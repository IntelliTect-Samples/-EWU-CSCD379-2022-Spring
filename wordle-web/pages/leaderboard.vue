<template>
  <v-container fluid fill-height justify-center>
    <v-card width = 80%>
    <v-col justify="center" dense no-gutters>
      <v-row v-for="player in scores" :key="player" dense no-gutters>
        <leaderboardTile> {{player}} </leaderboardTile>
          <!-- <v-col v-for="data in player" :key="data" align="right">
          {{data}}
          </v-col> -->
      </v-row>
    </v-col>
    <v-card-actions>
      <v-btn color="primary" nuxt to="/game"> Back to the Game </v-btn>
    </v-card-actions>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'
import {Player} from "~/scripts/player"
import axios from "axios";

@Component({})
export default class ScoreBoard extends Vue {
  scores: Player[] = [];

      mounted(){ 
        this.getTopTen();
      }
      
      getTopTen(){
        this.$axios.get('/api/Player')
        .then(response => {
            this.scores = response.data;
        })
    }

}
</script>
