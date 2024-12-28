https://www.bilibili.com/video/BV1pK41137He/?p=46&vd_source=b7200d0eaee914e9c128dcabce5df118
# 什么是Logging
## 基本概念
1、日志级别：Trace<Debug<Information<Warning<Error<Critical/
2、日志提供者（LoggingProvidex）:把日志输出到哪里。常见的有控制台，文件，数据库
3、.NET的日志非常灵活，对于业务代码只需要注入日志对象记录日志即可，具体哪些日志输出到哪里、什么样的格式、是否输出等都有配置或者初始化代码决定

## 输出到控制台
1、NuGet:Microsoft.Extensions.Logging、Microsoft.Extensions.Logging.Console
2、DI注入：
	services.AddLogging(logBuilder=>{
		logBuilder.AddConsole();//可选多个Provider
	});
3、需要记录日志的代码，注入ILogger<T>即可，T一般就用当前类，这个类的名字会输出到日志，方便定位错误。然后调用LogInformation()、LogError等方法输出不同级别的日志，还支持输出异常对象

												 
										
													  


													  