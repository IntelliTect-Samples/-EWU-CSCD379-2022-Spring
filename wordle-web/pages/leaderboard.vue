<template>
  <v-container fluid fill-height justify-center>
    <v-row justify="center" dense no-gutters>
      <v-col v-for="(i) in scoreNames" :key="i" cols="1" dense no-gutters>
        <v-container class="text-center mx-0 px-1 py-1 my-0">
          <v-card-text>
            {{ i }}
          </v-card-text>
        </v-container>
      </v-col>
      <v-col v-for="(i) in scoreTimes" :key="i" cols="1" dense no-gutters>
        <v-container class="text-center mx-0 px-1 py-1 my-0">
          <v-card-text>
            {{ i }}
          </v-card-text>
        </v-container>
      </v-col>
    </v-row>
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
  scoreNames: string[] = [];
  scoreTimes: number[] = [];



}
</script>
