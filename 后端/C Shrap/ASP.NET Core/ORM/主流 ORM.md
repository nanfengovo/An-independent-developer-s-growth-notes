---
created: 2024-11-08T11:42:19 (UTC +08:00)
tags: []
source: https://mp.weixin.qq.com/s/xHSBGaWaJhgq_fjusj-Xfg
author: 
---

# .NET 主流 ORM 功能介绍 大全 最新

> ## Excerpt
> .NET主流ORM下面是3款.NET 使用最多的ORM，来自公众号投票结果 ，数据比较真实可靠测试项目发布时

---
下面是3款.NET 使用最多的ORM，来自公众号投票结果 ，数据比较真实可靠

| 测试项目 | 发布时间 | 微信公众号投票 | 使用难度 | 功能 | 性能 |
| --- | --- | --- | --- | --- | --- |
| SqlSugar orm | 2014 | 26% 491票 | 适中 | 全 | 中高 |
| EFCore  orm | 2016 | 36% 663票 | 较难 | 全 | 中高 |
| Dapper  orm | 2013 | 23%  374票 | 简单 | 少 | 高 |

  

一、SqlSugar ORM介绍

一款老牌 .NET 开源多库架构ORM框架（EF Core单库架构），由果糖大数据科技团队维护和更新 ，开箱即用最易上手的.NET ORM框架 。  

生态圈丰富，目前开源生态仅次于EF Core，但是在需要多库兼容的项目或产品中更加偏爱SqlSugar

1.1、ORM入门示例

```
//创建数据库对象 (用法和EF Dappper一样通过new保证线程安全)  
SqlSugarClient Db= new SqlSugarClient(new ConnectionConfig(){  
       ConnectionString = "连接符字串",  
       DbType = DbType.SqlServer,  
       IsAutoCloseConnection = true});  
//建表  
//db.CodeFirst.InitTables<Student>(); 更多看文档迁移         
          
//查询表的所有  
var list = db.Queryable<Student>().ToList();  
    
//插入  
db.Insertable(new Student() { SchoolId = 1, Name = "jack" }).ExecuteCommand();  
    
//更新  
db.Updateable(new Student() { Id = 1, SchoolId = 2, Name = "jack2" }).ExecuteCommand();  
    
//删除  
db.Deleteable<Student>().Where(it => it.Id == 1).ExecuteCommand();  
    
//实体与数据库结构一样  
public class Student  
{  
 //数据是自增需要加上IsIdentity  
 //数据库是主键需要加上IsPrimaryKey  
 //注意：要完全和数据库一致2个属性  
 [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]  
 public int Id { get; set; }  
 public int? SchoolId { get; set; }  
 public string Name { get; set; }  
}
```

#### 1.2、SqlSugar ORM 开箱即用（支持AOT）

1、真正可以实现零Sql的ORM,拥有超强查询体系：导航查询、联表查询、并集查询、子查询 、 报表查询 等

2、支持 .NET 百万级【大数据】写入和更新、分表和几十亿查询和统计等 拥有成熟方案

3、支持 SAAS 完整应用 跨库查询 、审计、租户分库 、租户分表 和 租户数据隔离

4、支持【低代码】+工作流 （动态建类 、动态建表、无实体多库兼容CRUD 、 JSON TO SQL 、自定义XML等）

5、语法最爽的.NET ORM、优美的表达式、仓储、UnitOfWork、DbContext、AOP

6、支持 DbFirst、CodeFirst(无命令迁移)和【WebFirst】 3种模式开发

7、 简单易用、功能齐全、高性能、轻量级、服务齐全、官网教程文档、有专业技术支持一天18小时服务

1.3、SqlSugar数据库支持

| 关系型数据库 | MySql、SqlServer、Sqlite、Oracle 、 postgresql、达梦、人大金仓(国产推荐)、海量数据库Vastbase、神通数据库、瀚高、Access 、OceanBase MySqlConnector、华为 GaussDB 、南大通用 GBase、MariaDB、Tidb、Odbc、Percona Server, Amazon Aurora、Azure Database for MySQL、PolarDB Google Cloud SQL for MySQL、kunDB、TDSQL、GoldenDB 、自定义数据库 |
| --- | --- |
| 时序数据库 | TDengine (支持群集，缺点不支持更新，语法比较弱支持的东西少)QuestDb（适合几十亿数据分析,模糊查询,适合单机，语法强大，自动分表存储 ，缺点不支持删除） |
| 列式存储库 | Clickhouse（适用于商业智能领域(BI)，缺点大小写必须和库一样，不支持事务） |
| 即将上线 | Mongodb（mongodb.entities）延期24年1月Sybase、hana、FireBird、InfluxDBlitedb、 |

SqlSugar特色1：超级简单

在不用任何设计模式，任何框架的情况下都可以拥有最佳体验，SqlSugar做到了保姆一样的服务，直接用不需要学习

的框架，各种默认值都是最佳配置，用到什么看一下文档便可。

SqlSugar特色2：产品必备

1、低代码支持：string to exp、exp to string、 exp to sql 、List< object> to sql 、Json to sql 、List< object> to Class

2、可以一套代码支持所有主流数据库（包括国产数据库），成本要远低于EF Core, EF Core基本每个数据库都需要手动写

兼容代码 。例如：建表、创建视图、获取表结构、获取数据类型、查询函数、索引 、修改表等等，SqlSugar只需要一

套代码就能支持多个数据库。支持多库建表，多库修改表，多库索引，多库事务，多库查询，跨库查询，多库共存，

多库切换等等。

补充：支持的Sql函数超100个

SqlSugar 特色3：高性能方案

1、SqlSugar可以生成理想的Sql脱颖而出，相反EF Core对生成的SQL的调整能力有限，可能受到一些限制和约束, SqlSugar在复杂查询方面的优势使其成为更强大、更高效的选择。

2、SqlSugar提供了全面的高性能解决方案，包括大数据写入、大数据导航查询、大数据更新、大数据分表、大数据删除、大数据插入或更新、大数据导入和验证等功能。此外，它还支持二级缓存、读写分离、时序库等功能。无论是处理海量数据还是优化数据库操作，SqlSugar都是一个强大而可靠的选择。它的高性能和丰富的功能集使得开发者能够轻松应对各种复杂场景，并实现快速高效的数据库操作。

3、SqlSugar是一个完全开源且遵循MIT协议的框架，提供了与收费组件如Z.EntityFramework.Extensions.EFCore和Dapper Plus相媲美的全部功能，而无需支付额外费用。

4、超高的基础性能，例如100万记条映射到List< T>比Dapper还快些

SqlSugar 特色4：无限潜力

任何开源都离不开活跃的社区,未来发展将越好，目前SqlSugar 拥有.NET单个开源项目最活跃的社区之一

并且当天解决率为80%，开源界最勤劳的小蜜蜂 ，每天都在和用户互动，已经形成了良性循环

社区每天都有好的建议和需求推动着SqlSugar向更高的高度发展

Sqlugar 特色5：超前理念

SqlSugar是一款来自未来的ORM，拥有超前的理念，需求领跑第一线，可以毫不夸张的说，在设计理念上就算不更新几年都不会过时，我们每天都会跟踪用户需求，将这些用户需求分类和整理，把有共性的功能都整理出来，经历过长达7年的努力，需求成负增长，已经走向了成熟和完善，是一款真正用了功能齐全的ORM框架,如果你用过EF CORE或者DAPPER肯定会为功能缺失而无奈，该有的功能没有，花里胡哨的一大堆。

如果你用SqlSugar，会给你一个不错的选择， 不断给你惊喜。

Dapper ORM

Dapper是一款轻量级ORM工具。如果你在小的项目中，使用Entity Framework、NHibernate 来处理大数据访问及关系映射，未免有点杀鸡用牛刀。你又觉得ORM省时省力，这时Dapper 将是你不二的选择。

对象关系映射（ORM）已经被使用了很长时间，以解决在编程过程中对象模型与数据模型在关系数据库中不匹配的问题。

Dapper是由Stack OverFlow团队开发的开源的，轻量级的ORM.相比于其他的ORM框架，Dapper速度非常快。

Dapper的设计考虑到了性能以及易用性。它支持使用事务，存储过程或数据批量插入的静态和动态对象绑定。

EF Core ORM

Entity Framework (EF) Core 是轻量化、可扩展、开源和跨平台版的常用 Entity Framework 数据访问技术。

EF Core 可用作对象关系映射程序 (O/RM)，这可以实现以下两点：

-   使 .NET 开发人员能够使用 .NET 对象处理数据库。
    
-   无需再像通常那样编写大部分数据访问代码。
    

EF Core 支持多个数据库引擎，请参阅数据库提供程序了解详细信息。

源码下载

Dapper ORM

https://github.com/DapperLib/Dapper

EF Core ORM

https://github.com/dotnet/efcore

SqlSugar ORM

https://github.com/DotNetNext/SqlSugar
