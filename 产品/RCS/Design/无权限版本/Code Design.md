> 受天津恩智浦的项目启发，对其进行重新设计

# 需求简介：
> 由上层系统（AMA）派单，RCS负责将运单拆分，通过接口下发给TM（调度），调度执行运单并向RCS同步状态，RCS不需要将状态变更通知到上层AMA;同时调度做完任务需要通知RCS,RCS可以取消调度正在执行的任务；RCS系统要做到不依赖于上层的AMA系统运行；
> RCS需支持以下几种任务：
> 	1、去取料处取一定数量的弹夹放到放料区
>     2、去取料处取一定数量的弹夹先放到机台，同时在机台上取一定数量的弹夹放到放料处，取的数量和放的数量不一定一致
# 原来选用的技术栈
> ABP(8.3.4)+SoybeanAdmin_NaiveUI+SqlServer
# 需求分析&&进一步设计：
*  AMA任务和自己产生的任务能否共用接口
* 状态变更优，尝试通过分布式事件驱动/尝试状态机的方式调度
* 接口调用设计优化
* 日志框架优化，能否模块化；包含系统日志（根据级别分类，需要日志来源），外部接口日志（日志来源），前端设计组件化
* 配置项模块化，一键导入导出
* 尝试任务流/低代码的方式/开放公开API(不单单指给AMA调用的)
## 扩展
后端不用ABP，试试微服务(最好在前端soy框架的基础上直接替换原来的后端)，前端试试不用框架，用vue手搓，数据库使用pgsql
# 后端 ：使用ABP框架
## 创建后端项目
> abp new RCS -u none --version 8.3.4

### 实现Swagger注释功能
#### 1、基础配置
在Host层和Application层的csproj文件中添加
```
<PropertyGroup>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>
    <DocumentationFile>$(OutputPath)$(AssemblyName).xml</DocumentationFile>
</PropertyGroup>

```
#### 2、Swagger 服务配置
在 RCSHttpApiHostModule.cs 中的 ConfigureSwaggerServices 方法：
```
private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
{
    context.Services.AddAbpSwaggerGenWithOAuth(
        configuration["AuthServer:Authority"]!,
        new Dictionary<string, string>
        {
            {"RCS", "RCS API"}
        },
        options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo 
            { 
                Title = "RCS API", 
                Version = "v1",
                Description = "RCS系统API文档 - 机器人控制系统接口"
            });
            
            // 包含XML注释文件
            var xmlFiles = new[]
            {
                "RCS.Application.Contracts.xml",
                "RCS.HttpApi.xml", 
                "RCS.HttpApi.Host.xml",
                "RCS.Application.xml"
            };
            
            foreach (var xmlFile in xmlFiles)
            {
                if (File.Exists(xmlFile))
                {
                    options.IncludeXmlComments(xmlFile, true);
                }
            }
        });
}

```
项目中使用了以下XML注释标签：

<summary>: 方法、类、属性的简要描述
<param>: 参数说明
<returns>: 返回值说明
<remarks>: 详细说明和备注
<response>: HTTP响应状态码说明
<example>: 示例值（特别用于DTO属性）