# 参考视频（杨中科）：
>配置系统1-入门：
> https://www.bilibili.com/video/BV1pK41137He?vd_source=b7200d0eaee914e9c128dcabce5df118&p=40&spm_id_from=333.788.videopod.episodes
>配置系统2-选项方式读取：
>https://www.bilibili.com/video/BV1pK41137He?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=41
>配置系统3-其他配置提供者：
>https://www.bilibili.com/video/BV1pK41137He?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=42
>配置系统4-开发自己的配置提供者：
>https://www.bilibili.com/video/BV1pK41137He?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=43
>配置系统5-开发数据库配置提供者
>https://www.bilibili.com/video/BV1pK41137He?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=44
>配置系统6-多配置源的优先级
>https://www.bilibili.com/video/BV1pK41137He?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=45
>
# 参考资料：


![[Pasted image 20250306222746.png]]
# 实际使用
## 读取
### 新建控制台程序
### 添加测试用的配置文件，设置属性
![[Pasted image 20250306221416.png]]
###  安装Microsoft.Extensions.Configuration和Microsoft.Extensions.Configuration.Json
### 编写如下代码(这里我使用了顶级语句)：
```
// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;

ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("config.json", optional: false, reloadOnChange: false);
IConfigurationRoot configurationRoot = configurationBuilder.Build();
string name = configurationRoot["name"];
Console.WriteLine($"name = {name}");
string proxyAddress = configurationRoot.GetSection("proxy:address").Value;
Console.WriteLine($"address={proxyAddress}");
```
#### 运行代码查看结果:
![[Pasted image 20250306222647.png]]

#### 浅析代码：
>configurationBuilder.AddJsonFile("config.json", optional: false, reloadOnChange: false):
>* 添加了一个待解析的名为”config.json“的配置文件，
>* optional:表示这个文件是否可选，false意味着配置文件不存在时候会报错
>* reloadOnChange:表示如果文件修改了，是否重新加载配置

##### 测试上述的属性：
###### 1、config.json改为config1.json
![[Pasted image 20250306223350.png]]
###### 2、config.json改为config1.json && optional: true
![[Pasted image 20250306223520.png]]
###### 3、reloadOnChange: true
>需要修改代码持续的打印在控制台上，然后修改配置文件  修改的代码参考下面的;

```
// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;


await Task.Run(async () =>
{
    while (true)
    {
        ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonFile("config.json", optional: false, reloadOnChange: true);
        IConfigurationRoot configurationRoot = configurationBuilder.Build();
        string name = configurationRoot["name"];
        Console.WriteLine($"name = {name}");
        string proxyAddress = configurationRoot.GetSection("proxy:address").Value;
        Console.WriteLine($"address={proxyAddress}");
        await Task.Delay(2000);
    }
});
```
![[Pasted image 20250306224148.png]]
去修改配置文件
![[Pasted image 20250306224235.png]]
！！！==**发现并没有更新**==
###### 去看作者的视频发现：
![[Pasted image 20250306224847.png]]