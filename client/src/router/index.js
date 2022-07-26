import Vue from 'vue';
import VueRouter from 'vue-router';
import QrcodeScan from '../views/QrcodeScan.vue';
import Login from '../views/Login.vue';
import DashBoard from '../views/DashBoard.vue';
import UsersList from '../views/UsersList.vue';
import store from '../store';
import middlewarePipeline from './middleware-pipeline';
import { auth, admin } from './middleware';

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
    meta: {
      middleware: [auth],
    },
  },
  {
    path: '/users',
    name: 'users',
    component: UsersList,
    meta: {
      middleware: [auth, admin],
    },
  },
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, from, next) => {
  if (!to.meta.middleware) {
    return next();
  }

  const { middleware } = to.meta;
  const context = {
    to,
    from,
    next,
    store,
  };

  return middleware[0]({
    ...context,
    next: middlewarePipeline(context, middleware, 1),
  });
});

export default router;
