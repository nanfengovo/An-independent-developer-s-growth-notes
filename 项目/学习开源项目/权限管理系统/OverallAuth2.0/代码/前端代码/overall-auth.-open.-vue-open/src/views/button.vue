<template>
  <lay-button
    v-for="item in parentButton"
    :key="item.buttonKey"
    :type="item.types"
    :size="item.size"
    :border="item.borders"
    :border-style="item.bordersStyle"
    :radius="item?.isRadius"
    :prefix-icon="item.icon"
    @click="openPage(item.buttonKey)"
  >
    {{ item.buttonName == "" ? "默认按钮" : item.buttonName }}
  </lay-button>
</template>
<script lang="ts">
import {
  ref,
  reactive,
  onMounted,
  defineComponent,
  PropType,
  registerRuntimeCompiler,
} from "vue";
import { layer } from "@layui/layer-vue";
import { getButtonByMenuId } from "../api/button/index";
import { useRouter } from "vue-router";
import store from "../store";
import { GetParamUrl } from "../api/publicTool";
import { LayuiSelectRowAuthExtend } from "../model/match";
export default defineComponent({
  props: {
    model: {
      type: Object as PropType<LayuiSelectRowAuthExtend[]>,
      required: true,
    },
  },
  setup(props, context) {
    const router = useRouter();
    const parentButton = ref({});
    //初始化数据
    onMounted(() => {
      getButtonByMenuMsg();
    });

    //获取按钮样式
    const getButtonByMenuMsg = async () => {
      var mneuId = GetParamUrl("MneuId");
      getButtonByMenuId({ menuId: parseInt(mneuId) }).then(
        ({ data, code, msg }) => {
          if (code == 200) {
            parentButton.value = data;
          } else {
            layer.confirm(msg, { icon: 2, title: "错误消息" });
          }
        }
      );
    };

    const openPage = function (row:string) {
      context.emit(row, props.model);
    };
    return {
      openPage,
      parentButton,
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