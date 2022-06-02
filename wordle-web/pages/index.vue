<template>
  <div>
    <v-row justify="center" align="center">
      <v-col cols="12" sm="8" md="6" justify="center" align="center">
        <v-spacer />
        <game-logo-text />
        <v-spacer />
      </v-col>
    </v-row>

    <v-row justify="center" align="center">
      <v-col cols="12" sm="8" md="6">
        <v-card class="pa-5">
          <v-card-text>
            <p>
              This game is an original word game that is fun for the whole
              family! This game will be the highlight at all your parties.
            </p>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>

    <v-row>
      <v-spacer />
      <v-col cols="12" sm="12" md="4">
        <v-btn block color="primary" nuxt to="/Game">
          <v-icon> mdi-cat </v-icon>
          Play the Game
        </v-btn>
      </v-col>
      <v-col cols="12" sm="12" md="4">
        <v-btn block color="secondary" nuxt to="/DailyWord">
          <v-icon> mdi-file-word-box </v-icon>
          Play the Daily Word
        </v-btn>
      </v-col>
      <v-col cols="12" sm="12" md="4">
        <v-btn block color="info" nuxt to="/PlayerScores">
          <v-icon> mdi-equalizer </v-icon>
          Player Scores
        </v-btn>
      </v-col>
      <v-spacer />
    </v-row>
    
  </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class IndexPage extends Vue {
  name: string = 'IndexPage'
}
</script>

