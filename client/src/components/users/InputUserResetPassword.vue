<template>
  <v-form ref="form">
    <v-text-field
      v-model="payload.password"
      :rules="rules"
      prepend-icon="fa-lock"
      name="password"
      label="Password"
      type="password"
      required
    ></v-text-field>
    <v-text-field
      @keyup.enter="send"
      v-model="payload.confirmPassword"
      :rules="[...rules, rulesConfirm]"
      prepend-icon="mdi-lock-question"
      name="confirmPassword"
      :label="$t('Repeat password')"
      type="password"
      required
    ></v-text-field>
    <v-spacer></v-spacer>
    <div class="d-flex justify-end">
      <v-btn color="primary" @click="send">{{ $t('Save') }}</v-btn>
    </div>
  </v-form>
</template>

<script>
export default {
  name: 'InputUserResetPassword',
  props: {
    token: {
      type: String,
      required: true,
    },
    email: {
      type: String,
      required: true,
    },
  },
  data() {
    return {
      payload: {
        password: '',
        confirmPassword: '',
        email: this.$props.email,
        token: this.$props.token,
      },
      // eslint-disable-next-line prettier/prettier, max-len
      rulesConfirm: () => this.payload.password === this.payload.confirmPassword || this.$i18n.t('Error.Password match'),
      rules: [
        (v) => !!v || this.$i18n.t('Is required'),
        (v) => (v && v.length >= 6) || this.$i18n.t('Error.Minimum 6'),
      ],
    };
  },
  methods: {
    send() {
      this.$emit('onSave', this.payload);
    },
  },
};
</script>

<style></style>
