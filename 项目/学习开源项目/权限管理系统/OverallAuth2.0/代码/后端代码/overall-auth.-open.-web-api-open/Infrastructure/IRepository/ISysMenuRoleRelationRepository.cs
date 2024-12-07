using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// 菜单与角色仓储接口
    /// </summary>
    public interface ISysMenuRoleRelationRepository : IRepository<SysMenuRoleRelation>
    {
        /// <summary>
        /// 根据角色获取菜单关系
        /// </summary>
        /// <param name="roleId">角色id集合</param>
        /// <returns></returns>
        List<SysMenuRoleRelation> GetSysMenuRoleRelationByRoleId(List<int> roleId);

        /// <summary>
        /// 根据角色id删除数据
        /// </summary>
        /// <param name="roleId">角色id</param>
        void DeleteByRoleId(int roleId);
    }
}
