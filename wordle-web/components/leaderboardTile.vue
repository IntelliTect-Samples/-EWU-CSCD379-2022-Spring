<template>
  <v-card>
    <slot name="icon"></slot>
    <v-row>
      <v-col>
        <v-card-text>{{ player.name }}</v-card-text>
      </v-col>
      <v-col>
        <v-card-text>{{ player.gameCount }}</v-card-text>
      </v-col>
      <v-col>
        <v-card-text>{{ player.averageAttempts }}</v-card-text>
      </v-col>
      <v-col>
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
