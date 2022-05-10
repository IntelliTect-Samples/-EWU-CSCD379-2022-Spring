<template>
  <v-container fluid fill-height justify-center>
    <!-- <v-tooltip bottom>
      <template #activator="{ on, attrs }">
        <v-btn color="primary" nuxt to="/" fab v-bind="attrs" v-on="on">
          <v-icon> mdi-home </v-icon>
        </v-btn>
      </template>
      <span> Go Home </span>
    </v-tooltip> -->

    <!-- <v-card-text class="text-h1 font-weight-black text-center">
      Wordle!
    </v-card-text> -->

    <v-alert v-if="wordleGame.gameOver" width="80%" :type="gameResult.type">
      {{ gameResult.text }}
      <v-btn class="ml-2" @click="resetGame"> Play Again? </v-btn>
    </v-alert>
    <v-dialog
    v-model="leaderboardPrompt"
    elevation="0"
    width="40%"
    :persistent="true">
      <v-card class = "px-0 py-0 mx-0 my-0 justify-center" min-height="200">
        <h1>Enter a name to track your score!</h1>
        <v-divider />
          <v-text-field v-model="playerName" outlined class ="px-15 my-3" />
        <v-card-actions>
          <v-btn @click="leaderboardPrompt=false, submitName()"> Submit Name </v-btn>
          <v-spacer />
          <v-btn @click="leaderboardPrompt=false, cancelNameEntry()"> No Thanks! </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <v-col>
      <v-row>
      Game Time: {{(stopwatch.currentTime/1000/60/60)>1?Math.floor(stopwatch.currentTime/1000/60/60)+":":""}}{{Math.floor(stopwatch.currentTime/1000/60)}}:{{Math.floor(stopwatch.currentTime/1000%60)< 10?'0'+Math.floor(stopwatch.currentTime/1000%60):Math.floor(stopwatch.currentTime/1000%60)}}
      <v-spacer />
      <v-btn plain @click="leaderboardPrompt=true">
        <v-icon dark>
          mdi-account-circle
       </v-icon>
        {{playerName}}
      </v-btn>
      </v-row>
      <!-- Full game time in (h)(h)(:)(m)m:ss-->
      <v-row justify="center">
    <gameboard :wordleGame="wordleGame" />
      </v-row >
      <v-row justify="center">
    <keyboard :wordleGame="wordleGame" />
      </v-row>
    </v-col>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue, Prop} from 'vue-property-decorator'
import { WordsService } from '~/scripts/wordsService'
import { GameState, WordleGame } from '~/scripts/wordleGame'
import KeyBoard from '~/components/keyboard.vue'
import GameBoard from '~/components/gameboard.vue'
import { Word } from '~/scripts/word'
import {Stopwatch} from '~/scripts/stopwatch'
import {Player} from '~/scripts/player'
import axios from 'axios'

@Component({ components: { KeyBoard, GameBoard } })
export default class Game extends Vue {
  playerName: string ="Guest";
  tempName = this.playerName;
  stopwatch: Stopwatch = new Stopwatch();
  unposted: boolean = false; // remains false unless a player is prompted to change their name at the end of the game

  word: string = WordsService.getRandomWord()
  wordleGame = new WordleGame(this.word)
  leaderboardPrompt: boolean = false;

  mounted(){
    if(!this.stopwatch.isRunning){
      this.stopwatch.Start();
    }
  }


  resetGame() {
    this.word = WordsService.getRandomWord()
    this.wordleGame = new WordleGame(this.word)
    this.unposted = false // Should never be needed
  }

  get gameResult() {
    if (this.wordleGame.state === GameState.Won) {
      this.endOfGame();
      return { type: 'success', text: 'Yay! You won!' }
    }
    if (this.wordleGame.state === GameState.Lost) {
      this.endOfGame();
      return { type: 'error', text: `You lost... :( The word was ${this.word}` }
    }
    return { type: '', text: '' }
  }

  endOfGame(){
    this.stopwatch.Stop();
      if(this.playerName === "Guest"){
        this.unposted = true;

        this.leaderboardPrompt = true;
      }
  }

  getLetter(row: number, index: number) {
    const word: Word = this.wordleGame.words[row - 1]
    if (word !== undefined) {
      return word.letters[index - 1]?.char ?? ''
    }
    return ''
  }

  cancelNameEntry(originalName :string) {
    this.playerName = this.tempName;
    if(this.unposted){ // unposted is only true if a player is prompted with a rename at the very end of a game.
      this.postGameToLeaderboard(); // If called during a lost game, the score is not recorded. See PostGameToLeaderboard
    }
  }

  submitName(){
    if(this.playerName ==="")
      this.playerName="Guest"
    this.tempName = this.playerName;
    if(this.unposted){
      this.postGameToLeaderboard();
    }
  }

  postGameToLeaderboard(){

  if (this.wordleGame.state===GameState.Won){
    this.$axios.post('/api/Player',{
    "name": this.playerName,
    "attempts": this.wordleGame.words.length,
    "seconds": Math.round(this.stopwatch.currentTime/1000)
  }).then(function (response) {
    console.log(response);
  })
  }

  this.unposted = false;
  }
}
</script>
