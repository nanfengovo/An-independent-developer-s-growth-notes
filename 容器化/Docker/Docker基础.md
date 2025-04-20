以下是使用 Docker Desktop 的入门指南，按步骤操作即可快速上手：

### 一、安装验证
1. **启动 Docker Desktop**
   - Windows：双击桌面图标，任务栏出现鲸鱼图标即启动成功
   - macOS：在应用程序中打开，菜单栏出现鲸鱼图标表示运行中
   - 出现 "Docker Desktop is running" 提示即为正常

2. **验证安装**
   打开终端/PowerShell 输入：
   ```bash
   docker --version
   docker run hello-world
   ```
   看到版本号且hello-world运行成功说明安装正确

---

### 二、基础操作
#### 1. 镜像管理
```bash
# 搜索镜像
docker search nginx

# 下载镜像（以nginx为例）
docker pull nginx

# 查看本地镜像
docker images
```

#### 2. 容器操作
```bash
# 启动容器（基础格式）
docker run [选项] 镜像名

# 示例：启动Nginx并映射端口
docker run -d -p 8080:80 --name my_nginx nginx

# 查看运行中的容器
docker ps

# 查看所有容器（包括已停止的）
docker ps -a

# 停止容器
docker stop my_nginx

# 删除容器
docker rm my_nginx

# 进入容器内部
docker exec -it my_nginx bash
```

---

### 三、实用示例：搭建Web服务
1. 启动一个 WordPress 网站：
```bash
docker run -d --name wordpress -p 8000:80 -e WORDPRESS_DB_HOST=db \
-e WORDPRESS_DB_USER=root -e WORDPRESS_DB_PASSWORD=123456 wordpress
```

2. 访问 `http://localhost:8000` 即可看到安装界面

---

### 四、常见问题解决
1. **权限问题**
   - Linux/macOS 需在命令前加 `sudo`
   - 或把用户加入docker组：`sudo usermod -aG docker $USER`

2. **镜像下载慢**
   修改 Docker 镜像源：
   3. 右键 Docker 图标 → Settings
   4. Docker Engine 中添加：
      ```json
      "registry-mirrors": [
        "https://registry.docker-cn.com",
        "https://mirror.baidubce.com"
      ]
      ```

3. 5. 口冲突**
   修改 `-p 主机端口:容器端口` 中的主机端口号

---

### 五、进阶操作
#### 1. 构建自定义镜像
1. 创建 Dockerfile：
```dockerfile
FROM python:3.8-slim
WORKDIR /app
COPY . .
RUN pip install -r requirements.txt
CMD ["python", "app.py"]
```

2. 构建镜像：
```bash
docker build -t my_python_app .
```

#### 2. 数据持久化
使用 volumes 保存数据：
```bash
docker run -d -v /path/on/host:/var/lib/mysql mysql
```

#### 3. 多容器管理
使用 docker-compose.yml：
```yaml
version: '3'
services:
  web:
    image: nginx
    ports:
      - "80:80"
  db:
    image: mysql
    environment:
      MYSQL_ROOT_PASSWORD: 123456
```

启动：`docker-compose up -d`

---

### 六、学习建议
1. 官方文档：https://docs.docker.com/
2. 交互式教程：`docker run -d -p 4000:4000 docker/getting-started`
3. 常用命令备忘录：
   ```
   docker logs [容器名]     查看日志
   docker stats           查看资源占用
   docker system prune    清理无用资源
   ```

按照这些步骤操作，您可以在1小时内掌握Docker的基本使用方法。遇到具体问题时可结合错误信息搜索解决方案。