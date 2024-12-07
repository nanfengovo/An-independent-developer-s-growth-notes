using System.ComponentModel;

namespace Utility
{
    /// <summary>
    /// 权限字段枚举
    /// </summary>
    public enum PermissionsFieldEnum
    {
        /// <summary>
        /// 当前登录用户
        /// </summary>
        [Description("当前登录用户")]
        CurrentUser = 1,

        /// <summary>
        /// 当前登录用户角色
        /// </summary>
        [Description("当前登录用户角色")]
        CurrentRole = 2,

        /// <summary>
        /// 当前登录用户部门
        /// </summary>
        [Description("当前登录用户部门")]
        CurrentDepartment = 3,

        /// <summary>
        /// 创建用户
        /// </summary>
        [Description("创建用户")]
        CreateUser = 4,

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        CreateTime = 5,
    }
}
