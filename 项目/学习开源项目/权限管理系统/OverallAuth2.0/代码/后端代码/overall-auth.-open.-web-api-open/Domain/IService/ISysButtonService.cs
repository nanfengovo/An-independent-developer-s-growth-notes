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
    /// 按钮服务接口
    /// </summary>
    public interface ISysButtonService
    {
        /// <summary>
        /// 获取菜单拥有按钮
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <param name="roleId">角色id</param>
        /// <returns>返回对应按钮集合</returns>
        ReceiveStatus<SysButtonOutPut> GetMenuHaveButton(int menuId, int roleId);

        /// <summary>
        /// 新增按钮数据
        /// </summary>
        /// <param name="sysButton"></param>
        ReceiveStatus Insert(SysButton sysButton);

        /// <summary>
        /// 修改按钮数据
        /// </summary>
        /// <param name="sysButton"></param>
        ReceiveStatus Update(SysButton sysButton);

        /// <summary>
        /// 新增按钮角色权限
        /// </summary>
        /// <param name="menuButtonRoleInput"></param>
        /// <param name="loginResult">操作人员信息</param>
        ReceiveStatus InsertButtonRole(MenuButtonRoleInput menuButtonRoleInput, LoginResult loginResult);

        /// <summary>
        /// 获取按钮
        /// </summary>
        /// <param name="pageResultModel">分页模型</param>
        /// <param name="loginResult">登陆人员信息</param>
        /// <returns>返回按钮集合</returns>
        PageResultModel<SysButtonDataOutPut> GetButtonList(PageResultModel pageResultModel, LoginResult loginResult);

        /// <summary>
        /// 根据菜单和角色获取按钮
        /// </summary>
        /// <param name="roleId">角色集合</param>
        /// <param name="menuId">菜单id</param>
        /// <returns></returns>
        ReceiveStatus<SysButtonDataOutPut> GetButtonByRoleIdOrMenuId(List<int> roleId, int menuId);

        /// <summary>
        /// 获取所有下拉树菜单
        /// </summary>
        /// <returns></returns>
        ReceiveStatus<LayuiTree> GetMenuSelectTree();
    }
}
