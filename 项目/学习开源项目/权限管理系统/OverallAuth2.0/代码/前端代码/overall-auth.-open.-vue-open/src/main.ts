import { createApp } from 'vue'
import Router from './router'
import Store from './store'
import App from './App.vue'
import { permission } from "./directives/permission";
import './mockjs'
import  layer  from "@layui/layui-vue";

const app = createApp(App)
app.use(Store);
app.use(Router);
app.use(layer);

app.directive("permission",permission);
app.mount('#app');
