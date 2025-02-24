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

