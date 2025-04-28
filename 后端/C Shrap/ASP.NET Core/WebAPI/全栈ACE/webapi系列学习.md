# Restful风格的API
CRUD =>增删改查
>GET:调用get类型的接口数据库的数据不发生改变（查）
>POST：数据库中增加数据（增）
>PUT：数据库中的数据发生改变（改）
>DELETE: 数据库中的数据发生减少（删）

# 跨域
>//跨域第一步 在program.cs
builder.Services.AddCors(x =&gt; x.AddPolicy("any",p=&gt;p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
>//跨域第二步 在program.cs
app.UseCors();
>//跨域第三步 在控制器
    [EnableCors("any")]
# ApiController作用（特性）：
>1、自动的推断前端传入的数据应该以什么样的方式去接收（绑定源参数推理）
>2、强行检测post、put是不是具备Route特性
>3、自动HTTP400响应
>4、Multipart/form-data 请求推理
>5、错误代码的详细信息
>6、数据验证
>

# 前端有两种传数据的方法：

## 不写在URL里后面单独使用{}
![[attachments/Pasted image 20250427193103.png]]
>这个时候后端有两种方式处理数据

### 第一种在.net3.1之后
>在控制器上面加[ApiController]属性

![[attachments/Pasted image 20250427193650.png]]
### 第二种在.NET3.1之前
>使用[Formbody]属性

![[attachments/Pasted image 20250427194956.png]]
上面两种情况效果是一样的这个时候打开后端的swagger发现使用的是json数据格式，请求的地址如下
![[attachments/Pasted image 20250427195157.png]]
![[attachments/Pasted image 20250427195247.png]]
# 返回值类型
## 特定类型
>最简单的操作返回基元或复杂数据类型（如string或自定义类型）

只返回一个状态码

## IActionResult类型
>当操作中含有多个ActionResult时，适合使用IActionResult返回类型，ActionResult类型表示多种Http状态代码。此类别中的某些常见的返回类型为BadRequestResult（400）NotFoundResult(404)、OKObjectResult(200)

## ActionResult 类型
>返回值中既要状态码还要不同类型的值


# IOC（Inversion of Control）控制反转
依赖注入和控制反转有什么关系
>依赖注入是实现控制反转的一种手段或方式

## 依赖注入（DI:Dependency Injection）
谁依赖谁？为什么需要依赖？谁注入谁？为什么需要注入
* 谁依赖谁：应用程序依赖IOC容器
* 为什么需要依赖：应用程序需要IOC容器来提供对象需要的外部资源
* 谁注入谁：IOC容器注入应用程序某个对象，应用程序依赖的对象
* 注入了什么：注入对象需要的外部资源（包括对象、资源、常量数据）*
## IOC容器是什么
>在ASP.NET Core中IOC容器就是ServiceCollection,字面意思就是服务收集器或者叫服务集合，就是一个存放服务的容器罐子，这里的服务指在开发中需要使用的各种类的统称。不仅仅是在Web项目中使用

## 依赖倒置
>不直接使用实体类依赖接口

# 服务生命周期
服务生命周期分三类
>* Transient 瞬态生命周期
>* Singleton 单例生命周期
>* Scoped 作用域生命周期

