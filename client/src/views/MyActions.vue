<template>
  <WireFrameVue>
    <div style="height: 60px, padding-bottom: 10px">
      <v-row no-gutters>
        <v-col md="4" cols="12">
          <interval-dates-picker :dates="dates" @onSetDates="setDates" @onBlurDates="setDates" />
        </v-col>
        <v-spacer></v-spacer>
        <v-col md="2" cols="12">
          <v-select
            height="50"
            :items="optionsPresent"
            item-text="text"
            item-value="value"
            prepend-inner-icon="mdi-filter-outline"
            :label="$t('Filter by presents')"
            v-model="present"
          ></v-select>
        </v-col>
        <v-col>
          <v-btn icon color="primary" :title="$t('Reload table')">
            <v-icon @click="onReset"> mdi-reload </v-icon>
          </v-btn>
        </v-col>
      </v-row>
    </div>
    <!--  :expanded.sync="expanded"  show-expand-->
    <v-data-table
      :headers="headers"
      :options.sync="options"
      :expanded.sync="expanded"
      :items="actions"
      show-expand
      :loading="loaded"
      multi-sort
      item-key="index"
      :footer-props="{ 'items-per-page-options': [20, 31, 40, -1] }"
    >
      <template v-slot:item.total="{ item }">
        <span>{{ item.total.toFixed(2) }}</span>
      </template>
      <template v-slot:expanded-item="{ headers, item }">
        <td :colspan="headers.length">
          <div class="row sp-details pt-6 pb-6">
            <div class="col-md-4 col-12">
              <h3>{{ $t('Postmarkers') }}</h3>
              <v-data-table hide-default-footer :items="item.actions" :headers="headerTableUserAct"> </v-data-table>
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
import IntervalDatesPicker from '../components/layout/Input/IntervalDatesPicker.vue';

export default {
  name: 'Actions',
  components: {
    WireFrameVue,
    IntervalDatesPicker,
  },
  data() {
    return {
      expanded: [],
      present: 0,
      dates: [moment().startOf('week').format('YYYY-MM-DD'), moment().endOf('week').format('YYYY-MM-DD')],
      optionsPresent: [
        {
          text: this.$t('All'),
          value: 0,
        },
        {
          text: this.$t('Absent'),
          value: 1,
        },
        {
          text: this.$t('Present'),
          value: 2,
        },
      ],
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
      headerTableUserAct: [
        {
          text: this.$t('Entry'),
          align: 'start',
          value: 'entry',
        },
        { text: this.$t('Exit'), value: 'exit' },
      ],
      actions: [],
      options: {},
      loaded: false,
    };
  },
  methods: {
    setDates(dates) {
      this.dates = dates;
    },
    getAction() {
      Axios.post(
        `${process.env.VUE_APP_ROOT_API}/action/useractions`,
        {
          initDate: this.dates[0],
          endDate: this.dates[1],
          sortDesc: this.options.sortDesc.slice(0, -1),
          sortBy: this.options.sortBy,
          present: this.present,
        },
        {
          headers: { Authorization: this.$store.state.token },
          params: {
            page: this.options.page,
            pagesize: this.options.itemsPerPage,
          },
          // eslint-disable-next-line comma-dangle
        }
      )
        .then((response) => {
          this.actions = response.data.data;
          this.loaded = false;
        })
        .catch((error) => {
          this.$store.commit('SetError', `${error}, ${this.$i18n.t('Error.Impossible to get operations')}`);
        });
    },
    onReset() {
      this.dates = [moment().startOf('week').format('YYYY-MM-DD'), moment().endOf('week').format('YYYY-MM-DD')];
      this.actions();
    },
  },
  watch: {
    dates() {
      this.getAction();
    },
    options() {
      this.getAction();
    },
    present() {
      this.getAction();
    },
  },
  mounted() {
    this.getAction();
  },
};
</script>

<style></style>
