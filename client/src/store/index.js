import Axios from 'axios';
import Vue from 'vue';
import Vuex from 'vuex';
import createPersistedState from 'vuex-persistedstate';
import i18n from '../i18n';

Vue.use(Vuex);
export default new Vuex.Store({
  plugins: [createPersistedState()],

  state: {
    loggedUser: {},
    marked: {},
    isExit: false,
    token: null,
    error: false,
    messageError: i18n.t('Error.Generic'),
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
    SetQrcode(state, payload) {
      state.loggedUser.qrCode = payload;
    },
    SetLang(state, payload) {
      state.lang = payload;
      i18n.locale = state.lang;
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
      return new Promise((resolve, reject) => {
        Axios.get(`${process.env.VUE_APP_ROOT_API}/users/user-info`, {
          headers: { Authorization: state.token },
        })
          .then((response) => {
            commit('GetUser', response.data.user);
            resolve(response.data.user);
          })
          .catch((error) => {
            commit('SetError', `${error}, ${i18n.t('Error.Information user')}`);
            reject(error);
          });
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
          commit('SetError', `${error}, ${i18n.t('Error.Save avatar')}`);
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
          commit('SetError', `${error}, ${i18n.t('Error.Delete avatar')}`);
        });
    },
    Postmark({ commit }, payload) {
      Axios.post(`${process.env.VUE_APP_ROOT_API}/qrcodes/postmark`, payload)
        .then((response) => {
          commit('Postmark', response.data);
        })
        .catch((error) => {
          console.log(`error + ${error}`);
        });
    },
    UpdateQrcode({ commit, state }, user) {
      Axios.post(
        `${process.env.VUE_APP_ROOT_API}/qrcodes/update`,
        { token: user.qrCode },
        {
          headers: { Authorization: state.token },
          // eslint-disable-next-line prettier/prettier
        },
      )
        .then((response) => {
          // eslint-disable-next-line no-param-reassign
          user.qrCode = response.data;
          return user.qrCode;
        })
        .catch((error) => {
          commit('SetError', `${error}, impossible to update qrcode`);
        });
    },
    // eslint-disable-next-line no-unused-vars
    ResetPassword({ commit }, payload) {
      return new Promise((resolve, reject) => {
        Axios.post(`${process.env.VUE_APP_ROOT_API}/users/reset-user-pswd`, payload)
          .then((response) => resolve(response.data))
          .catch((error) => {
            reject(error);
          });
      });
    },
  },
  modules: {},
});
