using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    /// <summary>
    /// 菜单数据行权限配置仓储接口实现
    /// </summary>
    public class SysMenuTableRowAuthConfigRepository : Repository<SysMenuTableRowAuthConfig>, ISysMenuTableRowAuthConfigRepository
    {
        /// <summary>
        /// 根据菜单id，获取菜单行权限配置
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns></returns>
        public List<SysMenuTableRowAuthConfig> GetTableRowAuthConfigByMenuId(int menuId)
        {
            string sql = " select * from  Sys_MenuTableRowAuthConfig where MenuId = @Key ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Query<SysMenuTableRowAuthConfig>(sql, new { Key = menuId }).ToList();
        }
    }
}
