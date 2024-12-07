<template>
  <lay-layout class="example">
    <lay-layout>
      <lay-side class="layuiSideCalss">
        <lay-tree
          :data="tree"
          v-model:selectedKey="checkedKeys2"
          :showLine="showLine"
          @node-click="handleClick"
        >
        </lay-tree>
      </lay-side>
      <lay-body style="margin: 10px 10px">
        <div>
          <lay-radio-button
            v-model="selectedValue"
            name="action"
            value="1"
            @change="change"
            >权限规则数据</lay-radio-button
          >
          <lay-radio-button
            v-model="selectedValue"
            name="action"
            value="2"
            @change="change"
            >基础数据配置</lay-radio-button
          >
        </div>
        <div v-if="selectedValue == 1">
          <lay-table
            :height="'100%'"
            :columns="menuColumns"
            :data-source="dataSource"
            even
          >
            <template v-slot:toolbar>
              <lay-button
                size="sm"
                border="blue"
                border-style="dashed"
                prefix-icon="layui-icon-set"
                @click="addRule"
                >新增行数据权限规则</lay-button
              >
            </template>
            <template #status="{ row }">
              <lay-switch
                :model-value="row.isOpen"
                onswitch-text="已启用"
                unswitch-text="已关闭"
                @change="changeStatus($event, row.id)"
              ></lay-switch>
            </template>
            <template v-slot:operator="{ row }">
              <lay-button
                border="green"
                border-style="dashed"
                size="xs"
                @click="editRule(row)"
              >
                <lay-icon class="layui-icon-edit"></lay-icon> 编辑</lay-button
              >
              <lay-popconfirm
                content="确定要删除此规则吗?"
                @confirm="deleteRule(row.id)"
              >
                <lay-button size="xs" border="red" border-style="dashed"
                  ><lay-icon class="layui-icon-delete"></lay-icon>
                  删除</lay-button
                >
              </lay-popconfirm>
            </template>
          </lay-table>
        </div>
        <div v-if="selectedValue == 2">
          <lay-table
            :height="'100%'"
            :columns="menuColumnsConfig"
            :data-source="configList"
            even
          >
            <template v-slot:toolbar>
              <lay-button
                size="sm"
                border="blue"
                border-style="dashed"
                prefix-icon="layui-icon-set"
                @click="addBaseConfig"
                >新增基础数据</lay-button
              >
            </template>
            <template #conditionalEquationValueSty="{ row }">
              <lay-select v-model="row.conditionalEquationList[0].value">
                <lay-select-option
                  v-for="item in row.conditionalEquationList"
                  :key="item.value"
                  :value="item.value"
                  :label="item.label"
                ></lay-select-option>
              </lay-select>
            </template>
            <template #conditionalEquationValueListSty="{ row }">
              <div v-if="row.conditionalEquationValueList.length == 0">
                手输
              </div>
              <div v-if="row.conditionalEquationValueList.length > 0">
                <lay-select v-model="row.conditionalEquationValueList[0].value">
                  <lay-select-option
                    v-for="item in row.conditionalEquationValueList"
                    :key="item.value"
                    :value="item.value"
                    :label="item.label"
                  ></lay-select-option>
                </lay-select>
              </div>
            </template>
            <template v-slot:operator="{ row }">
              <lay-button
                size="xs"
                border="green"
                border-style="dashed"
                @click="editBaseConfig(row)"
              >
                <lay-icon class="layui-icon-edit"></lay-icon> 编辑</lay-button
              >
              <lay-popconfirm
                content="确定要删除此规则配置吗?"
                @confirm="deleteRuleConfig(row.id)"
              >
                <lay-button size="xs" border="red" border-style="dashed"
                  ><lay-icon class="layui-icon-delete"></lay-icon>
                  删除</lay-button
                >
              </lay-popconfirm>
            </template>
          </lay-table>
        </div>
      </lay-body>
    </lay-layout>
  </lay-layout>
</template>

<script lang="ts">
import { ref, reactive, onMounted, h, defineComponent, Ref } from "vue";
import { layer } from "@layui/layui-vue";
import configureRules from "../tableRow/configureRules.vue";
import baseConfigure from "../tableRow/baseConfigure.vue";
import { getMenuByRoleId } from "../../../api/authority/index";
import {
  GetTableRowAuthByMenuId,
  GetRowAuthConfigByMenuId,
  GetTableRowAuthConfigByMenuId,
  SetRuleIsOpenById,
  DeleteRule,
  DeleteRuleConfig,
} from "../../../api/authority/tableRow/index";
import {
  OriginalTreeData,
  StringOrNumber,
} from "@layui/layui-vue/types/component/tree/tree.type";
import { LayuiSelectRowAuthExtend } from "../../../model/match";

export default defineComponent({
  setup() {
    //初始化数据
    onMounted(() => {
      getRoleMenus();
      getTableRowAuthByMenuIdRule();
      getRowAuthConfigByMenuIdMsg();
      GetTableRowAuthConfig();
    });
    const tree = ref();
    const menuColumns = ref([
      // { title: "选项", width: "55px", type: "checkbox", fixed: "left" },
      {
        title: "编号",
        width: "80px",
        key: "id",
      },
      {
        title: "规则",
        width: "280px",
        key: "ruleJson",
        ellipsisTooltip: true,
      },
      {
        title: "备注",
        width: "280px",
        key: "remark",
        ellipsisTooltip: true,
      },
      {
        title: "是否使用",
        width: "100px",
        key: "isOpen",
        customSlot: "status",
      },
      {
        title: "创建时间",
        width: "100px",
        key: "createTime",
      },
      {
        title: "操作",
        width: "120px",
        key: "operator",
        customSlot: "operator",
      },
    ]);

    const menuColumnsConfig = ref([
      // { title: "选项", width: "55px", type: "checkbox", fixed: "left" },
      {
        title: "编号",
        width: "80px",
        key: "id",
      },
      {
        title: "字段",
        width: "180px",
        key: "label",
        ellipsisTooltip: true,
      },
      {
        title: "条件",
        width: "200px",
        key: "conditionalEquationValue",
        ellipsisTooltip: true,
        customSlot: "conditionalEquationValueSty",
      },
      // {
      //   title: "结果控件样式",
      //   width: "180px",
      //   key: "ShowControl",
      // },
      {
        title: "结果控件样式数据",
        width: "180px",
        key: "showControlDataSource",
        customSlot: "conditionalEquationValueListSty",
      },
      // {
      //   title: "创建时间",
      //   width: "100px",
      //   key: "createTime",
      // },
      {
        title: "操作",
        width: "100px",
        key: "operator",
        customSlot: "operator",
      },
    ]);
    //变量
    const selectedValue = ref("1");
    const change = function (current: string) {
      console.log("当前值:" + current);
    };
    const dataSource = ref([]);
    const dataSourceConfig = ref([]);
    const checkedKeys2 = ref<StringOrNumber>(5);
    const menuId = ref<StringOrNumber>(5);
    const configList = ref<LayuiSelectRowAuthExtend[]>([]);

    //获取菜单
    const getRoleMenus = async () => {
      getMenuByRoleId({
        roleId: 0,
        isDisabledGroup: true,
        isDisabledItem: false,
      }).then(({ data, code, msg }) => {
        if (code == 200) {
          tree.value = data[0].treeItems;
        } else {
          layer.confirm(msg, { icon: 2, title: "错误消息" });
        }
      });
    };

    //获取菜单数据权限规则
    const getTableRowAuthByMenuIdRule = async () => {
      GetTableRowAuthByMenuId({ menuId: menuId.value }).then(
        ({ data, code, msg }) => {
          if (code == 200) {
            dataSource.value = data;
          } else {
            layer.confirm(msg, { icon: 2, title: "错误消息" });
          }
        }
      );
    };

    //获取菜单数据权限配置
    const getRowAuthConfigByMenuIdMsg = async () => {
      GetRowAuthConfigByMenuId({ menuId: menuId.value }).then(
        ({ data, code, msg }) => {
          if (code == 200) {
            dataSourceConfig.value = data;
          } else {
            layer.confirm(msg, { icon: 2, title: "错误消息" });
          }
        }
      );
    };

    //树点击事件
    function handleClick(node: OriginalTreeData) {
      menuId.value = node.id;
      checkedKeys2.value = node.id;
      getTableRowAuthByMenuIdRule();
      GetTableRowAuthConfig();
      getRowAuthConfigByMenuIdMsg();
    }

    //定义传入弹出层参数
    const openPageData = reactive<any>({
      menuId: menuId.value,
      ruleJson: [],
      rowAuthId: 0,
      dataSourceConfig: [],
      configId: 0,
      PermissionsField: "",
      ConditionalEquationValue: [],
      ShowControl: "",
      ShowControlDataSource: "",
    });

    //编辑规则
    const editRule = function (row: any) {
      openPageData.ruleJson = JSON.parse(row.ruleJson);
      openPageData.rowAuthId = row.id;
      openPageData.remark = row.remark;
      openPageData.isOpen = row.isOpen;
      addOrEditMenuRowRole(false);
    };

    //新增规则
    const addRule = function () {
      openPageData.ruleJson = "";
      openPageData.rowAuthId = 0;
      openPageData.remark = "";
      openPageData.isOpen = false;
      addOrEditMenuRowRole(true);
    };

    //删除规则
    const deleteRule = function (id: StringOrNumber) {
      DeleteRule({ id: id }).then(({ code, msg }) => {
        if (code == 200) {
          getTableRowAuthByMenuIdRule();
          GetTableRowAuthConfig();
          getRowAuthConfigByMenuIdMsg();
        } else {
          layer.confirm(msg, { icon: 2, title: "错误消息" });
        }
      });
    };

    //删除规则配置
    const deleteRuleConfig = function (id: StringOrNumber) {
      DeleteRuleConfig({ id: id }).then(({ code, msg }) => {
        if (code == 200) {
          getTableRowAuthByMenuIdRule();
          GetTableRowAuthConfig();
          getRowAuthConfigByMenuIdMsg();
        } else {
          layer.confirm(msg, { icon: 2, title: "错误消息" });
        }
      });
    };

    //新增/编辑行权限界面
    const addOrEditMenuRowRole = function (isAdd: boolean) {
      openPageData.menuId = menuId.value;
      if (isAdd) {
        openPageData.ruleJson = [
          {
            id: "1",
            pid: "0",
            matchGroup: "And",
            level: 1,
            matchingWhere: [],
            children: [],
          },
        ];
      }

      layer.drawer({
        title: "权限规则",
        area: ["55%", "100%"],
        content: h(configureRules, {
          openPageData,
          onCloseBnt(res: any) {
            getTableRowAuthByMenuIdRule();
            getRowAuthConfigByMenuIdMsg();
            GetTableRowAuthConfig();
            layer.closeAll();
          },
        }),
      });
    };

    //新增基础配置
    const addBaseConfig = function (row: any) {
      openPageData.configId = 0;
      openPageData.PermissionsField = "";
      openPageData.ConditionalEquationValue = [];
      openPageData.ShowControl = "";
      openPageData.ShowControlDataSource = "";
      addOrEditBaseConfig(true);
    };

    //编辑基础配置
    const editBaseConfig = function (row: any) {
      openPageData.configId = row.id;
      openPageData.PermissionsField = row.value;
      openPageData.ConditionalEquationValue = row.conditionalEquationList.map(
        (f: { value: any }) => f.value
      );
      openPageData.ShowControl = row.showControlName;
      openPageData.ShowControlDataSource = row.showControlDataSourceName;
      addOrEditBaseConfig(false);
    };

    //新增编辑基础配置
    const addOrEditBaseConfig = function (isAdd: boolean) {
      openPageData.dataSourceConfig = dataSourceConfig.value;
      layer.drawer({
        title: "基础配置",
        area: ["55%", "100%"],
        content: h(baseConfigure, {
          openPageData,
          onCloseBnt(res: any) {
            getTableRowAuthByMenuIdRule();
            getRowAuthConfigByMenuIdMsg();
            GetTableRowAuthConfig();
            layer.closeAll();
          },
        }),
      });
    };

    //获取数据行权限配置
    const GetTableRowAuthConfig = () => {
      configList.value = [];
      if (menuId.value > 0) {
        GetTableRowAuthConfigByMenuId({ menuId: menuId.value }).then(
          ({ data, code, msg }) => {
            if (code == 200) {
              configList.value = data;
            } else {
              layer.confirm(msg, { icon: 2, title: "错误消息" });
            }
          }
        );
      }
    };

    //设置启用状态
    const changeStatus = (isChecked: boolean, id: number) => {
      SetRuleIsOpenById({
        id: id,
        menuId: menuId.value,
        isOpen: isChecked,
      }).then(({ code, msg }) => {
        if (code == 200) {
          getTableRowAuthByMenuIdRule();
          GetTableRowAuthConfig();
          getRowAuthConfigByMenuIdMsg();
        } else {
          layer.confirm(msg, { icon: 2, title: "错误消息" });
        }
      });
    };
    return {
      tree,
      checkedKeys2,
      handleClick,
      menuColumns,
      menuColumnsConfig,
      addRule,
      dataSource,
      editRule,
      deleteRule,
      deleteRuleConfig,
      selectedValue,
      change,
      addBaseConfig,
      editBaseConfig,
      configList,
      changeStatus,
    };
  },
  components: {
    configureRules,
    baseConfigure,
  },
});
</script>

<style>
.example .layui-footer,
.example .layui-header {
  line-height: 60px;
  text-align: center;
  background: #87ca9a;
  color: white;
}
.layuiSideCalss {
  /* display: flex; */
  margin: 10px 10px;
  background: white;
  /* align-items: center;
  justify-content: center; */
  color: white;
  width: 20% !important;
  flex: 0 0 20% !important;
}

.example .layui-body {
  display: block !important;
  background: white;
  /* align-items: center;
  justify-content: center; */
  color: white;
}
</style>