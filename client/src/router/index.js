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
    meta: { requiresAuth: false },
  },
  {
    path: '/scan',
    name: 'scan',
    component: QrcodeScan,
    meta: { requiresAuth: false },
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
    meta: { requiresAuth: false },
  },
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, from, next) => {
  if (!store.state.token && to.name !== 'login' && to.name !== 'scan') {
    next({ name: 'login' });
  } else if (store.state.token && store.state.token !== undefined && to.name !== 'login' && to.name !== 'scan') {
    store.dispatch('GetUser');
  }
  next();
});

export default router;
