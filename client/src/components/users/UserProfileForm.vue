<template>
  <v-form ref="formUser" v-model="valid" lazy-validation style="position: relative">
    <v-container>
      <v-row>
        <v-col class="d-flex justify-center" cols="12" sm="6" md="6">
          <v-hover v-slot="{ hover }">
            <user-avatar-hover
              :base64="avatar"
              class="mb-6"
              :hover="hover"
              size="200"
              iconSize="40"
              @uploadAvatar="uploadAvatar"
              @deleteAvatar="deleteAvatar"
            ></user-avatar-hover>
          </v-hover>
          <router-link v-if="linkModifyPswd" style="text-decoration: none" :to="{ name: 'update-password' }">
            <v-icon color="primary">mdi-account-lock</v-icon>{{ $t('Modify password') }}
          </router-link>
        </v-col>
        <v-col class="d-flex justify-center mb-6" cols="12" sm="6" md="6">
          <QrcodeCard @updateQrCode="updateQrCode" :disabled="disableQrcode" :user="user" />
        </v-col>
        <v-col cols="12" sm="6" md="4">
          <v-text-field
            :disabled="disableField.name"
            :rules="rules"
            v-model="user.firstName"
            :label="$t('Name')"
          ></v-text-field>
        </v-col>
        <v-col cols="12" sm="6" md="4">
          <v-text-field
            :disabled="disableField.surname"
            :rules="rules"
            v-model="user.lastName"
            :label="$t('Lastname')"
          ></v-text-field>
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
            :disabled="disableField.role"
            v-model="user.roleName"
            item-value="value"
            item-text="text"
            :label="$t('Role')"
          ></v-select>
        </v-col>
      </v-row>
      <v-row>
        <v-col md="6" sm="4" offset-sm="7" offset-md="6" class="text-right">
          <v-btn class="mr-3" color="error" @click="close"
            ><v-icon small> mdi-close-thick </v-icon> {{ $t('Disagree') }}
          </v-btn>
          <v-btn :disabled="disableSave" color="success" :title="$t('Save')" @click="save">
            <v-icon small> mdi-content-save </v-icon>
            {{ $t('Save') }}
          </v-btn>
        </v-col>
      </v-row>
    </v-container>
  </v-form>
</template>
<script>
import QrcodeCard from '../qrcode/QrcodeCard.vue';
import enumRoles from '../../enums/enumRoles';
import UserAvatarHover from './UserAvatarHover.vue';
import Utils from '../../mixins/utils';

export default {
  name: 'UsersProfileForm',
  components: { QrcodeCard, UserAvatarHover },
  mixins: [Utils],
  props: {
    user: {
      type: Object,
      dafault: {},
    },
    disableQrcode: {
      type: Boolean,
      default: false,
    },
    disableSave: {
      type: Boolean,
      default: false,
    },
    disableField: {
      type: Object,
      default: () => ({
        name: false,
        surname: false,
        role: false,
      }),
    },
    validation: {
      type: Object,
      default: () => ({
        username: null,
        email: null,
      }),
    },
    linkModifyPswd: {
      type: Boolean,
      default: false,
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
      avatar: this.user.avatar == null ? null : this.user.avatar,
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
    saveDisable() {
      return this.disableSave;
    },
  },
  watch: {
    user(newVal) {
      this.$refs.formUser.resetValidation();
      this.avatar = newVal.avatar == null ? null : newVal.avatar;
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
    updateQrCode(user) {
      this.$emit('updateQrCode', user);
    },
    resetValidation() {
      this.validation.username = null;
      this.validation.email = null;
      return true;
    },
    async uploadAvatar(payload) {
      debugger;
      this.file = await this.compressImage(payload.file, 800, 600, 0.8);
      this.$emit('saveDisableAvatar');
      const reader = new FileReader();
      reader.readAsDataURL(payload.file);
      const self = this;
      reader.onload = () => {
        self.avatar = reader.result;
      };
    },
    deleteAvatar() {
      this.avatar = null;
      this.$emit('saveDisableAvatar');
      this.cancelAvatar = true;
    },
    close() {
      this.$emit('close');
    },
    save() {
      if (!this.error || !this.$refs.formUser.validate()) {
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
