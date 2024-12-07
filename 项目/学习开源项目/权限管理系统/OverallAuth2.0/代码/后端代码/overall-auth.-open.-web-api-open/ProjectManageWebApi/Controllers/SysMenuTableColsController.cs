using Domain;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.BusinessModel;
using System;
using Utility;

namespace ProjectManageWebApi.Controllers
{
    /// <summary>
    /// Sys_MenuTableCols 数据列
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SysMenuTableColsController : BaseController
    {
        #region 构造实列化

        /// <summary>
        /// 数据列服务
        /// </summary>
        public ISysMenuTableColsService _sysMenuTableColsService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sysMenuTableColsService"></param>
        public SysMenuTableColsController(ISysMenuTableColsService sysMenuTableColsService)
        {
            _sysMenuTableColsService = sysMenuTableColsService;
        }

        #endregion

        #region 接口

        /// <summary>
        /// 新增数据列
        /// </summary>
        /// <param name="sysMenuTableCols">实体模型</param>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus Insert(SysMenuTableCols sysMenuTableCols)
        {
            sysMenuTableCols.CreateTime = DateTime.Now;
            sysMenuTableCols.CreateUser = GetLoginUserMsg().UserId.ToString();
            return _sysMenuTableColsService.Insert(sysMenuTableCols);
        }

        /// <summary>
        /// 修改数据列
        /// </summary>
        /// <param name="sysMenuTableCols">实体模型</param>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus Update(SysMenuTableCols sysMenuTableCols)
        {
            sysMenuTableCols.CreateTime = DateTime.Now;
            sysMenuTableCols.CreateUser = GetLoginUserMsg().UserId.ToString();
            return _sysMenuTableColsService.Update(sysMenuTableCols);
        }

        /// <summary>
        /// 删除数据列
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete]
        public ReceiveStatus Delete(int id)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            _sysMenuTableColsService.Delete(id);
            return receiveStatus;
        }

        /// <summary>
        /// 获取菜单数据列
        /// </summary>
        /// <param name="pageResultModel">分页模型</param>
        /// <returns>返回菜单数据列集合</returns>
        [HttpPost]
        public ReceiveStatus<SysMenuTableColsDataOutPut> GetMenuTableColsList(PageResultModel pageResultModel)
        {
            ReceiveStatus<SysMenuTableColsDataOutPut> receiveStatus = new();
            var result = _sysMenuTableColsService.GetMenuTableColsList(pageResultModel, GetLoginUserMsg());
            receiveStatus.data = result.data;
            receiveStatus.total = result.total;
            return receiveStatus;
        }

        /// <summary>
        /// 获取菜单拥有的列
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <param name="roleId">角色id</param>
        /// <returns>返回对应列集合</returns>
        [HttpGet]
        public ReceiveStatus<SysMenuTableColsOutPut> GetMenuHaveTableCols(int menuId, int roleId)
        {
            var list = _sysMenuTableColsService.GetMenuHaveTableCols
                (menuId, roleId);
            return list;
        }

        #endregion
    }
}
