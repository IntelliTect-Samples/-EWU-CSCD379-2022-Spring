<template>
  <v-app>
    <v-app-bar fixed app>
      <v-icon>mdi-home </v-icon>
      <router-link to="/" class="text-h4 font-weight-black no-decoration">
        Wordle
        
      </router-link>
      <v-spacer />
      <settings-dialog />
    </v-app-bar>
    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>
    <v-footer app>
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>

    <v-navigation-drawer
    v-model="drawer"
    absolute
    temporary
    right
    width="200">

      <v-list nav dense>
        <v-list-item nuxt to="/">
          <v-list-item-icon>
            <v-icon>mdi-home</v-icon>
          </v-list-item-icon>
          <v-list-item-title>Home</v-list-item-title>
        </v-list-item>

        <v-list-item nuxt to="/about">
          <v-list-item-icon>
            <v-icon>mdi-information-outline</v-icon>
          </v-list-item-icon>
          <v-list-item-title>About</v-list-item-title>
        </v-list-item>
      </v-list>

    </v-navigation-drawer>
  </v-app>
</template>



<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import SettingsDialog from '@/components/settings-dialog.vue'
@Component({ components: { SettingsDialog } })
export default class DefaultLayout extends Vue {}
</script>

<style>
.no-decoration {
  text-decoration: none;
}
</style>