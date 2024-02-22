<template>
  <v-navigation-drawer
    v-if="user"
    height="100%"
    absolute
    class="pb-9"
    color="grey lighten-3"
    :mini-variant.sync="mini"
    permanent
    app
  >
    <div style="height: 100%" @click.stop="mini = !mini">
      <div style="height: calc(100vh - 50px); position: relative;">
        <v-list class="header-nav pt-9">
          <v-list-item>
            <v-list-item-avatar v-if="mini" style="margin-left: -7px !important">
              <v-avatar class="d-flex justify-center" color="primary" :size="40">
                <user-avatar size="35" :base64="avatar" />
              </v-avatar>
            </v-list-item-avatar>
            <v-hover v-slot="{ hover }">
              <v-list-item-avatar v-if="!mini" size="90">
                <user-avatar-hover
                  size="90"
                  :hover="hover"
                  :base64="avatar"
                  @uploadAvatar="uploadAvatar"
                  @deleteAvatar="deleteAvatar"
                ></user-avatar-hover>
              </v-list-item-avatar>
            </v-hover>
            <v-spacer></v-spacer>
            <v-list>
              <v-list-item>
                <v-btn @click="logout" icon color="red" title="logout">
                  <v-icon>mdi-location-exit</v-icon>
                </v-btn>
              </v-list-item>
              <v-list-item>
                <v-btn @click="$router.push({ name: 'profile' })" icon :title="$t('Modify Profile')">
                  <v-icon>mdi-account-cog</v-icon>
                </v-btn>
              </v-list-item>
            </v-list>
          </v-list-item>
          <v-list-item v-if="!mini">
            <v-list-item-content>
              <v-list-item-title class="text-h6">
                {{ user.fullName }}
              </v-list-item-title>
              <v-list-item-subtitle>{{ $t(user.role) }}</v-list-item-subtitle>
            </v-list-item-content>
          </v-list-item>
        </v-list>
        <v-list-item
          v-for="(item, index) in nav"
          :key="index"
          :title="item.title"
          @click="$router.push({ name: item.route_name, params: { user: $store.state.loggedUser.username } })"
          link
        >
          <v-list-item-icon>
            <v-icon v-text="item.icon"></v-icon>
          </v-list-item-icon>
          <v-list-item-title>{{ item.text }}</v-list-item-title>
        </v-list-item>
        <div id="aside-footer">
          <v-select v-model="locale" :items="$i18n.availableLocales"></v-select>
        </div>
      </div>
    </div>
  </v-navigation-drawer>
</template>

<script>
import enumRoles from '../../../enums/enumRoles';
import UserAvatarHover from '../../users/UserAvatarHover.vue';
import UserAvatar from '../../users/UserAvatar.vue';

export default {
  components: { UserAvatarHover, UserAvatar },
  name: 'AsideNavabar',
  data() {
    return {
      mini: true,
      locale: this.$route.params.lang,
      asideItemNavigation: [
        {
          icon: 'mdi-monitor-dashboard',
          title: this.$i18n.t('Dashboard'),
          text: this.$i18n.t('Dashboard'),
          route_name: 'dash-board',
        },
      ],
      rules: [(value) => !value || value.size < 2000000 || 'Avatar size should be less than 2 MB!'],
    };
  },
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
    nav() {
      return this.getMenuByRole();
    },
    avatar() {
      return this.user.avatar ? this.user.avatar : null;
    },
  },
  watch: {
    locale(val) {
      this.$i18n.locale = val;
      this.$router.replace({
        ...this.$router,
        name: this.$route.name,
        params: { lang: val },
      });
    },
  },
  methods: {
    logout() {
      this.$store.commit('Logout');
      this.$router.push({ name: 'login' });
    },
    uploadAvatar(file) {
      const formData = new FormData();
      formData.append('file', file.file);
      this.$store.dispatch('UploadAvatar', formData);
    },
    deleteAvatar() {
      this.$store.dispatch('DeleteAvatar');
    },
    getMenuByRole() {
      if (this.user.role === Object.keys(enumRoles)[1]) {
        this.asideItemNavigation = [
          {
            icon: 'mdi-account-group',
            title: this.$i18n.t('Users account'),
            text: this.$i18n.t('Users account'),
            route_name: 'users',
          },
          {
            icon: 'mdi-account-clock',
            title: this.$i18n.t('Users actions'),
            text: this.$i18n.t('Users actions'),
            route_name: 'actions',
          },
        ];
      } else if (this.user.role === Object.keys(enumRoles)[2]) {
        this.asideItemNavigation = [
          {
            icon: 'mdi-monitor-dashboard',
            title: this.$i18n.t('Dashboard'),
            text: this.$i18n.t('Dashboard'),
            route_name: 'dash-board',
          },
          {
            icon: 'mdi-qrcode-scan',
            title: this.$i18n.t('Scan qrcode'),
            text: this.$i18n.t('Scan qrcode'),
            route_name: 'scan',
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
#aside-footer {
  bottom: 0;
  position: absolute;
  padding: 5px;
  width: 60px;
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
