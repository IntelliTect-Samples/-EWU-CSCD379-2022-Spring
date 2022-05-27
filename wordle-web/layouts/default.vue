<template>
  <v-app light>
    <v-app-bar :clipped-left="clipped" fixed app color="nav" height="50">
      <router-link to="/" class="title-bar-text">
        <v-toolbar-title>
          <v-icon color="secondary">mdi-cat</v-icon> Generic Word Game
        </v-toolbar-title>
      </router-link>
      <v-spacer />
      <settings-dialog />
      <v-app-bar-nav-icon @click="drawer = true"></v-app-bar-nav-icon>
    </v-app-bar>

    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>

     <v-navigation-drawer v-model="rightDrawer" :right="right" temporary fixed>
      <v-list nav dense>
        <v-list-item-group v-model="group" color="secondary">
          <v-list-item nuxt to="/">
            <v-list-item-icon>
              <v-icon>mdi-home</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Home</v-list-item-title>
          </v-list-item>

          <v-list-item nuxt to="/Game">
            <v-list-item-icon>
              <v-icon>mdi-clippy</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Game</v-list-item-title>
          </v-list-item>

          <v-list-item nuxt to="/ScoreStats">
            <v-list-item-icon>
              <v-icon>mdi-equalizer</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Score Stats</v-list-item-title>
          </v-list-item>

          <v-list-item nuxt to="/About">
            <v-list-item-icon>
              <v-icon>mdi-cat</v-icon>
            </v-list-item-icon>
            <v-list-item-title>About</v-list-item-title>
          </v-list-item>
        </v-list-item-group>

          <v-list-item>
            <v-btn text block nuxt to="/leaderboard">
              Leader Board <v-icon>mdi-equalizer</v-icon>
            </v-btn>
          </v-list-item>

            <v-list-item>
          <v-btn text block nuxt to="/dailywordgame">
            <v-icon>mdi-controller-classic</v-icon>
            <v-spacer></v-spacer>
            Daily Wordle
          </v-btn>
        </v-list-item>

      </v-list>
    </v-navigation-drawer>

    <v-footer :absolute="!fixed" app>
      <v-spacer />
      <span>&copy; Michael Wright {{ new Date().getFullYear() }}</span>
      <v-spacer />
    </v-footer>
  </v-app>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import SettingsDialog from '@/components/settings-dialog.vue'

@Component({ components: { SettingsDialog } })
export default class DefaultLayout extends Vue {
  drawer = false
  dialog = false

  goHome() {}
}
</script>

<style>
.title-bar-text {
  text-decoration: none;
  font-weight: bold;
}
</style>
