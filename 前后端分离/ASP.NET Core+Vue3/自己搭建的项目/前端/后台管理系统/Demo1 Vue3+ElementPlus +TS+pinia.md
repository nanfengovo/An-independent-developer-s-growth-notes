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

## 全家桶 --路由配置
### npm install vue-router
### 在src文件夹下创建router文件夹在router文件夹下创建index.ts
```
import { createRouter, createWebHashHistory } from 'vue-router'

  

const router = createRouter({

    history: createWebHashHistory(),

    routes: []

})

  

export default router
```

### 在main.ts中使用
```
import { createApp } from 'vue'

import 'normalize.css'

import './assets/css/index.less'

import App from './App.vue'

import router from './router'

  

createApp(App).use(router).mount('#app')
```
### 在src文件夹下创建views文件夹
### 在views文件夹下创建login文件夹和main文件夹
### 在login文件夹和main文件夹下分别添加login.vue和main.vue
![[Pasted image 20250225002101.png]]
### 解决警告
![[Pasted image 20250225003449.png]]
```
import pluginVue from 'eslint-plugin-vue'

import {

    defineConfigWithVueTs,

    vueTsConfigs

} from '@vue/eslint-config-typescript'

import skipFormatting from '@vue/eslint-config-prettier/skip-formatting'

  

export default defineConfigWithVueTs(

    {

        name: 'app/files-to-lint',

        files: ['**/*.{ts,mts,tsx,vue}'],

        rules: {

            // 在这里直接覆盖规则

            'vue/multi-word-component-names': 'off'

        }

    },

    {

        name: 'app/files-to-ignore',

        ignores: ['**/dist/**', '**/dist-ssr/**', '**/coverage/**']

    },

    // 确保自定义规则覆盖默认规则

    {

        extends: [

            pluginVue.configs['flat/essential'],

            vueTsConfigs.recommended,

            skipFormatting

        ],

        rules: {

            // 再次确保自定义规则被应用

            'vue/multi-word-component-names': 'off'

        }

    }

)
```
## 配置代码片段
### 使用https://snippet-generator.app/
![[Pasted image 20250225191320.png]]
### VSCode 文件 ->首选项->配置代码片段复制右侧的内容粘贴上去

```
{

"vue3 typescript": {

  "prefix": "tsvue",

  "body": [

    "<template>",

    "    <div class=\"${1:home}\">",

    "        <h2>${1:home}</h2>",

    "    </div>",

    "</template>",

    "<script setup lang=\"ts\">",

    "</script>",

    "",

    "<style lang=\"less\" scoped>",

    ".${1:home}{}",

    "</style>"

  ],

  "description": "vue3 typescript"

}

}
```
## 配置路由
![[Pasted image 20250225194723.png]]
![[Pasted image 20250225194738.png]]
## pinia状态管理配置
### 安装pinia
>npm install pinia

### 在src文件夹下新建store文件夹，在store文件夹下新建index.ts

### index.ts中导入并使用pinia
![[Pasted image 20250225195303.png]]
### main.ts中使用pinia
![[Pasted image 20250225195454.png]]
## axios网络请求的配置
### 在src文件夹下新建service文件夹，在service文件夹下新建config文件夹、modules文件夹、request文件夹
### 安装axios
>npm install axios
### 在config文件夹下新建index.ts文件
![[Pasted image 20250225204332.png]]
### 在request文件夹下新建index.ts和type.ts
#### 其中type.ts文件内容如下：
```
import type { AxiosRequestConfig, AxiosResponse } from 'axios'

  

interface HYInterceptors<T = AxiosResponse> {

    requestInterceptor?: (config: AxiosRequestConfig) => AxiosRequestConfig

    requestInterceptorCatch?: (error: any) => any

    responseInterceptor?: (res: T) => T

    responseInterceptorCatch?: (error: any) => any

    requestSuccessFn?: (config: AxiosRequestConfig) => AxiosRequestConfig

    requestFailureFn?: (error: any) => any

    responseSuccessFn?: (res: T) => T

    responseFailureFn?: (error: any) => any

}

export interface HYRequestConfig<T = AxiosResponse> extends AxiosRequestConfig {

    interceptors?: HYInterceptors<T>

}
```

![[Pasted image 20250226124523.png]]
#### index.ts文件如下
```
import axios from 'axios'

import type { AxiosInstance } from 'axios'

import type { HYRequestConfig } from './type'

  

class HYRequest {

    instance: AxiosInstance

    //request实例 => axios实例

    constructor(config: HYRequestConfig) {

        this.instance = axios.create(config)

        //拦截器

        this.instance.interceptors.request.use(

            (config) => {

                console.log('全局请求成功的拦截')

                return config

            },

            (err) => {

                console.log('全局请求失败的拦截')

                return err

            }

        )

        this.instance.interceptors.response.use(

            (res) => {

                console.log('全局响应成功的拦截')

                return res.data

            },

            (err) => {

                console.log('全局响应失败的拦截')

                return err

            }

        )

  

        //针对特定的hyRequest实例进行拦截

        this.instance.interceptors.request.use(

            //config.interceptors?.requestSuccessFn,

            config.interceptors?.requestFailureFn

        )

        this.instance.interceptors.response.use(

            config.interceptors?.responseSuccessFn,

            config.interceptors?.responseFailureFn

        )

    }

  

    request<T = any>(config: HYRequestConfig<T>) {

        //单个请求的拦截

        if (config.interceptors?.requestSuccessFn) {

            config = config.interceptors.requestSuccessFn(config)

        }

  

        //返回一个promise

        return new Promise<T>((resolve, reject) => {

            this.instance

                .request<any, T>(config)

                .then((res) => {

                    if (config.interceptors?.responseSuccessFn) {

                        res = config.interceptors.responseSuccessFn(res)

                    }

                    resolve(res)

                })

                .catch((err) => {

                    reject(err)

                })

        })

    }

    get<T = any>(config: HYRequestConfig<T>) {

        return this.request({ ...config, method: 'GET' })

    }

  

    post<T = any>(config: HYRequestConfig<T>) {

        return this.request({ ...config, method: 'POST' })

    }

  

    delete<T = any>(config: HYRequestConfig<T>) {

        return this.request({ ...config, method: 'DELETE' })

    }

  

    patch<T = any>(config: HYRequestConfig<T>) {

        return this.request({ ...config, method: 'PATCH' })

    }

}

export default HYRequest
```

### 在service文件夹下创建 index.ts
```
import { BASE_URL, TIME_OUT } from './config'

import HYRequest from './request'

  

const hyRequest = new HYRequest({

    baseURL: BASE_URL,

    timeout: TIME_OUT

})

  

const hyRequest2 = new HYRequest({

    baseURL: 'http://codercba.com:1888/airbnb/api',

    timeout: 8000,

    interceptors: {

        requestSuccessFn: (config: any) => {

            console.log('请求成功的拦截')

            return config

        },

        requestFailureFn: (err: any) => {

            console.log('请求失败的拦截')

            return err

        },

        responseSuccessFn: (res: any) => {

            console.log('响应成功的拦截')

            return res

        },

        responseFailureFn: (err: any) => {

            console.log('响应失败的拦截')

            return err

        }

    }

})

  

export { hyRequest, hyRequest2 }
```
## 区分开发环境和生产环境
### 第一种方法
在service文件夹下 config文件夹下index.ts文件中写两个地址，开发环境注释生产环境的那个地址，打包的时候注释开发环境的地址
![[Pasted image 20250226183216.png]]
#### 第二种方法
根据当前的环境去选择，但是编译器不知道production
![[Pasted image 20250226190746.png]]
#### Vite的环境变量
Vite在一个特殊的import.meta.env对象上暴露环境变量。这里有一些在所有情况下都可以使用的内建变量
* import.meta.env.MODE:{string} 应用运行的模式
* import.meta.env.PROD:{boolean} 应用是否运行在生产环境
* import.meta.env.DEV:{boolean} 应用是否运行在开发环境
* import.meta.env.SSR:{boolean} 应用是否运行在server上
![[Pasted image 20250226191604.png]]
Vite使用dotenv从你的环境目录中的下列文件加载额外的环境变量
.env   # 所有情况都会加载
.env.local # 所有情况下都会加载，但会被git忽略
.env.[model]  # 只在特定模式下加载
.env.[model] # 只在特定模式下加载，但会被git忽略

只有以VITE_为前缀的变量才会暴露给经过vite处理的代码
![[Pasted image 20250226193545.png]]
## ElementPlus的集成
### 安装ElementPlus
>npm install element-plus

### 完整引入
#### 在main.ts中 
import ElementPlus from 'element-plus'
然后
app.use(ElementPlus)
这时npm run dev 发现按钮是没有样式的
需要
import 'element-plus/dist/index.css'
![[Pasted image 20250226203455.png]]
## App宽高铺满和ElementPlus的CSS
![[Pasted image 20250226214009.png]]
![[Pasted image 20250226214102.png]]
这样我们发现默认是没有占满屏幕的
![[Pasted image 20250226214402.png]]
即使App.vue中设置高度为100%也是不生效的
### 方法1：
![[Pasted image 20250226214715.png]]
![[Pasted image 20250226214733.png]]
### 方法2
![[Pasted image 20250226215801.png]]
## 登录页-Panel底部操作界面的搭建
### 引入背景图片
### 将登录的div封装成组件
####  登录页-panel中间tabs切换的搭建
```
<template>

    <div class="login-panel">

        <!--顶部标题-->

        <h1 class="title">后台管理系统</h1>

        <!--图标-->

        <img class="logo" src="@/assets/img/logo.png" alt="logo" />

        <!--选项卡-->

        <div class="tabs">

            <el-tabs type="border-card" stretch>

                <el-tab-pane label="账号登录">

  

                </el-tab-pane>

                <el-tab-pane label="手机登录">

  

                </el-tab-pane>

  

            </el-tabs>

        </div>

  

        <!--底部区域-->

        <div class="controls">

            <el-checkbox v-model="isRemPassword" label="记住密码" size="large" />

            <el-link type="primary">忘记密码</el-link>

        </div>

        <el-button type="primary" class="login-btn">Primary</el-button>

    </div>

</template>

<script setup lang="ts">

import { ref } from 'vue'

const isRemPassword = ref(false)

  

</script>

  

<style lang="less" scoped>

.login-panel {

    width: 380px;

    background-color: white;

    margin-bottom: 150px;

    height: 330px;

}

  

.logo {

    width: 80%;

    height: 15%;

    margin-left: 10%;

}

  

.title {

    text-align: center;

    margin-bottom: 15px;

}

  

.icon {

    display: flex;

    align-items: center;

    justify-content: center;

}

  

.text {

    margin-left: 5px;

}

  

.controls {

    margin-top: 12px;

    display: flex;

    justify-content: space-between;

}

  

.controls .el-checkbox {

    margin-left: 25px;

}

  

.controls .el-link {

    margin-right: 25px;

}

  
  

.login-btn {

    margin-top: 10px;

    margin-left: 5%;

    width: 90%;

}

</style>
```
效果：
![[Pasted image 20250227212026.png]]
## 图标的引入和使用
### 安装图标
>npm install @element-plus/icons-vue

### 注册图标
![[Pasted image 20250227213333.png]]
## 登录页-插槽的使用和tabs的切换绑定
![[Pasted image 20250227215717.png]]
最终代码
```
<template>

    <div class="login-panel">

        <!--顶部标题-->

        <h1 class="title">后台管理系统</h1>

        <!--图标-->

        <img class="logo" src="@/assets/img/logo.png" alt="logo" />

        <!--选项卡-->

        <div class="tabs">

            <el-tabs type="border-card" stretch v-model="activeName">

                <el-tab-pane label="账号登录" name="account">

                    <template #label>

                        <div class="label">

                            <el-icon>

                                <UserFilled />

                            </el-icon>

                            <span class="text">账号登录</span>

                        </div>

                    </template>

                </el-tab-pane>

                <el-tab-pane label="手机登录" name="phone">

                    <template #label>

                        <div class="label">

                            <el-icon>

                                <Cellphone />

                            </el-icon>

                            <span class="text">手机登录</span>

                        </div>

                    </template>

                </el-tab-pane>

  

            </el-tabs>

        </div>

  

        <!--底部区域-->

        <div class="controls">

            <el-checkbox v-model="isRemPassword" label="记住密码" size="large" />

            <el-link type="primary">忘记密码</el-link>

        </div>

        <el-button type="primary" class="login-btn" @click="handleLoginBtnClick">登录</el-button>

    </div>

</template>

<script setup lang="ts">

import { ref } from 'vue'

const activeName = ref('phone')

const isRemPassword = ref(false)

  

function handleLoginBtnClick() {

    if (activeName.value === 'account') {

        console.log('账号登录')

    } else {

        console.log('手机登录')

    }

}

  

</script>

  

<style lang="less" scoped>

.login-panel {

    width: 380px;

    background-color: white;

    margin-bottom: 150px;

    height: 330px;

}

  

.logo {

    width: 80%;

    height: 15%;

    margin-left: 10%;

}

  

.title {

    text-align: center;

    margin-bottom: 15px;

}

  

.label {

    display: flex;

    align-items: center;

    justify-content: center;

}

  

.text {

    margin-left: 5px;

}

  

.controls {

    margin-top: 12px;

    display: flex;

    justify-content: space-between;

}

  

.controls .el-checkbox {

    margin-left: 25px;

}

  

.controls .el-link {

    margin-right: 25px;

}

  
  

.login-btn {

    margin-top: 10px;

    margin-left: 5%;

    width: 90%;

}

</style>
```
## 登录页-账号登录的验证规则配置
效果图：
![[Pasted image 20250228001346.png]]
```
<template>

    <div class="pane-account">

        <el-form :model="account" label-width="60px" :rules="accountRules">

            <el-form-item label="账号" prop="name">

                <el-input v-model="account.name" placeholder="请输入账号" clearable />

            </el-form-item>

            <el-form-item label="密码" prop="password">

                <el-input type="password" v-model="account.password" placeholder="请输入密码" show-password clearable />

            </el-form-item>

        </el-form>

    </div>

</template>

<script setup lang="ts">

import { reactive } from 'vue';

import type { FormRules } from 'element-plus';

// 账号密码

const account = reactive({

    name: '',

    password: ''

})

  
  

// 表单验证规则

const accountRules: FormRules = {

    name: [

        { message: '必须输入账号~', required: true, trigger: 'blur' },

        { pattern: /^[a-z0-9]{3,10}$/, message: '必须是3到10位的数字或字母', trigger: 'blur' }

    ],

    password: [

        { message: '必须输入密码~', required: true, trigger: 'blur' },

        { pattern: /^[a-z0-9]{3,}$/, message: '必须是3位以上的数字或字母', trigger: 'blur' }

    ]

}

</script>

  

<style lang="less" scoped>

.pane-account {}

</style>
```

#### 关键点
![[Pasted image 20250228001452.png]]
## 登录页-父组件点击logi调用子组件的方法

![[Pasted image 20250228125326.png]]
## 表单的验证和EIMessage样式
>在子组件中验证登录的逻辑，如果用户的输入不符合规则，不应该执行登录（不提交表单，不发送请求）
![[Pasted image 20250228131301.png]]

## 账号的登录逻辑和登录状态保存
模拟登录
>![[Pasted image 20250301130903.png]]

![[Pasted image 20250301130920.png]]

## 本地缓存和缓存工具的封装
>localStorage和sessionStorage的区别
>localStorage:关闭网页还存在
>sessionStorage：关闭网页不存在

## 登录页-登录后的路由导航守卫
>判断用户是否登录？登录跳转到main，没登录跳转到login

![[Pasted image 20250301131542.png]]

## 退出登录
>1.清除token  2.router.push('/login');(回到登录页)

![[Pasted image 20250301131654.png]]
## 登录页-记住密码
![[Pasted image 20250301142929.png]]
![[Pasted image 20250301142950.png]]

## 权限控制的系统设计（RBAC设计方案）
>权限管理：根据登录用户的不同，呈现不同的后台管理系统内容（具备不同的操作权限）

### RBAC : role based access control(基于角色的访问控制)


## main 页面-main页面整体布局

最终效果：
![[Pasted image 20250302092047.png]]
代码：
```
<template>

    <div class="main">

        <!-- <el-button type='success' @click="handleExitClick">退出登录</el-button> -->

        <el-container class="main-container">

            <el-aside class="el-aside" width="200px">Aside</el-aside>

            <el-container>

                <el-header class="el-header">Header</el-header>

                <el-main class="el-main">Main</el-main>

            </el-container>

        </el-container>

    </div>

</template>

<script setup lang="ts">

// import router from '@/router';

  
  

//退出登录

// function handleExitClick() {

//     //1.清除token

//     localStorage.removeItem('token');

//     //2.跳转到登录页

//     router.push('/login');

// }

  

</script>

  

<style lang="less" scoped>

.home {

    color: blue;

}

  

.main-container {

    height: 100vh;

    width: 100vw;

  

    .el-aside {

        background-color: antiquewhite;

    }

  

    .el-header {

        background-color: aqua;

        height: 50px;

    }

  

    .el-main {

        background-color: bisque;

    }

}

</style>
```

## main页面 -左侧导航的整体布局
>权限控制：通过菜单来控制

### 在components文件夹下新建 main-menu文件夹和main-header文件夹分别在两个文件夹下新建与文件夹同名的.vue组件
最终效果：
![[Pasted image 20250302094106.png]]
代码：
```
<template>

    <div class="main-menu">

        <div class="logo">

            <img src="@/assets/img/logo.png" alt="logo加载失败" class="logo-img" />

        </div>

        <div class="menu">

            <el-menu default-active="2" class="el-menu-vertical-demo">

                <el-sub-menu index="1">

                    <template #title>

                        <el-icon>

                            <location />

                        </el-icon>

                        <span>Navigator One</span>

                    </template>

                    <el-menu-item-group title="Group One">

                        <el-menu-item index="1-1">item one</el-menu-item>

                        <el-menu-item index="1-2">item two</el-menu-item>

                    </el-menu-item-group>

                    <el-menu-item-group title="Group Two">

                        <el-menu-item index="1-3">item three</el-menu-item>

                    </el-menu-item-group>

                    <el-sub-menu index="1-4">

                        <template #title>item four</template>

                        <el-menu-item index="1-4-1">item one</el-menu-item>

                    </el-sub-menu>

                </el-sub-menu>

                <el-menu-item index="2">

                    <el-icon><icon-menu /></el-icon>

                    <span>Navigator Two</span>

                </el-menu-item>

                <el-menu-item index="3" disabled>

                    <el-icon>

                        <document />

                    </el-icon>

                    <span>Navigator Three</span>

                </el-menu-item>

                <el-menu-item index="4">

                    <el-icon>

                        <setting />

                    </el-icon>

                    <span>Navigator Four</span>

                </el-menu-item>

            </el-menu>

        </div>

    </div>

</template>

<script setup lang="ts">

</script>

  

<style lang="less" scoped>

.main-menu {}

  

.logo {

    height: 60px;

    display: flex;

    justify-content: center;

    align-items: center;

  

    .logo-img {

        height: 40px;

    }

}

</style>
```


## main页面-手动搭建menu菜单展示
### el-menu 组件的解析
![[6f44d00ae6f1bb6dee6318e372182f1.jpg]]
## 搭建静态的菜单导航栏
### 最终效果
![[Pasted image 20250302113225.png]]
代码
```
<template>

    <div class="main-menu">

        <div class="logo">

            <img src="@/assets/img/logo.png" alt="logo加载失败" class="logo-img" />

        </div>

        <div class="search">

  

            <input type="text" placeholder="输入菜单名称进行搜索" class="search-input" />

            <el-button type="primary" class="search-button">

                <el-icon>

                    <Search />

                </el-icon>

            </el-button>

        </div>

        <div class="menu">

            <el-menu text-color="#b7bdc3" active-text-color="#fff" background-color="#001529">

                <!-- 系统管理 -->

                <el-sub-menu index="1">

                    <template #title>

                        <el-icon>

                            <Monitor />

                        </el-icon>

                        <span>系统管理</span>

                    </template>

                    <el-menu-item>

                        <template #title>

                            <el-icon>

                                <Platform />

                            </el-icon>

                            <span>大屏数据展示</span>

                        </template>

                    </el-menu-item>

                    <el-menu-item>

                        <template #title>

                            <el-icon>

                                <Histogram />

                            </el-icon>

                            <span>系统监控面板</span>

                        </template>

                    </el-menu-item>

                    <el-menu-item>

                        <template #title>

                            <el-icon>

                                <Open />

                            </el-icon>

                            <span>自动任务管理</span>

                        </template>

                    </el-menu-item>

                </el-sub-menu>

  

                <!-- 库位管理 -->

                <el-sub-menu index="2">

                    <template #title>

                        <el-icon>

                            <MapLocation />

                        </el-icon>

                        <span>库位管理</span>

                    </template>

                    <el-menu-item>

                        <template #title>

                            <el-icon>

                                <Location />

                            </el-icon>

                            <span>平面库位展示</span>

                        </template>

                    </el-menu-item>

                    <el-menu-item>

                        <template #title>

                            <el-icon>

                                <AddLocation />

                            </el-icon>

                            <span>3D库位展示</span>

                        </template>

                    </el-menu-item>

                </el-sub-menu>

  

                <!-- 任务管理 -->

                <el-sub-menu index="3">

                    <template #title>

                        <el-icon>

                            <Odometer />

                        </el-icon>

                        <span>任务管理</span>

                    </template>

                    <el-menu-item>

                        <template #title>

                            <el-icon>

                                <Clock />

                            </el-icon>

                            <span>提升机任务管理</span>

                        </template>

                    </el-menu-item>

                    <el-menu-item>

                        <template #title>

                            <el-icon>

                                <PieChart />

                            </el-icon>

                            <span>四向车任务管理</span>

                        </template>

                    </el-menu-item>

                </el-sub-menu>

  

                <!-- 任务运维 -->

                <el-sub-menu index="4">

                    <template #title>

                        <el-icon>

                            <Setting />

                        </el-icon>

                        <span>系统运维管理</span>

                    </template>

                    <el-menu-item>

                        <template #title>

                            <el-icon>

                                <Link />

                            </el-icon>

                            <span>Modbus数据点运维</span>

                        </template>

                    </el-menu-item>

                    <el-menu-item>

                        <template #title>

                            <el-icon>

                                <Cpu />

                            </el-icon>

                            <span>S7数据点运维</span>

                        </template>

                    </el-menu-item>

                </el-sub-menu>

  

                <!-- 系统日志管理 -->

                <el-sub-menu index="5">

                    <template #title>

                        <el-icon>

                            <TrendCharts />

                        </el-icon>

                        <span>系统日志管理</span>

                    </template>

                    <el-menu-item>

                        <template #title>

                            <el-icon>

                                <Document />

                            </el-icon>

                            <span>操作日志记录</span>

                        </template>

                    </el-menu-item>

                    <el-menu-item>

                        <template #title>

                            <el-icon>

                                <ChromeFilled />

                            </el-icon>

                            <span>自动任务日志</span>

                        </template>

                    </el-menu-item>

                    <el-menu-item>

                        <template #title>

                            <el-icon>

                                <Aim />

                            </el-icon>

                            <span>数据点读写日志</span>

                        </template>

                    </el-menu-item>

                </el-sub-menu>

  

                <!-- 权限管理 -->

                <el-sub-menu index="6">

                    <template #title>

                        <el-icon>

                            <More />

                        </el-icon>

                        <span>权限管理</span>

                    </template>

                    <el-menu-item>

                        <template #title>

                            <el-icon>

                                <UserFilled />

                            </el-icon>

                            <span>用户管理</span>

                        </template>

                    </el-menu-item>

                    <el-menu-item>

                        <template #title>

                            <el-icon>

                                <Avatar />

                            </el-icon>

                            <span>角色管理</span>

                        </template>

                    </el-menu-item>

                </el-sub-menu>

            </el-menu>

        </div>

    </div>

</template>

<script setup lang="ts">

</script>

  

<style lang="less" scoped>

.logo {

    height: 60px;

    display: flex;

    justify-content: center;

    align-items: center;

  

    .logo-img {

        height: 40px;

    }

}

  

.search {

    .search-input {

        width: 80%;

        height: 30px;

        border-radius: 5px;

        font-size: small;

    }

  

    .search-button {

        width: 20%;

        height: 30px;

    }

  
  

    height: 30px;

    display: flex;

}

  

.el-menu {

    border-right: none;

    user-select: none;

}

  

.el-sub-menu {

    .el-menu-item {

        padding-left: 50px !important;

        background-color: #0c2135;

    }

  

    .el-menu-item:hover {

        color: #fff;

    }

  

    .el-menu-item.is-active {

        background-color: #0a60bd;

    }

}

</style>
```

## main 页面-动态菜单一
### 代码：
```
<el-menu text-color="#b7bdc3" active-text-color="#fff" background-color="#001529" default-active="1">

  

                <!-- 动态菜单 -->

                <!--遍历整个菜单数组-->

                <template v-for="item in menuList" :key="item.id">

                    <el-sub-menu :index="item.id + ''">

                        <template #title>

                            <span>

                                {{ item.name }}

                            </span>

                        </template>

                        <template v-for="subitem in item.children" :key="subitem.id">

                            <el-menu-item>

                                {{ subitem.name }}

                            </el-menu-item>

                        </template>

                    </el-sub-menu>

  

                </template>
               
```

### 后端返回给前端的数据
```
//模拟后端返回的菜单数组

const menuList = [

    {

        'id': 1,

        'name': '系统管理',

        'type': 1,

        'url': '/main/system',

        'icon': 'el-icon-monitor',

        'sort': 1,

        'children': [

            {

                'id': 2,

                'url': 'main/analysis/screen',

                'name': '大屏数据展示',

                'icon': 'el-icon-Platform',

                'sort': 1,

                'type': 2,

                'children': null,

                'parentId': 1

            },

            {

                'id': 3,

                'url': 'main/analysis/dashboard',

                'name': '系统监控面板',

                'icon': 'el-icon-Histogram',

                'sort': 2,

                'type': 2,

                'children': null,

                'parentId': 1

            },

            {

                'id': 4,

                'url': 'main/analysis/autoTask',

                'name': '自动任务管理',

                'icon': 'el-icon-Open',

                'sort': 2,

                'type': 2,

                'children': null,

                'parentId': 1

            }

  

        ]

    },

    {

        'id': 5,

        'name': '库位管理',

        'type': 1,

        'url': '/main/mapLocation',

        'icon': 'el-icon-MapLocation',

        'sort': 1,

        'children': [

            {

                'id': 6,

                'url': 'main/mapLocation/location',

                'name': '平面库位展示',

                'icon': 'el-icon-Location',

                'sort': 1,

                'type': 2,

                'children': null,

                'parentId': 5

            },

            {

                'id': 7,

                'url': 'main/mapLocation/addLocation',

                'name': '3D库位展示',

                'icon': 'el-icon-AddLocation',

                'sort': 2,

                'type': 2,

                'children': null,

                'parentId': 5

            }

        ]

    },

    {

        'id': 8,

        'name': '任务管理',

        'type': 1,

        'url': '/main/task',

        'icon': 'el-icon-Odometer',

        'sort': 1,

        'children': [

            {

                'id': 9,

                'url': 'main/task/lift',

                'name': '提升机任务管理',

                'icon': 'el-icon-Clock',

                'sort': 1,

                'type': 2,

                'children': null,

                'parentId': 8

            },

            {

                'id': 10,

                'url': 'main/task/rgv',

                'name': '四向车任务管理',

                'icon': 'el-icon-PieChart',

                'sort': 2,

                'type': 2,

                'children': null,

                'parentId': 8

            }

        ]

    },

    {

        'id': 11,

        'name': '系统运维管理',

        'type': 1,

        'url': '/main/om',

        'icon': 'el-icon-Setting',

        'sort': 1,

        'children': [

            {

                'id': 12,

                'url': 'main/om/modbus',

                'name': 'Modbus数据点运维',

                'icon': 'el-icon-Link',

                'sort': 1,

                'type': 2,

                'children': null,

                'parentId': 11

            },

            {

                'id': 13,

                'url': 'main/om/S7',

                'name': 'S7数据点运维',

                'icon': 'el-icon-Cpu',

                'sort': 2,

                'type': 2,

                'children': null,

                'parentId': 11

            }

        ]

    },

    {

        'id': 14,

        'name': '系统日志管理',

        'type': 1,

        'url': '/main/log',

        'icon': 'el-icon-TrendCharts',

        'sort': 1,

        'children': [

            {

                'id': 15,

                'url': 'main/log/actionLog',

                'name': '操作日志',

                'icon': 'el-icon-Document',

                'sort': 1,

                'type': 2,

                'children': null,

                'parentId': 14

            },

            {

                'id': 16,

                'url': 'main/log/autoTaskLog',

                'name': '自动任务日志',

                'icon': 'el-icon-ChromeFilled',

                'sort': 2,

                'type': 2,

                'children': null,

                'parentId': 14

            },

            {

                'id': 17,

                'url': 'main/log/dbPointLog',

                'name': '数据点读写日志',

                'icon': 'el-icon-Aim',

                'sort': 2,

                'type': 2,

                'children': null,

                'parentId': 14

            }

        ]

    },

    {

        'id': 18,

        'name': '权限管理',

        'type': 1,

        'url': '/main/Permissions',

        'icon': 'el-icon-Setting',

        'sort': 1,

        'children': [

            {

                'id': 19,

                'url': 'main/Permissions/user',

                'name': '用户',

                'icon': 'el-icon-UserFilled',

                'sort': 1,

                'type': 2,

                'children': null,

                'parentId': 18

            },

            {

                'id': 20,

                'url': 'main/Permissions/role',

                'name': '角色',

                'icon': 'el-icon-Avatar',

                'sort': 2,

                'type': 2,

                'children': null,

                'parentId': 18

            }

        ]

    }

]
```
### 最终效果：
![[Pasted image 20250302151003.png]]
### 问题 
>1、图标没有展示
>2、设置默认显示的菜单没成功

## main页面-menu菜单图标的动态组件
>后端返回的是字符串

### 将字符串转换为组件
```
    <!--图标-->

                            <el-icon>

                                <component :is="item.icon.split('el-icon')[1]" />

                            </el-icon>
                            
```
![[Pasted image 20250302151720.png]]

## main页面-header头部的整体布局(静态布局的搭建)
### 最终效果：
![[Pasted image 20250302154221.png]]
### 代码：
```
<template>

    <div class="main-header">

        <div class="menu-icon">

            <el-icon size="28px">

                <Fold />

            </el-icon>

        </div>

        <div class="content">

            <div class="breadcrumb">

                面包屑

            </div>

            <div class="info">个人信息</div>

        </div>

    </div>

</template>

<script setup lang="ts">

</script>

  

<style lang="less" scoped>

.main-header {

    display: flex;

    align-items: center;

    flex: 1;

    height: 100%;

}

  

.menu-icon {

    display: flex;

    align-items: center;

    cursor: pointer;

}

  

.content {

    display: flex;

    justify-content: space-between;

    align-items: center;

    flex: 1;

    padding: 0 18px;

}

</style>
```
