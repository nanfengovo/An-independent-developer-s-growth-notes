https://www.bilibili.com/video/BV1pK41137He/?p=46&vd_source=b7200d0eaee914e9c128dcabce5df118
# 什么是Logging
## 基本概念
1、日志级别：Trace<Debug<Information<Warning<Error<Critical/
2、日志提供者（LoggingProvidex）:把日志输出到哪里。常见的有控制台，文件，数据库
3、.NET的日志非常灵活，对于业务代码只需要注入日志对象记录日志即可，具体哪些日志输出到哪里、什么样的格式、是否输出等都有配置或者初始化代码决定

## 输出到控制台
1、NuGet:Microsoft.Extensions.Logging、Microsoft.Extensions.Logging.Console
2、DI注入：
```
	services.AddLogging(logBuilder=>{
		logBuilder.AddConsole();//可选多个Provider
	});
```
3、需要记录日志的代码，注入ILogger<T>即可，T一般就用当前类，这个类的名字会输出到日志，方便定位错误。然后调用LogInformation()、LogError等方法输出不同级别的日志，还支持输出异常对象

代码如下：
``` project.cs
using System;  
using Microsoft.Extensions.DependencyInjection;  
using Microsoft.Extensions.Logging;  
  
namespace LoggingDemo1  
{  
    class Program  
    {  
        static void Main(string[] args)  
        {  
            ServiceCollection services = new ServiceCollection();  
            services.AddLogging(LogBuilder =>  
            {  
                LogBuilder.AddConsole();  
                LogBuilder.SetMinimumLevel(LogLevel.Trace);  
            });  
            services.AddScoped<Test1>();  
              
            using (var sp = services.BuildServiceProvider())  
            {  
                var test1 = sp.GetRequiredService<Test1>();  
                test1.Test();  
            }  
        }  
    }  
}
```
Test1:
```
using Microsoft.Extensions.Logging;  
  
namespace LoggingDemo1  
{  
    public class Test1  
    {  
        private readonly ILogger<Test1> logger;  
  
        public Test1(ILogger<Test1> logger)  
        {  
            this.logger= logger;  
        }  
  
        public void Test()  
        {  
            logger.LogInformation("Testing");  
            logger.LogDebug("testDebug");  
            logger.LogError("error");  
            logger.LogWarning("warning");  
              
        }  
    }  
}
```




 ##  ASP.NET Core中使用NLog（以webapi为例）
 ## 将日志写入到文件和控制台
 ### 安装必要的库
 ![[0f1de311d4c419ccd10fc8f832aeb3b.png]]
### NLog.config 配置文件
``` NLog.config
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
      autoReload="true"
      internalLogLevel="Info"
      internalLogFile="internal-nlog.txt">

	<!-- 定义日志输出目标 -->
	<targets>
		<!-- 输出到文件 -->
		<target name="logfile"
				xsi:type="File"
				fileName="logs/${shortdate}.log"
				layout="${longdate}|${level:uppercase=true}|${logger}|${message} ${exception:format=ToString}" />

		<!-- 输出到控制台（可选） -->
		<target name="console" xsi:type="Console" />
	</targets>

	<!-- 定义日志规则 -->
	<rules>

		<!-- Suppress output from Microsoft framework when non-critical -->
		<logger name="System.*" finalMinLevel="Warn" />
		<logger name="Microsoft.*" finalMinLevel="Warn" />
		<!-- Keep output from Microsoft.Hosting.Lifetime to console for fast startup detection -->
		<logger name="Microsoft.Hosting.Lifetime*" finalMinLevel="Info" writeTo="lifetimeConsole" />
		<logger name="*" minlevel="Info" writeTo="logfile,console" />
	</rules>
</nlog>

```

``` program.cs
 // 添加 NLog 服务
 // 清除默认的日志提供程序
 builder.Logging.ClearProviders();
 builder.Host.UseNLog();
```
### 在控制器中注入
```
protected readonly ILogger<控制器名称> _logger;

public 控制器名称(ILogger<控制器名称> logger)
{
    _logger = logger;
}
```

## 将日志保存到数据库，同时在控制台和文件中也写入
```
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
      autoReload="true"
      internalLogLevel="Info"
      internalLogFile="internal-nlog.txt">

	<!-- 定义日志输出目标 -->
	<targets>
		<!-- 输出到文件 -->
		<target name="logfile"
				xsi:type="File"
				fileName="logs/${shortdate}.log"
				layout="${longdate}|${level:uppercase=true}|${logger}|${message} ${exception:format=ToString}" />

		<!-- 输出到控制台（可选） -->
		<target name="console" xsi:type="Console" />

		<!-- 输出到数据库 -->
		<target xsi:type="Database" name="database">
			<connectionString>Server=.;Database=PLCHelperDB;User=sa;Password=aaaa2624434145;Encrypt=True;Trusted_Connection=True;TrustServerCertificate=True;</connectionString>
			<!-- 其他配置保持不变 -->
			<commandText>
				INSERT INTO logs ( date, level, logger, message) VALUES (@time, @level, @logger, @message);
			</commandText>
			<parameter name="@time" layout="${longdate}" />
			<parameter name="@level" layout="${level}" />
			<parameter name="@logger" layout="${logger}" />
			<parameter name="@message" layout="${message}" />
		</target>
	</targets>

	<!-- 定义日志规则 -->
	<rules>
		<!-- Suppress output from Microsoft framework when non-critical -->
		<logger name="System.*" finalMinLevel="Warn" />
		<logger name="Microsoft.*" finalMinLevel="Warn" />
		<!-- Keep output from Microsoft.Hosting.Lifetime to console for fast startup detection -->
		<logger name="Microsoft.Hosting.Lifetime*" finalMinLevel="Info" writeTo="console" />
		<!-- Write all logs with level Info and above to file and console -->
		<logger name="*" minlevel="Info" writeTo="logfile,console" />
		<logger name="Microsoft.*" finalMinLevel="Warn" writeTo="database"/>
	</rules>
</nlog>
```



