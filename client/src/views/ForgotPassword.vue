<template>
  <v-container fluid fill-height class="justify-center">
    <v-flex xs12 sm8 md4>
      <v-card class="elevation-12">
        <v-toolbar dark color="primary">
          <v-toolbar-title>Reset Password</v-toolbar-title>
        </v-toolbar>
        <v-card-text>
          <v-form ref="formReset">
            <v-text-field
              v-model="email"
              :rules="rules"
              @change="resetMessage"
              prepend-icon="fa-at"
              name="email"
              label="Mail"
              @keyup.enter="SendMail"
              type="text"
              required
            ></v-text-field>
            <v-spacer></v-spacer>
            <div class="d-flex justify-end">
              <v-btn color="primary" @click="SendMail">Reset</v-btn>
            </div>
            <v-alert v-if="error.isError" prominent outlined border="left" class="mt-2" type="error">
              {{ error.message }}
            </v-alert>
            <v-alert v-if="success.issuccess" prominent outlined border="left" class="mt-2" type="success">
              {{ success.message }}
            </v-alert>
          </v-form>
        </v-card-text>
      </v-card>
    </v-flex>
  </v-container>
</template>

<script>
import Axios from 'axios';
import i18n from '../i18n';

export default {
  name: 'ForgotPassword',
  data: () => ({
    email: '',
    rules: [
      (v) => !!v || i18n.t('Is required'),
      (v) => !v || /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) || i18n.t('E-mail must be valid'),
    ],
    error: {
      isError: false,
      message: '',
    },
    success: {
      issuccess: false,
      message: '',
    },
  }),
  methods: {
    resetMessage() {
      this.error = {
        isError: false,
        message: '',
      };
      this.success = {
        issuccess: false,
        message: '',
      };
    },
    SendMail() {
      const self = this;
      if (this.$refs.formReset.validate()) {
        Axios.post(`${process.env.VUE_APP_ROOT_API}/users/send-email-reset-pswd`, {
          email: this.email,
          lang: self.$i18n.locale,
        })
          .then(() => {
            self.success = {
              issuccess: true,
              message: self.$i18n.t('Dialog.Send Mail'),
            };
            self.error = { isError: false, message: '' };
          })
          .catch((error) => {
            const message = `Error.${error.response.data.message}`;
            self.error = { isError: true, message: self.$i18n.t(message) };
          });
      }
    },
  },
};
</script>

<style></style>
