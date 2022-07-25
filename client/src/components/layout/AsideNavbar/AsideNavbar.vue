<template>
  <div>
    <v-navigation-drawer absolute color="grey pt-9 lighten-3" mini-variant>
      <v-icon @click="() => (this.show = !this.show)" class="d-block text-center mx-auto mb-9" large>mdi-menu</v-icon>
      <v-list-item v-for="(item, index) in nav" :key="index" link>
        <v-icon v-text="item.icon" :title="item.title" @click="$router.push({ name: item.route_name })"></v-icon>
      </v-list-item>
    </v-navigation-drawer>
 <v-navigation-drawer app width="300" class="ml-15" v-show="show">
      <v-sheet color="grey lighten-5 pa-5" height="200" width="100%">
        <v-container class="grey lighten-5">
          <v-row no-gutters>
            <v-col>
              <div class="d-flex justify-space-between">
                <v-avatar class="d-block" color="grey darken-1" size="65">
                  <img :src="`data:image/png;base64,${user.avatar}`" />
                </v-avatar>
                <v-btn @click="logout" icon color="red" title="logout">
                  <v-icon>mdi-location-exit</v-icon>
                </v-btn>
              </div>
            </v-col>
            <v-col>
              <v-list>
                <v-list-item link>
                  <v-list-item-content>
                    <v-list-item-title class="text-h6">
                      {{ user.fullName }}
                    </v-list-item-title>
                    <v-list-item-subtitle>{{ user.role }}</v-list-item-subtitle>
                  </v-list-item-content>
                </v-list-item>
              </v-list>
            </v-col>
          </v-row>
        </v-container>
      </v-sheet>
      <v-list class="pl-14" shaped>
        <v-list-item v-for="n in 5" :key="n" link>
          <v-list-item-content>
            <v-list-item-title>Item {{ n }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
  </div>
</template>

<script>
export default {
  name: 'AsideNavabar',
  data() {
    return {
      show: false,
      asideItemNavigation: [
        {
          icon: 'mdi-monitor-dashboard',
          title: 'DashBoard',
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
      if (this.user.role === 'Administrator') {
        this.asideItemNavigation = [
          ...this.asideItemNavigation,
          {
            icon: 'mdi-account-group',
            title: 'List of users',
            route_name: 'users',
          },
          {
            icon: 'mdi-table-account',
            title: 'views action',
            route_name: 'actions',
          },
        ];
      } else if (this.user.role === 'Operators') {
        this.asideItemNavigation = [
          ...this.asideItemNavigation,
          {
            icon: 'mdi-qrcode-scan',
            title: 'scan qrcode',
            route_name: 'scan',
          },
        ];
      }
      return this.asideItemNavigation;
    },
  },
};
</script>
