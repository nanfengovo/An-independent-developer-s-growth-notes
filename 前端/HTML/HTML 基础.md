---
created: 2024-10-15T09:34:17 (UTC +08:00)
tags: []
source: https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics
author: 
---

# HTML 基础 - 学习 Web 开发 | MDN

> ## Excerpt
> 超文本标记语言（英语：HyperText Markup Language，简称：HTML）是一种用来结构化 Web 网页及其内容的标记语言。网页内容可以是：一组段落、一个重点信息列表、也可以含有图片和数据表格。正如标题所示，本文将对 HTML 及其功能做一个基本介绍。

---
-   [上一页](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/Dealing_with_files)
-   [概述：Web 入门](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web)
-   [下一页](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/CSS_basics)

超文本标记语言（英语：**H**yper**T**ext **M**arkup **L**anguage，简称：HTML）是一种用来结构化 Web 网页及其内容的标记语言。网页内容可以是：一组段落、一个重点信息列表、也可以含有图片和数据表格。正如标题所示，本文将对 HTML 及其功能做一个基本介绍。

## [HTML 到底是什么？](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics#html_%E5%88%B0%E5%BA%95%E6%98%AF%E4%BB%80%E4%B9%88%EF%BC%9F)

HTML 是一种用于定义内容结构的_标记语言_。HTML 由一系列的[**元素**](https://developer.mozilla.org/zh-CN/docs/Glossary/Element)组成，这些元素可以用来包围不同部分的内容，使其以某种方式呈现或者工作。一对[标签](https://developer.mozilla.org/zh-CN/docs/Glossary/Tag)可以为一段文字或者一张图片添加超链接，将文字设置为斜体，改变字号，等等。例如，键入下面一行内容：

```
My cat is very grumpy
```

可以将这行文字封装成一个段落元素来使其独立成行：

```
<span><span><span>&lt;</span>p</span><span>&gt;</span></span>My cat is very grumpy<span><span><span>&lt;/</span>p</span><span>&gt;</span></span>
```

### [HTML 元素详解](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics#html_%E5%85%83%E7%B4%A0%E8%AF%A6%E8%A7%A3)

让我们深入探索一下这个段落元素。

![段落元素，包含：开始标签，‘my cat is very grumpy’的内容，结束标签](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics/grumpy-cat-small.png)

这个元素的主要部分有：

1.  **开始标签**（Opening tag）：包含元素的名称（本例为 p），及一对包围名称的**尖括号**。这表示元素从这里开始或者开始起作用——在本例中即段落由此开始。
2.  **结束标签**（Closing tag）：与开始标签相似，只是其在元素名之前包含了一个_正斜杠_。这表示元素到这里结束——在本例中即段落在此结束。初学者常常会犯忘记添加结束标签的错误，这可能会产生一些奇怪的结果。
3.  **内容**（Content）：元素的内容，本例中就是所输入的文本本身。
4.  **元素**（Element）：开始标签、结束标签与内容相结合，便是一个完整的元素。

元素也可以有下图中那样的属性（Attribute）：

![段落开始标签，以及高亮的 class 属性：class=editor-note](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics/grumpy-cat-attribute-small.png)

属性包含的是不想在真正的内容中出现的和元素有关的额外信息。本例中，`class` 是属性_名_，`editor-note` 是属性_值_。`class` 属性是可以用于定位元素（以及任何其他有相同 `class` 值的元素）的标识名称，以便进一步为元素指定样式或进行其他操作时使用。一些属性没有值，如 [`required`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Attributes/required)。

有值的属性应该包含：

1.  属性与元素名称（或上一个属性，如果元素有超过一个属性的话）之间的一个空格。
2.  属性名，后接一个等号。
3.  一对引号包围的属性值。

**备注：**不包含 [ASCII](https://developer.mozilla.org/zh-CN/docs/Glossary/ASCII) 空格（以及 `"` `'` `` ` `` `=` `<` `>`）的简单属性值可以不使用引号，但是建议将所有属性值用引号括起来，这样的代码一致性更佳，更易于阅读。

### [嵌套元素](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics#%E5%B5%8C%E5%A5%97%E5%85%83%E7%B4%A0)

也可以将一个元素置于其他元素之中——称作**嵌套**。要表明猫咪**非常**暴躁，可以将“very”用 [`<strong>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/strong) 元素包围，“very”将突出显示：

```
<span><span><span>&lt;</span>p</span><span>&gt;</span></span>My cat is <span><span><span>&lt;</span>strong</span><span>&gt;</span></span>very<span><span><span>&lt;/</span>strong</span><span>&gt;</span></span> grumpy.<span><span><span>&lt;/</span>p</span><span>&gt;</span></span>
```

必须保证元素的嵌套次序正确：在上面的例子中，首先使用 [`<p>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/p) 标签，然后是 [`<strong>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/strong) 标签，因此要先结束 [`<strong>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/strong) 标签，最后再结束 [`<p>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/p) 标签。这样是不对的：

```
<span><span><span>&lt;</span>p</span><span>&gt;</span></span>My cat is <span><span><span>&lt;</span>strong</span><span>&gt;</span></span>very grumpy.<span><span><span>&lt;/</span>p</span><span>&gt;</span></span><span><span><span>&lt;/</span>strong</span><span>&gt;</span></span>
```

元素必须正确地开始和结束，才能清楚地显示出正确的嵌套层次。要是像上面那样交叠使用，浏览器就得自己猜测，虽然它会竭尽全力，但很大程度不会给你期望的结果。所以一定要避免！

### [空元素](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics#%E7%A9%BA%E5%85%83%E7%B4%A0)

不包含任何内容的元素称为[**空元素**](https://developer.mozilla.org/zh-CN/docs/Glossary/Void_element)。我们以 HTML 页面中已有的 [`<img>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/img) 元素为例：

```
<span><span><span>&lt;</span>img</span> <span>src</span><span><span>=</span><span>"</span>images/firefox-icon.png<span>"</span></span> <span>alt</span><span><span>=</span><span>"</span>My test image<span>"</span></span> <span>/&gt;</span></span>
```

本元素包含两个属性，但是并没有 `</img>` 结束标签，元素里也没有内容。这是因为图像元素不需要通过内容来产生效果，它的作用是向其所在的位置嵌入一张图片。

### [HTML 文档详解](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics#html_%E6%96%87%E6%A1%A3%E8%AF%A6%E8%A7%A3)

以上把 HTML 元素作为个体进行介绍，但孤木不成林。现在来看看单个元素如何彼此协同构成一个完整的 HTML 页面。回顾[处理文件](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/Dealing_with_files)文章中创建的 `index.html` 示例：

```
<span><span>&lt;!</span><span>doctype</span> <span>html</span><span>&gt;</span></span>
<span><span><span>&lt;</span>html</span> <span>lang</span><span><span>=</span><span>"</span>en-US<span>"</span></span><span>&gt;</span></span>
  <span><span><span>&lt;</span>head</span><span>&gt;</span></span>
    <span><span><span>&lt;</span>meta</span> <span>charset</span><span><span>=</span><span>"</span>utf-8<span>"</span></span> <span>/&gt;</span></span>
    <span><span><span>&lt;</span>meta</span> <span>name</span><span><span>=</span><span>"</span>viewport<span>"</span></span> <span>content</span><span><span>=</span><span>"</span>width=device-width<span>"</span></span> <span>/&gt;</span></span>
    <span><span><span>&lt;</span>title</span><span>&gt;</span></span>My test page<span><span><span>&lt;/</span>title</span><span>&gt;</span></span>
  <span><span><span>&lt;/</span>head</span><span>&gt;</span></span>
  <span><span><span>&lt;</span>body</span><span>&gt;</span></span>
    <span><span><span>&lt;</span>img</span> <span>src</span><span><span>=</span><span>"</span>images/firefox-icon.png<span>"</span></span> <span>alt</span><span><span>=</span><span>"</span>My test image<span>"</span></span> <span>/&gt;</span></span>
  <span><span><span>&lt;/</span>body</span><span>&gt;</span></span>
<span><span><span>&lt;/</span>html</span><span>&gt;</span></span>
```

这里有：

-   `<!doctype html>`——[文档类型](https://developer.mozilla.org/zh-CN/docs/Glossary/Doctype)。这是必不可少的开头。混沌初分，HTML 尚在襁褓（大约是 1991/92 年）之时，这个元素用来关联 HTML 编写规范，以供自动查错等功能所用。而在当今，它作用有限，可以说仅用于保证文档正常读取。现在知道这些就足够了。
-   `<html></html>`——[`<html>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/html) 元素。该元素包含整个页面的所有内容，有时候也称作根元素。它还包含 `lang` 属性，设置页面的主要语种。
-   `<head></head>`——[`<head>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/head) 元素。该元素作为想在 HTML 页面中包含但不想向用户显示的内容的容器。包括想在搜索结果中显示的[关键字](https://developer.mozilla.org/zh-CN/docs/Glossary/Keyword)和页面描述、用于设置页面样式的 CSS、字符集声明等等。
-   `<meta charset="utf-8">`——该元素指明你的文档使用 UTF-8 字符编码，UTF-8 包括世界绝大多数书写语言的字符。它基本上可以处理任何文本内容。以它为编码还可以避免以后出现某些问题，没有理由再选用其他编码。
-   `<meta name="viewport" content="width=device-width">`——[视口元素](https://developer.mozilla.org/zh-CN/docs/Web/CSS/Viewport_concepts#%E7%A7%BB%E5%8A%A8%E8%AE%BE%E5%A4%87%E7%9A%84%E8%A7%86%E5%8F%A3)可以确保页面以视口宽度进行渲染，避免移动端浏览器以比视口更宽的宽度渲染内容，导致内容缩小。
-   `<title></title>`——[`<title>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/title) 元素。该元素设置页面的标题，显示在浏览器标签页上，也作为收藏网页的描述文字。
-   `<body></body>`——[`<body>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/body) 元素。该元素包含期望让用户在访问页面时看到的_全部_内容，包括文本、图像、视频、游戏、可播放的音轨或其他内容。

## [图像](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics#%E5%9B%BE%E5%83%8F)

重温一下 [`<img>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/img) 元素：

```
<span><span><span>&lt;</span>img</span> <span>src</span><span><span>=</span><span>"</span>images/firefox-icon.png<span>"</span></span> <span>alt</span><span><span>=</span><span>"</span>My test image<span>"</span></span> <span>/&gt;</span></span>
```

正如之前讲的那样，该元素通过在属性 `src` 中包含图像文件路径的地址，可在所在位置嵌入图像。

该元素还包括一个替换文字属性 `alt`。在 [`alt` 属性](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/img#%E4%BD%BF%E7%94%A8%E6%9C%89%E5%AE%9E%E9%99%85%E6%84%8F%E4%B9%89%E7%9A%84%E5%A4%87%E7%94%A8%E6%8F%8F%E8%BF%B0)中，是图像的描述内容，用于当图像不能被用户看见时显示，不可见的原因可能是：

1.  用户有视觉障碍。有严重视觉障碍的用户可以使用屏幕阅读器来朗读 alt 属性的内容。
2.  有些错误使图像无法显示。可以试着故意将 `src` 属性里的路径改错。保存并刷新页面就可以在图像位置看到：

![图片内容为文字“测试图片”](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics/alt-text-example.png)

alt 文本的关键字即“描述文本”。alt 文本应向用户完整地传递图像要表达的意思。用“测试图片”来描述 Firefox 标志并不合适，修改成“Firefox 标志：一只盘旋在地球上的火狐”就好多了。

可以试着为图像编写一些更好的 alt 文本。

## [标记文本](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics#%E6%A0%87%E8%AE%B0%E6%96%87%E6%9C%AC)

本小节包含了一些最常用的文本标记 HTML 元素。

### [标题（Heading）](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics#%E6%A0%87%E9%A2%98%EF%BC%88heading%EF%BC%89)

标题元素可用于指定内容的标题和子标题。就像一本书的书名、每章的大标题、小标题，等。HTML 文档也是一样。HTML 包括六个级别的标题，[<h1> - <h6>](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/Heading_Elements)，一般最多用到 3-4 级标题。

```
<span>&lt;!-- 4 个级别的标题 --&gt;</span>
<span><span><span>&lt;</span>h1</span><span>&gt;</span></span>主标题<span><span><span>&lt;/</span>h1</span><span>&gt;</span></span>
<span><span><span>&lt;</span>h2</span><span>&gt;</span></span>顶层标题<span><span><span>&lt;/</span>h2</span><span>&gt;</span></span>
<span><span><span>&lt;</span>h3</span><span>&gt;</span></span>子标题<span><span><span>&lt;/</span>h3</span><span>&gt;</span></span>
<span><span><span>&lt;</span>h4</span><span>&gt;</span></span>次子标题<span><span><span>&lt;/</span>h4</span><span>&gt;</span></span>
```

**备注：**在 HTML 中，`<!--` 和 `-->` 之间的任何内容都是 **HTML 注释**。浏览器在渲染代码时，会忽略掉注释。换句话说，注释在页面上不可见——仅停留在代码中。HTML 注释是你书写与代码有关的注解或逻辑的一种方式。

可以尝试在 [`<img>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/img) 元素上面添加一个合适的标题。

**备注：**你可以看到第一级标题是有隐式的主题样式。不要使用标题元素来加大、加粗文本，因为标题对于[无障碍](https://developer.mozilla.org/zh-CN/docs/Learn/Accessibility/HTML#%E6%96%87%E6%9C%AC%E5%86%85%E5%AE%B9)和[搜索引擎优化](https://developer.mozilla.org/zh-CN/docs/Learn/HTML/Introduction_to_HTML/HTML_text_fundamentals#%e4%b8%ba%e4%bb%80%e4%b9%88%e6%88%91%e4%bb%ac%e9%9c%80%e8%a6%81%e7%bb%93%e6%9e%84%e5%8c%96%ef%bc%9f)非常有意义。要保持页面结构清晰，标题整洁，不要发生标题级别跳跃。

### [段落（Paragraph）](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics#%E6%AE%B5%E8%90%BD%EF%BC%88paragraph%EF%BC%89)

如上文所讲，[`<p>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/p) 元素是用来指定段落的。通常用于指定常规的文本内容：

试着向一个或几个段落中添加一些文本（[_你的网站会是什么样子？_](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/What_will_your_website_look_like)文章中有这些文本），并把它们放在你的 [`<img>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/img) 元素下方。

### [列表（List）](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics#%E5%88%97%E8%A1%A8%EF%BC%88list%EF%BC%89)

Web 上的许多内容都是列表，HTML 有一些特别的列表元素。标记列表通常包括至少两个元素。最常用的列表类型为：

1.  **无序列表**（Unordered List）中项目的顺序并不重要，就像购物列表。用一个 [`<ul>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/ul) 元素包围。
2.  **有序列表**（Ordered List）中项目的顺序很重要，就像烹调指南。用一个 [`<ol>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/ol) 元素包围。

列表的每个项目用一个列表项目（List Item）元素 [`<li>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/li) 包围。

比如，要将下面的段落片段改成一个列表：

```
<span><span><span>&lt;</span>p</span><span>&gt;</span></span>
  At Mozilla, we're a global community of technologists, thinkers, and builders
  working together…
<span><span><span>&lt;/</span>p</span><span>&gt;</span></span>
```

可以这样更改标记：

```
<span><span><span>&lt;</span>p</span><span>&gt;</span></span>At Mozilla, we're a global community of<span><span><span>&lt;/</span>p</span><span>&gt;</span></span>

<span><span><span>&lt;</span>ul</span><span>&gt;</span></span>
  <span><span><span>&lt;</span>li</span><span>&gt;</span></span>technologists<span><span><span>&lt;/</span>li</span><span>&gt;</span></span>
  <span><span><span>&lt;</span>li</span><span>&gt;</span></span>thinkers<span><span><span>&lt;/</span>li</span><span>&gt;</span></span>
  <span><span><span>&lt;</span>li</span><span>&gt;</span></span>builders<span><span><span>&lt;/</span>li</span><span>&gt;</span></span>
<span><span><span>&lt;/</span>ul</span><span>&gt;</span></span>

<span><span><span>&lt;</span>p</span><span>&gt;</span></span>working together…<span><span><span>&lt;/</span>p</span><span>&gt;</span></span>
```

试着在示例页面中添加一个有序列表和无序列表。

## [链接](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics#%E9%93%BE%E6%8E%A5)

链接非常重要 — 它们赋予 Web 网络属性。要植入一个链接，我们需要使用一个简单的元素 — [`<a>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/a) — “a”是“anchor”（锚）的缩写。要将一些文本添加到链接中，只需如下几步：

1.  选择一些文本。比如“Mozilla Manifesto”。
    
2.  将文本包含在 [`<a>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/a) 元素内，就像这样：
    
3.  为此 [`<a>`](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/a) 元素添加一个 `href` 属性，就像这样：
    
    ```
    <span><span><span>&lt;</span>a</span> <span>href</span><span><span>=</span><span>"</span><span>"</span></span><span>&gt;</span></span>Mozilla Manifesto<span><span><span>&lt;/</span>a</span><span>&gt;</span></span>
    ```
    
4.  把属性的值设置为所需网址：
    
    ```
    <span><span><span>&lt;</span>a</span> <span>href</span><span><span>=</span><span>"</span>https://www.mozilla.org/zh-CN/about/manifesto/<span>"</span></span><span>&gt;</span></span>
      Mozilla Manifesto
    <span><span><span>&lt;/</span>a</span><span>&gt;</span></span>
    ```
    

如果网址开始部分省略了 `https://` 或者 `http://`（称作_协议_），可能会得到错误的结果。在完成一个链接后，可以试着点击它来确保指向正确。

**备注：** `href` 这个名字可能一开始看起来有点令人费解。如果它很难记忆的话，记住它代表的是超文本引用（_**h**ypertext **ref**erence_）。

现在就为页面添加一个链接吧。

## [总结](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics#%E6%80%BB%E7%BB%93)

如果你一直跟着这篇文章里的指导做的话，你应该完成了一个像下面这样的页面（也可以[查看这里](https://mdn.github.io/beginner-html-site/)）：

![一张网页截图，包含：Firefox 标志，写着 Mozilla 很酷的标题以及两个文本段落](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/HTML_basics/finished-test-page-small.png)

如果你遇到困难，你可以将 Github 上的[完整示例代码](https://github.com/mdn/beginner-html-site/blob/main/index.html)与你的文件进行比较。

在这里，我们只是介绍了一点点 HTML。想学习更多，访问我们的[学习 HTML](https://developer.mozilla.org/zh-CN/docs/Learn/HTML) 主题。

-   [上一页](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/Dealing_with_files)
-   [概述：Web 入门](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web)
-   [下一页](https://developer.mozilla.org/zh-CN/docs/Learn/Getting_started_with_the_web/CSS_basics)
