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
