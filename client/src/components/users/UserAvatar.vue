<template>
  <img v-if="base64" :src="base64" />
  <v-icon :size="size" dark v-else> mdi-account-circle </v-icon>
</template>

<script>
export default {
  name: 'UserAvatar',
  props: {
    base64: {
      type: [String, null],
      default: '',
    },
    size: {
      type: String,
      default: '40',
    },
  },
};
</script>
