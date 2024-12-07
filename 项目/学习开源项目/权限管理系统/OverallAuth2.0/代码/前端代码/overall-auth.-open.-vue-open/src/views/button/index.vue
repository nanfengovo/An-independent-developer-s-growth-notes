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
    <template #buttonStyle="{ row }">
      <lay-button
        :type="row.types"
        :size="row.size"
        :border="row.borders"
        :border-style="row.bordersStyle"
        :radius="row?.isRadius == false ? false : true"
        :prefix-icon="row.icon"
      >
        {{ row.buttonName == "" ? "默认按钮" : row.buttonName }}
      </lay-button>
    </template>
    <template #status="{ row }">
      <lay-switch
        :model-value="row.status"
        @change="changeStatus($event, row)"
      ></lay-switch>
    </template>
    <template v-slot:toolbar>
      <navigation1 @AddButtonKey="addButton" :model="pageParms"></navigation1>
    </template>
    <template v-slot:operator="{ row }">
      <lay-button  :disabled="row.createUser == '1'?true:false" size="xs" type="primary" @click="editButton(row)"
        >编辑</lay-button
      >
    </template>
  </lay-table>
</template>

<script lang="ts">
import { ref, reactive, onMounted, h, defineComponent, Ref } from "vue";
import { layer } from "@layui/layui-vue";
import { getButtonList } from "../../api/button/index";
import { buttonModel } from "../../model/buttonStyle";
import ChildrenOne from "../button/addOrEdit.vue";
import navigation1 from "../button.vue";
import {
  GetMenuColsByMenuId,
  GetParamUrl,
  SysMenuTableColsDataOutPut,
} from "../../api/publicTool";
export default defineComponent({
  setup() {
    //初始化数据
    onMounted(() => {
      GetMenuColsByMenuIdMsg();
      
    });

    const page = reactive({ current: 1, limit: 10, total: 0 });
    //定义列
    const columns: Ref<SysMenuTableColsDataOutPut[]> = ref([]);

    //变量
    const dataSource = ref([]);
    const loading = ref(false);
    const selectedKeys = ref([]);

    //获取菜单，并赋值
    const getAllButtonList = async () => {
       var mneuId = GetParamUrl("MneuId");
      getButtonList({ pageIndex: page.current, pageSize: page.limit,menuId:mneuId }).then(
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
        getAllButtonList();
      } else {
        columns.value = [];
      }
    };

    //定义传入弹出层参数
    const openPageData = reactive<buttonModel>({
      BordersStyle: "soild",
      Size: "md",
      Types: "primary",
      Icon: "",
      ButtonStyleName: "",
      Borders: "",
      Radius: 2,
      IsRadius: false,
      ButtonStyleId: 0,
      MenuId: 0,
      ButtonName: "",
      ButtonKey: "",
      OrderBy: 0,
      ButtonId: 0,
    });

    //新增/编辑界面
    const addOrEditButton = function (isAdd: boolean) {
      var tilte = "";
      if (isAdd) tilte = "新增按钮";
      else tilte = "编辑【" + openPageData.ButtonName + "】按钮信息";
      layer.open({
        title: tilte,
        area: ["35%", "50%"],
        content: h(ChildrenOne, {
          openPageData,
          onCloseBnt(res: any) {
            getAllButtonList();
            layer.closeAll();
          },
        }),
      });
    };

    //添加角色
    const addButton = function () {
      emptyOpenPageData();
      addOrEditButton(true);
    };

    //编辑用户
    const editButton = (row: any) => {
      openPageData.BordersStyle = row.bordersStyle;
      openPageData.Size = row.size;
      openPageData.Types = row.types;
      openPageData.Icon = row.icon;
      openPageData.ButtonStyleName = row.buttonStyleName;
      openPageData.Borders = row.borders;
      openPageData.IsRadius = row.isRadius;
      openPageData.ButtonStyleId = row.buttonStyleId;
      openPageData.MenuId = row.menuId;
      openPageData.ButtonName = row.buttonName;
      openPageData.ButtonKey = row.buttonKey;
      openPageData.OrderBy = row.orderBy;
      openPageData.ButtonId = row.id;
      addOrEditButton(false);
    };

    //清空模型
    const emptyOpenPageData = function () {
      openPageData.BordersStyle = "soild";
      openPageData.Size = "md";
      openPageData.Types = "primary";
      openPageData.Icon = "";
      openPageData.ButtonStyleName = "";
      openPageData.Borders = "";
      openPageData.Radius = 2;
      openPageData.IsRadius = false;
      openPageData.ButtonStyleId = undefined;
      openPageData.MenuId = undefined;
      openPageData.ButtonName = "";
      openPageData.ButtonKey = "";
      openPageData.OrderBy = 0;
      openPageData.ButtonId = 0;
    };

    //分页相关
    const change = (page: { current: any; limit: any }) => {
      loading.value = true;
      loadDataSource(page.current, page.limit);
      loading.value = false;
    };
    const loadDataSource = (pageIndex: number, pageSize: number) => {
      page.current = pageIndex;
      page.limit = pageSize;
      getAllButtonList();
    };

    const remove = () => {
      //layer.msg(selectedKeys.value, { area: "50%" });
    };

    return {
      columns,
      dataSource,
      selectedKeys,
      page,
      addButton,
      editButton,
      openPageData,
      change,
      remove,
    };
  },
  components: {
    ChildrenOne,
    navigation1,
  },
});
</script>