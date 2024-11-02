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


、、
