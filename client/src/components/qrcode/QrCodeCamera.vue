<template>
  <!-- se la webcam non funziona mettere props camera='auto' funziona solo in ssl -->
  <qrcode-stream v-if="alertData.reloaded" :track="paintOutline" :camera="camera" @decode="onDecode" @init="onInit">
    <v-btn absolute color="blue-grey" fab @click="switchCamera">
      <v-icon dark>mdi-camera-switch</v-icon>
    </v-btn>
    <div class="validation-pending" v-if="alertData.validation">
      <v-alert :type="alertData.status" :value="alertData.show" outlined>
        {{ alertData.message }}
        {{ alertData.status != 'error' ? `Hour ${alertData.hour}` : '' }}
        <br />
        <v-btn v-if="alertData.status === 'error'" @click="onReload()" color="red" icon>
          <v-icon>mdi-cached</v-icon>
        </v-btn>
      </v-alert>
    </div>
  </qrcode-stream>
</template>

<script>
import { QrcodeStream } from 'vue-qrcode-reader';

export default {
  name: 'QrcodeCamera',
  components: {
    QrcodeStream,
  },
  props: {
    alert: {
      type: Object,
      default: () => {},
    },
  },
  watch: {
    alert(newAlert) {
      this.alertData = newAlert;
    },
  },
  data() {
    return {
      camera: 'rear',
      alertData: this.alert,
    };
  },
  methods: {
    onInit(promise) {
      promise.catch((error) => {
        const triedFrontCamera = this.camera === 'user';
        const triedRearCamera = this.camera === 'rear';
        const cameraMissingError = error.name === 'OverconstrainedError';

        if (triedFrontCamera && cameraMissingError) {
          this.camera = 'rear';
        }

        if (triedRearCamera && cameraMissingError) {
          this.camera = 'user';
        }
      });
    },
    switchCamera() {
      // eslint-disable-next-line default-case
      switch (this.camera) {
        case 'rear':
          this.camera = 'user';
          break;
        case 'user':
          this.camera = 'rear';
          break;
      }
    },
    onDecode(data) {
      this.alertData.validation = true;
      this.$emit('onDecodeAction', data);
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
    onReload() {
      this.alertData = {
        ...this.alertData,
        reloded: false,
        validation: false,
        show: false,
      };
      setTimeout(() => {
        this.alertData = {
          ...this.alertData,
          validation: false,
          reloded: true,
        };
      }, 2000);
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
