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
    /// 菜单数据行权限服务接口
    /// </summary>
    public interface ISysMenuTableRowAuthService
    {
        /// <summary>
        /// 根据菜单id，获取菜单行权限配置
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns></returns>
        ReceiveStatus<LayuiSelectRowAuthExtend> GetTableRowAuthConfigByMenuId(int menuId);

        /// <summary>
        /// 保存规则
        /// </summary>
        /// <param name="input">输入参数</param>
        /// <param name="loginResult">登陆人员信息</param>
        void SaveRule(MatchingWhereInput input, LoginResult loginResult);

        /// <summary>
        /// 设置规则是否启用
        /// 同一个菜单，只能启用一个规则
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="menuId">菜单id</param>
        /// <param name="isOpen">是否打开</param>
        ReceiveStatus SetRuleIsOpenById(int id, int menuId, bool isOpen);

        /// <summary>
        /// 根据菜单id，获取菜单行权限
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns></returns>
        ReceiveStatus<SysMenuTableRowAuthOutPut> GetTableRowAuthByMenuId(int menuId);

        /// <summary>
        /// 根据菜单id，获取权限行配置信息数据源
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns></returns>
        ReceiveStatus<RowAuthConfigExendOutPut> GetRowAuthConfigByMenuId(int menuId);

        /// <summary>
        /// 保存规则配置
        /// </summary>
        /// <param name="input">输入参数</param>
        /// <param name="loginResult">操作人员信息</param>
        ReceiveStatus SaveRuleConfig(SysMenuTableRowAuthConfigInput input, LoginResult loginResult);

        /// <summary>
        /// 删除规则
        /// </summary>
        /// <param name="id">规则id</param>
        ReceiveStatus DeleteRule(int id);

        /// <summary>
        /// 删除规则配置
        /// </summary>
        /// <param name="id">规则配置id</param>
        ReceiveStatus DeleteRuleConfig(int id);
    }
}
