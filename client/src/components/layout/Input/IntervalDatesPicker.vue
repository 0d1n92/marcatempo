<template>
  <v-menu
    ref="datemenu"
    v-model="isOpen"
    :close-on-content-click="false"
    :return-value.sync="dates"
    transition="scale-transition"
    offset-y
    min-width="auto"
  >
    <template v-slot:activator="{ on, attrs }">
      <v-text-field
        v-model="datesFormat"
        :label="$t('Dates Interval')"
        prepend-inner-icon="mdi-calendar"
        readonly
        v-bind="attrs"
        v-on="on"
        height="50"
      ></v-text-field>
    </template>
    <v-date-picker v-model="dates" range no-title scrollable>
      <v-spacer></v-spacer>
      <v-btn text color="primary" @click="isOpen = false"> Cancel </v-btn>
      <v-btn text color="primary" @click="onClick"> OK </v-btn>
    </v-date-picker>
  </v-menu>
</template>

<script>
import * as moment from 'moment/moment';

export default {
  name: 'IntervalDatesPicker',
  data() {
    return {
      moment,
      dates: [],
      datesFormat: [moment(new Date()).format('DD-MM-YYYY'), moment(new Date()).format('DD-MM-YYYY')],
      isOpen: false,
    };
  },

  watch: {
    // eslint-disable-next-line no-unused-vars
    dates(val, old) {
      this.datesFormat = [moment(new Date(val[0])).format('DD-MM-YYYY'), moment(new Date(val[1])).format('DD-MM-YYYY')];
    },
  },
  methods: {
    onClick() {
      this.$refs.datemenu.save(this.dates);
      this.$emit('setDates', this.dates);
    },
  },
};
</script>

<style></style>
