<template>
<dv>asdfsdf</dv>
 <navigation1 @Key1="AddMenuKey" @Key2="DelMenuKey" :model="pageParms"></navigation1>
</template>

<script lang="ts">
import { defineComponent, onMounted, reactive, ref } from 'vue'
import { layer } from '@layui/layer-vue'
import navigation1 from "../button.vue";

export default defineComponent({
  setup() {

    const  pageParms = ref({
        userName :'测试001',
        sex:"男"
    })
   function AddMenuKey(e: any) {
      layer.msg('测试页面间传值:'+e.userName);
    }
    function DelMenuKey(e: any) {
      layer.msg('测试页面间传值2:'+e.userName);
    }
    return {
        AddMenuKey,
        DelMenuKey,
        pageParms
    }
  },
  components:{navigation1}
})
</script>

<style scoped>
</style>
