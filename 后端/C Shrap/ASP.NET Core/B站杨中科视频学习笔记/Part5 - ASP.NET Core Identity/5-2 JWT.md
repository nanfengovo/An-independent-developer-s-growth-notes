# 5-2-1 代替Session的JWT是什么
>https://www.bilibili.com/video/BV1pK41137He?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=147
## Session的缺点是什么
1、对于分布式集群环境，Session数据保存在服务器内存中就不合适了，应该放在一个中心状态服务器上，ASP.NET Core支持Session采用Redis、Memcached
2、中心状态服务器有性能问题
## JWT （Json Web Token）
1、JWT把登录信息（令牌）保存在客户端
2、为了防止客户端的令牌造假，保存在客户端的令牌经过了签名处理，而签名的密钥只有服务器端才知道，每次服务器端收到客户端提交过来的令牌的时候都要检查一下签名

### JWT的组成：header+payload(name:admin)+签名
>签名：签名算法（header+payload+服务器端才知道的密钥）

# 5-2-2 .NET Core中JWT的基本使用
>https://www.bilibili.com/video/BV1pK41137He?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=148

# 5-2-3 .NET Core对于JWT的封装
>https://www.bilibili.com/video/BV1pK41137He?vd_source=b7200d0eaee914e9c128dcabce5df118&spm_id_from=333.788.videopod.episodes&p=149


