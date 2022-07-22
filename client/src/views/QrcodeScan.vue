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
                <v-btn absolute color="blue-grey" fab @click="switchCamera">
                  <v-icon dark>mdi-camera-switch</v-icon>
                </v-btn>
                <div class="validation-pending" v-if="validation">
                  <v-alert :type="entryAlert.status" :value="entryAlert.show" outlined>
                    {{ `${entryAlert.message} Hour ${entryAlert.hour}` }}
                  </v-alert>
                </div>
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
                <v-btn absolute color="blue-grey" fab @click="switchCamera">
                  <v-icon dark>mdi-camera-switch</v-icon>
                </v-btn>
                <div class="validation-pending" v-if="validation">
                  <v-alert :type="exitAlert.status" :value="exitAlert.show" outlined>
                    {{ `${exitAlert.message} Hour ${exitAlert.hour}` }}
                  </v-alert>
                </div>
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
      validation: false,
      camera: 'rear',
      exit: true,
      enterAccordion: false,
      exitAccordion: false,
      entryAlert: {
        show: false,
        status: 'error',
        message: 'Generic Error',
        hour: '',
      },
      exitAlert: {
        show: false,
        status: 'error',
        message: 'Generic Error',
        hour: '',
      },
      response: {},
    };
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
      this.validation = true;
      this.onPostMarket({ token: data, exit: this.exit });
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

    onPostMarket(payload) {
      Axios.post(`${process.env.VUE_APP_ROOT_API}/qrcodes/postmark`, payload)
        .then((response) => {
          this.response = response.data;
          console.log(response.data);
          if (this.exit) {
            this.exitAlert = {
              show: true,
              status: 'success',
              message: response.data.message,
              hour: response.data.data.exit,
            };
          } else {
            this.entryAlert = {
              show: true,
              status: 'success',
              message: response.data.message,
              hour: response.data.data.entry,
            };
          }
        })
        .catch((error) => {
          console.log(`errore + ${error}`);

          if (this.exit) {
            this.exitAlert = {
              show: true,
              status: 'error',
              message: error,
            };
          } else {
            this.entryAlert = {
              show: true,
              status: 'error',
              message: error,
            };
          }
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

    onInit(promise) {
      promise.catch((error) => {
        const cameraMissingError = error.name === 'OverconstrainedError';
        const triedFrontCamera = this.camera === 'front';

        if (triedFrontCamera && cameraMissingError) {
          this.camera = 'rear';
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
