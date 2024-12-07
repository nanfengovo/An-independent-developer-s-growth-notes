using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    /// <summary>
    /// 显示控件结果数据源枚举
    /// </summary>
    public enum ShowControlDataSourceEnum
    {

        /// <summary>
        /// 手填
        /// </summary>
        [Description("手填")]
        HandInput = 1,

        /// <summary>
        /// 所有人员
        /// </summary>
        [Description("人员")]
        Personnel = 2,

        /// <summary>
        /// 角色
        /// </summary>
        [Description("角色")]
        UserRole = 3,

        /// <summary>
        /// 部门
        /// </summary>
        [Description("部门")]
        Department = 4,

        /// <summary>
        /// 当前登录用户
        /// </summary>
        [Description("当前登录用户--选择此数据只能选择单选下拉框")]
        CurrentUser = 5,

        /// <summary>
        /// 当前登录用户角色
        /// </summary>
        [Description("当前登录用户角色--选择此数据只能选择单选下拉框")]
        CurrentRole = 6,

        /// <summary>
        /// 当前登录用户部门
        /// </summary>
        [Description("当前登录用户部门--选择此数据只能选择单选下拉框")]
        CurrentDepartment = 7,
    }
}
