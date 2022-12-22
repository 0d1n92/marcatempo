<template>
  <WireFrameVue>
    <!-- <v-data-table :headers="headers" :items="desserts" class="elevation-1"> </v-data-table> -->
    <div style="height: 60px, padding-bottom: 10px">
      <v-row no-gutters>
        <v-col md="4" cols="12">
          <multi-select-users @onChange="updateOperators" :items="users" />
        </v-col>
        <v-col></v-col>
        <v-col md="4" cols="12">
          <interval-dates-picker @setDates="setDates" />
        </v-col>
      </v-row>
    </div>
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
import * as moment from 'moment/moment';
import Axios from 'axios';
import WireFrameVue from '../components/layout/WireFrame.vue';
import Utils from '../mixins/utils';
import MultiSelectUsers from '../components/users/MultiSelectUsers.vue';
import IntervalDatesPicker from '../components/layout/Input/IntervalDatesPicker.vue';

export default {
  name: 'Actions',
  components: { WireFrameVue, MultiSelectUsers, IntervalDatesPicker },
  mixins: [Utils],
  data() {
    return {
      expanded: [],
      selectedOperator: [],
      dates: [moment(new Date()).format('YYYY-MM-DD'), moment(new Date()).format('YYYY-MM-DD')],
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
  watch: {
    dates() {
      this.getOperetors();
    },
  },
  methods: {
    setDates(dates) {
      this.dates = dates;
    },
    updateOperators(selected) {
      if (selected) {
        selected.forEach((x) => {
          this.selectedOperator.push(x.username);
        });
      }
      this.getOperetors();
    },
    getOperetors() {
      Axios.post(
        `${process.env.VUE_APP_ROOT_API}/action/actionoperators`,
        {
          initDate: this.dates[0],
          endDate: this.dates[1],
          pageSize: 10,
          page: 1,
          usersName: this.selectedOperator,
        },
        {
          headers: { Authorization: this.$store.state.token },
          // eslint-disable-next-line comma-dangle
        }
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
