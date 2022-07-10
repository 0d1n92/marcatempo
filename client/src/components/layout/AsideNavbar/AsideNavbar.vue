<template>
  <div>
    <v-navigation-drawer absolute color="grey pt-9 lighten-3" mini-variant>
      <v-icon
        @click="() => (this.show = !this.show)"
        class="d-block text-center mx-auto mb-9"
        large
        >mdi-menu</v-icon
      >
       <v-list-item
          v-for="(item, index) in asideItemNavigation"
          :key="index"
          link
        >
           <v-list-item-icon>
              <v-icon v-text="item.icon"></v-icon>
            </v-list-item-icon>
       </v-list-item>
    </v-navigation-drawer>
    <v-navigation-drawer app width="300" class="ml-15" v-show="show">
      <v-sheet color="grey lighten-5 pa-5" height="128" width="100%">
        <v-container class="grey lighten-5">
          <v-row no-gutters>
            <v-col>
              <v-avatar
                class="d-block"
                color="grey darken-1"
                size="65"
              ></v-avatar>
            </v-col>
            <v-col>
              <v-list>
                <v-list-item link>
                  <v-list-item-content>
                    <v-list-item-title class="text-h6">
                      {{$store.state.loggedUser.firstName + ' ' + $store.state.loggedUser.lastName}}
                    </v-list-item-title>
                    <v-list-item-subtitle
                      >{{ $store.state.loggedUser.roleName }}</v-list-item-subtitle
                    >
                  </v-list-item-content>
                </v-list-item>
              </v-list>
            </v-col>
          </v-row>
        </v-container>
      </v-sheet>  
      <v-list 
        class="pl-14"
        shaped
      >
        <v-list-item
          v-for="n in 5"
          :key="n"
          link
        >
          <v-list-item-content>
            <v-list-item-title>Item {{ n }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>    
    </v-navigation-drawer>    
  </div>
</template>

<script>
export default {
  name: "AsideNavabar",
  data() {
    return {
      show: false,
      asideItemNavigation: [],
    };
  },
  mounted() {
    if ( this.$store.state.loggedUser.roleName == "Administrator") {
      this.asideItemNavigation = [
        {
          icon: "mdi-table-account",
          title:"views operator",
          url:""
        }
      ]
    } else {
      this.asideItemNavigation = [
        {
          icon: "mdi-table-us",
          title:"views operator",
          url:"mdi-qrcode-scan"
        }
      ]
    }
   ;
  },
};
</script>