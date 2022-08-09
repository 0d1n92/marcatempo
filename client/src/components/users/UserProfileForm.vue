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
              <v-avatar size="200" color="indigo">
                <img v-if="avatar" :src="avatar" />
                <span
                  v-else-if="user && user.firstName && user.lastName && user.firstName[0] && user.lastName[0]"
                  class="white--text text-h5"
                  >{{ UserInitials }}</span
                >
                <v-expand-transition>
                  <div
                    v-if="hover"
                    title="Upload avatar"
                    class="d-flex transition-fast-in-fast-out black darken-2 v-card--reveal text-h2 white--text"
                    style="height: 100%"
                  >
                    <v-icon size="40" class="absolute" color="white">mdi-file-upload-outline</v-icon>
                    <v-file-input
                      class="input_avatar"
                      accept="image/png, image/jpeg, image/bmp"
                      prepend-icon=""
                      full-width
                      height="100%"
                      v-model="file"
                      @change="uploadAvatar"
                    >
                    </v-file-input>
                  </div>
                </v-expand-transition>
              </v-avatar>
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

export default {
  name: 'UsersAdminForm',
  components: { QrcodeCard },
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
    uploadAvatar() {
      const reader = new FileReader();
      reader.readAsDataURL(this.file);
      const self = this;
      reader.onload = () => {
        self.avatar = reader.result;
      };
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
  position: absolute;
  width: 100%;
  height: 40% !important;
}

.input_avatar {
  width: 100% !important;
  position: absolute !important;
  display: block !important;
}
</style>
