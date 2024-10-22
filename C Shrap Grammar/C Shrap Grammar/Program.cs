namespace C_Shrap_Grammar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 变量  先申明再赋值
            int i = 3;
            //浮点类型 double 小数点后15~16位
            double j = 3.14;
            double k = 3;
            double l = 3.141111111111111111111111111111;
            //打印出来就有15位
            Console.WriteLine(l);
            //金钱类型
            decimal money = 5000m;
            #region  string 和 String 的区别  : String 是.NET 平台下的字符串类 ，string 是 C# 中的字符串类
            String str = "Hello World";
            string str2 = "Hello World";
            Console.WriteLine(str);
            Console.WriteLine(str2);
            #endregion
            #endregion
        }
    }
}
