using System;


namespace Utility
{
    /// <summary>
    /// 异常帮助类
    /// </summary>
    public class ExceptionHelper
    {
        /// <summary>
        /// 自定义异常(会写入错误日志表)
        /// </summary>
        /// <param name="msg"></param>
        public static void ThrowBusinessException(string msg)
        {
            throw new Exception(msg);
        }

        /// <summary>
        /// 自定义业务异常(不会写入错误日志表)
        /// </summary>
        /// <param name="msg">信息信息</param>
        /// <param name="codeStatu">异常状态</param>
        /// <returns>返回结果集</returns>
        public static ReceiveStatus CustomException(string msg, CodeStatuEnum codeStatu = CodeStatuEnum.Warning)
        {
            ReceiveStatus receiveStatus = new();
            receiveStatus.code = codeStatu;
            receiveStatus.msg = msg;
            receiveStatus.success = false;
            return receiveStatus;
        }


    }

    /// <summary>
    /// 异常帮助类（返回数据）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExceptionHelper<T> : ExceptionHelper
    {
        /// <summary>
        /// 自定义业务异常(不会写入错误日志表)
        /// </summary>
        /// <param name="msg">信息信息</param>
        /// <param name="codeStatu">异常状态</param>
        /// <returns>返回结果集</returns>
        public static ReceiveStatus<T> CustomExceptionData(string msg, CodeStatuEnum codeStatu = CodeStatuEnum.Warning)
        {
            ReceiveStatus<T> receiveStatus = new();
            receiveStatus.code = codeStatu;
            receiveStatus.msg = msg;
            receiveStatus.success = false;
            receiveStatus.data = new System.Collections.Generic.List<T>();
            return receiveStatus;
        }
    }
}
