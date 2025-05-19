# 效果图
![[attachments/Pasted image 20250516005523.png]]
# 技术栈
>.net 6.0 WPF  iconfont.

# 文件夹一揽
![[attachments/Pasted image 20250516005929.png]]
# 开发流程
## 主界面
>设计分三行 

### 隐藏头部 （优先使用第二种方法，第一种用bug...）
![[attachments/Pasted image 20250517130202.png]]
```
    <WindowChrome.WindowChrome>
        <WindowChrome GlassFrameThickness="0"></WindowChrome>
    </WindowChrome.WindowChrome>
```
### 使用阿里的图标库 替换原来头部的最小化、最大化和关闭按钮
#### UI
![[attachments/Pasted image 20250518201733.png]]
#### 编写资源字典
![[attachments/Pasted image 20250518201907.png]]
```
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Style x:Key="OperateBtnStyle" TargetType="Button">
        <Setter Property="Width" Value="40" />
        <Setter Property="Background" Value="#11ffffff" />
        <Setter Property="Foreground" Value="White" />
        <Setter Property="FontFamily" Value="../Resource/Fonts/#iconfont" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Button">
                    <Grid Background="{TemplateBinding Background}">
                        <Border x:Name="border">
                            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" />
                        </Border>
                    </Grid>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter TargetName="border" Property="Background" Value="#33ffffff" />
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
</ResourceDictionary>
```
#### 将图标资源放在文件夹下
![[attachments/Pasted image 20250518202039.png]]