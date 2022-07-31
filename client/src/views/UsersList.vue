<template>
  <WireFrameVue>
    <v-data-table
      :options.sync="options"
      :headers="headers"
      :server-items-length="count"
      :loading="loading"
      :items="users"
      sort-by="Name"
      class="elevation-1"
    >
      <template v-slot:top>
        <v-toolbar flat>
          <v-toolbar-title>Users</v-toolbar-title>
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
              <v-btn color="primary" dark class="mb-2" v-bind="attrs" v-on="on" fab>
                <v-icon>mdi-account-plus</v-icon>
              </v-btn>
            </template>
            <user-profile-form @save="save" @close="close" :user="editedItem" :formTitle="formTitle" />
          </v-dialog>
          <ConfirmDialog
            :show="dialogDelete"
            @agree="closeDelete"
            title="Delete user"
            :description="`Are you sure you want to delete user ${editedItem.username}?`"
          />
        </v-toolbar>
      </template>
      <template v-slot:item.actions="{ item }">
        <v-icon small class="mr-2" @click="editItem(item)"> mdi-pencil </v-icon>
        <v-icon small @click="deleteItem(item)"> mdi-delete </v-icon>
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
    onGetUsers() {
      const { page, itemsPerPage } = this.options;
      Axios.get(`${process.env.VUE_APP_ROOT_API}/Users/users-list`, {
        headers: { Authorization: this.$store.state.token },
        params: {
          page,
          pageSize: itemsPerPage,
        },
      })
        .then((response) => {
          this.users = response.data.data;
          this.count = response.data.count;
          this.loading = false;
        })
        .catch((error) => {
          console.log(`errore + ${error}`);
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

    save() {
      /*    if (this.editedIndex > -1) {
        Object.assign(this.users[this.editedIndex], this.editedItem);
      } else {
        this.users.push(this.editedItem);
      } */
      Object.assign(this.users[this.editedIndex], this.editedItem);
      const formData = new FormData();
      formData.append('Avatar', this.editedItem.avatar);
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
      console.log(this.editItem);
      Axios.put(`${process.env.VUE_APP_ROOT_API}/users/${this.editedItem.id}`, formData, {
        headers: { Authorization: this.$store.state.token },
        // eslint-disable-next-line prettier/prettier
      }).then(() => {
        this.close();
      })
        .catch((error) => {
          console.log(`errore + ${error}`);
        });
    },
  },
};
</script>

<style></style>
