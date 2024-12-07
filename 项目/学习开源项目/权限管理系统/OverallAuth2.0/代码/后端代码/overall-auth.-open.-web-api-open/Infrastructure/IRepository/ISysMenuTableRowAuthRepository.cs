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
    /// 菜单数据行权限仓储接口
    /// </summary>
    public interface ISysMenuTableRowAuthRepository : IRepository<SysMenuTableRowAuth>
    {
        /// <summary>
        /// 根据菜单id，获取菜单行权限
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns></returns>
        List<SysMenuTableRowAuthOutPut> GetTableRowAuthByMenuId(int menuId);

        /// <summary>
        /// 批量更新IsOpen字段
        /// </summary>
        /// <param name="menuId">主键集合</param>
        /// <param name="isOpen">是否开启</param>
        void UpdateIsOpenById(int menuId, bool isOpen);

        /// <summary>
        /// 批量更新IsOpen字段
        /// </summary>
        /// <param name="id">主键集合</param>
        /// <param name="isOpen">是否开启</param>
        void UpdateIsOpenByMenuId(int id, bool isOpen);
    }
}
