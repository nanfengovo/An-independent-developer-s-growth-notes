using Model;
using Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Domain
{
    /// <summary>
    /// 菜单数据列服务接口
    /// </summary>
    public interface ISysMenuTableColsService
    {
        /// <summary>
        /// 新增数据列
        /// </summary>
        /// <param name="sysMenuTableCols"></param>
        ReceiveStatus Insert(SysMenuTableCols sysMenuTableCols);

        /// <summary>
        /// 修改按钮数据
        /// </summary>
        /// <param name="sysMenuTableCols"></param>
        ReceiveStatus Update(SysMenuTableCols sysMenuTableCols);

        /// <summary>
        /// 删除数据列
        /// </summary>
        /// <param name="id">主键</param>
        void Delete(int id);

        /// <summary>
        /// 获取菜单数据列
        /// </summary>
        /// <param name="pageResultModel">分页模型</param>
        /// <param name="loginResult">登陆人员信息</param>
        /// <returns>返回菜单数据列集合</returns>
        PageResultModel<SysMenuTableColsDataOutPut> GetMenuTableColsList(PageResultModel pageResultModel, LoginResult loginResult);

        /// <summary>
        /// 获取菜单拥有的列
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <param name="roleId">角色id</param>
        /// <returns>返回对应列集合</returns>
        ReceiveStatus<SysMenuTableColsOutPut> GetMenuHaveTableCols(int menuId, int roleId);
    }
}
