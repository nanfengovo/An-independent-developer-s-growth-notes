# Identity 标识框架1
>https://www.bilibili.com/video/BV1pK41137He?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=144
## Authentication （鉴权/验证）与Authorization(授权)
>Authentication : 用来验证用户是否登录
>Authorization : 用来验证用户是否有权限进行访问

## 标识（ Identity）框架
>采用基于角色的访问控制（Role-Based Access Control，简称RBAC）策略，内置了对用户、角色等表的管理以及相关的接口，支持外部登录、2FA等
>标识框架使用EFCore对数据库进行操作，因此标识框架支持几乎所有的数据库

## Identity框架的使用
> 1、 IdentityUser<TKey>、IdentityRole<Tkey> Tkey代表主键的类型。我们一般编写继承自Identity<TKey>、IdentityRole<TKey>的自定义类，可以增加自定义属性
> 2、Nuget安装：
> 	Microsoft.AspNetCore.Identity.EntityFrameworkCore
> 3、创建继承自IdentityDbContext的类
> 4、可以通过IdDbContext类来操作数据库，不过框架提供了RoleManager、UserManager等类来简化对数据库的操作
> 5、部分方法发返回值为Task<IdentityResult>类型，查看IdentityResult类型定义
> 6、向依赖注入容器中注册标识框架相关的业务




# 实操步骤：
## 1、建立Asp.net Core webapi的项目（8.0）
## 2、安装nuget :Microsoft.AspNetCore.Identity.EntityFrameworkCore
## 3、添加MyUser类继承IdentityUser<long>
![[Pasted image 20250221231935.png]]
## 4、添加MyRole类继承IdentityRole<long>
## 5、添加MyDbContext 类 继承IdentityDbContext
![[Pasted image 20250221232504.png]]
## 6、编写这部分代码
![[Pasted image 20250222000651.png]]
## 7、安装nuget : Microsoft.EntityFrameworkCore.SqlServer
## 8、安装nuget: Microsoft.EntityFrameworkCore.Tools
## 9、添加：DbContextDesignTimeFactory 类
![[Pasted image 20250222001753.png]]
## 效果：
![[Pasted image 20250222001844.png]]


#  标识框架2
> https://www.bilibili.com/video/BV1pK41137He?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=145

## 使用 
###  1 .添加Demo控制器
```
[Route("api/[controller]/[action]")]
[ApiController]
public class DemoController : ControllerBase
{
    private readonly UserManager<MyUser> userManager;

    private readonly RoleManager<MyRole> roleManager;

    public DemoController(UserManager<MyUser> userManager, RoleManager<MyRole> roleManager)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
    }

    [HttpPost]
    public async Task<ActionResult<string>> Test1()
    {
       if(await roleManager.RoleExistsAsync("admin")==false)
        {
            MyRole Role = new MyRole { Name = "admin"};
            var result = await roleManager.CreateAsync(Role);
            if(!result.Succeeded)
            {
                return BadRequest("roleManager.Create failed!!");
            }

        }
        MyUser user1 = await userManager.FindByNameAsync("yzk");
        if(user1 == null)
        {
            user1 = new MyUser { UserName = "yzk" };
            var result = await userManager.CreateAsync(user1, "123456");
            if (!result.Succeeded)
            {
                return BadRequest("userManager.Create failed!!");
            }
        }
        if(await userManager.IsInRoleAsync(user1, "admin"))
        {
            var result = userManager.AddToRoleAsync(user1, "admin");
            if (!result.Result.Succeeded)
            {
                return BadRequest("userManager.AddToRoleAsync failed!!");
            }
        }
	      if(!await userManager.IsInRoleAsync(user1, "admin"))
		 {
		     var result = userManager.AddToRoleAsync(user1, "admin");
		     if (!result.Result.Succeeded)
		     {
		         return BadRequest("userManager.AddToRoleAsync failed!!");
		     }
		 }
		return "ok!";
    }
}
```

