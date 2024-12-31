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
