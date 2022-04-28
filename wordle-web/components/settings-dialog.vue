 <template>
  <div>
  
<v-btn icon @click="toggleDialog">
      <v-icon> mdi-cog </v-icon>
    </v-btn>

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

                  <v-list-item @click="defaultTheme">
                    <v-list-item-title> Default </v-list-item-title>
                  </v-list-item>

                  <v-list-item @click="dreamyPink">
                    <v-list-item-title> Dreamy Pink</v-list-item-title>
                  </v-list-item>

                  <v-list-item @click="purpleTheme">
                    <v-list-item-title> Meg's Purple </v-list-item-title>
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

  toggleDialog() {
    this.dialog = !this.dialog
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

  defaultTheme() {
    const defaultTheme = {
      primary: colors.blue.darken2,
      accent: colors.indigo.darken3,
      secondary: colors.purple.darken3,
      info: colors.teal.lighten1,
      warning: colors.cyan.base,
      error: colors.blue.accent4,
      success: colors.teal.accent3,
    }

    this.$vuetify.theme.themes.dark = defaultTheme
    this.$vuetify.theme.themes.light = defaultTheme
  }

  dreamyPink() {
    const dreamyPink = {
      primary: colors.pink.accent3,
      accent: colors.red.accent4,
      secondary: colors.pink.darken1,
      info: colors.pink.lighten3,
      warning: colors.purple.darken2,
      error: colors.red.lighten2,
      success: colors.pink.accent4,
    }

    this.$vuetify.theme.themes.dark = dreamyPink
    this.$vuetify.theme.themes.light = dreamyPink
  }

}
</script>
