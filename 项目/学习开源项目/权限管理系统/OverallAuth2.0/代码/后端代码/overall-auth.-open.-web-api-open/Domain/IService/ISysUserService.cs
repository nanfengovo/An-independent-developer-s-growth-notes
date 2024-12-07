using Model;
using Model.BusinessModel;
using System.Collections.Generic;
using Utility;

namespace Domain
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public interface ISysUserService
    {
        /// <summary>
        /// 根据用户名称和密码获取用户信息
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="password">用户密码</param>
        /// <returns></returns>
        ReceiveStatus<LoginResult> GetUserMsg(string userName, string password);

        /// <summary>
        /// 获取所有用户数据
        /// </summary>
        /// <returns></returns>
        List<SysUser> GetAll();

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="pageResultModel">分页模型</param>
        /// <param name="loginResult">登录人员信息</param>
        /// <returns></returns>
        PageResultModel<UserOrRoleOutPut> GetUserList(PageResultModel pageResultModel, LoginResult loginResult);

        /// <summary>
        /// 设置用户角色
        /// </summary>
        /// <param name="userOrRoleInput">传入模型</param>
        /// <param name="userId">修改用户id</param>
        ReceiveStatus SetUserRole(UserOrRoleInput userOrRoleInput, int userId);

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="sysUser"></param>
        ReceiveStatus Insert(SysUser sysUser);

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="sysUser"></param>
        ReceiveStatus Update(SysUser sysUser);

        /// <summary>
        /// 根据key获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SysUser GetByKey(string id);

        /// <summary>
        /// 反射
        /// </summary>
        ReceiveStatus test();

    }
}
