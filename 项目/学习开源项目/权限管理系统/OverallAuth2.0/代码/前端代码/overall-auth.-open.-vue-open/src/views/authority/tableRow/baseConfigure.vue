<template>
  <lay-form :model="openPageData" ref="layFormRef4" :rules="rules5" required>
    <lay-form-item label="字段" prop="PermissionsField">
      <lay-select v-model="openPageData.PermissionsField" style="width: 100%">
        <lay-select-option
          v-for="item in openPageData.dataSourceConfig[0].permissionsFieldList"
          :key="item.value"
          :value="item.value"
          :label="item.label"
        ></lay-select-option>
      </lay-select>
    </lay-form-item>
    <lay-form-item label="条件" prop="ConditionalEquationValue">
      <lay-select
        v-model="openPageData.ConditionalEquationValue"
        multiple
        style="width: 100%"
        minCollapsedNum="8"
      >
        <lay-select-option
          v-for="item in openPageData.dataSourceConfig[0]
            .conditionalEquationValueList"
          :key="item.value"
          :value="item.value"
          :label="item.label"
        ></lay-select-option>
      </lay-select>
    </lay-form-item>
    <lay-form-item label="结果控件风格" prop="ShowControl">
      <lay-select v-model="openPageData.ShowControl" style="width: 100%">
        <lay-select-option
          v-for="item in openPageData.dataSourceConfig[0].showControlList"
          :key="item.value"
          :value="item.value"
          :label="item.label"
        ></lay-select-option>
      </lay-select>
    </lay-form-item>
    <lay-form-item label="结果控件数据" prop="ShowControlDataSource">
      <lay-select
        v-model="openPageData.ShowControlDataSource"
        style="width: 100%"
      >
        <lay-select-option
          v-for="item in openPageData.dataSourceConfig[0]
            .showControlDataSourceList"
          :key="item.value"
          :value="item.value"
          :label="item.label"
        ></lay-select-option>
      </lay-select>
    </lay-form-item>
    <lay-form-item style="text-align: center">
      <lay-button type="primary" @click="submit1">保存</lay-button>
      <lay-button @click="closeBnt">关闭</lay-button>
    </lay-form-item>
  </lay-form>
</template>
<script  lang="ts" >
import { ref, reactive, onMounted, defineComponent, PropType } from "vue";
import { layer } from "@layui/layer-vue";
import {
  GetTableRowAuthByMenuId,
  GetRowAuthConfigByMenuId,
  saveRuleConfig,
} from "../../../api/authority/tableRow/index";
import { GetTableRowAuthConfigByMenuId } from "../../../api/authority/tableRow";
import { LayuiSelectRowAuthExtend } from "../../../model/match";

export default defineComponent({
  props: {
    openPageData: {
      type: Object as PropType<any | null>,
      required: true,
    },
  },

  setup(props, context) {
    const menuId = props.openPageData.menuId;
    const dataSource = ref<any>();
    //关闭按钮
    const closeBnt = () => {
      context.emit("closeBnt", "返回参数");
    };
    //初始化数据
    onMounted(() => {
      getRowAuthConfigByMenuIdMsg();
    });
    //获取菜单数据权限配置
    const getRowAuthConfigByMenuIdMsg = async () => {
      GetRowAuthConfigByMenuId({ menuId: menuId.value }).then(
        ({ data, code, msg }) => {
          if (code == 200) {
            dataSource.value = data;
          } else {
            layer.confirm(msg, { icon: 2, title: "错误消息" });
          }
        }
      );
    };

    //加入验证
    const layFormRef4 = ref();
    const submit1 = () => {
      layFormRef4.value.validate((isValidate: any, model: any, errors: any) => {
        if (isValidate) {
          model.PermissionsFieldName =
            props.openPageData.dataSourceConfig[0].permissionsFieldList.filter(
              (f: { value: any }) => f.value == model.PermissionsField
            )[0].label;
          saveRuleConfig(model).then(({ code, msg }) => {
            if (code == 200) {
              layer.msg(msg, { icon: 1 });
              closeBnt();
            } else {
              layer.confirm(msg, { icon: 2, title: "错误消息" });
            }
          });
        }
      });
    };
    return {
      layFormRef4,
      closeBnt,
      dataSource,
      submit1,
    };
  },
  components: {},
});
</script>

<style scoped>
form {
  padding: 10px;
}
</style>