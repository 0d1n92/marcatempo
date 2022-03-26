import Axios from "axios";
import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    LoggedUser: {},
    marked: {},
    isExit: false  
  },
  mutations: {
    Login(state,payload) {
      state.LoggedUser = payload;
      localStorage.token=  payload.token;
    },

    Postmark(state, payload ) {
      state.marked = payload;  
      console.log("risultato qrcode", state.marked);
    },

    SetIsExit(state, payload) {
      console.log(payload)
       state.isExit = payload;
    }
  },
  actions: {

    AuthLogin({commit},payload) {
     
      Axios.post(process.env.VUE_APP_ROOT_API + "/users/authenticate", {
          username: payload.username,
          password: payload.password
      }
      ).then(response => { 
          commit('Login', response.data)
      }).catch(function (error) {
        console.log("errore" + error);
      });
    },
    
    Postmark ({commit}, payload) {
      Axios.post(process.env.VUE_APP_ROOT_API + "/qrcodes/postmark", payload )
        .then(response => {
          commit('Postmark', response.data)
        }).catch(function (error) {
          console.log("errore" + error);
        });
    }
  },
  modules: {},
});
