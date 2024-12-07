using Dapper;
using Model;
using Model.BusinessModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    /// <summary>
    /// 菜单仓储
    /// </summary>
    public class SysMenuRepository : Repository<Menu>, ISysMenuRepository
    {
        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public List<Menu> GetMenusList()
        {
            string sql = " select * from  Sys_Menu ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Query<Menu>(sql).ToList();
        }


        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <param name="authWhere">权限条件</param>
        /// <returns></returns>
        public List<MenuOutput> GetAllMenusList(string authWhere)
        {
            StringBuilder sql = new(@" select sm.*,su.UserName from  Sys_Menu  sm 
                                       inner join Sys_User as su on sm.CreateUser = su.UserId ");
            var qp = new QueryParameter();
            if (!string.IsNullOrWhiteSpace(authWhere))
            {
                qp.listWhere.Append(authWhere);
            }
            if (!string.IsNullOrEmpty(qp.listWhere.ToString()))
            {
                sql.Append(" WHERE 1=1 " + qp.listWhere.ToString());
            }
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Query<MenuOutput>(sql.ToString(), qp.dynamicParameter).ToList();
        }

        /// <summary>
        /// 根据菜单id获取菜单
        /// </summary>
        /// <param name="menuId">菜单id集合</param>
        /// <returns></returns>
        public List<Menu> GetMenusByMenuIdList(List<int> menuId)
        {
            string sql = " select * from  Sys_Menu where Id in @Key ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Query<Menu>(sql, new { Key = menuId }).ToList();
        }
    }
}
