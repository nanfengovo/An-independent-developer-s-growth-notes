Ubuntu系统是自带git的
通过git --version来查看git的版本
git config --get user.name    ：查看用户名
git config --get user.email     ：查看邮箱
git config --global user.name "Your Name"    ：设置全局用户名
git config --global user.email "your.email@example.com"   ：设置全局邮箱
# 生成ssh公钥
ssh-keygen -t rsa -b 4096 -C "your_email@example.com"  ：生成ssh公钥
以下是生成SSH密钥对的详细步骤（适用于所有主流操作系统）：

---

### **1. 生成SSH密钥对**
#### **通用方法（推荐Ed25519算法）**
```bash
ssh-keygen -t ed25519 -C "your_email@example.com"
```
- **说明**：
  - `-t ed25519`：使用更安全的Ed25519椭圆曲线算法（比传统RSA更高效且安全）。
  - `-C "your_email@example.com"`：添加注释（通常用邮箱标识密钥用途，非必需）。

#### **传统RSA算法（兼容旧系统）**
```bash
ssh-keygen -t rsa -b 4096 -C "your_email@example.com"
```
- **说明**：
  - `-b 4096`：指定密钥长度为4096位（增强安全性）。

---

### **2. 设置密钥保存路径**
执行命令后，会提示选择密钥保存路径：
```bash
Enter file in which to save the key (/home/username/.ssh/id_ed25519):
```
- **直接按回车**：使用默认路径（`~/.ssh/id_ed25519` 或 `~/.ssh/id_rsa`）。
- **自定义路径**：输入完整路径（非必要不建议修改）。

---

### **3. 设置密钥密码（可选）**
```bash
Enter passphrase (empty for no passphrase):
```
- **建议设置密码**：输入一个密码（每次使用密钥时需验证，提升安全性）。
- **跳过密码**：直接按回车（适合自动化场景，但安全性降低）。

---

### **4. 生成结果**
密钥对默认保存在 `~/.ssh/` 目录下：
- **私钥**：`id_ed25519` 或 `id_rsa`（需严格保密，切勿泄露）。
- **公钥**：`.pub` 后缀文件（如 `id_ed25519.pub`，需上传到目标服务）。

---

### **5. 查看公钥内容**
```bash
cat ~/.ssh/id_ed25519.pub
```
输出示例：
```
ssh-ed25519 AAAAC3NzaC1lZDI1NTE5AAAAIJx... your_email@example.com
```

---

### **6. 将公钥添加到目标服务**
#### **GitHub/GitLab**
1. 复制公钥内容（从 `id_ed25519.pub` 文件）。
2. 登录GitHub/GitLab，进入 **Settings → SSH Keys**。
3. 点击 **New SSH Key**，粘贴公钥并保存。

#### **远程服务器**
1. 将公钥内容追加到服务器的 `~/.ssh/authorized_keys` 文件：
   ```bash
   ssh-copy-id -i ~/.ssh/id_ed25519.pub user@server_ip
   ```

---

### **7. 测试SSH连接**
```bash
ssh -T git@github.com  # 测试GitHub
ssh user@server_ip     # 测试远程服务器
```
- **成功提示**（如GitHub）：
  ```
  Hi username! You've successfully authenticated...
  ```

---

### **8. 权限设置（重要！）**
确保私钥文件权限安全：
```bash
chmod 600 ~/.ssh/id_ed25519     # 私钥权限设为仅用户可读写
chmod 644 ~/.ssh/id_ed25519.pub # 公钥权限可放宽
```

---

### **常见问题**
#### **1. 密钥已存在怎么办？**
- 选择覆盖：输入 `y` 后回车（注意备份旧密钥）。
- 保留旧密钥：输入自定义路径（如 `~/.ssh/new_key`）。

#### **2. 如何管理多个密钥？**
编辑 `~/.ssh/config` 文件，指定不同主机使用不同密钥：
```bash
Host github.com
  HostName github.com
  User git
  IdentityFile ~/.ssh/github_key

Host my-server
  HostName 192.168.1.100
  User root
  IdentityFile ~/.ssh/server_key
```

#### **3. 忘记密钥密码怎么办？**
无法恢复，需重新生成密钥对并更新到所有服务。

---

### **总结**
- **生成命令**：`ssh-keygen -t ed25519 -C "注释"`。
- **核心文件**：私钥保密，公钥上传。
- **安全建议**：设置密码 + 严格权限控制。

通过以上步骤，即可快速生成并配置SSH密钥，安全访问Git服务或远程服务器。
## 查看ssh公钥
cat ~/.ssh/id_ed25519.pub   # Ed25519算法公钥
或
cat ~/.ssh/id_rsa.pub       # RSA算法公钥

# 拉取代码到本地
>git clone +git@github.com:nanfengovo/An-independent-developer-s-growth-notes.git
>![[attachments/Pasted image 20250511213507.png]]

