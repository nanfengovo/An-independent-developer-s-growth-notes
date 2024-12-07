using Domain;
using Microsoft.AspNetCore.Mvc;
using Model.BusinessModel;
using Utility;

namespace ProjectManageWebApi.Controllers
{
    /// <summary>
    /// Sys_MenuTableRowAuth 菜单数据行权限
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SysMenuTableRowAuthController : BaseController
    {
        #region 构造实列化

        /// <summary>
        /// 菜单数据行权限服务
        /// </summary>
        public ISysMenuTableRowAuthService _sysMenuTableRowAuthService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sysMenuTableRowAuthService"></param>
        public SysMenuTableRowAuthController(ISysMenuTableRowAuthService sysMenuTableRowAuthService)
        {
            _sysMenuTableRowAuthService = sysMenuTableRowAuthService;
        }

        #endregion

        #region 接口实现

        /// <summary>
        /// 根据菜单id，获取菜单行权限配置
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns></returns>
        [HttpGet]
        public ReceiveStatus<LayuiSelectRowAuthExtend> GetTableRowAuthConfigByMenuId(int menuId)
        {
            var result = _sysMenuTableRowAuthService.GetTableRowAuthConfigByMenuId(menuId);
            return result;
        }

        /// <summary>
        /// 根据菜单id，获取菜单行权限
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns></returns>
        [HttpGet]
        public ReceiveStatus<SysMenuTableRowAuthOutPut> GetTableRowAuthByMenuId(int menuId)
        {
            var result = _sysMenuTableRowAuthService.GetTableRowAuthByMenuId(menuId);
            return result;
        }

        /// <summary>
        /// 根据菜单id，获取权限行配置信息数据源
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns></returns>
        [HttpGet]
        public ReceiveStatus<RowAuthConfigExendOutPut> GetRowAuthConfigByMenuId(int menuId)
        {
            var result = _sysMenuTableRowAuthService.GetRowAuthConfigByMenuId(menuId);
            return result;
        }

        /// <summary>
        /// 保存规则
        /// </summary>
        /// <param name="input">输入参数</param>
        /// <returns></returns>
        [HttpPost]
        public ReceiveStatus SaveRule(MatchingWhereInput input)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            _sysMenuTableRowAuthService.SaveRule(input, GetLoginUserMsg());
            return receiveStatus;
        }

        /// <summary>
        /// 设置规则是否启用
        /// 同一个菜单，只能启用一个规则
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="menuId">菜单id</param>
        /// <param name="isOpen">是否打开</param>
        [HttpGet]
        public ReceiveStatus SetRuleIsOpenById(int id, int menuId, bool isOpen)
        {
            return _sysMenuTableRowAuthService.SetRuleIsOpenById(id, menuId, isOpen);
        }

        /// <summary>
        /// 保存规则配置
        /// </summary>
        /// <param name="input">输入参数</param>
        [HttpPost]
        public ReceiveStatus SaveRuleConfig(SysMenuTableRowAuthConfigInput input)
        {
            return _sysMenuTableRowAuthService.SaveRuleConfig(input, GetLoginUserMsg());
        }

        /// <summary>
        /// 删除规则
        /// </summary>
        /// <param name="id">规则id</param>
        [HttpGet]
        public ReceiveStatus DeleteRule(int id)
        {
            return _sysMenuTableRowAuthService.DeleteRule(id);
        }

        /// <summary>
        /// 删除规则配置
        /// </summary>
        /// <param name="id">规则配置id</param>
        [HttpGet]
        public ReceiveStatus DeleteRuleConfig(int id)
        {
            return _sysMenuTableRowAuthService.DeleteRuleConfig(id);
        }
        #endregion
    }
}
