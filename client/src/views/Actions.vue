<template>
  <WireFrameVue>
    <!-- <v-data-table :headers="headers" :items="desserts" class="elevation-1"> </v-data-table> -->
    <v-row no-gutters>
      <v-col>
        <multi-select-users @onChange="getOperetors" :items="users" />
      </v-col>
      <v-col> </v-col>
      <v-col> </v-col>
      <v-col> </v-col>
    </v-row>
    <v-data-table
      :headers="headers"
      :options.sync="options"
      :items="operators"
      :expanded.sync="expanded"
      show-expand
      single-expand
      item-key="name"
    >
      <template v-slot:expanded-item="{ headers }">
        <td :colspan="headers.length">
          <div class="row sp-details">
            <div class="col-4 text-right">
              <v-text-field label="Label"></v-text-field>
            </div>
            <div class="col-4 text-right">
              <v-text-field label="Label 1"></v-text-field>
            </div>
            <div class="col-4 text-right">
              <v-text-field label="Label 2"></v-text-field>
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
import MultiSelectUsers from '../components/users/MultiSelectUsers.vue';

export default {
  name: 'Actions',
  components: { WireFrameVue, MultiSelectUsers },
  mixins: [Utils],
  data() {
    return {
      expanded: [],
      selectedOperator: [],
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
    getOperetors(selected) {
      if (selected) {
        selected.forEach((x) => {
          this.selectedOperator.push(x.username);
        });
      }
      Axios.post(
        `${process.env.VUE_APP_ROOT_API}/action/actionoperators`,
        {
          initDate: '2022-08-17',
          endDate: '2022-08-17',
          pageSize: 10,
          page: 1,
          usersName: this.selectedOperator,
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
