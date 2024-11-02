# 基础知识储备：
>需要具备的基础知识储备：
>- C#基础语法
>- 如何改变控制台的前景色（文字颜色）和如何恢复默认颜色  Console.ResetColor()
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



# 由于上述有很多特殊符号我不会打：采取下面的方式
# 图例：幸运轮盘 ＠  地雷：＃   暂停：＄   时空隧道：卐"

# 代码如下：
```c#
namespace Flying_Chess_Game
{
    internal class Program
    {
        //用静态字段来模拟全局变量；使用长度为100的int类型的数组来模拟地图上元素  --Maps[i]=0:普通关卡 □；Maps[i]=1:幸运轮盘  ◎；Maps[i]=2:地雷 ☆；Map[i]=3:暂停 ▲ ；Map[i]=4 :时空隧道 卐
        public static int[] Maps = new int[100];

        //声明一个静态数组用来存储玩家A和玩家B的坐标
        public static int[] PlayerPos = new int[2];

        //存储两个玩家的姓名
        public static string[] PlayerNames = new string[2];

        //布尔类型的数组作为玩家游戏的标记
        public static bool[] IsPlaying = new bool[2];

        static void Main(string[] args)
        {

            //绘制游戏头
            GameShow();
            #region 提示玩家输入姓名
            //玩家A
            Console.WriteLine("请输入玩家A的姓名：");
            PlayerNames[0] = Console.ReadLine();
            while (PlayerNames[0] == "")
            {
                Console.WriteLine("玩家A的姓名不能为空，请重新输入:");
                PlayerNames[0] = Console.ReadLine();
            }
            //玩家B
            Console.WriteLine("请输入玩家B的姓名：");
            PlayerNames[1] = Console.ReadLine();
            while (PlayerNames[1] == "" || PlayerNames[1] == PlayerNames[0])
            {
                if (PlayerNames[1] == "")
                {
                    Console.WriteLine("玩家B的姓名不能为空，请重新输入:");
                    PlayerNames[1] = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("玩家A和玩家B的姓名不能相同，请重新输入:");
                    PlayerNames[1] = Console.ReadLine();
                }

            }
            #endregion
            //玩家姓名输入完成后清屏
            Console.Clear();
            //绘制游戏头
            GameShow();
            Console.WriteLine(PlayerNames[0] + "的士兵用A表示");
            Console.WriteLine(PlayerNames[1] + "的士兵用B表示");
            //Console.WriteLine("图例：幸运轮盘 ＠  地雷：＃   暂停：＄   时空隧道：卐");

            //初始化地图
            InitailMap();
            //绘制地图  在绘制地图前一定要先初始化地图
            DrawMap();

            #region 开始游戏
            //当玩家A和玩家B没有一个人在终点的时候，两个玩家不停的玩游戏
            while (PlayerPos[0] < 99 || PlayerPos[1] < 99)
            {
                if (IsPlaying[0] == false)
                {
                    PlayGame(0);
                }
                else 
                {
                    IsPlaying[0] = false;
                }
                if (PlayerPos[0] >=99)
                {
                    Console.WriteLine($"玩家{PlayerNames[0]}赢了,游戏结束！", Console.ForegroundColor = ConsoleColor.Red);
                    break;
                }
                if (IsPlaying[1] == false)
                {
                    PlayGame(1);
                }
                else
                {
                    IsPlaying[1] = false;
                }
                if (PlayerPos[1] >= 99)
                {
                    Console.WriteLine($"玩家{PlayerNames[1]}赢了,游戏结束！", Console.ForegroundColor = ConsoleColor.Red);
                    break;
                }


            }
            Console.WriteLine("\r\n██╗   ██╗██╗ ██████╗████████╗ ██████╗ ██████╗ ██╗   ██╗\r\n██║   ██║██║██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗╚██╗ ██╔╝\r\n██║   ██║██║██║        ██║   ██║   ██║██████╔╝ ╚████╔╝ \r\n╚██╗ ██╔╝██║██║        ██║   ██║   ██║██╔══██╗  ╚██╔╝  \r\n ╚████╔╝ ██║╚██████╗   ██║   ╚██████╔╝██║  ██║   ██║   \r\n  ╚═══╝  ╚═╝ ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝   \r\n                                                       \r\n");
            #endregion
            //PlayerPosChange();
            DrawMap();
        }
        #region 绘制飞行棋游戏头
        /// <summary>
        /// 绘制飞行棋游戏头
        /// </summary>
        public static void GameShow()
        {
            Console.WriteLine("****************************************************************", Console.ForegroundColor = ConsoleColor.Blue);
            Console.WriteLine("*                              飞                              *", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("*                              行                              *", Console.ForegroundColor = ConsoleColor.Green);
            Console.WriteLine("*                              棋                              *", Console.ForegroundColor = ConsoleColor.Red);
            Console.WriteLine("*                              游                              *", Console.ForegroundColor = ConsoleColor.Gray);
            Console.WriteLine("*                              戏                              *", Console.ForegroundColor = ConsoleColor.Green);
            Console.ResetColor();
            Console.WriteLine("****************************************************************");
        }
        #endregion

        #region 初始化地图
        /// <summary>
        /// 初始化地图
        /// </summary>
        public static void InitailMap()
        {

            int[] luckyTurn = { 6, 23, 40, 55, 69, 83 }; //幸运轮盘    1
            for (int i = 0; i < luckyTurn.Length; i++)
            {
                //int index = luckyTurn[i];
                //Maps[index] = 1;
                Maps[luckyTurn[i]] = 1;
            }


            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };   //地雷位置  2
            for (int i = 0; i < landMine.Length; i++)
            {
                Maps[landMine[i]] = 2;
            }


            int[] pause = { 9, 27, 60, 93 };         //暂停   3
            for (int i = 0; i < pause.Length; i++)
            {
                Maps[pause[i]] = 3;
            }


            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };   //时空隧道  4
            for (int i = 0; i < timeTunnel.Length; i++)
            {
                Maps[timeTunnel[i]] = 4;
            }
        }
        #endregion

        #region 绘制地图
        /// <summary>
        /// 绘制地图中的元素
        /// </summary>
        public static void DrawMap()
        {
            #region 绘制图例
            Console.Write("图例：");
            Console.Write("幸运轮盘 :＠\t", Console.ForegroundColor = ConsoleColor.Green);
            Console.Write("地雷 :＃\t", Console.ForegroundColor = ConsoleColor.Red);
            Console.Write("暂停 :＄\t", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("时空隧道 :卐\t", Console.ForegroundColor = ConsoleColor.DarkBlue);
            Console.ResetColor();
            #endregion
            #region 第一横行
            for (int i = 0; i < 30; i++)
            {
                Console.Write(DrawStringMap(i)); ;

            }
            #endregion
            //画完第一横行后，换行
            Console.WriteLine();
            #region 第一竖行
            for (int i = 30; i < 35; i++)
            {
                for (int j = 0; j < 29; j++)
                {
                    Console.Write("  ");
                }
                Console.Write(DrawStringMap(i)); ;
                Console.WriteLine();
            }
            #endregion
            #region 第二横行
            for (int i = 64; i >= 35; i--)
            {
                Console.Write(DrawStringMap(i));
            }
            #endregion

            //画完第二横行后，换行
            Console.WriteLine();
            #region 第二竖行
            for (int i = 65; i <= 69; i++)
            {
                Console.WriteLine(DrawStringMap(i));
            }
            #endregion
            #region 第三横行
            for (int i = 70; i <= 99; i++)
            {
                Console.Write(DrawStringMap(i));
            }
            #endregion

            //画完最后一行后，换行
            Console.WriteLine();

        }
        #endregion

        #region 绘制地图中的特殊元素
        /// <summary>
        /// 绘制地图中的特殊元素
        /// </summary>
        /// <param name="i"></param>
        public static string DrawStringMap(int i)
        {
            string str = "";

            //如果玩家A和玩家B的坐标相同，画一个尖括号
            if (PlayerPos[0] == PlayerPos[1] && PlayerPos[0] == i)
            {
                str = "<>";
                //Console.Write(" ＜＞");
            }
            else if (PlayerPos[0] == i)  //玩家A在第一行但是玩家A和玩家B的坐标不一样
            {
                //使用shift+空格切换全角和半角
                str = "Ａ";
            }
            else if (PlayerPos[1] == i)  //玩家B在第一行但是玩家A和玩家B的坐标不一样
            {
                //使用shift+空格切换全角和半角
                str = "Ｂ";
            }
            else
            {
                switch (Maps[i])
                {
                    //普通的地图元素
                    case 0:
                        str = "[]";
                        break;
                    //幸运轮盘
                    case 1:
                        //Console.ForegroundColor = ConsoleColor.Green;
                        //str ="＠" ;
                        //Console.ResetColor();
                        PrintElement("＠");
                        break;
                    //地雷
                    case 2:
                        //Console.ForegroundColor = ConsoleColor.Red;
                        //str = "＃";
                        //Console.ResetColor();
                        PrintElement("＃");
                        break;
                    //暂停
                    case 3:
                        //Console.ForegroundColor = ConsoleColor.Yellow;
                        //str = "＄";
                        //Console.ResetColor();
                        PrintElement("＄");
                        break;
                    //时空隧道
                    case 4:
                        //Console.ForegroundColor = ConsoleColor.DarkBlue;
                        //str = "卐";
                        //Console.ResetColor();
                        PrintElement("卐");
                        break;
                }
            }
            return str;

        }
        #endregion

        #region 绘制带颜色的特殊元素
        /// <summary>
        /// 绘制带颜色的特殊元素
        /// </summary>
        /// <param name="str"></param>
        static void PrintElement(string str)
        {
            switch (str)
            {
                case "＠":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("＠");
                    Console.ResetColor();
                    break;
                case "＃":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("＃");
                    Console.ResetColor();
                    break;
                case "＄":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("＄");
                    Console.ResetColor();
                    break;
                case "卐":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("卐");
                    Console.ResetColor();
                    break;

            }

        }
        #endregion


        #region 保证玩家在地图上
        /// <summary>
        /// 玩家坐标改变前调用该方法 （为了省事可以在清空控制台的内容后重新渲染地图的时候调用一次即可）
        /// </summary>
        public static void PlayerPosChange()
        {

            if (PlayerPos[0] < 0)
            {
                PlayerPos[0] = 0;
            }
            if (PlayerPos[1] < 0)
            {
                PlayerPos[1] = 0;
            }
            if (PlayerPos[0] >= 99)
            {
                PlayerPos[0] = 99;
                //IsPlaying[0] = true;
                //IsPlaying[1] = true;
                //Console.WriteLine($"玩家{PlayerNames[0]}赢了,游戏结束！",Console.ForegroundColor = ConsoleColor.Red);
                //Console.ResetColor ();
            }
            if (PlayerPos[1] >= 99)
            {
                PlayerPos[1] = 99;
                //IsPlaying[0] = true;
                //IsPlaying[1] = true;
                //Console.WriteLine($"玩家{PlayerNames[1]}赢了,游戏结束！" ,Console.ForegroundColor    = ConsoleColor.Red);
                //Console .ResetColor ();
            }
        }
        #endregion

        #region 开始游戏
        public static void PlayGame(int i)
        {
            Console.WriteLine(PlayerNames[i] + "按任意键开始掷骰子");
            Console.ReadKey(true);
            Random random = new Random();
            int index = random.Next(1, 7);
            Console.WriteLine(PlayerNames[i] + "掷到了" + index + ",前进" + index + "步");
            PlayerPos[i] += index;
            PlayerPosChange();
            //玩家A可能踩到玩家B
            if (PlayerPos[i] == PlayerPos[1 - i])
            {
                Console.WriteLine("玩家" + PlayerNames[i] + "踩到了玩家" + PlayerNames[1 - i] + ",玩家" + PlayerNames[1 - i] + "退6格");
                PlayerPos[1 - i] -= 6;
                PlayerPosChange();
                Console.ReadKey(true);
            }
            else
            {
                switch (Maps[PlayerPos[i]])
                {
                    case 0:
                        Console.WriteLine("玩家" + PlayerNames[i] + "踩到了方块，这一回合无事发生！");
                        Console.WriteLine("按下任意键继续！玩家" + PlayerNames[i] + "开始移动");
                        Console.ReadKey(true);
                        Console.Clear();
                        DrawMap();
                        Console.WriteLine("玩家" + PlayerNames[i] + "行动完成");
                        Console.WriteLine("按下任意键继续！");
                        Console.ReadKey(true);
                        break;
                    case 1:
                        Console.WriteLine("玩家" + PlayerNames[i] + "踩到了幸运轮盘，输入1代表和对方交换位置！输入2代表轰炸对方，使对方退6格");
                        Console.WriteLine("按下任意键继续！玩家" + PlayerNames[i] + "开始移动");
                        Console.ReadKey(true);
                        Console.Clear();
                        DrawMap();
                        Console.WriteLine("玩家" + PlayerNames[i] + "行动完成");
                        Console.WriteLine("玩家" + PlayerNames[i] + "踩到了幸运轮盘，输入1代表和对方交换位置！输入2代表轰炸对方，使对方退6格");
                        //Console.WriteLine("按下任意键继续！");
                        string input = Console.ReadLine();
                        while (true)
                        {
                            if (input == "1")
                            {
                                //玩家A和玩家B交换位置
                                int temp = PlayerPos[i];
                                PlayerPos[i] = PlayerPos[1 - i];
                                PlayerPos[1 - i] = temp;
                                PlayerPosChange();
                                break;
                            }
                            if (input == "2")
                            {
                                PlayerPos[1 - i] -= 6;
                                PlayerPosChange();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("请输入1或者2，不要输入其他的字符！");
                                input = Console.ReadLine();
                            }
                        }

                        break;
                    case 2:
                        Console.WriteLine("玩家" + PlayerNames[i] + "踩到了地雷，后退6格");
                        Console.WriteLine("按下任意键玩家" + PlayerNames[i] + "开始行动");
                        Console.ReadKey(true);
                        PlayerPos[i] -= 6;
                        PlayerPosChange();
                        Console.Clear();
                        DrawMap();
                        Console.WriteLine("玩家" + PlayerNames[i] + "行动结束");
                        break;
                    case 3:
                        //暂停业务未开发
                        IsPlaying[i] = true;
                        Console.WriteLine("玩家" + PlayerNames[i] + "踩到了暂停，暂停一回合");
                        break;
                    case 4:
                        Console.WriteLine("玩家" + PlayerNames[i] + "遇到时空隧道，前进十格");
                        Console.WriteLine("按下任意键玩家" + PlayerNames[i] + "开始行动");
                        Console.ReadKey(true);
                        PlayerPos[i] += 10;
                        PlayerPosChange();
                        Console.Clear();
                        DrawMap();
                        Console.WriteLine("玩家" + PlayerNames[i] + "行动结束");
                        break;
                }

            }

        }
        #endregion
    }
}


```
# 产品展示：
![[Pasted image 20241101003114.png]]
![[Pasted image 20241101003137.png]]
![[Pasted image 20241101003242.png]]
# 游戏规则（需求）：
>- 两名玩家分别为A和B，A和B在一起的时候地图上显示为“<>”，两名玩家需要在地图上
>- 需要为玩家A和玩家B取名，两名玩家的姓名不能一样且不能为空，在地图上分别用"A"和“B”来表示
>- 在地图上：灰色的方块表示正常的元素，如果玩家踩中无事发生；如果踩中绿色的幸运轮盘，玩家需要输入1或者2来选择相应的奖励,并且玩家只能选择输入1或者2，这里不允许输入其他的字符，如果玩家选择1，表示和另一个玩家交换位置，如果玩家选择2，表示对方后退6格；如果玩家踩到红色的地雷则要后退6格；如果踩中黄色的暂停则下一回合不能掷骰子；如果踩到蓝色的字符则可以前进十格
>- 如果玩家A踩到玩家B，则玩家B后退6格
>- 任意一名玩家到达终点，则提示胜利并打印“victory”艺术字

# 功能模块拆分：
## 绘制游戏头
##  将游戏头封装成方法方便后续刷新使用到可以调用  GameShow()
```c#
 #region 绘制飞行棋游戏头
 /// <summary>
 /// 绘制飞行棋游戏头
 /// </summary>
 public static void GameShow()
 {
     Console.WriteLine("****************************************************************", Console.ForegroundColor = ConsoleColor.Blue);
     Console.WriteLine("*                              飞                              *", Console.ForegroundColor = ConsoleColor.Yellow);
     Console.WriteLine("*                              行                              *", Console.ForegroundColor = ConsoleColor.Green);
     Console.WriteLine("*                              棋                              *", Console.ForegroundColor = ConsoleColor.Red);
     Console.WriteLine("*                              游                              *", Console.ForegroundColor = ConsoleColor.Gray);
     Console.WriteLine("*                              戏                              *", Console.ForegroundColor = ConsoleColor.Green);
     Console.ResetColor();
     Console.WriteLine("****************************************************************");
 }
 #endregion
```
## 初始化地图
## 加载地图中特殊的点位 ，封装成方法，方便后面刷新后调用InitailMap()
>int[] luckyTurn = { 6, 23, 40, 55, 69, 83 }; //幸运轮盘   表示幸运轮盘对应的特殊点位的下标
```c#
 #region 初始化地图
 /// <summary>
 /// 初始化地图
 /// </summary>
 public static void InitailMap()
 {

     int[] luckyTurn = { 6, 23, 40, 55, 69, 83 }; //幸运轮盘    1
     for (int i = 0; i < luckyTurn.Length; i++)
     {
         //int index = luckyTurn[i];
         //Maps[index] = 1;
         Maps[luckyTurn[i]] = 1;
     }


     int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };   //地雷位置  2
     for (int i = 0; i < landMine.Length; i++)
     {
         Maps[landMine[i]] = 2;
     }


     int[] pause = { 9, 27, 60, 93 };         //暂停   3
     for (int i = 0; i < pause.Length; i++)
     {
         Maps[pause[i]] = 3;
     }


     int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };   //时空隧道  4
     for (int i = 0; i < timeTunnel.Length; i++)
     {
         Maps[timeTunnel[i]] = 4;
     }
 }
 #endregion
```

## 但是由于这些特殊的点在地图上是有颜色的，所以我们要在封装一个方法让特殊的点有颜色
```c#
  #region 绘制带颜色的特殊元素
  /// <summary>
  /// 绘制带颜色的特殊元素
  /// </summary>
  /// <param name="str"></param>
  static void PrintElement(string str)
  {
      switch (str)
      {
          case "＠":
              Console.ForegroundColor = ConsoleColor.Green;
              Console.Write("＠");
              Console.ResetColor();
              break;
          case "＃":
              Console.ForegroundColor = ConsoleColor.Red;
              Console.Write("＃");
              Console.ResetColor();
              break;
          case "＄":
              Console.ForegroundColor = ConsoleColor.Yellow;
              Console.Write("＄");
              Console.ResetColor();
              break;
          case "卐":
              Console.ForegroundColor = ConsoleColor.DarkBlue;
              Console.Write("卐");
              Console.ResetColor();
              break;

      }

  }
  #endregion
```
## 绘制地图  --封装成一个完整的方法在内部调用其他的方法来完善
### 分析一下地图：

![](https://i-blog.csdnimg.cn/blog_migrate/79adfd9ce6da34419b10af02926cb3ac.png)
>如上图所示：
>1.图上一共100个元素，如果用int型的数组保存，数组下标到99；
>2.地图可以拆分成由三个横行和两个竖行组成的
>3.每次刷新地图上面的图例都需要重新打印

#### 绘制图例
```c#
 #region 绘制图例
 Console.Write("图例：");
 Console.Write("幸运轮盘 :＠\t", Console.ForegroundColor = ConsoleColor.Green);
 Console.Write("地雷 :＃\t", Console.ForegroundColor = ConsoleColor.Red);
 Console.Write("暂停 :＄\t", Console.ForegroundColor = ConsoleColor.Yellow);
 Console.WriteLine("时空隧道 :卐\t", Console.ForegroundColor = ConsoleColor.DarkBlue);
 Console.ResetColor();
 #endregion
```

#### 绘制第一横行    --需要绘制地图上的特殊元素 封装成DrawStringMap()
```c#
 #region 第一横行
 for (int i = 0; i < 30; i++)
 {
     Console.Write(DrawStringMap(i)); ;

 }
 #endregion

```
##### 绘制地图中的特殊元素
```c# 
 #region 绘制地图中的特殊元素
 /// <summary>
 /// 绘制地图中的特殊元素
 /// </summary>
 /// <param name="i"></param>
 public static string DrawStringMap(int i)
 {
     string str = "";

     //如果玩家A和玩家B的坐标相同，画一个尖括号
     if (PlayerPos[0] == PlayerPos[1] && PlayerPos[0] == i)
     {
         str = "<>";
         //Console.Write(" ＜＞");
     }
     else if (PlayerPos[0] == i)  //玩家A在第一行但是玩家A和玩家B的坐标不一样
     {
         //使用shift+空格切换全角和半角
         str = "Ａ";
     }
     else if (PlayerPos[1] == i)  //玩家B在第一行但是玩家A和玩家B的坐标不一样
     {
         //使用shift+空格切换全角和半角
         str = "Ｂ";
     }
     else
     {
         switch (Maps[i])
         {
             //普通的地图元素
             case 0:
                 str = "[]";
                 break;
             //幸运轮盘
             case 1:
                 //Console.ForegroundColor = ConsoleColor.Green;
                 //str ="＠" ;
                 //Console.ResetColor();
                 PrintElement("＠");
                 break;
             //地雷
             case 2:
                 //Console.ForegroundColor = ConsoleColor.Red;
                 //str = "＃";
                 //Console.ResetColor();
                 PrintElement("＃");
                 break;
             //暂停
             case 3:
                 //Console.ForegroundColor = ConsoleColor.Yellow;
                 //str = "＄";
                 //Console.ResetColor();
                 PrintElement("＄");
                 break;
             //时空隧道
             case 4:
                 //Console.ForegroundColor = ConsoleColor.DarkBlue;
                 //str = "卐";
                 //Console.ResetColor();
                 PrintElement("卐");
                 break;
         }
     }
     return str;

 }
 #endregion
```
##### DrawStringMap()方法中又调用了 PrintElement(); 方法   ---该方法可以使绘制的特殊图例有颜色
```c#
 #region 绘制带颜色的特殊元素
 /// <summary>
 /// 绘制带颜色的特殊元素
 /// </summary>
 /// <param name="str"></param>
 static void PrintElement(string str)
 {
     switch (str)
     {
         case "＠":
             Console.ForegroundColor = ConsoleColor.Green;
             Console.Write("＠");
             Console.ResetColor();
             break;
         case "＃":
             Console.ForegroundColor = ConsoleColor.Red;
             Console.Write("＃");
             Console.ResetColor();
             break;
         case "＄":
             Console.ForegroundColor = ConsoleColor.Yellow;
             Console.Write("＄");
             Console.ResetColor();
             break;
         case "卐":
             Console.ForegroundColor = ConsoleColor.DarkBlue;
             Console.Write("卐");
             Console.ResetColor();
             break;

     }

 }
 #endregion
```
#### 绘制第一竖行   --上述代码执行完成后；键盘的光标会停留在绘制的第一横行的最后一个位置；首先需要将光标换到下一行，可以通过//画完第一横行后，换行Console.WriteLine();第二竖行从第30个位置开始；所以前面要打印29个空格使用for循环的嵌套
```c#
 #region 第一竖行
 for (int i = 30; i < 35; i++)
 {
     for (int j = 0; j < 29; j++)
     {
         Console.Write("  ");
     }
     Console.Write(DrawStringMap(i)); ;
     Console.WriteLine();
 }
 #endregion
```

#### 绘制第二横行
```c#
 #region 第二横行
 for (int i = 64; i >= 35; i--)
 {
     Console.Write(DrawStringMap(i));
 }
 #endregion

```

#### 绘制第二竖行：
```c#
 //画完第二横行后，换行
 Console.WriteLine();
 #region 第二竖行
 for (int i = 65; i <= 69; i++)
 {
     Console.WriteLine(DrawStringMap(i));
 }
 #endregion
```
#### 绘制第三横行：
```c#
  #region 第三横行
  for (int i = 70; i <= 99; i++)
  {
      Console.Write(DrawStringMap(i));
  }
  #endregion
```
## 开始游戏
>1.只要有一个人没到终点；游戏就要继续while (PlayerPos[0] < 99 && PlayerPos[1] < 99){}
>2.
### 为满足上述条件1；要保证游戏在一个whlie循环中进行
```c#
 #region 开始游戏
 //当玩家A和玩家B没有一个人在终点的时候，两个玩家不停的玩游戏
 while (PlayerPos[0] < 99 || PlayerPos[1] < 99)
 {
     if (IsPlaying[0] == false)
     {
         PlayGame(0);
     }
     else 
     {
         IsPlaying[0] = false;
     }
     if (PlayerPos[0] >=99)
     {
         Console.WriteLine($"玩家{PlayerNames[0]}赢了,游戏结束！", Console.ForegroundColor = ConsoleColor.Red);
         break;
     }
     if (IsPlaying[1] == false)
     {
         PlayGame(1);
     }
     else
     {
         IsPlaying[1] = false;
     }
     if (PlayerPos[1] >= 99)
     {
         Console.WriteLine($"玩家{PlayerNames[1]}赢了,游戏结束！", Console.ForegroundColor = ConsoleColor.Red);
         break;
     }


 }
 Console.WriteLine("\r\n██╗   ██╗██╗ ██████╗████████╗ ██████╗ ██████╗ ██╗   ██╗\r\n██║   ██║██║██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗╚██╗ ██╔╝\r\n██║   ██║██║██║        ██║   ██║   ██║██████╔╝ ╚████╔╝ \r\n╚██╗ ██╔╝██║██║        ██║   ██║   ██║██╔══██╗  ╚██╔╝  \r\n ╚████╔╝ ██║╚██████╗   ██║   ╚██████╔╝██║  ██║   ██║   \r\n  ╚═══╝  ╚═╝ ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝   \r\n                                                       \r\n");
 #endregion
 //PlayerPosChange();
 DrawMap();
```
### PlayGame()
```C#
     #region 开始游戏
 public static void PlayGame(int i)
 {
     Console.WriteLine(PlayerNames[i] + "按任意键开始掷骰子");
     Console.ReadKey(true);
     Random random = new Random();
     int index = random.Next(1, 7);
     Console.WriteLine(PlayerNames[i] + "掷到了" + index + ",前进" + index + "步");
     PlayerPos[i] += index;
     PlayerPosChange();
     //玩家A可能踩到玩家B
     if (PlayerPos[i] == PlayerPos[1 - i])
     {
         Console.WriteLine("玩家" + PlayerNames[i] + "踩到了玩家" + PlayerNames[1 - i] + ",玩家" + PlayerNames[1 - i] + "退6格");
         PlayerPos[1 - i] -= 6;
         PlayerPosChange();
         Console.ReadKey(true);
     }
     else
     {
         switch (Maps[PlayerPos[i]])
         {
             case 0:
                 Console.WriteLine("玩家" + PlayerNames[i] + "踩到了方块，这一回合无事发生！");
                 Console.WriteLine("按下任意键继续！玩家" + PlayerNames[i] + "开始移动");
                 Console.ReadKey(true);
                 Console.Clear();
                 DrawMap();
                 Console.WriteLine("玩家" + PlayerNames[i] + "行动完成");
                 Console.WriteLine("按下任意键继续！");
                 Console.ReadKey(true);
                 break;
             case 1:
                 Console.WriteLine("玩家" + PlayerNames[i] + "踩到了幸运轮盘，输入1代表和对方交换位置！输入2代表轰炸对方，使对方退6格");
                 Console.WriteLine("按下任意键继续！玩家" + PlayerNames[i] + "开始移动");
                 Console.ReadKey(true);
                 Console.Clear();
                 DrawMap();
                 Console.WriteLine("玩家" + PlayerNames[i] + "行动完成");
                 Console.WriteLine("玩家" + PlayerNames[i] + "踩到了幸运轮盘，输入1代表和对方交换位置！输入2代表轰炸对方，使对方退6格");
                 //Console.WriteLine("按下任意键继续！");
                 string input = Console.ReadLine();
                 while (true)
                 {
                     if (input == "1")
                     {
                         //玩家A和玩家B交换位置
                         int temp = PlayerPos[i];
                         PlayerPos[i] = PlayerPos[1 - i];
                         PlayerPos[1 - i] = temp;
                         PlayerPosChange();
                         break;
                     }
                     if (input == "2")
                     {
                         PlayerPos[1 - i] -= 6;
                         PlayerPosChange();
                         break;
                     }
                     else
                     {
                         Console.WriteLine("请输入1或者2，不要输入其他的字符！");
                         input = Console.ReadLine();
                     }
                 }

                 break;
             case 2:
                 Console.WriteLine("玩家" + PlayerNames[i] + "踩到了地雷，后退6格");
                 Console.WriteLine("按下任意键玩家" + PlayerNames[i] + "开始行动");
                 Console.ReadKey(true);
                 PlayerPos[i] -= 6;
                 PlayerPosChange();
                 Console.Clear();
                 DrawMap();
                 Console.WriteLine("玩家" + PlayerNames[i] + "行动结束");
                 break;
             case 3:
                 //暂停业务未开发
                 IsPlaying[i] = true;
                 Console.WriteLine("玩家" + PlayerNames[i] + "踩到了暂停，暂停一回合");
                 break;
             case 4:
                 Console.WriteLine("玩家" + PlayerNames[i] + "遇到时空隧道，前进十格");
                 Console.WriteLine("按下任意键玩家" + PlayerNames[i] + "开始行动");
                 Console.ReadKey(true);
                 PlayerPos[i] += 10;
                 PlayerPosChange();
                 Console.Clear();
                 DrawMap();
                 Console.WriteLine("玩家" + PlayerNames[i] + "行动结束");
                 break;
         }

     }

 }
 #endregion
```


# 实现步骤和理论：











































----------------------------------------------------------------
---
created: 2024-10-30T21:00:04 (UTC +08:00)
tags: [地雷时空隧道图标]
source: https://blog.csdn.net/make_1998/article/details/88781662
author: 
---

# C#基础——（飞行棋上）_地雷时空隧道图标-CSDN博客

> ## Excerpt
> 文章浏览阅读1.1k次。目录1、什么是飞行棋呢？2、整体步骤3、 游戏头显示4、玩家信息录入5、地图显示1、什么是飞行棋呢？2个玩家之间掷筛子然后走路，先到达终点的玩家赢，中间设置了4种特别的点：① 幸运轮盘——◎：选择交换位置还是让对方玩家回到原点② 地雷——☆：退6格③ 暂停——▲：停一次④ 时空隧道——卐：前进10格2、整体步骤3、 游戏头显示..._地雷时空隧道图标

---
**目录**

[1、什么是飞行棋呢？](https://blog.csdn.net/make_1998/article/details/88781662#t0)

[2、整体步骤](https://blog.csdn.net/make_1998/article/details/88781662#t1)

[3、 游戏头显示](https://blog.csdn.net/make_1998/article/details/88781662#t2)

[4、玩家信息录入](https://blog.csdn.net/make_1998/article/details/88781662#t3)

[5、地图显示](https://blog.csdn.net/make_1998/article/details/88781662#t4)

___

#### **1、什么是飞行棋呢？**

**![](https://i-blog.csdnimg.cn/blog_migrate/70e9930fc2dd864cf9990f835de12241.png)**

**2个玩家之间掷筛子然后走路，先到达终点的玩家赢，中间设置了4种特别的点：**

**① 幸运轮盘——◎：选择交换位置还是让对方玩家回到原点**

**② 地雷——☆：退6格**

**③ 暂停——▲：停一次**

**④ 时空隧道——卐：前进10格** 

#### **2、整体步骤**

![](https://i-blog.csdnimg.cn/blog_migrate/aeb200e38b4a42e97222c90713bad13d.png)

#### 3、 游戏头显示

**方法1：因为玩家信息录入成功之后，重新显示游戏头，所以将游戏头单独的设置成一个方法**

```cs
public static void ShowUI()

{

Console.WriteLine("********************************");

Console.WriteLine("* *");

Console.WriteLine("* 终极骑士飞行棋 1.0 *");

Console.WriteLine("* *");

Console.WriteLine("********************************");

}
```

#### 4、玩家信息录入

**用一个含有2个元素的字符串数组来存2个玩家的名字信息（下标为0的是玩家A的姓名，下标为1的是玩家B的姓名）**

**用一个含有2个元素的int类型数组来存2个玩家的坐标（下标为0的值为玩家A的坐标，下标为1的值为玩家B的坐标，开局2个玩家都在0坐标，所有2个元素初始值设为0）**

```cs
public static int[] PlayeraPos = new int[2] { 0, 0 };

public static string[] PlayerNames = new string[2];
```

![](https://i-blog.csdnimg.cn/blog_migrate/4bed021c9b0dcd13de226d18759f95ca.png)

 **第一部分代码：两个玩家姓名录入代码**

```cs
Console.WriteLine("请输入玩家A的姓名");

PlayerNames[0] = Console.ReadLine();

while (PlayerNames[0] == "")

{

Console.WriteLine("玩家A的姓名不能为空,请重新输入");

PlayerNames[0] = Console.ReadLine();

}

Console.WriteLine("请输入玩家B的姓名");

PlayerNames[1] = Console.ReadLine();

while (PlayerNames[1]==PlayerNames[0] || PlayerNames[1]=="")

{

if (PlayerNames[1] == PlayerNames[0])

{

Console.WriteLine("玩家B和玩家A的姓名{0}不能相同，请重新输入玩家B的姓名",PlayerNames[0]);

}

else

{

Console.WriteLine("玩家B的姓名为空,请重新输入");

}

PlayerNames[1] = Console.ReadLine();

}

Console.Clear();

ShowUI();

Console.WriteLine("对战开始......");

Console.WriteLine("{0}的士兵用A表示",PlayerNames[0]);

Console.WriteLine("{0}的士兵用B表示",PlayerNames[1]);
```

#### **5、地图显示**

**（1）先分析地图：**

![](https://i-blog.csdnimg.cn/blog_migrate/79adfd9ce6da34419b10af02926cb3ac.png)

**① 有100个点，用含有100个元素的int类型数组来表示这100个点，根据数值来判断图标**

**② 有8种类型的点**

<table><tbody><tr><td><p><strong>该点的特点</strong></p></td><td><p><strong>该点的图形</strong></p></td><td><strong>该点的下标</strong></td></tr><tr><td><strong>只有玩家A在该点</strong></td><td><strong>A</strong></td><td><strong>未知</strong></td></tr><tr><td><strong>只有玩家B在该点</strong></td><td><strong>B</strong></td><td><strong>未知</strong></td></tr><tr><td><strong>玩家A和B都不在该点</strong></td><td><strong>&lt;&gt;</strong></td><td><strong>开始的时候为0</strong></td></tr><tr><td><p><strong>没有玩家在该点，该点</strong><strong>元素的值为1</strong></p></td><td><p><strong>幸运轮盘——◎</strong></p></td><td><strong>开始的时候为6, 23, 40, 55, 69, 83</strong></td></tr><tr><td><strong>没有玩家在该点，该点元素的值为2</strong></td><td><p><strong>地雷——☆</strong></p></td><td><strong>开始的时候为5, 13, 17, 33, 38, 50, 64, 80, 94</strong></td></tr><tr><td><strong>没有玩家在该点，该点元素的值为3</strong></td><td><p><strong>暂停——▲</strong></p></td><td><strong>开始的时候为&nbsp;9, 27, 60, 93</strong></td></tr><tr><td><strong>没有玩家在该点，该点元素的值为4</strong></td><td><p><strong>时空隧道——卐</strong></p></td><td><strong>开始的时候为20, 25, 45, 63, 72, 88, 90</strong></td></tr><tr><td><p><strong>其他&nbsp;</strong></p></td><td><p><strong>正常——□</strong></p></td><td><strong>开始的时候为除了上面的都是</strong></td></tr></tbody></table>

**② 两个正方向的横行的画法一样**

**（2）方法2：游戏初始化：用一个含有100个元素的int类型的数组来存地图各个点，而各个点的图标的通过这个数组的值来判断**

```cs
public static int[] Map = new int[100];

public static void InitMap()

{

int[] luckyturn = { 6, 23, 40, 55, 69, 83 };

int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };

int[] pause = { 9, 27, 60, 93 };

int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };

for (int i = 0; i < luckyturn.Length; i++)

{

Map[luckyturn[i]] = 1;

}

for (int i = 0; i < landMine.Length; i++)

{

Map[landMine[i]] = 2;

}

for (int i = 0; i < pause.Length; i++)

{

Map[pause[i]] = 3;

}

for (int i = 0; i < timeTunnel.Length;i++)

{

Map[timeTunnel[i]] = 4;

}

}
```

**（3）方法3：游戏整体图标判断的逻辑：****上面的所说的8种点的类型判断**

```cs
ublic static string DrawStringMap(int pos)

{

string temp = "";

if (PlayeraPos[0] == PlayeraPos[1] && PlayeraPos[0] == pos)

{

Console.ForegroundColor = ConsoleColor.Yellow;

temp="<>";

}

else if (PlayeraPos[0] == pos)

{

Console.ForegroundColor = ConsoleColor.Yellow;

temp="A";

}

else if (PlayeraPos[1] == pos)

{

Console.ForegroundColor = ConsoleColor.Yellow;

temp = "B";

}

else

{

switch (Map[pos])

{

case 0:

Console.ForegroundColor = ConsoleColor.White;

temp = "□"; break;

case 1:

Console.ForegroundColor = ConsoleColor.Red;

temp = "◎"; break;

case 2:

Console.ForegroundColor = ConsoleColor.Blue;

temp = "☆"; break;

case 3:

Console.ForegroundColor = ConsoleColor.Green;

temp = "▲"; break;

case 4:

Console.ForegroundColor = ConsoleColor.Magenta;

temp = "卐"; break;

}

}

return temp;

}
```

**（3）方法4：正方向横行画法的代码：**

```cs
public static void DrawMapleftToRight(int left,int right)

{

for (int i = left; i <= right; i++)

{

Console.Write(DrawStringMap(i));

}

}
```

**（4）方法5：刚进入游戏的地图画法：**

```cs
public static void DrawMap()

{

Console.WriteLine("图例：幸运轮盘◎ 地雷：☆ 暂停：▲ 时空隧道：卐");

DrawMapleftToRight(0, 29);

Console.WriteLine();

for (int i = 30; i <= 34; i++)

{

for (int j = 0; j <= 28; j++)

{

Console.Write(" ");

}

Console.Write(DrawStringMap(i));

Console.WriteLine();

}

for (int i = 64; i >=35; i--)

{

Console.Write(DrawStringMap(i));

}

Console.WriteLine();

for (int i = 65; i <=69; i++)

{

Console.Write(DrawStringMap(i));

Console.WriteLine();

}

DrawMapleftToRight(70, 99);

Console.WriteLine("");

}
```

#### **其他的请见下一篇博客**

















