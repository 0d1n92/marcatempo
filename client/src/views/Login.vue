<template>
  <v-container fluid fill-height class="justify-center">
    <v-flex xs12 sm8 md4>
      <v-card class="elevation-12">
        <v-toolbar dark color="primary">
          <v-toolbar-title>Login form</v-toolbar-title>
        </v-toolbar>
        <v-card-text>
          <v-form ref="form">
            <v-text-field
              v-model="payloadLogin.username"
              :rules="[rules.required]"
              prepend-icon="fa-user"
              name="login"
              label="Login"
              @keyup.enter="Login"
              type="text"
              required
            ></v-text-field>
            <v-text-field
              id="password"
              @keyup.enter="Login"
              v-model="payloadLogin.password"
              :rules="[rules.required]"
              prepend-icon="fa-lock"
              name="password"
              label="Password"
              type="password"
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
  data: () => ({
    payloadLogin: {
      username: '',
      password: '',
    },
    rules: {
      required: (value) => !!value || 'Required.',
    },
    error: {
      isError: false,
      message: '',
    },
  }),
  methods: {
    Login() {
      const scope = this;
      this.$refs.form.validate();
      if (this.payloadLogin.username === '' || this.payloadLogin.password === '') return;
      Axios.post(`${process.env.VUE_APP_ROOT_API}/users/authenticate`, this.payloadLogin)
        .then((response) => {
          localStorage.token = response.data.token;
          this.$router.push({
            name: 'dash-board',
            params: { user: response.data.username },
          });
        })
        .catch((error) => {
          scope.error = {
            isError: true,
            message: error,
          };
          if (error.response.status === 404) {
            scope.error = { isError: true, message: 'Wrong user or password' };
          }
          console.log(`errore + ${error}`);
        });
    },
  },
};
</script>
