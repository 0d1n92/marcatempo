import Vue from "vue";
import VueRouter from "vue-router";
import QrcodeScan from "../views/QrcodeScan.vue";
import Login from "../views/Login.vue";
import DashBoard from "../views/DashBoard.vue";
import Operators from "../views/Operators.vue";


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
  {
    path: "/dashboard/:user",
    name: "DashBoard",
    component: DashBoard,
  },
  {

    path: "/dashboard/:user/operators",
    name: "operators",
    component: Operators,
  }

];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});



router.beforeEach((to, from, next) => {

  if (!localStorage.getItem('token') && to.name != "Login") {
    console.log("to:", to);
    next({ name: "login" })
  }
  next();
});

export default router;
