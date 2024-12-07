<template>
  <lay-form :model="model" ref="layFormRef4" :rules="rules5" required>
    <lay-form-item label="用户名称" prop="userName">
      <lay-input v-model="model.userName"></lay-input>
    </lay-form-item>
    <lay-form-item label="用户密码" prop="password">
      <lay-input v-model="model.password" type="password" password></lay-input>
    </lay-form-item>
    <!-- <lay-form-item label="所属角色" prop="roleId">
      <lay-select v-model="model.roleId" :show-search="true" :multiple="true" style="width:100%" :minCollapsedNum="6">
        <lay-select-option
          v-for="item in roleList"
          :key="item"
          :value="item.roleId"
          :label="item.roleName"
        ></lay-select-option>
      </lay-select>
    </lay-form-item> -->
    <lay-form-item label="年龄" prop="age">
      <lay-input
        v-model="model.age"
        type="number"
        :max="120"
        :min="18"
      ></lay-input>
    </lay-form-item>
    <lay-form-item label="性别" prop="sex">
      <lay-radio
        v-model="model.sex"
        name="action"
        :value="1"
        label="男"
      ></lay-radio>
      <lay-radio
        v-model="model.sex"
        name="action"
        :value="2"
        label="女"
      ></lay-radio>
    </lay-form-item>

    <lay-form-item style="text-align: center">
      <lay-button type="primary"  @click="submit1">保存</lay-button>
      <lay-button @click="closeBnt">关闭</lay-button>
    </lay-form-item>
  </lay-form>
</template>
<script setup>
import { ref, reactive, onMounted } from "vue";
import { layer } from "@layui/layer-vue";
import { getAll } from "../../api/authority/index";
import { addMenuMsg,updateUserMsg } from "../../api/user/index";

//初始化数据
onMounted(() => {
  //getAllList();
});

//加入验证
const layFormRef4 = ref();
const roleList = ref({});
//自定义按钮
const emit = defineEmits(["closeBnt"]);

//参数接收
const props = defineProps({
  openPageData: { userId: 0, userName: "", sex: 1, password: "", age: "" },
});
const model = ref({ ...props.openPageData });

//提交信息
const submit1 = () => {
  layFormRef4.value.validate((isValidate, model, errors) => {
    if (isValidate) {
      if (model.userId > 0) {
        updateUserMsg(model).then(({ code, msg }) => {
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
};
//获取父级菜单
// const getAllList = async () => {
//   getAll().then(({ data, code, msg }) => {
//     if (code == 200) {
//       roleList.value = data;
//     } else {
//       layer.confirm(msg, { icon: 2, title: "错误消息" });
//     }
//   });
// };

//关闭按钮
const closeBnt = () => {
  emit("closeBnt", "返回参数");
};
</script>

<style scoped>
form {
  padding: 10px;
}
.layui-select {
  cursor: pointer;
}
</style>