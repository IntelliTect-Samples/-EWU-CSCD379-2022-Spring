<template>
  <v-container fluid fill-height justify-center>
    <v-card width=80%>
      <v-col  v-if="getSuccessful" justify="center" dense no-gutters>
        <v-row v-for="(player, i) in scores" :key="i" dense no-gutters >
          <leaderboardTile :player="player">
            <slot name="icon">
              <v-icon v-if="i === 1">mdi-crown</v-icon>
            </slot>
          </leaderboardTile>
        </v-row>
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
