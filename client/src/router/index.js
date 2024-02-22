import Vue from 'vue';
import VueRouter from 'vue-router';
import QrcodeScan from '../views/QrcodeScan.vue';
import Login from '../views/Login.vue';
import UsersList from '../views/UsersList.vue';
import Actions from '../views/Actions.vue';
import Profile from '../views/Profile.vue';
import ForgotPassword from '../views/ForgotPassword.vue';
import MyActions from '../views/MyActions.vue';
import ResetPassword from '../views/ResetPassword.vue';
import UserUpdatePassword from '../views/UserUpdatePassword.vue';
import store from '../store';
import middlewarePipeline from './middleware-pipeline';
import { auth, admin } from './middleware';
import i18n from '../i18n';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    redirect: `/${i18n.locale}/login`,
  },
  {
    path: '/:lang',
    component: {
      render(c) {
        return c('router-view');
      },
    },
    children: [
      {
        path: 'login',
        name: 'login',
        component: Login,
      },
      {
        path: 'scan',
        name: 'scan',
        component: QrcodeScan,
      },
      {
        path: 'dashboard/:user',
        name: 'dash-board',
        component: MyActions,
        meta: {
          middleware: [auth],
        },
      },
      {
        path: 'actions/:username',
        name: 'my-actions',
        component: MyActions,
        meta: {
          middleware: [auth],
        },
      },
      {
        path: 'users',
        name: 'users',
        component: UsersList,
        meta: {
          middleware: [auth, admin],
        },
      },
      {
        path: 'users/actions',
        name: 'actions',
        component: Actions,
        meta: {
          middleware: [auth, admin],
        },
      },
      {
        path: 'user/profile',
        name: 'profile',
        component: Profile,
        meta: {
          middleware: [auth],
        },
      },
      {
        path: 'user/update-password',
        name: 'update-password',
        component: UserUpdatePassword,
        meta: {
          middleware: [auth],
        },
      },
      {
        path: 'password-forgot',
        name: 'password-forgot',
        component: ForgotPassword,
      },
      {
        path: 'reset-password',
        name: 'reset-password',
        query: { email: '', token: '' },
        component: ResetPassword,
      },
    ],
  },
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, from, next) => {
  store.state.error = false;
  let language = to.params.lang;
  if (!language) {
    language = 'it';
  }
  i18n.locale = language;
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
