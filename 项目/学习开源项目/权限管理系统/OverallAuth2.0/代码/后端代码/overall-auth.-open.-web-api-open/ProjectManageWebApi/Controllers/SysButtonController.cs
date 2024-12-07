using Microsoft.AspNetCore.Mvc;
using Model.BusinessModel;
using Domain;
using Utility;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManageWebApi.Controllers
{
    /// <summary>
    /// Sys_Button 按钮
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SysButtonController : BaseController
    {
        #region 构造实列化

        /// <summary>
        /// 按钮服务
        /// </summary>
        public ISysButtonService _buttonService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="buttonService"></param>
        public SysButtonController(ISysButtonService buttonService)
        {
            _buttonService = buttonService;
        }

        #endregion

        #region 接口

        /// <summary>
        /// 获取菜单拥有按钮
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <param name="roleId">角色id</param>
        /// <returns>返回对应按钮集合</returns>
        [HttpGet]
        public ReceiveStatus<SysButtonOutPut> GetMenuHaveButton(int menuId, int roleId)
        {
            var list = _buttonService.GetMenuHaveButton(menuId, roleId);
            return list;
        }

        /// <summary>
        /// 新增按钮信息
        /// </summary>
        /// <param name="sysButton"></param>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus Insert(SysButton sysButton)
        {
            sysButton.CreateTime = DateTime.Now;
            sysButton.CreateUser = GetLoginUserMsg().UserId.ToString();
            return _buttonService.Insert(sysButton);
        }

        /// <summary>
        /// 修改按钮信息
        /// </summary>
        /// <param name="sysButton"></param>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus Update(SysButton sysButton)
        {
            sysButton.CreateTime = DateTime.Now;
            sysButton.CreateUser = GetLoginUserMsg().UserId.ToString();
            return _buttonService.Update(sysButton);
        }

        /// <summary>
        /// 新增按钮角色权限
        /// </summary>
        /// <param name="menuButtonRoleInput"></param>
        [HttpPost]
        public ReceiveStatus InsertButtonRole(MenuButtonRoleInput menuButtonRoleInput)
        {
            return _buttonService.InsertButtonRole(menuButtonRoleInput, GetLoginUserMsg());
        }

        /// <summary>
        /// 获取按钮--按钮列表
        /// </summary>
        /// <param name="pageResultModel">分页模型</param>
        /// <returns>返回按钮集合</returns>
        [HttpPost]
        public ReceiveStatus<SysButtonDataOutPut> GetButtonList(PageResultModel pageResultModel)
        {
            ReceiveStatus<SysButtonDataOutPut> receiveStatus = new ReceiveStatus<SysButtonDataOutPut>();
            var result = _buttonService.GetButtonList(pageResultModel, GetLoginUserMsg());
            receiveStatus.data = result.data;
            receiveStatus.total = result.total;
            return receiveStatus;
        }

        /// <summary>
        /// 获取所有下拉树菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ReceiveStatus<LayuiTree> GetMenuSelectTree()
        {
            var result = _buttonService.GetMenuSelectTree();
            return result;
        }

        /// <summary>
        /// 根据菜单id获取登陆人员对应菜单按钮
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns></returns>
        [HttpGet]
        public ReceiveStatus<SysButtonDataOutPut> GetButtonByMenuId(int menuId)
        {
            var roleIds = GetLoginUserMsg().RoleIds.ToString();
            List<int> roleId = new List<int>();
            roleId = roleIds.Split(',').Select(s => Convert.ToInt32(s)).ToList();
            var data = _buttonService.GetButtonByRoleIdOrMenuId(roleId, menuId);
            return data;
        }
        #endregion
    }
}
