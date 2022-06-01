<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="6">
      <v-card>
        <v-card-title class="headline"> About This Game </v-card-title>
        <v-card-text>
          <p>
            This game was created as a class project at Eastern Washington
            University. The creative concept for Defintely Not Wordle was inspired
            by my great instructor Meg! This is coming from branch!
          </p>
        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn color="primary" nuxt to="/"> Back Home </v-btn>
          <v-btn color="primary" nuxt to="/"> Play the Game</v-btn>
          <v-spacer />
        </v-card-actions>
      </v-card>
    </v-col>
  </v-row>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class About extends Vue {
  name: string = 'About'
}
</script>
