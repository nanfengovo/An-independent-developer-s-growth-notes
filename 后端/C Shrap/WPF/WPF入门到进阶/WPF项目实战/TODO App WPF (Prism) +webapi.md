# 基础知识准备：
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

# 区域（Region）
>在 WPF Prism 中，**区域（Region）** 是框架的核心概念之一，用于实现模块化应用的动态布局和视图组合。它的核心作用是**解耦视图的布局容器与具体视图内容**，使开发者可以灵活地动态加载、卸载或切换视图，而无需直接操作底层 UI 容器。

##  **Region 的核心作用**

1. **占位符**  
    Region 充当 UI 中的“占位符”，定义了一个逻辑位置（如 `ContentControl`、`ItemsControl` 或 `TabControl`），后续可以将多个视图（View）动态注入到这个位置。
    
2. **解耦视图与容器**  
    视图的开发者无需知道最终布局细节，只需将视图注册到某个区域。布局的调整（如替换容器类型）不会影响视图本身的代码。
    
3. **动态组合**  
    支持运行时动态加载、卸载视图，实现灵活的导航和界面切换（如选项卡、多窗口）。
## ## **Region 的适配器（RegionAdapter）**

Prism 通过 `RegionAdapter` 将不同类型的 UI 容器适配为 Region：

- `ContentControlRegionAdapter`：处理 `ContentControl`（单视图）。
    
- `ItemsControlRegionAdapter`：处理 `ItemsControl`（多视图，如列表）。
    
- `SelectorRegionAdapter`：处理 `Selector` 派生类（如 `TabControl`，支持动态选项卡）。


# WebAPI概述和创建
## 1、什么是REST
>REST(Representational State Transfer) 表述性传递状态，是一种基于资源的架构风格，在REST中，资源（Resource）是最基本的概念，任何能够命名的对象都是资源，如：user,team,order,docment 他表示web服务要操作的一个实体，一个资源具有一个统一资源标识符。（Uniform Resource Identity URL）,如 users/123.通过资源能够表示并访问资源

## 2、什么是API
>API的全称Aplication Programming Itererface 即应用程序编程接口，我们在开发应用程序时经常用到。API作为接口，用来连接两个不同的系统，并使其中一方为另一方提供服务

# 3、Http协议
>超文本传输协议
>http方法：
>POST : 创建资源
>PUT：修改资源
>DELETE:删除资源
>状态码：
>1xx : 信息
>2xx : 成功
>3xx : 重定向
>4xx : 客户端错误
>5xx : 服务端错误  

--- 
# 搭建项目：
## 项目的技术栈：
>ASP.NET Core WebAPI (.net 6.0)+WPF+Prism+MaterialDesignTheme(UI库)

## 后端WebAPI的搭建
### 给swagger文档添加注释
#### 第一步 ：勾选生成API文档文件
![[assets/TODO App WPF (Prism) +webapi/file-20250404161821627.png]]
![[assets/TODO App WPF (Prism) +webapi/file-20250404162508326.png]]
#### 第二步 ：修改Program.cs
![[assets/TODO App WPF (Prism) +webapi/file-20250404162705212.png]]
#### 效果
![[assets/TODO App WPF (Prism) +webapi/file-20250404162739340.png]]
## 前端WPF的搭建
### 新建WPF应用程序,添加Prism.DryIoc(8.1.97)
### 在App.xaml中
```
using DailyAPP.WPF.ViewModels;
using DailyAPP.WPF.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DailyAPP.WPF
{
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
            return Container.Resolve<MainWin>();
        }

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //登录
            containerRegistry.RegisterDialog<LoginUC, LoginUCViewModel>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            var dialog = Container.Resolve<IDialogService>();
            dialog.ShowDialog("LoginUC",callback =>
            { 
                if(callback.Result != ButtonResult.OK) 
                {
                    Environment.Exit(0);
                    return;
                }
                base.OnInitialized();
            });
        }
    }

}
```
### 新建Views和ViewModels文件夹
删除MainView.xaml同时在App.xaml中删除startupurl,在Views下新建MainWin.xmal和LoginUC.xaml同时在VM中创建对应的模型


### 添加MaterialDesignThemeUI库
>参考文档：http://materialdesigninxaml.net/home#home

#### 修改App.xaml
```
<prism:PrismApplication x:Class="DailyAPP.WPF.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:DailyAPP.WPF"
             xmlns:masterialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
             xmlns:prism="http://prismlibrary.com/"
             >
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</prism:PrismApplication>
```
### 登录页、注册页设计
```
<UserControl x:Class="DailyAPP.WPF.Views.LoginUC"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:DailyAPP.WPF.Views"
             xmlns:md ="http://materialdesigninxaml.net/winfx/xaml/themes"
             xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
             mc:Ignorable="d" 
             Height="450" Width="800">
    <Grid Background="White">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="1.5*"/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <Image Source="/Images/login.png" Stretch="Fill"/>
        
        <md:Transitioner Grid.Column="1" SelectedIndex="0"> 
            <!--第一步 登录-->
            <md:TransitionerSlide x:Name="Login" >
                <DockPanel Margin="15" VerticalAlignment="Center">
                    <TextBlock Text="欢迎使用" FontWeight="Bold" FontSize="22" Margin="0,10" DockPanel.Dock="Top"></TextBlock>
                    <TextBox md:HintAssist.Hint="请输入账号" DockPanel.Dock="Top"  Margin="0,10" ></TextBox>
                    <PasswordBox md:HintAssist.Hint="请输入密码" DockPanel.Dock="Top"  Margin="0,10" ></PasswordBox>
                    <Button Content="登录" Margin="0,10" DockPanel.Dock="Top" Command="{Binding LoginCmm}"></Button>
                    
                    <DockPanel Margin="0 5" LastChildFill="False">
                        <TextBlock Text="注册账号">
                            <i:Interaction.Triggers >
                                <i:EventTrigger EventName="MouseLeftButtonDown">
                                    <i:InvokeCommandAction Command=""></i:InvokeCommandAction>
                                </i:EventTrigger>
                            </i:Interaction.Triggers>
                        </TextBlock>
                        <TextBlock Text="忘记密码" DockPanel.Dock="Right"></TextBlock>
                    </DockPanel>
                </DockPanel>
                
            </md:TransitionerSlide>
            <!--第二步 注册-->
            <md:TransitionerSlide>
                <DockPanel Margin="15" VerticalAlignment="Center">
                    <TextBlock Text="注册账号" FontWeight="Bold" FontSize="22" Margin="0,10" DockPanel.Dock="Top"></TextBlock>
                    <TextBox md:HintAssist.Hint="请输入姓名" DockPanel.Dock="Top"  Margin="0,10" ></TextBox>
                    <TextBox md:HintAssist.Hint="请输入姓名" DockPanel.Dock="Top"  Margin="0,10" ></TextBox>
                    <PasswordBox md:HintAssist.Hint="请输入密码" DockPanel.Dock="Top"  Margin="0,10" ></PasswordBox>
                    <PasswordBox md:HintAssist.Hint="请再次输入密码" DockPanel.Dock="Top"  Margin="0,10" ></PasswordBox>
                    <Button Content="注册账号" DockPanel.Dock="Top"></Button>
                    <Button Content="返回登录" DockPanel.Dock="Top" Margin="0 10" Style="{StaticResource MaterialDesignOutlinedButton}"></Button>
                </DockPanel>
            </md:TransitionerSlide>
        </md:Transitioner>
    </Grid>
</UserControl>
```

