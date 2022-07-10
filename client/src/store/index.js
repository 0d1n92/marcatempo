import Axios from "axios";
import Vue from "vue";
import Vuex from "vuex";
import createPersistedState from "vuex-persistedstate";

Vue.use(Vuex);

export default new Vuex.Store({
  plugins: [createPersistedState()],
  state: {
    loggedUser: {},
    marked: {},
    isExit: false,
  },
  mutations: {
    Login(state, payload) {
      state.loggedUser = payload;
      localStorage.token = payload.token;
      console.log("arrivo");
    },

    Postmark(state, payload) {
      state.marked = payload;
      console.log("risultato qrcode", state.marked);
    },

    SetIsExit(state, payload) {
      console.log(payload);
      state.isExit = payload;
    },
  },
  actions: {
    AuthLogin({ commit }, refer) {
      console.log (refer);
      Axios.post(process.env.VUE_APP_ROOT_API + "/users/authenticate", {
        username: refer.payloadLogin.username,
        password: refer.payloadLogin.password,
      })
        .then((response) => {
          console.log("auth");
          commit("Login", response.data);
          refer.$router.push({name:"DashBoard", params: { user:"Administrator"}})
          
        })
        .catch(function (error) {
          console.log("errore" + error);
        });
    },

    Postmark({ commit }, payload) {
      Axios.post(process.env.VUE_APP_ROOT_API + "/qrcodes/postmark", payload)
        .then((response) => {
          commit("Postmark", response.data);
        })
        .catch(function (error) {
          console.log("errore" + error);
        });
    },
  },
  modules: {},
});
