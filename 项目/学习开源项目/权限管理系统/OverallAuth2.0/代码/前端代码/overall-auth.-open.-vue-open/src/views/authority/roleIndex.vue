<template>
  <lay-table
    :page="page"
    :height="'100%'"
    :columns="columns"
    :loading="loading"
    :default-toolbar="true"
    :data-source="dataSource"
    v-model:selected-keys="selectedKeys"
    @change="change"
    @sortChange="sortChange"
    even
  >
    <template #status="{ row }">
      <lay-switch
        :model-value="row.status"
        @change="changeStatus($event, row)"
      ></lay-switch>
    </template>
    <template v-slot:toolbar>
      <navigation1 @AddRoleKey="addRole" :model="pageParms"></navigation1>
      <!-- <lay-button size="sm" type="primary" @click="addRole">新增</lay-button>
      <lay-button size="sm" @click="remove">删除</lay-button> -->
    </template>
    <!--超级管理员-->
    <template v-slot:operator="{ row }">
      <lay-button
        v-if="auth == authTypeEnum.menuAuth"
        :disabled="row.roleId != 1 ? false : true"
        size="xs"
        type="primary"
        @click="setMenuRole(row)"
        >菜单权限</lay-button
      >
      <lay-button
        v-if="auth == authTypeEnum.buttonAuth"
        :disabled="row.roleId != 1 ? false : true"
        size="xs"
        type="primary"
        @click="setButtonRole(row)"
        >按钮权限</lay-button
      >
      <lay-button
        v-if="auth == authTypeEnum.colsAuth"
        :disabled="row.roleId != 1 ? false : true"
        size="xs"
        type="primary"
        @click="editMenuCols(row)"
        >数据列权限</lay-button
      >
    </template>
  </lay-table>
</template>

<script>
import {
  ref,
  watch,
  reactive,
  onMounted,
  h,
  resolveComponent,
  defineComponent,
} from "vue";
import { layer } from "@layui/layui-vue";
import { getAllRoleMsg } from "../../api/authority/index";
import ChildrenOne from "./roleMenu.vue";
import RoleButton from "./roleButton.vue";
import ChildroleCols from "./roleCols.vue";
import ChildrenAddRole from "./addRole.vue";
import navigation1 from "../button.vue";
import {
  GetMenuColsByMenuId,
  GetParamUrl,
  authTypeEnum,
} from "../../api/publicTool";
export default defineComponent({
  props: {
    auth: {
      type: Number,
      required: true,
    },
  },
  setup() {
    //初始化数据
    onMounted(() => {
      GetMenuColsByMenuIdMsg();
    });

    const page = reactive({ current: 1, limit: 10, total: 0 });
    //定义列
    const columns = ref([]);

    //定义数据源
    const dataSource = ref([]);

    //菜单列
    const GetMenuColsByMenuIdMsg = async () => {
      columns.value = await GetMenuColsByMenuId();
      if (columns.value.length > 1) {
        getRole();
      } else {
        columns.value = [];
      }
    };
    //获取菜单，并赋值
    const getRole = async () => {
      getAllRoleMsg({
        pageIndex: page.current,
        pageSize: page.limit,
        menuId: GetParamUrl("MneuId"),
      }).then(({ data, code, msg, total }) => {
        if (code == 200) {
          dataSource.value = data;
          page.total = total;
        } else {
          layer.confirm(msg, { icon: 2, title: "错误消息" });
        }
      });
    };

    //定义传入弹出层参数
    const openPageData = reactive({
      roleId: 0,
      roleName: "",
    });

    //添加角色
    const addRole = function () {
      openPageData.roleId = 0;
      openPageData.roleName = "";
      layer.open({
        title: "新增角色",
        area: ["35%", "25%"],
        content: h(ChildrenAddRole, {
          openPageData,
          onCloseBnt(res) {
            getRole();
            layer.closeAll();
          },
        }),
      });
    };

    const loading = ref(false);

    const selectedKeys = ref([]);

    const change = (page) => {
      loading.value = true;
      dataSource.value = loadDataSource(page.current, page.limit);
      loading.value = false;
    };

    const sortChange = (key, sort) => {
      layer.msg(
        `字段${key} - 排序${sort}, 你可以利用 sort-change 实现服务端排序`
      );
    };

    const changeStatus = (isChecked, row) => {
      dataSource.value.forEach((item) => {
        if (item.id === row.id) {
          layer.msg("Success", { icon: 1 }, () => {
            item.status = isChecked;
          });
        }
      });
    };

    //设置菜单权限
    const setMenuRole = (row) => {
      (openPageData.roleId = row.roleId),
        (openPageData.roleName = row.roleName);
      openPage();
    };

    //获取弹出层，并打开
    const openPage = function () {
      layer.open({
        title: "设置角色【" + openPageData.roleName + "】菜单权限",
        area: ["25%", "65%"],
        content: h(ChildrenOne, {
          openPageData,
          onCloseBnt(res) {
            getRole();
            layer.closeAll();
          },
        }),
      });
    };

    //设置按钮权限
    const setButtonRole = (row) => {
      (openPageData.roleId = row.roleId),
        (openPageData.roleName = row.roleName);
      openButton();
    };

    //获取弹出层，并打开
    const openButton = function () {
      layer.open({
        title: "设置角色【" + openPageData.roleName + "】按钮权限",
        area: ["65%", "65%"],
        content: h(RoleButton, {
          openPageData,
          onCloseBnt(res) {
            getRole();
            layer.closeAll();
          },
        }),
      });
    };
    //数据列权限
    const editMenuCols = (row) => {
      (openPageData.roleId = row.roleId),
        (openPageData.roleName = row.roleName);
      layer.open({
        title: "设置角色【" + openPageData.roleName + "】列权限",
        area: ["65%", "65%"],
        content: h(ChildroleCols, {
          openPageData,
          onCloseBnt(res) {
            getRole();
            layer.closeAll();
          },
        }),
      });
    };

    const remove = () => {
      layer.msg(selectedKeys.value, { area: "50%" });
    };

    const loadDataSource = (pageIndex, pageSize) => {
      page.current = pageIndex;
      page.limit = pageSize;
      return getRole();
    };

    return {
      columns,
      dataSource,
      selectedKeys,
      page,
      change,
      changeStatus,
      remove,
      setMenuRole,
      setButtonRole,
      editMenuCols,
      openPage,
      openButton,
      addRole,
      openPageData,
      authTypeEnum,
      //Children,
    };
  },
  components: { navigation1 },
});
</script>