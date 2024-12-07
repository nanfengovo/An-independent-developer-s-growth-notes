using Domain.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.BusinessModel;
using System;
using System.Linq;
using Utility;

namespace ProjectManageWebApi.Controllers
{
    /// <summary>
    /// sys_menu菜单
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SysMenuController : BaseController
    {

        #region 构造实列化

        /// <summary>
        /// 菜单服务
        /// </summary>
        public ISysMenuService _menuService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="menuService"></param>
        public SysMenuController(ISysMenuService menuService)
        {
            _menuService = menuService;
        }

        #endregion

        #region 接口

        /// <summary>
        /// 获取菜单--上下级关系
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ReceiveStatus<MenuDao> GetAllChildren()
        {
            ReceiveStatus<MenuDao> receiveStatus = new ReceiveStatus<MenuDao>();
            var list = _menuService.GetAllChildren();
            receiveStatus.data = list;
            return receiveStatus;
        }

        /// <summary>
        /// 根据用户id获取权限菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ReceiveStatus<MenuDao> GetMenuByUserId()
        {
            ReceiveStatus<MenuDao> receiveStatus = new ReceiveStatus<MenuDao>();
            var result = _menuService.GetMenuByUserId(GetLoginUserMsg().UserId.ToString());
            return result;
        }

        /// <summary>
        /// 获取菜单--菜单管理列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ReceiveStatus<MenuOutput> GetMenusList(PageResultModel pageResultModel)
        {
            ReceiveStatus<MenuOutput> receiveStatus = new ReceiveStatus<MenuOutput>();
            var result = _menuService.GetMenusList(pageResultModel,GetLoginUserMsg());
            receiveStatus.data = result.data;
            receiveStatus.total = result.total;
            return receiveStatus;
        }

        /// <summary>
        /// 获取父级菜单数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ReceiveStatus<Menu> GetParentMenusList()
        {
            ReceiveStatus<Menu> receiveStatus = new ReceiveStatus<Menu>();
            var data = _menuService.GetAll().Where(f => f.Pid == 0).ToList();
            receiveStatus.data = data;
            return receiveStatus;
        }

        /// <summary>
        /// 添加菜单信息
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus AddMenuMsg(Menu menu)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            menu.CreateTime = DateTime.Now;
            menu.CreateUser = GetLoginUserMsg().UserId.ToString();
            _menuService.Insert(menu);
            return receiveStatus;
        }

        /// <summary>
        /// 修改菜单信息
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus UpdateMenuMsg(Menu menu)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            menu.CreateTime = DateTime.Now;
            menu.CreateUser = GetLoginUserMsg().UserId.ToString();
            _menuService.Update(menu);
            return receiveStatus;
        }
        #endregion
    }
}
