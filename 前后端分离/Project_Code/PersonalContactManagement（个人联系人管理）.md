# 功能需求
```
一、功能要求
　　基于.net8的WebAPI项目，设计一个《个人联系人管理》软件，使用SQLite数据库，基本功能如下：
1. 添加联系人；
2. 联系人列表；
3. 查找联系人；
4. 编辑联系人；
5. 删除联系人。

二、加分项
　　有余力的同学，可以加上一些更实用的功能：
6. 导入联系人，比如可以导出联系人文件，上传到平台，导入到平台数据库；
7. 导出联系人，比如导出后，再导入；
8. 联系人合并，可以根据姓名或电话号码合并。
9. 可以为联系人加上关键字管理功能，可以根据关键字查找联系人；
```

# 需求分析&原型设计&数据库设计
### 接口说明
####  1. 添加联系人
* Post 请求
* URL: /api/Contact/AddContactPerson
#### 2、联系人列表
* Get 请求
* URL:/api/Contact/GetContactPersonList
#### 3. 查找联系人
* Get 请求
* URL：/api/Contact/GetContactPerson
####  4. 编辑联系人
* Put 请求
* URL：/api/Contact/EditContactPerson
#### 5. 删除联系人
*  Delete 请求
*  URL: /api/Contact/DeleteContactPerson
#### 6.导入
* Post 请求
* URL : /api/Contact/Import
#### 7.导出
*  Get 请求
*  URL: /api/Contact/Export
#### 8. 联系人合并，可以根据姓名或电话号码合并
暂时没思路
#### 9. 可以为联系人加上关键字管理功能，可以根据关键字查找联系人
* Get 请求
* URL: /api/Contact/GetContactPersonByKeyWord

### 系统后端架构图
![[attachments/Pasted image 20250605224820.png]]

