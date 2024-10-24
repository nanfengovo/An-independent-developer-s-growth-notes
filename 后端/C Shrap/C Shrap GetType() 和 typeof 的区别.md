GetType和typeof()都能获得数据类型System.Type.
1:GetType()方法继承自0bject,因此C#中任何对象都具有GetType()方法，t.GetType(),其中t为变量名2:typeof是操作符，typeof(t)的t必须是具体的类型名称，不可以是变量名称。
比如有这样一个变量i:
string str = new string();
使用GetType()，str.GetType()返回值是string的类型，但是无法使用typeof(str)，因为str是一个变量使用typeof0)，则只能:typeof(string)，返回的同样是string的类型。
获取到System.Type就能获得类型中的方法，变量，所在命名空间等信息。
例子：
```c#
string str = "111";
Console.WriteLine("使用GetType（）可以获取到具体某一个变量的数据类型；比如下面获取变量str的类型：");
Console.WriteLine(str.GetType());
Console.WriteLine("使用typeof(数据类型)不能获取到某一个具体的变量类型");
Console.WriteLine(typeof(string));
Console.WriteLine(typeof(int));
```
上述代码的输出为：
``` 
使用GetType（）可以获取到具体某一个变量的数据类型；比如下面获取变量str的类型：
System.String
使用typeof(数据类型)不能获取到某一个具体的变量类型
System.String
System.Int32
```