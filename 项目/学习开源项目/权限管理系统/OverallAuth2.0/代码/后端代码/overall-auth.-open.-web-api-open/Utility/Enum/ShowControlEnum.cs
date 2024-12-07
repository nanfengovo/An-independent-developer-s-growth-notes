using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    /// <summary>
    /// 显示控件枚举
    /// </summary>
    public enum ShowControlEnum
    {
        /// <summary>
        /// 输入框
        /// </summary>
        [Description("输入框")]
        Input = 1,

        /// <summary>
        /// 单选下拉框
        /// </summary>
        [Description("单选下拉框")]
        RadioSelect = 2,

        /// <summary>
        /// 多选下拉框
        /// </summary>
        [Description("多选下拉框")]
        MultipleSelect = 3,

        /// <summary>
        /// 树形下拉框
        /// </summary>
        [Description("树形下拉框")]
        TreeSelect = 4,

        /// <summary>
        /// 弹出层
        /// </summary>
        [Description("弹出层")]
        Layer = 5,

        /// <summary>
        /// 时间
        /// </summary>
        [Description("时间")]
        DateTimeStr = 6,
    }
}
