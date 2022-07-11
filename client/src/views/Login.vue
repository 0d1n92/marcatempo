<template>
  <v-container fluid fill-height class="justify-center">
    <v-flex xs12 sm8 md4>
      <v-card class="elevation-12">
        <v-toolbar dark color="primary">
          <v-toolbar-title>Login form</v-toolbar-title>
        </v-toolbar>
        <v-card-text>
          <v-form>
            <v-text-field
              v-model="payloadLogin.username"
              :rules="[rules.required, rules.counter]"
              prepend-icon="fa-user"
              name="login"
              label="Login"
              type="text"
              required
            ></v-text-field>
            <v-text-field
              id="password"
              v-model="payloadLogin.password"
              :rules="[rules.required]"
              prepend-icon="fa-lock"
              name="password"
              label="Password"
              type="password"
              required
            ></v-text-field>
          </v-form>
           <v-alert v-if="error.isError" type="error">
              {{error.message}}
          </v-alert>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="primary" @click="Login">Login</v-btn>
        </v-card-actions>
      </v-card>
    </v-flex>
  </v-container>
</template>

<script>
import Axios from "axios";
export default {
  name: "Login",
  props: {
    source: String,
  },
  data: () => ({
    payloadLogin: {
      username: "",
      password: "",
    },
    rules: {
      required: value => !!value || 'Required.',
    },
    error: {
      isError: false,
      message: "",
    },
  }),
  methods: {
    Login() {
      let scope = this;
      if(this.payloadLogin.username == "" || this.payloadLogin.password ==="") {
         scope.error = {
              isError: true,
              message: "Wrong user or password",
          };
    
        return;
      }
      Axios.post(
        process.env.VUE_APP_ROOT_API + "/users/authenticate",
        this.payloadLogin
      )
        .then((response) => {
          localStorage.token = response.data.token;
          this.$router.push({
            name: "DashBoard",
            params: { user: response.data.username },
          });
        })
        .catch(function (error) {

          scope.error = {
              isError: true,
              message: error,
            };

          if (error.response.status == 404) {
            scope.error = {
              isError: true,
              message: "Wrong user or password",
            };
          }
           
          console.log("errore" + error);
        });
    },
  },
};
</script>

<style></style>
