Entity Framework Core
# EFCore简介
## 什么是ORM（这个我面试被问过）
> ORM: Object Relational Mapping  让开发者用对象操作的形式操作关系数据库 （在c#和传统的关系数据库之间做转换）  
有哪些ORM 
> EFCore 、Dapper、SqlSugar、FreeSql
什么是关系型数据库？什么是对象数据库
> 关系型数据库和对象数据库是两种不同的数据存储与管理模型，它们在设计理念、数据结构和适用场景上存在显著差异。以下是两者的详细解析：

```
📊 1. 关系型数据库（Relational Database, RDB）
核心概念
关系型数据库基于关系模型（由E. F. Codd于1970年提出），数据以二维表格形式组织。每个表由行（记录）和列（字段）构成，表之间通过主键（Primary Key） 和外键（Foreign Key） 建立关联。

核心特点
结构化存储：数据需预先定义表结构（Schema），包括字段名称、数据类型和约束（如唯一性、非空等）。  

SQL操作：使用结构化查询语言（SQL）进行数据操作（增删改查），支持复杂查询（如多表连接、聚合函数）。  

ACID事务：保证数据的原子性、一致性、隔离性、持久性，适合对数据一致性要求高的场景（如金融交易）。  

数据完整性：通过主键、外键、唯一约束等确保数据的逻辑正确性。  

典型代表

Oracle、MySQL、SQL Server、PostgreSQL。

优缺点
优点：成熟稳定、支持复杂查询、数据一致性强。  

缺点：扩展性有限（需垂直扩展或分库分表）、难以直接存储复杂数据类型（如嵌套结构）。

🧩 2. 对象数据库（Object Database, OODB）

核心概念

对象数据库以对象为基本存储单元，每个对象包含属性（数据） 和方法（操作），支持面向对象特性（如类、继承、封装、多态）。数据模型与编程语言（如Java、C++）的对象模型一致，无需ORM转换。

核心特点
直接存储对象：支持复杂数据类型（如数组、集合、嵌套对象），无需拆分为多表。  

面向对象操作：通过对象查询语言（OQL） 或编程语言原生语法访问数据。  

继承与多态：类可继承父类属性和方法，实现数据模型的灵活扩展。  

高性能访问：通过对象指针直接导航关联数据，避免多表连接。  

典型代表

ObjectDB（商业）、db4o（开源）、Versant。

优缺点
优点：  

天然支持复杂数据，适合图形、多媒体等场景。  

开发效率高（减少对象-关系映射代码）。  

水平扩展性较好（分布式架构）。  

缺点：  

查询优化弱于SQL，学习曲线陡峭。  

事务处理成熟度不及关系数据库。

⚖️ 3. 关键对比（关系型数据库 vs 对象数据库）
维度         关系型数据库 对象数据库

数据模型 二维表、行/列结构 对象、类/继承结构
查询语言 SQL（标准化、强大） OQL或原生语言（灵活但小众）
扩展性 垂直扩展为主 水平扩展更优
适用场景 金融、ERP等高一致性系统 游戏引擎、CAD、实时分析
复杂数据处理 需拆分多表，效率低 直接存储，高效

🧠 4. 如何选择？
选关系型数据库：  

  需强事务保证、复杂查询分析、结构化数据为主（如报表系统）。  
选对象数据库：  

  业务模型高度对象化、频繁操作复杂嵌套数据、追求开发效率（如内容管理系统）。  
💡 混合方案：现代数据库（如PostgreSQL）支持JSON类型或扩展（如ORDBMS），可兼顾关系模型与对象灵活性。

💎 总结

关系型数据库以结构化和强一致性见长，对象数据库以自然映射对象模型取胜。二者并非替代关系，而是互补工具。实际选型需结合数据复杂度、性能需求及开发成本综合权衡。


```
### EFCore和其他ORM比较

|          |                            EFCore                            |              Dapper              |
| -------- | :----------------------------------------------------------: | :------------------------------: |
| 优点     | 1、功能强大 2、官方支持 3、生产效率高 4、力求屏蔽底层数据库差异 |        简单，行为可预期强        |
| 缺点     |                        复杂上手门槛高                        | 生产效率低需要处理底层数据库差异 |
| 开发思想 |                   模型驱动（Model-Driven）                   |         DataBase-Driven          |

### EFCore和EF对比

1、EF有DB First、Model First、CodeFirst。EFCore不支持模型优先，推荐使用代码优先，遗留系统可以使用Scaffold-DbContext来生成代码实现类似DBFirst的效果，但是推荐Code First

2、EF会对实体标注做效验，EFCore追求轻量化，不效验

## 搭建EFCore开发环境

### 用什么数据库？（需要满足有EFCoreProvider和ADO.NET Core provider）

* EFCore底层是对ADO.NET Core的封装，ADO.NET Core支持的EFCore不一定支持
* EFCore支持所有主流数据库，包括SQL Server、Oracle、MySQL、PostgreSQL、SQLite等可以自己实现provider来提供新的数据库支持
* 对于SQL Server支持最完美，MySQL、PostgreSQL也不错

### ###  搭建EFCore的开发环境

> 建实体（Entity）类→建配置(Config)类→建DbContext→生成数据库

#### 约定大于配置

1、新建控制台项目

2、创建Book实体类

```c#
    internal class Book
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public DateTime PubTime { get; set; }

        public double Price { get; set; }


    }
```

3、创建book配置类BookConfig并实现IEntityTypeConfiguration<Book>这个泛型接口

约定

> 　１、实体属性名是字段名
>
> ​	２、数据库字段类型根据实体的去推断

```c#
    internal class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("T_Books");
        }


    }
```



４、创建继承自DdContext类

```c#
    internal class TestDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = . ;Database = EFCore6.14;Trusted_Connection = true;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
```

#### 数据库迁移

##### Add-Migration命令

需要安装EntityFrameworkCoreTool

##### Update-database

使用上面的指令数据库才会创建相应的库表，注意：如果迁移的时候出现这个报错A connection was successfully established with the server, but then an error occurred during the login process. (provider: SSL Provider, error: 0 - 证书链是由不受信任的颁发机构颁发的。)需要加上TrustServerCertificate=true;

#### 修改表结构

在Book实体类中加上 public string Author { get; set; }作者→Add-Migration AddAuthorAtBook→ Update-database

设置标题不可为空并且最大长度为50，设置作者不可为空并且最大长度为20

> ```c#
>         builder.Property(b => b.Title).HasMaxLength(50).IsRequired();
>         builder.Property(b => b.Author).HasMaxLength(20).IsRequired();
> ```

Add-Migration FixBookConfig→ Update-database

## EFCore实现数据的增删改查

### 插入数据

```c#
        static void Main(string[] args)
        {
            //ctx是逻辑数据库
            using TestDbContext ctx = new TestDbContext();
            Book book = new Book();
            book.Title = "C# 9.0 in a Nutshell";
            book.Author = "Joseph Albahari";
            book.Price = 100;
            book.PubTime = new DateTime(2020, 1, 1);
            //把book对象添加到逻辑数据库中(内存中)
            ctx.Books.Add(book);
            ctx.SaveChanges();
        }
```

在查询前有个问题：为什么EFCore可以使用Linq查询

> 因为Dbset实现了IEnumerable接口

### 查询价格在80以上的书

```c#
var books = ctx.Books.Where(b => b.Price > 80);
foreach (var item in books)
{
    Console.WriteLine($"{item.Title}");
}
```

### 修改 ：修改标题为C# 9.0 in a Nutshell的书价格为120元

```c#
 var book = ctx.Books.Where(b => b.Title == "C# 9.0 in a Nutshell");
 foreach (var item in book)
 {
     item.Price = 120;
 }
 ctx.SaveChanges();
```

### 删除 删除作者是Jos2的书

```C#
var b = ctx.Books.Where(b => b.Author == "Jos2");
ctx.Books.RemoveRange(b);
ctx.SaveChanges();
```

### 批量的修改和删除

没试过先留个白

## EFCore实体的配置

### 约定配置

主要配置

1、表名采用DbContext中对应的DbSet的属性名

2、数据表列的名字采用实体类属性的名字，列的数据类型采用和实体类属性类型兼容的类型

3、数据表列的可空性取决于对应实体类属性的可空性

4、名字为Id的属性为主键，如果主键为short,int或者long类型，则默认采用自增字段，如果主键为Guid类型，则默认采用默认的Guid生成机制来生成主键

### 两种配置方式

1、Data Annotation

把配置以特性（Annotation）的形式注在实体类中

如: [Table("T_Books")]

优点：简单，

缺点：耦合

2、FluentAPI（流畅）

builder.ToTable("T_Books");

把配置写到单独的配置类中

优点：解耦

缺点：复杂

### Fluent API

1、视图和实体类的映射：

> modelBuilder.Entity<Blog>().ToView("blogsView");

2、排除属性映射：

> modelBuilder.Entity<Blog>().lgnore(b => b.Name2);

3、配置列名：

> modelBuilder.Entity<Blog>().Property(b => b.BlogId).HasColumnName("blog_id");

4、配置列数据类型

> builder.Property(e => e.Title).HasColumnType("varchar(200)");

5、配置主键

> 默认把名字为Id或者实体类型+Id的属性作为主键，可以使用HasKey()来配置其他属性为主键
>
> modelBuilder.Entity<Student>().HasKey(c => c.Number);

6、生成列的值

> modelBuilder.Entity<Student>().Property(b => b.Number).ValueGeneratedOnAdd();

7、可以用HasDefaultValue()为属性设置默认值

> modelBuilder.Entity<Student>().Property(b => b.Age).HasDefault(6);

8、索引

> modelBuilder.Entity<Blog>().HasIndex(b => b.Url)

复合索引

> modeBuilder.Entity<Person>().HasIndex(p => new {p.FirstName,p.LastName});

唯一索引：IsUnique(); 聚集索引：IsClustered()

## Fluent API

### Fluent API众多方法

Fluent API中有多个重载方法比如：HasIndex,Property

把Number列作为索引以下两种方法都可以

builder.HasIndex("Number");

bulider.HasIndex(b => b.Number); 推荐使用这种可以使用c#的强类型检查机制

## 主键

1、EFCore支持多种主键生成策略：自动增长；Guid;Hi/Lo算法

2、自动增长

优点：简单

缺点：数据库迁移以及分布式系统中比较麻烦；并发性能差。

long，int类型的主键默认自增。因为是数据库生成的值，所以SaveChanges后会自动把主键的值更新到Id属性

3、自增字段的代码中不能为Id属性赋值，必须保持默认值0，否则运行的时候会报错

### Guid主键（Guid算法，全球唯一）

1、Guid算法（UUID算法）生成一个全球唯一的Id,适合于分布式系统，在进行多数据库数据合并的时候很简单。

优点：简单

缺点：磁盘空间占用大

2、Guid值不连续。使用Guid类型做主键的时候不能把主键设置为聚集索引。因为聚集索引是按照顺序保存主键的，因此使用Guid做主键性能差。比如Mysql的InnoDB引擎中主键是强制使用聚集索引的；有的数据库支持部分连续的Guid比如SQLServer中的NewSequentialId(),但也不能解决问题。在SQL Server等数据库中，不要把Guid主键设置成聚集索引；在MySQL中，插入频繁的表不要用Guid做主键

### 其他方案

1、混合自增和Guid（非复合主键）。用自增列做物理的主键，用Guid做逻辑上的主键。把自增列设置为表的主键，在业务上查询数据时把Guid当主键使用。在和其他表关联以及和外部系统通讯的时候（比如前端显示数据的标识的时候）都是用Guid列，不仅保证了性能，而且利用了Guid的优点，而且减轻了主键自增性导致主键值可能被预测的安全性问题

2、Hi/Lo算法;EFCore支持HI/Lo算法来优化自增列，主键值主要由两部分组成：高位（Hi）和低位（Lo）高位由数据库生成，两个高位之间间隔若干个值

## EFCore Migrations

1、向上迁移（Up）：对当前连接的数据库执行编号更高的迁移

2、向下迁移（Down）:把数据库回退到旧的迁移

> 非必要不要删除修改Migrations文件夹下的文件

## EFCore 数据库迁移其他命令

1、Add-Migration+迁移名称  :创建数据库迁移脚本

2、Update-Database :更新应用数据库迁移到数据库

3、Update-Database XXX :把数据库回滚到某种状态，迁移脚本不动

4、Remove-migration:删除最后一次迁移

5、Script-Migration:生成迁移的SQL代码  

有了Update-Database为什么还要生成SQL脚本 

>  ：答案是可以生成版本D到版本F的SQL脚本;
>
> Script-Migration D F
>
> 生成版本D到最新版本的SQL脚本：
>
> Script-Migration D

## EFCore的反向工程

> 反向工程：根据数据库表来反向生成实体类
>
> Scaffold-DbContext '连接字符串' Microsoft.EntityFrameworkCore.SqlServer

反向工程生成的实体类可能不可以直接使用

## EFCore底层是如何操作数据

> 通过Ado.net Core 把C#语句转换成SQL语句

## 什么是EFCore做不到的

### 为什么会存在EFCore做不到的情况

> C#千变万化；SQL功能简单。存在合法的C#语句无法被翻译成SQL的情况

## 通过代码查看EFCore的SQL语句

可以通过SQL Server Profiler来查看

### 第一种方法：标准日志

### 第二种方法：简单日志

在DbContext类中的OnConfiguring方法中

> optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

### 第三种方法：ToQueryString

> 1、上面两种方法无法得到一个操作的SQL语句，而且在操作很多的情况下容易混乱
>
> 2、EFCore的Where 方法返回的是IQueryable类型，DbSet也实现了IQueryable接口，IQueryable有扩展方法ToQueryString可以获取SQL
>
> 3、不需要真的执行查询才获取SQL；只能获取查询操作的

> 写测试性代码用简单日志，
>
> 正式需要记录SQL给审核人员或者排查故障，用标准日志
>
> 开发阶段，从繁杂的查询操作中立即看到SQL，使用ToQueryString(),只有查询的可以看

## 同样的LINQ被翻译成不同的SQL

> 不同的数据库方言不同
>
> SQL Server:Select top(3) * from t
>
> MySQL：select * from t LIMIT 3
>
> Oracle: select * from t where ROWNUM <=3

## EFCore 一对多的配置

新建控制台项目→新建文章类和评论类

```C#
    internal class Article
    {
        public long Id { get; set; }

        public string Title { get; set; }
        public string Message { get; set; }

        public List<Comment>  Comments{ get; set; } = new List<Comment>();
    }
```



```C#
    internal class Comment
    {
        public long Id { get; set; }

        public  string  Message { get; set; }

        public Article Article { get; set; }
    }
```

### 关系配置

EFCore中实体之间关系的配置

HasXXX(...).WithXXX(...);

有XXX、反之带有XXX

XXX可选One，Many

> 一对多：HasOne(...).WithMany(...);
>
> 一对一：HasOne(...).WithOne(...);
>
> 多对多：HasMany(...).With(...);

 #### 一对多：

> 案例：一篇文章对应多个评论，每个评论只对应一篇文章

```c#
 internal class Article
 {
     public long Id { get; set; }

     public string Title { get; set; }
     public string Message { get; set; }

     public List<Comment>  Comments{ get; set; } = new List<Comment>();
 }
```



```c#
internal class Comment
{
    public long Id { get; set; }

    public  string  Message { get; set; }

    public Article Article { get; set; }
}
```

```c#
 internal class ArticleConfig : IEntityTypeConfiguration<Article>
 {
     void IEntityTypeConfiguration<Article>.Configure(EntityTypeBuilder<Article> builder)
     {
         builder.ToTable("T_Articles");
         builder.Property(a => a.Title).HasMaxLength(255).IsUnicode().IsRequired();
         builder.Property(a => a.Message).IsUnicode().IsRequired();
     }
 }c
```

```c#
internal class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("T_Comments");
        builder.HasOne<Article>(c => c.Article).WithMany(a => a.Comments).IsRequired();
        builder.Property(c => c.Message).IsRequired().IsUnicode();
    }

    
}
```

##### 插入数据

```C#
using (MyDbContext dbContext = new MyDbContext())
{

    Article article = new Article();
    article.Title = "文章标题";
    article.Message = "文章内容";

    Comment comment1 = new Comment();
    comment1.Message = "评论1";
    Comment comment2 = new Comment();
    comment2.Message = "评论2";

    article.Comments.Add(comment1);
    article.Comments.Add(comment2);

    dbContext.Article.Add(article);
    dbContext.SaveChanges();

}
```

## 一对多关系的数据的获取（关联查询）

### 查询文章id为1008的文章标题和所有评论 

```c#
 #region 查询文章id为1008的文章标题和所有评论
 try
 {
     using (MyDbContext dbContext = new MyDbContext())
     {
         var ac = dbContext.Article.Include(a => a.Comments).Single(a => a.Id == 1008);
         Console.WriteLine(ac.Title);
         foreach (var item in ac.Comments)
         {
             Console.WriteLine(item.Id + ":" + item.Message);
         }
     }
 }
 catch (Exception ex)
 {

     Console.WriteLine(ex.Message);
 }

 #endregion
```

### ### 查询id为115的评论所在的文章标题

```c#
  try
  {
      using (MyDbContext dbContext = new MyDbContext())
      {
          var t =dbContext.Comment.Include(c => c.Article).Single(c => c.Id == 115);
          Console.WriteLine(t.Message);
          Console.WriteLine(t.Article.Title);
      }
  }
  catch (Exception ex)
  {

      Console.WriteLine(ex);
  }
```

## EFCore额外的外键字段

### 为什么需要外键属性

1、EFCore会在数据表建外键列

2、如果需要获取外键列的值就需要做关联查询，效率低

3、需要一种不需要join直接获取外键列值的方式

### 设置外键属性

1、在实体类中显示的声明一个外键属性

2、关系配置中通过HasForeignKey(c=>c.Articleid)指定这个属性为外键

3、除非必要否则不用声明因为会引入重复

## EFCore单向导航属性

> 不设置反向的属性，然后配置的时候WithMany()不设置参数

## EFCore关系配置在任何一方都可以

