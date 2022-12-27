import Vue from 'vue';
import './plugins/axios';
import Fragment from 'vue-fragment';
import App from './App.vue';
import router from './router';
import store from './store';
import vuetify from './plugins/vuetify';
import i18n from './i18n';

Vue.config.productionTip = false;
Vue.use(require('moment'));

Vue.use(Fragment.Plugin);

new Vue({
  router,
  store,
  vuetify,
  i18n,
  render: (h) => h(App),
}).$mount('#app');
