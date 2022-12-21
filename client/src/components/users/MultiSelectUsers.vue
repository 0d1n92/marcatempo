<template>
  <v-autocomplete
    @change="onChange"
    v-model="selectedItems"
    prepend-inner-icon="mdi-magnify"
    :items="items"
    filled
    chips
    color="blue-grey lighten-2"
    background-color="white"
    :label="$t('Search')"
    item-text="itemsSelect"
    item-value="itemsSelect"
    multiple
  >
    <template v-slot:selection="data">
      <v-chip v-bind="data.attrs" :input-value="data.selected" close @click:close="remove(data.item)">
        <v-avatar class="d-flex justify-center" color="primary">
          <user-avatar :base64="data.item.avatar" :size="'25'"></user-avatar>
        </v-avatar>
        {{ data.item.firstName }}
      </v-chip>
    </template>
    <template v-slot:item="data">
      <template v-if="typeof data.item !== `object`">
        <v-list-item-content v-text="data.item"></v-list-item-content>
      </template>
      <template v-else>
        <v-list-item-avatar>
          <v-avatar class="d-flex justify-center" color="primary" :size="40">
            <user-avatar :base64="data.item.avatar" :size="'40'"></user-avatar>
          </v-avatar>
        </v-list-item-avatar>
        <v-list-item-content>
          <v-list-item-title v-html="`${data.item.firstName} ${data.item.lastName}`"></v-list-item-title>
          <v-list-item-subtitle v-html="data.item.roleName"></v-list-item-subtitle>
        </v-list-item-content>
      </template>
    </template>
  </v-autocomplete>
</template>
<script>
import UserAvatar from './UserAvatar.vue';

export default {
  components: { UserAvatar },
  name: 'MultiSelectUsers',
  props: {
    items: {
      type: Array,
      default: () => {},
    },
  },
  data() {
    return {
      selectedItems: [],
    };
  },
  methods: {
    remove(item) {
      const index = this.selectedItems.findIndex((op) => op.username === item.username);
      if (index >= 0) this.selectedItems.splice(index, 1);
    },
    onChange() {
      this.$emit('onChange', this.selectedItems);
    },
  },
};
</script>

<style></style>
