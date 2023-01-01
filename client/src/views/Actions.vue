v-card-subttile
<template>
  <WireFrameVue>
    <div style="height: 60px, padding-bottom: 10px">
      <v-row no-gutters>
        <v-col md="4" cols="12">
          <multi-select-users
            @onChange="updateOperators"
            @onEditInput="
              (value) => {
                this.name = value;
              }
            "
            @onRemove="removeSelectedOperators"
            :items="users"
            :deleteInput="delateOperators"
          />
        </v-col>
        <v-spacer></v-spacer>
        <v-col md="4" cols="12">
          <interval-dates-picker @onSetDates="setDates" @onBlurDates="setDates" />
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
          <v-btn @click="onDownLoadCsv" icon color="primary" :title="$t('Export to csv')">
            <v-icon> mdi-file-export-outline </v-icon>
          </v-btn>
        </v-col>
      </v-row>
    </div>
    <v-data-table
      :headers="headers"
      :options.sync="options"
      :items="operators"
      :expanded.sync="expanded"
      :loading="loaded"
      show-expand
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
              <v-data-table hide-default-footer :items="item.actions" :headers="headerTableUserAct">
                <!-- eslint-disable-next-line vue/no-unused-vars -->
                <template v-slot:item.entry="{ item }">
                  <v-form :ref="`formDate-${item.id}-entry`">
                    <v-text-field
                      :value="item.entry"
                      :readonly="item.disableModifyAction"
                      @change="onChangeDate(item, $event, 'entry')"
                      :background-color="item.disableModifyAction ? '' : 'grey lighten-2'"
                      :rules="dateRule"
                      :error-messages="item.errorMessage"
                      :success-messages="item.successMessage"
                      hint="DD/MM/YYYY HH:mm"
                    />
                  </v-form>
                </template>
                <template v-slot:item.exit="{ item }">
                  <v-form :ref="`formDate-${item.id}-exit`">
                    <v-text-field
                      @change="onChangeDate(item, $event, 'exit')"
                      :value="item.exit"
                      :background-color="item.disableModifyAction ? '' : 'grey lighten-2'"
                      :readonly="item.disableModifyAction"
                      :rules="dateRule"
                      :error-messages="item.errorMessage"
                      :success-messages="item.successMessage"
                      hint="DD/MM/YYYY HH:mm"
                    >
                    </v-text-field>
                  </v-form>
                </template>
                <template v-slot:item.actions="{ item }">
                  <edit-delete-circle-btn
                    :save="true"
                    :disableSave="item.disableSaveBtn"
                    @onDeleteItem="onDeleteAction(item.id)"
                    @onEditItem="onEditItem(item)"
                    @onSaveItem="onSaveAction(item)"
                    hint="DD/MM/YYYY HH:mm"
                  />
                </template>
              </v-data-table>
            </div>
            <div class="col-md-4 col-12">
              <v-btn color="primary" @click="onClickAddAction(item.index)" icon :title="$t('Add Postmaker')">
                <v-icon>mdi-briefcase-plus-outline</v-icon>
              </v-btn>
            </div>
            <div class="col-md-4 col-12 text-right"></div>
          </div>
        </td>
      </template>
    </v-data-table>
    <v-row>
      <v-spacer></v-spacer>
      <v-spacer></v-spacer>
      <v-spacer></v-spacer>
      <v-spacer></v-spacer>
      <v-col>
        <v-card elevation="0">
          <v-card-title
            >{{ $t('Total') + ': ' }} <span>{{ this.total }}</span></v-card-title
          >
          <v-card-subtitle>{{ $t('Adds up the total users') }}</v-card-subtitle>
          <v-card-actions>
            <v-btn color="primary" @click="onCacolateTotal"> {{ $t('Calcolate') }} </v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </WireFrameVue>
</template>

<script>
import * as moment from 'moment/moment';
import Axios from 'axios';
import WireFrameVue from '../components/layout/WireFrame.vue';
import Utils from '../mixins/utils';
import MultiSelectUsers from '../components/users/MultiSelectUsers.vue';
import IntervalDatesPicker from '../components/layout/Input/IntervalDatesPicker.vue';
import EditDeleteCircleBtn from '../components/layout/Input/EditDeleteCircleBtn.vue';

export default {
  name: 'Actions',
  components: {
    WireFrameVue,
    MultiSelectUsers,
    IntervalDatesPicker,
    EditDeleteCircleBtn,
  },
  mixins: [Utils],
  data() {
    return {
      total: '0,00',
      expanded: [],
      selectedOperators: [],
      disableModifyAction: true,
      disableSave: true,
      dateRule: [
        // eslint-disable-next-line prettier/prettier
        (v) => !v ||
          /^([1-9]|([012][0-9])|(3[01]))\/([0]{0,1}[1-9]|1[012])\/\d\d\d\d [012]{0,1}[0-9]:[0-6][0-9]$/.test(v) ||
          this.$i18n.t('Error.Date must be valid'),
        (v) => !!v || this.$i18n.t('Is required'),
      ],
      headerTableUserAct: [
        {
          text: this.$t('Entry'),
          align: 'start',
          value: 'entry',
        },
        { text: this.$t('Exit'), value: 'exit' },
        { text: this.$t('Actions'), value: 'actions', sortable: false },
      ],
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
      present: 0,
      name: '',
    };
  },
  mounted() {
    this.getOperetors();
    this.onGetUsers({
      page: 1,
      pagesize: 20,
      name: '',
      sortBy: ['FirstName'],
      sortDesc: [false],
    });
  },
  watch: {
    dates() {
      this.getOperetors();
    },
    options() {
      this.getOperetors();
    },
    present() {
      this.getOperetors();
    },
    name(value) {
      if (value !== null && value.length > 3) {
        this.onGetUsers({
          page: 1,
          pagesize: 20,
          name: value,
          sortBy: ['FirstName'],
          sortDesc: [false],
        });
      }
    },
  },
  methods: {
    onCacolateTotal() {
      Axios.post(
        `${process.env.VUE_APP_ROOT_API}/action/total`,
        {
          TotalsUsers: this.operators.map((x) => x.total.toFixed(2)),
        },
        {
          headers: { Authorization: this.$store.state.token },
          // eslint-disable-next-line comma-dangle
        }
      )
        .then((response) => {
          this.total = response.data.totals;
        })
        .catch((error) => {
          this.$store.commit('SetError', `${error}, ${this.$i18n.t('Error.Impossible calculate total')}`);
        });
    },
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
          this.selectedOperators.push(x);
        });
      }
      this.getOperetors();
    },
    removeSelectedOperators(selected) {
      if (selected) {
        this.selectedOperators = [];
        selected.forEach((x) => {
          this.selectedOperators.push(x);
        });
      }
      this.getOperetors();
    },
    onChangeDate(item, event, typeAct) {
      // eslint-disable-next-line no-param-reassign
      item.disableSaveBtn = true;
      // eslint-disable-next-line no-param-reassign
      item.errorMessage = [];
      if (this.$refs[`formDate-${item.id}-entry`].validate() && this.$refs[`formDate-${item.id}-exit`].validate()) {
        // eslint-disable-next-line no-param-reassign
        item.disableSaveBtn = false;
        if (typeAct === 'entry') {
          // eslint-disable-next-line no-param-reassign
          item.entry = event;
        } else {
          // eslint-disable-next-line no-param-reassign
          item.exit = event;
        }
      }
    },
    getOperetors() {
      Axios.post(
        `${process.env.VUE_APP_ROOT_API}/action/actionoperators`,
        {
          initDate: this.dates[0],
          endDate: this.dates[1],
          usersName: this.selectedOperators,
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
          this.operators = response.data.data;
          this.loaded = false;
          this.delateOperators = false;
        })
        .catch((error) => {
          this.$store.commit('SetError', `${error}, ${this.$i18n.t('Error.Impossible to get operations')}`);
        });
    },

    onDeleteAction(id) {
      Axios.delete(`${process.env.VUE_APP_ROOT_API}/action/${id}`, {
        headers: { Authorization: this.$store.state.token },
        // eslint-disable-next-line comma-dangle
      })
        // eslint-disable-next-line no-unused-vars
        .then((response) => {
          this.getOperetors();
        })
        .catch((error) => {
          this.$store.commit('SetError', `${error}, ${this.$i18n.t('Error.Impossible to remove action')}`);
        });
    },
    onSaveAction(item) {
      if (moment(item.entry, 'DD/MM/YYYY HH:mm') > moment(item.exit, 'DD/MM/YYYY HH:mm')) {
        // eslint-disable-next-line no-param-reassign
        item.disableSaveBtn = true;
        // eslint-disable-next-line no-param-reassign
        item.errorMessage = [this.$t('Error.Date Entry')];
        return;
      }
      Axios.put(
        `${process.env.VUE_APP_ROOT_API}/action/${item.id}`,
        {
          Entry: item.entry,
          Exit: item.exit,
        },
        {
          headers: { Authorization: this.$store.state.token },
          // eslint-disable-next-line comma-dangle
        }
      )
        .then(() => {
          // eslint-disable-next-line no-param-reassign
          item.successMessage = this.$t('Success.Update successful');
          this.getOperetors();
          // eslint-disable-next-line no-param-reassign
          item.disableSaveBtn = true;
          setTimeout(() => {
            // eslint-disable-next-line no-param-reassign
            item.successMessage = [];
          }, 5000);
        })
        .catch((error) => {
          this.$store.commit('SetError', `${error}, ${this.$i18n.t('Error.Update failed')}`);
        });
    },
    onEditItem(item) {
      // eslint-disable-next-line no-param-reassign
      item.disableModifyAction = !item.disableModifyAction;
    },

    onDownLoadCsv() {
      const payload = this.operators.map((x) => ({
        date: x.date,
        firstName: x.firstName,
        lastName: x.lastName,
        total: x.total,
        username: x.userName,
      }));

      Axios.post(`${process.env.VUE_APP_ROOT_API}/action/export`, payload, {
        headers: { Authorization: this.$store.state.token },
        responseType: 'blob',
        // eslint-disable-next-line comma-dangle
      })
        .then((response) => {
          const href = URL.createObjectURL(response.data);
          const link = document.createElement('a');
          link.href = href;
          link.setAttribute('download', `postmarker-${moment(new Date()).format('DD/MM/YYYY HH:mm')}.csv`);
          document.body.appendChild(link);
          link.click();
          document.body.removeChild(link);
          URL.revokeObjectURL(href);
        })
        .catch((error) => {
          this.$store.commit('SetError', `${error}, ${this.$i18n.t('Error.Export Falied')}`);
        });
    },

    onClickAddAction(IdOperator) {
      let newAction = {};
      this.operators.forEach((item) => {
        if (item.index === IdOperator) {
          // eslint-disable-next-line no-param-reassign
          newAction = {
            entry: moment(item.date, 'DD/MM/YYYY').format('DD/MM/YYYY HH:mm'),
            exit: moment(item.date, 'DD/MM/YYYY').add(30, 'm').format('DD/MM/YYYY HH:mm'),
            userName: item.userName,
          };
        }
      });

      Axios.post(`${process.env.VUE_APP_ROOT_API}/action`, newAction, {
        headers: { Authorization: this.$store.state.token },
        // eslint-disable-next-line comma-dangle
      })
        .then(() => {
          this.getOperetors();
        })
        .catch((error) => {
          this.$store.commit('SetError', `${error}, ${this.$i18n.t('Error.Impossible to get operations')}`);
        });
    },
  },
};
</script>

<style></style>
