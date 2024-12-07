using Model;
using Model.BusinessModel;
using System.Collections.Generic;

namespace Infrastructure
{
    /// <summary>
    /// 菜单仓储
    /// </summary>
    public interface ISysMenuRepository : IRepository<Menu>
    {
        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        List<Menu> GetMenusList();

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <param name="authWhere">权限条件</param>
        /// <returns></returns>
        List<MenuOutput> GetAllMenusList(string authWhere);

        /// <summary>
        /// 根据菜单id获取菜单
        /// </summary>
        /// <param name="menuId">菜单id集合</param>
        /// <returns></returns>
        List<Menu> GetMenusByMenuIdList(List<int> menuId);
    }
}
