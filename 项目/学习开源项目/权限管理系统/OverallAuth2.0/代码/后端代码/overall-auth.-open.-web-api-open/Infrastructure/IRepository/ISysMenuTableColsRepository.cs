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
    /// 菜单数据列仓储接口
    /// </summary>
    public interface ISysMenuTableColsRepository : IRepository<SysMenuTableCols>
    {
        /// <summary>
        /// 根据菜单id获取列
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns>返回对应列集合</returns>
        List<SysMenuTableColsDataOutPut> GetTableColsByMenuId(int menuId);

        /// <summary>
        /// 根据菜单id和数据权限类型获取列
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <param name="dataRowAuthType">数据权限类型</param>
        /// <returns>返回对应列集合</returns>
        List<SysMenuTableColsDataOutPut> GetTableColsByMenuIdOrDataRowAuthType(int menuId, int dataRowAuthType);

        /// <summary>
        /// 根据菜单id和字段名称获取数据列
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <param name="fieldName">字段名称</param>
        /// <returns>返回数据列</returns>
        SysMenuTableCols GetTableColsByMenuIdOrFieldName(int menuId, string fieldName);

        /// <summary>
        /// 修改字段信息
        /// </summary>
        /// <param name="sysMenuTableCols"></param>
        void UpdateTableCols(SysMenuTableCols sysMenuTableCols);
    }
}
