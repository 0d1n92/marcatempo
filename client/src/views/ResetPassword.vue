<template>
  <v-container fluid fill-height class="justify-center">
    <v-flex xs12 sm8 md4>
      <v-card class="elevation-12">
        <v-toolbar dark color="primary">
          <v-toolbar-title>Reset Password</v-toolbar-title>
        </v-toolbar>
        <v-card-text>
          <input-user-reset-password @onSave="onSave" :email="$route.query.email" :token="$route.query.token">
          </input-user-reset-password>
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
</template>
<script>
import InputUserResetPassword from '../components/users/InputUserResetPassword.vue';

export default {
  components: { InputUserResetPassword },
  name: 'ResetPassword',
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
      const self = this;
      this.$store
        .dispatch('ResetPassword', payload)
        .then((response) => {
          self.success = {
            issuccess: response,
            message: self.$i18n.t('Success.Update password'),
          };
          debugger;
          self.error = {
            isError: false,
            message: '',
          };

          setTimeout(() => {
            self.$router.push({ name: 'login' });
          }, 5000);
        })
        .catch((e) => {
          debugger;
          self.success = {
            issuccess: false,
            message: '',
          };
          self.error = {
            isError: true,
            message: Object.values(e.response.data.errors)[0][0],
          };
        });
    },
  },
};
</script>

<style></style>
