<template>
  <div>
    <aside-navbar> </aside-navbar>
    <v-main class="pl-16 pt-16">
      <slot />
    </v-main>
    <general-error-message v-if="$store.state.error" :message="$store.state.messageError"> </general-error-message>
  </div>
</template>

<script>
import AsideNavbar from './AsideNavbar/AsideNavbar.vue';
import GeneralErrorMessage from './Message/GeneralErrorMessage.vue';

export default {
  components: { AsideNavbar, GeneralErrorMessage },
};
</script>
