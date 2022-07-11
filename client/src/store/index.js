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
    GetUser(state, payload) {
      state.loggedUser = payload;
    },
    Postmark(state, payload) {
      state.marked = payload;
      console.log("risultato qrcode", state.marked);
    },

    SetIsExit(state, payload) {
      state.isExit = payload;
    },
    Logout(state) {
      state.loggedUser={};
      localStorage.clear();
    }

  },
  actions: {
    GetUser({commit}) {
      Axios.get(process.env.VUE_APP_ROOT_API + "/users/user-info", { headers: { "Authorization": `${localStorage.getItem('token')}` } }).then(
        (response)=> {
          commit("GetUser", response.data.data);
        }
      ).catch(function (error) {
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
