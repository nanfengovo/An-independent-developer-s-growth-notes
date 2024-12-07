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
      <!-- <lay-button size="sm" type="primary" @click="addUser">新增</lay-button> -->
      <!-- <lay-button size="sm" @click="remove">删除</lay-button> -->
      <navigation1 @AddUserKey="addUser" :model="pageParms"></navigation1>
    </template>
    <template v-slot:operator="{ row }">
      <!--超级管理员-->
      <lay-button
        :disabled="row.userName == 'admin' ? true : false"
        size="xs"
        type="primary"
        @click="editUser(row)"
        >编辑</lay-button
      >
      <lay-button
        :disabled="row.userName == 'admin' ? true : false"
        size="xs"
        type="primary"
        @click="setRole(row)"
        >设置角色</lay-button
      >

      <!-- <lay-button size="xs">查看</lay-button> -->
    </template>
  </lay-table>
</template>

<script>
import { ref, reactive, onMounted, h, defineComponent } from "vue";
import { layer } from "@layui/layui-vue";
import { getUserListMsg } from "../../api/user/index";
import navigation1 from "../button.vue";
import ChildrenSetRole from "./setRole.vue";
import ChildrenAddUser from "./addUser.vue";
import { GetMenuColsByMenuId, GetParamUrl } from "../../api/publicTool";
import { useUserStore } from "../../store/user";

export default defineComponent({
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
        getUser();
      } else {
        columns.value = [];
      }
    };

    //获取菜单，并赋值
    const getUser = async () => {
      getUserListMsg({
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

    //定义传入弹出层参数(新增编码)
    const openPageData = reactive({
      userId: 0,
      userName: "",
      sex: 1,
      password: "",
      age: "",
      //roleId:[]
    });

    const setRoleData = reactive({
      userId: 0,
      userName: "",
      roleId: [],
    });

    //获取弹出层，并打开
    const setRole = function (row) {
      setRoleData.userId = row.userId;
      setRoleData.userName = row.userName;
      setRoleData.roleId =
        row.roleId.length > 0 ? row.roleId.split(",").map(Number) : [];
      layer.open({
        title: "设置用户【" + setRoleData.userName + "】权限",
        area: ["35%", "25%"],
        content: h(ChildrenSetRole, {
          setRoleData,
          onCloseBnt(res) {
            getUser();
            layer.closeAll();
          },
        }),
      });
    };

    const addOrEditUser = function () {
      var title = openPageData.userId > 0 ? "编辑用户" : "新增用户";
      layer.open({
        title: title,
        area: ["45%", "40%"],
        content: h(ChildrenAddUser, {
          openPageData,
          onCloseBnt(res) {
            getUser();
            layer.closeAll();
          },
        }),
      });
    };

    //添加用户
    const addUser = function () {
      emptyOpenPageData();
      addOrEditUser();
    };

    //编辑用户
    const editUser = (row) => {
      openPageData.userId = row.userId;
      openPageData.password = row.password;
      openPageData.sex = parseInt(row.sex);
      openPageData.userName = row.userName;
      openPageData.age = row.age;
      addOrEditUser();
    };

    const emptyOpenPageData = function () {
      openPageData.userId = 0;
      openPageData.password = "";
      openPageData.sex = 1;
      openPageData.userName = "";
      openPageData.age = "";
    };
    const loading = ref(false);

    const selectedKeys = ref([]);

    const change = (page) => {
      loading.value = true;
      dataSource.value = loadDataSource(page.current, page.limit);
      loading.value = false;
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
      editUser,
      setRole,
      addUser,
      openPageData,
      //Children,
    };
  },
  components: { navigation1 },
});
</script>