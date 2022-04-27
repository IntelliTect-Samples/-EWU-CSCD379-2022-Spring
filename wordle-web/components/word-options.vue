<template>
  <v-container fill-height justify-center>
    <v-btn
      color="red"
      :disabled="wordleGame.gameOver"
      @click=";[validWords(), showCountButton()]"
    >
      Fill ? word<br>
      (Cheating)
    </v-btn>
    <v-dialog v-model="dialog" width="500">
      <template #activator="{ on, attrs }">
        <v-btn v-show="countButton" v-bind="attrs" v-on="on">
          {{ wordOptions.count }}
        </v-btn>
      </template>

      <v-card>
        <v-card-title class="text-h6 red darken-1">
          Possible Words:
        </v-card-title>
        <v-divider></v-divider>

        <v-card-actions>
          <v-container>
            <v-row
              v-for="i in rowLoopCount()"
              :key="i"
              no-gutters
              justify="center"
            >
              <v-col v-for="n in 3" :key="n" md="4">
                <v-spacer></v-spacer>
                <v-btn
                  color="primary"
                  text
                  @click="
                    ;[
                      (dialog = false),
                      addWord(wordOptions.words[(i - 1) * 3 + (n - 1)]),
                    ]"
                >
                  {{ wordOptions.words[(i - 1) * 3 + (n - 1)] }}
                </v-btn>
              </v-col>
            </v-row>
          </v-container>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'
import { WordleGame } from '~/scripts/wordleGame'
import { wordOptions } from '~/scripts/wordOptions'

@Component({ components: {} })
export default class AvailableWordsButton extends Vue {
  @Prop({ required: true })
  wordleGame!: WordleGame

  countButton: boolean = false
  dialog: boolean = false
  wordOptions: wordOptions = new wordOptions()

  validWords() {
    this.wordOptions.validWords(this.wordleGame.currentWord.text)
  }

  showCountButton() {
    this.countButton = true
  }

  rowLoopCount() {
    return Math.ceil(this.wordOptions.count / 3)
  }

  addWord(word: string) {
    for (let i = 0; i < 5; i++) {
      this.wordleGame.currentWord.removeLetter()
    }

    for (let i = 0; i < 5; i++) {
      this.wordleGame.currentWord.addLetter(word.charAt(i))
    }
  }
}
</script>
