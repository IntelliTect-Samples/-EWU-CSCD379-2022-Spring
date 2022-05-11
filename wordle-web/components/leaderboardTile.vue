<template>
  <v-card color ="rgba(35,35,35,255)" class ="mx-3 my-3" fluid shaped width = 100% min-height = "50px" align = right>
    <v-row cols="9">
      <v-col colspan="3">
        <v-card-text>{{ player.name }}</v-card-text>
      </v-col>
      <v-col colspan="2">
        <v-card-text>{{ player.gameCount }}</v-card-text>
      </v-col>
      <v-col colspan="2">
        <v-card-text>{{ player.averageAttempts.toFixed(2) }}</v-card-text>
      </v-col>
      <v-col colspan="2">
        <v-card-text>{{ player.averageSecondsPerGame }}</v-card-text>
      </v-col>
    </v-row>
  </v-card>
</template>

<script lang="ts">
import {Component, Vue, Prop} from 'vue-property-decorator'
import {Player} from "~/scripts/player";

@Component({components: {}})
export default class GameBoard extends Vue {
  @Prop({required: true})
  player!: Player;

  @Prop({required: true})
  index!: number;

}
</script>
