# 变量
## string 和 String 的区别：
String 是.NET 平台下的字符串类 ，string 是 C# 中的字符串类
## Camel : 驼峰命名法  -- 变量命名
要求变量名首字母要小写，其余每个单词的首字母要大写，多用于给变量命名；
## Pascal :帕斯卡命名法  -- 多用于给类或者方法命名
要求每个单词的首字母大写，其余字母小写
# 类型转换
## 1.使用Convert 进行类型转换    --成功了就成功了，失败了就抛异常
### 使用：
#### 基础用法：
ex:
```c#
int num = Convert.ToInt32(Console.ReadLine());
```

####  如果输入的内容无法转换为int 会触发 System.FormatException:“The input string '用户输入的内容' was not in a correct format.” 程序会中断，这样就需要捕获异常：
```c#
  Console.WriteLine("请输入一个数");
  try
  {
      int num = Convert.ToInt32(Console.ReadLine());
  }
  catch (FormatException e)
  {
      Console.WriteLine(e); //--将异常打印在控制台，异常内容很详细，精确指出哪一行代码有问题；适合开发人员查看
  }
```
#### 进阶用法： 这里还可能出现其他的异常：如输入的数字超过int 的范围
```c#
 //提示用户输入一个数
 Console.WriteLine("请输入一个数");
 //使用int 型的变量num 来接收并存储这个数 ；使用Console.ReadLine()来接收用户的输入；  使用Convert.ToInt32将用户输入的字符串转换为int 型变量 ；如果是“数字”则可以转换成功，否则会转换失败，会触发System.FormatException:“The input string '用户输入的内容' was not in a correct format.”如果是数据太大会触发System.OverflowException:“Value was either too large or too small for an Int32.”这个异常 这里需要处理异常，通过try...Catch 来处理  --问题：如何通过try...Catch 处理特定的异常
 try
 {
     int num = Convert.ToInt32(Console.ReadLine());
 }
 catch (FormatException ex)
 {

     Helper.LogHelper.error(ex.Message);
 }
 catch (OverflowException ex)
 {
     Helper.LogHelper.error(ex.Message);
 }
```
Helper.LogHelper.error(ex.Message)参考[[封装一个日志助手类]]

---
## 2.使用Parse();   在用法上同Convert; Convert 本质上还是在调用Parse
### 问题：使用Convert 和Parse 谁效率高？  -- Parse 效率高，因为Convert 本质上还是在调用Parse
---

## 3.使用TryParse()：
