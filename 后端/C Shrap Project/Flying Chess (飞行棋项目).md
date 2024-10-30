# 基础知识储备：
>需要具备的基础知识储备：
>- C#基础语法
>- 如何改变控制台的前景色（文字颜色）和如何恢复默认颜色
>- 控制台中全角半角的相关概念：两个半角所占的位置等于一个全角所占的位置
>- shift+空格 ：切换全角半角

# 需求：
![[骑士飞行棋.pdf]]
# 开发步骤：
## 1.绘制游戏头：
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

## 2.初始化地图（加载地图所需要的资源） --为画地图做准备
> 将整数数组中的数字变成控制台中特殊类型的字符串的过程就是初始化地图
--Maps[i]=0:普通关卡 □；Maps[i]=1:幸运轮盘  ◎；Maps[i]=2:地雷 ☆；Map[i]=3:暂停 ▲ ；Map[i]=4 :时空隧道 卐
>int[] map = new int[100];   //对战地图
>int[] luckyTurn = {6, 23, 40, 55, 69, 83}; //幸运轮盘    1
>int[] landMine = {5, 13, 17, 33, 38, 50, 64, 80, 94};   //地雷位置  2
>int[] pause = {9, 27, 60, 93};         //暂停   3
>int[] timeTunnel = {20, 25, 45, 63, 72, 88, 90};   //时空隧道  4

![[df027e7b096a50fc01b4b8a11afb814.jpg]]





















