<template>
  <v-container fluid fill-height justify-center>
    <v-col justify="center" dense no-gutters>
      <v-row v-for="(i) in scores" :key="i" cols="1" dense no-gutters>
        <v-container class="text-center mx-0 px-1 py-1 my-0">
          <v-card-text>
            {{ i.playerID }}
            {{ i.name }}
            {{ i.gameCount }}
            {{ i.averageAttempts }}
            {{ i.averageSecondsPerGame}}
          </v-card-text>
        </v-container>
      </v-row>
    </v-col>
    <v-card-actions>
      <v-btn color="primary" nuxt to="/game"> Back to the Game </v-btn>
    </v-card-actions>
  </v-container>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'
import axios from "axios";

@Component({})
export default class ScoreBoard extends Vue {
  scores: any[] = [];

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
