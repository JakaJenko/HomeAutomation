import { createApp } from 'vue'
import App from './App.vue'
import SmartTable from 'vuejs-smart-table'

const app = createApp(App);
app.use(SmartTable);
app.mount('#app');