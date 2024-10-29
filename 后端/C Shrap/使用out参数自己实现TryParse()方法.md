```c#
 /// <summary>
 /// 使用out参数自己实现 TryParse()方法
 /// </summary>
 /// <param name="s">需要转换的</param>
 /// <param name="result">转换后的结果</param>
 /// <returns>是否成功转换</returns>
 public static bool MyTryParse(string s,out int result)
 {
     result = 0;
     try
     {
         result = Convert.ToInt32(s);
         return true;
     }
     catch 
     {

         return false;
     }
 }
```