# 后端 C# :
## 1、下载.NET 8 SDK(安装在本地)
>https://dotnet.microsoft.com/zh-cn/download

### 补充一下SDK和运行时的区别
>SDK是所有需要/使开发.NET Core应用程序更容易的东西,例如CLI和编译器.  
运行时是托管/运行应用程序的"虚拟机",它抽象了与基本操作系统的所有交互.  
运行应用程序只需要后者,但开发应用程序需要前者.
## 2、配置VSCode开发环境（安装插件）
### 必需的插件：
#### C#  :侧重于基础的功能
![[attachments/Pasted image 20250420220301.png]]
#### C# Dev Kit：进阶增强
![[attachments/Pasted image 20250420220427.png]]
####  Intellicode for C# Dev Kit :增强上面那个的AI能力
![[attachments/Pasted image 20250420220704.png]]
#### nuget 相关的插件
##### NuGet Package Manager GUI 
##### NuGet Gallery(需要科学上网)
![[attachments/Pasted image 20250426130611.png]]
### 非必需的插件
#### indent-rainbow ：编码缩进加彩虹
![[attachments/Pasted image 20250420221047.png]]
#### vscode-icons ：文件夹图标
![[attachments/Pasted image 20250420221409.png]]
#### GitLens ：协同开发
![[attachments/Pasted image 20250420221538.png]]
##  新建、开发并运行调试第一个Project
>dotnet new console -o  +项目名             

==使用 `-o` 是为了保持项目文件的组织性，确保每个项目独立存放在自己的文件夹中，避免文件混杂。这是 .NET CLI 中管理项目结构的推荐做法。==
这个命令创建的项目默认使用了顶级语句
###  创建非顶级语句格式的项目
>dotnet new console -o 项目名 --use-program-main

# 前端-vue3
## 安装nodejs
>在docker中运行nodejs镜像

### **拉取 Node.js 镜像**
>docker pull node:18

### **创建 Vue 项目目录**
>mkdir vue-docker-app && cd vue-docker-app

### 运行镜像
>docker run -itd --name vue-dev \
  -p 8080:8080 \
  -v $(pwd):/app \
  -w /app \
  node:18-alpine

### 进入容器内部
># 进入已运行的容器
docker exec -it vue-dev sh

### 创建Vue3项目
>npm create vite@latest my-vite-project --template vanilla
cd my-vite-project
npm install

### 运行vue 项目
#### 1、在package.json中设置端口号和容器端口号一致
![[attachments/Pasted image 20250422204434.png]]
![[attachments/Pasted image 20250422204402.png]]
#### 发现还是不行，在vite.config.ts中配置监听0.0.0.0
![[attachments/Pasted image 20250422204540.png]]
>为什么要这样做？
>![[attachments/Pasted image 20250422204632.png]]

## 安装vue相关的插件
### 必需的插件
#### Vue - Official
>Language Support for Vue