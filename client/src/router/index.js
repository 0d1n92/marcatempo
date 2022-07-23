import Vue from 'vue';
import VueRouter from 'vue-router';
import QrcodeScan from '../views/QrcodeScan.vue';
import Login from '../views/Login.vue';
import DashBoard from '../views/DashBoard.vue';
import UsersList from '../views/UsersList.vue';
import store from '../store';
// import store from '@/store';
Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    redirect: '/login',
  },
  {
    path: '/login',
    name: 'login',
    component: Login,
  },
  {
    path: '/scan',
    name: 'scan',
    component: QrcodeScan,
  },
  {
    path: '/dashboard/:user',
    name: 'dash-board',
    component: DashBoard,
  },
  {
    path: '/dashboard/users',
    name: 'users',
    component: UsersList,
  },
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, from, next) => {
  if (!localStorage.getItem('token') && to.name !== 'login' && to.name !== 'scan') {
    next({ name: 'login' });
  } else if (
    localStorage.getItem('token')
    && localStorage.getItem('token').length > 0
    && to.name !== 'login' &&
    to.name !== 'scan'
  ) {
    store.dispatch('GetUser').then(next()).catch(console.log('Error : user not found'));
  }
  next();
});

export default router;
