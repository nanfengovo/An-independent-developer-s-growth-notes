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
```
```




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

















