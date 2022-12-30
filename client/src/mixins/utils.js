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
      const { sortBy, sortDesc, page, itemsPerPage } = params;
      Axios.get(`${process.env.VUE_APP_ROOT_API}/Users/users-list`, {
        headers: { Authorization: this.$store.state.token },
        params: {
          page,
          pageSize: itemsPerPage,
          name: '',
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
