---
created: 2024-10-15T10:06:20 (UTC +08:00)
tags: []
source: https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics
author: 
---

# JavaScript 基础 - 学习 Web 开发 | MDN

> ## Excerpt
> JavaScript 是一门为网站添加交互性的编程语言。交互性体现在游戏、点击按钮或输入表单时的响应行为；动态的样式；动画，等等。本文将帮助你入门 JavaScript，并进一步加深你对 JavaScript 所能实现的功能的理解。

---
-   [上一页](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/CSS_basics)
-   [概述：Web 入门](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web)
-   [下一页](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/Publishing_your_website)

JavaScript 是一门为网站添加交互性的编程语言。交互性体现在游戏、点击按钮或输入表单时的响应行为；动态的样式；动画，等等。本文将帮助你入门 JavaScript，并进一步加深你对 JavaScript 所能实现的功能的理解。

## [JavaScript 到底是什么？](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics#javascript_%E5%88%B0%E5%BA%95%E6%98%AF%E4%BB%80%E4%B9%88%EF%BC%9F)

[JavaScript](https://developer.mozilla.org/zh-CN/docs/Glossary/JavaScript) 是一门为网站添加交互性的强有力的编程语言。由布兰登·艾克发明。

JavaScript 是一门多功能的、新手友好的编程语言。随着经验的积累，你将能够创建游戏、2D 和 3D 图形动画、全面的数据库驱动应用程序，等等。

JavaScript 本身相对简洁，但非常灵活。开发者在核心 JavaScript 语言的基础上编写了各种工具，让你能以最小的努力解锁大量的功能。这些工具包括：

-   Web 浏览器内置的应用程序编程接口（[API](https://developer.mozilla.org/zh-CN/docs/Glossary/API)），提供了丰富的功能，例如：动态创建 HTML 和设置 CSS 样式；从用户的摄像头采集和处理视频流、生成 3D 图形和音频样本。
-   允许开发者将来自其他内容提供商（如 [Disqus](https://disqus.com/)、Facebook）的功能整合到自己的网站中的第三方 API。
-   能够应用于 HTML 加速网站和应用程序开发的第三方框架和库。

作为一篇 JavaScript 的简要介绍，阐述核心 JavaScript 和上述的工具之间的区别超出了本文的范围。你可以在 MDN 的 [JavaScript 学习区](https://developer.mozilla.org/zh-CN/docs/Learn/JavaScript)，以及 MDN 的其余部分了解更多信息。

接下来将介绍核心语言的一些方面，并提供体验一些浏览器 API 特性的机会。祝你玩得开心！

## [“Hello World!”示例](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics#%E2%80%9Chello_world!%E2%80%9D%E7%A4%BA%E4%BE%8B)

JavaScript 是最流行的现代 Web 技术之一。随着 JavaScript 技能的增长，你的网站在功能和创新力上将达到一个新的维度。

然而，熟练掌握 JavaScript 比熟练掌握 HTML 和 CSS 要更有挑战。你必须从简单的开始，然后逐步前进。首先，来看看如何在页面中添加 JavaScript 完成 _Hello world!_ 示例（_Hello world!_ 是[标准的介绍性编程示例](https://zh.wikipedia.org/wiki/Hello_World)）。

**警告：**如果你没有完成之前的课程，请先[下载这个示例代码](https://codeload.github.com/mdn/beginner-html-site-styled/zip/refs/heads/gh-pages)，把示例代码当作起始点。

1.  打开测试站点的目录，创建一个名为 `scripts` 的新目录。然后在 scripts 目录中创建一个名为 `main.js` 的新文件，并保存。
    
2.  打开 `index.html` 文件，在结束标签 `</body>` 前添加下列代码：
    
    ```
    <span><span><span>&lt;</span>script</span> <span>src</span><span><span>=</span><span>"</span>scripts/main.js<span>"</span></span><span>&gt;</span></span><span></span><span><span><span>&lt;/</span>script</span><span>&gt;</span></span>
    ```
    
3.  与 CSS 的 [`<link>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/link) 元素的功能类似，它将 JavaScript 引入以作用于 HTML（以及 CSS 和页面上的任何其他内容）。
    
4.  将下列代码添加到 `scripts/main.js` 文件：
    
    ```
    <span>const</span> myHeading <span>=</span> document<span>.</span><span>querySelector</span><span>(</span><span>"h1"</span><span>)</span><span>;</span>
    myHeading<span>.</span>textContent <span>=</span> <span>"Hello world!"</span><span>;</span>
    ```
    
5.  确认保存了 HTML 和 JavaScript 文件。然后在浏览器中打开 `index.html`。你应该看到类似的内容：
    

![“hello world”标题，下面是 firefox 标志](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics/hello-world.png)

**备注：**上面将 [`<script>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/script) 元素放在 HTML 文件的底部附近的原因是**浏览器会按照代码在文件中的顺序进行读取**。

如果 JavaScript 先加载，并期望操纵还未加载的 HTML，可能会出现问题。将 JavaScript 放在 HTML 页面的底部附近是一种解决方案。想要了解更多的替代方案，参见[脚本加载策略](https://developer.mozilla.org/zh-CN/docs/Learn/JavaScript/First_steps/What_is_JavaScript#%E8%84%9A%E6%9C%AC%E5%8A%A0%E8%BD%BD%E7%AD%96%E7%95%A5)。

### [发生了什么？](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics#%E5%8F%91%E7%94%9F%E4%BA%86%E4%BB%80%E4%B9%88%EF%BC%9F)

使用 JavaScript 把标题文本改成了 _Hello world!_。用 [`querySelector()`](https://developer.mozilla.org/zh-CN/docs/Web/API/Document/querySelector "querySelector()") 函数获取标题的引用，然后把它储存在 `myHeading` 变量中。这与 CSS 选择器的用法非常相像。若要对某个元素进行操作，首先得选择它。

接着，把 `myHeading` 变量的 [`textContent`](https://developer.mozilla.org/zh-CN/docs/Web/API/Node/textContent "textContent") 属性（表示标题内容）的值设置为 _Hello world!_。

## [JavaScript 速成课程](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics#javascript_%E9%80%9F%E6%88%90%E8%AF%BE%E7%A8%8B)

为了让你更好地理解 JavaScript 的运行机制，我们会解释一些语言的核心特性。值得注意的是，这些特性是所有编程语言的共性。如果掌握了这些基础知识，你也可以开始用其他语言写代码。

**警告：**学习本文时，请尝试在 JavaScript 控制台中输入示例代码行，看看会发生什么。在[探索浏览器开发者工具](https://developer.mozilla.org/zh-CN/docs/Learn/Common_questions/Tools_and_setup/What_are_browser_developer_tools)中了解更多有关 JavaScript 控制台的信息。

### [变量](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics#%E5%8F%98%E9%87%8F)

[变量](https://developer.mozilla.org/zh-CN/docs/Glossary/Variable)是存储值的容器。要声明变量，先输入 [`let`](https://developer.mozilla.org/zh-CN/docs/Web/JavaScript/Reference/Statements/let) 关键字，然后输入变量名：

行尾的分号表示语句结束。仅当你需要在单行内分隔多条语句时，分号才是必须的。然而，一些人认为每条语句末尾加分号是最佳实践。对于何时应该使用、何时不应该使用分号有其他的规则。在[你的 JavaScript 分号指南](https://www.codecademy.com/resources/blog/your-guide-to-semicolons-in-javascript/)中了解更多细节。

变量名几乎可以任意取，但有一些限制（参见[命名规则小节](https://developer.mozilla.org/zh-CN/docs/Web/JavaScript/Guide/Grammar_and_types#%E5%8F%98%E9%87%8F)）。如果你不确定，还可以[验证变量名](https://mothereff.in/js-variables)是否有效。

JavaScript 对大小写敏感。这意味着 `myVariable` 和 `myvariable` 是不同的。如果代码中有问题，检查一下大小写！

声明变量后，你可以给它赋值：

你也可以在同一行执行声明和赋值操作：

你可以通过变量名获取值：

给变量赋值后，你可以修改变量的值：

```
let myVariable = "鲍勃";
myVariable = "斯蒂夫";
```

注意变量可以存储不同[数据类型](https://developer.mozilla.org/zh-CN/docs/Web/JavaScript/Data_structures)的值：

| 变量 | 解释 | 示例 |
| --- | --- | --- |
| [字符串](https://developer.mozilla.org/zh-CN/docs/Glossary/String) | 字符串就是文本序列。用单引号或双引号括起来的值就是字符串。 | `let myVariable = '鲍勃';` 或者  
`let myVariable = "鲍勃";` |
| [数字](https://developer.mozilla.org/zh-CN/docs/Glossary/Number) | 数字周围没有引号。 | `let myVariable = 10;` |
| [布尔](https://developer.mozilla.org/zh-CN/docs/Glossary/Boolean) | 真/假值。单词 `true`/`false` 是不需要引号的特殊关键字。 | `let myVariable = true;` |
| [数组](https://developer.mozilla.org/zh-CN/docs/Glossary/Array) | 让你在单一引用中存储多个值的结构。 | `let myVariable = [1,'鲍勃','斯蒂夫',10];`  
像这样引用数组成员：`myVariable[0]`、`myVariable[1]`，等等。 |
| [对象](https://developer.mozilla.org/zh-CN/docs/Glossary/Object) | 可以是任何内容。JavaScript 里的一切都是对象，对象能在变量中存储。这一点要牢记于心。 | `let myVariable = document.querySelector('h1');`  
上面的示例都是。 |

那么变量有什么用呢？编程时变量无处不在。如果值不能修改，那么就无法做任何动态的工作，比如个性化的问候，或是改变图片库中展示的图片。

### [注释](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics#%E6%B3%A8%E9%87%8A)

注释是和代码一起的文本片段。浏览器会忽略注释。类似于 CSS，JavaScript 中可以添加注释。

如果注释只有一行，将注释放在两个斜杠之后也是个选择，就像这样：

### [运算符](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics#%E8%BF%90%E7%AE%97%E7%AC%A6)

[运算符](https://developer.mozilla.org/zh-CN/docs/Glossary/Operator)是一种基于两个值（或变量）生成对应结果的数学符号。在下列表格中，介绍了一些最简单的运算符以及一些对应的示例，可以在 JavaScript 控制台中尝试这些示例。

| 运算符 | 解释 | 符号 | 示例 |
| --- | --- | --- | --- |
| 加 | 将两个数字相加或拼接两个字符串。 | `+` | `6 + 9;   'Hello ' + 'world!';` |
| 减、乘、除 | 这些运算符的作用与基础算术一致。 | `-`、`*`、`/` | `9 - 3;   8 * 2; //乘法在 JS 中是一个星号   9 / 3;` |
| 赋值 | 你已经见过了：为变量赋值。 | `=` | `let myVariable = '鲍勃';` |
| 严格相等 | 测试两个值是否相等以及是否是相同的数据类型，并返回一个 `true`/`false`（布尔）结果。 | [`===`](https://developer.mozilla.org/zh-CN/docs/Web/JavaScript/Reference/Operators/Strict_equality) | `let myVariable = 3;   myVariable === 4;` |
| 非、不等于 | 返回和先前逻辑上相反的值。非将 `true` 变为 `false`，等等。当它和相等运算符一起使用时，否定运算符测试两个值是否_不_相等。 | `!`、`!==` | 
对于“非”，基本表达式是 `true`，但结果返回的是 `false`，因为我们否定了这个值：

`let myVariable = 3;   !(myVariable === 3);`

“不等于”用不同的语法得出了基本上一样的结果。这里测试“`myVariable` 不等于 3”。返回 `false`，因为 `myVariable` 等于 3：

`let myVariable = 3;   myVariable !== 3;`

 |

运算符种类远不止这些，不过目前上表已经够用了。在[表达式和运算符](https://developer.mozilla.org/zh-CN/docs/Web/JavaScript/Reference/Operators)中了解完整列表。

**备注：**执行计算时，混用数据类型可能出现一些奇怪的结果。注意要正确地引用变量，然后得到预期的结果。比如在控制台输入 `"35" + "25"`，为什么没有得到预期的结果？因为引号将数字转换成了字符串，所以结果是拼接两个字符串而不是把两个数字相加。如果输入 `35 + 25`，你就会得到两个数字的和。

### [条件语句](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics#%E6%9D%A1%E4%BB%B6%E8%AF%AD%E5%8F%A5)

条件语句是用来测试表达式的真假的代码结构。一个常用的条件语句是 `if...else` 语句。例如：

```
<span>let</span> iceCream <span>=</span> <span>"chocolate"</span><span>;</span>
<span>if</span> <span>(</span>iceCream <span>===</span> <span>"chocolate"</span><span>)</span> <span>{</span>
  <span>alert</span><span>(</span><span>"我最喜欢巧克力冰淇淋了！"</span><span>)</span><span>;</span>
<span>}</span> <span>else</span> <span>{</span>
  <span>alert</span><span>(</span><span>"但是巧克力才是我的最爱呀……"</span><span>)</span><span>;</span>
<span>}</span>
```

`if ()` 中的表达式是一个测试。用（上文所提到的）严格相等运算符来比较 `iceCream` 变量与 `chocolate` 字符串是否相等。如果返回 `true`，则运行第一个代码块；如果返回 `false`，则运行 `else` 关键字之后的第二个代码块。

### [函数](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics#%E5%87%BD%E6%95%B0)

[函数](https://developer.mozilla.org/zh-CN/docs/Glossary/Function)是一种将你希望重复使用的功能封装起来的方式。你可以将一段代码定义为一个函数，当你在代码中调用该函数名时，它会执行。这是一种避免重复编写相同代码的好方式。你已经看到了一些函数的使用示例了。比如：

```
<span>let</span> myVariable <span>=</span> document<span>.</span><span>querySelector</span><span>(</span><span>"h1"</span><span>)</span><span>;</span>
```

`document.querySelector` 和 `alert` 是浏览器内置的函数。

如果你发现有个像变量名，但后面跟着小括号——`()`——的东西，它很可能是函数。函数通常接收[参数](https://developer.mozilla.org/zh-CN/docs/Glossary/Argument)：函数用来执行特定的任务。参数位于小括号内，多个参数之间用逗号分开。

比如， `alert()` 函数在浏览器窗口内弹出一个警告框，但还应为其提供一个字符串参数，告诉它警告框里要显示的内容。

你也可以定义你自己的函数。在下面的例子中，我们创建了一个接收两个数字参数的函数，并对这两个参数做乘法：

```
<span>function</span> <span>multiply</span><span>(</span><span>num1<span>,</span> num2</span><span>)</span> <span>{</span>
  <span>let</span> result <span>=</span> num1 <span>*</span> num2<span>;</span>
  <span>return</span> result<span>;</span>
<span>}</span>
```

尝试在控制台中运行这个函数；然后多试几组参数。比如：

```
<span>multiply</span><span>(</span><span>4</span><span>,</span> <span>7</span><span>)</span><span>;</span>
<span>multiply</span><span>(</span><span>20</span><span>,</span> <span>20</span><span>)</span><span>;</span>
<span>multiply</span><span>(</span><span>0.5</span><span>,</span> <span>3</span><span>)</span><span>;</span>
```

**备注：** [`return`](https://developer.mozilla.org/zh-CN/docs/Web/JavaScript/Reference/Statements/return) 语句告诉浏览器将 `result` 变量返回到函数外面。这一点很有必要，因为函数内定义的变量只能在函数内使用。这叫做变量的[作用域](https://developer.mozilla.org/zh-CN/docs/Glossary/Scope)。（阅读更多有关[变量的作用域](https://developer.mozilla.org/zh-CN/docs/Web/JavaScript/Guide/Grammar_and_types#%E5%8F%98%E9%87%8F%E7%9A%84%E4%BD%9C%E7%94%A8%E5%9F%9F)的内容。）

### [事件](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics#%E4%BA%8B%E4%BB%B6)

事件处理器能为网页添加真正的交互。它们是监听浏览器活动的代码块，并在响应中运行代码。最明显的例子就是处理[点击事件](https://developer.mozilla.org/zh-CN/docs/Web/API/Element/click_event)，当你用鼠标点击时，浏览器会触发该事件。作为演示，在控制台中输入下面的代码，然后点击网页的任意位置：

```
document<span>.</span><span>querySelector</span><span>(</span><span>"html"</span><span>)</span><span>.</span><span>addEventListener</span><span>(</span><span>"click"</span><span>,</span> <span>function</span> <span>(</span><span>)</span> <span>{</span>
  <span>alert</span><span>(</span><span>"别戳我，我怕疼！"</span><span>)</span><span>;</span>
<span>}</span><span>)</span><span>;</span>
```

将事件处理器与元素绑定有许多方法。这里我们选择了 [`<html>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/html) 元素，然后调用了它的 [`addEventListener()`](https://developer.mozilla.org/zh-CN/docs/Web/API/EventTarget/addEventListener) 函数，并传递要监听的事件名（`'click'`）和事件发生时要运行的函数。

刚刚我们传递给 `addEventListener()` 的函数被称为_匿名函数_，因为它没有名字。匿名函数还有另一种书写方式，我们称之为_箭头函数_。箭头函数使用 `() =>` 而不是 `function ()`：

```
document<span>.</span><span>querySelector</span><span>(</span><span>"html"</span><span>)</span><span>.</span><span>addEventListener</span><span>(</span><span>"click"</span><span>,</span> <span>(</span><span>)</span> <span>=&gt;</span> <span>{</span>
  <span>alert</span><span>(</span><span>"别戳我，我怕疼！"</span><span>)</span><span>;</span>
<span>}</span><span>)</span><span>;</span>
```

## [完善示例网站](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics#%E5%AE%8C%E5%96%84%E7%A4%BA%E4%BE%8B%E7%BD%91%E7%AB%99)

现在你已经具备了一些 JavaScript 基础，下面让我们为示例网站添加一些新特性。

在继续下面的内容之前，将 `main.js` 文件中的内容都删掉——即你在“Hello world!”示例中添加的内容——并保存这个空文件。要是不这样做的话，已经存在的代码将会与你下面要写的新代码产生冲突。

### [添加一个图像切换器](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics#%E6%B7%BB%E5%8A%A0%E4%B8%80%E4%B8%AA%E5%9B%BE%E5%83%8F%E5%88%87%E6%8D%A2%E5%99%A8)

在本小节，你将会学习如何使用 JavaScript 和 DOM API 特性交替显示两张图片。当用户点击图片时进行切换。

1.  选择一张你想在页面上展示的图片。理想情况下，这张图片的尺寸与之前添加的图片的尺寸尽可能相同。
    
2.  将这张图片保存在 `images` 目录中。
    
3.  将这张图片重命名为 _firefox2.png_。
    
4.  将下列的 JavaScript 代码添加到 `main.js` 文件：
    
    ```
    <span>const</span> myImage <span>=</span> document<span>.</span><span>querySelector</span><span>(</span><span>"img"</span><span>)</span><span>;</span>
    
    myImage<span>.</span><span>onclick</span> <span>=</span> <span>(</span><span>)</span> <span>=&gt;</span> <span>{</span>
      <span>const</span> mySrc <span>=</span> myImage<span>.</span><span>getAttribute</span><span>(</span><span>"src"</span><span>)</span><span>;</span>
      <span>if</span> <span>(</span>mySrc <span>===</span> <span>"images/firefox-icon.png"</span><span>)</span> <span>{</span>
        myImage<span>.</span><span>setAttribute</span><span>(</span><span>"src"</span><span>,</span> <span>"images/firefox2.png"</span><span>)</span><span>;</span>
      <span>}</span> <span>else</span> <span>{</span>
        myImage<span>.</span><span>setAttribute</span><span>(</span><span>"src"</span><span>,</span> <span>"images/firefox-icon.png"</span><span>)</span><span>;</span>
      <span>}</span>
    <span>}</span><span>;</span>
    ```
    
5.  保存所有文件并用浏览器打开 `index.html`。现在，当你点击图片时，会切换成另一张。
    

发生的事情是这样的。把 [`<img>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/img) 元素的引用存储在 `myImage` 变量中。接下来，让它的 `onclick` 事件处理器属性等于一个无名函数（“匿名”函数）。这样每次点击图片时：

1.  获取这张图片的 `src` 属性值。
    
2.  用一个条件句来判断 `src` 的值是否等于原始图片的路径：
    
    1.  如果是，则将 `src` 的值改为第二张图片的路径，在 [`<img>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/img) 内强制加载第二张图片。
    2.  如果不是（意味着它已经修改过）, 则把 `src` 的值重新设置为原始图片的路径，即原始状态。

### [添加个性化欢迎信息](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics#%E6%B7%BB%E5%8A%A0%E4%B8%AA%E6%80%A7%E5%8C%96%E6%AC%A2%E8%BF%8E%E4%BF%A1%E6%81%AF)

接下来，让我们在用户第一次访问站点时将页面标题修改为个性化欢迎信息。这个欢迎消息会一直存在。名字信息会由 [Web 存储 API](https://developer.mozilla.org/zh-CN/docs/Web/API/Web_Storage_API) 保存下来，即使用户关闭页面之后再重新打开。还会添加一个选项，改变用户名字以更新欢迎信息。

1.  打开 `index.html`，在 [`<script>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/script) 元素前添加下列代码：
    
    ```
    <span><span><span>&lt;</span>button</span><span>&gt;</span></span>Change user<span><span><span>&lt;/</span>button</span><span>&gt;</span></span>
    ```
    
2.  打开 `main.js`，将下列代码原封不动地添加到文件的底部。将获取新按钮和标题的引用，并存储到变量中：
    
    ```
    <span>let</span> myButton <span>=</span> document<span>.</span><span>querySelector</span><span>(</span><span>"button"</span><span>)</span><span>;</span>
    <span>let</span> myHeading <span>=</span> document<span>.</span><span>querySelector</span><span>(</span><span>"h1"</span><span>)</span><span>;</span>
    ```
    
3.  添加下列设置个性化欢迎信息的函数。现在什么都还没发生，但一会就会发生了。
    
    ```
    <span>function</span> <span>setUserName</span><span>(</span><span>)</span> <span>{</span>
      <span>const</span> myName <span>=</span> <span>prompt</span><span>(</span><span>"Please enter your name."</span><span>)</span><span>;</span>
      localStorage<span>.</span><span>setItem</span><span>(</span><span>"name"</span><span>,</span> myName<span>)</span><span>;</span>
      myHeading<span>.</span>textContent <span>=</span> <span><span>`</span><span>Mozilla is cool, </span><span><span>${</span>myName<span>}</span></span><span>`</span></span><span>;</span>
    <span>}</span>
    ```
    
    `setUserName()` 函数包含一个 [`prompt()`](https://developer.mozilla.org/zh-CN/docs/Web/API/Window/prompt) 函数，与 `alert()` 类似会弹出一个对话框。`prompt()` 函数的功能更多，需要用户输入数据，并在用户点击_确定_后将数据存储在一个变量中。在这个例子里，我们要求用户输入一个名字。接下来，代码调用 `localStorage` API，它允许我们将数据存储在浏览器中并供后续获取。我们使用 `localStorage` 的 `setItem()` 函数创建并存储一个`'name'` 的数据项，并将它的值设置为包含用户名的 `myName` 变量。最后将标题的 `textContent` 属性设置为带有用户新设置的名字的字符串。
    
4.  在函数声明的后面添加下列条件语句块。我们称之为初始化代码，因为它在初次加载时开始工作。
    
    ```
    <span>if</span> <span>(</span><span>!</span>localStorage<span>.</span><span>getItem</span><span>(</span><span>"name"</span><span>)</span><span>)</span> <span>{</span>
      <span>setUserName</span><span>(</span><span>)</span><span>;</span>
    <span>}</span> <span>else</span> <span>{</span>
      <span>const</span> storedName <span>=</span> localStorage<span>.</span><span>getItem</span><span>(</span><span>"name"</span><span>)</span><span>;</span>
      myHeading<span>.</span>textContent <span>=</span> <span><span>`</span><span>Mozilla is cool, </span><span><span>${</span>storedName<span>}</span></span><span>`</span></span><span>;</span>
    <span>}</span>
    ```
    
    这里的第一行使用取非运算符（逻辑非，用 `!` 表示）检测 `name` 数据是否存在。若不存在，调用 `setUserName()` 创建 `name` 数据。若存在（即用户上次访问时设置了用户名），调用 `getItem()` 获取保存的名字，然后像 `setUserName()` 中那样设置标题的 `textContent`。
    
5.  设置按钮的 `onclick` 事件处理器。按钮点击时，运行 `setUserName()` 函数。这样用户就可以通过点击按钮设置新名字了。
    
    ```
    myButton<span>.</span><span>onclick</span> <span>=</span> <span>function</span> <span>(</span><span>)</span> <span>{</span>
      <span>setUserName</span><span>(</span><span>)</span><span>;</span>
    <span>}</span><span>;</span>
    ```
    

### [用户名为 null？](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics#%E7%94%A8%E6%88%B7%E5%90%8D%E4%B8%BA_null%EF%BC%9F)

运行示例代码，弹出输入用户名的对话框，试着点击_取消_按钮。此时标题会显示为 _Mozilla is cool, null_。这是因为取消提示对话框后值将设置为 [`null`](https://developer.mozilla.org/zh-CN/docs/Web/JavaScript/Reference/Operators/null)。_null_ 是 JavaScript 中的一个特殊值，表示引用的值不存在。

也可以不输入任何名字直接点击_确认_，你的标题会显示为 _Mozilla is cool,_，原因么显而易见。

要避免这些问题，应该检查用户没有输入空名字。更新 `setUserName()` 为：

```
<span>function</span> <span>setUserName</span><span>(</span><span>)</span> <span>{</span>
  <span>const</span> myName <span>=</span> <span>prompt</span><span>(</span><span>"Please enter your name."</span><span>)</span><span>;</span>
  <span>if</span> <span>(</span><span>!</span>myName<span>)</span> <span>{</span>
    <span>setUserName</span><span>(</span><span>)</span><span>;</span>
  <span>}</span> <span>else</span> <span>{</span>
    localStorage<span>.</span><span>setItem</span><span>(</span><span>"name"</span><span>,</span> myName<span>)</span><span>;</span>
    myHeading<span>.</span>textContent <span>=</span> <span><span>`</span><span>Mozilla is cool, </span><span><span>${</span>myName<span>}</span></span><span>`</span></span><span>;</span>
  <span>}</span>
<span>}</span>
```

翻译一下就是：如果 `myName` 没有值，就再次从头运行`setUserName()`。如果有值（如果上面的表达式不为真），就把值存储到 `localStorage` 并设置为标题文本。

## [总结](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics#%E6%80%BB%E7%BB%93)

如果你一直跟着这篇文章里的指导做的话，你应该完成了一个像下面这样的页面。你也可以[查看我们的版本](https://mdn.github.io/beginner-html-site-scripted/)。

![创建元素后 HTML 页面最终的样子：一个标题、居中的大标志、内容和一个按钮](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics/website-screen-scripted.png)

如果你遇到困难，你可以将 [Github 上的完整示例代码](https://github.com/mdn/beginner-html-site-scripted/blob/main/scripts/main.js)与你的文件进行比较。

我们才接触到 JavaScript 的表面。要是你玩得开心，并希望继续下去，好好利用下面的资源。

## [参见](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/JavaScript_basics#%E5%8F%82%E8%A7%81)

[JavaScript——动态客户端脚本语言](https://developer.mozilla.org/zh-CN/docs/Learn/JavaScript)

更深入地了解 JavaScript。

[学习 JavaScript](https://learnjavascript.online/)

为有进取心的 Web 开发人员准备的优秀资源——在交互式环境中通过自动评估引导的短课程和交互式测试学习 JavaScript。前 40 节课为免费课程，而完整的课程仅需一次性支付少量费用。

-   [上一页](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/CSS_basics)
-   [概述：Web 入门](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web)
-   [下一页](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/Publishing_your_website)
