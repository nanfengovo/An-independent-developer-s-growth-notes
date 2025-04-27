# Restful风格的API
CRUD =>增删改查
>GET:调用get类型的接口数据库的数据不发生改变（查）
>POST：数据库中增加数据（增）
>PUT：数据库中的数据发生改变（改）
>DELETE: 数据库中的数据发生减少（删）

# 跨域
>//跨域第一步 在program.cs
builder.Services.AddCors(x =&gt; x.AddPolicy("any",p=&gt;p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
>//跨域第二步 在program.cs
app.UseCors();
>//跨域第三步 在控制器
    [EnableCors("any")]
# ApiController作用（特性）：
>1、自动的推断前端传入的数据应该以什么样的方式去接收（绑定源参数推理）
>2、强行检测post、put是不是具备Route特性
>3、自动HTTP400响应
>4、Multipart/form-data 请求推理
>5、错误代码的详细信息
>6、数据验证
>

# 前端有两种传数据的方法：

## 不写在URL里后面单独使用{}
![[attachments/Pasted image 20250427193103.png]]
>这个时候后端有两种方式处理数据

### 第一种在.net3.1之后
>在控制器上面加[ApiController]属性

![[attachments/Pasted image 20250427193650.png]]
### 第二种在.NET3.1之前
>使用[Formbody]属性

![[attachments/Pasted image 20250427194956.png]]
上面两种情况效果是一样的这个时候打开后端的swagger发现使用的是json数据格式，请求的地址如下
![[attachments/Pasted image 20250427195157.png]]
![[attachments/Pasted image 20250427195247.png]]
