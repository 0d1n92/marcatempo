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
      ></v-text-field>
    </template>
    <v-date-picker v-model="dates" range no-title scrollable>
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
      datesFormat: [moment(new Date()).format('DD/MM/YYYY'), moment(new Date()).format('DD/MM/YYYY')],
      isOpen: false,
    };
  },

  methods: {
    onClick() {
      this.datesFormat = [
        moment(new Date(this.dates[0])).format('DD/MM/YYYY'),
        moment(new Date(this.dates[1])).format('DD/MM/YYYY'),
      ];
      this.$refs.datemenu.save(this.dates);
      this.$emit('setDates', this.dates);
    },
  },
};
</script>

<style scoped>
.v-menu__content {
  margin-top: 10px !important;
}
</style>
