# 1、创建webapi的项目
# 2、在appsetting.json中编写配置文件，配置文件如下：
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ModbusTCPConfig": {
    "ProxyName": "Test",
    "IP": "127.0.0.1",
    "Port": 502,
    "SlaveID": 3,
    "FunctionCode": 1,
    "StartAddress": 1000,
    "Num": 5
  },
  "AllowedHosts": "*"
}
```
# 3、创建Model文件夹在Model文件夹下面新建ModbusTCPConfig类在里面编写和配置文件相对应的属性
代码如下：
```
namespace ModbusTcpAPI.Controllers
{
    public class ModbusTCPConfig
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string? ProxyName { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
        public byte SlaveID { get; set; }

        /// <summary>
        /// 功能码
        /// </summary>
        public byte FunctionCode { get; set; }


        /// <summary>
        /// 变量地址
        /// </summary>
        public ushort StartAddress { get; set; }

        /// <summary>
        /// 个数
        /// </summary>
        public ushort Num { get; set; }

    }
}
```
# 4、新建DomainServer文件夹在文件夹下新建ModbusTCPServer类
代码如下：
```
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ModbusTcpAPI.Controllers;
using NModbus;
using System.Net.Sockets;

namespace ModbusTcpAPI.domainServer
{
    public class ModbusTCPServer
    {
        private readonly ModbusTCPConfig _modbusConfig;

        public ModbusTCPServer(IOptions<ModbusTCPConfig> modbusConfig)
        {
            _modbusConfig = modbusConfig.Value;
        }

        /// <summary>
        /// 读取保持寄存器
        /// </summary>
        /// <returns></returns>
        public async Task<ushort[]> ReadHoldingRegisters()
        {
            using (var client = new TcpClient(_modbusConfig.IP, _modbusConfig.Port))
            {
                var factory = new ModbusFactory();
                var master = factory.CreateMaster(client);

                ushort startAddress = _modbusConfig.StartAddress;
                ushort numRegisters = _modbusConfig.Num; // 读取的寄存器数量

                var registers = await master.ReadHoldingRegistersAsync(_modbusConfig.SlaveID, startAddress, numRegisters);
                return registers;
            }
        }

        /// <summary>
        /// 写入保持寄存器
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> WriteSingleRegister( ushort value)
        {
            using (var client = new TcpClient(_modbusConfig.IP, _modbusConfig.Port))
            {
                var factory = new ModbusFactory();
                var master = factory.CreateMaster(client);

                ushort startAddress = _modbusConfig.StartAddress;

                await  master.WriteSingleRegisterAsync(_modbusConfig.SlaveID, startAddress, value);
                return true;
            }
        }
    }
}
```
# 5、在控制器文件夹下新建ModbusTCPController代码如下
```
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ModbusTcpAPI.domainServer;
using NModbus;
using System.Net.Sockets;

namespace ModbusTcpAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ModbusTCPController : ControllerBase
    {
        private readonly ModbusTCPConfig _modbusConfig;
        private readonly ModbusTCPServer _modbusTCPServer;
        private readonly ILogger<ModbusTCPController> _logger;

        public ModbusTCPController(IOptions<ModbusTCPConfig> modbusConfig, ModbusTCPServer modbusTCPServer, ILogger<ModbusTCPController> logger)
        {
            _modbusConfig = modbusConfig.Value;
            _modbusTCPServer = modbusTCPServer;
            _logger = logger;
        }

        /// <summary>
        /// 测试是否可以读取到配置文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Test()
        {
            return _modbusConfig.IP;
        }

        /// <summary>
        /// 读取保持寄存器
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ReadHoldingRegisters()
        {

            var result = await _modbusTCPServer.ReadHoldingRegisters();
            foreach (var item in result)
            {
                _logger.LogInformation(item.ToString());
            }
            return Ok(result);

        }



        /// <summary>
        /// 写入保持寄存器
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> WriteSingleRegister([FromBody] ushort value)
        {
            var result = await _modbusTCPServer.WriteSingleRegister(value);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

```

# 测试
使用modbusslave配合测试在swaggerui页面调接口发现是可以获取到正确的数据的，但是这个服务最好可以不依赖与前端所以考虑使用BcakgroundService
# 补充:在DomainServer下新建ScheduledTaskService类代码如下
```
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class ScheduledTaskService : BackgroundService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly Uri _apiUrl;

    public ScheduledTaskService(IHttpClientFactory httpClientFactory, IServiceProvider serviceProvider)
    {
        _httpClientFactory = httpClientFactory;
        // 你可以从配置或DI中获取API的URL
        _apiUrl = new Uri("http://localhost:5057/api/ModbusTCP/ReadHoldingRegisters");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(_apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    // 处理结果
                }
            }
            catch (Exception ex)
            {
                // 日志记录异常
            }

            // 等待一段时间后再次执行
            await Task.Delay(TimeSpan.FromMilliseconds(1000), stoppingToken);
        }
    }
}
```
# 最后Program.cs代码如下：
```

using ModbusTcpAPI.Controllers;
using ModbusTcpAPI.domainServer;

namespace ModbusTcpAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 添加服务到容器
            builder.Services.Configure<ModbusTCPConfig>(builder.Configuration.GetSection("ModbusTCPConfig"));
            builder.Services.AddScoped<ModbusTCPServer>();

            // 注册HttpClientFactory
            builder.Services.AddHttpClient();

            // 注册后台服务
            builder.Services.AddHostedService<ScheduledTaskService>();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
```

# 单独的启动服务发现一秒更新一下数据