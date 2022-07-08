import Vue from "vue";
import VueRouter from "vue-router";
import QrcodeScan from "../views/QrcodeScan.vue";
import Login from "../views/Login.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/scan",
    name: "ScanQr",
    component: QrcodeScan,
  },
  {
    path: "/login",
    name: "Login",
    component: Login,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});
//router.replace({ path: '/login', redirect: '/' })
export default router;
