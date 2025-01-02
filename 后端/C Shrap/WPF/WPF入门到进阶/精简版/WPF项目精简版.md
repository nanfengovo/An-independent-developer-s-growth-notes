# 01、WPF项目整体介绍

>https://www.bilibili.com/video/BV1TC411r7ho?vd_source=b7200d0eaee914e9c128dcabce5df118

## 一、WPF介绍-对比
###  WPF优点：
1、基于.NET Framework/.NET Core ,与XAML结合，易于设计界面
2、强大的图形和动画功能，适用于创建具有丰富视觉效果的应用程序
3、适应不同设备
4、良好的触摸屏支持
5、支持创建基于MVVM的应用程序

### WPF缺点：
1、学习曲线相对较陡峭，需要掌握XAML和MVVM
2、对硬件要求较高


##  二、项目介绍
1、框架 .NET 6
>2、XAML: 可扩展应用程序标记语言（Extensible Application Markup Language）,它是微软公司为构建应用程序用户界面而创建的一种新的描述性语言。XAML提供了一种便于扩展和定位的语法来定义和程序逻辑分离的用户界面，而这种实现方式和ASP.NET中的代码后置模型非常类似。XAML是一种解析性的语言，尽管它也可以被编译。它的优点是简化编程式上的用户创建过程，应用时要添加代码和配置
>	窗口，用户控件（如：环饼图），资源字典，页面


# 02、布局Grid
>https://www.bilibili.com/video/BV1TC411r7ho?vd_source=b7200d0eaee914e9c128dcabce5df118&p=2&spm_id_from=333.788.videopod.episodes

```xaml
<!--命名空间组 对应后台的Class="WpfBaseLesson.MainWindow  ns:namespace x,d,mc:别名  mc:Ignorable="d"只在设计器中显示 ，运行时忽略d:相关的属性 -->
    <Window x:Class="WpfBaseLesson.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfBaseLesson"
        mc:Ignorable="d"
        WindowStartupLocation="CenterScreen"
        Title="MainWindow" Height="450" Width="800">
     <!--容器控件 网格 -->
    <Grid ShowGridLines="True">
        <!--定义行  3行-->
        <Grid.RowDefinitions>
            <RowDefinition Height="40" d:Height="200"/>
            <RowDefinition Height="50" />
            <RowDefinition />
        </Grid.RowDefinitions>
        <!--定义列  2列-->
        <Grid.ColumnDefinitions>
            <ColumnDefinition />
            <ColumnDefinition />
        </Grid.ColumnDefinitions>
        <TextBlock Grid.Row="0" Grid.Column="0">第一行第一列</TextBlock>
        <TextBlock Grid.Row="0" Grid.Column="1">第一行第二列</TextBlock>
        <TextBlock Grid.Row="1" Grid.Column="0">第二行第一列</TextBlock>
        <TextBlock Grid.Row="2" Grid.Column="1">第三行第二列</TextBlock>
    </Grid>
</Window>
```

## XAML 通用注解
>1、x:Class="WpfBaseLesson.MainWindow" 表示后台对应的代码类名
>2、 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  ns：namespace  :x 表示别名
>3、mc:Ignorable="d"只在设计器中显示 ，运行时忽略d:相关的属性

## Grid布局注解
```
1、<Grid ShowGridLines="True"> 中 ShowGridLines="True"表示显示网格线
`> 2、  <!--定义行  3行-->`
        `<Grid.RowDefinitions>`
            `<RowDefinition Height="40" d:Height="200"/>`
            `<RowDefinition Height="50" />`
            `<RowDefinition />`
        `</Grid.RowDefinitions>`
 `<!--定义列  2列-->`
        `<Grid.ColumnDefinitions>`
            `<ColumnDefinition />`
            `<ColumnDefinition />`
        `</Grid.ColumnDefinitions>`
   `第几行几列：`     
        `<TextBlock Grid.Row="0" Grid.Column="0">第一行第一列</TextBlock>`
```
# 03、布局--其他容器控件
>https://www.bilibili.com/video/BV1TC411r7ho?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=3
## 网格 Grid  UniformGrid
>uniformGrid 自动创建行列，每个单元格大小相同，一般用于动态绑定数据
## 堆面板：StackPanel 
>紧凑堆一起（可设置横着堆或竖着堆），一个紧挨一个放不下就截取
>Orientation="Horizontal" 设置水平排

## 边框：Border
>Border是一个装饰的控件，此控件绘制一个边框，一个背景。Border中只能有一个子控件（Child）,若要显示多个子元素，需要在父Border中放一个Panel元素，然后讲子元素放在panel元素中

## Style 样式
>Style 样式基本用法，全局样式，资源字典，自定义布局样式模板，触发器
# 04、布局 -样式基本用法
>https://www.bilibili.com/video/BV1TC411r7ho?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=4
###  <!--将样式封装成资源-->
```
<Window x:Class="WpfBaseLesson.StyleWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfBaseLesson"
        mc:Ignorable="d"
        Title="StyleWindow" Height="450" Width="800">
    <!--将样式封装成资源-->
    <Window.Resources>
        <Style TargetType="Button" x:Key="buttonstyle">
            <Setter Property="Height"
                    Value="40"></Setter>
            <Setter Property="Width"
                    Value="50"></Setter>
            <Setter Property="FontSize"
                    Value="20"></Setter>
            <Setter Property="HorizontalAlignment"
                    Value="Center"></Setter>
            <Setter Property="VerticalAlignment"
                    Value="Center"></Setter>

        </Style>
    </Window.Resources>
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="50"/>
            <RowDefinition Height="50"/>
            <RowDefinition  Height="50"/>
        </Grid.RowDefinitions>
        <Button Content="注册" Style="{StaticResource buttonstyle}" Background="Green"></Button>
        <Button
                Grid.Row="1"
                FontSize="20" Style="{StaticResource buttonstyle}"></Button>
        <Button Content="其他"
                Height="40"
                Width="50"
                Grid.Row="2"
                FontSize="20"></Button>
    </Grid>
</Window>
```

# 05、布局-全局样式和资源字典
>https://www.bilibili.com/video/BV1TC411r7ho?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=5

## 局部样式优化
```
<Window x:Class="WpfBaseLesson.StyleWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfBaseLesson"
        mc:Ignorable="d"
        Title="StyleWindow" Height="450" Width="800">
    <!--将样式封装成资源-->
    <!--基样式-->
    <Window.Resources>
        <Style TargetType="Button" x:Key="buttonstyle">
            <Setter Property="Height"
                    Value="40"></Setter>
            <Setter Property="Width"
                    Value="50"></Setter>
            <Setter Property="FontSize"
                    Value="20"></Setter>
            <Setter Property="HorizontalAlignment"
                    Value="Center"></Setter>
            <Setter Property="VerticalAlignment"
                    Value="Center"></Setter>

        </Style>
        <!--注册样式-->
        <Style TargetType="Button"
               x:Key="RegButtonStyle"
               BasedOn="{StaticResource buttonstyle}">
            <Setter Property="Background"
                    Value="Green"></Setter>
        </Style>
        <!--登录样式-->
        <Style TargetType="Button"
               x:Key="LoginButtonStyle"
               BasedOn="{StaticResource buttonstyle}">
            <Setter Property="Background"
                    Value="Red"></Setter>
        </Style>
    </Window.Resources>
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="50"/>
            <RowDefinition Height="50"/>
            <RowDefinition  Height="50"/>
        </Grid.RowDefinitions>
        <Button Content="注册" Style="{StaticResource RegButtonStyle}"></Button>
        <Button Content="登录"
                Grid.Row="1"
                FontSize="20" Style="{StaticResource LoginButtonStyle}"></Button>
        <Button Content="其他"
                Height="40"
                Width="50"
                Grid.Row="2"
                FontSize="20"></Button>
    </Grid>
</Window>
```
## 全局样式和资源字典
```StyleWindows.xaml
<Window x:Class="WpfBaseLesson.StyleWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfBaseLesson"
        mc:Ignorable="d"
        Title="StyleWindow" Height="450" Width="800">
    
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="50"/>
            <RowDefinition Height="50"/>
            <RowDefinition  Height="50"/>
        </Grid.RowDefinitions>
        <Button Content="注册" Style="{StaticResource RegButtonStyle}"></Button>
        <Button Content="登录"
                Grid.Row="1"
                FontSize="20" Style="{StaticResource LoginButtonStyle}"></Button>
        <Button Content="其他"
                Height="40"
                Width="50"
                Grid.Row="2"
                FontSize="20"></Button>
    </Grid>
</Window>
```
```ButtonStyleDic.xaml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Style TargetType="Button"
           x:Key="buttonstyle">
        <Setter Property="Height"
                Value="40"></Setter>
        <Setter Property="Width"
                Value="50"></Setter>
        <Setter Property="FontSize"
                Value="20"></Setter>
        <Setter Property="HorizontalAlignment"
                Value="Center"></Setter>
        <Setter Property="VerticalAlignment"
                Value="Center"></Setter>

    </Style>
    <!--注册样式-->
    <Style TargetType="Button"
           x:Key="RegButtonStyle"
           BasedOn="{StaticResource buttonstyle}">
        <Setter Property="Background"
                Value="Green"></Setter>
    </Style>
    <!--登录样式-->
    <Style TargetType="Button"
           x:Key="LoginButtonStyle"
           BasedOn="{StaticResource buttonstyle}">
        <Setter Property="Background"
                Value="Red"></Setter>
    </Style>
</ResourceDictionary>
```
```App.xaml
<Application x:Class="WpfBaseLesson.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:WpfBaseLesson"
             StartupUri="StyleWindow.xaml"> <!--配置主窗体-->
    <Application.Resources>
         <!--配置 启动项 资源-->
        <ResourceDictionary Source="Dictionary/ButtonStyleDic.xaml"></ResourceDictionary>
    </Application.Resources>
</Application>
```
# 06、布局-自定义样式模板+触发器
>https://www.bilibili.com/video/BV1TC411r7ho?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=6









