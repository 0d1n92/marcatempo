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
                      :value="item.entry | getHour"
                      :readonly="item.disableModifyAction"
                      @change="onChangeDate(item, $event, 'entry')"
                      :background-color="item.disableModifyAction ? '' : 'grey lighten-2'"
                      :rules="dateRule"
                      :error-messages="item.errorMessage"
                      :success-messages="item.successMessage"
                      hint="HH:mm"
                    />
                  </v-form>
                </template>
                <template v-slot:item.exit="{ item }">
                  <v-form :ref="`formDate-${item.id}-exit`">
                    <v-text-field
                      @change="onChangeDate(item, $event, 'exit')"
                      :value="item.exit | getHour"
                      :background-color="item.disableModifyAction ? '' : 'grey lighten-2'"
                      :readonly="item.disableModifyAction"
                      :rules="dateRule"
                      :error-messages="item.errorMessage"
                      :success-messages="item.successMessage"
                      hint="HH:mm"
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
            <div class="col-md-4 col-12 text-right"></div>
            <div class="col-md-4 col-12 text-right"></div>
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
      expanded: [],
      selectedOperators: [],
      disableModifyAction: true,
      disableSave: true,
      dateRule: [
        // eslint-disable-next-line prettier/prettier
        (v) => !v ||
          /^[012]{0,1}[0-9]:[0-6][0-9]$/.test(v) ||
          this.$i18n.t('Date must be valid'),
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
          item.entry = moment(item.entry, 'DD/MM/YYYY HH:mm').format('DD/MM/YYYY ') + event;
        } else {
          // eslint-disable-next-line no-param-reassign
          item.exit = moment(item.entry, 'DD/MM/YYYY HH:mm').format('DD/MM/YYYY ') + event;
        }
      }
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
  },
  filters: {
    getHour(date) {
      return moment(date, 'DD/MM/YYYY HH:mm').format('HH:mm');
    },
  },
};
</script>

<style></style>
