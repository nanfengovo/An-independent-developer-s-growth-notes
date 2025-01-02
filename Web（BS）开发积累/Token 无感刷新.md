---
created: 2025-01-01T22:42:03 (UTC +08:00)
tags: []
source: https://mp.weixin.qq.com/s?__biz=MzI3NTQxMDc4MA==&mid=2247484563&idx=1&sn=05c69e700eba1d0cb9a71f659e997efb&chksm=eb047ea0dc73f7b6a0ab80916d54f22b299db20643888d380d40ce08a2260dc07b128ae11041&cur_album_id=3679129800661876743&scene=190#rd
author: 小墨
---

# 程序员必备：Web 应用 Token 无感刷新实战指南，告别用户掉线烦恼！

> ## Excerpt
> 「小墨是前端」致力于分享实用前端技术、挖掘优秀的开源项目，带你探索前端的奇妙世界，共同学习进步

---
> 「小墨是前端」致力于分享实用前端技术、挖掘优秀的开源项目，带你探索前端的奇妙世界，共同学习进步

作为程序员，我们都希望自己的应用能够提供流畅的用户体验。试想一下，用户正在进行关键操作，却因为 Token 过期而被迫中断，这无疑会让人抓狂。为了避免这种情况，我们需要实现 Token 无感刷新机制，让用户在不知不觉中完成身份验证。本期将深入剖析 Token 无感刷新的原理，并提供一个基于 Axios 的实战方案，帮助你打造丝般顺滑的用户体验。

### 为什么需要 Token 无感刷新？

传统的 Session-Cookie 认证方式在分布式环境下存在诸多限制，所以 JWT（JSON Web Token）凭借其轻量、自包含等特性成为现代 Web 应用的首选。但是JWT 也并非完美无缺，其有效期限制意味着 Token 过期后用户需要重新登录。这对于用户体验来说是一个巨大的痛点。为了解决这个问题，我们就需要引入 Token 无感刷新机制，让用户在 Token 过期前自动获取新的 Token，从而避免中断用户的操作流程。

### 双 Token 机制：平滑过渡的秘诀

实现 Token 无感刷新的关键在于双 Token 机制：Access Token 和 Refresh Token。Access Token 用于访问受保护的资源，有效期较短，例如 30 分钟。Refresh Token 用于获取新的 Access Token，有效期较长，例如 7 天。当 Access Token 过期时，客户端会使用 Refresh Token 向服务器请求新的 Access Token 和 Refresh Token，从而实现无感刷新。

### Axios 拦截器：优雅实现 Token 刷新逻辑

在前端开发中，我们可以利用 Axios 拦截器来实现 Token 的自动刷新。下面是一个经过实战检验的示例代码，它能够有效地处理并发请求，并避免重复刷新 Token。

```
import axios from 'axios';  
  
const axiosInstance = axios.create();  
let isRefreshing = false;  
const refreshSubscribers = [];  
  
const onRefreshed = (newAccessToken) => {  
  refreshSubscribers.map((callback) => callback(newAccessToken));  
};  
  
const subscribeTokenRefresh = (callback) => {  
  refreshSubscribers.push(callback);  
};  
  
axiosInstance.interceptors.response.use(  
  (response) => response,  
  async (error) => {  
    const { config, response } = error;  
    const originalRequest = config;  
  
    if (response && response.status === 401 && !originalRequest._retry) {  
      if (isRefreshing) {  
        return new Promise(resolve => {  
          subscribeTokenRefresh(token => {  
            originalRequest.headers['Authorization'] = 'Bearer ' + token;  
            resolve(axios(originalRequest));  
          });  
        })  
        .catch(error => {  
          console.error("Retry failed:", error); //处理重试失败的情况  
        });  
      }  
  
      originalRequest._retry = true;  
      isRefreshing = true;  
  
      try {  
        const refreshResponse = await axiosInstance.post('/refresh', {  
          refreshToken: localStorage.getItem('refreshToken')  
        });  
  
        const newAccessToken = refreshResponse.data.accessToken;  
        localStorage.setItem('accessToken', newAccessToken);  
        localStorage.setItem('refreshToken', refreshResponse.data.refreshToken);  
        onRefreshed(newAccessToken);  
        originalRequest.headers['Authorization'] = 'Bearer ' + newAccessToken;  
        return axios(originalRequest);  
      } catch (refreshError) {  
          console.error('Refresh Token 获取失败', refreshError);  
          // 清除token，跳转到登录页  
          localStorage.removeItem('accessToken');  
          localStorage.removeItem('refreshToken');  
          window.location.href = '/login'; // 跳转到登录页面  
          return Promise.reject(refreshError); // 返回错误，阻止后续操作  
      } finally {  
        isRefreshing = false;  
        refreshSubscribers.length = 0; // 重置订阅者  
      }  
    }  
  
    return Promise.reject(error);  
  }  
);  
  
  
axiosInstance.interceptors.request.use((config) => {  
  config.headers['Authorization'] = `Bearer ${localStorage.getItem('accessToken')}`;  
  return config;  
});  
  
export default axiosInstance;
```

这段代码的核心逻辑在于：使用 `_retry` 标记防止重复刷新 Token，并利用 `refreshSubscribers` 数组管理等待刷新完成的请求。当 Refresh Token 获取成功后，会通知所有等待的请求重新发送。这种方式能够有效地处理并发请求，并保证 Token 刷新逻辑的健壮性。

> 喜欢本文的话，不妨点个“在看”、分享给你的朋友，也欢迎大家关注我的公众号，我会持续分享更多前端干货和实用工具，一起探索前端的无限可能！

#### 推荐阅读

-   • [JavaScript 变量提升：不再是谜](https://mp.weixin.qq.com/s?__biz=MzI3NTQxMDc4MA==&mid=2247484534&idx=1&sn=c881589217f94d66f104be302229f116&scene=21#wechat_redirect "JavaScript 变量提升：不再是谜")
    
-   • [Flexbox 布局神器：\`flex: 1\`，轻松搞定等分难题！](https://mp.weixin.qq.com/s?__biz=MzI3NTQxMDc4MA==&mid=2247484542&idx=1&sn=59791359164ba65d73c8c2be9600e0b5&scene=21#wechat_redirect "Flexbox 布局神器：")
    
-   • [ChatGPT 也在用的Ajax取消请求技巧，你还不学？](https://mp.weixin.qq.com/s?__biz=MzI3NTQxMDc4MA==&mid=2247484514&idx=1&sn=a2ce64933ccbb162cfc5d0d4fcb96406&scene=21#wechat_redirect "ChatGPT 也在用的Ajax取消请求技巧，你还不学？") -[Vue3 升级指南：.sync 修饰符被移除怎么办？](https://mp.weixin.qq.com/s?__biz=MzI3NTQxMDc4MA==&mid=2247484498&idx=1&sn=938bc4b082a7c9d0e43f9a0ef7dd3991&scene=21#wechat_redirect "Vue3 升级指南：.sync 修饰符被移除怎么办？")
    
-   • [JS的隐式类型转换：避坑指南，提升代码健壮性！](https://mp.weixin.qq.com/s?__biz=MzI3NTQxMDc4MA==&mid=2247484473&idx=1&sn=5db4e2c54806180102bec2f9dbf76a32&scene=21#wechat_redirect "JS的隐式类型转换：避坑指南，提升代码健壮性！")
    
-   • [CSS 绝对定位 (absolute) 面试题解析：从入门到精通！](https://mp.weixin.qq.com/s?__biz=MzI3NTQxMDc4MA==&mid=2247484450&idx=1&sn=41ca98945f8b808a025bfd406fc432ff&scene=21#wechat_redirect "CSS 绝对定位 (absolute) 面试题解析：从入门到精通！")
    
-   • [跨域资源共享 (CORS) 深入浅出：前端必备技能，轻松解决跨域问题](https://mp.weixin.qq.com/s?__biz=MzI3NTQxMDc4MA==&mid=2247484440&idx=1&sn=f8bcbb60f5838280065f32b850e4a69a&scene=21#wechat_redirect "跨域资源共享 (CORS) 深入浅出：前端必备技能，轻松解决跨域问题")
    

___
