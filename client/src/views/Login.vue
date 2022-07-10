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
              prepend-icon="fa-user"
              name="login"
              label="Login"
              type="text"
            ></v-text-field>
            <v-text-field
              id="password"
              v-model="payloadLogin.password"
              prepend-icon="fa-lock"
              name="password"
              label="Password"
              type="password"
            ></v-text-field>
          </v-form>
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
  }),
  methods: {
    Login() {
      console.log(this.$router);
      this.$store.dispatch("AuthLogin", this);
    },
  },
};
</script>

<style></style>
