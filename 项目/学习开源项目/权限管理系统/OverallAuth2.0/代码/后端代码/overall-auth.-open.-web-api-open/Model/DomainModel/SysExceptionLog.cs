using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SysExceptionLog
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 异常类型
        /// </summary>
        public int ExceptionType { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public string ExceptionMsg { get; set; }

        /// <summary>
        /// 异常时间
        /// </summary>
        public DateTime ExceptionTime { get; set; }

        /// <summary>
        /// 操作人员
        /// </summary>
        public string OperateUserName { get; set; }

        /// <summary>
        /// 创建人员id
        /// </summary>
        public string OperateUserId { get; set; }

        /// <summary>
        /// 是否处理
        /// </summary>
        public bool IsHandle { get; set; }

        /// <summary>
        /// 处理人姓名
        /// </summary>
        public string HandleUserName { get; set; }

        /// <summary>
        /// 处理人id
        /// </summary>
        public string HandleUserId { get; set; }
    }
}
