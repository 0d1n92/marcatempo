<template>
  <v-card elevation="3" class="pa-2" width="200">
    <QrcodeVue level="M" :value="tokenQr" size="180" />
    <div class="d-flex">
      <v-btn
        :href="url"
        class="mx-2"
        title="download qrcode"
        dark
        large
        color="red"
        :download="`QrCode_${user.username}`"
      >
        <v-icon dark> mdi-download </v-icon>
      </v-btn>
      <v-btn @click="UpdateQrcode" class="mx-2" title="update qrcode" dark large color="blue">
        <v-icon dark> mdi-cached </v-icon>
      </v-btn>
    </div>
  </v-card>
</template>
<script>
import QrcodeVue from 'qrcode.vue';
import Axios from 'axios';

export default {
  name: 'QrcodeCard',
  components: { QrcodeVue },
  props: {
    user: {
      type: Object,
      default: () => ({}),
    },
  },
  data() {
    return {
      url: '',
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
          console.log(`errore + ${error}`);
        });
    },
  },
};
</script>
