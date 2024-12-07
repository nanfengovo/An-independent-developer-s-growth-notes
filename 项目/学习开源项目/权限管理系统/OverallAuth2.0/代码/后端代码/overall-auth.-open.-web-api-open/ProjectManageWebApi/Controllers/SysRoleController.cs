using Domain;
using Domain.IService;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.BusinessModel;
using System;
using Utility;

namespace ProjectManageWebApi.Controllers
{
    /// <summary>
    /// sys_role角色
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SysRoleController : BaseController
    {
        #region 构造实列化

        /// <summary>
        /// 用户服务
        /// </summary>
        public ISysRoleService _sysRoleService;
        /// <summary>
        /// 菜单服务
        /// </summary>
        public ISysMenuService _menuService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sysRoleService"></param>
        public SysRoleController(ISysRoleService sysRoleService, ISysMenuService menuService)
        {
            _sysRoleService = sysRoleService;
            _menuService = menuService;
        }

        #endregion

        #region 接口实现

        /// <summary>
        /// 获取所有角色信息（分页）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus GetAllRoleMsg(PageResultModel pageResultModel)
        {
            ReceiveStatus<SysRoleOutPut> receiveStatus = new ReceiveStatus<SysRoleOutPut>();
            var result = _sysRoleService.GetRoleList(pageResultModel, GetLoginUserMsg());
            receiveStatus.data = result.data;
            receiveStatus.total = result.total;
            return receiveStatus;
        }

        /// <summary>
        /// 获取所有角色信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ReceiveStatus<SysRole> GetAll()
        {
            ReceiveStatus<SysRole> receiveStatus = new ReceiveStatus<SysRole>();
            var result = _sysRoleService.GetAll();
            receiveStatus.data = result;
            return receiveStatus;
        }

        /// <summary>
        /// 根据角色id获取权限菜单
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="isDisabledGroup">是否禁用组--默认为false</param>
        /// <param name="isDisabledItem">是否禁用项--默认为false</param>
        /// <returns>返回角色所属菜单</returns>
        [HttpGet]
        public ReceiveStatus<LayuiTreeModel> GetMenuByRoleId(int roleId, bool isDisabledGroup = false, bool isDisabledItem = false)
        {
            var result = _sysRoleService.GetMenuByRoleId(roleId, isDisabledGroup, isDisabledItem);
            return result;
        }

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus AddRoleMsg(SysRole sysRole)
        {
            sysRole.CreateTime = DateTime.Now;
            sysRole.CreateUser = GetLoginUserMsg().UserId.ToString();
           return _sysRoleService.Insert(sysRole);
        }

        /// <summary>
        /// 修改角色权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus UpdataRoleAuthorityMsg(RoleMenuExend roleMenuExend)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            _sysRoleService.UpdataRoleAuthority(roleMenuExend.roleId, roleMenuExend.menuIds, GetLoginUserMsg().UserId);
            return receiveStatus;
        }
        #endregion
    }
}
