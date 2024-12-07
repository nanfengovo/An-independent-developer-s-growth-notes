<template>
  <lay-layout class="example">
    <lay-side>
      <lay-header>菜单权限</lay-header>
      <!-- <div style="height: 9%">
        <div class="topMenu"></div>
      </div> -->
      <div style="height: 85%; margin-top: 5px; overflow: auto">
        <lay-tree
          :data="tree"
          :tail-node-icon="false"
          v-model:selectedKey="checkedKeys2"
          :onlyIconControl="true"
          @node-click="handleClick"
        >
        </lay-tree>
      </div>
    </lay-side>
    <lay-layout>
      <lay-header>列权限</lay-header>
      <lay-body>
        <div style="height: 100%">
          <lay-table
            :height="'100%'"
            :columns="menuColumns"
            :data-source="dataSource"
            v-model:selected-keys="selectedColsKeys"
            even
          >
            <!--超级管理员-->
            <template v-slot:toolbar>
              <lay-button
                :disabled="menuId != 5 ? false : true"
                size="sm"
                border="blue"
                border-style="dashed"
                prefix-icon="layui-icon-set"
                @click="addMenuColsRole"
                >保存权限列设置</lay-button
              >
            </template>
          </lay-table>
        </div>
      </lay-body>
      <lay-footer> </lay-footer>
    </lay-layout>
  </lay-layout>
</template>

<script lang="ts">
import { layer } from "@layui/layui-vue";
import {
  OriginalTreeData,
  StringOrNumber,
} from "@layui/layui-vue/types/component/tree/tree.type";
import { ref, onMounted, defineComponent, PropType, Ref } from "vue";
import { getMenuByRoleId } from "../../api/authority/index";
import {
  insertMenuColsRoleMsg,
  getMenuHaveTableCols,
} from "../../api/authority/tableCols/index";
import { buttonModel } from "../../model/buttonStyle";
export default defineComponent({
  props: {
    openPageData: {
      type: Object,
      required: true,
    },
  },

  setup(props, context) {
    const dataSource = ref([{}]);
    const model = ref({ ...props.openPageData });
    const tree = ref();
    const menuId = ref();

    //初始化数据
    onMounted(() => {
      menuId.value = 5;
      getMenuCols(5);
      getRoleMenus();
    });
    const checkedKeys2 = ref<StringOrNumber>(5);
    const showCheckbox2 = ref(true);
    const selectedColsKeys = ref<string[]>();
    const menuColumns = ref([
      { title: "选项", width: "55px", type: "checkbox", fixed: "left" },
      {
        title: "编号",
        width: "80px",
        key: "id",
      },
      {
        title: "所属菜单",
        width: "200px",
        key: "menuTitle",
      },
      {
        title: "字段名称",
        width: "180px",
        key: "fieldName",
      },
      {
        title: "字段标题",
        width: "250px",
        key: "fieldTitle",
      },
      {
        title: "自定义插槽",
        width: "100px",
        key: "fieldCustomSlot",
      },
    ]);

    //获取菜单列
    const getMenuCols = async (menuId: StringOrNumber) => {
      selectedColsKeys.value = [];
      getMenuHaveTableCols({ menuId: menuId, roleId: model.value.roleId }).then(
        ({ data, code, msg }) => {
          if (code == 200) {
            dataSource.value = data[0].sysMenuTableColsData;
            data[0].selectedKeys.forEach((element: string) =>
              selectedColsKeys.value?.push(element)
            );
            //selectedColsKeys.value = data[0].selectedKeys;
          } else {
            layer.confirm(msg, { icon: 2, title: "错误消息" });
          }
        }
      );
    };

    //关闭按钮
    const closeBnt = () => {
      context.emit("closeBnt", "返回参数");
    };

    //获取角色菜单
    const getRoleMenus = async () => {
      getMenuByRoleId({ roleId: model.value.roleId,isDisabledGroup:false,isDisabledItem:false }).then(
        ({ data, code, msg }) => {
          if (code == 200) {
            tree.value = data[0].treeItems;
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
      getMenuCols(node.id);
    }

    //添加菜单按钮权限
    const addMenuColsRole = function () {
      var selectKeys = selectedColsKeys.value;
      var roleId = model.value.roleId;
      insertMenuColsRoleMsg({
        roleId: roleId,
        menuTableColsIds: selectKeys,
        menuId: menuId.value,
      }).then(({ data, code, msg }) => {
        if (code == 200) {
          layer.msg("菜单按钮权限设置成功", { icon: 1 });
          //closeBnt();
        } else {
          layer.confirm(msg, { icon: 2, title: "错误消息" });
        }
      });
    };
    return {
      dataSource,
      menuColumns,
      selectedColsKeys,
      showCheckbox2,
      checkedKeys2,
      closeBnt,
      handleClick,
      tree,
      addMenuColsRole,
      menuId,
    };
  },
  components: {},
});
</script>
<style>
.slot-fragment {
  height: 100%;
}
.example .layui-footer,
.example .layui-header {
  line-height: 60px;
  text-align: center;
  background: white;
  color: black;
}
.example .layui-side {
  /* display: flex; */
  background: white;
  align-items: center;
  justify-content: center;
  color: black;
  flex: 0 0 260px !important;
  width: 260px !important;
}
.example .layui-body {
  display: flex;
  background: white;
  align-items: center;
  justify-content: center;
  color: black;
}
.topMenu {
  height: 100%;
  color: black;
  flex: 10px 0 20px;
  display: flex;
  justify-content: center;
  align-items: center;
  border-bottom: 1px solid #ccc;
}
</style>