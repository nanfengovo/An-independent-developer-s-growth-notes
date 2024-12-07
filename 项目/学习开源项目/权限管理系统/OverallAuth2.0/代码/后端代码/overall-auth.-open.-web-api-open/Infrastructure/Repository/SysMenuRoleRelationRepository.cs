using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// 菜单与角色仓储
    /// </summary>
    public class SysMenuRoleRelationRepository : Repository<SysMenuRoleRelation>, ISysMenuRoleRelationRepository
    {
        /// <summary>
        /// 根据角色获取菜单关系
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <returns></returns>
        public List<SysMenuRoleRelation> GetSysMenuRoleRelationByRoleId(List<int> roleId)
        {
            string sql = " select * from  Sys_MenuRoleRelation where RoleId in @Key ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Query<SysMenuRoleRelation>(sql, new { Key = roleId.ToArray() }).ToList();
        }

        /// <summary>
        /// 根据角色id删除数据
        /// </summary>
        /// <param name="roleId">角色id</param>
        public void DeleteByRoleId(int roleId)
        {
            string sql = " delete from  Sys_MenuRoleRelation where RoleId=@RoleId ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            connection.Execute(sql, new { RoleId = roleId });
        }
    }
}
