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

## 3.使用TryParse()：  --不会抛异常，程序效率高
![[Pasted image 20241024165716.png]]

# Continue(s)和break
## break : 跳出当前循环
## Continue: 跳到循环条件处

# 三元表达式
## 语法：
表达式1？表达式2：表达式3；
表达式1是关系型表达式
如果为true 则三元表达式的结果为表达式2
```c#
 #region 三元表达式
 Console.WriteLine( "输入第一个数：");
 int num1 = 0;
 try
 {
      num1 = Convert.ToInt32(Console.ReadLine());
 }
 catch (FormatException ex)
 {

     Helper.LogHelper.error(ex.Message);
 }
 catch (OverflowException ex)
 {
     Helper.LogHelper.error(ex.Message);
 }

 int num2 = 0;
 Console.WriteLine("输入第二个数：");
 try
 {
      num2 = Convert.ToInt32(Console.ReadLine());
 }
 catch (FormatException ex)
 {

     Helper.LogHelper.error(ex.Message);
 }
 catch (OverflowException ex)
 {
     Helper.LogHelper.error(ex.Message);
 }
 int max = num1 > num2 ? num1 : num2;
 Console.WriteLine("两个数中较大的是{0}",max);
 #endregion
```
# 随机数
Next(1, 10) 左闭右开
```c#
     Random random = new Random();
     int num = random.Next(1, 10);
     Console.WriteLine(num);
```
# 枚举
## 语法：
public enum 枚举名
{
	枚举1，
	枚举2
}
==ex: 需要写在命名空间下或者类下，不能在方法内部声明==
```c#
   public enum Grender 
   {
       男,
       女 
   }

   public enum QQState
   { 
       OnLine,
       OffLine,
       Busy,
       QMe
   }
```
## 枚举类型和int、string类型的相互转换
### 枚举类型和int类型的相互转换
枚举默认可以和int类型相互转换，说明枚举和int类型是兼容的
ex:
#### 枚举转换为int型  --枚举第一个是0，以此类推
```c#
public enum QQState
   { 
       OnLine,
       OffLine,
       Busy,
       QMe
   }
   internal class Program
{
    static void Main(string[] args)
    {
	  QQState state = QQState.OffLine;
	  int m = (int)state;
	  Console.WriteLine(m);
    }
}
```
#### int型转枚举
```c#
public enum QQState
   { 
       OnLine,
       OffLine,
       Busy,
       QMe
   }
   internal class Program
{
    static void Main(string[] args)
    {
	     int n = 3;
	    QQState state = QQState.OnLine;
	    state = (QQState)n;
	    Console.WriteLine(state);//QMe
    }
}

输出为： QMe
```
 ==如果n的值超过枚举索引==

```c#
public enum QQState
   { 
       OnLine,
       OffLine,
       Busy,
       QMe
   }
   internal class Program
{
    static void Main(string[] args)
    {
	     int n = 8;
	    QQState state = QQState.OnLine;
	    state = (QQState)n;
	    Console.WriteLine(state);
    }
}

输出为8，不会报异常
```
