# 变量
## string 和 String 的区别：
String 是.NET 平台下的字符串类 ，string 是 C# 中的字符串类
## Camel : 驼峰命名法  -- 变量命名
要求变量名首字母要小写，其余每个单词的首字母要大写，多用于给变量命名；
## Pascal :帕斯卡命名法  -- 多用于给类或者方法命名
要求每个单词的首字母大写，其余字母小写
# 类型转换
## 1.使用Convert 进行类型转换    --成功了就成功了，失败了就抛异常
### 使用：
#### 基础用法：
ex:
```c#
int num = Convert.ToInt32(Console.ReadLine());
```

####  如果输入的内容无法转换为int 会触发 System.FormatException:“The input string '用户输入的内容' was not in a correct format.” 程序会中断，这样就需要捕获异常：
```c#

```
