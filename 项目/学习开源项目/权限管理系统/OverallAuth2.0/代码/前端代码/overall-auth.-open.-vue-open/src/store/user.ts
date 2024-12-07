import { defineStore } from 'pinia'
import { menu, permission } from "../api/module/user";
import { layer } from '@layui/layui-vue';
import { routes } from '../router/module/base-routes'
import { RouteRecordRaw, createWebHashHistory, Router } from 'vue-router';
import BaseLayout from '../../layouts/BaseLayout.vue';
import router from '../router/index';
import { ref } from 'vue';
const defineRouteComponents: Record<string, any> = {
  BaseLayout: () => import('@/layouts/BaseLayout.vue')
};
const defineRouteComponentKeys = Object.keys(defineRouteComponents);
export const generator = (
  routeMap: any[],
  parentId: string | number,
  routeItem?: any | [],
) => {
  return routeMap
    //.filter(item => item.menuKey === parentId)
    .map(item => {
      const pathArray = item.component.split('/');
      const url = ref<any>();
      if (pathArray.length > 0) {
        if (pathArray.length === 3)
          url.value = import(`../${pathArray[1]}/${pathArray[2]}.vue`);
        if (pathArray.length === 4)
          url.value = import(`../${pathArray[1]}/${pathArray[2]}/${pathArray[3]}.vue`);
        if (pathArray.length === 5)
          url.value = import(`../${pathArray[1]}/${pathArray[2]}/${pathArray[3]}/${pathArray[4]}.vue`);
      };
      const { title, requireAuth, menuKey } = item || {};
      const currentRouter: RouteRecordRaw = {
        // 如果路由设置了 path，则作为默认 path，否则 路由地址 动态拼接生成如 /dashboard/workplace
        path: item.path,
        // 路由名称，建议唯一
        //name: `${item.id}`,
        // meta: 页面标题, 菜单图标, 页面权限(供指令权限用，可去掉)
        meta: {
          title,
          requireAuth,
          menuKey
        },
        name: item.name,
        children: [],
        // 该路由对应页面的 组件 (动态加载 @/views/ 下面的路径文件)
        component: item.component && defineRouteComponentKeys.includes(item.component)
          ? defineRouteComponents[item.component]
          : () => url.value,

      };

      // 为了防止出现后端返回结果不规范，处理有可能出现拼接出两个 反斜杠
      if (!currentRouter.path.startsWith('http')) {
        currentRouter.path = currentRouter.path.replace('//', '/');
      }

      // 重定向
      item.redirect && (currentRouter.redirect = item.redirect);
      if (item.children != null) {
        // 子菜单，递归处理
        currentRouter.children = generator(item.children, item.menuKey, currentRouter);
      }
      if (currentRouter.children === undefined || currentRouter.children.length <= 0) {
        currentRouter.children;
      }
      return currentRouter;
    })
    .filter(item => item);
};

export const useUserStore = defineStore({
  id: 'user',
  state: () => {
    return {
      token: '',
      expiresDate: '',
      roleIds: '',
      userInfo: {},
      permissions: [],
      menus: [],
    }
  },
  actions: {
    async loadMenus() {
      new Promise<any>(async (resolve, reject) => {
        const { data, code, msg } = await menu();
        if (code == 200) {
          this.menus = data;
          var menuList = generator(data, '', undefined) as RouteRecordRaw[]
          menuList.map(d => {
            router.addRoute(d);
          })
          resolve(menuList);
        }
        else {
          this.menus =[];
          layer.confirm(msg, { icon: 2, title: "错误消息" });
        }
      });
    },
    async loadPermissions() {
      const { data, code, msg } = await permission();
      if (code == 200) {
        this.permissions = data;
      } else {
        layer.confirm(msg, { icon: 2, title: "错误消息" });
      }
    },
    // async getMenus(){
    //   debugger
    //   const { data, code } = await getParentMenusList();
    //   if(code == 200) {
    //     this.menus = data;
    //   }
    // },
  },
  persist: {
    storage: localStorage,
    paths: ['token', 'userInfo', 'permissions', 'menus', 'roleIds', 'expiresDate'],
  }
})

