# is
## is 用来判断某个变量是不是某个类型；返回的结果是bool型
ex：
```c#
  #region is 判断某个变量是不是某个类型
  object o = new object();
  int num = 0;
  if (o is object)
  {
      Console.WriteLine("o是object类型的");
  }
  else
  {
      Console.WriteLine("o不是object类型的");
  }

  if (num is int)
  {
      Console.WriteLine(num is int);
      Console.WriteLine("变量num是int型");
  }
  else
  {
      Console.WriteLine("变量num不是int型");
  }
  #endregion
```
结果为：
```
o是object类型的
True
变量num是int型
```
## is 和[[C Shrap GetType() 和 typeof 的区别]]

# as

## as操作符用于将一个对象强制转换为指定的类型;如果要进行转换的类型和目标类型不兼容，则返回null

