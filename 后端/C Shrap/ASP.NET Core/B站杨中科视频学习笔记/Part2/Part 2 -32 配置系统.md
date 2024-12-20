https://www.bilibili.com/video/BV1pK41137He?spm_id_from=333.788.videopod.episodes&vd_source=b7200d0eaee914e9c128dcabce5df118&p=40

 * .NET中的配置系统支持丰富的配置源，包括文件（jaon、xml、ini等）、注册表、环境变量、命令行、Azure Key Vailt等，还可以配置自定义配置源。可以跟踪配置的改变，可以按照优先级覆盖。
# Json文件配置
1、创建一个json文件，文件名随意，比如config.json，*设置文件属性*为“如果较新则复制”
2、NuGet安装Microsoft.Extensions.Configuration 和 Microsoft.Extensions.Configuration.Json
		Microsoft.Extensions.Configuration:配置框架的包
		 Microsoft.Extensions.Configuration.Json：读json文件的包
3、编写代码使用最简单的方式读取配置文件
