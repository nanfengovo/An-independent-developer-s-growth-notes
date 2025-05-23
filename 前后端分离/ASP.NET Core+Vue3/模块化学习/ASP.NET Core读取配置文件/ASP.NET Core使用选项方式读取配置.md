# 第一步 ：新建ASP.NET Core webapi项目

# 第二步：安装Microsoft.Extensions.Options和Microsoft.Extensions.Configuration.Binder
# 第三步：修改appsettings.json，内容如下：
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "DB": {
    "DbType": "SQLServer",
    "Connection": "Data Source = .Catalog=DemoDB; Integrated Security = true"
  },
  "Smtp": {
    "Server": "smtp.youzack.com",
    "UserName": "zack",
    "Password": "hello888",
  },
    "AllowedHosts": "*"
  }
```

# 第四步：由于我们只读取配置系统中“DB”和“Smtp”这两部分，建立对应的模型类，代码如下：
```
public class DbSettings
{
    public string? DbType { get; set; }
    public string? ConnectionString { get; set; }

}
```

```
 public class SmtpSettings
 {
     public string? Server { get; set; }
     public string? UserName { get; set; }
     public string? Password { get; set; }
 }
```

>由于使用选项方式读取配置的时候，需要和依赖注入一起使用，因此我们需要创建一个类用于获取注入的选项值。声明接收选项注入的对象的类型不能直接使用DbSettings、SmtpSettings，而要使用IOptions<T>、IOptionsMonitor<T>、IOptionsSnapshot<T>等泛型接口类型，因为它们可以帮我们处理容器生命周期、配置刷新等。它们的区别在于，IOptions<T>在配置改变后，我们不能读到新的值，必须重启程序才可以读到新的值；IOptionsMonitor<T>在配置改变后，我们能读到新的值；IOptionsSnapshot<T>也是在配置改变后，我们能读到新的值，和IOptionsMonitor<T>不同的是，在同一个范围内IOptionsMonitor<T>会保持一致性。

# 编写读取配置的Demo代码 如下：
```
 public class Demo
 {
     private readonly IOptionsSnapshot<DbSettings> optDbsettings;
     private readonly IOptionsSnapshot<SmtpSettings> optSmtpSettings;

     public Demo(IOptionsSnapshot<DbSettings> optDbsettings, IOptionsSnapshot<SmtpSettings> optSmtpSettings)
     {
         this.optDbsettings = optDbsettings;
         this.optSmtpSettings = optSmtpSettings;
     }


     public void Test()
     {
         var db = optDbsettings.Value;
         Console.WriteLine($"数据库：{db.DbType},{db.ConnectionString}");
         var smtp = optSmtpSettings.Value;
         Console.WriteLine($"smtp:{smtp.Server},{smtp.UserName},{smtp.Password}");
     }

 }
```

# 注册服务到容器
```
 var configurationBuilder = new ConfigurationBuilder();
 configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
 IConfigurationRoot config = configurationBuilder.Build();
 ServiceCollection services = new ServiceCollection();
 services.AddOptions().Configure<DbSettings>(e => config.GetSection("DB").Bind(e))
     .Configure<SmtpSettings>(e => config.GetSection("Smtp").Bind(e));
 services.AddTransient<Demo>();
 using (var sp = services.BuildServiceProvider())
 {
     while (true)
     {
         using (var scope = sp.CreateScope())
         {
             var spScope = scope.ServiceProvider;
             var demo = spScope.GetRequiredService<Demo>();
             demo.Test();
         }
         Console.WriteLine("可以修改配置了");
         Console.ReadKey();
     }
 }
```
# 代码解析

上面的代码中用到了依赖注入和JSON配置文件的读取，因此我们仍然需要安装Microsoft.Extensions.Configuration.Json、Microsoft.Extensions.DependencyInjection等NuGet包。

在第2行代码中，把方法的reloadOnChange参数设定为true，以启用“修改后重新加载配置”的功能；在第5行代码中，通过AddOptions方法注册与选项相关的服务，然后使用第6行代码把DB节点的内容绑定到DbSettings类型的模型对象上。

由于IOptionsSnapshot<T>的生命周期为“范围”，因此Demo这个用于读取配置的类的生命周期不能是单例，我们在第8行代码中把Demo注册为瞬态服务。

在第11行代码中建立了一个无限循环，这样就方便我们一直反复测试、修改配置文件。在第20行代码中，程序在每次循环结束后都用Console.ReadKey等待我们改完配置文件后回到程序按任意键来执行下次读取配置的代码。

由于IOptionsSnapshot<T>会在新的范围中加载新配置，因此在第13行代码中，在每次循环中都创建一个范围。
运行exe
![[assets/ASP.NET Core使用选项方式读取配置/file-20250308123308971.png]]

修改配置文件保存
![[assets/ASP.NET Core使用选项方式读取配置/file-20250308123433037.png]]
