<template>
  <div>
    <aside-navbar>
    </aside-navbar>
    <v-main class="pl-0">
      <slot />
    </v-main>
  </div>
</template>

<script>
import AsideNavbar from './AsideNavbar/AsideNavbar.vue'
export default {
  components: { AsideNavbar },

}
</script>

<style>

</style>