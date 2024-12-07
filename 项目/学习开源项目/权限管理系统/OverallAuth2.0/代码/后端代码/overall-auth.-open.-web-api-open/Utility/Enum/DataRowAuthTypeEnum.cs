using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    /// <summary>
    /// 数据行权限类型枚举
    /// </summary>
    public enum DataRowAuthTypeEnum
    {
        /// <summary>
        /// 数据行权限字段
        /// </summary>
        DataRowAuthField = 1,

        /// <summary>
        ///  非数据行权限字段
        /// </summary>
        UnDataRowAuthField = 2,
    }
}
