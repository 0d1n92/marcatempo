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
            <v-avatar size="200" color="indigo">
              <img v-if="user.avatar" :src="`data:image/png;base64,${user.avatar}`" />
              <span v-else class="white--text text-h5">{{ `${user.firstName[0]}${user.lastName[0]}` }}</span>
            </v-avatar>
          </v-col>
          <v-col cols="12" sm="6" md="6">
            <QrcodeCard :user="user" />
          </v-col>
          <v-col cols="12" sm="6" md="4">
            <v-text-field v-model="user.firstName" label="Name"></v-text-field>
          </v-col>
          <v-col cols="12" sm="6" md="4">
            <v-text-field v-model="user.lastName" label="Surname"></v-text-field>
          </v-col>
          <v-col cols="12" sm="6" md="4">
            <v-text-field v-model="user.username" label="Username"></v-text-field>
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
import enumRoles from '../../Enums/RoleEnum';

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
  data() {
    return { roles: Object.getOwnPropertyNames(enumRoles) };
  },
  methods: {
    close() {
      this.$emit('close');
    },
    save() {
      this.$emit('save');
    },
  },
};
</script>
