<template>
  <div>
    <v-btn icon @click="dialog = true">
      <v-icon>mdi-help-circle-outline</v-icon>
    </v-btn>

    <v-dialog v-model="dialog" width="450">
      <v-card>
        <v-card-title>How To Play Definitely Not Wordle</v-card-title>
        <v-card-text>
        You have 6 tries to correctly guess a 5 letter word. After each guess,
        if you select some of the correct letters, the game will give you clues 
        for the final answer.
          <v-list>
            <v-list-item>
              <v-list-item-icon>
                <v-icon large color="success">mdi-file-word-box</v-icon>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title
                  ><b>Green:</b> You got the right letter in the right spot</v-list-item-title
                >
              </v-list-item-content>
            </v-list-item>

            <v-list-item>
              <v-list-item-icon>
                <v-icon large color="warning">mdi-file-word-box</v-icon>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title
                  ><b>Yellow:</b> You got the right letter but it's in the wrong spot</v-list-item-title
                >
              </v-list-item-content>
            </v-list-item>

            <v-list-item>
              <v-list-item-icon>
                <v-icon large color="info">mdi-file-word-box</v-icon>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title
                  ><b>Gray:</b> You got a wrong letter in the wrong spot</v-list-item-title
                >
              </v-list-item-content>
            </v-list-item>
          </v-list>
        </v-card-text>
      </v-card>
    </v-dialog>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
@Component
export default class HelpDialog extends Vue {
  dialog = false
}
</script>