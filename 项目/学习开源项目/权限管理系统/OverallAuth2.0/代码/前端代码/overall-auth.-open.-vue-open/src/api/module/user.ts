import Http from '../http';

export const login = function(loginForm: any) {
    return Http.post('/api/SysUser/Login', loginForm)
}

export const menu = function() {
   return Http.get('/api/SysMenu/GetMenuByUserId');
}

export const permission = function() {
    return Http.get('/user/permission') 
}