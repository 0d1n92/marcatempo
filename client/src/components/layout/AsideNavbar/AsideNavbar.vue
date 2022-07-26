<template>
  <div>
    <v-navigation-drawer absolute color="grey lighten-3" expand-on-hover>
      <v-list class="header-nav pt-9">
        <v-list-item>
          <v-list-item-avatar size="90">
            <v-avatar class="d-block" color="grey darken-1" size="90">
              <img :src="`data:image/png;base64,${user.avatar}`" />
            </v-avatar>
          </v-list-item-avatar>
          <v-spacer></v-spacer>
          <v-btn @click="logout" icon color="red" title="logout">
            <v-icon>mdi-location-exit</v-icon>
          </v-btn>
        </v-list-item>
        <v-list-item>
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
  </div>
</template>

<script>
import enumRoles from '../../../enums/enumRoles';

export default {
  name: 'AsideNavabar',
  data() {
    return {
      asideItemNavigation: [
        {
          icon: 'mdi-monitor-dashboard',
          title: 'DashBoard',
          text: 'My dashboard',
          route_name: 'dash-board',
        },
      ],
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
  },
  methods: {
    logout() {
      this.$store.commit('Logout');
      this.$router.push({ name: 'login' });
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
</style>
