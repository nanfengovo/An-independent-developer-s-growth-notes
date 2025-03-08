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
    "SlaveID": 1,
    "FunctionCode": 1,
    "Address": 1000
  }
  "AllowedHosts": "*"
}
```
# 3、