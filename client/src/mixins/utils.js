import Axios from 'axios';

export default {
  data() {
    return {
      users: [],
      count: 0,
      loading: false,
    };
  },
  computed: {
    userInitials() {
      if (this.user.lastName && this.user.firstName) {
        if (this.user.firstName[0] && this.user.firstName[0]) {
          return `${this.user.firstName[0]}${this.user.lastName[0]}`;
        }
      }
      return '';
    },
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
};
