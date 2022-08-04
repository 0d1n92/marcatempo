<template>
  <v-alert
    border="top"
    color="#2A3B4D"
    id="general-message"
    class="mb-0 text-center"
    dark
    height="50px"
    width="100%"
    dense
  >
    <v-icon class="mr-2">mdi-alert</v-icon>
    {{ message }}
  </v-alert>
</template>

<script>
export default {
  name: 'GeneralErrorMessage',
  props: {
    message: {
      type: String,
      default: '',
    },
  },
};
</script>
<style scoped>
#general-message {
  position: absolute;
  bottom: 0;
  z-index: 1;
}
</style>
