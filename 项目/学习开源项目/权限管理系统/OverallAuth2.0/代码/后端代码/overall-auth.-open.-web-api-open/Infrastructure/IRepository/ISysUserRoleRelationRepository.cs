using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// 用户与角色关系仓储接口
    /// </summary>
    public interface ISysUserRoleRelationRepository : IRepository<SysUserRoleRelation>
    {
        /// <summary>
        /// 根据用户获取角色关系
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        List<SysUserRoleRelation> GetSysUserRoleRelationsByUserId(int userId);

        /// <summary>
        /// 根据用户id删除数据
        /// </summary>
        /// <param name="userId">用户id</param>
        void DeleteByUserId(int userId);
    }
}
