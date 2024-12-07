using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// 菜单数据行权限配置仓储接口
    /// </summary>
    public interface ISysMenuTableRowAuthConfigRepository : IRepository<SysMenuTableRowAuthConfig>
    {
        /// <summary>
        /// 根据菜单id，获取菜单行权限配置
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns></returns>
        List<SysMenuTableRowAuthConfig> GetTableRowAuthConfigByMenuId(int menuId);
    }
}
