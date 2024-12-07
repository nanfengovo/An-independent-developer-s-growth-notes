using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    /// <summary>
    /// 条件等式值枚举
    /// </summary>
    [Flags]
    public enum ConditionalEquationValueEnum
    {
        /// <summary>
        /// 等于
        /// </summary>
        [Description("=")]
        等于 = 1,

        /// <summary>
        /// 不等于
        /// </summary>
        [Description("!=")]
        不等于 = 2,

        /// <summary>
        /// 大于
        /// </summary>
        [Description(">")]
        大于 = 4,

        /// <summary>
        /// 大于等于
        /// </summary>
        [Description(">=")]
        大于等于 = 8,

        /// <summary>
        /// 小于
        /// </summary>
        [Description("<")]
        小于 = 16,

        /// <summary>
        /// 小于等于
        /// </summary>
        [Description("<=")]
        小于等于 = 32,

        /// <summary>
        /// 包含
        /// </summary>
        [Description("Contains")]
        包含 = 64,

        /// <summary>
        /// 不包含
        /// </summary>
        [Description("NotContains")]
        不包含 = 128,

    }
}
