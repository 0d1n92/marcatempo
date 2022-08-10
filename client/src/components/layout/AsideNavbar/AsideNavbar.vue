<template>
  <v-navigation-drawer
    v-if="user"
    height="100%"
    absolute
    color="grey lighten-3"
    :mini-variant.sync="mini"
    permanent
    app
  >
    <v-list class="header-nav pt-9">
      <v-list-item>
        <v-list-item-avatar v-if="mini" style="margin-left: -7px !important">
          <v-avatar class="d-flex justify-center" color="indigo" size="40">
            <img v-if="avatar" :src="avatar" />
            <span v-else class="white--text text-h6">{{ user.initials }}</span>
          </v-avatar>
        </v-list-item-avatar>
        <v-hover v-slot="{ hover }">
          <v-list-item-avatar v-if="!mini" size="90">
            <user-avatar-hover
              size="90"
              :initials="user.initials"
              :hover="hover"
              :base64="avatar"
              @uploadAvatar="uploadAvatar"
            ></user-avatar-hover>
          </v-list-item-avatar>
        </v-hover>
        <v-spacer></v-spacer>
        <v-btn @click="logout" icon color="red" title="logout">
          <v-icon>mdi-location-exit</v-icon>
        </v-btn>
      </v-list-item>
      <v-list-item v-if="!mini">
        <v-list-item-content>
          <v-list-item-title class="text-h6">
            {{ user.fullName }}
          </v-list-item-title>
          <v-list-item-subtitle>{{ user.role }}</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>
    </v-list>
    <v-list-item
      v-for="(item, index) in nav"
      :key="index"
      :title="item.title"
      @click="$router.push({ name: item.route_name })"
      link
    >
      <v-list-item-icon>
        <v-icon v-text="item.icon"></v-icon>
      </v-list-item-icon>
      <v-list-item-title>{{ item.text }}</v-list-item-title>
    </v-list-item>
  </v-navigation-drawer>
</template>

<script>
import enumRoles from '../../../enums/enumRoles';
import UserAvatarHover from '../../users/UserAvatarHover.vue';

export default {
  components: { UserAvatarHover },
  name: 'AsideNavabar',
  data() {
    return {
      mini: true,
      asideItemNavigation: [
        {
          icon: 'mdi-monitor-dashboard',
          title: 'DashBoard',
          text: 'My dashboard',
          route_name: 'dash-board',
        },
      ],
      rules: [(value) => !value || value.size < 2000000 || 'Avatar size should be less than 2 MB!'],
    };
  },
  mounted() {},
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
    nav() {
      return this.getMenuByRole();
    },
    avatar() {
      return this.user.avatar ? `data:image/png;base64,${this.user.avatar}` : null;
    },
  },
  methods: {
    logout() {
      this.$store.commit('Logout');
      this.$router.push({ name: 'login' });
    },
    uploadAvatar(file) {
      const formData = new FormData();
      formData.append('file', file);
      this.$store.dispatch('UploadAvatar', formData);
    },
    getMenuByRole() {
      if (this.user.role === Object.keys(enumRoles)[1]) {
        this.asideItemNavigation = [
          {
            icon: 'mdi-monitor-dashboard',
            title: 'DashBoard',
            route_name: 'dash-board',
            text: 'My dashboard',
          },
          {
            icon: 'mdi-account-group',
            title: 'List of users',
            route_name: 'users',
            text: 'Users account',
          },
          {
            icon: 'mdi-table-account',
            title: 'views action',
            route_name: 'actions',
            text: 'Users actions',
          },
        ];
      } else if (this.user.role === Object.keys(enumRoles)[2]) {
        this.asideItemNavigation = [
          {
            icon: 'mdi-monitor-dashboard',
            title: 'DashBoard',
            route_name: 'dash-board',
          },
          {
            icon: 'mdi-qrcode-scan',
            title: 'scan qrcode',
            route_name: 'scan',
            text: 'Scan qrcode',
          },
        ];
      }
      return this.asideItemNavigation;
    },
  },
};
</script>
<style scoped>
.header-nav {
  background: #fafafa !important;
}
.absolute {
  position: absolute;
}
.v-card--reveal {
  align-items: center;
  bottom: 0;
  justify-content: center;
  opacity: 0.5;
  position: absolute;
  width: 100%;
}
</style>
