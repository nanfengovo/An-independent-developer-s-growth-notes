# 题目：
```
基础语法部分：
1.n1=10,n2=20  交换n1和n2的值 (要求使用两种方法)
2.编程实现计算几天（如46天）是几周零几天
3.在第2题的基础上进阶： 用户输入今天是一年中的第几天，计算是几周零几天
4.根据用户输入的日期，判断是一年中的第几天(要求使用两种方法)
5.用户输入年份，判断是不是闰年
6.练习： 提示用户输入用户名和密码，要求用户名为admin，密码为123456；只要用户名和密码错误就重新输入；但是，最多只能输三次(使用while ,do while,)
7.for循环求1~100的整数和，偶数和，奇数和
8.找出100~999间的水仙花数
9.打印9*9乘法表
10.打印三角型的99乘法表
11.循环录入5个人的年龄并计算平均年龄，如果录入的数据出现负数或者大于100的数，立即停止录入并报错
12.在while中用break实现要求用户一直输入用户名和密码，只要不是admin、123456就一直提示要求重新输入，如果输入正确则提示成功
13.1~100之间的整数相加，得到累加值大于20的当前数（比如：1+2+3+4+5+6 = 21）结果6
14.用while continue 实现计算1到100（含）之间的除了能被7整除之外所有整数的和
15.==找出100内的所有素数  --质数，又称 素数，指**在大于 1 的 自然数 中，除了 和该数自身外，无法被其他自然数 整除 的数**==
16.从一个整数数组中取出最大的整数，最小整数，总和，平均值。
17.计算一个整数数组所有元素的和。
18.数组里面都是人的名字，分割成：例如：“老杨|老苏|老周……”（老杨，老苏，老周）
19.将一个整数数组的每一个进行如下的处理：如果元素是正数则将这个位置的元素值加1，如果这个元素是负数则将这个位置的元素值减1，如果元素是0，则不变
20.将一个字符串数组的元素的顺序进行反转。{“我”，“是”，“好人”}{“好人”，“是”，“我”}。第i个和第length-i-1个进行交换
21.读取输入的整数，定义成方法，多次调用（如果用户输入的是数字则返回，否则提示用户重新输入）
22.只允许用户输入y或n,请改成方法
23.使用方法实现：查找两个整数中的最大值
24.使用方法实现：计算输入数组的和
25.写一个方法，求一个数组中的最大值、最小值、总和、平均值
26.分别提示用户输入用户名和密码；写一个方法来判断用户输入的是否正确；返回给用户一个登录结果，并且还要单独的返回给用户一个登录信息；如果用户名或密码错误，除了返回登录结果外，还要返回一个用户名错误或密码错误
27.通过冒泡排序法对整数数组{1，3，4，7，90，2，4，6，8，10}实现升序排序
oop部分：
28.写一个Ticket类，有一个距离属性（本属性只读，在构造方法中赋值），有一个价格属性，价格属性只读，并且根据距离distance计算价格Price（1元/公里）
字符串：
29.随机输入你心中想到的一个名字，然后输出它的字符串长度  Length:可以得到字符串长度
30.两个学员输入各自最喜欢的课程名称，判断是否一致，如果相等则输出你们俩喜欢相同的课程，如果不相同则输出你们俩喜欢不同的课程
31.上题中两位同学输入C#和c#代表同一门课程，怎么办
32.从日期字符串（"2008-08-08"）中分析出年、月、日；2008年08月08日
	* 让用户输入一个日期格式如："2008-01-01",你输出日期为2008年1月2日*
集合：
33.创建一个集合；添加一些数字，求平均值,求和，最大值，最小值
34.写一个长度为10的集合，要求在里面随机的存放10个数字（0~9）但是要求所有的数字不重复
35.将一个数组中的奇数放到一个集合中，再将偶数放到另一个集合中，最终将两个集合合并为一个集合，并且将奇数显示在左边，偶数显示在右边
操作文件：
36.使用FileSteam实现多媒体文件复制
```

---
# 解：
## 1. [[交换两个变量的值]]
## 2.编程实现计算几天（如46天）是几周零几天
```c#
 int days = 46;
 int weeks = 46 / 7;
 int day = 46 % 7;
 Console.WriteLine($"46天是{weeks}周{day}天");
```
## 3.在第2题的基础上进阶： 用户输入今天是一年中的第几天，计算是几周零几天
```c#
Console.WriteLine("题目：用户输入今天是一年中的第几天，计算是几周零几天");
int days = 0;
try
{
    days = Convert.ToInt32(Console.ReadLine());
    int weeks = days / 7;
    int day = days % 7;
    Console.WriteLine($"{days}天是{weeks}周{day}天");
}
catch (Exception)
{

    Console.WriteLine("天数格式有误，请重新输入！");
}
```
## 4.根据用户输入的日期，判断是一年中的第几天(要求使用两种方法)
```c#
            Console.WriteLine("题目：根据用户输入的日期，判断是一年中的第几天");
            Console.WriteLine("思路：1判断是不是闰年，确定2月天数  2.求月份的天数和 3.加上天数");
            Console.WriteLine("请输入日期：");
            //接收用户的输入：
            DateTime dateTime;
            int days = 0;
            int month = 0;
            int day = 0;
            // 将string类型转换为DateTime类型有三种方式
            //第一种 ：Convert.ToDateTime(string) ---日期的格式需要是"yyyy/MM/dd"或"yyyy-MM-dd"
            try
            {
                dateTime = Convert.ToDateTime(Console.ReadLine());
                //Console.WriteLine(dateTime);
                //有两种方法可以知道用户输入的日期，是一年中的第几天
                #region 第一种： dateTime.DayOfYear   --本质上Microsoft封装的方法
                days = Convert.ToInt32(dateTime.DayOfYear);
                Console.WriteLine($"这是一年中的第{days}天");
                #endregion
                #region 第二种： 自己计算
                //1.判断是不是闰年  --先拿到年份才可以判断是不是闰年   --闰年2月有29天
                int year = Convert.ToInt32(dateTime.Year);
                bool isLeapYear = true;
                days=0;
                if (year % 400 == 0 || year % 4 == 0 && year % 100 != 0)
                {
                    Console.WriteLine("是闰年！");
                }
                else
                {
                    Console.WriteLine("不是闰年！");
                    isLeapYear = false;
                }
                //2.拿到月份
                 month = Convert.ToInt32(dateTime.Month);
                //3.拿到天数
                 day = Convert.ToInt32(dateTime.Day);
                //4.计算
                if (isLeapYear)
                {
                    //days = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }[month - 1] + day;
                    GetDays();
                    Console.WriteLine($"这是一年中的第{days}天");
                }
                else
                {
                    //days = new int[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }[month - 1] + day;
                    GetDays();
                    Console.WriteLine($"这是一年中的第{days-1}天");
                }
                
                #endregion
            }
            catch (Exception)
            {

                Console.WriteLine( "输入的日期格式有误，程序退出！，请重新输入格式为：yyyy/MM/dd 或者 yyyy-MM-dd的日期！");
            }

            //第二种：DateTime.ParseExact(Console.ReadLine(),"yyyyMMdd",System.Globalization.CultureInfo.CurrentCulture);
            //dateTime = DateTime.ParseExact(Console.ReadLine(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);

            //通过dataTime.Year拿到年份同时强转为int型
            //int year = Convert.ToInt32(dateTime.Year);
            //Console.WriteLine(year);
            //通过 dateTime.DayOfYear 拿到是一年中的第多少天
            //int days = Convert.ToInt32(dateTime.DayOfYear);
            //Console.WriteLine(days);
            //1 判断是不是闰年

            void GetDays() 
            {
                int[] months = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                for (int i = 0; i < month - 1; i++)
                {
                    days += months[i];
                }
                days += day;
            }
```
## 5.用户输入年份，判断是不是闰年
```c#
 Console.WriteLine("请输入年份：");
 int year = 0;
 try
 {
     year = Convert.ToInt32(Console.ReadLine());
     if (year % 400 == 0 || year % 4 == 0 && year % 100 != 0)
     {
         Console.WriteLine("是闰年！");
     }
     else
     {
         Console.WriteLine("不是闰年！");
     }
 }
 catch (Exception)
 {

     Console.WriteLine("输入的年份格式错误！");
 }
```
## 6.练习： 提示用户输入用户名和密码，要求用户名为admin，密码为123456；只要用户名和密码错误就重新输入；但是，最多只能输三次
### while

```c#  while
string useName = "";
string pwd = "";
int i = 0;
while ((useName != "admin" || pwd != "123456") && i<3)
{
    Console.WriteLine("请输入用户名;");
    useName = Console.ReadLine();
    Console.WriteLine("请输入密码：");
    pwd = Console.ReadLine();
    i++;
}
```
### do-while
```C#
   int i = 0;
   do
   {
       Console.WriteLine("请输入用户名;");
       useName = Console.ReadLine();
       Console.WriteLine("请输入密码：");
       pwd = Console.ReadLine();
       i++;
   } while ((useName != "admin" || pwd != "123456")&& i<3);
```
## 7.for循环求1~100的整数和，偶数和，奇数和
### 求1~100的整数和
```c#
 int sum = 0;
 for(int i = 1; i <= 100; i++) 
 {
     sum += i;
 }
 Console.WriteLine(sum);
```
### 求1~100的偶数和
#### 方法1：

```c#
      int sum = 0;
      for (int i = 1; i <= 100;i++) 
      {
          if (i % 2 == 0)
          {
              sum += i;
          }
      }
      Console.WriteLine(sum);
```
#### 方法2：
```c#
  int sum = 0;
  for (int i = 2; i <= 100; i+=2)
  {
      
          sum += i;
      
  }
  Console.WriteLine(sum);
```
### 求1~100的奇数和
```c#
 int sum = 0;
for (int i = 1; i <= 100; i += 2)
{

    sum += i;

}
Console.WriteLine(sum);
```
## 8.找出100~999间的水仙花数
``` 
什么叫水仙花数
百位的立方+十位的立方+个位的立方等于当前这个百位数字
分别拿到百位，十位，个位
//百位：除以100
//十位：%100/10
//个位：对10取余

```
```c#
   for (int i = 100; i <= 999; i++)
   {
       int bai = i / 100;
       int shi = i % 100 / 10;
       int ge = i % 10;
       if (bai * bai * bai + shi * shi * shi + ge * ge * ge == i)
       {
           Console.WriteLine(i);
       }

   }
```
## 9.打印9*9乘法表
```c#
  for (int i = 1; i <= 9; i++)
  {
      for(int j = 1;j<=9; j++)
      {
          Console.Write($"{i}*{j}={i*j}\t") ;
      }
      Console.WriteLine();
  }
```
![[Pasted image 20241024133229.png]]
## 10.打印三角型的99乘法表
```c#
       for (int i = 1; i <= 9; i++)
       {
           for (int j = 1; j <= i; j++)
           {
               Console.Write($"{i}*{j}={i * j}\t");
           }
           Console.WriteLine();
       }
```
![[Pasted image 20241024140120.png]]
## 11.循环录入5个人的年龄并计算平均年龄，如果录入的数据出现负数或者大于100的数，立即停止录入并报错
```c#
            #region 11.循环录入5个人的年龄并计算平均年龄，如果录入的数据出现负数或者大于100的数，立即停止录入并报错
            int age = 0;
            int average = 0;
            int sum = 0;
            for (int i = 1; i <=5; i++)
            {
                Console.WriteLine("请输入第{0}个的年龄：",i);
                try
                {
                    age = int.Parse(Console.ReadLine());
                    sum += age;
                }
                catch (FormatException ex)
                {

                    Helper.LogHelper.error(ex.Message);
                    Helper.LogHelper.Info("输入的年龄必须是数字！");
                    break;
                }
                catch (OverflowException ex)
                {
                    Helper.LogHelper.error(ex.Message);
                    Helper.LogHelper.Info("输入的年龄太大！");
                    break;
                }
                if (age < 0 || age > 100)
                {
                    Console.WriteLine("录入的年龄须在0~100之间！");
                    break;
                }
                else
                {
                   
                    if (i == 5) 
                    {
                        average = sum / 5;
                        Console.WriteLine("录入的5人平均年龄为{0}", average);
                    }
           
                }
               
            }

            #endregion
```
## 12.在while中用break实现要求用户一直输入用户名和密码，只要不是admin、123456就一直提示要求重新输入，如果输入正确则提示成功
```c#
  #region 12.在while中用break实现要求用户一直输入用户名和密码，只要不是admin、123456就一直提示要求重新输入，如果输入正确则提示成功
  bool isAdmin = false;
  while (!isAdmin)
  {

      Console.WriteLine("请输入用户名！");
      string useName = "";
      string pwd = "";
      useName = Console.ReadLine();
      Console.WriteLine("请输入密码！");
      pwd = Console.ReadLine();
      if (useName == "admin" && pwd == "123456")
      {
          Helper.LogHelper.Info("登录成功！");
          isAdmin = true;
      }
      else
      {
          Helper.LogHelper.warning("用户名或密码错误！请重新输入！");
      }

  }
  #endregion
```
## 13.1~100之间的整数相加，得到累加值大于20的当前数（比如：1+2+3+4+5+6 = 21）结果6
```c#
 int sum = 0;
 for (int i = 1; i <= 100; i++)
 {
     sum += i;
     if (sum > 20)
     {
         Console.WriteLine(i);
         break;
     }
 }
```
## 14.用while continue 实现计算1到100（含）之间的除了能被7整除之外所有整数的和
```c#
  #region 14.用while continue 实现计算1到100（含）之间的除了能被7整除之外所有整数的和
  int i = 1;
  int sum = 0;
  while(i<=100)
  {
      if (i % 7 == 0)
      {
          i++;
          continue;
      }
      sum += i;
      i++;
  }
  Console.WriteLine("1到100（含）之间的除了能被7整除之外所有整数的和为{0}",sum);
  #endregion
```
## 15.找出100内的所有素数  --质数，又称 素数，指**在大于 1 的 自然数 中，除了 和该数自身外，无法被其他自然数 整除 的数**
```c#
 for (int i = 2; i <= 100; i++)
 {
     bool b = true;
     for (int j = 2; j < i; j++)
     {
         if (i % j == 0)
         {
             b = false;
             break;
         }
     }
     if (b)
     {
         Console.WriteLine(i);
     }
 }
```

## 16.从一个整数数组中取出最大的整数，最小整数，总和，平均值。  
```c#
#region 数组练习  16.从一个整数数组中取出最大的整数，最小整数，总和，平均值。  
  
int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };  
//max min  
int max = nums[0];  //把数组中存在的一个数赋值给最大/最小值  
int min = nums[0];  
//sum  avg  
int sum = 0;  
int avg = 0;  
for (int i = 0; i < nums.Length; i++)  
{  
    if (nums[i] > max)  
    {  
        max = nums[i];  
    }  
  
    if (nums[i] < min)  
    {  
        min = nums[i];  
    }  
      
    sum += nums[i];  
      
      
}  
avg = sum / nums.Length;  
Console.WriteLine($"最大值是{max} ,最小值是{min},总和是{sum} ,平均值是{avg}");  
#endregion
```
## 17.计算一个整数数组所有元素的和。 
```c# 
#region 17.计算一个整数数组所有元素的和。  
  
int [] num  = {1,2,3,4,5};  
int sum = 0;  
for (int i = 0; i < num.Length; i++)  
{  
    sum += num [i];  
}  
  
Console.WriteLine($"数组和为{sum}");  
#endregion
```
## 18.数组里面都是人的名字，分割成：例如：“老杨|老苏|老周……”（老杨，老苏，老周）  
```c#
#region 18.数组里面都是人的名字，分割成：例如：“老杨|老苏|老周……”（老杨，老苏，老周）  
  
string[] names =  { "老杨","老苏","老周"};  
string str = null;  
for (int i = 0; i < names.Length-1; i++)  
{  
    str +=  names[i]+"|";  
}  
Console.WriteLine(str+names[names.Length-1]);  
#endregion
```
## 19.将一个整数数组的每一个进行如下的处理：如果元素是正数则将这个位置的元素值加1，如果这个元素是负数则将这个位置的元素值减1，如果元素是0，则不变 
```c#
#region 19.将一个整数数组的每一个进行如下的处理：如果元素是正数则将这个位置的元素值加1，如果这个元素是负数则将这个位置的元素值减1，如果元素是0，则不变  
  
int[] num = { 1, 2, 3, 4, -2, -4, -6 };  
for (int i = 0; i < num.Length; i++)  
{  
    if (num[i] > 0)  
    {  
        num[i] += 1;  
    }  
  
    if (num[i] < 0)  
    {  
        num[i] -= 1;  
    }  
}  
  
for (int i = 0; i < num.Length; i++)  
{  
    Console.WriteLine(num[i]);  
}
```
## 20.将一个字符串数组的元素的顺序进行反转。{“我”，“是”，“好人”}{“好人”，“是”，“我”}。第i个和第length-i-1个进行交换 
### 方法一：自己实现
```c#
#region 20.将一个字符串数组的元素的顺序进行反转。{“我”，“是”，“好人”}{“好人”，“是”，“我”}。第i个和第length-i-1个进行交换  
  
string[] s = { "我", "是", "好人" };  
  
for (int i = 0; i < s.Length/2; i++)  
{  
    string temp = s[i];  
    s[i] = s[s.Length - 1 - i];  
    s[s.Length - 1 - i] = temp;  
}  
  
for (int i = 0; i < s.Length; i++)  
{  
    Console.WriteLine(s[i]);  
}  
  
#endregion
```
### 方法二：使用数组方法Reverse实现数组中元素的倒序反转
```c#
#region 20.将一个字符串数组的元素的顺序进行反转。{“我”，“是”，“好人”}{“好人”，“是”，“我”}。第i个和第length-i-1个进行交换  
  
string[] s = { "我", "是", "好人" };  
  
   #region 方法二：使用Reverse方法实现倒序反转
   Array.Reverse(s);

   #endregion
  
for (int i = 0; i < s.Length; i++)  
{  
    Console.WriteLine(s[i]);  
}  
  
#endregion
```
## 21.读取输入的整数，定义成方法，多次调用（如果用户输入的是数字则返回，否则提示用户重新输入）
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
			        #region 21. 读取输入的整数，定义成方法，多次调用（如果用户输入的是数字则返回，否则提示用户重新输入）
					 Console.WriteLine("请输入数字");
					 string s = Console.ReadLine();
					 GetNumber(s);
					 #endregion
		 }
	}
	 public static int GetNumber(string s)
        {
            while (true)
            {
                try
                {
                    int num = Convert.ToInt32(s);
                    return num;
                }
                catch 
                {

                    Console.WriteLine("请重新输入");
                    s= Console.ReadLine();
                }
            }
        }
    }
}

```
## 22.只允许用户输入y或n,请改成方法
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
			          #region 22.只允许用户输入y或n,请改成方法
					  Console.WriteLine("请输入y或n停止循环！");
					  string s = Console.ReadLine();
					  IsInputyorn(s);           
					  #endregion
		 }
	}
	        /// <summary>
        /// 22.只允许用户输入y或n,请改成方法
        /// </summary>
        /// <param name="s">用户输入 </param>
        public static void IsInputyorn(string s)
        {
            bool IsStop = true;
            while (IsStop)
            {
                if (s == "y" || s == "Y" || s == "n" || s == "N")
                {
                    IsStop = false;
                    continue;
                    //IsStop == true;

                }
                else
                {
                   
                    Console.WriteLine("请重新输入");
                    s = Console.ReadLine();
                }
                    
            }
        
        }

    }
}

```
## 23.求两个整数的的最大值
```c#
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace C_Shrap_Grammar
{   internal class Program
   {
       static void Main(string[] args)
       {
	           #region 23. 求两个整数的的最大值
			    int max = GetMax(10, 3);
			    Console.WriteLine(max);
			    #endregion
		}
		 /// <summary>
		 /// 23.找出两个整数的的最大值并将最大值返回
		 /// </summary>
		 /// <param name="num1">第一个参数</param>
		 /// <param name="num2">第二个参数</param>
		 /// <returns>将最大值返回</returns>
		 public static int GetMax(int num1, int num2)
		 {
		     return num1 > num2 ? num1 : num2;
		 }
     }
}

```
## 24.使用方法实现：计算输入数组的和
```c#
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace C_Shrap_Grammar
{   internal class Program
   {
       static void Main(string[] args)
       {
	            #region 24.使用方法实现：计算输入数组的和
				 int[] num = { 1, 2, 3, 4, 5, 6, 7, 8 };
				int s = GetSum(num);
				 Console.WriteLine("数组的和为{0}",s);
				 #endregion
		}
	      /// <summary>
	      /// 24.使用方法实现：计算输入数组的和
	      /// </summary>
	      /// <param name="numbers">需要求和的数组</param>
	      /// <returns>返回求和的结果</returns>
	      public static int GetSum(int[] numbers)
	      { 
	          int sum = 0;
	          for (int i = 0; i < numbers.Length; i++)
	          { 
	              sum += numbers[i];
	              
	          }
	          return sum;
	      }
     }
}
```
## 25.写一个方法，求一个数组中的最大值、最小值、总和、平均值
### 方法一：使用数组返回：
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
	        #region 25.写一个方法，求一个数组中的最大值、最小值、总和、平均值
			int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			int [] res = GetMaxMinSunAvg(nums);
			Console.WriteLine("最大值是{0}，最小值是{1}，总和是{2}，平均值是{3}", res[0], res[1], res[2], res[3]);
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
### 方法二：使用out参数
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
		 /// 25-2. 求一个数组中的最大值、最小值、总和、平均值
		 /// </summary>
		 /// <param name="nums">要求值的数组</param>
		 /// <param name="max">多余返回的最大值</param>
		 /// <param name="min">多余返回的最小值</param>
		 /// <param name="sum">多余返回的总和</param>
		 /// <param name="avg">多余返回的平均值</param>
		 public static void Test(int[] nums, out int max, out int min, out int sum, out int avg)
		 {
		     //out 参数要求在方法的内部必须为其赋值
		     max = nums[0];
		     min = nums[0];
		     sum = 0;
		     for (int i = 0; i < nums.Length; i++)
		     {
		         //如果当前循环到的元素比最大值还大，就把它赋值给最大值
		         if (nums[i] > max)
		         {
		             max = nums[i];
		         }
		         //如果当前循环到的元素比最小值还小，就把它赋值给最小值
		         if (nums[i] < min)
		         {
		             min = nums[i];
		         }
		         //求和
		         sum += nums[i];
		
		     }
		     avg = sum / nums.Length;
		
		 }
	}
}
```
## 26.分别提示用户输入用户名和密码；写一个方法来判断用户输入的是否正确；返回给用户一个登录结果，并且还要单独的返回给用户一个登录信息；如果用户名或密码错误，除了返回登录结果外，还要返回一个用户名错误或密码错误
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
		  #region 26.分别提示用户输入用户名和密码；写一个方法来判断用户输入的是否正确；返回给用户一个登录结果，并且还要单独的返回给用户一个登录信息；如果用户名或密码错误，除了返回登录结果外，还要返回一个用户名错误或密码错误
		  Console.WriteLine("请输入用户名！");
		  string userName = Console.ReadLine();
		  Console.WriteLine("请输入密码！");
		  string password = Console.ReadLine();
		  string msg = "";
		  bool b = IsLogin(userName, password, out msg);
		  Console.WriteLine(msg);
		  #endregion
		}
		  /// <summary>
		 /// 26.分别提示用户输入用户名和密码；写一个方法来判断用户输入的是否正确；返回给用户一个登录结果，并且还要单独的返回给用户一个登录信息；如果用户名或密码错误，除了返回登录结果外，还要返回一个用户名错误或密码错误
		 /// </summary>
		 /// <param name="username">用户名</param>
		 /// <param name="pwd">密码</param>
		 /// <param name="msg">多余返回的登录信息</param>
		 /// <returns>返回的登录结果</returns>
		 public static bool IsLogin(string username, string pwd, out string msg)
		 {
		     if (username == "admin" && pwd == "123456")
		     {
		         msg = "登录成功！";
		         return true;
		     }
		     if (username == "admin")
		     {
		         msg = "用户名错误！";
		         return false;
		     }
		     if (pwd == "123456")
		     {
		         msg = "密码错误！";
		         return false;
		
		     }
		     else
		     {
		         msg = "用户名和密码错误！";
		         return false;
		     }
		
		 
		 }
	}
}
```
## 27.通过冒泡排序法对整数数组{1，3，4，7，90，2，4，6，8，10}实现升序排序
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
		  #region 27.通过冒泡排序法对整数数组{1，3，4，7，90，2，4，6，8，10}实现升序排序
			int[] arr = { 1, 3, 4, 7, 90, 2, 4, 6, 8, 10 };
			AscendingOrder(arr);
			for (int i = 0; i < arr.Length; i++)
			{
			    Console.WriteLine(arr[i]);
			}
			#endregion
		}
		 /// <summary>
		 ///  27.通过冒泡排序法对整数数组{1，3，4，7，90，2，4，6，8，10}实现升序排序
		 /// </summary>
		 /// <param name="arr"></param>
		 public static void AscendingOrder(int[] arr)
		 {
		     for (int i = 0; i < arr.Length - 1; i++)
		     {
		         for (int j = 0; j < arr.Length - 1 - i; j++)
		         {
		             if (arr[j] > arr[j + 1])
		             {
		                 int temp = arr[j];
		                 arr[j] = arr[j + 1];
		                 arr[j + 1] = temp;
		             }
		         }
		     }
		
		 }
	}
}
```
## 28.写一个Ticket类，有一个距离属性（本属性只读，在构造方法中赋值），有一个价格属性，价格属性只读，并且根据距离distance计算价格Price（1元/公里）
```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Ticket
    {

        //构造函数 在构造函数中给距离字段赋值  --因为距离是属性是只读的
        public Ticket(double distance)
        {
            _distance = distance;
        }

        //距离字段
        private double _distance;

        //距离属性 --只读 ；不能为负数
        public double Distance
        {
            get
            {
                if(_distance < 0)
                {
                    _distance = 0;
                }
                return _distance;
            }
        }

        //价格字段
        private double _price;

        //价格属性--只读
        //0~100公里不打折
        //100~200公里打9折
        //200公里以上打八折
        public double Price
        {
            get 
            {
                if(_distance < 100)
                {
                    return _distance * 1;
                }
                else if(_distance>100 && _distance < 200)
                {
                    return _distance * 0.9;
                }
                else
                {
                    return _distance * 0.8;
                }
                
            }
        }
        /// <summary>
        /// 计算总价格
        /// </summary>
        /// <returns></returns>
        public void Spend()
        {
            Console.WriteLine("{0}公里花了{1}元",Distance,Price);
           // return Distance*1.0;
        }

    }
}
```
```c#
namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person(1, "nanfengqaq", 198);
            ////person.Name = "nanfengqaq";
            ////person.Age = 198;


            //Console.WriteLine(person.Name + "的年龄是 " + person.Age);
            ////调用静态方法
            //Person.M2();
            ////调用实例方法
            //person.M1();

            //Student student = new Student("张三",100,100,100);
            //Console.WriteLine(student.Name+"的语文为："+student.Chinese+"数学成绩为："+student.Math+"英语成绩为："+student.English);
            //Console.ReadKey();

            #region  28.写一个Ticket类，有一个距离属性（本属性只读，在构造方法中赋值），有一个价格属性，价格属性只读，并且根据距离distance计算价格Price（1元/公里）
            Ticket ticket = new Ticket(300);
            ticket.Spend();
            #endregion

        }
    }
}
```
## 29.随机输入你心中想到的一个名字，然后输出它的字符串长度  Length:可以得到字符串长度
```c#
using System.Diagnostics;
using System.Text;

namespace StringBuilder使用
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 字符串练习
            #region 29.随机输入你心中想到的一个名字，然后输出它的字符串长度  Length:可以得到字符串长度
            Console.WriteLine("输入你心中想到的一个名字");
            string s = Console.ReadLine();
            Console.WriteLine(s.Length);
            #endregion
            #endregion

        }
    }
}
```
## 30.两个学员输入各自最喜欢的课程名称，判断是否一致，如果相等则输出你们俩喜欢相同的课程，如果不相同则输出你们俩喜欢不同的课程
```C#
using System.Diagnostics;
using System.Text;

namespace StringBuilder使用
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 30.两个学员输入各自最喜欢的课程名称，判断是否一致，如果相等则输出你们俩喜欢相同的课程，如果不相同则输出你们俩喜欢不同的课程
			 Console.WriteLine("请输入你喜欢的课程");
			 string str1 = Console.ReadLine();
			 Console.WriteLine("请输入你喜欢的课程");
			 string str2 = Console.ReadLine();
			 if(str1.Equals(str2))
			 {
			     Console.WriteLine("你们俩喜欢相同的课程");
			 }
			 else
			     Console.WriteLine("你们俩喜欢不相同的课程");
			 #endregion

        }
    }
}
```
## 31.上题中两位同学输入C#和c#代表同一门课程，怎么办   --统一转为大写或者小写在判断
### 方法一：统一转为大写或者小写在判断
```c#
using System.Diagnostics;
using System.Text;

namespace StringBuilder使用
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 31.上题中两位同学输入C#和c#代表同一门课程，怎么办  --可以统一转换为大写或小写在判断
			 Console.WriteLine("请输入你喜欢的课程");
			 string str1 = Console.ReadLine();
			 str1 = str1.ToUpper();
			 Console.WriteLine("请输入你喜欢的课程");
			 string str2 = Console.ReadLine();
			 str2 = str2.ToUpper();
			 if(str1.Equals(str2))
			 {
			     Console.WriteLine("你们俩喜欢相同的课程");
			 }
			 else
			     Console.WriteLine("你们俩喜欢不相同的课程");
			 #endregion

        }
    }
}
```
> - 使用ToUpper();转换为大写 该方法返回一个string类型的
> - 使用ToLower();转为小写该方法返回一个string类型的

### 方法二：忽略大小写
```c#
using System.Diagnostics;
using System.Text;

namespace StringBuilder使用
{
    internal class Program
    {
        static void Main(string[] args)
        {
             #region 方法二：
			 Console.WriteLine("请输入你喜欢的课程");
			 string str1 = Console.ReadLine();
			 Console.WriteLine("请输入你喜欢的课程");
			 string str2 = Console.ReadLine();
			 if (str1.Equals(str2,StringComparison.OrdinalIgnoreCase))
			 {
			     Console.WriteLine("你们俩喜欢相同的课程");
			 }
			 else
			     Console.WriteLine("你们俩喜欢不相同的课程");
			
			 #endregion

        }
    }
}
```
>Equals(str2,StringComparison.OrdinalIgnoreCase) :比较两个字符串忽略大小写

## 32.从日期字符串（"2008-08-08"）中分析出年、月、日；2008年08月08日
	* 让用户输入一个日期格式如："2008-01-01",你输出日期为2008年1月2日*

```c#
using System.Diagnostics;
using System.Text;

namespace StringBuilder使用
{
    internal class Program
    {
        static void Main(string[] args)
        {
              #region 分割字符串练习 32.从日期字符串（"2008-08-08"）中分析出年、月、日；2008年08月08日 *让用户输入一个日期格式如："2008-01-01",你输出日期为2008年1月2日 *

			 string datatime = "2008-08-08";
			 char [] chs = { '-' };
			 string[] str = datatime.Split(chs);
			 Console.WriteLine(str[0] + "年" + str[1] + "月" + str[2]+"日");
			
			 Console.WriteLine("请输入日期:");
			 string data = Console.ReadLine();
			 string[] str1 = data.Split(chs);
			 Console.WriteLine(str1[0] + "年" + str1[1] + "月" + str1[2] + "日");
			 #endregion

        }
    }
}
```
## 33.创建一个集合；添加一些数字，求平均值,求和，最大值，最小值
## 34.写一个长度为10的集合，要求在里面随机的存放10个数字（0~9）但是要求所有的数字不重复
```c#
using System.Collections;

namespace ArrayList练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 集合练习
            #region 33.创建一个集合；添加一些数字，求平均值,求和，最大值，最小值
            ArrayList list = new ArrayList();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            int sum = 0;
            double avg = 0;
            int max =(int)list[0];
            int min = (int)list[0];
            foreach (var item in list)
            {
                if ((int)item > max)
                {
                    max = (int)item;
                }
                if ((int)item < min)
                {
                    min = (int)item;
                }
                sum += (int)item;
                avg = sum / list.Count;
            }
            Console.WriteLine(list.Count);
            Console.WriteLine($"sum={sum},avg={avg},max={max},min={min}");
            #endregion
            #region 34.写一个长度为10的集合，要求在里面随机的存放10个数字（0~9）但是要求所有的数字不重复
            ArrayList arrayList = new ArrayList();
            Random r = new Random();
            
            
            for (int i = 0; i < 10; i++)
            {
                int index = r.Next(0, 10);
                if (!arrayList.Contains(index))
                {
                    
                    arrayList.Add(index);
                }
                else
                {
                    i--;
                }
            }
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
            #endregion
            #endregion
        }
    }
}
```
## 35.将一个数组中的奇数放到一个集合中，再将偶数放到另一个集合中，最终将两个集合合并为一个集合，并且将奇数显示在左边，偶数显示在右边
```c#
	 using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 集合练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 35.将一个数组中的奇数放到一个集合中，再将偶数放到另一个集合中，最终将两个集合合并为一个集合，并且将奇数显示在左边，偶数显示在右边
            int[] nums = new int []{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //将数组中的奇数放到集合中   --用ArrayList / 泛型应该都行
            //存放奇数的集合
            List<int> oddNumber = new List<int> ();
            //存放偶数的集合
            List<int> evenNumber = new List<int> ();
             for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i]%2 != 0)
                {
                    oddNumber.Add (nums[i]);
                }
                else
                {
                    evenNumber.Add (nums[i]);
                }
            }
            oddNumber.AddRange(evenNumber);
            foreach (int i in oddNumber)
            {
                Console.Write(i + " ");
            }
            //Dictionary<List<int>,List<int>> d = new Dictionary<List<int>, List<int>> ();
            //var result = from oddn in oddNumber
            //             from evenn in evenNumber
            //             select new { oddNumber=oddn, evenNumber=evenn};
            //foreach(var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach(var item in result)
            // {
            //     Console.WriteLine(item.oddNumber +" "+ item.evenNumber);
            // }

            #endregion
        }
    }
}

```
## 36.使用FileStream实现多媒体文件复制
```c#
using System;

namespace 使用FileStream_实现多媒体文件的复制
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //思路：将需要复制的文件读取出来，写入到指定的位置
            //源文件的地址、
            string source = @"C:\Users\nanfengqaq\Desktop\test.txt";
            //目标地址
            string target = @"C:\Users\nanfengqaq\Desktop\test1.txt";
            CopyFile(source,target);
            Console.WriteLine("复制完成！");
        }
        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="source">y源文件地址</param>
        /// <param name="target">目标地址</param>
        public static void CopyFile(string source, string target)
        {
            //1.创建一个负责读取的流
            using (FileStream fileRead = new FileStream(source, FileMode.Open, FileAccess.Read))
            {
                //2.创建一个负责写入的流
                using (FileStream fileWrite = new FileStream(target, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] bytes = new byte[1024];
                    //因为文件可能很大，所以需要循环读取
                    while (true)
                    {


                        //返回本次读取实际读取到的字节数
                        int r = fileRead.Read(bytes, 0, bytes.Length);

                        //如果r=0 就意味着什么没有读到，读取完了
                        if(r == 0)
                        {
                            break;
                        }
                        fileWrite.Write(bytes, 0, r);
                        

                    }
                   
                   

                }
            }
        }
    }
}
```