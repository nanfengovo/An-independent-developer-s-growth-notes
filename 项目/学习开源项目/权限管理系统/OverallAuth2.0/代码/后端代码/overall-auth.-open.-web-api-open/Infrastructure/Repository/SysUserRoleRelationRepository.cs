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
    /// 用户与角色关系仓储
    /// </summary>
    public class SysUserRoleRelationRepository : Repository<SysUserRoleRelation>, ISysUserRoleRelationRepository
    {
        /// <summary>
        /// 根据用户获取角色关系
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<SysUserRoleRelation> GetSysUserRoleRelationsByUserId(int userId)
        {
            string sql = " select * from  Sys_UserRoleRelation  where UserId = @UserId ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Query<SysUserRoleRelation>(sql, new { UserId = userId }).ToList();
        }

        /// <summary>
        /// 根据用户id删除数据
        /// </summary>
        /// <param name="userId">用户id</param>
        public void DeleteByUserId(int userId)
        {
            string sql = " delete from  Sys_UserRoleRelation where UserId=@UserId ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            connection.Execute(sql, new { UserId = userId });
        }
    }
}
