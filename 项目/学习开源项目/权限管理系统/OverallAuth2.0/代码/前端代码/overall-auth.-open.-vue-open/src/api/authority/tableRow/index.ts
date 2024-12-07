import { StringOrNumber } from '@layui/layui-vue/types/component/tree/tree.type';
import Http from '../../http';

//根据菜单id，获取菜单行权限配置
export const GetTableRowAuthConfigByMenuId = function (params?: { menuId: StringOrNumber }) {
    return Http.get('/api/SysMenuTableRowAuth/GetTableRowAuthConfigByMenuId', params);
}

//根据菜单id，获取菜单行权限
export const GetTableRowAuthByMenuId = function (params?: { menuId: StringOrNumber }) {
    return Http.get('/api/SysMenuTableRowAuth/GetTableRowAuthByMenuId', params);
}

//根据菜单id，获取权限行配置信息数据源
export const GetRowAuthConfigByMenuId = function (params?: { menuId: StringOrNumber }) {
    return Http.get('/api/SysMenuTableRowAuth/GetRowAuthConfigByMenuId', params);
}

//保存规则
export const saveRule = function (model: any) {
    return Http.post('/api/SysMenuTableRowAuth/SaveRule', model);
}

//保存规则配置
export const saveRuleConfig = function (model: any) {
    return Http.post('/api/SysMenuTableRowAuth/SaveRuleConfig', model);
}

//设置规则是否启用
// 同一个菜单，只能启用一个规则
export const SetRuleIsOpenById = function (params?: { id: StringOrNumber, menuId: StringOrNumber, isOpen: boolean }) {
    return Http.get('/api/SysMenuTableRowAuth/SetRuleIsOpenById', params);
}

//删除规则
export const DeleteRule = function (params?: { id: StringOrNumber }) {
    return Http.get('/api/SysMenuTableRowAuth/DeleteRule', params);
}

//删除规则配置
export const DeleteRuleConfig = function (params?: { id: StringOrNumber }) {
    return Http.get('/api/SysMenuTableRowAuth/DeleteRuleConfig', params);
}