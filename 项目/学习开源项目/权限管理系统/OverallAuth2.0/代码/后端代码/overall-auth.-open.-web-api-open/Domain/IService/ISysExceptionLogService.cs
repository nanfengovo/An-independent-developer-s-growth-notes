using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// 异常日志服务
    /// </summary>
    public interface ISysExceptionLogService
    {
        /// <summary>
        /// 新增异常
        /// </summary>
        /// <param name="sysExceptionLog"></param>
        void insert(SysExceptionLog sysExceptionLog);
    }
}
