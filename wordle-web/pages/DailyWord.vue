<template>
  <v-container fluid fill-height class="pa-0">
    <v-btn
      v-if="!isMobile()"
      outlined
      absolute
      top
      right
      color="primary"
      @click="dialog = true"
    >
      <v-icon primary> mdi-account </v-icon>
      {{ playerName }}
    </v-btn>

    <v-dialog v-model="dialog" width="450" persistent>
      <v-card>
        <v-card-title>Enter Your Name Here Please</v-card-title>
        <v-card-text>
          Add you name to our score board so you can save your game scores!
          <v-text-field v-model="playerName" type="text" placeholder="Guest">
          </v-text-field>
        </v-card-text>
        <v-card-actions>
          <v-btn @click=";(dialog = false), setUserName(playerName)">
            Save
          </v-btn>
          <v-btn @click="dialog = false"> I prefer to remain nameless </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    
    <v-row>
      <v-spacer />
      <v-col cols="12" sm="8" md="6" 
        justify="center" 
        align="center" 
        class="text-h6 font-weight-bold">
        Daily Word Game
      </v-col>
      <v-spacer />
    </v-row>

    <v-row v-if="isMobile()">
      <v-btn
        block
        small
        tile
        color="primary"
        class="mt-2 mb-2"
        @click="dialog = true"
      >
        <v-icon primary> mdi-account </v-icon>
        {{ playerName }}
      </v-btn>
    </v-row>

    <v-row>
      <v-spacer />
      <v-alert v-if="wordleGame.gameOver" :type="gameResult.type" width="450">
        {{ gameResult.text }}
      </v-alert>
      <v-spacer />
    </v-row>

    <game-board :wordle-game="wordleGame" />

    <keyboard :wordle-game="wordleGame" />

    <v-overlay v-if="overlay">
      <v-progress-circular indeterminate absolute size="64">
      </v-progress-circular>
      <br />
      <v-chip class="ma-2" outlined> Getting Daily Word ... </v-chip>
    </v-overlay>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import { GameState, WordleGame } from '~/scripts/wordleGame'
import KeyBoard from '@/components/keyboard.vue'
import GameBoard from '@/components/game-board.vue'
import { Word } from '~/scripts/word'
@Component({ components: { KeyBoard, GameBoard } })
export default class DailyWordGame extends Vue {
  pageName = 'Daily Words'
  word: string = ''
  wordleGame = new WordleGame(this.word)
  playerName = ''
  dialog = false
  isLoaded: boolean = false
  timeInSeconds: number = 0
  startTime: number = 0
  endTime: number = 0
  intervalID: any
  overlay = true
  month = 0
  day = 0
  year = 0
  isMobile() {
    return this.$vuetify.breakpoint.xsOnly
  }
  mounted() {
    setTimeout(() => this.startTimer(), 5000)
    this.retrieveUserName()
    const currentDate = new Date()
    this.month = currentDate.getMonth() + 1
    this.year = currentDate.getFullYear()
    this.day = currentDate.getDate()
    this.getDailyWord()
  }
  getDailyWord() {
    const date =
      this.month.toString() +
      '/' +
      this.day.toString() +
      '/' +
      this.year.toString()
    this.overlay = true
    this.$axios
      .get('/DateWord', { params: { date } })
      .then((response) => {
        this.word = response.data
      })
      .finally(() => {
        this.overlay = false
        this.wordleGame = new WordleGame(this.word)
      })
  }
  get gameResult() {
    this.stopTimer()
    this.timeInSeconds = Math.floor(this.endTime - this.startTime)
    if (this.wordleGame.state === GameState.Won) {
      if (
        this.playerName.toLocaleLowerCase() !== 'guest' &&
        this.playerName !== ''
      ) {
        this.endGameSave()
      } else {
        this.dialog = true
      }
      return { type: 'success', text: 'You won! :^)' }
    }
    if (this.wordleGame.state === GameState.Lost) {
      return {
        type: 'error',
        text: `You lost... :^( The word was ${this.word}`,
      }
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
  retrieveUserName() {
    const userName = localStorage.getItem('userName')
    if (userName == null) {
      this.playerName = 'Guest'
    } else {
      this.playerName = userName
    }
  }
  setUserName(userName: string) {
    localStorage.setItem('userName', userName)
    if (this.wordleGame.state === GameState.Won) {
      this.endGameSave()
    }
  }
  startTimer() {
    this.startTime = Date.now() / 1000
    this.intervalID = setInterval(this.updateTimer, 1000)
  }
  updateTimer() {
    this.timeInSeconds = Math.floor(Date.now() / 1000 - this.startTime)
  }
  stopTimer() {
    this.endTime = Date.now() / 1000
    clearInterval(this.intervalID)
  }
  endGameSave() {
    this.$axios.post('/api/Players', {
      name: this.playerName,
      attempts: this.wordleGame.words.length,
      seconds: this.timeInSeconds,
    })
    this.$axios.post('/DateWord/CreateDateWord', {
      month: this.month,
      day: this.day,
      year: this.year,
      number0fAttempts: this.wordleGame.words.length,
      seconds: this.timeInSeconds,
      playerName: this.playerName,
    })
  }
}
</script>