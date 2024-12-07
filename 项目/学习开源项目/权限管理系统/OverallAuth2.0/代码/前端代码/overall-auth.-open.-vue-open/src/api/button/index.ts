import { StringOrNumber } from '@layui/layui-vue/types/component/tree/tree.type';
import Http from '../http';

//添加按钮样式
export const addButtonStyleMsg = function (pageModel: any) {
    return Http.post('/api/SysButtonStyle/AddButtonStyleMsg', pageModel);
}

//修改按钮样式
export const updateButtonStyleMsg = function (pageModel: any) {
    return Http.post('/api/SysButtonStyle/UpdateButtonStyleMsg', pageModel);
}

//删除按钮样式
export const deleteButtonStyleMsg = function (params?: { buttonStyleId: number; }) {
    return Http.delete('/api/SysButtonStyle/DeleteButtonStyleMsg', params);
}

//获取所有按钮样式
export const getAllButtonStyle = function (params?: { menuId?: string;buttonStyleName?:string }) {
    return Http.get('/api/SysButtonStyle/GetAllButtonStyle',params);
}

//获取按钮信息
export const getButtonList = function (pageModel: any) {
    return Http.post('/api/SysButton/GetButtonList', pageModel);
}

//获取所有下拉树菜单
export const getMenuSelectTree = function () {
    return Http.get('/api/SysButton/GetMenuSelectTree');
}

//添加按钮
export const addButtonMsg = function (pageModel: any) {
    return Http.post('/api/SysButton/Insert', pageModel);
}

//编辑按钮
export const updateButtonMsg = function (pageModel: any) {
    return Http.post('/api/SysButton/Update', pageModel);
}

//根据菜单id获取登陆人员对应菜单按钮
export const getButtonByMenuId = function (params?: { menuId: number; }) {
    return Http.get('/api/SysButton/GetButtonByMenuId', params);
}

//添加菜单按钮权限
export const insertButtonRoleMsg = function (pageModel: any) {
    return Http.post('/api/SysButton/InsertButtonRole', pageModel);
}

//根据菜单id获取登陆人员对应菜单按钮权限
export const getMenuHaveButton = function (params?: { menuId: StringOrNumber; roleId: number }) {
    return Http.get('/api/SysButton/GetMenuHaveButton', params);
}



