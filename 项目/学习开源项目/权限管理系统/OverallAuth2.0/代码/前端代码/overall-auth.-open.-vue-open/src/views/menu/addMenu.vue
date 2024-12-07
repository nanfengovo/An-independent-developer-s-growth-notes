<template>
  <lay-form :model="model" ref="layFormRef4" :rules="rules5" required>
    <lay-form-item label="菜单名称" prop="menuTitle">
      <lay-input v-model="model.menuTitle"></lay-input>
    </lay-form-item>
    <lay-form-item label="上级菜单">
      <lay-select v-model="model.pid">
        <lay-select-option
          v-for="item in parentMenu"
          :key="item"
          :value="item.id"
          :label="item.menuTitle"
        ></lay-select-option>
      </lay-select>
    </lay-form-item>
    <lay-form-item label="菜单目录" prop="menuUrl">
      <lay-input v-model="model.menuUrl"></lay-input>
    </lay-form-item>
    <lay-form-item label="菜单路径" prop="component">
      <lay-input v-model="model.component"></lay-input>
    </lay-form-item>
    <lay-form-item label="菜单图标" prop="menuIcon">
      <lay-input v-model="model.menuIcon"></lay-input>
    </lay-form-item>
    <lay-form-item label="是否开启" prop="isOpen" mode="inline">
      <lay-switch v-model="model.isOpen"></lay-switch>
    </lay-form-item>
    <lay-form-item style="text-align: center">
      <lay-button type="primary" @click="submit1">保存</lay-button>
      <lay-button @click="reset4">重置表单</lay-button>
      <lay-button @click="closeBnt">关闭</lay-button>
    </lay-form-item>
  </lay-form>
</template>
<script setup>
import { ref, reactive, onMounted } from "vue";
import { layer } from "@layui/layer-vue";
import {
  addMenuMsg,
  getParentMenusList,
  updateMenuMsg,
} from "../../api/menu/menu";

//初始化数据
onMounted(() => {
  getParentMenus();
});

//加入验证
const layFormRef4 = ref();
const parentMenu = ref({});

//自定义按钮
const emit = defineEmits(["closeBnt"]);

//参数接收
const props = defineProps({
  openPageData: Object,
});
const model = ref({ ...props.openPageData });

//提交信息
const submit1 = () => {
  layFormRef4.value.validate((isValidate, model, errors) => {
    if (isValidate) {
      if (model.id > 0) {
        updateMenuMsg(model).then(({ code, msg }) => {
          if (code == 200) {
            layer.msg(msg, { icon: 1 });
            closeBnt();
          } else {
            layer.confirm(msg, { icon: 2, title: "错误消息" });
          }
        });
      } else {
        addMenuMsg(model).then(({ code, msg }) => {
          if (code == 200) {
            layer.msg(msg, { icon: 1 });
            closeBnt();
          } else {
            layer.confirm(msg, { icon: 2, title: "错误消息" });
          }
        });
      }
    }
  });

  //layer.load(0, { time: 3000, content: "请稍后..." });
  // layer.msg(`${JSON.stringify(model)}`, { time: 2000 });
};

//获取父级菜单
const getParentMenus = async () => {
  getParentMenusList().then(({ data, code, msg }) => {
    if (code == 200) {
      parentMenu.value = data;
    } else {
      layer.confirm(msg, { icon: 2, title: "错误消息" });
    }
  });
};

//重置信息
const reset4 = () => {
  layFormRef4.value.reset();
};

//关闭按钮
const closeBnt = () => {
  emit("closeBnt", "返回参数");
};
</script>

<style scoped>
form {
  padding: 10px;
}
</style>