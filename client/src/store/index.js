import Axios from 'axios';
import Vue from 'vue';
import Vuex from 'vuex';
import createPersistedState from 'vuex-persistedstate';

Vue.use(Vuex);
export default new Vuex.Store({
  plugins: [createPersistedState()],
  state: {
    loggedUser: {},
    marked: {},
    isExit: false,
    token: null,
  },
  getters: {
    getUser: (state) => {
      const user = {
        avatar: state.loggedUser.avatar,
        fullName: `${state.loggedUser.firstName} ${state.loggedUser.lastName}`,
        role: state.loggedUser.roleName,
      };
      return user;
    },
  },
  mutations: {
    GetUser(state, payload) {
      state.loggedUser = payload;
    },
    Postmark(state, payload) {
      state.marked = payload;
    },

    SetIsExit(state, payload) {
      state.isExit = payload;
    },
    Logout(state) {
      state.loggedUser = {};
      state.token = null;
    },

    SetJwtToken(state, token) {
      state.token = token;
    },
    UploadAvatar(state, avatar) {
      state.loggedUser.avatar = avatar;
    },
  },
  actions: {
    GetUser({ commit, state }) {
      Axios.get(`${process.env.VUE_APP_ROOT_API}/users/user-info`, {
        headers: { Authorization: state.token },
      })
        .then((response) => {
          commit('GetUser', response.data.user);
        })
        .catch((error) => {
          console.log(`errore + ${error}`);
        });
    },
    UploadAvatar({ commit, state }, formData) {
      Axios.post(`${process.env.VUE_APP_ROOT_API}/users/save-avatar`, formData, {
        headers: { Authorization: state.token },
      })
        .then((response) => {
          commit('UploadAvatar', response.data.image);
        })
        .catch((error) => {
          console.log(`errore + ${error}`);
        });
    },
    Postmark({ commit }, payload) {
      Axios.post(`${process.env.VUE_APP_ROOT_API}/qrcodes/postmark`, payload)
        .then((response) => {
          commit('Postmark', response.data);
        })
        .catch((error) => {
          console.log(`errore + ${error}`);
        });
    },
  },
  modules: {},
});
