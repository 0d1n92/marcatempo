<template>
  <Fragment>
    <v-hover v-slot="{ hover }" v-if="remove">
      <v-btn icon :color="hover ? 'red' : 'grey darken-1'" @click="deleteItem()" title="Remove">
        <v-icon small> {{ hover ? 'mdi-delete-empty' : 'mdi-delete' }} </v-icon>
      </v-btn>
    </v-hover>
    <v-hover v-slot="{ hover }" v-if="edit">
      <v-btn icon :color="hover ? 'blue' : 'grey darken-1'" @click="editItem()" title="Edit">
        <v-icon small> mdi-pencil </v-icon>
      </v-btn>
    </v-hover>
    <v-hover v-slot="{ hover }" v-if="save">
      <v-btn icon :disabled="disableSave" :color="hover ? 'green' : 'green darken-1'" title="Save" @click="saveItem()">
        <v-icon small> mdi-content-save </v-icon>
      </v-btn>
    </v-hover>
  </Fragment>
</template>

<script>
import { Fragment } from 'vue-fragment';

export default {
  name: 'EditCircleBtn',
  components: { Fragment },
  props: {
    edit: {
      type: Boolean,
      default: true,
    },
    remove: {
      type: Boolean,
      default: true,
    },
    save: {
      type: Boolean,
      default: true,
    },
    disableSave: {
      type: Boolean,
      default: true,
    },
  },
  methods: {
    deleteItem() {
      this.$emit('onDeleteItem');
    },
    editItem() {
      this.$emit('onEditItem');
    },
    saveItem() {
      this.$emit('onSaveItem');
    },
  },
};
</script>

<style></style>
