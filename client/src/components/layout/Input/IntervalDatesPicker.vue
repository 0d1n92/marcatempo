<template>
  <v-menu
    ref="datemenu"
    v-model="isOpen"
    :close-on-content-click="false"
    :return-value.sync="dates"
    transition="scale-transition"
    offset-y
    min-width="auto"
    class="mb-10"
  >
    <template v-slot:activator="{ on, attrs }">
      <v-text-field
        height="50"
        v-model="datesFormat"
        :label="$t('Dates Interval')"
        prepend-inner-icon="mdi-calendar"
        hint="DD/MM/YYYY,DD/MM/YYYY"
        v-bind="attrs"
        v-on="on"
        @blur="onBlur"
      ></v-text-field>
    </template>
    <v-date-picker :min="minDate" @input="updateMinDate" v-model="dates" range no-title scrollable>
      <v-btn
        text
        color="primary"
        @click="
          () => {
            isOpen = false;
            this.minDate = null;
          }
        "
      >
        Cancel
      </v-btn>
      <v-btn text color="primary" @click="onClick"> OK </v-btn>
    </v-date-picker>
  </v-menu>
</template>

<script>
import * as moment from 'moment/moment';
import Utils from '../../../mixins/utils';

export default {
  name: 'IntervalDatesPicker',
  mixins: [Utils],
  props: {
    dates: {
      type: Array,
      default: () => [moment(new Date()).format('YYYY-MM-DD'), moment(new Date()).format('YYYY-MM-DD')],
    },
  },
  data() {
    return {
      moment,
      datesFormat: [this.$options.filters.getDate(this.dates[0]), this.$options.filters.getDate(this.dates[1])],
      isOpen: false,
      minDate: null,
    };
  },
  methods: {
    onClick() {
      this.minDate = null;
      this.datesFormat = [this.$options.filters.getDate(this.dates[0]), this.$options.filters.getDate(this.dates[1])];
      this.$refs.datemenu.save(this.dates);
      this.$emit('onSetDates', this.dates);
    },
    updateMinDate(val) {
      const [min, max] = val;
      this.minDate = null;
      this.minDate = min;
      if (max === min) {
        this.minDate = null;
      }
    },

    onBlur() {
      this.datesFormat = this.datesFormat.split(',');
      const dates = this.datesFormat.map((date) => moment(date, 'DD/MM/YYYY').format('YYYY-MM-DD'));
      this.$refs.datemenu.save(dates);
      this.$emit('onBlurDates', dates);
    },
  },
};
</script>

<style scoped>
.v-menu__content {
  margin-top: 10px !important;
}
</style>
