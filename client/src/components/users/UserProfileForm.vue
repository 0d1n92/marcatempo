<template>
  <v-form ref="form" v-model="valid" lazy-validation style="position: relative">
    <v-container>
      <v-row>
        <v-col cols="12" sm="6" md="6">
          <v-hover v-slot="{ hover }">
            <user-avatar-hover
              :base64="avatar"
              :hover="hover"
              :initials="userInitials"
              size="200"
              iconSize="40"
              @uploadAvatar="uploadAvatar"
              @deleteAvatar="deleteAvatar"
            ></user-avatar-hover>
          </v-hover>
        </v-col>
        <v-col cols="12" sm="6" md="6">
          <QrcodeCard :disabled="disableQrcode" :user="user" />
        </v-col>
        <v-col cols="12" sm="6" md="4">
          <v-text-field :rules="rules" v-model="user.firstName" :label="$t('Name')"></v-text-field>
        </v-col>
        <v-col cols="12" sm="6" md="4">
          <v-text-field :rules="rules" v-model="user.lastName" :label="$t('Lastname')"></v-text-field>
        </v-col>
        <v-col cols="12" sm="6" md="4">
          <v-text-field
            :rules="[...rules, resetValidation]"
            v-model="user.username"
            :error-messages="validation.username"
            label="Username"
          ></v-text-field>
        </v-col>
        <v-col cols="12" sm="6" md="4">
          <v-text-field
            :rules="[...emailRules, resetValidation]"
            :error-messages="validation.email"
            v-model="user.email"
            label="Email"
          ></v-text-field>
        </v-col>
        <v-col cols="12" sm="6" md="4">
          <v-select
            :items="roles"
            :rules="[(v) => !!v || this.$i18n.t('Is required')]"
            v-model="user.roleName"
            item-value="value"
            item-text="text"
            :label="$t('Role')"
          ></v-select>
        </v-col>
      </v-row>
      <v-row>
        <v-col sm="3" offset-sm="9" class="text-right">
          <v-btn color="blue darken-1" text @click="close"> {{ $t('Disagree') }} </v-btn>
          <v-btn color="blue darken-1" text @click="save"> {{ $t('Save') }} </v-btn>
        </v-col>
      </v-row>
    </v-container>
  </v-form>
</template>
<script>
import QrcodeCard from '../qrcode/QrcodeCard.vue';
import enumRoles from '../../enums/enumRoles';
import UserAvatarHover from './UserAvatarHover.vue';

export default {
  name: 'UsersProfileForm',
  components: { QrcodeCard, UserAvatarHover },
  props: {
    user: {
      type: Object,
      dafault: {},
    },
    disableQrcode: {
      type: Boolean,
      default: false,
    },
    validation: {
      type: Object,
      default: () => ({
        username: null,
        email: null,
      }),
    },
  },
  data() {
    return {
      rules: [],
      cancelAvatar: false,
      emailRules: [
        (v) => !v || /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) || this.$i18n.t('E-mail must be valid'),
      ],
      error: true,
      avatar: this.user.avatar == null ? null : `data:image/png;base64,${this.user.avatar}`,
      file: null,
      valid: true,
      validationUsr: [],
    };
  },
  mounted() {
    this.rules = [
      (v) => !!v || this.$i18n.t('Is required'),
      (v) => (v && v.length >= 3) || this.$i18n.t('Dialog.Must be less than 3 characters'),
    ];
  },
  computed: {
    roles() {
      const roles = [];
      Object.keys(enumRoles).forEach((item) => {
        if (item !== 'Guest') {
          roles.push({ text: this.$i18n.t(item), value: item });
        }
      });
      return roles;
    },
    userInitials() {
      if (this.user.lastName && this.user.firstName) {
        if (this.user.firstName[0] && this.user.firstName[0]) {
          return `${this.user.firstName[0]}${this.user.lastName[0]}`;
        }
      }
      return '';
    },
  },
  watch: {
    user(newVal) {
      this.$refs.form.resetValidation();
      this.avatar = newVal.avatar == null ? null : `data:image/png;base64,${newVal.avatar}`;
    },
    validation(newVal) {
      if (newVal.username) {
        this.validationUsername = this.validation.username ? [newVal.username] : [];
      } else if (newVal.email) {
        this.validationEmail = this.validation.email ? [newVal.email] : [];
      }
    },
  },

  methods: {
    resetValidation() {
      this.validation.username = null;
      this.validation.email = null;
      return true;
    },
    uploadAvatar(payload) {
      this.file = payload.file;
      const reader = new FileReader();
      reader.readAsDataURL(payload.file);
      const self = this;
      reader.onload = () => {
        self.avatar = reader.result;
      };
    },
    deleteAvatar() {
      this.avatar = null;
      this.cancelAvatar = true;
    },
    close() {
      this.$emit('close');
    },
    save() {
      if (!this.error || !this.$refs.form.validate()) {
        return;
      }
      this.$emit('save', { file: this.file, base64: this.avatar, deleteAvatar: this.cancelAvatar });
      this.cancelAvatar = false;
    },
  },
};
</script>
<style scoped>
.v-card--reveal {
  align-items: center;
  bottom: 0;
  justify-content: center;
  opacity: 0.5;
  width: 100%;
  height: 50% !important;
}

.input_avatar {
  width: 100% !important;
  cursor: pointer !important;
  position: absolute !important;
  bottom: 0;
  display: block !important;
}
</style>
