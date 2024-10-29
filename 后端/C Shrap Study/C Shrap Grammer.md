# 变量
## string 和 String 的区别：
String 是.NET 平台下的字符串类 ，string 是 C# 中的字符串类
## Camel : 驼峰命名法  -- 变量命名
要求变量名首字母要小写，其余每个单词的首字母要大写，多用于给变量命名；
## Pascal :帕斯卡命名法  -- 多用于给类或者方法命名
要求每个单词的首字母大写，其余字母小写
# 类型转换  --强转的前提是类型兼容
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

#     Continue(s)和break
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
### 枚举类型和string类型的相互转换
#### 枚举类型转换为string 
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
	     #region 枚举类型转换为string 
			 QQState state = QQState.OnLine;
			 string s = state.ToString();
			 Console.WriteLine(s);
		 #endregion
    }
}
```
#### string类型转换为枚举 :
语法：==（要转换的枚举类型）Enum.Parse(typeof(要转换的枚举类型)，“要转换的字符串”)==
如果“要转换的字符串”是数字，则不会产生异常
如果“要转换的字符串”是空字符串，则会产生异常
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
		    #region string类型转换为枚举 
			string s1 = "1";
			QQState qState = (QQState) Enum.Parse(typeof(QQState),s1);
			Console.WriteLine(qState);
			#endregion
    }
}
```
如果s1 为空; 产生System.ArgumentException:“Must specify valid information for parsing in the string. Arg_ParamName_Name”异常
![[Pasted image 20241024235638.png]]![[Pasted image 20241024235851.png]]
# 结构   -- 可以帮助我们一次性声明多个==不同类型的变量== （实际是字段）
语法：
[public] strut  结构名
{
	成员；//字段
}

## 字段和变量的区别：
==在程序运行的时候，变量只能存一个值；字段可以存多个值；同时在取名上：字段前要加_==

```c#
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace C_Shrap_Grammar
{
	 public struct Person
	 {
	     public string _name;
	     public  int _age;
	     char _gender;
	 }
	 internal class Program
	 {
	     static void Main(string[] args)
	     {
		    #region 结构     --一次性声明多个类型的变量
            Person person;
            person._name = "张三";
            person._age = 18;
            #endregion
        }
    }
}


```
结构体中的字段如果不加public 是访问不到的   上述例子中无法通过person._gender 来给性别赋值
# 数组   -- 一次存储多个相同类型的变量
语法：
数组类型  [ ] 数组名 = new 数组类型[数组长度]；
# 冒泡排序：将一个数组中的元素从大到小或者从小到大的顺序进行排序
## 规则：将第一个元素和后面的每一个元素做比较，只要前面的元素大于后面的元素就交换一次

ex:
方法1：
```c# 
#region 冒泡排序  ：将一个数组中的元素从大到小或者从小到大的顺序进行排序    规则：将第一个元素和后面的每一个元素做比较，只要前面的元素大于或小于后面的元素就交换一次

int[] nums = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
//第一趟比较：8，7，6，5，4，3，2，1，0 ,9   交换9次
//第二趟比较：7，6，5，4，3，2，1，0，8 , 8
//第三趟比较：6，5，4，3，2，1,0，7，8，9
//第四次比较：5，4，3，2，1，0，6，7，8，9
//第五趟比较：4，3，2，1，0，5，6，7，8，9
//第六趟比较：3，2，1，0，4，5，6，7，8，9
//第七趟比较：2，1，0，3，4，5，6，7，8，9
//第八趟比较：1，0，2，3，4，5，6，7，8，9
//第九趟比较：0，1，2，3，4，5，6，7，8，9

for (int i = 0; i < nums.Length-1; i++) 
{
    for (int j = 0; j < nums.Length - 1-i; j++)
    {
        if (nums[j] > nums[j + 1])
        { 
            int temp = nums[j];
            nums[j] = nums[j + 1];
            nums[j + 1] = temp;
        }
    }
}

for (int i = 0;i < nums.Length;i++)
{
    Console.Write(nums[i]+"\t");
}


#endregion
```
方法2：
```c#
#region 冒泡排序  ：将一个数组中的元素从大到小或者从小到大的顺序进行排序    规则：将第一个元素和后面的每一个元素做比较，只要前面的元素大于或小于后面的元素就交换一次

int[] nums = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
//第一趟比较：8，7，6，5，4，3，2，1，0 ,9   交换9次
//第二趟比较：7，6，5，4，3，2，1，0，8 , 8
//第三趟比较：6，5，4，3，2，1,0，7，8，9
//第四次比较：5，4，3，2，1，0，6，7，8，9
//第五趟比较：4，3，2，1，0，5，6，7，8，9
//第六趟比较：3，2，1，0，4，5，6，7，8，9
//第七趟比较：2，1，0，3，4，5，6，7，8，9
//第八趟比较：1，0，2，3，4，5，6，7，8，9
//第九趟比较：0，1，2，3，4，5，6，7，8，9
  #region 方法2：使用数组的Sort 方法；对数组升序排列    Reverse方法对数组的元素倒叙反转
  Array.Sort(nums);
  #endregion

for (int i = 0;i < nums.Length;i++)
{
    Console.Write(nums[i]+"\t");
}


#endregion
```
# out 参数的使用  --out参数可以返回多个相同类型的值也可以返回多个不同类型的值
##  如果在一个方法中返回多个相同类型的值的时候，可以考虑返回一个数组。但是如果返回不同类型的值的时候数组就不可以了，这个时候可以使用out 参数
```c#
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace C_Shrap_Grammar
{
	    internal class Program
    {
        static void Main(string[] args)
        {
		    int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
	         #region 25-2 .方法2：使用out 参数 --对相同类型和不同类型都有效
			  int max = 0;
			  int min = 0;
			  int sum = 0;
			  int avg = 0;
			  Test(nums, out max, out min, out sum, out avg);
			  Console.WriteLine("最大值是{0}，最小值是{1}，总和是{2}，平均值是{3}", max,min,sum,avg);
			
			  #endregion
		}
		 /// <summary>
		 ///25. 求一个数组中的最大值、最小值、总和、平均值
		 /// </summary>
		 /// <param name="nums"></param>
		 /// <returns></returns>
		 public static int[] GetMaxMinSunAvg(int[] nums)
		 {
		     int[] res = new int[4];
		     //假设res[0]是最大值；res[1]是最小值；res[2]是总和；res[3]是平均值
		     res[0] = nums[0];//max
		     res[1] = nums[0];//min
		     res[2] = 0;
		     for (int i = 0; i < nums.Length; i++)
		     {
		         //如果当前循环到的元素比最大值还大，就把它赋值给最大值
		         if (nums[i] > res[0])
		         {
		             res[0] = nums[i];
		         }
		         //如果当前循环到的元素比最小值还小，就把它赋值给最小值
		         if (nums[i] < res[1])
		         {
		             res[1] = nums[i];
		         }
		         //求和
		         res[2] += nums[i];
		
		     }
		     //平均值
		     res[3] = res[2] / nums.Length;
		     return res;
		 }
	}
}
```