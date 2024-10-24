# is
is 用来判断某个变量是不是某个类型；返回的结果是bool型
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