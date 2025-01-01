# CSS基本语法
## 选择器
![[Pasted image 20241231221856.png]]
选择器{
	
}
### 元素选择器
ex:
```css
    header {

            color: red;

        }

        p {

            color: blue;

        }
```
### 类选择器
ex：
```css
  #my_header p{

            color: yellow;

        }
```
### 子选择器
>#box1>div>p{
>}

### 邻居选择器
>#all-acticles h2 + p{
>}

## CSS的三种使用方式
### 行内样式(Inline Styling)
ex:
```CSS
<label style="color: aqua;">行内样式</label>
```

### 内部样式(Internal Styling)
ex:
```CSS
    <style>

        header {

            color: red;

        }

        p {

            color: blue;

        }

        #my_header p{

            color: yellow;

        }

    </style>
```
### 外部样式(External Styling):单独的

```
<!DOCTYPE html>

<html lang="en">

<head>

    <meta charset="UTF-8">

    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>Document</title>

    <link rel="stylesheet" href="style.css">

</head>

<body>

    <h1>第一个页面</h1>

    <p>段落一</p>

    <p>段落二</p>

</body>

</html>
```
## CSS颜色
###  直接定义
ex：
```css
   body{

            color: blue;

        }

        #p1{

            color:tomato;

        }
```
### rgb
ex:
```css
  #p2{

            color: rgb(78, 81, 78);

        }
```
### 16进制
ex:
```css
      #p3{

            color: #ffffff;

            background-color: black;

        }
```
### hsl 
```css
    #p4{

            /*HSL*/

            /* H:色调 */

            /* S:饱和度 */

            /* L:亮度 */

            color: hsl(100, 84%, 66%);

        }
```
## 字体
```css
			 font-family: cursive, sans-serif;

            font-size: 50px;

            font-weight: bold;

            font-style: italic;
```
font-family:字体  如果第一个找不到用后面的那个
font-size：字体的大小
font-weight：字体的粗细 bold     加粗
font-style: 字体的风格  italic  斜体
## 边框 border
ex:
```css
  p{

            border-style: dotted;/*边框样式 solid :实线* ,dotted 虚线*/

            border-width: 5px;/*边框宽度*/

            border-color: red;/*边框颜色*/

            border-radius: 10px;/*边框圆角*/

        }
```
简写：
    #p2{

            border: solid 5px blue;/*简写*/

        }
 ### 每个边用不同的
 ```css
     #p3{

            border-top: solid 5px green;/*上边框*/

            border-bottom: dotted 5px red;/*下边框*/

            border-left: solid 5px yellow;/*左边框*/

            border-right: solid 5px purple;/*右边框*/

        }
```
## CSS 阴影
### 文字阴影
```css
<!DOCTYPE html>

<html lang="en">

<head>

    <meta charset="UTF-8">

    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>CSS阴影</title>

    <style>

        h1{

            text-shadow: 20px 20px 10px  red;/*水平阴影 垂直阴影 模糊距离 阴影颜色*/

        }

    </style>

</head>

<body>

    <!--文字阴影   盒子(box)阴影-->

    <h1>nanfengovo</h1>

    <div id="div_1">

        我是第一个盒子

    </div>

    <div id="div_2">

        我是第二个盒子

    </div>

</body>

</html>
```

>text-shadow: 20px 20px 10px  red;/*水平阴影 垂直阴影 模糊距离 阴影颜色*/  

 - 第一个20表示水平阴影20px
 - 第二个20表示垂直阴影20px
 - 第三个10表示阴影的模糊度
 - red表示阴影的颜色

### 盒子阴影   --实现较为好看的登录框

>盒子阴影（box-shadow）是CSS中的一个属性，用于在元素的框周围添加阴影效果。它的语法如下：
>box-shadow: [水平偏移] [垂直偏移] [模糊半径] [扩展半径] [阴影颜色];

- **水平偏移**（horizontal offset）：阴影相对于元素框的水平偏移量。正值表示阴影向右偏移，负值表示阴影向左偏移。
- **垂直偏移**（vertical offset）：阴影相对于元素框的垂直偏移量。正值表示阴影向下偏移，负值表示阴影向上偏移。
- **模糊半径**（blur radius）：阴影的模糊程度。值越大，阴影越模糊。可以省略，默认为0，即阴影边缘是锐利的。
- **扩展半径**（spread radius）：阴影的扩展程度。正值表示阴影扩大，负值表示阴影收缩。可以省略，默认为0。
- **阴影颜色**（shadow color）：阴影的颜色。可以使用任何有效的CSS颜色值。
## 外边距  margin     margin:auto 表示水平居中
>以下是关于 CSS `margin` 属性的详细解释：

`margin` 属性用于设置元素的外边距，可以用来控制元素与其周围元素之间的距离。`margin` 属性可以接受一个、两个、三个或四个值。

### 单个值

当 `margin` 只有一个值时，这个值会应用到元素的四个边（上、右、下、左）。

margin: 20px;

### 两个值

当 `margin` 有两个值时，第一个值应用于上下边，第二个值应用于左右边。

margin: 20px 10px;

### 三个值

当 `margin` 有三个值时，第一个值应用于上边，第二个值应用于左右边，第三个值应用于下边。

margin: 20px 10px 30px;

### 四个值

当 `margin` 有四个值时，依次应用于上、右、下、左边。

margin: 20px 10px 30px 5px;

### 自动值

`margin` 也可以设置为 `auto`，通常用于水平居中对齐块级元素。


## 浮动排版  float
`float` 属性用于将元素从正常的文档流中取出，并使其向左或向右浮动。浮动元素会尽可能地向左或向右对齐，并且后续的内容会围绕它们排列。

### 语法

float: none | left | right | inherit;

### 属性值

- `none`：默认值。元素不浮动，保持在文档流中。
- `left`：元素向左浮动。
- `right`：元素向右浮动。
- `inherit`：从父元素继承 `float` 属性的值。

## Overflow
![[Pasted image 20250101103922.png]]
### hidden
溢出的内容被隐藏不显示
### visible 
可以看到溢出

### clip
类似hidden
### scroll
添加滚动条
### auto
区域够大就不出现滚动条
不够大就出现


## display 
### 初始display
div 默认是区块的
span 默认是行内的

可以将div设置成行内通过 display :inline

### inline-block
可以设置高度

### none
不可见
## height and width
添加
   *{

            box-sizing: border-box;

        }
可以忽略边框

>  min-width: 25%;max-width: 50%;
最大宽度和最小宽度

## Position
### absolute    绝对定位  是相对于父容器而言的
绝对定位 如果超出父元素所在容器但是不希望超出父元素所在的容器可以在父元素的css中加入
>position: relative;

### fixed 固定位置  是相对于页面而言的

### sticky
固定和页面顶部的距离
## 盒模型 （Box MOdel）
  <!-- content:内容 -->
    <!-- margin:外边距 -->

    <!-- padding:内边距 -->

    <!-- border:边框 -->
## Padding 
内容与元素间的距离

