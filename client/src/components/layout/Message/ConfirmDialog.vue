<template>
  <v-row justify="center">
    <v-dialog v-model="open" max-width="700">
      <v-card>
        <v-card-title class="text-h5"> {{ title }}</v-card-title>
        <v-card-text>
          {{ description }}
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="green darken-1" text @click="disagree"> {{ $t('Disagree') }} </v-btn>
          <v-btn color="green darken-1" text @click="agree"> {{ $t('Agree') }} </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script>
export default {
  name: 'ConfirmDialog',
  props: {
    title: {
      type: String,
      default: '',
    },
    description: {
      type: String,
      default: '',
    },
    show: {
      type: Boolean,
      default: false,
    },
  },
  data() {
    return {
      open: false,
    };
  },
  watch: {
    show(newValue) {
      this.open = newValue;
    },
  },
  methods: {
    agree() {
      this.open = false;
      this.$emit('agree');
    },
    disagree() {
      this.open = false;
      this.$emit('disagree');
    },
  },
};
</script>

<style></style>
