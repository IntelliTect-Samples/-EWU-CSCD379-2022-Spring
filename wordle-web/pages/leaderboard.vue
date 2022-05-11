<template>
  <v-container fluid fill-height justify-center>
    <v-card width=80%>
      <v-card-title>Leaderboard</v-card-title>
      <v-col justify="center" dense no-gutters>
        <v-row cols="9">
          <v-col colspan="3">
            <v-card-text>Name</v-card-text>
          </v-col>
          <v-col colspan="2">
            <v-card-text>Games Played</v-card-text>
          </v-col>
          <v-col colspan="2">
            <v-card-text>Average Attempts</v-card-text>
          </v-col>
          <v-col colspan="2">
            <v-card-text>Average Seconds</v-card-text>
          </v-col>
        </v-row>
        <v-card v-if="!getSuccessful" :loading="!getSuccessful">
          <v-card-title>Loading...</v-card-title>
        </v-card>
        <v-container v-if="getSuccessful" fluid>
          <v-row v-for="(player, i) in scores" :key="i" colspan="9" dense no-gutters>
            <v-icon v-if="i === 0" color=yellow>mdi-crown</v-icon>
            <v-icon v-if="i === 1">mdi-crown</v-icon>
            <v-icon v-if="i === 2" color=brown>mdi-crown</v-icon>
            <leaderboardTile :player="player"/>
          </v-row>
        </v-container>
      </v-col>
      <v-card-actions>
        <v-btn color="primary" nuxt to="/game"> Back to the Game</v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import {Component, Vue, Prop} from 'vue-property-decorator'
import {Player} from "~/scripts/player"

@Component({})
export default class ScoreBoard extends Vue {
  scores: Player[] = [];

  getSuccessful: boolean = false;

  created() {
    this.getTopTen();
  }

  getTopTen() {
    this.$axios.get('/api/Player')
      .then(response => {
        this.scores = response.data;
        console.log(this.scores)
        this.getSuccessful = true;
      })
  }

}
</script>
