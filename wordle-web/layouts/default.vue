<template>
  <v-app>
    <v-app-bar fixed app>
      <router-link to="/" class="text-h4 font-weight-black no-decoration mx-4" img = "">
         Eagle
      </router-link>
      <v-btn to="/" fab x-large elevation="0"> 
        <v-img 
            max-height="60"
            max-width="60"
            src="https://cdn.ewu.edu/wp-content/themes/ewu-2018/assets/eagle.svg"
          ></v-img>
      </v-btn>
      <v-icon class ="px-4" dark>
        mdi-account-circle
      </v-icon> CurrentlyDoesntChange
      <!-- Tips on how to change: https://github.com/nuxt/nuxt.js/issues/8122#issuecomment-709443008 -->
      <v-spacer />
      <settings-dialog />
    </v-app-bar>
    <v-main>
      <v-container>
        <Nuxt />
        
      </v-container>
    </v-main>
    <v-footer app>href
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
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
