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
    /// 按钮仓储接口
    /// </summary>
    public interface ISysButtonRepository : IRepository<SysButton>
    {
        /// <summary>
        /// 根据菜单id获取按钮
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns>返回对应按钮集合</returns>
        List<SysButtonDataOutPut> GetButtonByMenuId(int menuId);
    }
}
