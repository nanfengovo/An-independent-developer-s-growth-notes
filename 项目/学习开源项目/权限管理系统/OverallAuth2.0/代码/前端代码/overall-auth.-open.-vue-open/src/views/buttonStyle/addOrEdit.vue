<template>
  <lay-form :model="openPageData" ref="layFormRef4" :rules="rules5">
    <lay-form-item label="按钮样式名称" prop="ButtonStyleName" required>
      <lay-input v-model="openPageData.ButtonStyleName"></lay-input>
    </lay-form-item>
    <lay-form-item label="边框样式" prop="BordersStyle">
      <lay-select v-model="openPageData.BordersStyle" style="width: 100%">
        <lay-select-option
          v-for="item in bordersStyleList"
          :key="item.key"
          :value="item.key"
          :label="item.value"
        ></lay-select-option>
      </lay-select>
    </lay-form-item>
    <lay-form-item label="边框颜色" prop="Borders">
      <lay-select v-model="openPageData.Borders" style="width: 100%">
        <lay-select-option
          v-for="item in bordersList"
          :key="item"
          :value="item.key"
          :label="item.value"
        ></lay-select-option>
      </lay-select>
    </lay-form-item>
    <lay-form-item label="按钮大小" prop="Size">
      <lay-select v-model="openPageData.Size" style="width: 100%">
        <lay-select-option
          v-for="item in sizeList"
          :key="item"
          :value="item.key"
          :label="item.value"
        ></lay-select-option>
      </lay-select>
    </lay-form-item>
    <lay-form-item label="按钮样式" prop="Types">
      <lay-select v-model="openPageData.Types" style="width: 100%">
        <lay-select-option
          v-for="item in typesList"
          :key="item"
          :value="item.key"
          :label="item.value"
        ></lay-select-option>
      </lay-select>
    </lay-form-item>
    <lay-form-item label="图标" prop="Icon">
      <lay-input
        v-model="openPageData.Icon"
        placeholder="layui 官网查找"
      ></lay-input>
    </lay-form-item>
    <lay-form-item label="是否圆角" prop="Radius">
      <lay-radio
        v-model="openPageData.Radius"
        name="action"
        :value="1"
        label="是"
      ></lay-radio>
      <lay-radio
        v-model="openPageData.Radius"
        name="action"
        :value="2"
        label="否"
      ></lay-radio>
    </lay-form-item>
    <lay-form-item label="按钮样式预览">
      <lay-button
        :type="openPageData.Types"
        :size="openPageData.Size"
        :border="openPageData.Borders"
        :border-style="openPageData.BordersStyle"
        :radius="openPageData?.Radius == 2 ? false : true"
        :prefix-icon="openPageData.Icon"
      >
        {{
          openPageData.ButtonStyleName == ""
            ? "默认按钮"
            : openPageData.ButtonStyleName
        }}
      </lay-button>
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
  addButtonStyleMsg,
  updateButtonStyleMsg,
} from "../../api/button/index";
import {
  buttonStyleModel,
  bordersStyleList,
  sizeList,
  typesList,
  bordersList,
} from "../../model/buttonStyle";

export default defineComponent({
  props: {
    openPageData: {
      type: Object as PropType<buttonStyleModel | null>,
      required: true,
    },
  },

  setup(props, context) {
    let IsRadius = ref<boolean | undefined>();
    IsRadius.value = props.openPageData?.Radius == 1 ? false : true;

    //关闭按钮
    const closeBnt = () => {
      context.emit("closeBnt", "返回参数");
    };
    //初始化数据
    onMounted(() => {});

    //加入验证
    const layFormRef4 = ref();

    //提交信息
    const submit1 = () => {
      layFormRef4.value.validate(
        (isValidate: any, model: buttonStyleModel, errors: any) => {
          if (isValidate) {
            model.IsRadius = model.Radius == 2 ? false : true;
            if (model.ButtonStyleId > 0) {
              updateButtonStyleMsg(model).then(({ code, msg }) => {
                if (code == 200) {
                  layer.msg(msg, { icon: 1 });
                  closeBnt();
                } else {
                  layer.confirm(msg, { icon: 2, title: "错误消息" });
                }
              });
            } else {
              addButtonStyleMsg(model).then(({ code, msg }) => {
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
      bordersStyleList,
      sizeList,
      typesList,
      bordersList,
      IsRadius,
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