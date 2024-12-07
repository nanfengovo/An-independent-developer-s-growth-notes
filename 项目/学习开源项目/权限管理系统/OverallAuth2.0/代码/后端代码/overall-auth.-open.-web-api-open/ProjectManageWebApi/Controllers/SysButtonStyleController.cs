using Domain;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.BusinessModel;
using System;
using Utility;

namespace ProjectManageWebApi.Controllers
{
    /// <summary>
    /// Sys_ButtonStyle 按钮样式
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SysButtonStyleController : BaseController
    {
        #region 构造实列化

        /// <summary>
        /// 按钮样式服务
        /// </summary>
        public ISysButtonStyleService _sysButtonStyleService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sysButtonStyleService"></param>
        public SysButtonStyleController(ISysButtonStyleService sysButtonStyleService)
        {
            _sysButtonStyleService = sysButtonStyleService;
        }

        #endregion

        #region 接口

        /// <summary>
        /// 添加按钮样式信息
        /// </summary>
        /// <param name="sysButtonStyle"></param>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus AddButtonStyleMsg(SysButtonStyle  sysButtonStyle)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            sysButtonStyle.CreateTime = DateTime.Now;
            sysButtonStyle.CreateUser = GetLoginUserMsg().UserId.ToString();
            _sysButtonStyleService.Insert(sysButtonStyle);
            return receiveStatus;
        }

        /// <summary>
        /// 修改按钮样式信息
        /// </summary>
        /// <param name="sysButtonStyle"></param>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus UpdateButtonStyleMsg(SysButtonStyle sysButtonStyle)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            sysButtonStyle.CreateTime = DateTime.Now;
            sysButtonStyle.CreateUser = GetLoginUserMsg().UserId.ToString();
            _sysButtonStyleService.Update(sysButtonStyle);
            return receiveStatus;
        }

        /// <summary>
        /// 删除按钮样式信息
        /// </summary>
        /// <param name="buttonStyleId"></param>
        /// <returns></returns>
        [HttpDelete]
        public ReceiveStatus DeleteButtonStyleMsg(int buttonStyleId)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            _sysButtonStyleService.Delete(buttonStyleId);
            return receiveStatus;
        }

        /// <summary>
        /// 获取所有按钮样式数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ReceiveStatus<SysButtonStyleOutPut> GetAllButtonStyle(string buttonStyleName, string menuId)
        {
            ReceiveStatus<SysButtonStyleOutPut> receiveStatus = new ReceiveStatus<SysButtonStyleOutPut>();
            var list = _sysButtonStyleService.GetAll(buttonStyleName, menuId,GetLoginUserMsg());
            receiveStatus.data = list;
            return receiveStatus;
        }
        #endregion
    }
}
