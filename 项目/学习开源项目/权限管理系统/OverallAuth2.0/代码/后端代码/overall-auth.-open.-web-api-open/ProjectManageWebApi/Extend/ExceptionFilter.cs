using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Model;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Utility;

namespace ProjectManageWebApi
{
    /// <summary>
    /// 异常捕获
    /// </summary>
    public class ExceptionFilter : IAsyncExceptionFilter
    {

        /// <summary>
        /// 实例化异常日志服务
        /// </summary>
        private readonly ISysExceptionLogService _sysExceptionLogService;

        /// <summary>
        /// 构造实例化
        /// </summary>
        /// <param name="sysExceptionLogService"></param>
        public ExceptionFilter(ISysExceptionLogService sysExceptionLogService)
        {
            _sysExceptionLogService = sysExceptionLogService;
        }

        /// <summary>
        /// 全局异常捕获
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            //异常信息
            Exception ex = context.Exception;

            //异常位置
            var DisplayName = context.ActionDescriptor.DisplayName;

            //异常行号
            int lineNumber = 0;
            const string lineSearch = ":line ";
            var index = ex.StackTrace.LastIndexOf(lineSearch);
            if (index != -1)
            {
                var lineNumberText = ex.StackTrace.Substring(index + lineSearch.Length);
                lineNumber = Convert.ToInt32(lineNumberText.Substring(0, lineNumberText.IndexOf("\r\n")));
            }

            // 如果异常没有被处理则进行处理
            if (context.ExceptionHandled == false)
            {
                string exceptionMsg = "错误位置：" + DisplayName + "\r\n" + "错误行号：" + lineNumber + "\r\n" + "错误信息：" + ex.Message;
                // 定义返回类型
                var result = new ReceiveStatus<string>
                {
                    code = CodeStatuEnum.Error,
                    //msg = "错误位置：" + DisplayName + "\r\n" + "错误行号：" + lineNumber + "\r\n" + "错误信息：" + ex.Message,
                    msg = "错误信息：" + ex.Message,
                    success = false,
                };

                context.Result = new ContentResult
                {
                    // 返回状态码设置为200，表示成功
                    StatusCode = StatusCodes.Status200OK,
                    // 设置返回格式
                    ContentType = "application/json;charset=utf-8",
                    Content = JsonConvert.SerializeObject(result)
                };

                //添加异常日志
                SysExceptionLog sysExceptionLog = new()
                {
                    ExceptionType = 1,
                    ExceptionMsg = exceptionMsg,
                    ExceptionTime = DateTime.Now,
                    OperateUserName = "admin",
                    OperateUserId = "1",
                    IsHandle = false
                };
                _sysExceptionLogService.insert(sysExceptionLog);
            }
            // 设置为true，表示异常已经被处理了
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
