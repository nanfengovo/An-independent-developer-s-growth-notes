<template>
  <lay-form :model="openPageData" ref="layFormRef4" :rules="rules5">
    <lay-form-item label="字段名称" prop="FieldName" required>
      <lay-input :disabled="openPageData.IsSystemData == 1?true:false" v-model="openPageData.FieldName" :maxlength="20"></lay-input>
    </lay-form-item>
    <lay-form-item label="字段类型" prop="FieldType" required>
      <lay-input :disabled="openPageData.IsSystemData == 1?true:false" v-model="openPageData.FieldType"></lay-input>
    </lay-form-item>
    <lay-form-item label="所属菜单" prop="MenuId" required>
      <lay-tree-select
      :disabled="openPageData.IsSystemData == 1?true:false"
        style="width: 100%"
        v-model="openPageData.MenuId"
        :data="parentMenu"
        :size="2"
      ></lay-tree-select>
    </lay-form-item>
    <lay-form-item label="字段标题" prop="FieldTitle" required>
      <lay-input v-model="openPageData.FieldTitle" :maxlength="20"></lay-input>
    </lay-form-item>
    <lay-form-item label="字段宽度" prop="FieldWidth" required>
      <lay-input-number
        v-model="openPageData.FieldWidth"
        :min="0"
        :max="1000"
      ></lay-input-number>
    </lay-form-item>

    <lay-form-item label="字段插槽" prop="FieldCustomSlot">
      <lay-input
        v-model="openPageData.FieldCustomSlot"
        :maxlength="20"
      ></lay-input>
    </lay-form-item>
    <lay-form-item label="排序方式" prop="FieldSort">
      <lay-select v-model="openPageData.FieldSort" style="width: 100%">
        <lay-select-option
          v-for="item in fieldSortList"
          :key="item"
          :value="item.key"
          :label="item.value"
        ></lay-select-option>
      </lay-select>
    </lay-form-item>
    <lay-form-item label="对齐方式" prop="FieldAlign">
      <lay-select v-model="openPageData.FieldAlign" style="width: 100%">
        <lay-select-option
          v-for="item in fieldAlignList"
          :key="item"
          :value="item.key"
          :label="item.value"
        ></lay-select-option>
      </lay-select>
    </lay-form-item>
    <lay-form-item label="字段固定" prop="FieldFixed">
      <lay-select v-model="openPageData.FieldFixed" style="width: 100%">
        <lay-select-option
          v-for="item in fieldFixedList"
          :key="item"
          :value="item.key"
          :label="item.value"
        ></lay-select-option>
      </lay-select>
    </lay-form-item>
    <!-- <lay-form-item label="显示tips" prop="FieldEllipsisTooltips">
      <lay-radio
        v-model="openPageData.FieldEllipsisTooltips"
        name="action"
        :value="1"
        label="是"
      ></lay-radio>
      <lay-radio
        v-model="openPageData.FieldEllipsisTooltips"
        name="action"
        :value="0"
        label="否"
      ></lay-radio>
    </lay-form-item> -->
    <lay-form-item label="行权限字段" prop="DataRowAuthType">
      <lay-radio
        v-model="openPageData.DataRowAuthType"
        name="action"
        :value="1"
        label="是"
      ></lay-radio>
      <lay-radio
        v-model="openPageData.DataRowAuthType"
        name="action"
        :value="2"
        label="否"
      ></lay-radio>
    </lay-form-item>
    <lay-form-item label="行权限字段" prop="DataRowAuthField" v-if="openPageData.DataRowAuthType==1" required>
      <lay-input v-model="openPageData.DataRowAuthField"></lay-input>
    </lay-form-item>
    <lay-form-item label="行权限字段名" prop="DataRowAuthFieldName" v-if="openPageData.DataRowAuthType==1" required>
      <lay-input v-model="openPageData.DataRowAuthFieldName"></lay-input>
    </lay-form-item>
    <!-- <lay-form-item label="最小宽度" prop="FieldMinWidth">
      <lay-input-number
        v-model="openPageData.FieldMinWidth"
        :min="0"
        :max="500"
      ></lay-input-number>
    </lay-form-item> -->
    <lay-form-item label="排序" prop="OrderBy">
      <lay-input-number
        v-model="openPageData.FieldOrderBy"
        :min="0"
        :max="100"
      ></lay-input-number>
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
  getMenuSelectTree,
  getAllButtonStyle,
} from "../../../api/button/index";
import {
  addMenuTableColsMsg,
  updateMenuTableColsMsg,
} from "../../../api/authority/tableCols/index";

import {
  fieldSortList,
  menuTableColsModel,
  fieldAlignList,
  fieldFixedList,
} from "../../../model/menuTableCols";

export default defineComponent({
  props: {
    openPageData: {
      type: Object as PropType<menuTableColsModel>,
      required: true,
    },
  },

  setup(props, context) {
    let IsRadius = ref<boolean | undefined>();

    //关闭按钮
    const closeBnt = () => {
      context.emit("closeBnt", "返回参数");
    };

    //菜单
    const parentMenu = ref({});
    //按钮样式
    const parentButtonStyle = ref([]);

    //初始化数据
    onMounted(() => {
      getMenuSelectTreeMsg();
      getAllButtonStyleMsg();
    });

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
    //获取按钮样式
    const getAllButtonStyleMsg = async () => {
      getAllButtonStyle().then(({ data, code, msg }) => {
        if (code == 200) {
          parentButtonStyle.value = data;
        } else {
          layer.confirm(msg, { icon: 2, title: "错误消息" });
        }
      });
    };

    //按钮样式选择事件
    const selectClick = (value: number) => {
      var model = parentButtonStyle.value.filter(
        (item: any) => item.buttonStyleId == value
      );
    };

    //加入验证
    const layFormRef4 = ref();

    //提交信息
    const submit1 = () => {
      layFormRef4.value.validate(
        (isValidate: any, model: menuTableColsModel, errors: any) => {
          if (isValidate) {
            model.FieldEllipsisTooltip =
              model.FieldEllipsisTooltips == 0 ? false : true;
            if (model.Id > 0) {
              updateMenuTableColsMsg(model).then(({ code, msg }) => {
                if (code == 200) {
                  layer.msg(msg, { icon: 1 });
                  closeBnt();
                } else {
                  layer.confirm(msg, { icon: 2, title: "错误消息" });
                }
              });
            } else {
              addMenuTableColsMsg(model).then(({ code, msg }) => {
                if (code == 200) {
                  layer.msg(msg, { icon: 1 });
                  closeBnt();
                } else {
                  layer.confirm(msg, { icon: 2, title: "错误消息" });
                }
              });
            }
          }
        }
      );
    };
    return {
      submit1,
      layFormRef4,
      closeBnt,
      fieldSortList,
      fieldAlignList,
      fieldFixedList,
      IsRadius,
      parentMenu,
      parentButtonStyle,
      selectClick,
    };
  },
  components: {},
});
</script>

<style>
form {
  padding: 10px;
}
</style>