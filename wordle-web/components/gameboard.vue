<template justify="center">
  <v-card width="300" style = "background: linear-gradient(180deg, rgba(20,194,0,1) 0%, rgba(2,59,0,1) 88%, rgba(157,0,0,1) 100%)">
    <v-container>
      <v-row v-for="row in wordleGame.maxGuesses" :key="row" dense>
        <v-col v-for="index in wordleGame.currentWord.maxLetters" :key="index">
          <v-card height="50" :color="letterColor(getLetter(row, index))">
            <v-card-text class="text-center">
              {{ getChar(getLetter(row, index)) }}
            </v-card-text>
          </v-card>
        </v-col>
        <hintButton v-on:guess-from-hint="guessFromHint" v-if="wordleGame.displayHints[row]" :words="wordleGame.hints[row]" />
      </v-row>
    </v-container>
  </v-card>
  
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'
import { WordleGame } from '~/scripts/wordleGame'
import { Word } from '~/scripts/word'
import { Letter } from '~/scripts/letter'
@Component({ components: {} })
export default class GameBoard extends Vue {
  @Prop({ required: true })
  wordleGame!: WordleGame

  guessFromHint(clicked: string){
    console.log("emission caught")
    this.wordleGame.setCurrentWord(clicked);
  }

  getLetter(row: number, index: number): Letter | null {
    const word: Word = this.wordleGame.words[row - 1]
    if (word !== undefined) {
      return word.letters[index - 1] ?? null
    }
    return null
  }

  getChar(letter: Letter | null) {
    if (letter === null) return ''
    return letter.char.toUpperCase()
  }

  letterColor(letter: Letter | null): string {
    if (letter === null) return ''
    return letter.letterColor
  }
}
</script>
