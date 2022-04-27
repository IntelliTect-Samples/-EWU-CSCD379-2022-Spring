<template>
    <div>      
        <v-btn
          icon @click ="toggleMenu">
          <v-icon> mdi-hamburger</v-icon>
        </v-btn>

        <v-btn 
          icon @click="toggleDialog">
          <v-icon> mdi-cog </v-icon>
        </v-btn>

         <v-dialog v-model="menu" width="450">
          <v-card>
            <v-container>
              <v-card-title> Menu </v-card-title>
              <v-card-text>
                <v-menu offset-y>
                  <template #activator="{ on, attrs }">
                      <v-btn color="primary" v-bind="attrs" v-on="on" nuxt to="/about" @click="menu=!menu"> About Page </v-btn>
                  </template>
                </v-menu>
              </v-card-text>
            </v-container>
          </v-card>
        </v-dialog>
          

        <v-dialog v-model="dialog" width="450">
          <v-card>
            <v-container>
              <v-card-title> Settings </v-card-title>

              <v-card-text>
                <v-menu offset-y>
                  <template #activator="{ on, attrs }">
                      <v-btn color="primary" dark v-bind="attrs" v-on="on">
                        Pick Theme
                      </v-btn>
                  </template>
                  <v-list>
                    <v-list-item-group>
                      <v-list-item @click="turnOnTheLights">
                        <v-list-item-title> Light Mode </v-list-item-title>
                      </v-list-item>
                      <v-list-item @click="turnOffTheLights">
                        <v-list-item-title> Dark Mode </v-list-item-title>
                      </v-list-item>
                    </v-list-item-group>
                  </v-list>
                </v-menu>

                <v-menu offset-y>
                  <template #activator="{ on, attrs }">
                    <v-btn color="primary" dark v-bind="attrs" v-on="on">
                      Pick A Color
                    </v-btn>
                  </template>
                  <v-list>
                    <v-list-item-group>
                      <v-list-item @click="purpleTheme">
                        <v-list-item-title> Purple </v-list-item-title>
                      </v-list-item>
                    </v-list-item-group>
                  </v-list>
                  <v-list>
                    <v-list-item-group>
                      <v-list-item @click="europaTheme">
                        <v-list-item-title> Europa Theme </v-list-item-title>
                      </v-list-item>
                    </v-list-item-group>
                  </v-list>
                  <v-list>
                    <v-list-item-group>
                      <v-list-item @click="vowOfTheDisciple">
                        <v-list-item-title> Vow Of The Disciple Theme </v-list-item-title>
                      </v-list-item>
                    </v-list-item-group>
                  </v-list>
                </v-menu>
              </v-card-text>
            </v-container>
          </v-card>
        </v-dialog>

  </div>
</template>


<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import { colors } from 'vuetify/lib' 

@Component({})
export default class SettingsDialog extends Vue {
  dialog = false
  menu = false

  toggleDialog() {
    this.dialog = !this.dialog
  }

  toggleMenu() {
    this.menu = !this.menu
  }
  
  turnOnTheLights() {
    this.$vuetify.theme.dark = false
  }

  turnOffTheLights() {
    this.$vuetify.theme.dark = true
  }

  

  purpleTheme() {
    const purpleTheme = {
      primary: colors.deepPurple,
      accent: colors.purple.accent3,
      secondary: colors.purple,
      info: '#03A9F4',
      warning: colors.pink.accent1,
      error: colors.pink.accent3,
      success: colors.deepPurple.lighten4,
    }

    this.$vuetify.theme.themes.dark = purpleTheme
    this.$vuetify.theme.themes.light = purpleTheme
  }

  europaTheme(){
    const europaTheme = {
      primary: colors.lightBlue,
      accent: colors.indigo.accent3,
      secondary: colors.blue,
      info: '#03A9F4',
      warning: colors.blue.accent1,
      error: colors.blueGrey,
      success: colors.green.lighten4,
      background:colors.indigo.lighten5,
    }

    this.$vuetify.theme.themes.dark = europaTheme
    this.$vuetify.theme.themes.light = europaTheme
  }
  
   vowOfTheDisciple(){
    const vowOfTheEurope = {
      primary: colors.red,
      accent: colors.red.accent3,
      secondary: colors.red,
      info: '#03A9F4',
      warning: colors.orange.darken4,
      error: colors.red,
      success: colors.green,
      background:colors.red.lighten5,
      gradient:colors.blue,
    }

    this.$vuetify.theme.themes.dark = vowOfTheEurope
    this.$vuetify.theme.themes.light = vowOfTheEurope
  }
}
</script>

