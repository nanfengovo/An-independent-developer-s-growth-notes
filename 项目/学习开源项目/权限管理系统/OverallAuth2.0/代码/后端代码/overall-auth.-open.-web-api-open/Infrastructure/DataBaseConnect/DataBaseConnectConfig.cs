using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// 数据库连接配置
    /// </summary>
    public static class DataBaseConnectConfig
    {
        /// <summary>
        /// 声明静态连接
        /// </summary>
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static DataBaseConnectConfig()
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载            
            Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
        }

        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="sqlConnectionStr">连接数据库字符串</param>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection(string sqlConnectionStr = null)
        {

            if (string.IsNullOrWhiteSpace(sqlConnectionStr))
            {
                sqlConnectionStr = Configuration["ConnectionStrings:SqlConnection"];
            }
            var connection = new SqlConnection(sqlConnectionStr);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }
    }
}
