<template>
  <lay-panel>
    <div style="width: 300px; height: 33px; float: left">
      <div style="width: 80px; float: left; height: 100%; line-height: 38px">
        所属菜单:
      </div>
      <div style="width: 210px; float: left; height: 100%">
        <lay-tree-select
          style="width: 100%"
          v-model="searchFilter.MenuId"
          :data="parentMenu"
          size="lg"
        ></lay-tree-select>
      </div>
    </div>
    <div>
      <lay-button border="orange" border-style="dashed" @click="searchClick"
        >搜索</lay-button
      >
    </div>
  </lay-panel>
  <lay-table
    :page="page"
    :height="'100%'"
    :columns="columns"
    :loading="loading"
    :default-toolbar="true"
    :data-source="dataSource"
    v-model:selected-keys="selectedKeys"
    @change="change"
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
    <!-- <template #status="{ row }">
      <lay-switch
        :model-value="row.status"
        @change="changeStatus($event, row)"
      ></lay-switch>
    </template> -->
    <template v-slot:toolbar>
      <navigation1 @AddDataColsKey="addDataCols" :model="null"></navigation1>
    </template>
    <!--超级管理员-->
    <template v-slot:operator="{ row }">
      <!-- <lay-button :disabled="row.createUser == '1'?true:false" size="xs" type="primary" @click="editDataCols(row)"
        >编辑</lay-button
      > -->
      <lay-button size="xs" type="primary" @click="editDataCols(row)"
        >编辑</lay-button
      >
    </template>
  </lay-table>
</template>

<script lang="ts">
import { ref, reactive, onMounted, h, defineComponent, Ref } from "vue";
import { layer } from "@layui/layui-vue";
import { getMenuTableColsList } from "../../../api/authority/tableCols/index";
import ChildrenOne from "../tableCols/addOrEdit.vue";
import { menuTableColsModel } from "../../../model/menuTableCols";
import navigation1 from "../../button.vue";
import {
  SysMenuTableColsDataOutPut,
  GetMenuColsByMenuId,
  GetParamUrl,
} from "../../../api/publicTool";
import { getMenuSelectTree } from "../../../api/button";

export default defineComponent({
  setup() {
    //初始化数据
    onMounted(() => {
      getMenuSelectTreeMsg();
      GetMenuColsByMenuIdMsg();
    });
    //菜单
    const parentMenu = ref({});
    const page = reactive({ current: 1, limit: 15, total: 0 });
    //定义列
    const columns: Ref<SysMenuTableColsDataOutPut[]> = ref([]);

    //变量
    const dataSource = ref([]);
    const loading = ref(false);
    const selectedKeys = ref([]);

    const searchFilter = reactive<any>({
      MenuId: 0,
    });

    //菜单列
    const GetMenuColsByMenuIdMsg = async () => {
      columns.value = await GetMenuColsByMenuId();
      if (columns.value.length > 1) {
        getMenuTableColsListMsg();
      } else {
        columns.value = [];
      }
    };

    //获取菜单数据列，并赋值
    const getMenuTableColsListMsg = async () => {
      getMenuTableColsList({
        pageIndex: page.current,
        pageSize: page.limit,
        filterJson: JSON.stringify(searchFilter),
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
    const openPageData = reactive<menuTableColsModel>({
      Id: 0,
      MenuId: 0,
      //MenuTitle: "",
      FieldName: "",
      FieldType: "",
      FieldTitle: "",
      FieldOrderBy: 0,
      FieldWidth: 0,
      FieldSort: "",
      FieldCustomSlot: "",
      FieldAlign: "",
      FieldFixed: "",
      FieldMinWidth: 0,
      FieldEllipsisTooltips: 0,
      FieldEllipsisTooltip: false,
      DataRowAuthType: 1,
      DataRowAuthField: "",
      DataRowAuthFieldName: "",
      IsSystemData: 2,
    });

    //新增/编辑界面
    const addOrEditDataCols = function (isAdd: boolean) {
      var tilte = "";
      if (isAdd) tilte = "新增数据列信息";
      else tilte = "编辑数据列信息";
      layer.open({
        title: tilte,
        area: ["35%", "90%"],
        content: h(ChildrenOne, {
          openPageData,
          onCloseBnt(res: any) {
            getMenuTableColsListMsg();
            layer.closeAll();
          },
        }),
      });
    };

    //添加
    const addDataCols = function () {
      emptyOpenPageData();
      addOrEditDataCols(true);
    };

    //编辑
    const editDataCols = (row: any) => {
      openPageData.Id = row.id;
      openPageData.MenuId = row.menuId;
      //openPageData.MenuTitle = row.menuTitle;
      openPageData.FieldName = row.fieldName;
      openPageData.FieldType = row.fieldType;
      openPageData.FieldTitle = row.fieldTitle;
      openPageData.FieldOrderBy = row.fieldOrderBy;
      openPageData.FieldWidth = row.fieldWidth == null ? 0 : row.fieldWidth;
      openPageData.FieldSort = row.fieldSort;
      openPageData.FieldCustomSlot = row.fieldCustomSlot;
      openPageData.FieldAlign = row.fieldAlign;
      openPageData.FieldFixed = row.fieldFixed;
      openPageData.FieldMinWidth =
        row.fieldMinWidth == null ? 0 : row.fieldMinWidth;
      openPageData.FieldEllipsisTooltips =
        row.fieldEllipsisTooltip == false ? 0 : 1;
      openPageData.DataRowAuthType = row.dataRowAuthType;
      openPageData.DataRowAuthFieldName = row.dataRowAuthFieldName;
      openPageData.DataRowAuthField = row.dataRowAuthField;
      openPageData.IsSystemData = row.isSystemData;
      addOrEditDataCols(false);
    };

    //清空模型
    const emptyOpenPageData = function () {
      openPageData.Id = 0;
      openPageData.MenuId = undefined;
      //openPageData.MenuTitle = "";
      openPageData.FieldName = "";
      openPageData.FieldType = "";
      openPageData.FieldTitle = "";
      openPageData.FieldOrderBy = 0;
      openPageData.FieldWidth = 0;
      openPageData.FieldSort = "";
      openPageData.FieldCustomSlot = "";
      openPageData.FieldAlign = "";
      openPageData.FieldFixed = "";
      openPageData.FieldMinWidth = 0;
      openPageData.FieldEllipsisTooltips = 0;
      openPageData.IsSystemData = 2;
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
      getMenuTableColsListMsg();
    };

    //获取父级菜单
    const getMenuSelectTreeMsg = async () => {
      getMenuSelectTree().then(({ data, code, msg }) => {
        if (code == 200) {
          parentMenu.value = data;
        } else {
          layer.confirm(msg, { icon: 2, title: "错误消息" });
        }
      });
    };

    //搜索
    const searchClick = function () {
      if (columns.value.length <= 1) layer.msg("未设置显示列，不能查询数据");
      else getMenuTableColsListMsg();
    };
    return {
      columns,
      dataSource,
      selectedKeys,
      page,
      addDataCols,
      editDataCols,
      openPageData,
      change,
      parentMenu,
      searchClick,
      searchFilter,
      loading,
    };
  },
  components: {
    ChildrenOne,
    navigation1,
  },
});
</script>