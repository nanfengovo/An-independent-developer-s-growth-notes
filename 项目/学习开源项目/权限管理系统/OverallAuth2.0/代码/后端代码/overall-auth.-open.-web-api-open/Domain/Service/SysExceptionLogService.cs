using Domain;
using Infrastructure;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// 异常日志服务实现
    /// </summary>
    public class SysExceptionLogService : ISysExceptionLogService
    {
        #region 构造实列化

        //实例化异常仓储
        private readonly ISysExceptionLogRepository _sysExceptionLogRepository;

        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        /// <param name="sysExceptionLogRepository"></param>
        public SysExceptionLogService(ISysExceptionLogRepository sysExceptionLogRepository)
        {
            _sysExceptionLogRepository = sysExceptionLogRepository;
        }

        #endregion

        /// <summary>
        /// 新增异常日志
        /// </summary>
        /// <param name="sysExceptionLog"></param>
        public void insert(SysExceptionLog sysExceptionLog)
        {
            _sysExceptionLogRepository.Insert(sysExceptionLog, BaseSqlRepository.exceptionLog_insertSql);
        }
    }
}
