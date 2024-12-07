<template>
  <lay-form :model="model" ref="layFormRef4" :rules="rules5" required>
    <lay-form-item label="角色名称" prop="roleName">
      <lay-input v-model="model.roleName"></lay-input>
    </lay-form-item>
    
    <lay-form-item style="text-align: center">
      <lay-button type="primary" @click="submit1">新增角色</lay-button>
      <lay-button @click="closeBnt">关闭</lay-button>
    </lay-form-item>
  </lay-form>
</template>
<script setup>
import { ref, reactive ,onMounted} from "vue";
import { layer } from "@layui/layer-vue";
import { addRoleMsg } from "../../api/authority/index";

//初始化数据
onMounted(() => {
    
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
      addRoleMsg(model).then(({ code, msg }) => {
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