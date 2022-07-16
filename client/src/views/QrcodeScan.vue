<template>
  <v-container fluid fill-height>
    <v-layout align-center justify-center>
      <v-flex xs12 sm8 md4>
        <qrcode-stream :camera="camera" @decode="onDecode" @init="onInit">
          <v-btn color="blue-grey" fab @click="switchCamera">
            <v-icon dark>mdi-camera-switch</v-icon>
          </v-btn>
        </qrcode-stream>
        <v-btn depressed @click="$store.commit('SetIsExit', false)" color="primary"> Entrata </v-btn>
        <v-btn depressed @click="$store.commit('SetIsExit', true)" color="error">Uscita</v-btn>
      </v-flex>
    </v-layout>
  </v-container>
</template>
<script>
import { QrcodeStream } from 'vue-qrcode-reader';

export default {
  components: {
    QrcodeStream,
  },
  data() {
    return {
      camera: 'rear',
    };
  },

  mounted() {
    console.log(this.$store.state.isExit);
  },

  methods: {
    onDecode(data) {
      this.QrCodePost(data);
    },

    switchCamera() {
      if (this.camera === 'front') {
        this.camera = 'rear';
      } else {
        this.camera = 'front';
      }
    },

    QrCodePost(JSONpayload) {
      const payload = JSON.parse(JSONpayload);
      payload.Exit = this.$store.state.isExit;
      this.$store.dispatch('Postmark', payload);
    },
    onInit(promise) {
      promise.catch((error) => {
        const cameraMissingError = error.name === 'OverconstrainedError';
        const triedFrontCamera = this.camera === 'front';

        if (triedFrontCamera && cameraMissingError) {
          // no front camera on this device
        }
      });
    },
  },
};
</script>

<style></style>
