```
这里放一下电脑几个数据库连接字符串：
# sql Server
Server=.;Database=数据库名;User Id=sa;Password=aaaa2624434145;Encrypt=True;TrustServerCertificate=True;
```
# 搭建ABP的环境(安装Cli)
>  dotnet tool install -g Volo.Abp.Cli 

# 创建API项目（纯后端webapi）
## 默认使用的是和cli相匹配的版本（9.1.3）
> abp new ApiDemo -u none

## 使用.net 8
>abp new apidemo -u none -version 8.3.0

==上面的两个命令最外层的文件夹都是aspnet-core== 如果在同一个文件夹下会导致覆盖
所以要使用下面的命令
> abp new apidemo -u none --version 8.0.0 -o my-api-demo

这个命令会在原来的文件夹名称为aspnet-core外面嵌套一层my-api-demo
![[attachments/Pasted image 20250825225745.png]]
这里也没什么好纠结的，其实也可以手动的去改文件夹的名称；至少到这里项目是创建完成了
## 修改两个地方的连接字符并迁移数据库
![[attachments/Pasted image 20250825230207.png]]
### 迁移数据库
在修改连接字符串后，将下图的设为启动项并运行
![[attachments/Pasted image 20250825230615.png]]
成功后使用数据库的GUI去查看下是否有这个库，如果有就是成功了，进入下一步
### 运行api项目
这里我直接运行的时候报错了，我猜是因为我用的cli版本是9.1.3但是项目的版本是.net 8
将这里的版本从8.0.0改为8.0.6就可以了
![[attachments/Pasted image 20250825231102.png]]
运行成功后自动跳转swaggerui 但是这时发现调接口是调不通的，是因为没有进行授权，那么怎么授权呢
### 接口授权
找到Login下面的api/account/login接口
使用admin,1q2w3E* 登录后就可以调通其余的接口了
### 添加新的控制器

# TODOAPP Demo
## 不分层的MVC
> https://abp.io/docs/latest/tutorials/todo/single-layer?UI=MVC&DB=EF

## 分层的MVC
>https://abp.io/docs/latest/tutorials/todo/layered?UI=MVC&DB=EF

