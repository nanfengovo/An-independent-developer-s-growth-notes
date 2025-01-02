---
created: 2025-01-01T14:49:56 (UTC +08:00)
tags: []
source: https://github.com/S7NetPlus/s7netplus/wiki
author: 
---

# 主页 · S7NetPlus/s7netplus 维基

> ## Excerpt
> S7.NET+ -- A .NET library to connect to Siemens Step7 devices - S7NetPlus/s7netplus

---
## S7.Net 文档

## 如何下载 s7.Net

官方存储库在 GitHub（[https://github.com/killnine/s7netplus](https://github.com/killnine/s7netplus)），您也可以直接从 NuGet（[https://www.nuget.org/packages/S7netplus/](https://www.nuget.org/packages/S7netplus/)）下载该库。

## 什么是S7.Net

S7.Net 是一个仅适用于西门子 PLC 且仅支持以太网连接的 PLC 驱动程序。这意味着您的 PLC 必须具有 Profinet CPU 或 Profinet 外部卡（CPxxx 卡）。S7.Net 完全用 C# 编写，因此您可以轻松地对其进行调试，而无需通过本机 dll。

## 支持PLC

S7.Net 与 S7-200、S7-300、S7-400、S7-1200、S7-1500 兼容。  

## 开始使用 S7.Net

要开始使用 S7.Net，您必须下载并将 S7.Net.dll 包含在您的项目中。您可以通过下载 NuGet 包或下载源代码并编译它们来执行此操作。

## 创建 PLC 实例、连接和断开连接

要创建驱动程序的实例，您需要使用此构造函数：

```cs
public Plc(CpuType cpu, string ip, Int16 rack, Int16 slot)
```

-   **cpu**：指定您要连接的 CPU。支持的 CPU 包括：

```cs
public enum CpuType {
    S7200 = 0,
    S7300 = 10,
    S7400 = 20,
    S71200 = 30,
    S71500 = 40,
}
```

-   **ip**：指定 CPU 或外部以太网卡的 IP 地址
-   **机架**：包含 plc 的机架，您可以在 Step7 的硬件配置中找到它
-   **插槽**：这是 CPU 的插槽，您可以在 Step7 的硬件配置中找到它

例子：

此代码为 IP 地址为 127.0.0.1 的 S7-300 plc 创建一个 Plc 对象，该 plc 位于机架 0 中，CPU 位于插槽 2 中：

```cs
Plc plc = new Plc(CpuType.S7300, "127.0.0.1", 0, 2);
```

## 连接到 PLC

例如这行代码打开连接：

## 断开与 PLC 的连接

例如这将关闭连接：

## 错误处理

任何方法都可能导致`PlcException`各种错误。您应该实施适当的错误处理。`PlcException`提供`ErrorCode`适当的错误消息。

错误类型如下：

```cs
public enum ErrorCode
{
    NoError = 0,
    WrongCPU_Type = 1,
    ConnectionError = 2,
    IPAddressNotAvailable, 
    WrongVarFormat = 10,
    WrongNumberReceivedBytes = 11, 
    SendData = 20,
    ReadData = 30, 
    WriteData = 50
}
```

## 检查 PLC 可用性

要检查 plc 是否可用（打开套接字），您可以使用该属性

当您检查此属性时，驱动程序将尝试连接到 plc，如果可以连接则返回 true，否则返回 false。

## 检查 PLC 连接

检查 plc 连接很简单，因为您必须检查 PC 插座是否已连接，还要检查 PLC 是否仍连接在插座的另一端。在这种情况下，您必须检查的属性是：

调用方法 Open() 并且结果成功后，可以检查此属性以检查连接是否仍然有效。

## 读取字节/写入字节

该库提供了几种读取变量的方法。最基本和最常用的是 ReadBytes。

```cs
public byte[] ReadBytes(DataType dataType, int db, int startByteAdr, int count)

public void WriteBytes(DataType dataType, int db, int startByteAdr, byte[] value)
```

这将从给定的内存位置读取您指定的所有字节。如果字节数超过单个请求中可以传输的最大字节数，则此方法会自动处理多个请求。

-   **dataType**：你必须使用枚举 DataType 指定内存位置

```cs
public enum DataType
{
    Input = 129,
    Output = 130,
    Memory = 131,
    DataBlock = 132,
    Timer = 29,
    Counter = 28
}
```

-   **db**：数据类型的地址，比如要读取DB1，则该字段为“1”；如果要读取T45，则该字段为45。
-   **startByteAdr**：您要读取的第一个字节的地址，例如如果您要读取DB1.DBW200，那么这就是200。
-   **count**：包含您要读取的字节数。
-   **value\[ \]**：要从 plc 读取的字节数组。

例如：此方法读取 DB1 的前 200 个字节：

```cs
var bytes = plc.ReadBytes(DataType.DataBlock, 1, 0, 200);
```

## 读取并解码 / 写入解码

此方法允许根据提供的 varType 读取并接收已解码的结果。如果您读取多个相同类型的字段（例如 20 个连续的 DBW），这将非常有用。如果您指定 VarType.Byte，它具有与 ReadBytes 相同的功能。

```cs
public object Read(DataType dataType, int db, int startByteAdr, VarType varType, int varCount)

public void Write(DataType dataType, int db, int startByteAdr, object value)
```

-   **dataType**：你必须使用枚举 DataType 指定内存位置

```cs
public enum DataType
{
    Input = 129,
    Output = 130,
    Memory = 131,
    DataBlock = 132,
    Timer = 29,
    Counter = 28
}
```

-   **db**：数据类型的地址，比如要读取DB1，则该字段为“1”；如果要读取T45，则该字段为45。
-   **startByteAdr**：您要读取的第一个字节的地址，例如如果您要读取DB1.DBW200，那么这就是200。
-   **varType**：指定您想要转换的字节数据。

```cs
public enum VarType
{
    Bit,
    Byte,
    Word,
    DWord,
    Int,
    DInt,
    Real,
    String,
    StringEx,
    Timer,
    Counter
}
```

-   **count**：包含您想要读取的变量数。
-   **value**：要写入 plc 的值数组。它可以是单个值或数组，只需记住类型是唯一的（例如 double 数组、int 数组、short 数组等）。

例如：此方法读取 DB1 的前 20 个双字：

```cs
var dwords = plc.Read(DataType.DataBlock, 1, 0, VarType.DWord, 20);
```

## 读取单个变量/写入单个变量

此方法通过解析字符串并返回正确结果从 plc 读取单个变量。虽然这是最容易上手的方法，但效率很低，因为驱动程序会为每个变量发送一个 TCP 请求。

```cs
public object Read(string variable)

public void Write(string variable, object value)
```

-   **变量**：使用字符串指定要读取的变量，如“DB1.DBW20”，“T45”，“C21”，“DB1.DBD400”等。

示例：读取变量 DB1.DBW0。必须将结果转换为 ushort 才能在 C# 中获取正确的 16 位格式。

```cs
ushort result = (ushort)plc.Read("DB1.DBW0");
```

## 读取结构体 / 写入结构体

此方法从指定的 DB 中读取填充 C# 结构所需的所有字节，并返回包含值的结构。当您想在某个连续内存范围内读取单个数据块中的许多变量时，建议使用此方法。

“读取结构”和“写入结构”方法不支持字符串。

```cs
public object ReadStruct(Type structType, int db, int startByteAdr = 0)

public void WriteStruct(object structValue, int db, int startByteAdr = 0)
```

-   **structType**：要读取的结构体类型，例如：typeOf(MyStruct))
-   **db**：要读取的数据库的索引
-   **startByteAdr**：指定要读取的字节的首地址（默认为零）。

示例：在 plc 中定义一个 DataBlock，如下所示：

![结构](https://github.com/killnine/s7netplus/raw/master/Documentation/struct.png)

然后在您的.Net 应用程序中添加一个类似于 plc 中的 DB 的结构：

```cs
public struct testStruct
{
    public bool varBool0;
    public bool varBool1;
    public bool varBool2;
    public bool varBool3;
    public bool varBool4;
    public bool varBool5;
    public bool varBool6;
    public byte varByte0;
    public byte varByte1;
    public ushort varWord0;
    public float varReal0;
    public bool varBool7;
    public float varReal1;
    public byte varByte2;
    public UInt32 varDWord;
}
```

然后添加代码来读取或写入完整的结构

```cs
// reads a struct from DataBlock 1 at StartAddress 0
testStruct myTestStruct = (testStruct) plc.ReadStruct(typeof(testStruct), 1, 0);
```

## 读一门课/写一门课

此方法从指定的 DB 中读取填充 C# 中的类所需的所有字节。该类作为引用传递，并使用反射分配值。当您想要在某个连续内存范围内的单个数据块中读取许多变量时，建议使用此方法。

“读取类”和“写入类”方法不支持字符串。

```cs
public void ReadClass(object sourceClass, int db, int startByteAdr = 0)

public void WriteClass(object classValue, int db, int startByteAdr = 0)
```

-   **sourceClass**：要分配值的类的实例
-   **db**：要读取的数据库的索引
-   **startByteAdr**：指定要读取的字节的第一个地址（默认为零）。示例：在 plc 中定义一个 DataBlock，如下所示：

![结构](https://github.com/killnine/s7netplus/raw/master/Documentation/struct.png)

然后在您的.Net 应用程序中添加一个类似于 plc 中的 DB 的结构：

```cs
public class TestClass
{
    public bool varBool0 { get; set;}
    public bool varBool1 { get; set;}
    public bool varBool2 { get; set;}
    public bool varBool3 { get; set;}
    public bool varBool4 { get; set;}
    public bool varBool5 { get; set;}
    public bool varBool6 { get; set;}

    public byte varByte0 { get; set;}
    public byte varByte1 { get; set;}

    public ushort varWord0 { get; set;}

    public float varReal0 { get; set;}
    public bool varBool7 { get; set;}
    public float varReal1 { get; set;}

    public byte varByte2 { get; set;}
    public UInt32 varDWord { get; set;}
}
```

然后添加代码来读取或写入完整的类

```cs
// reads a class from DataBlock 1, startAddress 0
TestClass myTestClass = new TestClass();
plc.ReadClass(myTestClass, 1, 0);
```

## 读取多个变量

此方法在单个请求中读取多个变量。变量可以位于相同或不同的数据块中。

```cs
public void Plc.ReadMultibleVars(List<DataItem> dataItems);
```

-   **List<>**：你必须指定一个 DataItem 列表，其中包含要读取的所有数据项

示例：此方法从数据块中读取几个变量

首先定义数据项

```cs
private static DataItem varBit = new DataItem()
{
    DataType = DataType.DataBlock,
    VarType = VarType.Bit,
    DB = 83,
    BitAdr = 0,
    Count = 1,
    StartByteAdr = 0,
    Value = new object()
};

private static DataItem varByteArray = new DataItem()
{
    DataType = DataType.DataBlock,
    VarType = VarType.Byte,
    DB = 83,
    BitAdr = 0,
    Count = 100,
    StartByteAdr = 0,
    Value = new object()
};

private static DataItem varInt = new DataItem()
{
    DataType = DataType.DataBlock,
    VarType = VarType.Int,
    DB = 83,
    BitAdr = 0,
    Count = 1,
    StartByteAdr = 102,
    Value = new object()
};

private static DataItem varReal = new DataItem()
{
    DataType = DataType.DataBlock,
    VarType = VarType.Real,
    DB = 83,
    BitAdr = 0,
    Count = 1,
    StartByteAdr = 112,
    Value = new object()
};

private static DataItem varString = new DataItem()
{
    DataType = DataType.DataBlock,
    VarType = VarType.StringEx,
    DB = 83,
    BitAdr = 0,
    Count = 20,         // max lengt of string
    StartByteAdr = 116,
    Value = new object()
};
    
private static DataItem varDateTime = new DataItem()
{
    DataType = DataType.DataBlock,
    VarType = VarType.DateTime,
    DB = 83,
    BitAdr = 0,
    Count = 1,
    StartByteAdr = 138,
    Value = new object()
}; 
```

然后定义一个列表，其中 DataItems 将存储在

```cs
private static List<DataItem> dataItemsRead = new List<DataItem>();
```

将数据项添加到列表中

```cs
dataItemsRead.Add(varBit);
dataItemsRead.Add(varByteArray);
dataItemsRead.Add(varInt);
dataItemsRead.Add(varReal);
dataItemsRead.Add(varString);
dataItemsRead.Add(varDateTime);
```

打开与 plc 的连接并立即读取项目

```cs
myPLC.Open();

// read the list of variables
myPLC.ReadMultipleVars(dataItemsRead);

// close the connection
myPLC.Close();

// access the values of the list
Console.WriteLine("Int:" + dataItemsRead[2].Value);
```

## 写入多个变量

此方法在单个请求中写入多个变量。

```cs
public void Plc.Write(Array[DataItem] dataItems);
```

-   **Array\[\]**你必须指定一个 DataItem 数组，其中包含你想要写入的所有项目

示例：此方法将多个变量写入一个数据块

定义数据项

```cs
 private static DataItem varWordWrite = new DataItem()
{
    DataType = DataType.DataBlock,
    VarType = VarType.Word,
    DB = 83,
    BitAdr = 0,
    Count = 1,
    StartByteAdr = 146,
    Value = new object()
};

private static DataItem varIntWrite = new DataItem()
{
    DataType = DataType.DataBlock,
    VarType = VarType.Int,
    DB = 83,
    BitAdr = 0,
    Count = 1,
    StartByteAdr = 148,
    Value = new object()
};

private static DataItem varDWordWrite = new DataItem()
{
    DataType = DataType.DataBlock,
    VarType = VarType.DWord,
    DB = 83,
    BitAdr = 0,
    Count = 1,
    StartByteAdr = 150,
    Value = new object()
};

private static DataItem varDIntWrite = new DataItem()
{
    DataType = DataType.DataBlock,
    VarType = VarType.DInt,
    DB = 83,
    BitAdr = 0,
    Count = 1,
    StartByteAdr = 154,
    Value = new object()
};

private static DataItem varRealWrite = new DataItem()
{
    DataType = DataType.DataBlock,
    VarType = VarType.Real,
    DB = 83,
    BitAdr = 0,
    Count = 1,
    StartByteAdr = 158,
    Value = new object()
};

private static DataItem varStringWrite = new DataItem()
{
    DataType = DataType.DataBlock,
    VarType = VarType.StringEx,
    DB = 83,
    BitAdr = 0,
    Count = 20,
    StartByteAdr = 162,
    Value = new object()
};
```

将值分配给数据项。注意使用正确的数据转换以使变量适合 S7 数据类型

```cs
// asign values to the variable to be written                
varWordWrite.Value = (ushort)67;
varIntWrite.Value = (ushort)33;
varDWordWrite.Value = (uint)444;
varDIntWrite.Value = 6666;
varRealWrite.Value = 77.89;
varStringWrite.Value = "Writting";
```

然后定义一个列表来存储数据项，并将创建的项目添加到列表中

```cs
private static List<DataItem> dataItemsWrite = new List<DataItem>();

// add data items to list of data items to write                
dataItemsWrite.Add(varWordWrite);
dataItemsWrite.Add(varIntWrite);
dataItemsWrite.Add(varDWordWrite);
dataItemsWrite.Add(varDIntWrite);
dataItemsWrite.Add(varRealWrite);
dataItemsWrite.Add(varStringWrite);
```

最后打开与 plc 的连接并一次性写入项目。使用`.ToArray()`将列表转换为数组。

```cs
// open the connection
myPLC.Open();

// write the items
myPLC.Write(dataItemsWrite.ToArray());

// close the connection
myPLC.Close();
```
