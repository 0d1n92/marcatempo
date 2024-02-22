<template>
  <wire-frame>
    <v-container fluid fill-height class="justify-center">
      <v-flex xs12 sm8 md4>
        <v-card elevation="0">
          <v-toolbar elevation="0">
            <v-toolbar-title><v-icon>mdi-account-lock</v-icon> Reset Password</v-toolbar-title>
          </v-toolbar>
          <v-card-text>
            <input-user-reset-password @onSave="onSave" :token="$store.state.token"></input-user-reset-password>
            <v-alert v-if="error.isError" prominent outlined border="left" class="mt-2" type="error">
              {{ error.message }}
            </v-alert>
            <v-alert v-if="success.issuccess" prominent outlined border="left" class="mt-2" type="success">
              {{ success.message }}
            </v-alert>
          </v-card-text>
        </v-card>
      </v-flex>
    </v-container>
  </wire-frame>
</template>

<script>
import Axios from 'axios';
import WireFrame from '../components/layout/WireFrame.vue';
import InputUserResetPassword from '../components/users/InputUserResetPassword.vue';

export default {
  components: { InputUserResetPassword, WireFrame },
  name: 'UserUpdatePassword',
  data() {
    return {
      error: {
        isError: false,
        message: '',
      },
      success: {
        issuccess: false,
        message: '',
      },
    };
  },
  methods: {
    onSave(payload) {
      Axios.put(`${process.env.VUE_APP_ROOT_API}/users/update-password`, payload, {
        headers: { Authorization: this.$store.state.token },
      })
        .then(() => {
          this.showSucessBox();
        })
        .catch((error) => {
          this.$store.commit('SetError', `${error}, ${this.$i18n.t('Error.Impossibile update pswd')}`);
        });
    },

    showSucessBox() {
      this.success.issuccess = true;
      this.success.message = 'Password changed';
      setTimeout(() => {
        this.success.issuccess = false;
      }, 10000);
    },
  },
};
</script>

<style></style>
