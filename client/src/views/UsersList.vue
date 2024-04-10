<template>
  <WireFrameVue>
    <v-data-table
      :options.sync="options"
      :headers="headerTraslate"
      :server-items-length="count"
      :footer-props="{ 'items-per-page-options': [10, 20, 30, 40, -1] }"
      :loading="loading"
      :items="users"
      sort-by="Name"
      :search="search"
      class="elevation-1"
    >
      <template v-slot:top>
        <v-toolbar flat>
          <v-toolbar-title class="mr-16">{{ $t('Users') }}</v-toolbar-title>
          <v-text-field
            v-model="search"
            @input="onSearch"
            append-icon="mdi-magnify"
            label="Search"
            single-line
            hide-details
          ></v-text-field>
          <v-spacer></v-spacer>
          <v-spacer></v-spacer>
          <v-spacer></v-spacer>
          <v-spacer></v-spacer>
          <v-spacer></v-spacer>
          <v-spacer></v-spacer>
          <v-spacer></v-spacer>
          <v-spacer></v-spacer>
          <v-spacer></v-spacer>
          <v-spacer></v-spacer>
          <v-dialog v-model="dialog" width="80%">
            <template v-slot:activator="{ on, attrs }">
              <v-btn color="primary" @click="onClickAddUser" dark class="mb-2" v-bind="attrs" v-on="on" fab>
                <v-icon>mdi-account-plus</v-icon>
              </v-btn>
            </template>
            <v-card>
              <v-card-title class="pa-0">
                <v-toolbar dark color="primary">
                  <v-icon>mdi-account</v-icon>
                  <v-toolbar-title>{{ formTitle }}</v-toolbar-title>
                  <v-spacer></v-spacer>
                   <v-icon  @click="close" color="white" small> mdi-close-thick </v-icon>
                </v-toolbar>
              </v-card-title>
              <user-profile-form
                ref="userProfileForm"
                :disableSave="disableSave"
                :validation="validation"
                :disableQrcode="btnDisable"
                @saveDisableAvatar="disableSave = false"
                @updateQrCode="updateQrCode"
                @save="save"
                @close="close"
                :user="editedItem"
              />
            </v-card>
          </v-dialog>
          <ConfirmDialog
            :show="dialogDelete"
            @agree="deleteItemConfirm"
            :title="$t('Deleting user')"
            :description="`${$t('Are you sure you want to delete user')} ${editedItem.username}?`"
          />
        </v-toolbar>
      </template>
      <template v-slot:item.actions="{ item }">
        <edit-delete-circle-btn :save="false" @onDeleteItem="deleteItem(item)" @onEditItem="editItem(item)" />
      </template>
    </v-data-table>
  </WireFrameVue>
</template>
<script>
import Axios from 'axios';
import WireFrameVue from '../components/layout/WireFrame.vue';
import ConfirmDialog from '../components/layout/Message/ConfirmDialog.vue';
import UserProfileForm from '../components/users/UserProfileForm.vue';
import Utils from '../mixins/utils';
import EditDeleteCircleBtn from '../components/layout/Input/EditDeleteCircleBtn.vue';

export default {
  name: 'UserList',
  components: {
    WireFrameVue,
    ConfirmDialog,
    UserProfileForm,
    EditDeleteCircleBtn,
  },
  mixins: [Utils],
  data() {
    return {
      search: '',
      dialog: false,
      validation: {
        username: null,
        email: null,
      },
      disableSave: true,
      dialogDelete: false,
      btnDisable: false,
      update: true,
      options: {},
      qrcode: {},
      headers: [
        {
          text: 'Name',
          align: 'start',
          value: 'firstName',
        },
        { text: 'Lastname', value: 'lastName' },

        { text: 'Role', value: 'roleName' },
        { text: 'Actions', value: 'actions', sortable: false },
      ],
      editedIndex: -1,
      editedItem: {},
      defaultItem: {
        firstName: '',
        lastName: '',
        username: '',
        email: '',
        qrCode: '',
        roleId: 2,
        roleName: 'Operator',
        avatar: null,
      },
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? this.$i18n.t('Add User') : this.$i18n.t('User Profile');
    },
    headerTraslate() {
      return this.headers.map((header) => ({ ...header, text: this.$i18n.t(header.text) }));
    },
  },
  watch: {
    options: {
      handler() {
        this.onGetUsers(this.options);
      },
      deep: true,
    },
    editedItem: {
      handler() {
        if (!this.$refs.userProfileForm.$refs.formUser.validate()) {
          this.disableSave = true;
        } else {
          this.disableSave = false;
        }
      },
      deep: true,
    },
    dialog(val) {
      // eslint-disable-next-line no-unused-expressions
      val || this.close();
    },
    dialogDelete(val) {
      // eslint-disable-next-line no-unused-expressions
      val || this.closeDelete();
    },
  },

  created() {
    this.initialize();
  },

  methods: {
    onSearch() {
      if (this.search.length > 3) {
        this.onGetUsers({ ...this.options, name: this.search });
      } else if (this.search.length === 0) {
        this.onGetUsers(this.options);
      }
    },
    updateQrCode(user) {
      this.$store.dispatch('UpdateQrcode', user);
    },
    initialize() {
      // eslint-disable-next-line no-unused-expressions
      this.users;
    },

    editItem(item) {
      this.update = true;
      this.editedIndex = this.users.indexOf(item);
      this.editedItem = { ...item };
      this.dialog = true;
    },

    deleteItem(item) {
      this.editedIndex = this.users.indexOf(item);
      this.editedItem = { ...item };
      this.dialogDelete = true;
    },

    close() {
      this.dialog = false;
      this.onGetUsers(this.options);
      this.$nextTick(() => {
        this.editedItem = { ...this.defaultItem };
        this.editedIndex = -1;
      });
      this.btnDisable = false;
    },

    closeDelete() {
      this.dialogDelete = false;
      this.$nextTick(() => {
        this.editedItem = { ...this.defaultItem };
        this.editedIndex = -1;
      });
    },
    onClickAddUser() {
      this.dialog = true;
      this.btnDisable = true;
      this.update = false;
    },
    save(avatar) {
      const formData = this.createFormData(avatar);
      if (this.update) {
        this.callBackUpdate(formData);
        return;
      }
      this.callBackCreate(formData);
    },
    createFormData(avatar) {
      this.editedItem.avatar = avatar.base64;
      if (this.update) {
        Object.assign(this.users[this.editedIndex], this.editedItem);
      }
      const formData = new FormData();
      formData.append('Avatar', avatar.file);
      const data = {
        FirstName: this.editedItem.firstName,
        LastName: this.editedItem.lastName,
        UserName: this.editedItem.username,
        Role: this.editedItem.roleName,
        Email: this.editedItem.email,
        deleteAvatar: avatar.deleteAvatar,
      };

      Object.entries(data).forEach(([key, val]) => {
        formData.append(key, val);
      });

      return formData;
    },
    callBackCreate(formData) {
      Axios.post(`${process.env.VUE_APP_ROOT_API}/users/create`, formData, {
        headers: { Authorization: this.$store.state.token },
      })
        .then(() => {
          this.close();
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
              `${error}, ${this.$i18n.t('Error.CreateUser')}: ${this.$i18n.t(`Error.${error.response.data.message}`)}`
            );
          }
        });
    },
    callBackUpdate(formData) {
      Axios.put(`${process.env.VUE_APP_ROOT_API}/users/${this.editedItem.id}`, formData, {
        headers: { Authorization: this.$store.state.token },
      })
        .then(() => {
          this.close();
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
    deleteItemConfirm() {
      Axios.delete(`${process.env.VUE_APP_ROOT_API}/users/${this.editedItem.id}`, {
        headers: { Authorization: this.$store.state.token },
      })
        // eslint-disable-next-line no-unused-vars
        .then((response) => {})
        .catch((error) => {
          this.$store.state.commit('SetError', `${error}, ${this.$i18n.t('Error.DeleteUser')}`);
        });
      this.users.splice(this.editedIndex, 1);
      this.closeDelete();
    },
  },
};
</script>

<style></style>
