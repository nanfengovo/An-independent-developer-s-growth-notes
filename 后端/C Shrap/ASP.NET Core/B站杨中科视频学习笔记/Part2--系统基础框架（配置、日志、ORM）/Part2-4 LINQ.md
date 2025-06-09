# 为什么要学习linq  ：使处理数据变得简单
## 需求：
统计一个字符串中每个字母出现的频率（忽略大小写），然后按照从高到低的顺序输出出现频率高于两次的单词和其出现的频率
```
var items = s.Where(c => char.IsLetter(c))//过滤非字母
			.Select(c => char.ToLower(c))//大写字母转小写
			.GroupBy(c => c)//根据字母分组
			.Where(g => g.Count()>2)//过滤掉出现次数<=2
			.OrderByDescending(g => g.Count())//按次数排序
			.Select(g => new {Char = g.Key, Count = g.Count()})
```

## 委托——>lambda——>LINQ

### 委托
1、委托是指向方法的类型，调用委托变量时执行的就是变量指向的方法
2、.NET中定义了泛型委托Action(无返回值)和Func（有返回值），所以一般不用自定义委托

#### Demo 自定义 委托
##### 不带返回值的委托
** delegate void d(); ** 

```
namespace 委托
{
    delegate void d();

    internal class Program
    {
        static void Main(string[] args)
        {
            d d1 = F1;
            d1();
           
        }

        public static void F1()
        {
            Console.WriteLine("我是F1");
        }

        public static void F2()
        {
            Console.WriteLine("我是F2");
        }
    }
}
```

输出为：
我是F1

```
namespace 委托
{
    delegate void d();

    internal class Program
    {
        static void Main(string[] args)
        {
            d d1 = F1;
            d1();
            d1 = F2;
            d1();
           
        }

        public static void F1()
        {
            Console.WriteLine("我是F1");
        }

        public static void F2()
        {
            Console.WriteLine("我是F2");
        }
    }
}
```

输出：
我是F1
我是F2

##### 带返回值
```
namespace 委托
{
    delegate void d();
    delegate int b(int i,int j );
    internal class Program
    {
        static void Main(string[] args)
        {
            d d1 = F1;
            d1();
            d1 = F2;
            d1();
            b b1 = F3;
            b1(3, 5);
           
        }

        public static void F1()
        {
            Console.WriteLine("我是F1");
        }

        public static void F2()
        {
            Console.WriteLine("我是F2");
        }

        public static int F3(int a ,int b)
        {
              Console.WriteLine($"{a+b}");
			  return a;
        }
    }
}

```
输出
我是F1
我是F2
8
### Lambda是怎么来的
#### Demo
##### 没有参数没有返回值的匿名方法
```
namespace 委托
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Action f1 = delegate ()
            {
                Console.WriteLine("我是AAA");
            };
            f1();
        }

       
    }
}
```
输出：
我是AAA

##### 带参数的匿名函数
```
namespace 委托
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Action f1 = delegate ()
            {
                Console.WriteLine("我是AAA");
            };
            f1();

            Action<int,int> f2 = delegate (int i, int j)
            {
                Console.WriteLine($"i ={i},j={j}");
            };
            f2(1,2);
        }

       
    }
}
```
输出：
我是AAA
i =1,j=2
#####  带参数带返回值的匿名函数
```
namespace 委托
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Action f1 = delegate ()
            {
                Console.WriteLine("我是AAA");
            };
            f1();

            Action<int,int> f2 = delegate (int i, int j)
            {
                Console.WriteLine($"i ={i},j={j}");
            };
            f2(1,2);

            Func<int, int, int> f3 = delegate (int i, int j)
            {
                return i + j;
            };
            Console.WriteLine(f3(1, 2));
            
        }

       
    }
}

```
输出
我是AAA
i =1,j=2
3
#### 进入主题 Lambda表达式
匿名方法可以写出lambda表达式
Func<int,int,string> f1 = (i1,i2)=>{
	return $"{i1}+{i2}={i1+i2}";
};
可以省略参数数据类型，因为编译能根据委托类型推断出参数的类型，用=>引出来方法体
#### Demo
```
namespace 委托
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Action f1 = delegate ()
            {
                Console.WriteLine("我是AAA");
            };
            f1();

            Action<int,int> f2 = delegate (int i, int j)
            {
                Console.WriteLine($"i ={i},j={j}");
            };
            f2(1,2);

            Func<int, int, int> f3 = delegate (int i, int j)
            {
                return i + j;
            };
            Console.WriteLine(f3(1, 2));
            
            Func<int,int,int> f4 = (int i,int j)=> { return i + j; };

            Console.WriteLine(f4(1,2));
        }

       
    }
}

```

这里f3和f4的输出是一样的所以
可以把delegate 换成 => (“=>” 读作goes to)
在上面的例子中还可以省略参数的数据类型，因为编译器可以推断
即
```
 Func<int, int, int> f5 = (i,j) => { return i + j; };

 Console.WriteLine(f5(1, 2));
```
> 如果委托没有返回值且方法体只有一行代码，可以省略{}

```
 Action f1 = delegate ()
 {
     Console.WriteLine("我是AAA");
 };
 f1();

 Action f11 =() => Console.WriteLine("我是AAA");

 Action<int,int> f2 = delegate (int i, int j)
 {
     Console.WriteLine($"i ={i},j={j}");
 };
 f2(1,2);

 Action <int,int> f22 = (int i, int j) => Console.WriteLine($"i ={i},j={j}");

```

> 如果=> 后的方法体中只有一行代码，且方法体有返回值，可以省略方法体的{}和return

```
            Func<int, int, int> f5 = (i,j) => { return i + j; };

            Console.WriteLine(f5(1, 2));

            Func<int, int, int> f6 = (i, j) =>  i + j;

            Console.WriteLine(f5(1, 2));
```

> 如果只有一个参数，参数的（）可以省略

#### 还原下面的Lambda表达式
```
Action<string> f7 = s => Console.WriteLine(s);
```
```
Action<string> f77 = (string s) => { Console.WriteLine(s); };
```

#### 简化下面的式子
```
Func<int, bool> f8 = delegate (int i)
{
    return i > 0;
};
```

```
Func<int, bool> f88 = i => i > 0;
```
写到这，感慨下语法糖真的是太甜了 🤐

## 揭秘LINQ方法的背后 ——简化数据处理
### 入门案例：
> 对于int[] nums = new [] {1,2,3,2,1,23,25} 打印大于10
```
namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //对于int[] nums = new [] {1,2,3,2,1,23,25} 打印大于10
            int[] nums = new[] { 1, 2, 3, 2, 1, 23, 25 };
            //法1
            foreach (var item in nums)
            {
                if(item > 10)
                {
                    Console.WriteLine(item);
                }
            }

            //法2
            var nums2 = nums.Where(x => x > 10).ToArray();
            foreach (var item in nums2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
```

####  自己实现一个where方法
```
 static IEnumerable<int> MyWhere(IEnumerable<int> items,Func<int,bool> f)
 {
     List<int> result = new List<int>();
     foreach (var item in items)
     {
         if(f(item))
         {
             result.Add(item);
         }
     }
     return result;
 }
```

那么上述题目就还有一种实现方法
```
//法3
var num3 = MyWhere(nums, a => a > 10);
foreach (var item in num3)
{
    Console.WriteLine(item);
}
```
#### 使用yieId
```
static IEnumerable<int> MyWhere(IEnumerable<int> items,Func<int,bool> f)
{
    foreach (var item in items)
    {
        if(f(item))
        {
            yield return item;
        }
    }
    
}
```

>  yieId : 满足条件的数据立即返回，继续处理下一条，数据处理的效率高

## Linq中常用的扩展方法
> 在System.Linq命名空间中

### 准备初始数据
```
public class Employee
{
    public long Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public bool Gender { get; set; }

    public int Salary { get; set; }

    public override string ToString()
    {
        return $"Id = {Id},Name = {Name}, Age = {Age}, Gender = {Gender} ,Salary = {Salary}";
    }
}
```
```
 static void Main(string[] args)
 {
     List<Employee> list = new List<Employee>();
     list.Add(new Employee { Id = 1001, Name = "刘磊", Age = 51, Gender = false, Salary = 9797 });
     list.Add(new Employee { Id = 1002, Name = "11", Age = 16, Gender = true, Salary = 13968 }); list.Add(new Employee { Id = 1001, Name = "刘1", Age = 21, Gender = false, Salary = 9737 });
     list.Add(new Employee { Id = 1002, Name = "21", Age = 49, Gender = true, Salary = 3968 }); list.Add(new Employee { Id = 1001, Name = "刘2磊", Age = 51, Gender = false, Salary = 4757 });
     list.Add(new Employee { Id = 1002, Name = "131", Age = 16, Gender = true, Salary = 8968 }); list.Add(new Employee { Id = 1001, Name = "刘3磊", Age = 91, Gender = false, Salary = 8797 });
     list.Add(new Employee { Id = 1002, Name = "31", Age = 26, Gender = true, Salary = 6968 }); list.Add(new Employee { Id = 1001, Name = "刘4磊", Age = 81, Gender = false, Salary = 5797 });
     list.Add(new Employee { Id = 1002, Name = "刘芳", Age = 36, Gender = true, Salary = 5968 }); list.Add(new Employee { Id = 1001, Name = "刘5磊", Age = 11, Gender = false, Salary = 9777 });
     list.Add(new Employee { Id = 1002, Name = "周勇", Age = 74, Gender = true, Salary = 6968 }); list.Add(new Employee { Id = 1001, Name = "刘6磊", Age = 15, Gender = false, Salary = 7897 });
     list.Add(new Employee { Id = 1002, Name = "刘涛", Age = 46, Gender = true, Salary = 6968 }); list.Add(new Employee { Id = 1001, Name = "刘7磊", Age = 18, Gender = false, Salary = 5497 });
     list.Add(new Employee { Id = 1002, Name = "周勇", Age = 56, Gender = true, Salary = 6968 }); list.Add(new Employee { Id = 1001, Name = "刘8磊", Age = 51, Gender = false, Salary = 5457 });
     list.Add(new Employee { Id = 1002, Name = "李伟", Age = 44, Gender = true, Salary = 1368 });
 }
```
### 常用扩展方法
#### Where:
> 每一项数据都会经过predicate的测试，如果针对一个元素，predicate执行的返回值为true ,那么这个元素就会放到返回值中
> where参数是一个lambda表达式格式的匿名方法，方法的参数e表示当前判断的元素对象。参数的名字不一定非叫e,不过一般lambda表达式中的变量名长度都不长
##### 输出上面年龄大于30的
```
#region Where
list.Where(x => x.Age > 30).ToList().ForEach(x => Console.WriteLine(x));
#endregion
```

#### Count：
> 获取数据条数

```
  #region Count
  var count = list.Count(x => x.Age > 30);
  Console.WriteLine(count);
  #endregion
```
如果用的是上述数据的话输出应该是11
#### Any
> 是否至少有一条数据

```
            #region Any
            //是否有名字叫张三的如果有返回true，没有返回false
            var isExist = list.Any(x => x.Name == "张三");
            Console.WriteLine(isExist);
            #endregion
```
输出false
#### 获取一条数据（是否带参数的两种写法）
##### Single
> 有且只有一条满足要求的数据
> 	只能筛选一条数据，如果筛选的数据多余一条就会报错（System.InvalidOperationException:“Sequence contains more than one element”），如果没有符合条件的也会报错

###### 筛选的数据多余1条
```
#region Single
Console.WriteLine(list.Single());
#endregion
```
输出异常：System.InvalidOperationException:“Sequence contains more than one element”
###### 筛选的数据刚好1条
```
Console.WriteLine(list.Where(x => x.Name == "11").Single());
```
输出对象
>Id = 1002,Name = 11, Age = 16, Gender = True ,Salary = 13968

上述的写法还可以写成下面的
```
#region Single
Console.WriteLine(list.Where(x => x.Name == "11").Single());
Console.WriteLine(list.Single(x => x.Name == "11"));
#endregion
```
###### 筛选的数据小于一条
```
 #region Single
 Console.WriteLine(list.Where(x => x.Name == "张三").Single());
 #endregion
```
输出异常：System.InvalidOperationException:“Sequence contains no elements”






##### SingleOrDefault
> 最多只有一条满足要求的数据

##### First
> 至少有一条，返回第一条

##### FirstOrDefault
> 返回第一条或者默认值

> 防御性编程：选择合适的方法