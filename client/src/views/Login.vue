<template>
  <v-container fluid fill-height class="justify-center">
    <v-flex xs12 sm8 md4>
      <v-card class="elevation-12">
        <v-toolbar dark color="primary">
          <v-toolbar-title>Login</v-toolbar-title>
          <v-spacer></v-spacer>
          <v-btn icon>
            <v-icon @click="$router.push({ name: 'scan' })">mdi-qrcode-scan</v-icon>
          </v-btn>
        </v-toolbar>
        <v-card-text>
          <v-form ref="form">
            <v-text-field
              v-model="payloadLogin.username"
              :rules="rules"
              prepend-icon="fa-user"
              name="login"
              :label="$t('Username or Email')"
              @keyup.enter="Login"
              type="text"
              required
            ></v-text-field>
            <v-text-field
              id="password"
              @keyup.enter="Login"
              v-model="payloadLogin.password"
              :rules="rules"
              prepend-icon="fa-lock"
              name="password"
              label="Password"
              :type="showPswd ? 'text' : 'password'"
              :append-icon="showPswd ? 'mdi-eye' : 'mdi-eye-off'"
              @click:append="showPswd = !showPswd"
              required
            ></v-text-field>
            <v-spacer></v-spacer>
            <div class="d-flex justify-end">
              <v-btn color="primary" @click="Login">Login</v-btn>
            </div>
            <v-alert v-if="error.isError" prominent outlined border="left" class="mt-2" type="error">
              {{ error.message }}
            </v-alert>
          </v-form>
          <router-link :to="{ name: 'password-forgot' }">{{ $t('Forgot password') }}</router-link>
        </v-card-text>
      </v-card>
    </v-flex>
  </v-container>
</template>

<script>
import Axios from 'axios';

export default {
  name: 'Login',
  props: {
    source: String,
  },
  data() {
    return {
      showPswd: false,
      payloadLogin: {
        username: '',
        password: '',
      },
      rules: [(value) => !!value || this.$i18n.t('Is required')],
      error: {
        isError: false,
        message: '',
      },
    };
  },
  methods: {
    Login() {
      const self = this;
      this.$refs.form.validate();
      if (this.payloadLogin.username === '' || this.payloadLogin.password === '') return;
      Axios.post(`${process.env.VUE_APP_ROOT_API}/users/authenticate`, this.payloadLogin)
        .then((response) => {
          this.$store.commit('SetJwtToken', response.data.token);

          self.$store.dispatch('GetUser').then((usr) => {
            if (usr.roleId === 1) {
              self.$router.push({
                name: 'actions',
              });
            } else {
              self.$router.push({
                name: 'dash-board',
                params: { user: response.data.userName },
              });
            }
          });
        })
        .catch((error) => {
          self.error = {
            isError: true,
            message: error,
          };
          if (error.response.status === 404) {
            self.error = { isError: true, message: self.$i18n.t('Error.User not found') };
          }

          if (error.response.status === 401) {
            self.error = { isError: true, message: self.$i18n.t('Error.Wrong password') };
          }

          if (error.response.status === 403) {
            self.error = { isError: true, message: self.$i18n.t('Error.Blocked user') };
          }
          console.error(`errore + ${error}`);
        });
    },
  },
};
</script>
