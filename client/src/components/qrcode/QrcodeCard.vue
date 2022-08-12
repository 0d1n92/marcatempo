<template>
  <div>
    <v-card elevation="3" class="pa-2" width="200">
      <QrcodeVue level="M" :value="tokenQr" size="180" />
      <div class="d-flex">
        <v-btn
          :href="url"
          class="mx-2"
          title="Download qrcode"
          dark
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
          class="mx-2"
          :title="$t('Update qrcode')"
          dark
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
      @agree="UpdateQrcode"
      @disagree="closeDialog"
    ></confirm-dialog>
  </div>
</template>
<script>
import QrcodeVue from 'qrcode.vue';
import Axios from 'axios';
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
      tokenQr: this.user.qrCode,
    };
  },
  watch: {
    tokenQr(newVal) {
      this.tokenQr = newVal;
    },
    user(newVal) {
      this.tokenQr = newVal.qrCode;
    },
  },
  mounted() {
    this.GetLinkQrcode();
  },
  methods: {
    GetLinkQrcode() {
      const img = this.$el.querySelector('canvas').toDataURL();
      this.url = img;
    },
    UpdateQrcode() {
      Axios.post(
        `${process.env.VUE_APP_ROOT_API}/qrcodes/update`,
        { token: this.tokenQr },
        {
          headers: { Authorization: this.$store.state.token },
          // eslint-disable-next-line prettier/prettier
        },
      )
        .then((response) => {
          this.tokenQr = response.data.token;
        })
        .catch((error) => {
          this.$store.commit('SetError', `${error}, impossible to update qrcode`);
        });
    },
    closeDialog() {
      this.showDialog = false;
      console.log('close');
    },
  },
};
</script>
