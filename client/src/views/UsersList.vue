<template>
  <WireFrameVue>
    <v-data-table
      :options.sync="options"
      :headers="headers"
      :server-items-length="count"
      :loading="loading"
      :items="users"
      sort-by="Name"
      :search="search"
      class="elevation-1"
    >
      <template v-slot:top>
        <v-toolbar flat>
          <v-toolbar-title class="mr-16">Users</v-toolbar-title>
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
              <v-btn color="primary" @click="dialog = true" dark class="mb-2" v-bind="attrs" v-on="on" fab>
                <v-icon>mdi-account-plus</v-icon>
              </v-btn>
            </template>
            <user-profile-form @save="save" @close="close" :user="editedItem" :formTitle="formTitle" />
          </v-dialog>
          <ConfirmDialog
            :show="dialogDelete"
            @agree="deleteItemConfirm"
            title="Delete user"
            :description="`Are you sure you want to delete user ${editedItem.username}?`"
          />
        </v-toolbar>
      </template>
      <template v-slot:item.actions="{ item }">
        <v-hover v-slot="{ hover }">
          <v-btn icon :color="hover ? 'blue' : 'grey darken-1'" @click="editItem(item)" title="Edit">
            <v-icon small> mdi-pencil </v-icon>
          </v-btn>
        </v-hover>
        <v-hover v-slot="{ hover }">
          <v-btn icon :color="hover ? 'red' : 'grey darken-1'" @click="deleteItem(item)" title="Remove">
            <v-icon small> {{ hover ? 'mdi-delete-empty' : 'mdi-delete' }} </v-icon>
          </v-btn>
        </v-hover>
      </template>
      <template v-slot:no-data>
        <v-btn color="primary" @click="initialize"> Reset </v-btn>
      </template>
    </v-data-table>
  </WireFrameVue>
</template>
<script>
import Axios from 'axios';
import WireFrameVue from '../components/layout/WireFrame.vue';
import UserProfileForm from '../components/users/UserProfileForm.vue';
import ConfirmDialog from '../components/layout/Message/ConfirmDialog.vue';

export default {
  name: 'UserList',
  components: { WireFrameVue, UserProfileForm, ConfirmDialog },
  data: () => ({
    search: '',
    dialog: false,
    dialogDelete: false,
    loading: true,
    options: {},
    count: 0,
    qrcode: {},
    headers: [
      {
        text: 'Name',
        align: 'start',
        sortable: false,
        value: 'firstName',
      },
      { text: 'Surname', value: 'lastName' },

      { text: 'Role', value: 'roleName' },
      { text: 'Actions', value: 'actions', sortable: false },
    ],
    users: [],
    editedIndex: -1,
    editedItem: {},
    defaultItem: {
      name: '',
      calories: 0,
      fat: 0,
      carbs: 0,
      protein: 0,
    },
  }),
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? 'Add User' : 'User Profile';
    },
  },
  watch: {
    options: {
      handler() {
        this.onGetUsers();
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
      console.log('change');
      console.log(this.search.length);
      if (this.search.length > 3) {
        this.onGetUsers();
      } else if (this.search.length === 0) {
        this.onGetUsers();
      }
    },
    onGetUsers() {
      const { page, itemsPerPage } = this.options;
      Axios.get(`${process.env.VUE_APP_ROOT_API}/Users/users-list`, {
        headers: { Authorization: this.$store.state.token },
        params: {
          page,
          pageSize: itemsPerPage,
          name: this.search,
        },
      })
        .then((response) => {
          this.users = response.data.data;
          this.count = response.data.count;
          this.loading = false;
        })
        .catch((error) => {
          this.$store.commit('SetError', `${error}, impossible to get users`);
        });
    },
    initialize() {
      // eslint-disable-next-line no-unused-expressions
      this.users;
    },

    editItem(item) {
      this.editedIndex = this.users.indexOf(item);
      this.editedItem = { ...item };
      this.dialog = true;
    },

    deleteItem(item) {
      this.editedIndex = this.users.indexOf(item);
      this.editedItem = { ...item };
      this.dialogDelete = true;
    },

    deleteItemConfirm() {
      Axios.delete(`${process.env.VUE_APP_ROOT_API}/users/${this.editedItem.id}`, {
        headers: { Authorization: this.$store.state.token },
      })
        .then((response) => {
          console.log(response.data);
        })
        .catch((error) => {
          this.$store.state.commit('SetError', `${error}, impossible to delete user`);
        });
      this.users.splice(this.editedIndex, 1);
      this.closeDelete();
    },

    close() {
      this.dialog = false;
      this.onGetUsers();
      this.$nextTick(() => {
        this.editedItem = { ...this.defaultItem };
        this.editedIndex = -1;
      });
    },

    closeDelete() {
      this.dialogDelete = false;
      this.$nextTick(() => {
        this.editedItem = { ...this.defaultItem };
        this.editedIndex = -1;
      });
    },

    save(avatar) {
      this.editedItem.avatar = avatar.base64;
      Object.assign(this.users[this.editedIndex], this.editedItem);
      const formData = new FormData();
      formData.append('Avatar', avatar.file);
      const data = {
        FirstName: this.editedItem.firstName,
        LastName: this.editedItem.lastName,
        UserName: this.editedItem.username,
        Role: this.editedItem.roleName,
        Email: this.editedItem.email,
      };

      Object.entries(data).forEach(([key, val]) => {
        formData.append(key, val);
      });
      Axios.put(`${process.env.VUE_APP_ROOT_API}/users/${this.editedItem.id}`, formData, {
        headers: { Authorization: this.$store.state.token },
      })
        .then(() => {
          this.close();
        })
        .catch((error) => {
          this.$store.commit('SetError', `${error}, impossible to update user`);
        });
    },
  },
};
</script>

<style></style>
