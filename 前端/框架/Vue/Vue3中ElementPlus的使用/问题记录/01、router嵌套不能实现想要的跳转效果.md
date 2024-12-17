![[routerviewNG演示.gif]]
可以看到点击用户是不符合想要实现的效果的，而菜单是满足的
核心代码：component:Framework,
```
 {

        path: '/menu',

        redirect: '/menu/index',

        meta: { title: '菜单管理' },

        name: "菜单管理",

        component:Framework,

        children: [

        {

            path: '/menu',

            name: '菜单',

            component: () => import('../../views/menu/index.vue'),

            meta: { title: '菜单', requireAuth: true, affix: true, closable: false },

        }

        ]

    },

    {

        path: '/user',

        meta: { title: '用户管理' },

        name: "用户管理",

        children: [

        {

            path: '/user',

            name: '用户',

            component: () => import('../../views/user/index.vue'),

            meta: { title: '用户' },

        }]

    },
```