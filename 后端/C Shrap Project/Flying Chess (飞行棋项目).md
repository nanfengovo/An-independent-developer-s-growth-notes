![[骑士飞行棋.pdf]]
# 绘制游戏头：
```c#
    /// <summary>
    /// 绘制飞行棋游戏头
    /// </summary>
    public static void GameShow()
    {
        Console.WriteLine("**************************************************************************", Console.ForegroundColor = ConsoleColor.Blue);
        Console.WriteLine("*                                   飞                                   *", Console.ForegroundColor = ConsoleColor.Yellow);
        Console.WriteLine("*                                   行                                   *", Console.ForegroundColor = ConsoleColor.Green);
        Console.WriteLine("*                                   棋                                   *", Console.ForegroundColor = ConsoleColor.Red);
        Console.WriteLine("*                                   游                                   *", Console.ForegroundColor = ConsoleColor.Gray);
        Console.WriteLine("*                                   戏                                   *", Console.ForegroundColor = ConsoleColor.Green);
        Console.ResetColor();
        Console.WriteLine("**************************************************************************");
    }
```
>关键代码解释：
>1.  Console.WriteLine("**************************************************************************", Console.ForegroundColor = ConsoleColor.Blue);      --表示控制台打印输出的前景色（文字的颜色是Blue）
>2. Console.ResetColor();    -- 表示回复控制台的默认颜色

