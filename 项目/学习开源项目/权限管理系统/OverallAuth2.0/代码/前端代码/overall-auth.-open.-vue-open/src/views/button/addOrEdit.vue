<template>
  <lay-form :model="openPageData" ref="layFormRef4" :rules="rules5" >
    <lay-form-item label="按钮名称" prop="ButtonName" required>
      <lay-input v-model="openPageData.ButtonName" :maxlength = "10"></lay-input>
    </lay-form-item>
    <lay-form-item label="按钮Key" prop="ButtonKey" required>
      <lay-input v-model="openPageData.ButtonKey"></lay-input>
    </lay-form-item>
    <lay-form-item
      label="按钮样式"
      style="width: 46%; float: left"
      prop="ButtonStyleId"
      required
    >
      <lay-select v-model="openPageData.ButtonStyleId" :show-search="true" @change="selectClick">
        <lay-select-option
          v-for="item in parentButtonStyle"
          :key="item.buttonStyleId"
          :value="item.buttonStyleId"
          :label="item.buttonStyleName"
        ></lay-select-option>
      </lay-select>
    </lay-form-item>
    <lay-form-item label="预览" prop="" mode="inline">
      <lay-button
        :type="openPageData.Types"
        :size="openPageData.Size"
        :border="openPageData.Borders"
        :border-style="openPageData.BordersStyle"
        :radius="openPageData?.IsRadius"
        :prefix-icon="openPageData.Icon"
      >
        {{
          openPageData.ButtonName == "" ? "默认按钮" : openPageData.ButtonName
        }}
      </lay-button>
    </lay-form-item>
    <lay-form-item label="所属菜单" prop="MenuId" required>
      <lay-tree-select
        style="width: 100%"
        v-model="openPageData.MenuId"
        :data="parentMenu"
        :size="2"
      ></lay-tree-select>
    </lay-form-item>
    <lay-form-item label="排序" prop="OrderBy">
      <lay-input-number
        v-model="openPageData.OrderBy"
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
  addButtonMsg,
  updateButtonMsg,
} from "../../api/button/index";
import {
  buttonStyleModel,
  bordersStyleList,
  sizeList,
  typesList,
  bordersList,
  buttonModel,
} from "../../model/buttonStyle";

export default defineComponent({
  props: {
    openPageData: {
      type: Object as PropType<buttonModel>,
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
      props.openPageData.Borders = model[0]["borders"];
      props.openPageData.Types = model[0]["types"];
      props.openPageData.BordersStyle = model[0]["bordersStyle"];
      props.openPageData.ButtonStyleId = model[0]["buttonStyleId"];
      props.openPageData.ButtonStyleName = model[0]["buttonStyleName"];
      props.openPageData.Icon = model[0]["icon"];
      props.openPageData.IsRadius = model[0]["isRadius"];
      props.openPageData.Radius = model[0]["radius"];
      props.openPageData.Size = model[0]["size"];
    };

    //加入验证
    const layFormRef4 = ref();

    //提交信息
    const submit1 = () => {
      layFormRef4.value.validate(
        (isValidate: any, model: buttonModel, errors: any) => {
          if (isValidate) {
            //model.IsRadius = model.Radius == 2 ? false : true;
            if (model.ButtonId > 0) {
              updateButtonMsg(model).then(({ code, msg }) => {
                if (code == 200) {
                  layer.msg(msg, { icon: 1 });
                  closeBnt();
                } else {
                  layer.confirm(msg, { icon: 2, title: "错误消息" });
                }
              });
            } else {
              addButtonMsg(model).then(({ code, msg }) => {
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