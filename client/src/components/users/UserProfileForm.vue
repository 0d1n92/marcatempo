<template>
  <v-card>
    <v-card-title class="pa-0">
      <v-toolbar dark color="primary">
        <v-icon>mdi-account</v-icon>
        <v-toolbar-title>{{ formTitle }}</v-toolbar-title>
      </v-toolbar>
    </v-card-title>
    <v-card-text>
      <v-container>
        <v-row>
          <v-col cols="12" sm="6" md="6">
            <v-hover v-slot="{ hover }">
              <user-avatar-hover
                :base64="avatar"
                :hover="hover"
                :initials="UserInitials"
                size="200"
                iconSize="40"
                @uploadAvatar="uploadAvatar"
                @deleteAvatar="deleteAvatar"
              ></user-avatar-hover>
            </v-hover>
          </v-col>
          <v-col cols="12" sm="6" md="6">
            <QrcodeCard :user="user" />
          </v-col>
          <v-col cols="12" sm="6" md="4">
            <v-text-field :rules="rules ? [rules.required] : ['']" v-model="user.firstName" label="Name"></v-text-field>
          </v-col>
          <v-col cols="12" sm="6" md="4">
            <v-text-field
              :rules="rules ? [rules.required] : ['']"
              v-model="user.lastName"
              label="Surname"
            ></v-text-field>
          </v-col>
          <v-col cols="12" sm="6" md="4">
            <v-text-field
              :rules="rules ? [rules.required] : ['']"
              v-model="user.username"
              label="Username"
            ></v-text-field>
          </v-col>
          <v-col cols="12" sm="6" md="4">
            <v-text-field :rules="rules ? [rules.required] : ['']" v-model="user.email" label="Email"></v-text-field>
          </v-col>
          <v-col cols="12" sm="6" md="4">
            <v-select :items="roles" v-model="user.roleName" label="Role"></v-select>
          </v-col>
        </v-row>
      </v-container>
    </v-card-text>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn color="blue darken-1" text @click="close"> Cancel </v-btn>
      <v-btn color="blue darken-1" text @click="save"> Save </v-btn>
    </v-card-actions>
  </v-card>
</template>
<script>
import QrcodeCard from '../qrcode/QrcodeCard.vue';
import enumRoles from '../../enums/enumRoles';
import UserAvatarHover from './UserAvatarHover.vue';

export default {
  name: 'UsersAdminForm',
  components: { QrcodeCard, UserAvatarHover },
  props: {
    formTitle: {
      type: String,
      dafult: '',
    },
    user: {
      type: Object,
      dafault: {},
    },
  },
  mounted() {
    this.rules = {
      required: (value) => {
        this.error = !!value;
        return !!value || 'Required.';
      },
    };
    this.UserInitials = `${this.user.firstName[0]}${this.user.lastName[0]}`;
  },
  data() {
    return {
      roles: Object.keys(enumRoles).filter((item) => item !== 'Guest'),
      rules: {
        required: '',
      },
      error: true,
      avatar: this.user.avatar == null ? null : `data:image/png;base64,${this.user.avatar}`,
      file: null,
      UserInitials:
        this.user.firstName && this.user.firstName.lenght > 0
          ? `${this.user.firstName[0]}${this.user.lastName[0]}`
          : '',
    };
  },
  watch: {
    user(newVal) {
      if (newVal && newVal.lastName && newVal.firstName && newVal.firstName[0] && newVal.firstName[0]) {
        this.UserInitials = `${newVal.firstName[0]}${newVal.lastName[0]}`;
      }
      this.avatar = newVal.avatar == null ? null : `data:image/png;base64,${newVal.avatar}`;
    },
  },

  methods: {
    uploadAvatar(file) {
      this.file = file;
      const reader = new FileReader();
      reader.readAsDataURL(file);
      const self = this;
      reader.onload = () => {
        self.avatar = reader.result;
      };
    },
    deleteAvatar() {
      this.avatar = null;
      this.$emit('deleteAvatar');
    },
    close() {
      this.$emit('close');
    },
    save() {
      if (!this.error) {
        return;
      }
      this.$emit('save', { file: this.file, base64: this.avatar });
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
