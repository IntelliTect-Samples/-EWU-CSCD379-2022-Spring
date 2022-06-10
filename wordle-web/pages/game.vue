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
     <v-col cols="5" class="d-flex flex-row-reverse">
          <v-dialog v-model="dialog" justify-end persistent max-width="600px">
            <template #activator="{ on, attrs }">
              <v-btn color="primary" dark v-bind="attrs" v-on="on">
                {{ playerName }}
              </v-btn>
            </template>
            <v-card>
              <v-card-text>
                <v-text-field
                  v-model="playerName"
                  type="text"
                  placeholder="Guest"
                ></v-text-field>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="dialog = false">
                  Close
                </v-btn>
                <v-btn
                  color="blue darken-1"
                  text
                  @click=";(dialog = false), setUserName(playerName)"
                >
                  Save
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-col>
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
  playerName: string = "Guest"
  tempName = this.playerName
  seconds: number = 0
  unposted: boolean = false
  startTime: number = 0
  endTime: number = 0
  stopwatch: Stopwatch = new Stopwatch();

  resetGame() {
    this.word = WordsService.getRandomWord()
    this.wordleGame = new WordleGame(this.word)
    this.unposted = false
  }

  get gameResult() {
    this.stopwatch.Stop()
    this.seconds = Math.floor(this.endTime - this.startTime)
    if (this.wordleGame.state === GameState.Won) {
      this.gameOver();
      return { type: 'success', text: 'Yay! You won!' }
    }
    if (this.wordleGame.state === GameState.Lost) {
      return { type: 'error', text: `You lost... :( The word was ${this.word}` }
    }
    return { type: '', text: '' }
  }

   mounted() {
    if (!this.stopwatch.isRunning) {
      this.stopwatch.Start();
    }
    this.retrieveUserName()
  }

  displayTimer(): string {
    return this.stopwatch.getFormattedTime();
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
    }
  }

  cancelNameEntry(originalName :string) {
    this.playerName = this.tempName;
    if(this.unposted){ 
    }
  }

   setUserName(userName: string) {
    localStorage.setItem('userName', userName)
    if (this.wordleGame.state === GameState.Won) {
      this.endGameSave()
    }
  }

  retrieveUserName() {
    const userName = localStorage.getItem('userName')
    if (userName == null) {
      this.playerName = 'Guest'
    } else {
      this.playerName = userName
    }
  }
   endGameSave() {
    this.$axios.post('/api/Players', {
      name: this.playerName,
      attempts: this.wordleGame.words.length,
      seconds: Math.round(this.stopwatch.currentTime / 1000),
    },);
  }
  
}
</script>
