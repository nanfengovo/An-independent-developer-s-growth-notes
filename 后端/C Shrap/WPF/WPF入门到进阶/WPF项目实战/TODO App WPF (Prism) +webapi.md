# Prism框架介绍：
>区域 、模块化、导航、对话服务、发布订阅

>Prism框架提供了一套丰富的工具、类和模块、帮助开发人员实现以下功能：
>1、模块化：Prism框架支持将应用程序拆分成多个模块，每个模块具备自己的功能和视图。这种模块化的设计使应用程序更加灵活和可扩展
>
>2、导航：Prism框架提供了导航功能，可以方便地在不同的视图之间进行导航和交互。开发人员可以定义导航路径和参数，以及处理导航事件
>
>3、依赖注入：Prism框架内置了一个轻量级的依赖注入容器，可以帮助开发人员管理和解决组件之间的依赖关系，这样可以提高代码的可测试性和可维护性
>
>4、事件聚合器：Prism框架提供了一个事件聚合器，可以帮助不同模块之间解耦和通信，开发人员可以通过发布和订阅事件来实现模块间的交互
>
>5、命令绑定：Prism框架支持命令绑定，可以将用户操作和后台逻辑进行绑定，这样可以更好的分离用户界面和业务逻辑
>
>6、可测试性：Prism框架的设计考虑了应用程序的可测试性，提供了一些工具和模式，帮助开发人员编写可测试的代码



# Prism框架使用
## 第一步：
>.net 6.0新建WPF应用程序  下载PrismDryIoc （8.1.97）

## 第二步：
>在App.xaml中引入命名空间：xmlns:prism="http://prismlibrary.com/"

## 第三步：
>将Application 换成 prism:PrismApplication

![[assets/TODO App WPF (Prism) +webapi/file-20250402123444283.png]]

## 第四步 
>App.xaml.cs 中继承PrismApplication并实现两个抽象类

>* CreateShell() 设置启动页，需要删掉App.xaml里的StartupUri
>* RegisterTypes 注入相关的服务
```
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    /// <summary>
    /// 设置启动页
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();  
    }

    /// <summary>
    /// 注入服务
    /// </summary>
    /// <param name="containerRegistry"></param>
    /// <exception cref="NotImplementedException"></exception>
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        
    }
}
```

