<template>
  <v-container fluid fill-height>
    <v-layout align-center justify-center>
      <v-flex xs12 sm8 md4>
        <qrcode-stream
          camera="auto"
          @decode="onDecode"
          @init="onInit"
        ></qrcode-stream>
        <v-btn
          depressed
          @click="$store.commit('SetIsExit', false)"
          color="primary"
        >
          Entrata
        </v-btn>
        <v-btn depressed @click="$store.commit('SetIsExit', true)" color="error"
          >Uscita</v-btn
        >
      </v-flex>
    </v-layout>
  </v-container>
</template>
<script>
import { QrcodeStream } from "vue-qrcode-reader";
export default {
  components: {
    QrcodeStream,
  },

  mounted() {
    
    console.log(this.$store.state.isExit);
  },

  methods: {
    onDecode(data) {
      console.log("entro", data);
      this.QrCodePost(data);
    },

    QrCodePost(JSONpayload) {
      let payload = JSON.parse(JSONpayload);
      payload.Exit = this.$store.state.isExit;
      console.log(
        "payload è",
        payload,
        "store isexist",
        this.$store.state.isExit
      );
      this.$store.dispatch("Postmark", payload);
    },
    onInit(promise) {
      promise.then(console.log).catch(console.error);
    },
  },
};
</script>

<style></style>
