---
created: 2024-10-21T13:53:17 (UTC +08:00)
tags: []
source: https://github.com/tomakita/Colorful.Console
author: 
---

# tomakita/Colorful.Console：设置您的 .NET 控制台输出样式！

> ## Excerpt
> Style your .NET console output! Contribute to tomakita/Colorful.Console development by creating an account on GitHub.

---
[![构建状态](https://camo.githubusercontent.com/48b9bd896ab4b36a9f42123345ec336a9b6c9970c62cf37ac41a8100805a450a/68747470733a2f2f63692e6170707665796f722e636f6d2f6170692f70726f6a656374732f7374617475732f6866377931756e36356d64666b6662783f7376673d74727565)](https://ci.appveyor.com/project/tomakita/colorful-console)

**Colorful.Console**是一个环绕该类的 C# 库`System.Console`，它公开了增强的样式功能。

[![多彩.控制台图标](https://github.com/tomakita/Colorful.Console/raw/master/static/colorful_icon_ngsize.png)](https://github.com/tomakita/Colorful.Console/blob/master/static/colorful_icon_ngsize.png)

## 如何获取

-   从 NuGet下载[`Colorful.Console`](https://www.nuget.org/packages/Colorful.Console)。
-   执行 Git 克隆

> git 克隆[https://github.com/tomakita/Colorful.Console.git](https://github.com/tomakita/Colorful.Console.git)

## 基本用法

```cs
using System;
using System.Drawing;
using Console = Colorful.Console;
...
...
Console.WriteLine("console in pink", Color.Pink);
Console.WriteLine("console in default");
```

[![基本示例](https://github.com/tomakita/Colorful.Console/raw/master/static/basic_x.png)](https://github.com/tomakita/Colorful.Console/blob/master/static/basic_x.png)

## 使用完整的 System.Drawing.Color 支持进行书写

```cs
int r = 225;
int g = 255;
int b = 250;
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(storyFragments[i], Color.FromArgb(r, g, b));

    r -= 18;
    b -= 9;
}
```

[![使用完整的 System.Drawing.Color 支持进行书写](https://github.com/tomakita/Colorful.Console/raw/master/static/rgb_x.png)](https://github.com/tomakita/Colorful.Console/blob/master/static/rgb_x.png)

## 使用两种颜色设置文本格式

```cs
string dream = "a dream of {0} and {1} and {2} and {3} and {4} and {5} and {6} and {7} and {8} and {9}...";
string[] fruits = new string[]
{
    "bananas",
    "strawberries",
    "mangoes",
    "pineapples",
    "cherries",
    "oranges",
    "apples",
    "peaches",
    "plums",
    "melons"
};

Console.WriteLineFormatted(dream, Color.LightGoldenrodYellow, Color.Gray, fruits);
```

[![使用两种颜色设置文本格式](https://github.com/tomakita/Colorful.Console/raw/master/static/formatter_x1.png)](https://github.com/tomakita/Colorful.Console/blob/master/static/formatter_x1.png)

## 使用多种颜色设置文本格式

```cs
string dream = "a dream of {0} and {1} and {2} and {3} and {4} and {5} and {6} and {7} and {8} and {9}...";
Formatter[] fruits = new Formatter[]
{
    new Formatter("bananas", Color.LightGoldenrodYellow),
    new Formatter("strawberries", Color.Pink),
    new Formatter("mangoes", Color.PeachPuff),
    new Formatter("pineapples", Color.Yellow),
    new Formatter("cherries", Color.Red),
    new Formatter("oranges", Color.Orange),
    new Formatter("apples", Color.LawnGreen),
    new Formatter("peaches", Color.MistyRose),
    new Formatter("plums", Color.Indigo),
    new Formatter("melons", Color.LightGreen),
};

Console.WriteLineFormatted(dream, Color.Gray, fruits);
```

[![使用多种颜色设置文本格式](https://github.com/tomakita/Colorful.Console/raw/master/static/formatter_x2.png)](https://github.com/tomakita/Colorful.Console/blob/master/static/formatter_x2.png)

## 根据控制台写入次数交替显示 2 种或多种颜色

```cs
ColorAlternatorFactory alternatorFactory = new ColorAlternatorFactory();
ColorAlternator alternator = alternatorFactory.GetAlternator(2, Color.Plum, Color.PaleVioletRed);

for (int i = 0; i < 15; i++)
{
    Console.WriteLineAlternating("cats", alternator);
}
```

[![根据控制台写入次数交替显示 2 种或多种颜色](https://github.com/tomakita/Colorful.Console/raw/master/static/alternator_x2.png)](https://github.com/tomakita/Colorful.Console/blob/master/static/alternator_x2.png)

## 根据一个或多个正则表达式在 2 种或多种颜色之间交替

```cs
ColorAlternatorFactory alternatorFactory = new ColorAlternatorFactory();
ColorAlternator alternator = alternatorFactory.GetAlternator(new[] { "hiss", "m[a-z]+w" }, Color.Plum, Color.PaleVioletRed);

for (int i = 0; i < 15; i++)
{
    string catMessage = "cats";

    if (i % 3 == 0)
    {
        catMessage = meowVariant[meowCounter++];
    }
    else if (i % 10 == 0)
    {
        catMessage = "hiss";
    }

    Console.WriteLineAlternating(catMessage, alternator);
}
```

[![根据一个或多个正则表达式在 2 种或多种颜色之间交替](https://github.com/tomakita/Colorful.Console/raw/master/static/alternator_x1.png)](https://github.com/tomakita/Colorful.Console/blob/master/static/alternator_x1.png)

## 为文本的特定区域设置样式

```cs
StyleSheet styleSheet = new StyleSheet(Color.White);
styleSheet.AddStyle("rain[a-z]*", Color.MediumSlateBlue);

Console.WriteLineStyled(storyAboutRain, styleSheet);
```

[![根据一个或多个正则表达式在 2 种或多种颜色之间交替](https://github.com/tomakita/Colorful.Console/raw/master/static/styler_x1.png)](https://github.com/tomakita/Colorful.Console/blob/master/static/styler_x1.png)

## 对文本的特定区域进行样式设置，执行简单的转换

```cs
StyleSheet styleSheet = new StyleSheet(Color.White);
styleSheet.AddStyle("rain[a-z]*", Color.MediumSlateBlue, match => match.ToUpper());

Console.WriteLineStyled(storyAboutRain, styleSheet);
```

[![对文本的特定区域进行样式设置，执行简单的转换](https://github.com/tomakita/Colorful.Console/raw/master/static/styler_x2.png)](https://github.com/tomakita/Colorful.Console/blob/master/static/styler_x2.png)

## 对文本的特定区域进行样式设置，根据周围文本进行转换

```cs
StyleSheet styleSheet = new StyleSheet(Color.White);
styleSheet.AddStyle("rain[a-z]*", Color.MediumSlateBlue,
    (unstyledInput, matchLocation, match) =>
    {
        if (unstyledInput[matchLocation.End] == '.')
        {
            return "marshmallows";
        }
        else
        {
            return "s'mores";
        }
    });

Console.WriteLineStyled(storyAboutRain, styleSheet);
```

[![对文本的特定区域进行样式设置，执行简单的转换](https://github.com/tomakita/Colorful.Console/raw/master/static/styler_x3.png)](https://github.com/tomakita/Colorful.Console/blob/master/static/styler_x3.png)

## 使用默认字体将文本转换为 ASCII 艺术

```cs
int DA = 244;
int V = 212;
int ID = 255;
for (int i = 0; i < 3; i++)
{
    Console.WriteAscii("HASSELHOFF", Color.FromArgb(DA, V, ID));

    DA -= 18;
    V -= 36;
}
```

[![使用默认字体将文本转换为 ASCII 艺术](https://github.com/tomakita/Colorful.Console/raw/master/static/ascii_x1.png)](https://github.com/tomakita/Colorful.Console/blob/master/static/ascii_x1.png)

```cs
FigletFont font = FigletFont.Load("chunky.flf");
Figlet figlet = new Figlet(font);

Console.WriteLine(figlet.ToAscii("Belvedere"), ColorTranslator.FromHtml("#8AFFEF"));
Console.WriteLine(figlet.ToAscii("ice"), ColorTranslator.FromHtml("#FAD6FF"));
Console.WriteLine(figlet.ToAscii("cream."), ColorTranslator.FromHtml("#B8DBFF"));
```

[![使用默认字体将文本转换为 ASCII 艺术](https://github.com/tomakita/Colorful.Console/raw/master/static/ascii_x2.png)](https://github.com/tomakita/Colorful.Console/blob/master/static/ascii_x2.png)

## 渐变风格的系列

```cs
List<char> chars = new List<char>()
{
'r', 'e', 'x', 's', 'z', 'q', 'j', 'w', 't', 'a', 'b', 'c', 'l', 'm',
'r', 'e', 'x', 's', 'z', 'q', 'j', 'w', 't', 'a', 'b', 'c', 'l', 'm',
'r', 'e', 'x', 's', 'z', 'q', 'j', 'w', 't', 'a', 'b', 'c', 'l', 'm',
'r', 'e', 'x', 's', 'z', 'q', 'j', 'w', 't', 'a', 'b', 'c', 'l', 'm'
};
Console.WriteWithGradient(chars, Color.Yellow, Color.Fuchsia, 14);
```

[![渐变风格的系列](https://github.com/tomakita/Colorful.Console/raw/master/static/gradw_x.png)](https://github.com/tomakita/Colorful.Console/blob/master/static/gradw_x.png)

## 使用说明

可以使用该功能将控制台颜色恢复为默认值`Colorful.Console.ReplaceAllColorsWithDefaults`。

可以使用该函数替换控制台调色板中的单独颜色`Colorful.Console.ReplaceColor`。

**Colorful.Console**只能在单个控制台会话中以 16 种不同的颜色（包括默认用作控制台背景的黑色！）写入控制台。这是 Windows 控制台本身的限制（参考：[MSDN](https://msdn.microsoft.com/en-us/library/windows/desktop/ms682091(v=vs.85).aspx)），我们无法解决这个问题。如果您知道解决方法，请告诉我们！
