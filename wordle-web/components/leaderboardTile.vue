<template>
  <v-card fluid>
    <slot name="icon"> </slot>
    <v-row cols="9">
      <v-col colspan="3">
        <v-card-text>{{ player.name }}</v-card-text>
      </v-col>
      <v-col colspan="2">
        <v-card-text>{{ player.gameCount }}</v-card-text>
      </v-col>
      <v-col colspan="2">
        <v-card-text>{{ player.averageAttempts }}</v-card-text>
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

}
</script>
