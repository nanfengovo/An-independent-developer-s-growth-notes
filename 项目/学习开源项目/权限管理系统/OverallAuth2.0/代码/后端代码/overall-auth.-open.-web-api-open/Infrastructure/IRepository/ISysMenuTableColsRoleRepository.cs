using Model;
using Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// 菜单数据列权限仓储接口
    /// </summary>
    public interface ISysMenuTableColsRoleRepository : IRepository<SysMenuTableColsRole>
    {
        /// <summary>
        /// 根据角色id和菜单id获取菜单数据列
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="menuId">菜单id</param>
        /// <returns>返回对应菜单数据列集合</returns>
        List<SysMenuTableColsRole> GetTableColsRoleByRoleIdOrMenuId(int roleId, int menuId);

        /// <summary>
        /// 根据角色id和菜单id获取菜单数据列
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="menuId">菜单id</param>
        /// <returns>返回对应菜单数据列集合</returns>
        List<SysMenuTableColsDataOutPut> GetTableColsRoleByRoleIdOrMenuId(List<int> roleId, int menuId);

        /// <summary>
        /// 根据角色id和菜单id删除菜单列权限
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="menuId">菜单id</param>
        void DeleteMenuTableColsByRoleIdOrMenuId(int roleId, int menuId);
    }
}
