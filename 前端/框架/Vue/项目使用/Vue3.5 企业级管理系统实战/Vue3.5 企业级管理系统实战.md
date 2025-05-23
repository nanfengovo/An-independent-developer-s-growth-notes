# Vue3.5 企业级管理系统实战（一）：项目初始搭建与配置
>https://mp.weixin.qq.com/s?__biz=MzAxMTQ1MzkxOQ==&mid=2247485126&idx=1&sn=184aaf961e3d883da9486cb215cb2f31&chksm=9b419276ac361b60fcd000c6c672a318e2c07cf960172298858b3e90120184279c4ff9da7114&cur_album_id=3804243018585227278&scene=190#rd

## 环境搭建
###  1.1、安装Pnpm
>npm install pnpm -g

### 1.2、创建项目并启动
>pnpm create vite

```
#安装依赖
pnpm i
# 启动项目
pnpm run dev
```
## 工具集成
>    ESLint 用于代码质量检查，Prettier 专注于代码格式化，EditorConfig 帮助统一编码风格，而Husky 通过 Git 钩子强制执行代码检查，Lint-staged 仅对暂存文件应用 linters，Commitlint 则确保提交信息遵循一定的规范。这些工具共同构成了一个强大的代码质量和提交规范流程。
###  **2.1 eslint 集成**
#### **2.1.1 eslint 安装依赖**
>npx eslint --init

###  **2.2 prettier 集成**
>`prettier` 是一个代码格式化工具，用于统一代码风格。
`eslint-plugin-prettier` 是一个 ESLint 插件，它允许 ESLint 使用 Prettier 的规则来检查代码风格。
`eslint-config-prettier` 是一个 ESLint 配置，用于关闭 ESLint 中与 Prettier 冲突的规则，确保两者能和谐工作，避免规则冲突。

通过 pnpm 安装 prettier 相关插件：

```
pnpm install prettier eslint-plugin-prettier eslint-config-prettier -D
```
安装后，在项目文件夹下新建 prettier 配置文件 prettier.config.js 。
