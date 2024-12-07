import Http from '../http';

//获取菜单
export const getMenusList = function(pageModel: any) {
   return  Http.post('/api/SysMenu/GetMenusList',pageModel);
}

//获取父级菜单
export const getParentMenusList = function() {
   return  Http.get('/api/SysMenu/GetParentMenusList');
}

//获取所有菜单--上下级关系
export const getAllChildren = function() {
   return  Http.get('/api/SysMenu/GetAllChildren');
}

//添加菜单
export const addMenuMsg = function(menu: any) {
   return  Http.post('/api/SysMenu/AddMenuMsg',menu);
}

//编辑菜单
export const updateMenuMsg = function(menu: any) {
   return  Http.post('/api/SysMenu/UpdateMenuMsg',menu);
}

 //根据菜单id获取登陆人员菜单数据列
 export const GetTableColsRoleByMenuId = function (params?: { menuId: number; }) {
   return Http.get('/api/SysMenuTableColsRole/GetTableColsRoleByMenuId', params);
}