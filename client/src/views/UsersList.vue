<template>
  <WireFrameVue>
    <v-data-table :headers="headers" :items="users" sort-by="Name" class="elevation-1">
      <template v-slot:top>
        <v-toolbar flat>
          <v-toolbar-title>Users</v-toolbar-title>
          <v-spacer></v-spacer>
          <v-dialog v-model="dialog" width="80%">
            <template v-slot:activator="{ on, attrs }">
              <v-btn color="primary" dark class="mb-2" v-bind="attrs" v-on="on"> Add Operator </v-btn>
            </template>
            <user-profile-form @save="save" @close="close" :user="editedItem" :formTitle="formTitle" />
          </v-dialog>
          <v-dialog v-model="dialogDelete" max-width="500px">
            <v-card>
              <v-card-title class="text-h5">Are you sure you want to delete this item?</v-card-title>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="closeDelete">Cancel</v-btn>
                <v-btn color="blue darken-1" text @click="deleteItemConfirm">OK</v-btn>
                <v-spacer></v-spacer>
              </v-card-actions>
            </v-card>
          </v-dialog>
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

export default {
  name: 'UserList',
  components: { WireFrameVue, UserProfileForm },
  data: () => ({
    dialog: false,
    dialogDelete: false,
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
  mounted() {
    Axios.get(`${process.env.VUE_APP_ROOT_API}/Users/users-list`, {
      headers: { Authorization: `${localStorage.getItem('token')}` },
    })
      .then((response) => {
        this.users = response.data.users;
      })
      .catch((error) => {
        console.log(`errore + ${error}`);
      });
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? 'Add User' : 'User Profile';
    },
  },
  watch: {
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
      if (this.editedIndex > -1) {
        Object.assign(this.users[this.editedIndex], this.editedItem);
      } else {
        this.users.push(this.editedItem);
      }
      this.close();
    },
  },
};
</script>

<style></style>
