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
    /// 角色服务接口
    /// </summary>
    public interface ISysRoleService
    {
        /// <summary>
        /// 获取所有角色数据
        /// </summary>
        /// <returns></returns>
        List<SysRole> GetAll();

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="sysRole"></param>
        ReceiveStatus Insert(SysRole sysRole);

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="sysRole"></param>
        ReceiveStatus Update(SysRole sysRole);

        /// <summary>
        /// 根据key获取角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SysRole GetByKey(string id);

        /// <summary>
        /// 获取所有角色（分页）
        /// </summary>
        /// <param name="pageResultModel">分页模型</param>
        /// <param name="loginResult">登陆人员信息</param>
        /// <returns></returns>
        PageResultModel<SysRoleOutPut> GetRoleList(PageResultModel pageResultModel, LoginResult loginResult);

        /// <summary>
        /// 根据角色id获取权限菜单
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="isDisabledGroup">是否禁用组</param>
        /// <param name="isDisabledItem">是否禁用项</param>
        /// <returns>返回角色所属菜单</returns>
        ReceiveStatus<LayuiTreeModel> GetMenuByRoleId(int roleId, bool isDisabledGroup, bool isDisabledItem);

        /// <summary>
        /// 修改角色权限
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="menuIds">菜单id集合</param>
        /// <param name="userId">操作人员id</param>
        void UpdataRoleAuthority(int roleId, List<int> menuIds, int userId);
    }
}
