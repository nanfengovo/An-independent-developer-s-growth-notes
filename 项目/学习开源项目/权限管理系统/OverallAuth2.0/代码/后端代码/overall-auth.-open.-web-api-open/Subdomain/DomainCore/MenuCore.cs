using Model;
using Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subdomain.DomainCore
{
    /// <summary>
    /// 菜单核心
    /// </summary>
    public static class MenuCore
    {
        #region 用于菜单导航的树形结构

        /// <summary>
        /// 递归获取菜单结构--呈现上下级关系（转换layui-vue对应模型）
        /// 用于菜单的树形结构
        /// </summary>
        /// <returns></returns>
        public static List<MenuDao> GetMenuDao(List<Menu> menuList)
        {
            List<MenuDao> list = new();
            List<MenuDao> menuListDto = new();
            foreach (var item in menuList)
            {
                //菜单id为 40,52,74的改为39 ，因为它们使用的是菜单id为39的模板
                if (item.Id == 40 || item.Id == 52 || item.Id == 74)
                    item.Id = 39;
                MenuDao model = new()
                {
                    Title = item.MenuTitle,
                    Icon = item.MenuIcon,
                    Id = item.MenuUrl + "?MneuId=" + item.Id,
                    MenuKey = item.Id,
                    PMenuKey = item.Pid,
                    Component = item.Component,
                    Path = item.Path,
                    RequireAuth = item.RequireAuth,
                    Name = item.Name,
                    Redirect = item.Redirect,
                    IsOpen = item.IsOpen
                };
                list.Add(model);
            }
            foreach (var data in list.Where(f => f.PMenuKey == 0 && f.IsOpen))
            {
                var childrenList = GetChildrenMenu(list, data.MenuKey);
                data.children = childrenList.Count == 0 ? null : childrenList;
                menuListDto.Add(data);
            }
            return menuListDto;
        }

        /// <summary>
        /// 实现递归
        /// </summary>
        /// <param name="moduleOutput"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private static List<MenuDao> GetChildrenMenu(List<MenuDao> moduleOutput, int id)
        {
            List<MenuDao> sysShowTempMenus = new();
            //得到子菜单
            var info = moduleOutput.Where(w => w.PMenuKey == id && w.IsOpen).ToList();
            //循环
            foreach (var sysMenuInfo in info)
            {
                var childrenList = GetChildrenMenu(moduleOutput, sysMenuInfo.MenuKey);
                //把子菜单放到Children集合里
                sysMenuInfo.children = childrenList.Count == 0 ? null : childrenList;
                //添加父级菜单
                sysShowTempMenus.Add(sysMenuInfo);
            }
            return sysShowTempMenus;
        }


        #endregion


        #region 用于列表上的树形结构

        /// <summary>
        /// 递归获取菜单table树形结构
        /// </summary>
        /// <returns></returns>
        public static List<MenuOutput> GetTableTreeMenuDao(List<MenuOutput> menuList)
        {
            List<MenuOutput> list = new();
            List<MenuOutput> menuListDto = new();
            foreach (var item in menuList)
            {
                MenuOutput model = new()
                {
                    MenuTitle = item.MenuTitle,
                    MenuIcon = item.MenuIcon,
                    Id = item.Id,
                    Pid = item.Pid,
                    Component = item.Component,
                    Path = item.Path,
                    RequireAuth = item.RequireAuth,
                    Name = item.Name,
                    Redirect = item.Redirect,
                    IsOpen = item.IsOpen,
                    MenuUrl = item.MenuUrl,
                    CreateTime = item.CreateTime,
                    CreateUser = item.CreateUser,
                    UserName = item.UserName
                };
                list.Add(model);
            }
            foreach (var data in list.Where(f => f.Pid == 0 && f.IsOpen))
            {
                var childrenList = GetTableTreeChildrenMenu(list, data.Id);
                data.Children = childrenList.Count == 0 ? null : childrenList;
                menuListDto.Add(data);
            }
            return menuListDto;
        }

        /// <summary>
        /// 实现递归
        /// </summary>
        /// <param name="moduleOutput"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private static List<MenuOutput> GetTableTreeChildrenMenu(List<MenuOutput> moduleOutput, int id)
        {
            List<MenuOutput> sysShowTempMenus = new();
            //得到子菜单
            var info = moduleOutput.Where(w => w.Pid == id && w.IsOpen).ToList();
            //循环
            foreach (var sysMenuInfo in info)
            {
                var childrenList = GetTableTreeChildrenMenu(moduleOutput, sysMenuInfo.Id);
                //把子菜单放到Children集合里
                sysMenuInfo.Children = childrenList.Count == 0 ? null : childrenList;
                //添加父级菜单
                sysShowTempMenus.Add(sysMenuInfo);
            }
            return sysShowTempMenus;
        }


        #endregion


        #region 用于功能上的树形结构

        /// <summary>
        /// 递归获取角色树形结构--呈现上下级关系（转换layui-vue对应模型）
        /// 用于功能上的树形结构
        /// </summary>
        /// <param name="menuList">菜单集合</param>
        /// <param name="isDisabledGroup">是否禁用组菜单</param>
        /// <param name="isDisabledItem">是否禁用项菜单</param>
        /// <returns>返回layui-vue对应树模型</returns>
        public static List<LayuiTree> GetRoleMenuDao(List<Menu> menuList, bool isDisabledGroup, bool isDisabledItem)
        {
            List<LayuiTree> list = new();
            List<LayuiTree> menuListDto = new();
            foreach (var item in menuList)
            {
                LayuiTree model = new()
                {
                    Title = item.MenuTitle,
                    Id = item.Id,
                    Pid = item.Pid,
                    IsOpen = item.IsOpen
                };
                list.Add(model);
            }
            foreach (var data in list.Where(f => f.Pid == 0 && f.IsOpen))
            {
                //禁用组
                if (isDisabledGroup)
                    data.Disabled = true;

                var childrenList = GetChildrenRoleMenu(list, data.Id, isDisabledItem);
                data.Children = childrenList.Count == 0 ? null : childrenList;
                menuListDto.Add(data);
            }
            return menuListDto;
        }

        /// <summary>
        /// 实现递归
        /// </summary>
        /// <param name="moduleOutput"></param>
        /// <param name="id"></param>
        /// <param name="isDisabledItem"></param>
        /// <returns></returns>
        private static List<LayuiTree> GetChildrenRoleMenu(List<LayuiTree> moduleOutput, int id, bool isDisabledItem)
        {
            List<LayuiTree> sysShowTempMenus = new();
            //得到子菜单
            var info = moduleOutput.Where(w => w.Pid == id && w.IsOpen).ToList();
            //循环
            foreach (var sysMenuInfo in info)
            {
                //禁用项
                if (isDisabledItem)
                    sysMenuInfo.Disabled = true;

                var childrenList = GetChildrenRoleMenu(moduleOutput, sysMenuInfo.Id, isDisabledItem);
                //把子菜单放到Children集合里
                sysMenuInfo.Children = childrenList.Count == 0 ? null : childrenList;
                //添加父级菜单
                sysShowTempMenus.Add(sysMenuInfo);
            }
            return sysShowTempMenus;
        }

        #endregion
    }
}
