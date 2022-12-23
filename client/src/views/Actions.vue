<template>
  <WireFrameVue>
    <div style="height: 60px, padding-bottom: 10px">
      <v-row no-gutters>
        <v-col md="4" cols="12">
          <multi-select-users
            @onChange="updateOperators"
            @onRemove="removeSelectedOperators"
            :items="users"
            :deleteInput="delateOperators"
          />
        </v-col>
        <v-spacer></v-spacer>
        <v-col md="4" cols="12">
          <interval-dates-picker @setDates="setDates" />
        </v-col>
        <v-spacer></v-spacer>
        <v-col>
          <v-btn icon color="primary" :title="$t('Reload table')">
            <v-icon @click="onReset"> mdi-reload </v-icon>
          </v-btn>
          <v-btn icon color="primary" :title="$t('Export to csv')">
            <v-icon> mdi-file-export-outline </v-icon>
          </v-btn>
        </v-col>
      </v-row>
    </div>
    <!-- to do: vedere ordinameto BE -->
    <v-data-table
      :headers="headers"
      :options.sync="options"
      :items="operators"
      :expanded.sync="expanded"
      :loading="loaded"
      show-expand
      multi-sort
      single-expand
      item-key="name"
      :footer-props="{ 'items-per-page-options': [20, 31, 40, -1] }"
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
      selectedOperators: [],
      loaded: true,
      delateOperators: false,
      dates: [moment(new Date()).format('YYYY-MM-DD'), moment(new Date()).format('YYYY-MM-DD')],
      headers: [
        {
          text: this.$t('Name'),
          align: 'start',
          value: 'firstName',
        },
        { text: this.$t('Lastname'), value: 'lastName' },
        { text: this.$t('Date'), value: 'date' },
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
    options() {
      this.getOperetors();
    },
  },
  methods: {
    setDates(dates) {
      this.dates = dates;
    },
    onReset() {
      this.dates = [moment(new Date()).format('YYYY-MM-DD'), moment(new Date()).format('YYYY-MM-DD')];
      this.selectedOperators = [];
      this.delateOperators = true;
      this.getOperetors();
    },
    updateOperators(selected) {
      if (selected) {
        selected.forEach((x) => {
          this.selectedOperators.push(x.username);
        });
      }
      this.getOperetors();
    },
    removeSelectedOperators(selected) {
      if (selected) {
        this.selectedOperators = [];
        selected.forEach((x) => {
          this.selectedOperators.push(x.username);
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
          pageSize: this.options.itemsPerPage,
          page: this.options.page,
          usersName: this.selectedOperators,
          sortDesc: this.options.sortDesc,
          sortBy: this.options.sortBy,
        },
        {
          headers: { Authorization: this.$store.state.token },
          // eslint-disable-next-line comma-dangle
        }
      )
        .then((response) => {
          this.operators = response.data.data;
          this.loaded = false;
          this.delateOperators = false;
        })
        .catch((error) => {
          this.$store.commit('SetError', `${error}, ${this.$i18n.t('Error.Impossible to get operations')}`);
        });
    },
  },
};
</script>

<style></style>
