<!-- eslint-disable no-restricted-syntax -->
<template>
  <v-container style="background: #1976d2; color: white" fluid fill-height>
    <v-row>
      <v-col md="6" offset-md="3">
        <v-expansion-panels>
          <v-expansion-panel
            @click="() => (exit = false)"
            style="background: #4caf50; color: white"
            :disabled="enterAccordion"
          >
            <v-expansion-panel-header disable-icon-rotate>
              Entry
              <template v-slot:actions>
                <v-icon> mdi-door-open </v-icon>
              </template>
            </v-expansion-panel-header>
            <v-expansion-panel-content>
              <qrcode-stream :track="paintOutline" :camera="camera" @decode="onDecode" @init="onInit">
                <v-btn color="blue-grey" fab @click="switchCamera">
                  <v-icon dark>mdi-camera-switch</v-icon>
                </v-btn>
                <v-alert :type="messageEntry.type" :value="messageEntry.show">
                  {{ messageEntry.message }}
                </v-alert>
              </qrcode-stream>
            </v-expansion-panel-content>
          </v-expansion-panel>
          <v-expansion-panel
            @click="onClickAccordionExit"
            style="background: #ff5252; color: white"
            :disabled="exitAccordion"
          >
            <v-expansion-panel-header disable-icon-rotate>
              Exit
              <template v-slot:actions>
                <v-icon> mdi-exit-run</v-icon>
              </template>
            </v-expansion-panel-header>
            <v-expansion-panel-content>
              <qrcode-stream :track="paintOutline" :camera="camera" @decode="onDecode" @init="onInit">
                <v-btn color="blue-grey" fab @click="switchCamera">
                  <v-icon dark>mdi-camera-switch</v-icon>
                </v-btn>
                <v-alert :type="messageExit.type" :value="messageExit.show">
                  {{ messageExit.message }}
                </v-alert>
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
import Axios from 'axios';

export default {
  components: {
    QrcodeStream,
  },
  data() {
    return {
      camera: 'rear',
      exit: true,
      messageEntry: {
        show: false,
        message: '',
        type: 'success',
      },
      messageExit: {
        show: false,
        message: '',
        type: 'success',
      },
      enterAccordion: false,
      exitAccordion: false,
      response: {},
    };
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
  watch: {
    enterAccordion() {
      this.onWhatchAccordion();
    },
    exitAccordion() {
      this.onWhatchAccordion();
    },
  },

  methods: {
    onDecode(data) {
      console.log('scatto');
      this.PostMarket({ token: data, exit: this.exit });
    },

    onClickAccordionExit() {
      this.exit = true;
      this.enterAccordion = true;
      this.exitAccordion = !this.exitAccordion;
    },
    onClickAccordionEnter() {
      this.exit = false;
      this.exitAccordion = true;
      this.enterAccordion = !this.enterAccordion;
    },

    onWhatchAccordion() {
      if (this.enterAccordion && this.exitAccordion) {
        this.enterAccordion = false;
        this.exitAccordion = false;
      }
    },

    PostMarket(payload) {
      Axios.post(`${process.env.VUE_APP_ROOT_API}/qrcodes/postmark`, payload)
        .then((response) => {
          this.response = response.data;
          if (payload.exit) {
            this.messageExit = {
              ...this.messageExit,
              show: true,
              message: response.message,
            };
            return true;
          }
          this.messageEntry = {
            ...this.messageExit,
            show: true,
            message: response.message,
          };
          return true;
        })
        .catch((error) => {
          console.log(`errore + ${error}`);
          if (payload.exit) {
            this.messageExit = {
              type: 'error',
              show: true,
              message: error,
            };
            return true;
          }
          this.messageEntry = {
            type: 'error',
            show: true,
            message: error,
          };
          return true;
        });
    },
    paintOutline(detectedCodes, ctx) {
      detectedCodes.forEach((detectedCode) => {
        const [firstPoint, ...otherPoints] = detectedCode.cornerPoints;
        // eslint-disable-next-line no-param-reassign
        ctx.strokeStyle = 'red';
        ctx.beginPath();
        ctx.moveTo(firstPoint.x, firstPoint.y);
        otherPoints.forEach((item) => {
          ctx.lineTo(item.x, item.y);
        });
        ctx.lineTo(firstPoint.x, firstPoint.y);
        ctx.closePath();
        ctx.stroke();
      });
    },

    switchCamera() {
      if (this.camera === 'front') {
        this.camera = 'rear';
      } else {
        this.camera = 'front';
      }
    },

    QrCodePost(token) {
      const payload = { exit: this.exit, token };
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
.no-active {
  opacity: 0 !important;
}
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
