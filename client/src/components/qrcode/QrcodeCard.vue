<template>
  <div>
    <v-card elevation="3" class="pa-2" width="200">
      <div :class="disabled ? 'overflow-qr' : ''">
        <QrcodeVue level="M" :value="tokenQr" size="180" />
      </div>
      <div class="d-flex">
        <v-btn
          :href="url"
          @click="getLinkQrcode()"
          class="mx-2 white--text"
          title="Download qrcode"
          :disabled="disabled"
          large
          color="red"
          :download="`QrCode_${user.username}`"
        >
          <v-icon dark> mdi-download </v-icon>
        </v-btn>
        <v-btn
          :disabled="disabled"
          @click="showDialog = true"
          class="mx-2 white--text"
          :title="$t('Update qrcode')"
          large
          color="blue"
        >
          <v-icon dark> mdi-cached </v-icon>
        </v-btn>
      </div>
    </v-card>
    <confirm-dialog
      :show="showDialog"
      :title="$t('Update qrcode')"
      :description="`${$t('Dialog.Update qrcode')}\n ${$t('Inreversible operation')}`"
      @agree="updateQrcode"
      @disagree="closeDialog"
    ></confirm-dialog>
  </div>
</template>
<script>
import QrcodeVue from 'qrcode.vue';
import ConfirmDialog from '../layout/Message/ConfirmDialog.vue';

export default {
  name: 'QrcodeCard',
  components: { QrcodeVue, ConfirmDialog },
  props: {
    user: {
      type: Object,
      default: () => ({}),
    },
    disabled: {
      type: Boolean,
      default: false,
    },
  },
  data() {
    return {
      url: '',
      showDialog: false,
    };
  },
  computed: {
    tokenQr() {
      return this.user.qrCode;
    },
  },
  mounted() {
    this.getLinkQrcode();
  },
  update() {
    this.getLinkQrcode();
  },
  methods: {
    getLinkQrcode() {
      const img = this.$el.querySelector('canvas').toDataURL();
      this.url = img;
    },
    updateQrcode() {
      this.$emit('updateQrCode', this.user);
      this.showDialog = false;
    },
    closeDialog() {
      this.showDialog = false;
    },
  },
};
</script>
<style scoped>
.overflow-qr {
  background: white;
  opacity: 0.1;
  z-index: 1;
}
</style>
