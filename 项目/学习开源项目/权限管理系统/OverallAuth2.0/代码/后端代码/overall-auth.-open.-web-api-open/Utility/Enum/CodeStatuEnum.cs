using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    /// <summary>
    /// 操作状态
    /// </summary>
    public enum CodeStatuEnum
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        Successful = 200,

        /// <summary>
        ///  警告
        /// </summary>
        Warning = 99991,

        /// <summary>
        /// 操作引发错误
        /// </summary>
        Error = 99992
    }
}
