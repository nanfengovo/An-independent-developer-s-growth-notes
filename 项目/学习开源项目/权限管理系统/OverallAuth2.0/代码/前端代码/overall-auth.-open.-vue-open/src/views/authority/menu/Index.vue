<template>
  <roleIndex :auth="authTypeEnum.menuAuth"></roleIndex>
</template>
<script lang="ts">
import { defineComponent } from 'vue';
import roleIndex from "../roleIndex.vue"
import {
  authTypeEnum
} from "../../../api/publicTool";

export default defineComponent({
  setup() {
    return {
      //SceneKindEnum,
      authTypeEnum
    };
  },
  components: {
    roleIndex,
  },
});
</script>
