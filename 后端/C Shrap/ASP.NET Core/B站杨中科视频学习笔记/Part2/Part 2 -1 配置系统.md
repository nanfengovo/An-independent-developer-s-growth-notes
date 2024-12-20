# 配置系统-1 入门 
https://www.bilibili.com/video/BV1pK41137He?spm_id_from=333.788.videopod.episodes&vd_source=b7200d0eaee914e9c128dcabce5df118&p=40

 * .NET中的配置系统支持丰富的配置源，包括文件（jaon、xml、ini等）、注册表、环境变量、命令行、Azure Key Vailt等，还可以配置自定义配置源。可以跟踪配置的改变，可以按照优先级覆盖。
## Json文件配置
1、创建一个json文件，文件名随意，比如config.json，*设置文件属性*为“如果较新则复制”
2、NuGet安装Microsoft.Extensions.Configuration 和 Microsoft.Extensions.Configuration.Json
		Microsoft.Extensions.Configuration:配置框架的包
		 Microsoft.Extensions.Configuration.Json：读json文件的包
3、编写代码使用最简单的方式读取配置文件
### 1、直接读取：
config.json:
```json
{  
  "name": "yzk",  
  "age": 18,  
  "proxy": {"address": "aa"}  
}
```


```c#
ConfigurationBuilder configBuilder = new ConfigurationBuilder();  
configBuilder.AddJsonFile("config.json",optional: true, reloadOnChange: true);  
IConfigurationRoot configRoot  = configBuilder.Build();  
string name = configRoot["name"];  
Console.WriteLine("name:"+name);  
string age = configRoot["age"];  
Console.WriteLine("age:"+age);  
string address = configRoot.GetSection("proxy:address").Value;  
Console.WriteLine("address:"+address);
```
输出：
>name:yzk
age:18
address:aa
### 2、绑定读取配置
	1、可以绑定一个类，自动完成配置的读取。
	 2、NuGet安装:Microsoft.Extensions.Configuration.Binder
	 3、Server server = configRoot.GetSection("proxy").Get<Server>();

config.json
```json
{  
  "name": "yzk",  
  "age": 18,  
  "proxy": {"address": "aa","port": 80}  
}
```

#### 第一种方法：绑定类读取 (类：要读取的配置文件的类)
Proxy.cs
```c#
public class Proxy  
{  
    public string Address { get; set; }  
      
    public int Port { get; set; }  
}
```
读取：
```c#
ConfigurationBuilder configBuilder = new ConfigurationBuilder();  
configBuilder.AddJsonFile("config.json",optional: true, reloadOnChange: true);  
IConfigurationRoot configRoot  = configBuilder.Build();
Proxy proxy = configRoot.GetSection("Proxy").Get<Proxy>();  
Console.WriteLine($"{proxy.Address}, {proxy.Port}");
```
输出：
>aa, 80


#### 第二种方法: 绑定类读取（整体）

config.json
```json
{  
  "name": "yzk",  
  "age": 18,  
  "proxy": {"address": "aa","port": 80}  
}
```
Config.cs'
```c#
public class Config  
{  
    public string Name {get;set;}  
      
    public int Age {get;set;}  
      
    public Proxy Proxy {get;set;}  
}
```
读取
```c#
ConfigurationBuilder configBuilder = new ConfigurationBuilder();  
configBuilder.AddJsonFile("config.json",optional: true, reloadOnChange: true);  
IConfigurationRoot configRoot  = configBuilder.Build();
Config config = configRoot.Get<Config>();  
Console.WriteLine(config.Name);  
Console.WriteLine(config.Age);  
Console.WriteLine(config.Proxy.Address);  
Console.WriteLine(config.Proxy.Port);
```
输出：
>yzk
18
aa
80
# 配置系统-2  选项方式读取配置
https://www.bilibili.com/video/BV1pK41137He?spm_id_from=333.788.videopod.episodes&vd_source=b7200d0eaee914e9c128dcabce5df118&p=41

1、推荐使用选项方式读取，和DI结合更好，且更好利用“reloadonchange”机制。
2、NuGet 安装：Microsoft.Extensions.Options、Microsoft.Extensions.Configuration.Binder,Microsoft.Extensions.Configuration、Microsoft.Extensions.Configuration.Json.
3、读取配置时，DI要声明IOptions<T>、IOptionsMonitor<T>、IOptionsSnapshot<T>等类型。IOptions<T>不会读取到新的值；和IOptionsMonitor相比，**IOptionsSnapshot会在同一范围内（比如ASP.NET Core一个请求中）保持一致。建议使用IOptionsSnapshot.**

1、在读取配置的地方，用IOptionsSnapshot<T>注入。不要在构造函数中直接读取IOptionsSnapshot.Value,而是在用到的地方再读取，否则就无法更新变化
2、如下配置
services.AddOptions()
	 .Configure<DbSettings>(e=>
	 config.GetSection("DB").Bind(e))
		 .Configure<SmtpSettings>(e=>
		 config.GetSection("Smtp").Bind(e));
		 services.AddTransient<Demo>();//不能用Singleton

