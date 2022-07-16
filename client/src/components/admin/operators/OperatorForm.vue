<template>
  <v-card width="500">
    <v-card-title>
      <span class="text-h5">{{ formTitle }}</span>
    </v-card-title>
    <v-card-text>
      <v-container>
        <v-row>
          <v-col cols="12" sm="6" md="4">
            <v-text-field v-model="operator.firstName" label="Name"></v-text-field>
          </v-col>
          <v-col cols="12" sm="6" md="4">
            <v-text-field v-model="operator.lastName" label="Surname"></v-text-field>
          </v-col>
          <v-col cols="12" sm="6" md="4">
            <v-text-field v-model="operator.username" label="Username"></v-text-field>
          </v-col>
          <v-col cols="12" sm="6" md="4">
            <QrcodeVue
              :value="
                JSON.stringify({
                  exit: true,
                  userId: operator.userId,
                  qRcode: operator.qrCode,
                })
              "
              size="200"
            />
          </v-col>
        </v-row>
      </v-container>
    </v-card-text>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn color="blue darken-1" text @click="close"> Cancel </v-btn>
      <v-btn color="blue darken-1" text @click="save"> Save </v-btn>
    </v-card-actions>
  </v-card>
</template>
<script>
import QrcodeVue from 'qrcode.vue';

export default {
  name: 'OperatorForm',
  components: { QrcodeVue },
  props: {
    // eslint-disable-next-line vue/require-prop-type-constructor
    formTitle: '',
    operator: {},
  },
  methods: {
    close() {
      this.$emit('close');
    },
    save() {
      this.$emit('save');
    },
  },
};
</script>
