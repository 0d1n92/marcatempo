<template>
  <WireFrameVue>
    <!-- <v-data-table :headers="headers" :items="desserts" class="elevation-1"> </v-data-table> -->
    <v-autocomplete
      :disabled="isUpdating"
      :items="users"
      filled
      chips
      color="blue-grey lighten-2"
      label="Select"
      item-text="name"
      item-value="name"
      multiple
    >
      <template v-slot:selection="data">
        <v-chip
          v-bind="data.attrs"
          :input-value="data.selected"
          close
          @click="data.select"
          @click:close="remove(data.item)"
        >
          <v-avatar left>
            <img :src="`data:image/png;base64,${data.item.avatar}`" />
          </v-avatar>
          {{ data.item.firstName }}
        </v-chip>
      </template>
      <template v-slot:item="data">
        <template v-if="typeof data.item !== `object`">
          <v-list-item-content v-text="data.item"></v-list-item-content>
        </template>
        <template v-else>
          <v-list-item-avatar>
             <v-avatar class="d-flex justify-center" color="primary" :size="40">
               <user-avatar :base64="data.item.avatar" :size="40"></user-avatar>
            </v-avatar>
          </v-list-item-avatar>
          <v-list-item-content>
            <v-list-item-title v-html="`${data.item.firstName} ${data.item.lastName}`"></v-list-item-title>
            <v-list-item-subtitle v-html="data.item.roleName"></v-list-item-subtitle>
          </v-list-item-content>
        </template>
      </template>
    </v-autocomplete>
    <v-data-table
      :headers="headers"
      :options.sync="options"
      :items="operators"
      :expanded.sync="expanded"
      show-expand
      single-expand
      item-key="name"
      :search="search"
    >
      <template v-slot:expanded-item="{ headers }">
        <td :colspan="headers.length">
          <div class="row sp-details">
            <div class="col-4 text-right">
              <v-text-field v-model="input1" label="Label"></v-text-field>
            </div>
            <div class="col-4 text-right">
              <v-text-field v-model="input2" label="Label 1"></v-text-field>
            </div>
            <div class="col-4 text-right">
              <v-text-field v-model="input3" label="Label 2"></v-text-field>
            </div>
          </div>
        </td>
      </template>
    </v-data-table>
  </WireFrameVue>
</template>

<script>
import Axios from 'axios';
import WireFrameVue from '../components/layout/WireFrame.vue';
import Utils from '../mixins/utils';
import UserAvatar from '../components/users/UserAvatar.vue';

export default {
  name: 'Actions',
  components: { WireFrameVue, UserAvatar },
  mixins: [Utils],
  data() {
    return {
      expanded: [],
      headers: [
        {
          text: this.$t('Name'),
          align: 'start',
          sortable: false,
          value: 'firstName',
        },
        { text: this.$t('Lastname'), value: 'lastName' },
        { text: this.$t('Total'), value: 'total' },
      ],
      operators: [],
      options: {},
    };
  },
  mounted() {
    this.getOperetors();
    this.onGetUsers(this.options);
  },
  methods: {
    getColor(calories) {
      if (calories > 400) return 'red';
      if (calories > 200) return 'orange';
      return 'green';
    },

    getOperetors() {
      Axios.post(
        `${process.env.VUE_APP_ROOT_API}/action/actionoperators`,
        {
          initDate: '2022-08-17',
          endDate: '2022-08-17',
          pageSize: 10,
          page: 1,
          name: [],
        },
        {
          headers: { Authorization: this.$store.state.token },
        },
      )
        .then((response) => {
          this.operators = response.data.data;
        })
        .catch((error) => {
          this.$store.commit('SetError', `${error}, ${this.$i18n.t('Error.Impossible to get users')}`);
        });
    },
  },
};
</script>

<style></style>
