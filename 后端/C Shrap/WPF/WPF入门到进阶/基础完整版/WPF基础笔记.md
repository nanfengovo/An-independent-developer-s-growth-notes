# 窗体组成和主要属性
## 窗体组成：工作区+非工作区
![[assets/WPF基础笔记/file-20250401213746484.png]]
## 属性
### WindowStartupLocation:设置窗体启动的位置
![[assets/WPF基础笔记/file-20250401214226175.png]]
#### 设置在它的所有者的正中间时的注意点
>1、在子窗体中设置WindowStartupLocation="CenterOwner"
>2、在父窗体的点击事件中告诉子窗体实例化对象的所有者（window1.Owner = this;）
### Icon:设置图标
![[assets/WPF基础笔记/file-20250401215518940.png]]
![[assets/WPF基础笔记/file-20250401215457500.png]]
效果：
![[assets/WPF基础笔记/file-20250401215546911.png]]
>这里只是改了窗体的图标，应用程序的图标没有改

![[assets/WPF基础笔记/file-20250401215716028.png]]
### 设置应用程序的图标（一定要是ico文件）
![[assets/WPF基础笔记/file-20250401220245224.png]]
效果
![[assets/WPF基础笔记/file-20250401221209474.png]]
## 窗体属性
### SizeToContent: 大小跟着内容走
![[assets/WPF基础笔记/file-20250401234246308.png]]
### MaxWidth and MinWidth
>设置最大和最小宽度
### Topmost="True"
>打开新窗体的时候始终保证主窗体是在最前端


## 控件
### 布局控件
#### Grid 行列（默认是一行一列）
##### 定义行：
```
 <Grid.RowDefinitions>
     <RowDefinition/>
     <RowDefinition/>
 </Grid.RowDefinitions>
```
![[assets/WPF基础笔记/file-20250402002824002.png]]
##### 定义列：
```
        <!--列定义-->
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
```
##### 设置行列的宽高（行可以设置高不能设置宽，列可以设置宽不能设置高）有三种方式
```
<Window x:Class="Chapter03.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:Chapter03"
        mc:Ignorable="d"
        Title="Grid学习" Height="450" Width="800">
    <Grid>
        <!--行定义-->
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="50px"/>
        </Grid.RowDefinitions>
        
        <!--列定义-->
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="2*"/>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition Width="50px"/>
        </Grid.ColumnDefinitions>
    </Grid>
</Window>
```
##### 跨行 Grid.RowSpan="n"  这里n代码你要跨几行
![[assets/WPF基础笔记/file-20250402004646795.png]]
##### 跨列   Grid.ColumnSpan="n" n表示几列
![[assets/WPF基础笔记/file-20250402004740457.png]]
### 内容控件

### 依赖属性
#### 应用场景
* 要求属性支持绑定
* 自定义控件的扩展属性
* 验证/强制回调
* 附加属性（特殊的依赖属性）

### 附加属性 



