---
created: 2024-12-16T20:53:48 (UTC +08:00)
tags: [从0到1 搭建OverallAuth2.0 权限管理系统,OverallAuth2.0 权限管理系统]
source: https://www.cnblogs.com/cyzf/p/18467560
author: 陈逸子风
---

# （系列七）.net8 Aop切面编程 - 陈逸子风 - 博客园

> ## Excerpt
> 说明 该文章是属于OverallAuth2.0系列文章，每周更新一篇该系列文章（从0到1完成系统开发）。 该系统文章，我会尽量说的非常详细，做到不管新手、老手都能看懂。 说明：OverallAuth2.0 是一个简单、易懂、功能强大的权限+可视化流程管理系统。 友情提醒：本篇文章是属于系列文章，看该

---
**说明  
**

    该文章是属于OverallAuth2.0系列文章，每周更新一篇该系列文章（从0到1完成系统开发）。

    该系统文章，我会尽量说的非常详细，做到不管新手、老手都能看懂。

    说明：OverallAuth2.0 是一个简单、易懂、功能强大的权限+可视化流程管理系统。

友情提醒：本篇文章是属于系列文章，看该文章前，建议先看之前文章，可以更好理解项目结构。

**有兴趣的朋友，请关注我吧(\*^▽^\*)。**

**![](https://img2024.cnblogs.com/blog/1158526/202408/1158526-20240824140446786-404771438.png)**

**关注我，学不会你来打我**

**什么是Aop切面编程**

俗话说：没有使用Aop的系统都不是好系统。  

那么aop到底是什么东西，人们对它的评价如此之高。

Aop是Aspect Oriented Programming的缩写，意思是“面向切面编程”。

从字面意思上理解就是把一个功能块切成很多面。

**列如：**

我有10个获取数据的接口，随着代码的不断迭代,现如今想做以下2个操作。

1、现在对这10个接口做一个【性能监控】，监控这10个接口的调用时间。你会怎么做？

2、对这10个接口做一个【调用监控】，查看调用人、调用时间、传入参数、返回数据等记录。你会怎么做？

有人说，在每个接口中加一点监控代码。

也有人说，写一个监控方法，在接口中调用该方法。

但这都不是好的选择，它不仅工作量大、耦合性高，还容易造成错误，不易维护。

为了解决这种困难，aop诞生了。它在不修改接口原有逻辑的情况下，把接口切分为多个逻辑单元。

它很好的降低了这方面的耦合性，提高了代码的灵活性和可扩展性。

它目前的主要作用有：日志记录、安全控制、异常处理、事务处理、安全控制等功能。

**.net8 中Aop的运用**

首先说下：本篇Aop的运用是结合Autofac一起使用，如果对Autofac太不明白，请移步[从0到1搭建权限管理系统系列四 .net8 中Autofac的使用](https://www.cnblogs.com/cyzf/p/18439606)

 安装：Castle.DynamicProxy(选择最新)、Autofac.Extras.DynamicProxy（选择最新，最新的这个好像是包含了Castle.DynamicProxy）

编写Aop插件（AopPlugIn），代码如下

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

```
/// <summary>
/// aop插件
/// </summary>
public class AopPlugIn : IInterceptor
{
    /// <summary>
    /// 拦截
    /// </summary>
    /// <param name="invocation"></param>
    public void Intercept(IInvocation invocation)
    {
        //当前调用方法名称
        var methodName = invocation.Method.Name;

        //当前调用方法所在服务名称
        var interfaceServiceName = "I" + invocation.TargetType.Name;

        //获取当前调用的方法信息
        var methodInfo = invocation.Method;

        //当前方法参数数量
        var methodParameterCount = methodInfo.GetParameters().Length;

        // 当前接口所有参数
        foreach (var parameter in methodInfo.GetParameters())
        {
            //参数名称
            var ParameterName = parameter.Name;
            //参数值
            var ParameterValue = invocation.Arguments[parameter.Position];
            //参数类型
            var ParameterType = invocation.Arguments[parameter.Position] == null ? string.Empty : invocation.Arguments[parameter.Position].GetType().Name;
        }

        /*
         你可以在方法执行前，编写任何逻辑
         */

        //执行调用方法
        invocation.Proceed();

        /*
         你可以在方法执行后，编写任何逻辑
         */

        //当前接口返回值
        var value = invocation.ReturnValue;
    }
}
```

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

代码解释：该插件相当于一个拦截器，只要被Autofac注册的服务并且要求拦截，那么该服务下的所有接口都会进入拦截器中。

**Intercept()：**在该aop中方法中可以获取当前调用接口的名称、服务名称、参数、返回值等

**invocation.Proceed()**：执行当前调用的接口。在该方法前后做一些逻辑操作，如日志、性能监控、异常监控等。

**在Autofac中添加Aop集成服务**

如果对Autofac太不明白，请移步[从0到1搭建权限管理系统系列四 .net8 中Autofac的使用](https://www.cnblogs.com/cyzf/p/18439606)

编写好aop的插件后，我们需要把aop插件集成到Autofac中，配合完成接口的拦截。代码如下

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

```
/// <summary>
/// Autofac插件
/// </summary>
public class AutofacPlugIn : Autofac.Module
{
    /// <summary>
    /// 重写Autofac的Load方法
    /// </summary>
    /// <param name="containerBuilder"></param>
    protected override void Load(ContainerBuilder containerBuilder)
    {
        //服务项目程序集
        Assembly service = Assembly.Load("DomainService");
        Assembly intracface = Assembly.Load("Infrastructure");

        //注册aop
        containerBuilder.RegisterType(typeof(AopPlugIn));

        //项目必须以xxx结尾
        containerBuilder.RegisterAssemblyTypes(service).Where(n => n.Name.EndsWith("Service") && !n.IsAbstract)
            .InstancePerLifetimeScope().AsImplementedInterfaces().InterceptedBy(typeof(AopPlugIn)).EnableInterfaceInterceptors();
        containerBuilder.RegisterAssemblyTypes(intracface).Where(n => n.Name.EndsWith("Repository") && !n.IsAbstract)
           .InstancePerLifetimeScope().AsImplementedInterfaces();
    }
}
```

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

代码解释：containerBuilder.RegisterType(typeof(AopPlugIn));必须要先注册aop，然后通过InterceptedBy(typeof(AopPlugIn)).EnableInterfaceInterceptors()集成到Autofac中。

这里要注意下，我们可以在后面添加where条件，来确定哪些接口需要拦截。如果不添加，那么就会拦截Autofac中所有的接口

**测试**

aop的使用，其实就是一个拦截器，拦截被autofac注入的服务接口，所以配置非常简单，当然所有的技术都不是完美的，要看系统进行选择。

执行之前我们搭建好的接口

![](https://img2024.cnblogs.com/blog/1158526/202410/1158526-20241016113058934-455449513.png)

执行：查询所有用户接口GetAllUser（）

![](https://img2024.cnblogs.com/blog/1158526/202410/1158526-20241016113158361-1237889503.png)

可以看到，该接口被成功拦截。我们可以自由的在方法前后，添加业务逻辑，它不会改变原有接口逻辑。

![](https://img2024.cnblogs.com/blog/1158526/202410/1158526-20241016113254870-1404350932.png)

以上是一些接口的基本信息，及返回值，当然我们可以获取更多接口的信息。

有了这些信息后，我们就可以做很多逻辑操作，比如之前说的：日志记录、性能监控、调用监控、异常信息、事务处理等。

以上就是全局异常捕获机制，感兴趣的可以下载项目，修改吧。

**源代码地址：https://gitee.com/yangguangchenjie/overall-auth2.0-web-api**  

**预览地址：http://139.155.137.144:8880/swagger/index.html**

**帮我Star，谢谢。**

**有兴趣的朋友，请关注我微信公众号吧(\*^▽^\*)。**

**![](https://img2024.cnblogs.com/blog/1158526/202408/1158526-20240824140446786-404771438.png)**

关注我：一个全栈多端的宝藏博主，定时分享技术文章，不定时分享开源项目。关注我，带你认识不一样的程序世界
