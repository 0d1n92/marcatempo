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
              {{ $t('Entry') }}
              <template v-slot:actions>
                <v-icon> mdi-door-open </v-icon>
              </template>
            </v-expansion-panel-header>
            <v-expansion-panel-content>
              <qr-code-camera :alert="entryAlert" @onDecodeAction="onPostMarker"></qr-code-camera>
            </v-expansion-panel-content>
          </v-expansion-panel>
          <v-expansion-panel
            @click="onClickAccordionExit"
            style="background: #ff5252; color: white"
            :disabled="exitAccordion"
          >
            <v-expansion-panel-header disable-icon-rotate>
              {{ $t('Exit') }}
              <template v-slot:actions>
                <v-icon> mdi-exit-run</v-icon>
              </template>
            </v-expansion-panel-header>
            <v-expansion-panel-content>
              <qr-code-camera :alert="exitAlert" @onDecodeAction="onPostMarker"></qr-code-camera>
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-expansion-panels>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import Axios from 'axios';
import QrCodeCamera from '../components/qrcode/QrCodeCamera.vue';

export default {
  name: 'QrcodeScan',
  components: { QrCodeCamera },
  data() {
    return {
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
      entryAlert: {
        validation: false,
        reloaded: true,
        show: false,
        status: 'error',
        message: this.$i18n.t('Error.Generic'),
        hour: '',
      },
      exitAlert: {
        validation: false,
        reloaded: true,
        show: false,
        status: 'error',
        message: this.$i18n.t('Error.Generic'),
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
    onPostMarker(data) {
      const payload = { token: data, exit: this.exit };
      Axios.post(`${process.env.VUE_APP_ROOT_API}/qrcodes/postmark`, payload)
        .then((response) => {
          this.response = response.data;
          if (this.exit) {
            this.exitAlert = {
              ...this.exitAlert,
              show: true,
              status: 'success',
              message: response.data.message,
              hour: response.data.data.exit,
            };
          } else {
            this.entryAlert = {
              ...this.entryAlert,
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
              ...this.exitAlert,
              show: true,
              message: error,
            };
          } else {
            this.entryAlert = {
              ...this.entryAlert,
              show: true,
              message: error,
            };
          }
        });
    },
  },
};
</script>
