---
created: 2024-12-07T21:33:26 (UTC +08:00)
tags: [C#]
source: https://www.zhihu.com/question/4078540632
author: 艾康麦icon-meh被忽悠学了半年C#，跟我念:"西，夏普" 关注
---

# C#应该学什么? - 知乎

> ## Excerpt
> 本人目前大二，最近入门C#，已经会了基础的语法，像多线程，反射，委托，特性，这些高级特性勉勉强强知道…

---
俗话说选择不对，努力白费，对于C#的学习也是一样方向不对努力白费。

新手或者有经验的开发者学习c#时往往不知道该学习哪个技术，哪些框架。

盲目的学习会导致不足以学以致用，下面就来分享几个学习路线图。

一、后端开发路线

这条线路是纯后端开发，主要做[服务端开发](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=%E6%9C%8D%E5%8A%A1%E7%AB%AF%E5%BC%80%E5%8F%91&zhida_source=entity)，前后端分离是当下的主流开发模式。该路线方向需要学习以下技能：

1、基础知识：c#基础知识、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core相关知识、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core Web [Api](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=Api&zhida_source=entity)、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core [http://Aap.Net](https://link.zhihu.com/?target=http%3A//Aap.Net) Mvc（可选） 、[Grpc](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=Grpc&zhida_source=entity)

2、ORM：主要学习EF Core、Dapper（其他流行ORM也行但尽量走主流路线）

3、数据库：MySql、[SqlServer](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=SqlServer&zhida_source=entity) 深入学习其中一种即可，另一种需要熟悉

4、日志组件：NLog或者Serilog

5、定时框架：[http://Quartz.Net](https://link.zhihu.com/?target=http%3A//Quartz.Net) Core或者Handfire

![](https://pica.zhimg.com/50/v2-10ab4fade18c67ccd61b0ce123e45321_720w.jpg?source=1def8aca)

6、分布式组件：Redis、[RabbitMQ](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=RabbitMQ&zhida_source=entity)、Mongdb（可选）、[Kafka](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=Kafka&zhida_source=entity)（可选）

7、架构方面：经典三层、熟悉DDD架构模式（可选）、熟悉微服务（可选）

8、[CICD](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=CICD&zhida_source=entity)：熟悉Linux操作系统、Git代码管理器、Doker（可选）、[K8s](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=K8s&zhida_source=entity)（可选）

二、c/s客户端开发路线

当下物联网开发正火很多大厂都在招物联网技术开发

1、基础知识：c#基础知识、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core相关知识、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core Web Api、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core [http://Aap.Net](https://link.zhihu.com/?target=http%3A//Aap.Net) Mvc（可选） 、Grpc

2、ORM：主要学习EF Core、Dapper（其他流行ORM也行但尽量走主流路线）

3、数据库：MySql、SqlServer 深入学习其中一种即可，另一种需要熟悉

4、日志组件：NLog或者Serilog

5、定时框架：[http://Quartz.Net](https://link.zhihu.com/?target=http%3A//Quartz.Net) Core或者Handfire

6、客户端方面：[Wpf](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=Wpf&zhida_source=entity)（深入学习）、MQtt协议、Winfrom（可选）

7、分布式组件：Redis、RabbitMQ、Mongdb（可选）、Kafka（可选）

8、架构方面：经典三层、熟悉DDD架构模式（可选）、熟悉微服务（可选）

9、CICD：熟悉Linux操作系统、Git代码管理器、Doker（可选）、K8s（可选）

三、Web全栈开发路线1

该路线是[全栈开发](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=2&q=%E5%85%A8%E6%A0%88%E5%BC%80%E5%8F%91&zhida_source=entity)，需要学习前端的一些基础知识：

1、基础知识：c#基础知识、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core相关知识、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core Web Api、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core [http://Aap.Net](https://link.zhihu.com/?target=http%3A//Aap.Net) Mvc（可选） 、Grpc

2、ORM：主要学习EF Core、Dapper（其他流行ORM也行但尽量走主流路线）

3、数据库：MySql、SqlServer 深入学习其中一种即可，另一种需要熟悉

4、日志组件：NLog或者Serilog

5、定时框架：[http://Quartz.Net](https://link.zhihu.com/?target=http%3A//Quartz.Net) Core或者Handfire

6、前端方面：[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Mvc、js、html、css、Vue（[React](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=React&zhida_source=entity)、Angula js）

7、分布式组件：Redis、RabbitMQ、Mongdb（可选）、Kafka（可选）

![](https://picx.zhimg.com/50/v2-f654227db819f992a02598ccecb315fa_720w.jpg?source=1def8aca)

8、架构方面：经典三层、熟悉DDD架构模式（可选）、熟悉微服务（可选）

9、CICD：熟悉Linux操作系统、Git代码管理器、Doker（可选）、K8s（可选）

四、Web全栈开发路线2

c#全栈开发方向，使用c#开发前后端功能，不需要学习js和html

1、基础知识：c#基础知识、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core相关知识、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core Web Api、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core [http://Aap.Net](https://link.zhihu.com/?target=http%3A//Aap.Net) Mvc（可选） 、Grpc

2、ORM：主要学习EF Core、Dapper（其他流行ORM也行但尽量走主流路线）

3、数据库：MySql、SqlServer 深入学习其中一种即可，另一种需要熟悉

4、日志组件：NLog或者Serilog

5、定时框架：[http://Quartz.Net](https://link.zhihu.com/?target=http%3A//Quartz.Net) Core或者Handfire

6、前端方面：Blazer（深入学习）

7、分布式组件：Redis、RabbitMQ、Mongdb（可选）、Kafka（可选）

8、架构方面：经典三层、熟悉DDD架构模式（可选）、熟悉微服务（可选）

9、CICD：熟悉Linux操作系统、Git代码管理器、Doker（可选）、K8s（可选）

五、游戏开发路线

1、基础知识：c#基础知识、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core相关知识、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core Web Api、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core [http://Aap.Net](https://link.zhihu.com/?target=http%3A//Aap.Net) Mvc（可选） 、Grpc

2、ORM：主要学习EF Core、Dapper（其他流行ORM也行但尽量走主流路线）

3、游戏引擎：[Unity3d](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=Unity3d&zhida_source=entity)（深入学习）

4、日志组件：NLog或者Serilog

5、定时框架：[http://Quartz.Net](https://link.zhihu.com/?target=http%3A//Quartz.Net) Core或者Handfire

6、分布式组件：Redis、RabbitMQ、Mongdb（可选）、Kafka（可选）

7、架构方面：经典三层、熟悉DDD架构模式（可选）、熟悉微服务（可选）

8、CICD：熟悉Linux操作系统、Git代码管理器、Doker（可选）、K8s（可选）

六、移动端开发路线

如果你项从事开发移动应用，使用c#开发原生安卓、IOS、Mac 应用你需要掌握以下技术

1、基础知识：c#基础知识、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core相关知识、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core Web Api、[http://Asp.Net](https://link.zhihu.com/?target=http%3A//Asp.Net) Core [http://Aap.Net](https://link.zhihu.com/?target=http%3A//Aap.Net) Mvc（可选） 、Grpc

2、ORM：主要学习EF Core、Dapper（其他流行ORM也行但尽量走主流路线）

3、数据库：SqlLite

4、日志组件：NLog或者Serilog

5、定时框架：[http://Quartz.Net](https://link.zhihu.com/?target=http%3A//Quartz.Net) Core或者Handfire

6、客户端方面：[Xamarin](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=Xamarin&zhida_source=entity)（深入学习）、Maui

7、分布式组件：Redis、RabbitMQ、Mongdb（可选）、Kafka（可选）

8、架构方面：经典三层、熟悉DDD架构模式（可选）、熟悉微服务（可选）

9、CICD：熟悉Linux操作系统、Git代码管理器、Doker（可选）、K8s（可选）

作为 C# 程序员，除了上述经典书籍和[开源框架](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=%E5%BC%80%E6%BA%90%E6%A1%86%E6%9E%B6&zhida_source=entity)外，还需要掌握以下技术：

1\. .NET Core 和 [http://ASP.NET](https://link.zhihu.com/?target=http%3A//ASP.NET) Core：了解并熟练掌握 .NET Core 和 [http://ASP.NET](https://link.zhihu.com/?target=http%3A//ASP.NET) Core 框架，这将使您能够开发跨平台的 Web 应用程序和服务。

2\. Entity Framework Core：深入学习并掌握 Entity Framework Core，这是一款功能强大的[对象关系映射](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=%E5%AF%B9%E8%B1%A1%E5%85%B3%E7%B3%BB%E6%98%A0%E5%B0%84&zhida_source=entity)（ORM）框架，可以简化数据访问代码的编写。

3\. Blazor：了解并熟悉 Blazor 技术，它是一种基于 WebAssembly 的客户端 Web UI 框架，允许您使用 C# 而非 JavaScript 编写交互式 Web 应用程序。

4\. [LINQ](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=LINQ&zhida_source=entity)：深入理解 C# 语言集成查询（LINQ）技术，以便在处理数据时编写出易于阅读和维护的代码。

5\. 并发与多线程：学习并了解 C# 中的 Task Parallel Library（TPL）和 async/await 机制，以便在实际项目中高效地处理并发和多线程问题。

6\. 单元测试与持续集成：熟悉 [NUnit](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=NUnit&zhida_source=entity)、xUnit 等单元测试框架，并学会使用 CI/CD 工具（如 [Jenkins](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=Jenkins&zhida_source=entity)、TeamCity、Azure DevOps 等）进行自动化构建和部署。

7\. [微服务架构](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=%E5%BE%AE%E6%9C%8D%E5%8A%A1%E6%9E%B6%E6%9E%84&zhida_source=entity)：了解微服务架构的原理和最佳实践，学习如何使用相关技术（如 Docker、[Kubernetes](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=Kubernetes&zhida_source=entity) 等）构建可扩展、易于维护的应用程序。

8\. Azure 或 [AWS](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=AWS&zhida_source=entity)：熟悉至少一个主流云服务平台（如 Microsoft Azure 或 [Amazon Web Services](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=Amazon+Web+Services&zhida_source=entity)），并掌握它们提供的各种服务和解决方案。

9\. 设计模式与软件架构：深入了解各种设计模式和软件架构原则，以便在面对复杂问题时能够编写出高质量、易于维护的代码。

10\. 持续学习新技术：作为顶尖程序员，不仅要掌握现有技术，还要关注行业动态，持续学习新兴技术，以适应不断变化的市场需求。

掌握这些技术将使您具备更强大的实力，成为一名优秀的 C# 程序员。

除了您提到的这些技术，作为顶尖的 C# 程序员，还可以掌握以下进阶技能：

1\. SignalR：学习实时 Web 通信框架 SignalR，了解如何使用它构建实时交互式应用程序。

2\. [http://ML.NET](https://link.zhihu.com/?target=http%3A//ML.NET)：了解并掌握 [http://ML.NET](https://link.zhihu.com/?target=http%3A//ML.NET)，这是一个基于 .NET 的机器学习框架，允许您在 C# 应用程序中轻松地实现数据挖掘、预测分析等功能。

![](https://picx.zhimg.com/50/v2-be5ca1ef005bbaaea674c3b174e68d8f_720w.jpg?source=1def8aca)

3\. [gRPC](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=gRPC&zhida_source=entity)：了解并熟悉 gRPC 技术，它是一种高性能、跨平台的远程过程调用(RPC)框架，可帮助您构建高性能的微服务。

4\. XAML 和 WPF/[UWP](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=UWP&zhida_source=entity)：深入理解 XAML 语言，并掌握 WPF 或 UWP 框架，用于开发桌面应用程序。

5\. Xamarin：学习 Xamarin 技术，了解如何使用 C# 和 Xamarin 构建跨平台的[移动应用程序](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=%E7%A7%BB%E5%8A%A8%E5%BA%94%E7%94%A8%E7%A8%8B%E5%BA%8F&zhida_source=entity)。

6\. 代码优化和性能调优：掌握代码优化和性能调优的技巧，以便编写出高效、可扩展的代码。

7\. 项目管理和[敏捷开发](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=%E6%95%8F%E6%8D%B7%E5%BC%80%E5%8F%91&zhida_source=entity)：了解项目管理方法和敏捷开发流程（如 Scrum、[Kanban](https://zhida.zhihu.com/search?content_id=700432976&content_type=Answer&match_order=1&q=Kanban&zhida_source=entity) 等），掌握在团队环境中协同工作的技巧。

8\. 跨领域知识：了解相关行业和技术领域的知识，如网络安全、数据可视化、AI、IoT 等，这将使您在实际项目中具备更广泛的知识体系。

9\. 代码审查和重构：掌握代码审查的技巧，以便提高代码质量；学会对现有代码进行重构，以提高代码的可读性和可维护性。

10\. 社交技能和团队协作：培养良好的沟通、协作和解决问题的能力，这对于在软件开发行业取得成功至关重要。

通过掌握这些进阶技能，您将能够在 C# 领域及相关领域脱颖而出，成为一名更加全面的顶尖程序员。
