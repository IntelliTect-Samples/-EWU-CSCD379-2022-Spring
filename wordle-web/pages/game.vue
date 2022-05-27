<template>
  <v-container fluid fill-height justify-center>
    <v-alert v-if="wordleGame.gameOver" width="80%" :type="gameResult.type">
      {{ gameResult.text }}
      <v-btn class="ml-2" @click="resetGame"> Play Again? </v-btn>
    </v-alert>

    <v-dialog
    v-model="leaderboard"
    elevation="0"
    width="50%"
    :persistent="true">
      <v-card class = "px-0 py-0 mx-0 my-0 justify-center" min-height="200">
        <h1>Create your username!!</h1>
        <v-divider />
          <v-text-field v-model="playerName" outlined class ="px-15 my-3" />
            <v-card-actions>
              <v-btn @click="leaderboard=false, submitName()"> Please enter your username here </v-btn>
              <v-spacer />
              <v-btn @click="leaderboard=false, cancelNameEntry()"> I prefer to remain nameless </v-btn>
            </v-card-actions>
      </v-card>
    </v-dialog>
      <v-btn plain @click="leaderboard=true">
        <v-icon dark>
          mdi-circle
       </v-icon>
        {{playerName}}
      </v-btn>
      


    <game-board :wordle-game="wordleGame" />

    <keyboard :wordle-game="wordleGame" />
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import { WordsService } from '~/scripts/wordsService'
import { GameState, WordleGame } from '~/scripts/wordleGame'
import KeyBoard from '@/components/keyboard.vue'
import GameBoard from '@/components/game-board.vue'
import { Word } from '~/scripts/word'
import {Stopwatch} from '~/scripts/stopwatch'
import {Player} from '~/scripts/player'
import axios from 'axios'


@Component({ components: { KeyBoard, GameBoard } })
export default class Game extends Vue {
  word: string = WordsService.getRandomWord()
  wordleGame = new WordleGame(this.word)
  playerName: string = "Guest";
  tempName = this.playerName;
  unposted: boolean = false;

  resetGame() {
    this.word = WordsService.getRandomWord()
    this.wordleGame = new WordleGame(this.word)
    this.unposted = false
  }

  get gameResult() {
    if (this.wordleGame.state === GameState.Won) {
      this.gameOver();
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

  gameOver(){
    if(this.playerName === "Guest"){
      this.unposted = true;
    }
  }

  submitName(){
    if(this.playerName ==="")
      this.playerName="Guest"
    this.tempName = this.playerName;
    if(this.unposted){
      //something. I think submit to leaderboard
    }
  }

  cancelNameEntry(originalName :string) {
    this.playerName = this.tempName;
    if(this.unposted){ 
      //something. I think submit to leaderboard
    }
  }
}
</script>
