---
created: 2024-10-21T12:39:07 (UTC +08:00)
tags: [colorful.console]
source: https://blog.csdn.net/qq_44695769/article/details/130642519
author: 
---

# C# 控制台彩色打印_colorful.console-CSDN博客

> ## Excerpt
> 文章浏览阅读548次。文章介绍了如何在C#控制台应用Colorful.Console库进行彩色打印，创建了一个静态工具类LogHelper，提供了Debug、Info、Warning和Error等方法，分别对应不同颜色的输出。此外，还提及了结合Nlog日志框架进行更高级的日志管理。

---
![](https://csdnimg.cn/release/blogv2/dist/pc/img/original.png)

[龙中舞王](https://blog.csdn.net/qq_44695769 "龙中舞王") ![](https://csdnimg.cn/release/blogv2/dist/pc/img/newCurrentTime2.png) 于 2023-05-12 15:00:24 发布

## 前言

平时C#控制台打印，都是黑白的，不是很好看。这里使用彩色打印来在控制台上面打印。

## NuGet包引入

Colorful.Console  
![在这里插入图片描述](https://i-blog.csdnimg.cn/blog_migrate/bc964a2fd7f9de671587a468a5a3fa48.png)

## 新建工具类

```java
using System; using System.Collections.Generic; using System.Linq; using System.Text; using System.Threading.Tasks; using Console = Colorful.Console;//这个是重点 using System.Drawing; namespace WeatherApi.Utils { public static class LogHelper { public static void Debug(object res) { Console.WriteLine(res); } public static void Info(object res) { Console.WriteLine(res, Color.LightGreen); } public static void Error(object res) { Console.WriteLine(res,Color.Red); } public static void Warning(object res) { Console.WriteLine(res,Color.Yellow); } } }
```

## 主程序打印

```java
using System; using System.Collections.Generic; using System.Linq; using System.Text; using System.Threading.Tasks; using WeatherApi.Utils; namespace WeatherApiProgram { internal class Program { static void Main(string[] args) { LogHelper.Debug("我是Debug"); LogHelper.Info("我是Info"); LogHelper.Warning("我是Warning"); LogHelper.Error("我是Error"); } } }
```

![在这里插入图片描述](https://i-blog.csdnimg.cn/blog_migrate/a600e3296c69b838a2a2c38e3074c4df.png)

## 扩展：

-   [Colorful.console更高级用法](https://blog.csdn.net/qq_43307934/article/details/124063179?ops_request_misc=&request_id=&biz_id=102&utm_term=Colorful.Console&utm_medium=distribute.pc_search_result.none-task-blog-2~all~sobaiduweb~default-2-124063179.142%5Ev87%5Econtrol_2,239%5Ev2%5Einsert_chatgpt&spm=1018.2226.3001.4187)
-   [配套Nlog日志管理](https://blog.csdn.net/zls365365/article/details/125127985)
