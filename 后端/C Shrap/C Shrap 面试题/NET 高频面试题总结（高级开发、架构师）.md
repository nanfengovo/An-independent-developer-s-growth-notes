---
created: 2024-12-01T18:34:54 (UTC +08:00)
tags: []
source: https://mp.weixin.qq.com/s/UgBMgIlVpe2RkRXFFDMFWA
author: 
---

# .NET 高频面试题总结（高级开发、架构师）

> ## Excerpt
> .NET 高频面试题总结（高级开发、架构师）。

---
**问题**

1、10万+大数据处理方式、应用场景。

2、redis在项目中如何使用。

3、消息队列使用的四种场景介绍。

4、redis缓存穿透、缓存击穿、缓存雪崩原因+解决方案。

![图片](https://mmbiz.qpic.cn/sz_mmbiz_jpg/oicJiaCwicKCllIaiaQJCLUs4t6E4k1fjg1kYVYF0JtgMDT7OX6GB5YO3S0h14qZlGZDMicJuKqicbiciad7hBJUa4WQwA/640?wx_fmt=jpeg&from=appmsg&tp=webp&wxfrom=5&wx_lazy=1&wx_co=1)

5、单列模式使用场景。

6、什么是死锁？死锁产生的原因？如何避免死锁？

7、ElasticSearch使用场景。

8、TiDB使用场景。

9、Redis的优点

支持多种数据结构，如 string（字符串）、 list(双向链表)、dict(hash表)、set(集合）、zset(排序set)、hyperloglog（基数估算）

每个类型使用的场景

10、各个索引应用场景

11、B+树为什么快

12、二叉树查找法。

13、消息队列Kafka、RocketMQ、RabbitMQ的优劣势比较和使用场景

14、redis集群的方式

redis有三种集群方式：主从复制，哨兵模式和集群。

**1、主从复制**

**主从复制原理**

-   从服务器连接主服务器，发送SYNC命令；
    
-   主服务器接收到SYNC命名后，开始执行BGSAVE命令生成RDB文件并使用缓冲区记录此后执行的所有写命令；
    
-   主服务器BGSAVE执行完后，向所有从服务器发送快照文件，并在发送期间继续记录被执行的写命令；
    
-   从服务器收到快照文件后丢弃所有旧数据，载入收到的快照；
    
-   主服务器快照发送完毕后开始向从服务器发送缓冲区中的写命令；
    
-   从服务器完成对快照的载入，开始接收命令请求，并执行来自主服务器缓冲区的写命令（从服务器初始化完成）
    
-   主服务器每执行一个写命令就会向从服务器发送相同的写命令，从服务器接收并执行收到的写命令（从服务器初始化完成后的操作）
    

**主从复制优缺点**

**优点**

-   支持主从复制，主机会自动将数据同步到从机，可以进行读写分离
    
-   为了分载Master的读操作压力，Slave服务器可以为客户端提供只读操作的服务，写服务仍然必须由Master来完成
    
-   Slave同样可以接受其它Slaves的连接和同步请求，这样可以有效的分载Master的同步压力。
    
-   Master Server是以非阻塞的方式为Slaves提供服务。所以在Master-Slave同步期间，客户端仍然可以提交查询或修改请求。
    
-   Slave Server同样是以非阻塞的方式完成数据同步。在同步期间，如果有客户端提交查询请求，Redis则返回同步之前的数据
    

**缺点**

Redis不具备自动容错和恢复功能，主机从机的宕机都会导致前端部分读写请求失败，需要等待机器重启或者手动切换前端的IP才能恢复。

主机宕机，宕机前有部分数据未能及时同步到从机，切换IP后还会引入数据不一致的问题，降低了系统的可用性。

Redis较难支持在线扩容，在集群容量达到上限时在线扩容会变得很复杂。

**2、哨兵模式**

当主服务器中断服务后，可以将一个从服务器升级为主服务器，以便继续提供服务，但是这个过程需要人工手动来操作。为此，Redis 2.8中提供了哨兵工具来实现自动化的系统监控和故障恢复功能。

哨兵的作用就是监控Redis系统的运行状况。它的功能包括以下两个。

1、监控主服务器和从服务器是否正常运行。

2、主服务器出现故障时自动将从服务器转换为主服务器。

**哨兵的工作方式**

每个Sentinel（哨兵）进程以每秒钟一次的频率向整个集群中的Master主服务器，Slave从服务器以及其他Sentinel（哨兵）进程发送一个 PING 命令。

如果一个实例（instance）距离最后一次有效回复 PING 命令的时间超过 down-after-milliseconds 选项所指定的值， 则这个实例会被 Sentinel（哨兵）进程标记为主观下线（SDOWN）

如果一个Master主服务器被标记为主观下线（SDOWN），则正在监视这个Master主服务器的所有 Sentinel（哨兵）进程要以每秒一次的频率确认Master主服务器的确进入了主观下线状态

当有足够数量的 Sentinel（哨兵）进程（大于等于配置文件指定的值）在指定的时间范围内确认Master主服务器进入了主观下线状态（SDOWN）， 则Master主服务器会被标记为客观下线（ODOWN）

在一般情况下， 每个 Sentinel（哨兵）进程会以每 10 秒一次的频率向集群中的所有Master主服务器、Slave从服务器发送 INFO 命令。

当Master主服务器被 Sentinel（哨兵）进程标记为客观下线（ODOWN）时，Sentinel（哨兵）进程向下线的 Master主服务器的所有 Slave从服务器发送 INFO 命令的频率会从 10 秒一次改为每秒一次。

若没有足够数量的 Sentinel（哨兵）进程同意 Master主服务器下线， Master主服务器的客观下线状态就会被移除。若 Master主服务器重新向 Sentinel（哨兵）进程发送 PING 命令返回有效回复，Master主服务器的主观下线状态就会被移除。

**哨兵模式的优缺点**

**优点**

哨兵模式是基于主从模式的，所有主从的优点，哨兵模式都具有。

主从可以自动切换，系统更健壮，可用性更高。

缺点

Redis较难支持在线扩容，在集群容量达到上限时在线扩容会变得很复杂。

**3、Redis-Cluster集群**

redis的哨兵模式基本已经可以实现高可用，读写分离 ，但是在这种模式下每台redis服务器都存储相同的数据，很浪费内存，所以在redis3.0上加入了cluster模式，实现的redis的分布式存储，也就是说每台redis节点上存储不同的内容。

Redis-Cluster采用无中心结构,它的特点如下：

所有的redis节点彼此互联(PING-PONG机制),内部使用二进制协议优化传输速度和带宽。

节点的fail是通过集群中超过半数的节点检测失效时才生效。

客户端与redis节点直连,不需要中间代理层.客户端不需要连接集群所有节点,连接集群中任何一个可用节点即可。

**工作方式**

在redis的每一个节点上，都有这么两个东西，一个是插槽（slot），它的的取值范围是：0-16383。还有一个就是cluster，可以理解为是一个集群管理的插件。

当我们的存取的key到达的时候，redis会根据crc16的算法得出一个结果，然后把结果对 16384 求余数，这样每个 key 都会对应一个编号在 0-16383 之间的哈希槽，通过这个值，去找到对应的插槽所对应的节点，然后直接自动跳转到这个对应的节点上进行存取操作。

为了保证高可用，redis-cluster集群引入了主从模式，一个主节点对应一个或者多个从节点，当主节点宕机的时候，就会启用从节点。当其它主节点ping一个主节点A时，如果半数以上的主节点与A通信超时，那么认为主节点A宕机了。如果主节点A和它的从节点A1都宕机了，那么该集群就无法再提供服务了。

**15、如何在ASP.NET Core中激活Session功能？**

首先要添加session包. 其次要在configservice方法里面添加session。

然后又在configure方法里面调用usesession。

**16、ASP.NET Core Filter如何支持依赖注入?**

可以通过全局注册，支持依赖注入

通过TypeFilter(typeof(Filter)) 标记在方法，标记在控制器

通过ServiceType(typeof(Filter))标记在方法，标记在控制器，必须要注册Filter这类；

TypeFilter和ServiceType的本质是实现了一个IFilterFactory接口

**17、ASP.NET Core 如何和读取配置文件中的内容？**

可以有两种方式，可以通过IConfiguration接口来读取；

有可以定义根据配置文件结构一致的实体对象，来绑定到对象中去；或者通过1写入，2注入读取

必须保证：DBConnectionOption和配置文件的内容结构一致；

```
services.Configure < DBConnectionOption > (Configuration.GetSection("ConnectionStrings")); //注入多个链接   
  
private DBConnectionOption dBConnections = null;  
  
private DbContext _Context = null;  
  
public DbContextFactory(DbContext context, IOptions < DBConnectionOption > options)   
{  
        _Context = context;  
        dBConnections = options.Value;  
}
```

**18、ASP.NET Core有哪些好的功能？**

第一是依赖注入。

第二是日志系统架构。

第三是引入了一个跨平台的网络服务器，kestrel。可以没有iis, apache和nginx就可以单独运行。

第四是可以使用命令行创建应用。

第五是使用appsettings来配置工程。

第六是使用startup来注册服务。

第七是更好的支持异步编程。

第八是支持web socket和signal IR。

第九是对于跨网站的请求的预防和保护机制

**19、描述一下依赖注入后的服务生命周期?**

在ASP.NET Core中，我们不需要关心如何释放这些服务, 因为系统会帮我们释放掉。有三种服务的生命 周期。

1、单实例服务， 通过add singleton方法来添加。在注册时即创建服务, 在随后的请求中都使用这一个服务。

2、短暂服务, 通过add transient方法来添加。是一种轻量级的服务，用于无状态服务的操作。

3、作用域服务，一个新的请求会创建一个服务实例。使用add scoped方法来添加。

**20、说说RESTful是什么**

在传统的服务中，比方说WebService,WCF，Remouting，都是通过调用方法来做到一个进程去调用另外一个进程的服务，在Core WebApi中是把要调用的服务资源化，比方说有图书资源，Books，学生资源Studentlist，每一个资源对应一个控制器，然后对外提供增删改查等操作；

对外提供统一的Uri, 可以对资源Books，资源Studentlist做增删改查的操作；访问的是资源，可以根据不同的额访问方式，做不同的事儿；

**21、如何解决跨域问题？**

三种方式

1、后台模拟Http请求，既然是浏览器的行为，就避开浏览器，先来一个同源的服务器去请求，然后由服务器模拟http请求去请求到Core WebApi的资源，然后响应给前端；

2、JSONP，思路：通过html部分标签发起请求，比方说 等等，发起请求是可以避开同源策略的，使用这些标签发起请求，然后带有一个回调函数，然后得到请求后，把回调函数之心一次，把数据解析后使用；

3、服务端允许跨域，多种方式，可以自己定义中间件支持跨域，只要把响应的Response的头信息Header中写入"Access-Control-Allow-Origin"即可支持跨域；

如果需要让所有的Api都支持跨域，就可以写一个中间件从管道处理模型中去支持跨域，如果要选择性的支持跨域，可以使用ActionFilter来完成，也可以通过Cors（ASP.NET Core中提供的中间件，可以支持配置不同的跨域规则）来配置支持跨域；

**22、说说你了解到的鉴权授权技术**

1、传统的授权技术：通过Session、Cookie完成授权；

实现特点:

让无状态的http请求，变的有状态，让第一次请求和第二次请求之间产生联系，第一次请求进入服务器，在服务器写入一组session，然后返回sessionId给客户端存在Cookie,第二次请求，从cookie中渠道SessionId,传递给服务器，服务器鉴别SessionId,如果是上一次来的SessionId,就认为之前来请求过；

就认为有权限；

```
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)   
{  
    app.UseSwagger();  
    app.UseSwaggerUI(c = >c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));  
}
```

2、流行鉴权授权方式：

Token授权，在Core WebApi中主要就是JWT和IdentityServer4;

都是独立的授权中心，授权后办法token，然后客户端带着token去请求Api,Api方验证Token，验证通过就有权限，验证不通过就没有权限；

**23、gRPC有几种模式？**

四种模式

1、简单模式：简单模式只是使用参数和返回值作为服务器与客户端传递数据的方式，最简单。

2、客户端流模式：即从客户端往服务器端发送数据使用的是流，即服务器端的参数为流类型，然而在服务器相应后返还数据给客户端，使用的也是流的send方法。

一般在服务器端的代码，需要先recv再send，而客户端与此相反。但是在后面的双向模式中可以使用go的协程协作。

3、服务器端流模式：即服务器端返回结果的时候使用的是流模式，即传入的数据是通过参数形式传入的。但是在往客户端发送数据时使用send方法，与客户端返回数据的方式大同小异。

4、双向模式：客户端如果不适用协程，那么发送必须在接收之前。如果使用协程，发送与接收并没有先后顺序。为了保证协程的同步，可以使用互斥量进行约束。

**24、谈谈对通信加密解密的理解**

加密解密分为：对称可逆加密，非对称可逆加密两大类；

可逆加密：加密后得到密文，可以通过加密后的密文得到原文；

**对称可逆加密特点：**

有一个公开的加密算法，任何人都知道；

有一组Key，分为加密Key和解密Key，且两个Key是相同的；

使用当前这个Key加密，可以得到一段密文；

同时如果这段密文想要得到原文，也必须得使用这个Key才能解密；

此类被称为对称可逆加密，性能很高，但是安全性较差；

只要是key被泄密了，密文就可以被攻破得到原文；

因为加密算法是公开的；

**非对称可逆加密特点：**

有一个公开的加密算法，任何人都知道；同时有一对Key,这一组Key是成套的，两个Key不相同，二者且不能相互推导；

一个Key作为加密Key，一个Key作为解密Key，且加密Key加密  后，只能由这个解密Key才能解开；

此类被称为非对称可逆加密；

在非对称可逆加密的应用中，有一个公钥和私钥的概念；

公钥：把其中的一个Key公开，

私钥：把其中 的一个Key私有化；

那这样就有一下场景：

**1、公开加密Key，私有解密Key：**

那么任何一个拥有公开加密Key的人给我这个拥有私有解密Key的人发密文，我都能解开，且只有我能解开；

这样就可以保证在通信传输的时候，保证信息的安全；

在传输的时候不会被泄密，因为就算在传输的过程中，密文被拦截了，也无法得到原文；

因为没有这个解密Key，有密文是无法得到原文的；

**2、公开解密Key,私有化加密Key:**

那么任何一个拥有解密Key的人都能够接收到来自于我这个拥有加密Key的人发送的消息，只要是我这个私有的加密Key加密后的密文，任何一个拥有解密Key的人都能够解开密文得到原文；那这样就可以实现一个功能：防止抵赖，也就是说，如果我是有解密Key的人，我得到的密文只要能够解开，那就说明这段密文一定是拥有加密Key的人发出来的；不然我是解不开这段密文的；

最后

如果你觉得这篇文章对你有帮助，不妨点个赞支持一下！你的支持是我继续分享知识的动力。如果有任何疑问或需要进一步的帮助，欢迎随时留言。也可以加入微信公众号**\[DotNet技术匠\]** 社区，与其他热爱技术的同行一起交流心得，共同成长！

作者：IT\_ziliang

出处：blog.csdn.net/IT\_ziliang/article/details/113184223

声明：网络内容，仅供学习，尊重版权，侵权速删，歉意致谢！

**END**

**方便大家交流、资源共享和共同成长**

**纯技术交流群，需要加入的小伙伴请扫码，并备注**【**加群**】

![图片](https://mmbiz.qpic.cn/sz_mmbiz_png/oicJiaCwicKClkj8yvNE8AibIkZ3uWJQKRoaY4JiaYkLVLmJnZnFhEFASS1rUxu1T0zm7ibJ8AdVo7X9dV1wibVzPCedA/640?wx_fmt=png&from=appmsg&tp=webp&wxfrom=5&wx_lazy=1&wx_co=1)

**推荐阅读**

[推荐一款支持40+通讯协议的强大工业调试软件](http://mp.weixin.qq.com/s?__biz=MzA4MTQyNDk4OA==&mid=2456956695&idx=1&sn=849c8866928abd9aa69f6ef5221c23a4&chksm=8813a824bf642132d7dbbcd5f344ecb361057353bcdbfde8b4e7e92f2d6a7821399716a7d708&scene=21#wechat_redirect)

[Anno 微服务框架：支持多语言（.NET）与高性能 gRPC](http://mp.weixin.qq.com/s?__biz=MzA4MTQyNDk4OA==&mid=2456956516&idx=1&sn=c861569c4a6c848c7655f296a7423428&chksm=8813a957bf642041ddc664b62cdcdacaee99dc6547d3887e632dd2fc942c347af11ab62fc4d8&scene=21#wechat_redirect)

[.NET 8 高性能跨平台图像处理库 ImageSharp](http://mp.weixin.qq.com/s?__biz=MzA4MTQyNDk4OA==&mid=2456956442&idx=1&sn=7814fd83d14d2c5e53e44dc877306966&chksm=8813a929bf64203f5ffca0d1f8efe5d23b1614b47ce45440faa415d61a51708d76a0c6c631c5&scene=21#wechat_redirect)

[C# 跨平台UI框架开源了 CPF](http://mp.weixin.qq.com/s?__biz=MzA4MTQyNDk4OA==&mid=2456956695&idx=2&sn=7579e5ca585796ad5bf139259fcee838&chksm=8813a824bf64213222cecba80adc1e286d86d2484f0d8b390130b349d91907177d6bca368888&scene=21#wechat_redirect)

觉得有收获？不妨分享让更多人受益

关注「**DotNet技术匠**」，共同提升技术实力

![图片](data:image/svg+xml,%3C%3Fxml version='1.0' encoding='UTF-8'%3F%3E%3Csvg width='1px' height='1px' viewBox='0 0 1 1' version='1.1' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink'%3E%3Ctitle%3E%3C/title%3E%3Cg stroke='none' stroke-width='1' fill='none' fill-rule='evenodd' fill-opacity='0'%3E%3Cg transform='translate(-249.000000, -126.000000)' fill='%23FFFFFF'%3E%3Crect x='249' y='126' width='1' height='1'%3E%3C/rect%3E%3C/g%3E%3C/g%3E%3C/svg%3E)

**收藏**

![图片](data:image/svg+xml,%3C%3Fxml version='1.0' encoding='UTF-8'%3F%3E%3Csvg width='1px' height='1px' viewBox='0 0 1 1' version='1.1' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink'%3E%3Ctitle%3E%3C/title%3E%3Cg stroke='none' stroke-width='1' fill='none' fill-rule='evenodd' fill-opacity='0'%3E%3Cg transform='translate(-249.000000, -126.000000)' fill='%23FFFFFF'%3E%3Crect x='249' y='126' width='1' height='1'%3E%3C/rect%3E%3C/g%3E%3C/g%3E%3C/svg%3E)

**点赞**

![图片](data:image/svg+xml,%3C%3Fxml version='1.0' encoding='UTF-8'%3F%3E%3Csvg width='1px' height='1px' viewBox='0 0 1 1' version='1.1' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink'%3E%3Ctitle%3E%3C/title%3E%3Cg stroke='none' stroke-width='1' fill='none' fill-rule='evenodd' fill-opacity='0'%3E%3Cg transform='translate(-249.000000, -126.000000)' fill='%23FFFFFF'%3E%3Crect x='249' y='126' width='1' height='1'%3E%3C/rect%3E%3C/g%3E%3C/g%3E%3C/svg%3E)

**分享**

![图片](data:image/svg+xml,%3C%3Fxml version='1.0' encoding='UTF-8'%3F%3E%3Csvg width='1px' height='1px' viewBox='0 0 1 1' version='1.1' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink'%3E%3Ctitle%3E%3C/title%3E%3Cg stroke='none' stroke-width='1' fill='none' fill-rule='evenodd' fill-opacity='0'%3E%3Cg transform='translate(-249.000000, -126.000000)' fill='%23FFFFFF'%3E%3Crect x='249' y='126' width='1' height='1'%3E%3C/rect%3E%3C/g%3E%3C/g%3E%3C/svg%3E)

**在看**
