import Http from '../http';

//获取用户
export const getUserListMsg = function (pageModel: any) {
    return Http.post('/api/SysUser/GetUserList', pageModel);
}

//添加用户
export const addMenuMsg = function(user: any) {
    return  Http.post('/api/SysUser/AddUserMsg',user);
 }

 //编辑用户
export const updateUserMsg = function(user: any) {
    return  Http.post('/api/SysUser/UpdateUserMsg',user);
 }

  //设置用户权限
export const setUserRole = function(userOrRoleInput: any) {
    return  Http.post('/api/SysUser/SetUserRole',userOrRoleInput);
 }