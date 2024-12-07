<template>
  <lay-form :model="model" ref="layFormRef4">
    <lay-form-item label="所属角色" prop="roleId">
      <lay-select
        v-model="model.roleId"
        :show-search="true"
        :multiple="true"
        style="width: 100%"
        :minCollapsedNum="6"
      >
        <!--超级管理员-->
        <lay-select-option
          v-for="item in roleList"
          :key="item"
          :value="item.roleId"
          :label="item.roleName"
          :disabled="item.roleId == 1 ? true : false"
        ></lay-select-option>
      </lay-select>
    </lay-form-item>
    <lay-form-item style="text-align: center">
      <lay-button type="primary" @click="submit1">保存</lay-button>
      <lay-button @click="closeBnt">关闭</lay-button>
    </lay-form-item>
  </lay-form>
</template>
<script setup>
import { ref, reactive, onMounted, nextTick } from "vue";
import { layer } from "@layui/layer-vue";
import { getAll } from "../../api/authority/index";
import { setUserRole } from "../../api/user/index";

//初始化数据
onMounted(() => {
  nextTick(() => {
    getAllList();
  });
});

//加入验证
const layFormRef4 = ref();
const roleList = ref({});
//自定义按钮
const emit = defineEmits(["closeBnt"]);

//参数接收
const props = defineProps({
  setRoleData: { userId: 0, userName: "", roleId: [] },
});
const model = ref({ ...props.setRoleData });

//提交信息
const submit1 = () => {
  layFormRef4.value.validate((isValidate, model, errors) => {
    if (isValidate) {
      if (model.roleId.length != 0) {
        setUserRole(model).then(({ code, msg }) => {
          if (code == 200) {
            layer.msg(msg, { icon: 1 });
            closeBnt();
          } else {
            layer.confirm(msg, { icon: 2, title: "错误消息" });
          }
        });
      } else layer.confirm("没有选择任何角色", { icon: 2, title: "提示消息" });
    }
  });
};
//获取所有角色
const getAllList = async () => {
  await getAll().then(({ data, code, msg }) => {
    if (code == 200) {
      roleList.value = data;
    } else {
      layer.confirm(msg, { icon: 2, title: "错误消息" });
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
.layui-select {
  cursor: pointer;
}
</style>