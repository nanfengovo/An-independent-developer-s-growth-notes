import { StringOrNumber } from '@layui/layui-vue/types/component/tree/tree.type';
import Http from '../../http';

//获取菜单数据列
export const getMenuTableColsList = function(pageModel: any) {
    return  Http.post('/api/SysMenuTableCols/GetMenuTableColsList',pageModel);
 }

 //添加菜单数据列
export const addMenuTableColsMsg = function (model: any) {
    return Http.post('/api/SysMenuTableCols/Insert', model);
}

 //修改菜单数据列
 export const updateMenuTableColsMsg = function (model: any) {
    return Http.post('/api/SysMenuTableCols/Update', model);
}


//根据菜单id获取登陆人员对应菜单列权限
export const getMenuHaveTableCols = function (params?: { menuId: StringOrNumber; roleId: number }) {
    return Http.get('/api/SysMenuTableCols/GetMenuHaveTableCols', params);
}

//添加菜单列权限
export const insertMenuColsRoleMsg = function (pageModel: any) {
    return Http.post('/api/SysMenuTableColsRole/Insert', pageModel);
}