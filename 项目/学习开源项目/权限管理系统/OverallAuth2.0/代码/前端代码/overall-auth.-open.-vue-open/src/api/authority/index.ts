import Http from '../http';

//获取角色
export const getAllRoleMsg = function (pageModel: any) {
    return Http.post('/api/SysRole/GetAllRoleMsg', pageModel);
}

//根据角色获取权限菜单
export const getMenuByRoleId = function (params?: { roleId: number; isDisabledGroup:boolean,isDisabledItem:boolean}) {
    return Http.get('/api/SysRole/GetMenuByRoleId', params);
}

//添加角色
export const addRoleMsg = function (pageModel: any) {
    return Http.post('/api/SysRole/AddRoleMsg', pageModel);
}

//根据角色修改权限菜单
export const updataRoleAuthorityMsg = function (params: any) {
    return Http.post('/api/SysRole/UpdataRoleAuthorityMsg', params);
}

//获取所有角色
export const getAll = function() {
    return  Http.get('/api/SysRole/GetAll');
 }

