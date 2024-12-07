<template>
  <lay-table
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
        {{ row.buttonStyleName == "" ? "默认按钮" : row.buttonStyleName }}
      </lay-button>
    </template>
    <template #status="{ row }">
      <lay-switch
        :model-value="row.status"
        @change="changeStatus($event, row)"
      ></lay-switch>
    </template>
    <template v-slot:toolbar>
      <navigation1
        @AddButtonStyleKey="addButtonStyle"
        :model="pageParms"
      ></navigation1>
      <!-- <lay-button size="sm" type="primary" @click="addButtonStyle"
        >新增</lay-button
      >
      <lay-button size="sm" @click="remove">删除</lay-button> -->
    </template>
    <template v-slot:operator="{ row }">
      <lay-button size="xs" type="primary" @click="editButtonStyle(row)"
        >编辑</lay-button
      >
      <!-- <lay-button size="xs">查看</lay-button> -->
    </template>
  </lay-table>
</template>

<script lang="ts">
import {
  ref,
  watch,
  reactive,
  onMounted,
  h,
  resolveComponent,
  defineComponent,
  Ref,
} from "vue";
import { layer } from "@layui/layui-vue";
import { getAllButtonStyle } from "../../api/button/index";
import { buttonStyleModel } from "../../model/buttonStyle";
import ChildrenOne from "./addOrEdit.vue";
import navigation1 from "../button.vue";
import {
  SysMenuTableColsDataOutPut,
  GetMenuColsByMenuId,
  GetParamUrl,
} from "../../api/publicTool";

export default defineComponent({
  setup() {
    //初始化数据
    onMounted(() => {
      GetMenuColsByMenuIdMsg();
    });

    //const page = reactive({ current: 1, limit: 10, total: 0 });
    //定义列
    const columns: Ref<SysMenuTableColsDataOutPut[]> = ref([]);

    //定义数据源
    const dataSource = ref([]);
    const loading = ref(false);
    const selectedKeys = ref([]);

    //菜单列
    const GetMenuColsByMenuIdMsg = async () => {
      columns.value = await GetMenuColsByMenuId();
      if (columns.value.length > 1) {
        getAllButtonStyleList();
      } else {
        columns.value = [];
      }
    };

    //获取菜单，并赋值
    const getAllButtonStyleList = async () => {
      getAllButtonStyle({menuId:GetParamUrl("MneuId"),buttonStyleName:""}).then(({ data, code, msg }) => {
        if (code == 200) {
          dataSource.value = data;
        } else {
          layer.confirm(msg, { icon: 2, title: "错误消息" });
        }
      });
    };

    //定义传入弹出层参数
    const openPageData = reactive<buttonStyleModel>({
      BordersStyle: "soild",
      Size: "md",
      Types: "primary",
      Icon: "",
      ButtonStyleName: "",
      Borders: "",
      Radius: 2,
      IsRadius: false,
      ButtonStyleId: 0,
    });

    //新增/编辑界面
    const addOrEditButton = function (isAdd: boolean) {
      var tilte = "";
      if (isAdd) tilte = "新增按钮样式";
      else tilte = "编辑【" + openPageData.ButtonStyleName + "】按钮样式信息";
      layer.open({
        title: tilte,
        area: ["35%", "70%"],
        content: h(ChildrenOne, {
          openPageData,
          onCloseBnt(res: any) {
            getAllButtonStyleList();
            layer.closeAll();
          },
        }),
      });
    };

    //添加按钮样式
    const addButtonStyle = function () {
      emptyOpenPageData();
      addOrEditButton(true);
    };

    //编辑按钮样式
    const editButtonStyle = function (row: any) {
      openPageData.BordersStyle = row.bordersStyle;
      openPageData.Size = row.size;
      openPageData.Types = row.types;
      openPageData.Icon = row.icon;
      openPageData.ButtonStyleName = row.buttonStyleName;
      openPageData.Borders = row.borders;
      openPageData.IsRadius = row.isRadius;
      openPageData.Radius = row.isRadius == true ? 1 : 2;
      openPageData.ButtonStyleId = row.id;
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
      openPageData.ButtonStyleId = 0;
    };

    return {
      columns,
      dataSource,
      selectedKeys,
      //ChildrenOne,
      addButtonStyle,
      editButtonStyle,
      openPageData,
    };
  },
  components: {
    ChildrenOne,
    navigation1,
  },
});
</script>