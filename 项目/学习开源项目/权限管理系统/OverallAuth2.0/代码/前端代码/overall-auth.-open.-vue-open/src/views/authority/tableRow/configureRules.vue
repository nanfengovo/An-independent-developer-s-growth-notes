<template>
  <div style="height: 100%">
    <div>
      <matchRules
        @Key1="PreviewRule"
        @Key2="SaveRule"
        :menuId="menuId"
        :ruleJson="ruleJson"
        :isOpen="isOpen"
        :ruleRemark="ruleRemark"
      ></matchRules>
    </div>
  </div>
</template>

<script lang="ts">
import { reactive, defineComponent, PropType } from "vue";
import { saveRule } from "../../../api/authority/tableRow/index";
import matchRules from "../../match/index.vue";
import { layer } from "@layui/layui-vue";
import { matchingData } from "../../../api/publicTool";

export default defineComponent({
  props: {
    openPageData: {
      type: Object as PropType<any>,
      required: true,
    },
  },

  setup(props, context) {
    const menuId = props.openPageData.menuId;
    const ruleJson = props.openPageData.ruleJson;
    const rowAuthId = props.openPageData.rowAuthId;
    const ruleRemark = props.openPageData.remark;
    const isOpen = props.openPageData.isOpen;
    //关闭按钮
    const closeBnt = () => {
      context.emit("closeBnt", "返回参数");
    };

    //预览规则
    function PreviewRule(e: matchingData[]) {
      const matchingWhere = reactive({
        jsonWhere: JSON.stringify(e),
        menuId: menuId,
        rowAuthId: rowAuthId,
      });
      saveRule(matchingWhere).then(({ code, msg }) => {
        if (code == 200) {
          layer.msg(msg, { icon: 1 });
          closeBnt();
        } else {
          layer.confirm(msg, { icon: 2, title: "错误 消息" });
        }
      });
    }
    //保存规则
    function SaveRule(e: matchingData[], ruleRemark: string) {
      const matchingWhere = reactive({
        jsonWhere: JSON.stringify(e),
        menuId: menuId,
        rowAuthId: rowAuthId,
        ruleRemark: ruleRemark,
        isOpen:isOpen
      });
      saveRule(matchingWhere).then(({ code, msg }) => {
        if (code == 200) {
          layer.msg(msg, { icon: 1 });
          closeBnt();
        } else {
          layer.confirm(msg, { icon: 2, title: "错误 消息" });
        }
      });
    }

    return {
      menuId,
      ruleJson,
      rowAuthId,
      ruleRemark,
      isOpen,
      PreviewRule,
      SaveRule,
    };
  },
  components: {
    matchRules,
  },
});
</script>

<style>
.example .layui-footer,
.example .layui-header {
  line-height: 60px;
  text-align: center;
  background: #87ca9a;
  color: white;
}
.layuiSideCalss {
  /* display: flex; */
  margin: 10px 10px;
  background: white;
  align-items: center;
  justify-content: center;
  color: white;
  width: 20% !important;
  flex: 0 0 20% !important;
}

.example .layui-body {
  /* display: flex; */
  background: white;
  align-items: center;
  justify-content: center;
  color: white;
}
</style>