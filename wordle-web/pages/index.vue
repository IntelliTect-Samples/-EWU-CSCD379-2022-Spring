<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="6">
      <v-card class="logo py-4 d-flex justify-center">
        <NuxtLogo />
        <VuetifyLogo />
      </v-card>
      <v-card align="center">
        <v-card-text class="headline">
            <h2>Welcome to eldroW</h2>
            <br>
            <p>
              For best experience please turn up your volume
              <v-icon>mdi-volume-high</v-icon>
            </p>
            <p>
              Antonio Gomez
            </p>
        </v-card-text>
        
        <v-card-actions align="center">
          <v-spacer />
          <v-btn color="primary" nuxt to="/game" align="center"> Game Page </v-btn>
          <v-btn
            color="secondary"
            :loading="isLoading"
            @click="changeButtonText"
          >
            Change Text
          </v-btn>
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
}
</script>
