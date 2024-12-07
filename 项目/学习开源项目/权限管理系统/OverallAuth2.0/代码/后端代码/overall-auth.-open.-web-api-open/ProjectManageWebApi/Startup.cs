using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Utility;

namespace ProjectManageWebApi
{
    /// <summary>
    /// 启动类
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 声明配置
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //接口文档添加说明
            services.AddSwaggerGen(options =>
            {
                // 注释
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // 第二个参数为是否显示控制器注释,我们选择true
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), true);
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });

                // 生成多个文档显示
                //typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
                //{
                //    //添加文档介绍
                //    options.SwaggerDoc(version, new OpenApiInfo
                //    {
                //        Title = $"项目名",
                //        Version = version,
                //        Description = $"项目名:{version}版本"
                //    });
                //});
            });

            //允许一个或多个来源可以跨域
            services.AddCors(options =>
            {
                options.AddPolicy("CustomCorsPolicy", policy =>
                {
                    // 设定允许跨域的来源，有多个可以用','隔开
                    policy.WithOrigins(Configuration.GetValue<string>("CustomCorsPolicy:WhiteList").Split(','))
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            //添加全局异常处理机制
            services.AddMvc(option =>
            {
                option.Filters.Add<ExceptionFilter>();
            });

            //时间格式处理
            services.AddControllers().AddJsonOptions(configure =>
            {
                configure.JsonSerializerOptions.Converters.Add(new DatetimeJsonConverter());

            });

            //jwt鉴权
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, option =>
            {
                var jwtsetting = ConfigurationFileHelper.GetNode<JwtSetting>("JwtSetting");
                Configuration.Bind("JwtSetting", jwtsetting);
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = jwtsetting.Issuer,//发行人
                    ValidAudience = jwtsetting.Audience,//订阅人
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtsetting.SecurityKey)),//解密的密钥
                    ValidateIssuerSigningKey = true,//是否验证签名,不验证的画可以篡改数据，不安全
                    ValidateIssuer = true,//是否验证发行人，就是验证载荷中的Iss是否对应ValidIssuer参数
                    ValidateAudience = true,//是否验证订阅人，就是验证载荷中的Aud是否对应ValidAudience参数
                    ValidateLifetime = true,//是否验证过期时间，过期了就拒绝访问
                    ClockSkew = TimeSpan.Zero,//这个是缓冲过期时间，也就是说，即使我们配置了过期时间，这里也要考虑进去，过期时间+缓冲，默认好像是7分钟，你可以直接设置为0
                    //RequireExpirationTime = true,
                };

                //option.Events = new JwtBearerEvent();
            });
        }

        /// <summary>
        /// Autofac注册服务的地方,Autofac会自动调用
        /// </summary>
        /// <param name="containerBuilder"></param>
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            //单个服务注册示例
            //   builder.RegisterType<MenuService>().As<IMenuService>();
            //    builder.RegisterType<IUserService>().As<IUserService>();

            //服务项目程序集
            Assembly service = Assembly.Load("Domain");
            Assembly intracface = Assembly.Load("Infrastructure");

            //项目必须以xxx结尾
            containerBuilder.RegisterAssemblyTypes(service).Where(n => n.Name.EndsWith("Service") && !n.IsAbstract)
                .InstancePerLifetimeScope().AsImplementedInterfaces();
            containerBuilder.RegisterAssemblyTypes(intracface).Where(n => n.Name.EndsWith("Repository") && !n.IsAbstract)
               .InstancePerLifetimeScope().AsImplementedInterfaces();
        }

        /// <summary>
        /// 配置对接
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectManageWebApi v1"));
            //}
            // 设定特定ip允许跨域 CustomCorsPolicy是在ConfigureServices方法中配置的跨域策略名称
            app.UseCors("CustomCorsPolicy");

            //路由中间件
            app.UseRouting();
            //认证中间件
            app.UseAuthentication();
            //授权中间件
            app.UseAuthorization();
            //终结点
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute()
                    .RequireAuthorization();
            });

        }
    }
}
