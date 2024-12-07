using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.BusinessModel;
using System;
using System.Linq;
using Utility;

namespace ProjectManageWebApi.Controllers
{
    /// <summary>
    /// sys_user用户
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SysUserController : BaseController
    {

        #region 构造实列化

        /// <summary>
        /// 用户服务
        /// </summary>
        public ISysUserService _userService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userService"></param>
        public SysUserController(ISysUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region 接口实现

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous] // 不验证权限
        public ReceiveStatus<LoginResult> Login(LoginModel loginModel)
        {
            var result = _userService.GetUserMsg(loginModel.account, loginModel.password);
            if (result.data.Count > 0)
            {
                var loginResult = result.data.First();
                var tokenResult = JwtHelper.BuildToken(loginResult);
                result.data = new System.Collections.Generic.List<LoginResult>() { tokenResult };
            }
            return result;
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public void LogOut()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }

        ///// <summary>
        ///// 反射
        ///// </summary>
        //[AllowAnonymous] // 不验证权限
        //public ReceiveStatus test()
        //{
        //    return _userService.test();
        //}

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="sysUser"></param>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus AddUserMsg(SysUser sysUser)
        {
            sysUser.CreateTime = DateTime.Now;
            sysUser.CreateUser = GetLoginUserMsg().UserId.ToString();
            return _userService.Insert(sysUser);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="sysUser"></param>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus UpdateUserMsg(SysUser sysUser)
        {
            sysUser.CreateTime = DateTime.Now;
            sysUser.CreateUser = GetLoginUserMsg().UserId.ToString();
            return _userService.Update(sysUser);
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ReceiveStatus GetAllUserMsg()
        {
            ReceiveStatus<SysUser> receiveStatus = new ReceiveStatus<SysUser>();
            var data = _userService.GetAll();
            receiveStatus.data = data;
            return receiveStatus;
        }

        /// <summary>
        /// 获取用户--用户管理列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus<UserOrRoleOutPut> GetUserList(PageResultModel pageResultModel)
        {
            ReceiveStatus<UserOrRoleOutPut> receiveStatus = new ReceiveStatus<UserOrRoleOutPut>();
            var result = _userService.GetUserList(pageResultModel, GetLoginUserMsg());
            receiveStatus.data = result.data;
            receiveStatus.total = result.total;
            return receiveStatus;
        }

        /// <summary>
        /// 设置用户角色
        /// </summary>
        /// <param name="userOrRoleInput">传入参数</param>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus SetUserRole(UserOrRoleInput userOrRoleInput)
        {
            return _userService.SetUserRole(userOrRoleInput, GetLoginUserMsg().UserId);
        }
        #endregion
    }
}
