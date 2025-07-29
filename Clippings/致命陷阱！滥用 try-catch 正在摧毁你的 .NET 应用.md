---
title: "致命陷阱！滥用 try-catch 正在摧毁你的 .NET 应用"
source: "https://mp.weixin.qq.com/s/iWzwFEvEguRe3D9KL5WWhQ"
author:
  - "[[寒冰]]"
published:
created: 2025-07-29
description: "核心警示：你添加 try-catch 本想保护应用，结果却：隐藏错误、触发重试风暴、让故障追踪难如登天。"
tags:
  - "clippings"
---
寒冰 *2025年07月24日 05:04*

### 核心警示：

你添加 try-catch 本想保护应用，  
结果却： **隐藏错误** 、 **触发重试风暴** 、 **让故障追踪难如登天** 。

> 在.NET 中，try-catch 并非总是盟友——有时它正是系统无声崩溃的元凶。
> 
>   
> **正确处理异常的关键：让应用高声报错、优雅恢复、永不让你猜谜！**

---

### 🚨 典型灾难代码

```
try
{
    var user = await _userService.GetUserAsync(id);
    _logger.LogInformation("Fetched user");
}
catch (Exception ex)  // 全类型捕获
{
    _logger.LogError(ex, "Something went wrong"); 
}
```

✅ **看似安全**  
❌ **静默掩盖根因**  
⚠️ **违反关注点分离**  
💥 **引发重试循环、丢失指标、调试地狱**

---

### ❌ 五大 try-catch 反模式（附解决方案）

#### ✅ 修复方案 1：使用 when 过滤器

```
try
{
    // 业务逻辑
}
catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
{
    _logger.LogWarning("用户不存在");  // 精准捕获
}
```

**优势** ：  
🔹 避免无关异常误入  
🔹 保持处理逻辑精准可控

> 📝 **重要提示** ：仅捕获可处理的异常。未知库故障等极少数场景下，可用宽泛捕获记录日志后重新抛出（ `throw;`）

#### ✅ 修复方案 2：预防代替捕获

```
if (!File.Exists(path))  // 防御性检查
{
    _logger.LogWarning("文件缺失: {path}", path);
    return;
}
// 而非盲目捕获 FileNotFoundException
```

**原则** ：  
🔹 防御性编程 > 异常控制流  
🔹 根据场景合理选用， **非万能方案**

#### ✅ 修复方案 3：创建领域专属异常

```
public classPaymentDeclinedException : Exception// 自定义异常
{
    public PaymentDeclinedException(string reason) : base(reason) { }
}

// 精准捕获可处理的异常
try
{
    await _paymentService.ProcessAsync();
}
catch (PaymentDeclinedException ex)  // 仅捕获支付拒绝
{
    _logger.LogWarning("支付拒绝: {reason}", ex.Message);
    return BadRequest(ex.Message);
}
```

**价值** ：  
🔹 提升代码可读性  
🔹 增强可测试性  
🔹 明确恢复路径

#### ✅ 修复方案 4：中间件统一处理

```
// 注册异常处理中间件
app.UseExceptionHandler("/error"); 

// 集中处理错误响应
app.Map("/error", (HttpContext context) =>
{
    var feature = context.Features.Get<IExceptionHandlerFeature>();
    return Results.Problem(detail: feature?.Error.Message);
});
```

**优势** ：  
🔹 全局统一错误响应  
🔹 业务代码零污染

#### ✅ 修复方案 5：后台任务禁止吞没异常

```
try
{
    await _processor.RunAsync();
}
catch (Exception ex)
{
    _logger.LogCritical(ex, "任务失败");
    throw;  // 重新抛出！让编排器（如Azure Functions）可见故障
}
```

**关键原则** ：  
🔹 后台任务静默失败 = 定时炸弹  
🔹 必须抛出以便触发重试/告警

#### ✅ 修复方案 6：分层弹性策略（Polly）

```
services.AddHttpClient("Users")
        .AddTransientHttpErrorPolicy(p =>
            p.WaitAndRetryAsync(3, retry => TimeSpan.FromSeconds(Math.Pow(2, retry))));  // 指数退避重试
```

**核心价值** ：  
🔹 HTTP层处理瞬时故障  
🔹 业务代码无侵入

---

### 🛠 专家级技巧：生产就绪清单

| ✅ 必做项 | ❌ 禁止项 |
| --- | --- |
| 用 `when` 替代宽泛捕获 | 吞没不可恢复的异常 |
| 自定义领域异常 | 在 catch 块内盲目重试 |
| 中间件集中处理 | 使用 `async void` 方法 |
| 后台任务必须重新抛出 | 未处理的任务异常 |
| 用 Polly 实现弹性策略 | 依赖异常控制流程 |

---

### 💬 终极忠告

> **try-catch 不是安全网，而是精密手术刀**  
> 我亲历的.NET 生产事故中， **从未因未捕获异常引发宕机** ，  
> 真正的灾难总是：  
> 🔥 异常被捕获 → 记录日志 → 静默忽略 → **用户发现故障时已无力回天**  
> 没有告警，没有重试，只有沉默的崩溃。

**让错误暴露在阳光下，才是真正的韧性。**

**如果你喜欢我的文章，请给我一个赞！谢谢**

  

继续滑动看下一个

架构师老卢

向上滑动看下一个