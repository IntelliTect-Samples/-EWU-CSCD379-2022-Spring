<!-- Work needed on this page:
Create a custom component to show available words ❌✅
Add a question mark key to the keyboard. This represents a placeholder for any character ❌✅
Create/extend a word list component with a method called validWords that takes a string with question marks and returns an array of valid words ❌✅
Create unit tests for the validWords method ❌✅
Display the number of valid words based on the entered letters ❌✅
When the number is clicked, show a dialog with all the available words with scrolling if there are too many to show on the screen. ❌✅
When a word is clicked, the word should be entered as the guess but not submitted ❌✅
Add a hover over for the word so it is obvious that it can be clicked. (No CSS) ❌✅
-->

<template>
  <v-container fluid fill-height justify-center>
    <v-tooltip bottom>
      <template #activator="{ on, attrs }">
        <v-btn color="primary" nuxt to="/" fab v-bind="attrs" v-on="on">
          <v-icon> mdi-home </v-icon>
        </v-btn>
      </template>
      <span> Go Home </span>
    </v-tooltip>

    <v-card-text class="text-h1 font-weight-black text-center">
      Wordle!
    </v-card-text>

    <v-alert v-if="wordleGame.gameOver" width="80%" :type="gameResult.type">
      {{ gameResult.text }}
      <v-btn class="ml-2" @click="resetGame"> Play Again? </v-btn>
    </v-alert>

    <game-board :wordleGame="wordleGame" />

    <keyboard :wordleGame="wordleGame" />

    

  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import { WordsService } from '~/scripts/wordsService'
import { GameState, WordleGame } from '~/scripts/wordleGame'
import KeyBoard from '@/components/keyboard.vue'
import GameBoard from '@/components/game-board.vue'
import { Word } from '~/scripts/word'

@Component({ components: { KeyBoard, GameBoard } })
export default class Game extends Vue {
  word: string = WordsService.getRandomWord()
  wordleGame = new WordleGame(this.word)

  resetGame() {
    this.word = WordsService.getRandomWord()
    this.wordleGame = new WordleGame(this.word)
  }

  get gameResult() {
    if (this.wordleGame.state === GameState.Won) {
      return { type: 'success', text: 'Yay! You won!' }
    }
    if (this.wordleGame.state === GameState.Lost) {
      return { type: 'error', text: `You lost... :( The word was ${this.word}` }
    }
    return { type: '', text: '' }
  }

  getLetter(row: number, index: number) {
    const word: Word = this.wordleGame.words[row - 1]
    if (word !== undefined) {
      return word.letters[index - 1]?.char ?? ''
    }
    return ''
  }
}
</script>