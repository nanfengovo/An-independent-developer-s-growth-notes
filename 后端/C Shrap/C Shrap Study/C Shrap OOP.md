# This关键字：表示当前类的对象
# 结构和类的区别：
>结构是面向过程的；结构不具备面向对象的特征（封装、继承、多态）
>类是面向对象

# 属性： --保护字段；对字段的取值和赋值做出限定
## 属性的本质是get（取值）和set（赋值）方法 给属性赋值，属性起到中间的作用实际还是给字段赋值；属性不存值
Field 字段
Method 方法
property 属性
>一般字段的访问基本为private ；属性的访问级别要高于字段 一般为Public    --通俗一点讲就是属性是暴露给外界访问的，字段是不暴露给外界的；给属性赋值实际是给字段赋值，属性是不保存值的

ex:
```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Person
    {
        //字段
        private string? _name;
        private int _age;


        //属性
        public string Name
        {
            get
            {
                return _name; 
            }
            set 
            { 
                _name = value; 
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (Age < 0 || Age > 100)
                {
                     _age = 0;
                }
                else
                {
                    _age = Age;
                }
                   
            }
        }
    }
}
```
# 字段（Field）  属性(Property)  方法(Method)
>-字段用来存储数据
>属性用来保护字段
>方法用来描述类的行为

# 静态和非静态的区别
>1.在非静态类中，既可以有实例成员，也可以有静态成员
>   在静态类中只能有静态成员
>2.在调用实例成员的时候，需要使用对象名.实例成员
>  在调用静态成员的时候，需要使用类名.静态成员名
>  总结：静态成员必须使用类名去调用，实例成员使用对象名调用
>  静态函数中，只能访问静态成员，不允许访问实例成员
>  实例函数中，既能访问静态成员，也能访问实例成员
## 为什么静态类无法实例化
~~~ 
因为静态类中都是静态成员，而调用静态成员使用类名.静态成员名；所以实例化没有意义
~~~

## 什么时候用静态类什么时候用非静态类
1)、如果想要将类当作“工具类”去使用，这个时候可以考虑将类写成静态类(避免频繁的实例化)
2)、静态类在整个项目中资源共享（静态类占静态存储区的内存），只有在程序结束的时候才释放资源。---静态类占内存，非静态类不占内存但是对象占内存；

# 构造函数：用来创建对象并且可以在构造函数中对对象进行初始化

## 构造函数是一个特殊的方法
>1.构造函数没有返回值，连void也不能写
>2.构造函数的名称必须和类名一样
>3.创建对象的时候会执行构造函数
>4.类中有个默认的无参构造函数

## 初始化对象
~~~
给对象的各个属性赋初值
~~~

# new 关键字
>1、在内存中开辟了一块空间
>2、在开辟的空间中创建对象
>3.调用对象的构造函数区进行初始化对象

# this 关键字
>1.代表当前类的对象
>2.在类中显示的调用当前类的构造函数

## 在类中显示的调用当前类的构造函数
ex:
```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Student
    {

        public Student( int studentNo, string name, int age, int chinese, int math, int english)
        {
            this.studentNo = studentNo;
            this.name = name;
            this.age = age;
            this.chinese = chinese;
            this.math = math;
            this.english = english;
        
        }


        public Student(string name,int chinese, int math, int english):this(0,name,0,chinese,math,english)
        {
        
        
        }

        private int studentNo;
        private string name;
        private int age;
        private  int chinese;
        private int math;
        private int english;

        public int StudentNo { get => studentNo; set => studentNo = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public int Chinese { get => chinese; set => chinese = value; }
        public int Math { get => math; set => math = value; }
        public int English { get => english; set => english = value; }
    }
}
```
# 析构函数  :希望立刻释放资源
```c#
  /// <summary>
  /// 析构函数：当程序结束的时候析构函数会被调用
  /// 帮助我们释放资源
  /// GC Garbage Collector
  /// </summary>
  ~Student() 
  {
      Console.WriteLine("我是析构函数");
  }
```
# 复习：
# 值类型和引用类型
区别：
>- 值类型和引用类型在内存上存储的地方不一样
>- 在传递值类型和传递引用类型的时候，传递方式不一样。值类型我们称之为值传递，引用类型我们称之为引用传递
>- 

## 值类型：int  double bool char decimal struct  enum
## 引用类型： string  自定义的类  数组

## 值类型和引用类型在内存上存储的地方不一样
>值类型的值存储在内存的栈中
>引用类型的值存储在内存的堆中


# 字符串
## 字符串的不可变性
当你给一个字符串重新赋值之后，旧值并没有销毁，而是重新开辟一块空间存储新值

### 旧的值如何处理
程序结束后，GC扫描整个内存，如果发现有的空间没有被指向则立即销毁
## 字符串的方法
>1.Length :获取字符串的长度
>2.str1.Equals(str2) ：比较两个字符串是否相等
>3.ToUpper();转换为大写 该方法返回一个string类型的
>4.ToLower();转为小写该方法返回一个string类型的
>5.Equals(str2,StringComparison.OrdinalIgnoreCase) :比较两个字符串忽略大小写
>6.Split(chs,StringSplitOptions.RemoveEmptyEntries):  分割字符串，chs :分割的规则  StringSplitOptions.RemoveEmptyEntries：去除空的
>7.Contains() :包含
>8.Replace（“A”,"B"）:A : 需要被替换的字符  B:替换的字符
>9.Substring ：截取字符串 
>		Substring(i) ;从指定索引下标开始截取一直截取到最后，包含指定索引
>		 Substring(i,j) :从下标为i的开始截取，截取j个
>10.StartSWith(value) :判断字符串是否以value开始
>11.EndsWith(value)   ;判断字符串是否以value结束
>12.indexOf（value）； 拿到value 在字符串中第一次出现的下标
>13.LastIndexOf()   最后一个出现的下标;
>14.Trim(); 去掉字符串前后的空格
>15.TrimEnd();去掉字符串中结尾的空格
>16.TrimStart(); 去掉字符串中前面的空格
>17.string.IsNullOrEmpty();判断字符串是否为空或Null
>18. string.Join（）：将数组按指定的字符串连接，返回一个字符串
 
### 通过下标访问字符串中的某一个值
ex；
```c#
   string s = "qwert";
   Console.WriteLine(s[2]);
```
结果是：e
>- 这里我们将string 类型的变量s 看作是char 类型的数组 => string s = "qwert"   <=> char [] s = char[] chars2 = { 'q','w','e','r','t'};
>- 但是不能通过s[1] = "s" 来改变s 的值   如果要改变可以通过将s 转换成char[] 改变后在转回string 类型


ex:
```c#
 //将字符串"qwert"变成"qsert"
 string s = "qwert";
 //未发生改变前
 Console.WriteLine(s);
 //将string类型转换为char[] 数组
 char [] chars = s.ToCharArray();
 //改变第二位的值
 chars[1] = 's';
 //将改变后的char[]数组 转换为字符串
 s = new string(chars);
 Console.WriteLine(s);
```
>- ToCharArray() :将字符串转化为char类型的数组
>- new string(chars)  ：将char[] 数组转换为字符串

## StringBuilder
>问题引入：
>将一个字符串拼接十万次

### 未使用StringBuilder
```c#
using System.Diagnostics;
using System.Text;

namespace StringBuilder使用
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            string str = null;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                str += i;
                
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
}
```
>控制台打印的时间为：00:00:06.0693889

### 使用StringBuilder
```c#
using System.Diagnostics;
using System.Text;

namespace StringBuilder使用
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            string str = null;
            StringBuilder sb = new StringBuilder();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                sb.Append(i);
                
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
}
```
>控制台打印结果为:00:00:00.0020956


## 分割字符串  Split
```c#
using System.Diagnostics;
using System.Text;

namespace StringBuilder使用
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
           #region 分割字符串  Split
			 string s = "a b   dfd _    + =   ,,, fda 0";
			 char[] chs = {' ','_','+','=',',','0' };
			 string[] str = s.Split(chs,StringSplitOptions.RemoveEmptyEntries);
			 for (int i = 0; i <str.Length; i++)
			 {
			     Console.WriteLine(str[i]);
			 }
			 Console.ReadKey();
			 #endregion
        }
    }
}
```
>- StringSplitOptions.RemoveEmptyEntries 去除为空的部分
>-  char[] chs = {' ','_','+','=',',','0' };  分割的规则

# 继承：
>子类继承了父类，那么子类从父类那里继承过来了什么？

~~~
子类继承了父类的属性和方法；没有继承父类的私有字段
~~~
>子类有没有继承父类的构造函数
~~~
子类并没有继承父类的构造函数，但是，子类会默认的调用父类无参数的构造函数，创建父类对象，让子类可以使用父类中的成员
所以，如果在父类中重写一个有参数的构造函数，那个无参数的就被干掉了，子类就调用不到了，子类就会报错
解决方法：
1.在父类重新写一个无参的构造函数
2.在子类中显式的调用父类中的构造函数使用关键字base
~~~


## 继承的特性
>1.单根性
>2.传递性


# new 关键字
>1.创建对像
>2.隐藏从父类那里继承过来的同名成员
>	隐藏的后果就是子类调用不到父类的成员

# 里氏转换
>- 子类对象可以调用父类中的成员，但是父类对象永远只能调用自己的成员
>- 子类可以赋值给父类：如果一个地方需要一个父类作为参数，我们可以给一个子类代替
>- 如果一个父类中装的是子类对象，那么我们可以将这个父类强转为子类对象

```c#
namespace 里氏转换
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*里氏转换 ：
             *1. 子类可以赋值给父类（如果有一个方法需要一个父类作为参数，我们可以传第一个子类对象）
             *2.如果父类中装的是子类对象，则可以将这个父类强转为子类对象 
             */

            //1. 子类可以赋值给父类
            
            Person person = new Student();
            if(person is Student)
            {
                ((Student)person).Print();
            }
            else
            {
                Console.WriteLine("转换失败！");
            }
            
        }

        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public void Print()
            {
                Console.WriteLine("我是人类！");
            }
        }

        public class Student : Person
        {
            public int Grade { get; set; }

            public void Print()
            {
                Console.WriteLine("我是学生！");
            }
        }

        public class Teacher : Person
        {
            public string Subject { get; set; }

            public void Print()
            {
                Console.WriteLine("我是老师");
            }
        }
    }
}
```
## is和as  :表示类型转换
>is:如果转换成功则返回true 否则返回false
>as:如果能够转换则返回对应的对象，否则返回null

# protected 受保护的:  可以被当前类和当前类的子类访问

# 集合
## ArrayList 集合    --集合中元素的类型不确定
### ArrayList集合的方法      

>集合：很多数据的的一个集合；长度可以任意改变，类型单一
>数组：长度不可变，长度单一

###  添加单个元素  Add();
### 添加集合元素  AddRange方法
### Clear(); 清空所有元素
### Remove(需要删除的元素) ； 删除单个元素
### RemoveAt(0); 根据下标删除
### RemoveRange(StartIndex,EndIndex);  从StartIndex下标开始删到EndIndex
###  Sort();升序排列（类型要差不多）
### Reverse(); 反转（倒叙）
### Insert(Index,要插入的内容)；在下标Index 插入要插入的内容
### Insert(Index,集合)；在指定的下标插入一个集合
### Contains();判断是否包含某个指定的元素 返回布尔类型

```c#
using System.Collections;

namespace ArrayList集合的各种方法
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //创建一个集合
            ArrayList list = new ArrayList();
            #region Add方法  ---添加单个元素
            list.Add(1);
            list.Add(2);
            list.Add(true);
            list.Add("nanfengqaq");
            list.Add('男');
            list.Add(new int [] { 1, 2, 3, 4 });
            Person person = new Person();
            list.Add(person);
            for(int i = 0;i < list.Count;i++)
            {
                if (list[i] is Person)
                {
                    ((Person)list[i]).SayHello();
                }
                if(list[i] is int[])
                {
                    int[] arr = (int[])list[i];
                    foreach(var item in arr)
                    {
                        Console.WriteLine(item);
                    }
                }

                Console.WriteLine(list[i]);
            }
            #endregion
            #region AddRange方法  ---添加数组或集合
            list.AddRange(new int[] { 1, 2, 3 });
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] is Person)
                {
                    ((Person)list[i]).SayHello();
                }

                Console.WriteLine(list[i]);
            }

            #endregion

        }

        public class Person
        {
            public void SayHello()
            {
                Console.WriteLine("Hello World!");
            }
        }
    }
}

```

### ArrayList集合的长度问题
>- count 表示这个集合中包含的元素个数
>- capcity  表示这个集合中可以包含的元素个数 （4n） ；每次集合中实际包含的元素个数（count）超过了可以包含的元素的个数（capcity）的时候，集合就会向内存中多申请一倍的空间来保证集合的长度一直够用

## Hashtable 集合   --键值对集合
>在键值对集合中，我们是根据键去找值的；
>键值对对象[键]=值；
>**** 键必须是唯一的，值可以重复
```c#
using System.Collections;

namespace Hashtable_集合
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //创建一个Hashtable键值对集合对象
            Hashtable hashtable = new Hashtable();
            hashtable.Add(1,"zhangsan");
            hashtable.Add(2,true);
            hashtable.Add(3,'男');
            hashtable.Add(false,"错误的");
            //在键值对集合中通过键找值
            //for循环便利不到键为false的值
            for (int i = 0; i < hashtable.Count; i++)
            {
                Console.WriteLine(hashtable[i]);
            }
            //使用foreach 可以遍历值或键
            foreach (var item in hashtable.Values)
            {
                Console.WriteLine(item);
            }
        }
    }
}
```
## List 泛型集合
>List<集合类型>  集合名   = new  List<集合类型>（）；

###  List泛型集合可以转换为数组
## 字典集合
>Dictionary<int，string> dic = new Dictionary<int, string>();



# Path类
> string str = @"C:\\Users\\nanfengqaq\\Desktop\\陕煤项目原型方案(2).rp";
> - 获得文件名和扩展名
>	- GetFileName（str）   --陕煤项目原型方案(2).rp
>- 获得文件名
>	- GetFileNameWithoutExtension(str)  --陕煤项目原型方案(2)
>- 获得扩展名
>	- GetExtension(str)  --.rp
>- 获得文件所在文件夹的名称
>	- GetDirectoryName(str)  --C:\Users\nanfengqaq\Desktop
>- 获得文件的全路径/绝对路径
>	- GetFullPath(str)   --C:\Users\nanfengqaq\Desktop\陕煤项目原型方案(2).rp
>- 连接两个字符串作为路径
>	- Combine(@"c:\a\","b.txt")   --c:\a\b.txt

```c#
namespace Path类
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = @"C:\\Users\\nanfengqaq\\Desktop\\陕煤项目原型方案(2).rp";
            //打印文件名和扩展名
            Console.WriteLine(Path.GetFileName(str));
            //打印文件名
            Console.WriteLine(Path.GetFileNameWithoutExtension(str));
            //打印文件的扩展名
            Console.WriteLine(Path.GetExtension(str));
            //打印文件所在的文件夹的名称
            Console.WriteLine(Path.GetDirectoryName(str));
            //打印文件的全路径/绝对路径
            Console.WriteLine(Path.GetFullPath(str));
            //连接两个字符串作为路径
            Console.WriteLine(Path.Combine(@"c:\a\","b.txt"));
        }
    }
}
```
![[Pasted image 20241107231718.png]]

# File 类   --一次性全部读取

>- 创建文件
>	-  //在桌面创建一个名为test的txt文件       File.Create(@"C:\Users\nanfengqaq\Desktop\test.txt");
>- 删除文件
>	- File.Delete(@"C:\Users\nanfengqaq\Desktop\test.txt");
>- 逐行读取
>	- ReadAllLines(@"C:\Users\nanfengqaq\Desktop\dcoker.txt",Encoding.Default)


```c#
using System.Text;

namespace File类
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 创建和删除文件
            //在桌面创建一个名为test的txt文件
            //File.Create(@"C:\Users\nanfengqaq\Desktop\test.txt");
            //Console.WriteLine("创建完成！");


            //删除指定的文件  --若文件存在则成功删除！如果不存在会怎么样？
            //这种方式不管文件是否存在都会打印删除成功；而不会抛异常，所以下面的更合理
            //File.Delete(@"C:\Users\nanfengqaq\Desktop\test.txt");
            //Console.WriteLine("删除成功！");
            //var filePath = @"C:\Users\nanfengqaq\Desktop\test.txt";
            //在桌面创建一个名为test的txt文件
            //if (!File.Exists(filePath))
            //{
            //    using (File.Create(filePath)) ;
            //    Console.WriteLine("创建完成！");
            //}
            //else
            //{
            //    Console.WriteLine("文件已存在！");
            //}
            ////删除指定的文件  --若文件存在则成功
            //if (File.Exists(filePath))
            //{
            //    File.Delete(filePath);
            //    Console.WriteLine("删除成功！");
            //}
            //else
            //{
            //    Console.WriteLine("文件不存在！");
            //}
            #endregion
            #region 逐行读取
            string [] str = File.ReadAllLines(@"C:\Users\nanfengqaq\Desktop\dcoker.txt",Encoding.Default);
            foreach (var item in str)
            {
                Console.WriteLine(item);
            }
            
            string [] s = File.ReadAllLines(@"C:\Users\nanfengqaq\Desktop\dcoker.txt", Encoding.Default);
            Console.WriteLine(s);
            #endregion


        }
    }
}
```
# 编码
>定义：
>将字符串以什么样的形式保存为二进制，这个就是编码 
>编码的发展历史：
>ASC (128) → ASCII(256) → GB2312(简体字) → Big5繁体字 → unicode （解析慢） → UTF-8  web 
>乱码：
>产生乱码的原因：就是你保存这个文件所采用的编码，跟你打开这个文件所采用的编码格式不一样
>
# 装箱和拆箱     --避免装箱和拆箱   -因为转换是在内存中完成的需要消耗资源
## 装箱
将值类型转化为引用类型
```c#
int i = 1;
object obj = i;
```
## 拆箱   --强转
把引用类型转为值类型
```c#
string str = "111";
int s = (int)str;
```

### 看两种类型是否发生了拆箱和装箱
>如果存在继承关系，可能发生
>如果不存在，则不可能发生

# 使用FileStream来读写文件    -- 操作字节的（一点一点读）
>FileStream    操作字节的（操作所有的文件） 
>StreamReader和StreamWrite 操作字符的
## FileStream 读取文件
```c#
            #region FileStream读取数据    .Net Core
            //1.创建新的FileStream的类读取文件，第一个参数是文件的地址，第二个参数是对那个文件做什么操作，第三个参数表示对文件里的数据做什么操作
            FileStream fileStream = new FileStream(@"C:\Users\nanfengqaq\\Desktop\test.txt", FileMode.OpenOrCreate,FileAccess.Read);
            //2.读取文件
            byte[] bytes = new byte[1024*1024*5];
            //返回本次实际读取到的有效字节数
            int r = fileStream.Read(bytes,0,bytes.Length);
            //将字节数组中每一个元素按指定的编码格式解码成字符串
            string st = Encoding.UTF8.GetString(bytes); //0--从第0个索引开始解码，到第r个
            //关闭流
            fileStream.Close();
            //释放流占用的资源
            fileStream.Dispose();
            Console.WriteLine(st);
            #endregion
```
## FileStream写入文件
```c#
   #region  FileStream写入数据
   using( FileStream fileStream = new FileStream(@"C:\Users\nanfengqaq\\Desktop\test.txt", FileMode.OpenOrCreate, FileAccess.Write))
   {
       string st2 = "覆盖后的内容";
       byte [] buffer = Encoding.UTF8.GetBytes(st2);
       fileStream.Write(buffer, 0, buffer.Length);
       Console.WriteLine("写入OK！");
   }

   #endregion
```
## 将创建文件流对象的过程写在using中会自动帮我们释放所占用的资源
## 使用FileStream实现多媒体文件的复制[[C Shrap 练习题：#36.使用FileStream实现多媒体文件复制]]
## StreamReader和StreamWriter 的使用
```C#
namespace StreamReader和StreamWriter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //使用StreamReader读取文件
            using (StreamReader sr = new StreamReader(@"C:\Users\nanfengqaq\Desktop\test.txt"))
            {
                Console.WriteLine(sr.ReadLine());
            }

            //使用StreamWriter写入文件
            using (StreamWriter sw = new StreamWriter(@"C:\Users\nanfengqaq\Desktop\test.txt"))
            {
                sw.WriteLine("Hello World!");
            }
        }
    }
}
```

# 多态
## 实现多态的手段
### 1）虚方法
>将父类的方法标记成虚方法，使用关键字virtual,在子类中重写父类的虚方法使用关键字override

### 2）抽象类
>当父类中断方法不知道如何去实现时，可以将父类写成抽象类，将父类中的方法写成抽象方法
### 3） 接口

# 补充：抽象类的特点
>1.抽象成员必须标记为abstract ，并且不能有任何实现
>2.抽象成员必须在抽象类中
>3.抽象类不能被实例化
>4.子类继承抽象类后，必须把父类中的所有抽象成员都重写（除非子类也是一个抽象类，则可以不用重写）
>5.抽象成员访问修饰符不能是private
>6.在抽象类中可以包含实例成员，并且抽象类的实例成员可以不被子类实现
>7.抽象类是有构造函数的，虽然不能被实例化。
>8.如果父类的抽象方法中有参数，那么继承这个抽象父类的子类在重写父类的方法的时候必须传入相应的参数。如果抽象父类的抽象方法中有返回值，那么子类在重写这个抽象方法的时候，也必须要传入返回值
>====
>如果父类中的方法有默认的实现，并且父类需要被实例化，这时可以考虑将父类定义成一个普通类，用虚方法来实现多态
>如果父类中的方法没有默认实现，父类也不需要被实例化，则可以将该类定义成一个抽象类

# 访问修饰符
>public :公开的；公共的
>private : 私有的，只能在当前类的内部访问
>protected :受保护的，只能在当前类的内部以及该类的子类中访问
>internal: 只能在当前项目中访问，在同一个项目中，internal和public 的权限是一样的
>protected internal : protected+internal

>1、能够修饰类的访问修饰符只有两个：public 、internal
>2、可访问性不一致
>子类的访问权限不能高于父类的访问权限

# 设计模式
>设计这个项目的一个方式。

## 01 简单工厂设计模式
# 值类型和引用类型

## 字符串的不可变性
```c#
namespace 值类型和引用类型
{
    internal class Program
    {
        static void Main(string[] args)
        {
            person p =new person();
            p.Name="nanfeng";
            person p2 = p;
            p2.Name = "nanfeng2";
            Console.WriteLine(p.Name+p2.Name);


            string s1 = "nanfeng";
            string s2 = s1;
            s2 = "nanfeng2";
            Console.WriteLine(s1+s2);
            
        }

        public class person
        {
            private string name;


            public string Name { get => name; set => name = value; }
        }
    }
}
```
# 序列化和反序列化 --传递数据
>序列化：将对象转换为二进制
>反序列化：将二进制转换为对象

作用：传输数据
## 序列化：
1、将这个类标记为可以被序列化的  在类的上面加上[Serializable]
2、开始序列化对象 BinaryFormatter    BinaryFormatter bf = new BinaryFormatter
# partial 部分类
# seaked 密封类 ：不能被其他类继承，但是可以继承其他类
# 接口：
>接口：就是一个规范、能力  
>	只要一个类继承了一个接口，这个类就必须实现这个接口中所有的成员
>	为了多态接口不能被实例化也就是说接口不能被new(不能创建对象)
>接口中的成员不允许添加访问修饰符，默认public 而类默认private
>接口中不允许写方法体
>接口中不允许写字段
>接口中可以写自动属性
>接口和接口之间可以继承并且可以多继承，但是类有单根性，即一个子类只允许有一个父类
>接口不能去继承一个类，而类可以继承接口（接口只能继承于接口，而类既可以继承于接口，也可以继承于类）
>实现接口的子类必须实现该接口的所有成员
>一个类同时继承类和接口的时候，在语法上必须要将类写在接口的前面

>自动属性和普通属性的区别是？
>自动属性没有字段和方法体
>自动属性本质还是get,set

```c#
namespace 自动属性和普通属性
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        public class Person
        {
            private string _name;
            public string Name
            {
                get { return Name; }
                set { Name = value; }
            }

            /// <summary>
            /// 自动属性
            /// </summary>
            public int Age
            { 
                get; set; 
            }
        }

    }
}
```

# 多态相关的总结
>1.什么时候用虚方法实现多态？
>		可以找到父类可以写方法
>2.什么时候用抽象类实现多态？
>		可以找到父类，无法写方法
>3.什么时候用接口实现多态？
>		找不出父类