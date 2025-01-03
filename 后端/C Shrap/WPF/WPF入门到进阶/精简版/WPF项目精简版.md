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

## 自定义样式模板
```
<Window x:Class="WpfBaseLesson.CustomStyleTemplate"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfBaseLesson"
        mc:Ignorable="d"
        Title="CustomStyleTemplate" Height="450" Width="800">
    <Grid>
        <Button Content="自定义"
                Height="40"
                Width="100"
                Background="Blue"
                Foreground="White"
                FontSize="20"
                HorizontalAlignment="Center"
                VerticalAlignment="Center"
                >
            <Button.Template>
                <ControlTemplate TargetType="Button">
                    <Border Background="Red" CornerRadius="10" BorderBrush="Black" BorderThickness="5">
                        <!--ContentPresenter 呈现内容的控件 占位-->
                        <!--<ContentPresenter HorizontalAlignment="Center"
                                          VerticalAlignment="Center"></ContentPresenter>-->
                        <TextBlock Text="自定义" VerticalAlignment="Center" HorizontalAlignment="Center" ></TextBlock>
                    </Border>
                </ControlTemplate>
            </Button.Template>
        </Button>
    </Grid>
</Window>
```
## 通过绑定的方式自定义样式模板
```
<Window x:Class="WpfBaseLesson.CustomStyleTemplate"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfBaseLesson"
        mc:Ignorable="d"
        Title="CustomStyleTemplate" Height="450" Width="800">
    <Grid>
        <Button Content="自定义"
                Height="40"
                Width="100"
                Background="Blue"
                BorderBrush="Black"
                Foreground="White"
                FontSize="20"
                HorizontalAlignment="Center"
                VerticalAlignment="Center"
                BorderThickness="5"
                >
            <Button.Template>
                <!--绑定-->
                <ControlTemplate TargetType="Button">
                    <Border Background="{TemplateBinding Background}" CornerRadius="10" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}">
                        <!--ContentPresenter 呈现内容的控件 占位-->
                        <!--<ContentPresenter HorizontalAlignment="Center"
                                          VerticalAlignment="Center"></ContentPresenter>-->
                        <TextBlock Text="{TemplateBinding Content}" VerticalAlignment="{TemplateBinding VerticalAlignment}" HorizontalAlignment="{TemplateBinding HorizontalAlignment}" ></TextBlock>
                    </Border>
                </ControlTemplate>
            </Button.Template>
        </Button>
    </Grid>
</Window>
```


## 触发器
```
<Window x:Class="WpfBaseLesson.CustomStyleTemplate"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfBaseLesson"
        mc:Ignorable="d"
        Title="CustomStyleTemplate" Height="450" Width="800">
    <Grid>
        <Button Content="自定义"
                Height="40"
                Width="100"
                Background="Blue"
                BorderBrush="Black"
                Foreground="White"
                FontSize="20"
                HorizontalAlignment="Center"
                VerticalAlignment="Center"
                BorderThickness="5"
                >
            <Button.Template>
                <!--绑定-->
                <ControlTemplate TargetType="Button">
                    <Border x:Name="border"  Background="{TemplateBinding Background}" CornerRadius="10" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}">
                        <!--ContentPresenter 呈现内容的控件 占位-->
                        <!--<ContentPresenter HorizontalAlignment="Center"
                                          VerticalAlignment="Center"></ContentPresenter>-->
                        <TextBlock x:Name="txt" Text="{TemplateBinding Content}" VerticalAlignment="{TemplateBinding VerticalAlignment}" HorizontalAlignment="{TemplateBinding HorizontalAlignment}" ></TextBlock>
                    </Border>
                    <!--触发器-->
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="true">
                            <Setter TargetName="border" Property="Background" Value="red"></Setter>
                            <Setter TargetName="txt"
                                    Property="Text"
                                    Value="ABC"></Setter>
                        </Trigger>
                        <Trigger Property="IsPressed"
                                 Value="true">
                            <Setter TargetName="border"
                                    Property="Background"
                                    Value="green"></Setter>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Button.Template>
        </Button>
    </Grid>
</Window>
```

# 07、在线办公系统-登录界面设计
>https://www.bilibili.com/video/BV1TC411r7ho?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=7


```
<Window x:Class="OAManage.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:OAManage"
        mc:Ignorable="d"
        Title="在线办公管理系统" Height="450" Width="800">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="30"></RowDefinition>
            <RowDefinition ></RowDefinition>
        </Grid.RowDefinitions>
        <!-- 第一行 -->
        <TextBlock Text="在线办公管理系统" Background="#0078d4" TextAlignment="Center" HorizontalAlignment="Center" Width="800" VerticalAlignment="Center" Height="30" FontSize="20" FontWeight="Light"></TextBlock>
        
        <!--第二行-->
        <Grid Grid.Row="1">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="180"></ColumnDefinition>
                <ColumnDefinition></ColumnDefinition>
            </Grid.ColumnDefinitions>
            <!-- 第二行的第一列 -->
            <Border >
                <Image Source="Image/Login.jpg"></Image>
            </Border>

            <Border Grid.Column="1"
                    Background="LightCyan">
                <Grid HorizontalAlignment="Center"
                      VerticalAlignment="Center">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="30"></RowDefinition>
                        <RowDefinition Height="30"></RowDefinition>
                        <RowDefinition></RowDefinition>
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="50"></ColumnDefinition>
                        <ColumnDefinition Width="100"></ColumnDefinition>
                    </Grid.ColumnDefinitions>
                    <!--第一行的第一列-->
                    <TextBlock Text="账号"
                               Margin="0,4"></TextBlock>

                    <!--第一行的第二列-->
                    <TextBox Grid.Column="1"
                             Margin="0,4"></TextBox>

                    <!--第二行的第一列-->
                    <TextBlock Text="密码"
                               Grid.Row="1"
                               Margin="0,4"></TextBlock>

                    <!--第二行的第二列-->
                    <TextBox Grid.Row="1"
                             Grid.Column="2"
                             Margin="0,4"></TextBox>

                    <Button Grid.Row="2"
                            Grid.ColumnSpan="2"
                            FontSize="20"
                            Background="LightBlue">登录</Button>

                </Grid>
            </Border>
            <!-- 第二行的第二列 -->
           
        </Grid>
    </Grid>
</Window>
```
# 08、 登录基本实现
>https://www.bilibili.com/video/BV1TC411r7ho?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=8

## 点击事件的方式实现登录 --耦合度太高了

```MainWindow.xaml
<Window x:Class="OAManage.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:OAManage"
        mc:Ignorable="d"
        Title="在线办公管理系统" Height="450" Width="800">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="30"></RowDefinition>
            <RowDefinition ></RowDefinition>
        </Grid.RowDefinitions>
        <!-- 第一行 -->
        <TextBlock Text="在线办公管理系统" Background="#0078d4" TextAlignment="Center" HorizontalAlignment="Center" Width="800" VerticalAlignment="Center" Height="30" FontSize="20" FontWeight="Light"></TextBlock>
        
        <!--第二行-->
        <Grid Grid.Row="1">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="180"></ColumnDefinition>
                <ColumnDefinition></ColumnDefinition>
            </Grid.ColumnDefinitions>
            <!-- 第二行的第一列 -->
            <Border >
                <Image Source="Image/Login.jpg"></Image>
            </Border>

            <Border Grid.Column="1"
                    Background="LightCyan">
                <Grid HorizontalAlignment="Center"
                      VerticalAlignment="Center">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="30"></RowDefinition>
                        <RowDefinition Height="30"></RowDefinition>
                        <RowDefinition></RowDefinition>
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="50"></ColumnDefinition>
                        <ColumnDefinition Width="100"></ColumnDefinition>
                    </Grid.ColumnDefinitions>
                    <!--第一行的第一列-->
                    <TextBlock Text="账号"
                               Margin="0,4"></TextBlock>

                    <!--第一行的第二列-->
                    <TextBox Grid.Column="1"
                             Margin="0,4" x:Name="txtAccount"></TextBox>

                    <!--第二行的第一列-->
                    <TextBlock Text="密码"
                               Grid.Row="1"
                               Margin="0,4"></TextBlock>

                    <!--第二行的第二列-->
                    <TextBox Grid.Row="1"
                             Grid.Column="2"
                             Margin="0,4" x:Name="txtPwd"></TextBox>

                    <Button Grid.Row="2"
                            Grid.ColumnSpan="2"
                            FontSize="20"
                            Background="LightBlue" Click="Btn_Login">登录</Button>

                </Grid>
            </Border>
            <!-- 第二行的第二列 -->
           
        </Grid>
    </Grid>
</Window>


```

```
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Login(object sender, RoutedEventArgs e)
        {
            string account = this.txtAccount.Text;
            string pwd = this.txtPwd.Text;

            if(account == "longma" && pwd=="123" )
            {
                MessageBox.Show("登录成功");
            }
            else
            {
                MessageBox.Show("登录失败");
                //清空文本框
                this.txtAccount.Text = "";
                this.txtPwd.Text = "";
            }

        }
```
## 点击事件+绑定实现登录
>问题：登录失败的情况不能清空页面文本框中的值

```MainWindow.xaml
<Window x:Class="OAManage.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:OAManage"
        mc:Ignorable="d"
        Title="在线办公管理系统" Height="450" Width="800">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="30"></RowDefinition>
            <RowDefinition ></RowDefinition>
        </Grid.RowDefinitions>
        <!-- 第一行 -->
        <TextBlock Text="在线办公管理系统" Background="#0078d4" TextAlignment="Center" HorizontalAlignment="Center" Width="800" VerticalAlignment="Center" Height="30" FontSize="20" FontWeight="Light"></TextBlock>
        
        <!--第二行-->
        <Grid Grid.Row="1">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="180"></ColumnDefinition>
                <ColumnDefinition></ColumnDefinition>
            </Grid.ColumnDefinitions>
            <!-- 第二行的第一列 -->
            <Border >
                <Image Source="Image/Login.jpg"></Image>
            </Border>

            <Border Grid.Column="1"
                    Background="LightCyan">
                <Grid HorizontalAlignment="Center"
                      VerticalAlignment="Center">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="30"></RowDefinition>
                        <RowDefinition Height="30"></RowDefinition>
                        <RowDefinition></RowDefinition>
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="50"></ColumnDefinition>
                        <ColumnDefinition Width="100"></ColumnDefinition>
                    </Grid.ColumnDefinitions>
                    <!--第一行的第一列-->
                    <TextBlock Text="账号"
                               Margin="0,4"></TextBlock>

                    <!--第一行的第二列-->
                    <TextBox Grid.Column="1"
                             Margin="0,4" Text="{Binding Account}"></TextBox>

                    <!--第二行的第一列-->
                    <TextBlock Text="密码"
                               Grid.Row="1"
                               Margin="0,4"></TextBlock>

                    <!--第二行的第二列-->
                    <TextBox Grid.Row="1"
                             Grid.Column="2"
                             Margin="0,4" Text="{Binding Pwd}"></TextBox>

                    <Button Grid.Row="2"
                            Grid.ColumnSpan="2"
                            FontSize="20"
                            Background="LightBlue" Click="Btn_Login">登录</Button>

                </Grid>
            </Border>
            <!-- 第二行的第二列 -->
           
        </Grid>
    </Grid>
</Window>



```

```c#
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OAManage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //设置数据上下文
            this.DataContext = this;
        }

        //账号
        public string Account { get; set; }

        //密码
        public string Pwd { get; set; }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Login(object sender, RoutedEventArgs e)
        {
          

            if(Account == "longma" && Pwd=="123" )
            {
                MessageBox.Show("登录成功");
            }
            else
            {
                MessageBox.Show("登录失败");
                //清空文本框
                this.Account = "";
                this.Pwd= "";
            }

        }
    }
}
```

# 09、在线办公系统-登录（双向绑定）
>https://www.bilibili.com/video/BV1TC411r7ho?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=9

>双向绑定：界面或者后台有一个发生改变就都要改变

```MainWindow.xaml
<Window x:Class="OAManage.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:OAManage"
        mc:Ignorable="d"
        Title="在线办公管理系统" Height="450" Width="800">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="30"></RowDefinition>
            <RowDefinition ></RowDefinition>
        </Grid.RowDefinitions>
        <!-- 第一行 -->
        <TextBlock Text="在线办公管理系统" Background="#0078d4" TextAlignment="Center" HorizontalAlignment="Center" Width="800" VerticalAlignment="Center" Height="30" FontSize="20" FontWeight="Light"></TextBlock>
        
        <!--第二行-->
        <Grid Grid.Row="1">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="180"></ColumnDefinition>
                <ColumnDefinition></ColumnDefinition>
            </Grid.ColumnDefinitions>
            <!-- 第二行的第一列 -->
            <Border >
                <Image Source="Image/Login.jpg"></Image>
            </Border>

            <Border Grid.Column="1"
                    Background="LightCyan">
                <Grid HorizontalAlignment="Center"
                      VerticalAlignment="Center">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="30"></RowDefinition>
                        <RowDefinition Height="30"></RowDefinition>
                        <RowDefinition></RowDefinition>
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="50"></ColumnDefinition>
                        <ColumnDefinition Width="100"></ColumnDefinition>
                    </Grid.ColumnDefinitions>
                    <!--第一行的第一列-->
                    <TextBlock Text="账号"
                               Margin="0,4"></TextBlock>

                    <!--第一行的第二列-->
                    <TextBox Grid.Column="1"
                             Margin="0,4" Text="{Binding Account}"></TextBox>

                    <!--第二行的第一列-->
                    <TextBlock Text="密码"
                               Grid.Row="1"
                               Margin="0,4"></TextBlock>

                    <!--第二行的第二列-->
                    <TextBox Grid.Row="1"
                             Grid.Column="2"
                             Margin="0,4" Text="{Binding Pwd}"></TextBox>

                    <Button Grid.Row="2"
                            Grid.ColumnSpan="2"
                            FontSize="20"
                            Background="LightBlue" Click="Btn_Login">登录</Button>

                </Grid>
            </Border>
            <!-- 第二行的第二列 -->
           
        </Grid>
    </Grid>
</Window>
```

```c#
using OAManage.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OAManage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 账号Model
        /// </summary>
        private AccountModel accountModel;
        public MainWindow()
        {
            InitializeComponent();
            //设置数据上下文
            accountModel = new AccountModel();
            this.DataContext = accountModel ;
            
        }

       

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Login(object sender, RoutedEventArgs e)
        {
          

            if(accountModel.Account == "longma" && accountModel.Pwd=="123" )
            {
                MessageBox.Show("登录成功");
            }
            else
            {
                MessageBox.Show("登录失败");
                //清空文本框
                accountModel.Account = "";
                accountModel.Pwd= "";
            }

        }
    }
}
```

```c#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAManage.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    class AccountModel:INotifyPropertyChanged  //属性改变通知的接口
    {
        /// <summary>
        /// 属性改变事件
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;


        private string _Account;

        public string Account
        {
            get { return _Account; }
            set 
            {
                _Account = value;
                //通知
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Account"));

                if(PropertyChanged !=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Account"));
                }
            }

        }

        ////账号
        //public string Account { get; set; }

        //密码
        //public string Pwd { get; set; }


        private string _Pwd;

        public string Pwd
        {
            get
            {
                return _Pwd;
            }
            set
            {
                _Pwd = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Pwd"));
                }
            }
        }
    }
}
```
# 10、在线办公系统-登录（绑定命令）
>https://www.bilibili.com/video/BV1TC411r7ho?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=10

![[Pasted image 20250103125102.png]]
## MainWindow.xaml
```MainWindow.xaml
<Window x:Class="OAManage.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:OAManage"
        mc:Ignorable="d"
        Title="在线办公管理系统" Height="450" Width="800">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="30"></RowDefinition>
            <RowDefinition ></RowDefinition>
        </Grid.RowDefinitions>
        <!-- 第一行 -->
        <TextBlock Text="在线办公管理系统" Background="#0078d4" TextAlignment="Center" HorizontalAlignment="Center" Width="800" VerticalAlignment="Center" Height="30" FontSize="20" FontWeight="Light"></TextBlock>
        
        <!--第二行-->
        <Grid Grid.Row="1">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="180"></ColumnDefinition>
                <ColumnDefinition></ColumnDefinition>
            </Grid.ColumnDefinitions>
            <!-- 第二行的第一列 -->
            <Border >
                <Image Source="Image/Login.jpg"></Image>
            </Border>

            <Border Grid.Column="1"
                    Background="LightCyan">
                <Grid HorizontalAlignment="Center"
                      VerticalAlignment="Center">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="30"></RowDefinition>
                        <RowDefinition Height="30"></RowDefinition>
                        <RowDefinition></RowDefinition>
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="50"></ColumnDefinition>
                        <ColumnDefinition Width="100"></ColumnDefinition>
                    </Grid.ColumnDefinitions>
                    <!--第一行的第一列-->
                    <TextBlock Text="账号"
                               Margin="0,4"></TextBlock>

                    <!--第一行的第二列-->
                    <TextBox Grid.Column="1"
                             Margin="0,4" Text="{Binding Account}"></TextBox>

                    <!--第二行的第一列-->
                    <TextBlock Text="密码"
                               Grid.Row="1"
                               Margin="0,4"></TextBlock>

                    <!--第二行的第二列-->
                    <TextBox Grid.Row="1"
                             Grid.Column="2"
                             Margin="0,4" Text="{Binding Pwd}"></TextBox>
                    <!--绑定命令-->
                    <Button Grid.Row="2"
                            Grid.ColumnSpan="2"
                            FontSize="20"
                            Background="LightBlue" Command="{Binding Command}">登录</Button>

                </Grid>
            </Border>
            <!-- 第二行的第二列 -->
           
        </Grid>
    </Grid>
</Window>

```
## MainWindow.cs

```C#
using OAManage.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OAManage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 账号Model
        /// </summary>
        private AccountModel accountModel;
        public MainWindow()
        {
            InitializeComponent();
            //设置数据上下文
            accountModel = new AccountModel();
            this.DataContext = accountModel ;
            
        }

    }
}
```
## AccountModel.cs
```C#
using OAManage.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OAManage.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    class AccountModel:INotifyPropertyChanged  //属性改变通知的接口
    {
        /// <summary>
        /// 属性改变事件
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;


        private string _Account;

        public string Account
        {
            get { return _Account; }
            set 
            {
                _Account = value;
                //通知
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Account"));

                if(PropertyChanged !=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Account"));
                }
            }

        }

        ////账号
        //public string Account { get; set; }

        //密码
        //public string Pwd { get; set; }


        private string _Pwd;

        public string Pwd
        {
            get
            {
                return _Pwd;
            }
            set
            {
                _Pwd = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Pwd"));
                }
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login()
        {
            if (Account == "longma" && Pwd == "123")
            {
                MessageBox.Show("登录成功");
            }
            else
            {
                MessageBox.Show("登录失败");
                //清空文本框
                Account = "";
                Pwd = "";
            }
        }

        /// <summary>
        /// 命令属性
        /// </summary>
        public ICommand Command 
        {
            get
            {
                return new DoCommand(Login);
            }
        }





    }
}

```
## DoCommand.cs
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OAManage.Command
{
    class DoCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// 具体要执行的事情
        /// </summary>
        private Action _execute;//委托

        /// <summary>
        /// 构造函数
        /// </summary>
        public DoCommand(Action execute)
        {
            this._execute = execute;
        }

        /// <summary>
        /// 能否执行
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool CanExecute(object? parameter)
        {
            return true;
        }


        /// <summary>
        /// 执行的事情
        /// </summary>
        /// <param name="parameter"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Execute(object? parameter)
        {
            if(_execute != null)
            {
                _execute();
            }
        }
    }
}
```