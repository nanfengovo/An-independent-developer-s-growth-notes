using Domain;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace ProjectManageWebApi.Controllers
{
    /// <summary>
    /// Sys_MenuTableColsRole 数据列权限
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SysMenuTableColsRoleController : BaseController
    {
        #region 构造实列化

        /// <summary>
        /// 数据列权限服务
        /// </summary>
        public ISysMenuTableColsRoleService _sysMenuTableColsRoleService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sysMenuTableColsRoleService"></param>
        public SysMenuTableColsRoleController(ISysMenuTableColsRoleService sysMenuTableColsRoleService)
        {
            _sysMenuTableColsRoleService = sysMenuTableColsRoleService;
        }

        #endregion

        #region 接口

        /// <summary>
        /// 新增数据列权限
        /// </summary>
        /// <param name="sysMenuTableColsRole">实体模型</param>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus Insert(SysMenuTableColsRoleInput sysMenuTableColsRole)
        {
            return _sysMenuTableColsRoleService.Insert(sysMenuTableColsRole, GetLoginUserMsg());
        }

        /// <summary>
        /// 修改数据列权限
        /// </summary>
        /// <param name="sysMenuTableColsRole">实体模型</param>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus Update(SysMenuTableColsRole sysMenuTableColsRole)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            sysMenuTableColsRole.CreateTime = DateTime.Now;
            sysMenuTableColsRole.CreateUser = GetLoginUserMsg().UserId.ToString();
            _sysMenuTableColsRoleService.Update(sysMenuTableColsRole);
            return receiveStatus;
        }

        /// <summary>
        /// 删除数据列权限
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete]
        public ReceiveStatus Delete(int id)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            _sysMenuTableColsRoleService.Delete(id);
            return receiveStatus;
        }

        /// <summary>
        /// 根据菜单id获取登陆人员菜单数据列
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns>返回对应菜单数据列集合</returns>
        [HttpGet]
        public ReceiveStatus<SysMenuTableColsDataOutPut> GetTableColsRoleByMenuId(int menuId)
        {
            var roleIds = GetLoginUserMsg().RoleIds.ToString();
            List<int> roleId = new List<int>();
            roleId = roleIds.Split(',').Select(s => Convert.ToInt32(s)).ToList();
            var data = _sysMenuTableColsRoleService.GetTableColsRoleByRoleIdOrMenuId(roleId, menuId);
            return data;
        }
        #endregion
    }
}
