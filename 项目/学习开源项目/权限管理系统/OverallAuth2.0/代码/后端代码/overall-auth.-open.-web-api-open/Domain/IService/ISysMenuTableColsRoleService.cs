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
    /// 菜单数据列权限服务接口
    /// </summary>
    public interface ISysMenuTableColsRoleService
    {
        /// <summary>
        /// 新增数据列
        /// </summary>
        /// <param name="sysMenuTableColsRole">数据列数据</param>
        /// <param name="loginResult">登陆人员信息</param>
        ReceiveStatus Insert(SysMenuTableColsRoleInput sysMenuTableColsRole, LoginResult loginResult);

        /// <summary>
        /// 修改按钮数据
        /// </summary>
        /// <param name="sysMenuTableColsRole"></param>
        void Update(SysMenuTableColsRole sysMenuTableColsRole);

        /// <summary>
        /// 删除数据列
        /// </summary>
        /// <param name="id">主键</param>
        void Delete(int id);

        /// <summary>
        /// 根据角色id和菜单id获取菜单数据列
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="menuId">菜单id</param>
        /// <returns>返回对应菜单数据列集合</returns>
        ReceiveStatus<SysMenuTableColsDataOutPut> GetTableColsRoleByRoleIdOrMenuId(List<int> roleId, int menuId);
    }
}
