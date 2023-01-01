<template>
  <v-avatar class="d-flex justify-center" color="primary" :size="size">
    <user-avatar :size="size" :base64="base64"></user-avatar>
    <v-expand-transition>
      <div v-if="hover" :title="$t('Update avatar')" style="width: 100%; height: 100%; position: absolute">
        <div class="transition-fast-in-fast-out red darken-2 v-card--reveal text-h2 white--text">
          <v-btn class="icon-top" icon :title="$t('Delete avatar')" @click="deleteAvatar">
            <v-icon :size="iconSize" color="white">mdi-trash-can-outline</v-icon>
          </v-btn>
        </div>
        <div
          class="transition-fast-in-fast-out black darken-2 v-card--reveal t ext-h2 white--text"
          style="cursor: pointer !important"
        >
          <v-icon :size="iconSize" class="icon-bottom" color="white" style="cursor: pointer !important"
            >mdi-file-upload-outline</v-icon
          >
          <v-file-input
            class="input_avatar"
            accept="image/png, image/jpeg, image/bmp"
            prepend-icon=""
            full-width
            v-model="file"
            style="cursor: pointer !important"
            @change="uploadAvatar"
          >
          </v-file-input>
        </div>
      </div>
    </v-expand-transition>
  </v-avatar>
</template>

<script>
import UserAvatar from './UserAvatar.vue';

export default {
  components: { UserAvatar },
  name: 'UserAvatarHover',
  props: {
    size: {
      type: String,
      default: '40',
    },
    base64: {
      type: [String, null],
      default: '',
    },
    hover: {
      type: Boolean,
      default: false,
      required: true,
    },
    iconSize: {
      type: String,
      default: '20',
    },
  },
  data() {
    return {
      file: null,
    };
  },
  methods: {
    uploadAvatar() {
      this.$emit('uploadAvatar', { file: this.file, deleteAvatar: false });
    },
    deleteAvatar() {
      this.$emit('deleteAvatar');
    },
  },
};
</script>

<style scoped>
.v-card--reveal {
  align-items: center;
  display: flex;
  bottom: 0;
  justify-content: center;
  position: relative !important;
  cursor: pointer !important;
  opacity: 0.5;
  width: 100%;
  height: 50% !important;
}
.input_avatar {
  width: 100% !important;
  height: 100%;
  bottom: 0;
  cursor: pointer !important;
  display: block !important;
  position: absolute;
}
</style>
