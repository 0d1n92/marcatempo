<template>
  <WireFrameVue>
    <user-profile-form
      ref="userProfileForm"
      :disableSave="disableSave"
      @save="onSaveUser"
      @saveDisableAvatar="disableSave = false"
      :disableField="disableField"
      @updateQrCode="updateQrCode"
      @close="onClose"
      :validation="validation"
      :user="user"
    ></user-profile-form>
  </WireFrameVue>
</template>

<script>
import Axios from 'axios';
import WireFrameVue from '../components/layout/WireFrame.vue';
import UserProfileForm from '../components/users/UserProfileForm.vue';
import enumRoles from '../enums/enumRoles';

export default {
  name: 'Profile',
  components: { WireFrameVue, UserProfileForm },
  data() {
    return {
      validation: {
        username: null,
        email: null,
      },
      disableSave: true,
      disableField: {
        name: false,
        surname: false,
        role: false,
      },
    };
  },
  computed: {
    user() {
      return this.$store.state.loggedUser;
    },
  },
  mounted() {
    if (this.$store.state.loggedUser.roleId === enumRoles.Operator) {
      this.disableField = {
        name: true,
        surname: true,
        role: true,
      };
    }
  },
  watch: {
    user: {
      handler() {
        this.disableSave = false;
        if (!this.$refs.userProfileForm.$refs.formUser.validate()) {
          this.disableSave = true;
        }
      },
      deep: true,
    },
  },
  methods: {
    onClose() {
      this.$store.dispatch('GetUser');
    },
    updateQrCode(user) {
      this.$store.dispatch('UpdateQrcode', user).then((response) => {
        this.$store.commit('SetQrcode', response);
      });
    },
    onSaveUser(avatar) {
      const formData = new FormData();
      this.$store.commit('UploadAvatar', avatar.base64);
      formData.append('Avatar', avatar.file);
      const data = {
        FirstName: this.user.firstName,
        LastName: this.user.lastName,
        UserName: this.user.username,
        Role: this.user.roleName,
        Email: this.user.email,
        deleteAvatar: avatar.deleteAvatar,
      };

      Object.entries(data).forEach(([key, val]) => {
        formData.append(key, val);
      });
      Axios.put(`${process.env.VUE_APP_ROOT_API}/users/profile`, formData, {
        headers: { Authorization: this.$store.state.token },
      })
        .then(() => {
          this.$store.commit('GetUser', this.user);
          this.disableSave = true;
        })
        .catch((error) => {
          if (error.response.data.message === 'Username already taken') {
            this.validation.username = this.$i18n.t(`Error.${error.response.data.message}`);
          } else if (error.response.data.message === 'Email already taken') {
            this.validation.email = this.$i18n.t(`Error.${error.response.data.message}`);
          } else {
            this.$store.commit(
              'SetError',
              // eslint-disable-next-line comma-dangle
              `${error}, ${this.$i18n.t('Error.UpdateUser')}: ${this.$i18n.t(`Error.${error.response.data.message}`)}`
            );
          }
        });
    },
  },
};
</script>

<style></style>
