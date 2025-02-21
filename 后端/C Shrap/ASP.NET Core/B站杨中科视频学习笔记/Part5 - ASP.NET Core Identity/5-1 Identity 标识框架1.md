# Authentication （鉴权/验证）与Authorization(授权)
>Authentication : 用来验证用户是否登录
>Authorization : 用来验证用户是否有权限进行访问

# 标识（ Identity）框架
>采用基于角色的访问控制（Role-Based Access Control，简称RBAC）策略，内置了对用户、角色等表的管理以及相关的接口，支持外部登录、2FA等
>标识框架使用EFCore对数据库进行操作，因此标识框架支持几乎所有的数据库

# Identity框架的使用
> 1、 IdentityUser<TKey>、IdentityRole<Tkey> Tkey代表主键的类型。我们一般编写继承自Identity<TKey>、IdentityRole<TKey>的自定义类，可以增加自定义属性
> 2、Nuget安装：
> 	Microsoft.AspNetCore.Identity.EntityFrameworkCore
> 3、创建继承自IdentityDbContext的类
> 4、可以通过IdDbContext类来操作数据库，不过框架提供了RoleManager、UserManager等类来简化对数据库的操作
> 5、部分方法发返回值为Task<IdentityResult>类型，查看IdentityResult类型定义



