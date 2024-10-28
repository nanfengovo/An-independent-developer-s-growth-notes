# 题目：
```
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
	
```