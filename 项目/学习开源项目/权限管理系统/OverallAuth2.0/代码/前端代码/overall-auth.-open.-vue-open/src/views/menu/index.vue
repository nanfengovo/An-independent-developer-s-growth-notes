<template>
  <lay-table
    :page="page"
    :expand-index="2"
    :height="'100%'"
    :columns="columns"
    :loading="loading"
    :data-source="dataSource"
    v-model:selected-keys="selectedKeys"
    @change="change"
    @sortChange="sortChange"
     :default-toolbar="true" 
     :default-expand-all="defaultExpandAll" 
    even
  >
    <template #status="{ row }">
      <lay-switch
        :model-value="row.status"
        @change="changeStatus($event, row)"
      ></lay-switch>
    </template>
    <template #menuTitleSlot="{ row }">
          <lay-icon :class="row.menuIcon"></lay-icon> &nbsp;&nbsp;
          {{ row.menuTitle }}
        </template>
    <template v-slot:toolbar>
      <navigation1
        @AddMenuKey="addMenu"
        @DelMenuKey="deleteMsg"
        :model="pageParms"
      ></navigation1>
       <lay-button size="sm" @click="expandAll">{{ defaultExpandAll ? '收起全部':'全部展开'}}</lay-button>
    </template>
    <!--超级管理员-->
    <template v-slot:operator="{ row }">
      <!-- <lay-button size="xs" type="primary" @click="editMenu(row)"
        >编辑</lay-button
      > -->
      <div>超级管理员才能修改</div>
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
import { getMenusList } from "../../api/menu/menu";

import ChildrenOne from "./addMenu.vue";
import navigation1 from "../button.vue";
import { GetMenuColsByMenuId,GetParamUrl } from "../../api/publicTool";
export default defineComponent({
  setup() {
    //初始化数据
    onMounted(() => {
      GetMenuColsByMenuIdMsg();
    });

    //分页参数
    const page = reactive({ current: 1, limit: 10, total: 0 });
    //定义列
    const columns = ref([]);

    //定义数据源
    const dataSource = ref([]);
    const loading = ref(false);
    const selectedKeys = ref([]);

    //获取菜单数据，并赋值
    const getMenu = async () => {
     var mneuId = GetParamUrl("MneuId");
      getMenusList({ pageIndex: page.current, pageSize: page.limit ,menuId:mneuId}).then(
        ({ data, code, msg, total }) => {
          if (code == 200) {
            dataSource.value = data;
            page.total = total;
          } else {
            layer.confirm(msg, { icon: 2, title: "错误消息" });
          }
        }
      );
    };

    //菜单列
    const GetMenuColsByMenuIdMsg = async () => {
      columns.value = await GetMenuColsByMenuId();
      if (columns.value.length > 1) {
        getMenu();
      } else {
        columns.value = [];
      }
    };

    //定义传入弹出层参数
    const openPageData = reactive({
      menuTitle: "",
      isOpen: true,
      pid: 0,
      menuUrl: "",
      menuIcon: "",
      id: 0,
    });

    //获取弹出层，并打开
    const Children = resolveComponent("ChildrenOne");
    const openPage = function (isAdd) {
      var tilte = "";
      if (isAdd) tilte = "新增菜单";
      else tilte = "编辑【" + openPageData.menuTitle + "】菜单信息";
      layer.open({
        title: tilte,
        area: ["50%", "55%"],
        content: h(ChildrenOne, {
          openPageData,
          onCloseBnt(res) {
            getMenu();
            layer.closeAll();
          },
        }),
      });
    };

    //新增菜单
    const addMenu = () => {
      emptyOpenPageData();
      openPage();
    };

    //编辑菜单
    const editMenu = (row) => {
      openPageData.isOpen = row.isOpen;
      openPageData.menuIcon = row.menuIcon;
      openPageData.menuTitle = row.menuTitle;
      openPageData.menuUrl = row.menuUrl;
      openPageData.id = row.id;
      openPageData.pid = row.pid;
      openPageData.component = row.component;
      openPage();
    };

    //删除菜单
    const deleteMsg = function () {
      layer.msg(selectedKeys.value, { area: "50%" });
    };

    //清空模型
    const emptyOpenPageData = function () {
      openPageData.isOpen = true;
      openPageData.menuIcon = "";
      openPageData.menuTitle = "";
      openPageData.menuUrl = "";
      openPageData.id = 0;
      openPageData.pid = 0;
      openPageData.component = "";
    };

    //加载数据
    const loadDataSource = (pageIndex, pageSize) => {
      page.current = pageIndex;
      page.limit = pageSize;
      return getMenu();
    };

    //分页事件
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
    const defaultExpandAll = ref(false);

    const expandAll = function() {
      defaultExpandAll.value = !defaultExpandAll.value;
    }
    return {
      columns,
      dataSource,
      selectedKeys,
      page,
      change,
      changeStatus,
      addMenu,
      editMenu,
      openPage,
      openPageData,
      Children,
      deleteMsg,
      defaultExpandAll,
      expandAll
    };
  },
  components: { navigation1 },
});
</script>