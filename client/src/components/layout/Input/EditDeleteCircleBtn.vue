<template>
  <Fragment>
    <v-hover v-slot="{ hover }">
      <v-btn icon :color="hover ? 'blue' : 'grey darken-1'" @click="editItem()" title="Edit">
        <v-icon small> mdi-pencil </v-icon>
      </v-btn>
    </v-hover>
    <v-hover v-slot="{ hover }">
      <v-btn icon :color="hover ? 'red' : 'grey darken-1'" @click="deleteItem()" title="Remove">
        <v-icon small> {{ hover ? 'mdi-delete-empty' : 'mdi-delete' }} </v-icon>
      </v-btn>
    </v-hover>
  </Fragment>
</template>

<script>
export default {
  name: 'EditCircleBtn',
  methods: {
    deleteItem() {
      this.$emit('onDeleteItem');
    },
    editItem() {
      this.$emit('onEditItem');
    },
  },
};
</script>

<style></style>
