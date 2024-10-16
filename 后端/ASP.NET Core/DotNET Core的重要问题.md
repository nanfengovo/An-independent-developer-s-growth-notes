# .NET Framework缺点:
1、系统级别的安装，互相影响
2、无法独立部署
3、ASP.NET 和IIS深度耦合
4、ASP.NET资源消耗大5、非云原生
# .NET Framework历史包袱：
1、带着手铐脚镣长大的ASP.NET MVC
2、ASP.NET底层不支持很好的单元测试
# .NET Core的优点：
1）支持独立部署，不互相影响；
2）彻底模块化；
3）没有历史包袱，运行效率高
4）不依赖于IIS5）跨平台
6）符合现代开发理念：依赖注入、单元测试等
# .NET Core和.NET Framework不同
1）不支持：ASP.NET WebForms、WCF服务器端、WF、.NET Remoting、Appdomain
2）部分Windows-Only的特性.NET core，但是无法跨平台： WinForm、WPF、注册表、Event Log、AD等。
