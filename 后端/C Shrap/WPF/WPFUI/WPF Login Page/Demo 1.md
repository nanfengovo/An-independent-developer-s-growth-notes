# 最终效果：
![[Pasted image 20250118233057.png]]
# MainWindow.xaml
``` xaml
<Window x:Class="Login_App.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:Login_App"
        mc:Ignorable="d" WindowStartupLocation="CenterScreen" WindowStyle="None" AllowsTransparency="True" Background="Transparent"
        Title="MainWindow" Height="500" Width="800">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="1.5*"/>
        </Grid.ColumnDefinitions>
        
        <Image Source="/Images/nimbus--close.png" Grid.Column="1" Panel.ZIndex="1" MouseUp="Image_MouseUp" Style="{StaticResource imgClose}"/>

        
        <!--左侧-->
        <Border CornerRadius="10 0 0 10">
            <Border.Background>
                <LinearGradientBrush StartPoint="0,0" EndPoint="1,1">
                    <GradientStop Color="#3AA9AD"
                                  Offset="0" />
                    <GradientStop Color="#3AADA1"
                                  Offset="1" />
                </LinearGradientBrush>
            </Border.Background>
            
            <!--避免左侧太单调，填充点多边形-->
            <Grid>
                <Canvas>
                    <Polygon Points="0,20,230,140,0,270"
                             Fill="#4EB1B6" />
                    <Polygon Points="100,400,200,370,180,470"
                             Fill="#4EB1B6" />
                    <Ellipse Margin="250 450 0 0"
                             Width="40"
                             Height="40"
                             Fill="#4EB1B6" />
                    <Ellipse Margin="50 400 0 0"
                             Width="20"
                             Height="20"
                             Fill="#4EB1B6" />
                </Canvas>

                <StackPanel VerticalAlignment="Center">
                    <TextBlock  Text="Sign Up" Style="{StaticResource titleText}" />
                    <TextBlock  Text="Enter your person info and create new account to connect us" Style="{StaticResource normalText}" Opacity="0.8" Margin="20 30"/>
                    <Button  Content="Sign Up" Style="{StaticResource button}"/>
                </StackPanel>
            </Grid>
        </Border>
        
        <!--右侧-->
        <Border Background="#ffffff" Grid.Column="1" CornerRadius="0 10 10 0" MouseDown="Border_MouseDown">
            <StackPanel VerticalAlignment="Center">
                <TextBlock Text="Sign in to App" Style="{StaticResource titleText}" Foreground="#3AB19B"/>
                <StackPanel Orientation="Horizontal" Margin="0 20" HorizontalAlignment="Center">
                    <Button Style="{StaticResource buttonCircle}">
                        <Image Source="/Images/ri--google-fill.png" Width="20" Height="20"  />
                    </Button>
                    <Button Style="{StaticResource buttonCircle}">
                        <Image Source="/Images/ri--facebook-box-fill.png"
                               Width="20"
                               Height="20" />
                    </Button>
                    <Button Style="{StaticResource buttonCircle}">
                        <Image Source="/Images/ion--logo-linkedin.png"
                               Width="20"
                               Height="20" />
                    </Button>
                </StackPanel>

                <TextBlock Text="or use youe email info: " Style="{StaticResource normalText}" Foreground="#878787" Margin=" 0 10 0 15" />

                <Border BorderThickness="1" BorderBrush="#acb0af" Margin="70 7" CornerRadius="5">
                    <Grid Margin="7 9">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition  Width="auto"/>
                            <ColumnDefinition  Width="*"/>
                        </Grid.ColumnDefinitions>

                        <Image Source="/Images/tdesign--user.png" Height="20" />
                        <TextBlock x:Name="textUser" MouseDown="textUser_MouseDown" Text="用户名：" Style="{StaticResource textHint}"/>
                        <TextBox x:Name="txtUser" TextChanged="txtUser_TextChanged" Style="{StaticResource textBox}"/>
                    </Grid>
                </Border>

                <Border BorderThickness="1"
                        BorderBrush="#acb0af"
                        Margin="70 7"
                        CornerRadius="5">
                    <Grid Margin="7 9">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition  Width="auto" />
                            <ColumnDefinition  Width="*" />
                        </Grid.ColumnDefinitions>

                        <Image Source="/Images/ri--lock-2-line.png"
                               Height="20" />
                        <TextBlock x:Name="textPassword"
                                   MouseDown="textPassword_MouseDown"
                                   Text="密码："
                                   Style="{StaticResource textHint}" />
                        <PasswordBox x:Name="txtPassword" PasswordChanged="txtPassword_PasswordChanged" Style="{StaticResource textBox}"/>
                    </Grid>
                </Border>

                <Button Content="Sign In" Click="Button_Click" Style="{StaticResource mainbutton}"/>
            </StackPanel>
        </Border>
    </Grid>
</Window>
```
# MainWindow.cs
``` c#
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

namespace Login_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtUser.Focus();
        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtUser.Text) && txtUser.Text.Length > 0 )
            {
                textUser.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtUser.Visibility = Visibility.Visible;
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

      

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtUser.Text) && !string.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("Successfully Signed Im");
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
```
# App.xaml
```xaml
<Application x:Class="Login_App.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:Login_App"
             StartupUri="MainWindow.xaml">
    <Application.Resources>

<!--标题文本样式-->
        <Style x:Key="titleText"
               TargetType="TextBlock">
            <Setter Property="FontSize"
                    Value="36" />
            <Setter Property="FontWeight"
                    Value="Bold" />
            <Setter Property="TextAlignment"
                    Value="Center" />
            <Setter Property="Foreground"
                    Value="#ffffff" />
        </Style>
        
 <!--普通文本样式-->       
        <Style x:Key="normalText" TargetType="TextBlock">
            <Setter Property="FontSize"
                    Value="16" />
            <Setter Property="LineHeight"
                    Value="28" />
            <Setter Property="TextWrapping"
                    Value="Wrap" />
            <Setter Property="TextAlignment"
                    Value="Center"/>
            <Setter Property="Foreground" Value="#ffffff"/>
        </Style>

<!--按钮样式-->        
        <Style x:Key="button" TargetType="Button">
            <Setter Property="FontSize"
                    Value="14" />
            <Setter Property="Width"
                    Value="170" />
            <Setter Property="Background"
                    Value="Transparent" />
            <Setter Property="Foreground"
                    Value="#fdfefe" />
            <Setter Property="FocusVisualStyle"
                    Value="{x:Null}" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Border Background="{TemplateBinding Background}" CornerRadius="25" BorderThickness="1" BorderBrush="White" Padding="15">
                            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            <Style.Triggers>
                <Trigger Property="IsMouseOver" Value="True">
                    <Setter  Property="Background"
                             Value="#e8e8e8" />
                    <Setter  Property="Foreground"
                             Value="DimGray" />
                </Trigger>
                <Trigger Property="IsMouseCaptured"
                         Value="True">
                    <Setter  Property="Background"
                             Value="#d9d9d9" />
                    <Setter  Property="Foreground"
                             Value="DimGray" />
                </Trigger>
            </Style.Triggers>
        </Style>

        <!--圆圈按钮的样式-->
        <Style x:Key="buttonCircle"
               TargetType="Button">
            <Setter Property="Background"
                    Value="Transparent" />
            <Setter Property="FocusVisualStyle"
                    Value="{x:Null}" />
            <Setter Property="Margin" Value="8 0"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Border Background="{TemplateBinding Background}"
                                CornerRadius="30"
                                BorderThickness="1"
                                BorderBrush="#878787"
                                Padding="15">
                            <ContentPresenter HorizontalAlignment="Center"
                                              VerticalAlignment="Center" />
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            <Style.Triggers>
                <Trigger Property="IsMouseOver"
                         Value="True">
                    <Setter  Property="Background"
                             Value="#d9d9d9" />
                </Trigger>
                <Trigger Property="IsMouseCaptured"
                         Value="True">
                    <Setter  Property="Background"
                             Value="#c4c4c4" />
                </Trigger>
            </Style.Triggers>
        </Style>

        
        
        <Style x:Key="textHint" TargetType="TextBlock">
            <Setter Property="FontSize"
                    Value="14" />
            <Setter Property="Grid.Column"
                    Value="1" />
            <Setter Property="Panel.ZIndex"
                    Value="1" />
            <Setter Property="Margin"
                    Value="10 0 0 0" />
            <Setter Property="Background" Value="White"/>
        </Style>

        <Style x:Key="textBox" TargetType="Control">
            <Setter  Property="FontSize"
                     Value="14" />
            <Setter Property="Grid.Column"
                    Value="1" />
            <Setter Property="Margin"
                    Value="10 0 0 0" />
            <Setter Property="Foreground"
                    Value="#878787" />
            <Setter Property="BorderBrush"
                    Value="Transparent" />
            <Setter Property="BorderThickness"
                    Value="0" />
        </Style>


        <Style x:Key="mainbutton"
               TargetType="Button">
            <Setter Property="FontSize"
                    Value="14" />
            <Setter Property="Width"
                    Value="200" />
            <Setter Property="Margin"
                    Value="0 20 0 0" />
            <Setter Property="Background"
                    Value="#3AB19B" />
            <Setter Property="Foreground"
                    Value="#FDFEFE" />
            <Setter Property="FocusVisualStyle"
                    Value="{x:Null}" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Border Background="{TemplateBinding Background}"
                                CornerRadius="25"
                                BorderThickness="1"
                                BorderBrush="#49B7A3"
                                Padding="15">
                            <ContentPresenter HorizontalAlignment="Center"
                                              VerticalAlignment="Center" />
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            <Style.Triggers>
                <Trigger Property="IsMouseOver"
                         Value="True">
                    <Setter  Property="Background"
                             Value="#339685" />
                    <Setter  Property="Foreground"
                             Value="White" />
                </Trigger>
                <Trigger Property="IsMouseCaptured"
                         Value="True">
                    <Setter  Property="Background"
                             Value="#2d7a6c" />
                    <Setter  Property="Foreground"
                             Value="White" />
                </Trigger>
            </Style.Triggers>
        </Style>

        <Style x:Key="imgClose" TargetType="Image">
            <Setter Property="Width"
                    Value="30" />
            <Setter Property="Height"
                    Value="30" />
            <Setter Property="VerticalAlignment"
                    Value="Top" />
            <Setter Property="HorizontalAlignment"
                    Value="Right" />
            <Setter Property="Margin"
                    Value="0 13 13 0" />
            <Style.Triggers>
                <Trigger Property="IsMouseOver" Value="True">
                    <Setter Property="RenderTransform">
                        <Setter.Value>
                            <ScaleTransform ScaleX="1.1"
                                            ScaleY="1.1" />
                        </Setter.Value>
                    </Setter>
                </Trigger>
            </Style.Triggers>
        </Style>

    </Application.Resources>
</Application>
```
