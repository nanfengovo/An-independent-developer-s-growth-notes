using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Utility
{
    /// <summary>
    /// 事务帮助类
    /// </summary>
    public static class TransactionHelper
    {
        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="func">执行方法</param>
        public static void ExecuteTransaction(Action func)
        {
            TransactionOptions transactionOption = new()
            {

                //设置事务隔离级别
                IsolationLevel = IsolationLevel.ReadCommitted,

                // 设置事务超时时间为60秒
                Timeout = new TimeSpan(0, 0, 120)
            };

            using TransactionScope scope = new(TransactionScopeOption.Required, transactionOption);
            try
            {
                //执行操作
                func();
                //提交
                scope.Complete();
            }
            catch (Exception ex)
            {
                //写入日志
                ExceptionHelper.ThrowBusinessException("事务发生错误：" + ex.Message);
            }
            finally
            {
                //释放资源
                scope.Dispose();
            }

        }
    }
}
