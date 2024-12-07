using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace ProjectManageWebApi
{
    /// <summary>
    /// appsettings帮助类
    /// </summary>
    public class ConfigurationFileHelper
    {
        /// <summary>
        /// 声明配置属性
        /// </summary>
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        static ConfigurationFileHelper()
        {
            Configuration = new ConfigurationBuilder()
                 .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
                 .Build();
        }

        /// <summary>
        /// 获得配置文件的对象值
        /// </summary>
        /// <param name="jsonPath">文件路径</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetJson(string jsonPath, string key)
        {
            if (string.IsNullOrEmpty(jsonPath) || string.IsNullOrEmpty(key)) return null;
            IConfiguration config = new ConfigurationBuilder().AddJsonFile(jsonPath).Build();//json文件地址
            return config.GetSection(key).Value;//json某个对象
        }

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetMysqlConnection()
        {
            return Configuration.GetConnectionString("MySql").Trim();
        }

        /// <summary>
        /// 根据节点名称获取配置模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Node"></param>
        /// <returns></returns>
        public static T GetNode<T>(string Node) where T : new()
        {
            T model = Configuration.GetSection(Node).Get<T>();
            return model;

        }

    }
}
