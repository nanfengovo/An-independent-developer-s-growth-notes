# EFCore介绍
https://www.bilibili.com/video/BV1pK41137He?vd_source=b7200d0eaee914e9c128dcabce5df118&p=50&spm_id_from=333.788.videopod.episodes
## EF Core
>Entity Framework Core（简称EF Core）是.NET Core中的ORM（object relational mapping，对象关系映射）框架，它可以让开发人员以面向对象的方式进行数据库操作，从而大大提高开发效率。本章将讲解EF Core的使用及在项目开发中使用EF Core需要注意的问题。
>EF Core是微软官方提供的ORM框架。EF Core不仅可以操作Microsoft SQL Server、MySQL、Oracle、PostgreSQL等数据库，而且可以操作Azure Cosmos DB等NoSQL数据库。
>除了EF Core之外，.NET Core中还有==Dapper、NHibernate Core、PetaPoco==等ORM框架。因为EF Core是微软官方出品的，而且EF Core体现的是面向模型的编程方式，更加先进，所以EF Core的市场占有率比较高。



## ORM
>ORM（object relational mapping，对象关系映射）中的“对象”指的就是C#中的对象，而“关系”指的是关系数据库，“映射”指的是在关系数据库和C#对象之间搭建一座“桥梁”。我们知道，在.NET中可以通过ADO.NET连接数据库然后执行SQL语句来操作数据库中的数据。而ORM可以让我们通过==操作C#对象的方式操作数据库==，比如使用ORM，可以通过创建C#对象的方式把数据插入数据库
>ORM只是对ADO.NET的封装，ORM底层仍然是通过ADO.NET访问数据库的。

# EFCore 入门(SQL Server)

## EFCore 环境搭建
https://www.bilibili.com/video/BV1pK41137He?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.player.switch&p=51
### 1.创建实体类
ex:
```
 internal class User
 {
     //id 主键 自增
     public int Id { get; set; }
     //用户名
     public string UserName { get; set; }
     //密码
     public string Password { get; set; }
 }
```
### 2.为项目安装NuGet包Microsoft.EntityFrameworkCore.SqlServer
	先创建一个实现了IEntityTypeConfiguration接口的实体类的配置类BookEntityConfig，它用于配置实体类和数据库表的对应关系
```
 internal class UserEntityConfig : IEntityTypeConfiguration<User>
 {
     public void Configure(EntityTypeBuilder<User> builder)
     {
         //表名 —— T_User
         builder.ToTable("T_User");

         //用户名是必填的最大长度是10位
         builder.Property(x=>x.UserName).HasMaxLength(10).IsRequired();

         //密码是必填的最大长度是20位
         builder.Property(x => x.Password).HasMaxLength(20).IsRequired();


     }
 }
```
### 3.创建一个继承自DbContext类的TestDbContext类
```
   internal class TestDbContext:DbContext
   {
       public DbSet<User> Users { get; set; }
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
           string conStr = "Server = . ;Database = PLCHelper ;Trusted_Connectio = true";
           optionsBuilder.UseSqlServer(conStr);
       }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           base.OnModelCreating(modelBuilder);
           modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
       }
   }
```
>我们把这样继承自DbContext的类叫作“上下文”。
>OnConfiguring方法用于对程序要连接的数据库进行配置，其中connStr变量的值表示程序要连接本地SQL Server数据库中名字为PLCHelper的数据库

### 4.为项目安装Microsoft.EntityFrameworkCore.Tools包
>在为项目安装完成Microsoft.EntityFrameworkCore.Tools包之后，在【程序包管理器控制台】中执行如下命令：
>1、Add-Migration InitialCreate。
>成功：
>![[Pasted image 20241230200122.png]]
>2、接着在【程序包管理器控制台】中执行Update-database
>一开始执行报错
>>A connection was successfully established with the server, but then an error occurred during the login process. (provider: SSL Provider, error: 0 - 证书链是由不受信任的颁发机构颁发的。)
>则：在原有字符串的基础上添加：Encrypt=True;Trusted_Connection=True;TrustServerCertificate=True;
>完整的字符串为 ; "Server = . ;Database = PLCHelper ;User=sa ;Password=aaaa2624434145 ;Encrypt=True;Trusted_Connection=True;TrustServerCertificate=True; "
>3、查看SqlServer
>![[Pasted image 20241230201237.png]]
>
#### 解析两个命令
##### Add-Migration+迁移说明
>Add-Migration InitialCreate就是一个数据库迁移命令，它的作用是根据实体类及配置生成操作数据库的迁移代码，其中的InitialCreate是开发人员给这次迁移取的名字，只要符合C#标识符命名规则，这个名字可以随意取，但是建议取一个能反映这次变化的、有意义的名字。Migrations文件夹下C#代码的文件的名字就是由“Id+迁移名字”组成的。

##### Update-database
>Update-database命令用于对当前连接的数据库执行所有未应用的数据库迁移代码，命令执行成功后，数据库中的表结构等就和项目中实体类的配置保持一致了。

## EFCore的基本操作--增删查改
>更改数据库需要：ctx.SaveChanges();
### 1.插入数据
https://www.bilibili.com/video/BV1pK41137He?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.player.switch&p=52
```
using System;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var ctx = new TestDbContext())
            {
                 #region 初始化数据 只能初始化一次  增
				 var user1 = new EntityModel.User { UserName = "admin", Password = "12345" };
				 ctx.Users.Add(user1);
				 ctx.SaveChanges();
				
				 var book1 = new EntityModel.Book { AuthorName = "张三", Title = "BOOK1", Price = 10 };
				 var book2 = new EntityModel.Book { AuthorName = "李四", Title = "BOOK2", Price = 20 };
				 var book3 = new EntityModel.Book { AuthorName = "张三", Title = "BOOK3", Price = 30 };
				 var book4 = new EntityModel.Book { AuthorName = "王五", Title = "BOOK4", Price = 40 };
				 var book5 = new EntityModel.Book { AuthorName = "张三", Title = "BOOK5", Price = 50 };
				 var book6 = new EntityModel.Book { AuthorName = "王五", Title = "BOOK6", Price = 60 };
				 ctx.Books.AddRange(book1, book2, book3, book4, book5, book6);
				 ctx.SaveChanges();
				 Console.WriteLine("初始化数据成功！");
				 #endregion
            }
            
            
        }
    }
}
```

```
namespace EFCore.EntityModel
{
    public class User
    {


            //id 主键 自增
            public int Id { get; set; }
            //用户名
            public string UserName { get; set; }
            //密码
            public string Password { get; set; }


    }
}

```


```
using EFCore.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    internal class TestDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStr = "Server = . ;Database = PLCHelper ;User=sa ;Password=aaaa2624434145 ;Encrypt=True;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(conStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }


    }
}


```

```
using EFCore.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore
{
    internal class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //表名 —— T_User
            builder.ToTable("T_User");

            //用户名是必填的最大长度是10位
            builder.Property(x=>x.UserName).HasMaxLength(10).IsRequired();

            //密码是必填的最大长度是20位
            builder.Property(x => x.Password).HasMaxLength(20).IsRequired();


        }
    }
}

```
_____
>12.30的问题：
>1、EFCore怎么加表/表怎么加字段
>2、怎么在ASP.NET Core中使用EFCore设置种子数据

### 2.查

#### 只查找
using System;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var ctx = new TestDbContext())
            {
                  #region 查
					  var books = ctx.Books.Where(x => x.Price > 30);
					  foreach (var b in books)
					  {
					      Console.WriteLine(b.Title);
					  }
				  #endregion
            }
            
            
        }
    }
}
#### 查找并排序
  #region 查找并按价格倒叙
  var items = ctx.Books.Where(x => x.Price > 30).OrderByDescending(x => x.Price);
  foreach(var it in items)
  {
      Console.WriteLine($"{it.AuthorName},{it.Price}");
  }
  #endregion
### 3.删   --查到后删除
```
 #region 删除价格为40的第一本书 --查到第一个后删除
 try
 {
     var book = ctx.Books.Where(x => x.Price == 40).FirstOrDefault();
     ctx.Remove(book);
     ctx.SaveChanges();
     Console.WriteLine("删除成功！");
 }
 catch (Exception)
 {

     Console.WriteLine("不存在价格为40的书！");
 }
 
 #endregion
```

### 4.改
```

                #region 改   查到后修改
                //将价格为50的书的价格改为100
                var book = ctx.Books.Where(x => x.Price == 50).FirstOrDefault();
                if (book != null)
                {
                    book.Price = 100;
                    ctx.SaveChanges();
                    Console.WriteLine("修改成功！");
                }
                else
                {
                    Console.WriteLine("不存在价格为50的书！");
                }


                #endregion
```
## EFCore进阶--批量增删查改
```
    #region 批量增删查改  ， 对价格大于30的书的价格加100
    var books = ctx.Books.Where(x => x.Price > 30);
    foreach (var b in books)
    {
        b.Price += 100;
    }
    ctx.SaveChanges();
    #endregion
```
## Fluent
https://www.bilibili.com/video/BV1pK41137He?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.player.switch&p=53
### 约定配置 ——约定大于配置
>为了减少配置工作量，EF Core采用了“约定大于配置”的设计原则，也就是说EF Core会默认按照约定根据实体类以及DbContext的定义来实现和数据库表的映射配置，除非用户显式地指定了配置规则。
 
>几个主要的约定规则。
>规则1：数据库表名采用上下文类中对应的DbSet的属性名。
>规则2：数据库表列的名字采用实体类属性的名字，列的数据类型采用和实体类属性类型兼容的类型。比如在SQL Server中，string类型对应nvarchar，long类型对应bigint。
>规则3：数据库表列的可空性取决于对应实体类属性的可空性。EF Core 6中支持C#中的可空引用类型。
>规则4：名字为Id的属性为主键，如果主键为short、int或者long类型，则主键默认采用自动增长类型的列。


### Data Annotation（数据注释）
>Data Annotation（数据注释）指的是可以使用.NET提供的Attribute[[1]](file:///index_split_030.html#filepos418196)对实体类、属性等进行标注的方式来实现实体类配置。比如通过[Table("T_Books")]，我们可以把实体类对应的表名配置为T_Books；通过[Required]，我们可以把属性对应的数据库表列配置为“不可为空”；通过[MaxLength(20)]，我们可以把属性对应的数据库表列配置为“最大长度为20”

### Fluent API


# 


# WPF中EFCore 结合Sqlite


