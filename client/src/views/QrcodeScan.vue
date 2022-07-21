<template>
  <v-container fluid fill-height>
    <v-row>
      <v-col md="6" offset-md="3">
        <v-expansion-panels>
          <v-expansion-panel>
            <v-expansion-panel-header> Entrata </v-expansion-panel-header>
            <v-expansion-panel-content>
              <qrcode-stream :camera="camera" @decode="onDecode(data, false)" @init="onInit">
                <v-btn color="blue-grey" fab @click="switchCamera">
                  <v-icon dark>mdi-camera-switch</v-icon>
                </v-btn>
              </qrcode-stream>
              <div v-if="validationSuccess" class="validation-success">This is a URL</div>

              <div v-if="validationFailure" class="validation-failure">This is NOT a URL!</div>

              <div v-if="validationPending" class="validation-pending">Long validation in progress...</div>
            </v-expansion-panel-content>
          </v-expansion-panel>
          <v-expansion-panel>
            <v-expansion-panel-header> Uscita </v-expansion-panel-header>
            <v-expansion-panel-content>
              <qrcode-stream :camera="camera" @decode="onDecode(data, true)" @init="onInit">
                <v-btn color="blue-grey" fab @click="switchCamera">
                  <v-icon dark>mdi-camera-switch</v-icon>
                </v-btn>
              </qrcode-stream>
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-expansion-panels>
      </v-col>
    </v-row>
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

  computed: {
    validationPending() {
      return this.isValid === undefined && this.camera === 'off';
    },

    validationSuccess() {
      return this.isValid === true;
    },

    validationFailure() {
      return this.isValid === false;
    },
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

<style scoped>
.validation-success,
.validation-failure,
.validation-pending {
  position: absolute;
  width: 100%;
  height: 100%;

  background-color: rgba(255, 255, 255, 0.8);
  text-align: center;
  font-weight: bold;
  font-size: 1.4rem;
  padding: 10px;

  display: flex;
  flex-flow: column nowrap;
  justify-content: center;
}
.validation-success {
  color: green;
}
.validation-failure {
  color: red;
}
</style>
