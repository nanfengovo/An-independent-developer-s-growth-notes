# 未配置
我们知道电脑安装了MySQL后一般可以通过 mysql --version 命令来查看电脑安装的MySQL的版本
```cmd
mysql --version

```
此时还没有配置环境变量：
![[Pasted image 20241029103004.png]]
可以到MySQL的安装目录下调出cmd去执行这个命令 （Windows 默认安装路径为：C:\Program Files\MySQL\MySQL Server 8.0\bin）
![[Pasted image 20241029103441.png]]
我们发现这个时候命令是可以被识别到的，所以将这个路径配置到path下
右键此电脑→属性→高级系统设置→环境变量，将Windows 默认安装路径为：C:\Program Files\MySQL\MySQL Server 8.0\bin添加到Path
![[Pasted image 20241029104632.png]]
![[Pasted image 20241029104715.png]]
![[Pasted image 20241029104830.png]]