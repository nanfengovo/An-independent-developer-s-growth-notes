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
    /// 按钮角色仓储接口
    /// </summary>
    public interface ISysButtonRoleRepository : IRepository<SysButtonRole>
    {
        /// <summary>
        /// 根据角色id和菜单id获取按钮
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="menuId">菜单id</param>
        /// <returns>返回对应按钮集合</returns>
        List<SysButtonRole> GetButtonByRoleIdOrMenuId(int roleId, int menuId);

        /// <summary>
        /// 根据角色id和菜单id删除菜单按钮权限
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="menuId">菜单id</param>
        void DeleteButtonByRoleIdOrMenuId(int roleId, int menuId);

        /// <summary>
        /// 根据角色id和菜单id获取按钮
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="menuId">菜单id</param>
        /// <returns>返回对应按钮集合</returns>
        List<SysButtonDataOutPut> GetButtonByRoleIdOrMenuId(List<int> roleId, int menuId);
    }
}
