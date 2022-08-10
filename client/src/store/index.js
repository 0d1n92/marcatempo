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
    error: false,
    messageError: 'Generic Error',
  },
  getters: {
    getUser: (state) => {
      const user = {
        avatar: state.loggedUser.avatar,
        initials:
          state.loggedUser && state.loggedUser.firstName && state.loggedUser.lastName
            ? `${state.loggedUser.firstName[0]}${state.loggedUser.lastName[0]}`
            : '',
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

    SetError(state, payload) {
      state.error = true;
      state.messageError = payload;
    },
    DeleteAvatar(state) {
      state.loggedUser.avatar = null;
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
          commit('SetError', `${error}, impossible to give information about the user`);
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
          commit('SetError', `${error}, impossible to save avatar`);
        });
    },
    DeleteAvatar({ commit, state }) {
      Axios.delete(`${process.env.VUE_APP_ROOT_API}/users/avatar`, {
        headers: { Authorization: state.token },
      })
        .then((response) => {
          commit('DeleteAvatar', response.data.image);
        })
        .catch((error) => {
          commit('SetError', `${error}, impossible to delete avatar`);
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
