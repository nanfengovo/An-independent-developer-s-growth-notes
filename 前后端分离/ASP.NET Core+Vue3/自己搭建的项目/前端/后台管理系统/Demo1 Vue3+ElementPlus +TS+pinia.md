# CMS: Common Manager System
##  新建项目
### 第一步：
>npm init vue@latest
![[Pasted image 20250224000316.png]]
### 最终
>我们这里先不引入Vue Router 和Pinia 到时候手动引入
![[Pasted image 20250224001510.png]]
## 查看项目
### 目录结构
![[Pasted image 20250224001856.png]]
#### .vscode文件夹下的extensions.json 是vscode下推荐安装的插件
#### node_modules: 包
#### public :静态资源
#### Src: 源代码
#### index.html:程序入口的母版
#### vite.config.ts: 给vite配置
![[Pasted image 20250224002933.png]]

#### tsconfig.node.json：为SSR考虑
![[Pasted image 20250224003351.png]]
## 项目配置
### 配置项目的icon
![[Pasted image 20250224011716.png]]
### 配置项目的标题
### 配置项目别名（Vite默认配置）
### 配置tsconfig.json
## 项目代码规范 -editorconfig 文件配置
## 项目代码规范 -prettier格式化配置
### 1、 安装prettier 
>npm install prettier -D
### 2、配置prettier文件
* useTabs : 使用tab缩进还是使用空格缩进 选择false
* tabWidth : tab是空格的情况下，是几个空格，选择2个
* printWidth : 当行字符的长度，推荐80
* singleQuote : 使用单引号还是双引号，选择true使用单引号
* trailingComma : 在多行输入的尾逗号是否添加，设置为none,比如对象类型的最后一个属性后面是否加一个，；
* semil : 语句末尾是否要加分号，默认为true 选择false表示不加
```
{

  "$schema": "https://json.schemastore.org/prettierrc",

  "semi": false,

  "singleQuote": true,

  "printWidth": 80,

  "useTabs": false,

  "tabWidth": 2,

  "trailingComma": "none"

}
```
### 3、创建prettierignore忽略文件
### 4、在VSCode中安装prettier插件并配置
>setting =>editor default format => 选择prettier - Code formmatter

![[Pasted image 20250224125826.png]]
### 5、测试prettier是否有效
* 在代码中保存代码
* 配置一次性修改的命令
*在 package.json中配置一个scripts:
>prettier "prettier  --write."*


## 项目代码规范 -eslint代码检测配置

### 安装插件
![[Pasted image 20250224133058.png]]
### 配置ESLint
![[Pasted image 20250224133411.png]]
### 解决ESLint和Prettier冲突问题
安装插件
>npm install eslint-plugin-prettier eslint-config-prettier -D

## CSS样式的重置
### 对默认CSS样式进行重置
* normalize.css
* reset.css
#### 使用normalize.css
>npm install normalize.css

#### 创建CSS文件夹
![[Pasted image 20250224223934.png]]
#### 从网上找reset.less并粘贴进去
```
// reset.less

  

// Reset box-sizing

*,

*::before,

*::after {

    box-sizing: border-box;

}

  

// Reset margin and padding

body,

h1,

h2,

h3,

h4,

h5,

h6,

p,

figure,

blockquote,

dl,

dd {

    margin: 0;

    padding: 0;

}

  

// Set up a root default font size

html {

    font-size: 16px;

}

  

// Set default body styles

body {

    font-family:

        -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu,

        Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;

    line-height: 1.5;

    color: #333;

    background-color: #fff;

}

  

// Reset headings

h1,

h2,

h3,

h4,

h5,

h6 {

    font-size: inherit;

    font-weight: normal;

}

  

// Reset list styles

ul,

ol {

    list-style: none;

}

  

// Reset table styles

table {

    border-collapse: collapse;

    border-spacing: 0;

}

  

// Reset form elements

input,

button,

textarea,

select {

    font: inherit;

    margin: 0;

}

  

// Reset links

a {

    text-decoration: none;

    color: inherit;

}

  

// Reset images

img {

    max-width: 100%;

    height: auto;

}

  

// Reset form element styles

button,

input,

optgroup,

select,

textarea {

    margin: 0;

    font-family: inherit;

    font-size: inherit;

    line-height: inherit;

}

  

// Remove default focus styles

:focus {

    outline: 0;

}

  

// Remove default button styles

button {

    background: none;

    border: none;

    cursor: pointer;

}

  

// Remove default fieldset styles

fieldset {

    border: 0;

}

  

// Remove default legend styles

legend {

    padding: 0;

}

  

// Utility classes

.hidden {

    display: none;

}

  

.visually-hidden {

    position: absolute;

    width: 1px;

    height: 1px;

    margin: -1px;

    padding: 0;

    overflow: hidden;

    clip: rect(0, 0, 0, 0);

    border: 0;

}

  

// Add more resets or utility classes as needed
```
#### 在main.ts中引入
![[Pasted image 20250224224128.png]]
#### npm run dev 运行项目 发现报错
![[Pasted image 20250224224205.png]]
#### 根据提示安装npm install -D less

### 补充
>import和@import的区别

#### 至此完成了CSS的重置


>@import
>**用途**：`@import` 是 CSS 中的一个功能，用于在一个 CSS 文件中引入其他 CSS 文件的内容
>**语法**：通常的用法是在一个 CSS 文件的顶部使用 `@import 'path/to/stylesheet.css';`。
>**上下文**：`@import` 仅用于 CSS 文件中，它不会在 JavaScript 文件中使用。

>import
> **用途**：`import` 是 ES6 (ECMAScript 2015) 模块系统中的一部分，用于在 JavaScript 文件中引入其他 JavaScript 模块、组件、变量、函数等。
> **语法**：在 JavaScript 文件中使用 `import` 关键字，如 `import myComponent from './myComponent.vue';`。
> **上下文**：`import` 可以用于 JavaScript 文件中，包括 `.js`、`.vue` 文件等，用于引入模块、组件或其他资源

>总结：
>- `@import` 用于 CSS 文件，用于引入其他 CSS 文件。
>- - `import` 用于 JavaScript 文件，用于引入 JavaScript 模块或组件。
