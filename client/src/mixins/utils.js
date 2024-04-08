import Axios from 'axios';
import * as moment from 'moment/moment';

export default {
  data() {
    return {
      users: [],
      count: 0,
      loading: false,
    };
  },
  methods: {
    onGetUsers(params) {
      // eslint-disable-next-line object-curly-newline
      const { sortBy, sortDesc, page, itemsPerPage, name } = params;
      Axios.get(`${process.env.VUE_APP_ROOT_API}/Users/users-list`, {
        headers: { Authorization: this.$store.state.token },
        params: {
          page,
          pageSize: itemsPerPage,
          name,
          sortBy: sortBy[0],
          desc: sortDesc[0],
        },
      })
        .then((response) => {
          this.users = response.data.data;
          this.count = response.data.count;
          this.loading = false;
        })
        .catch((error) => {
          this.$store.commit('SetError', `${error}, ${this.$i18n.t('Error.Impossible to get users')}`);
        });
    },
    compressImage(input, maxWidth, maxHeight, quality) {
      const file = input;
      return new Promise((resolve) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = (event) => {
          const img = new Image();
          img.src = event.target.result;
          img.onload = () => {
            let { width } = img;
            let { height } = img;

            // Calcola le nuove dimensioni mantenendo l'aspect ratio
            if (width > maxWidth) {
              height *= maxWidth / width;
              width = maxWidth;
            }
            if (height > maxHeight) {
              width *= maxHeight / height;
              height = maxHeight;
            }

            // Crea un canvas per disegnare l'immagine compressa
            const canvas = document.createElement('canvas');
            const context = canvas.getContext('2d');
            canvas.width = width;
            canvas.height = height;
            context.drawImage(img, 0, 0, width, height);

            // Converti l'immagine compressa in Blob
            canvas.toBlob(
              (blob) => {
                resolve(blob);
              },
              'image/jpeg',
              // eslint-disable-next-line comma-dangle
              quality
            );
          };
        };
      });
    },
  },
  filters: {
    getHour(date) {
      if (moment(date).isValid()) {
        return moment(date).format('HH:mm');
      }
      return moment(date, 'DD/MM/YYYY HH:mm').format('HH:mm');
    },
    getDateTime(date) {
      if (moment(date).isValid()) {
        return moment(date).format('DD/MM/YYYY HH:mm');
      }
      return 'Date not valid';
    },
    getDate(date) {
      return moment(date).format('DD/MM/YYYY');
    },
  },
};
