<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="6">
      <v-card class="logo py-4 d-flex justify-center">
      </v-card>
      <v-card>
        <v-card-title class="headline">
          Welcome to one of the many Wordle clones
        </v-card-title>
        <v-card-text>
          Now with hints and leaderboards!
        </v-card-text>
        <v-card-actions>
          <v-btn color="primary" nuxt to="/game"> Game Page </v-btn>
          <v-spacer />
          <v-btn color="primary" nuxt to="/leaderboard"> Leaderboard </v-btn>
        </v-card-actions>
      </v-card>
    </v-col>
  </v-row>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class IndexPage extends Vue {
  name: string = 'IndexPage'
  buttonText: string = 'Inspire me!'
  isLoading: boolean = false

  changeButtonText() {
    this.buttonText =
      this.buttonText === 'Inspire me!' ? 'Inspire me again!' : 'Inspire me!'
    this.isLoading = true
    setTimeout(() => {
      this.isLoading = false
    }, 1000)
  }

  emitFn(){
    this.$emit("emit-fn");
  }
}
</script>
