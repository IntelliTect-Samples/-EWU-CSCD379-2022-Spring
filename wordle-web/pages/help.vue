<template>
  <v-container fluid="true">
    <v-row justify="left">
      <v-col :cols="cols">
        <v-card flat color="transparent">
          <v-card-title class="justify-left">
            <h1>Instructions</h1>
          </v-card-title>
        </v-card>
      </v-col>

      <v-col :cols="cols">
        <v-card>
          <div class="d-flex align-left">
            <v-container>
              <v-card>
                <v-icon class="pa-1 my-2">mdi-check</v-icon>You have a total of 6 guesses <v-spacer></v-spacer>
                <v-icon class="pa-1 my-2">mdi-check</v-icon> Letters can be used more than once. <v-spacer></v-spacer>
                <v-icon class="pa-1 my-2">mdi-check</v-icon> Answers are never plurals.<v-spacer></v-spacer>
                <v-icon class="pa-1 my-2">mdi-lightbulb-on-outline</v-icon>
                You can search a list of possible answers to help
                <v-spacer></v-spacer>

                <v-icon class="pa-1 my-2">mdi-lightbulb-on-outline</v-icon>
                You can place
                <v-btn color="primary" small class="pa-0 my-4">?</v-btn>
                anywhere and choose from the list of possible answers.<v-spacer></v-spacer>
                <h-4 class="pa-1 my-2">(color varies by theme)</h-4>

                <v-divider></v-divider>
                <h2 class="pa-1 mt-2">Example:</h2>

                <v-btn color="error" small class="pa-0 mt-4 mb-2">T</v-btn>
                <v-btn color="error" small class="pa-0 mt-4 mb-2">H</v-btn>
                <v-btn color="error" small class="pa-0 mt-4 mb-2">O</v-btn>
                <v-btn color="warning" small class="pa-0 mt-4 mb-2">R</v-btn>
                <v-btn color="error" small class="pa-0 mt-4 mb-2">N</v-btn>
                <v-spacer></v-spacer>
                The R is IN the word but in the WRONG spot, the rest are not in
                the word. 
                <v-spacer></v-spacer>
                <v-btn color="error" small class="pa-0 mt-6 mb-2">T</v-btn>
                <v-btn color="error" small class="pa-0 mt-6 mb-2">A</v-btn>
                <v-btn color="success" small class="pa-0 mt-6 mb-2">B</v-btn>
                <v-btn color="error" small class="pa-0 mt-6 mb-2">L</v-btn>
                <v-btn color="warning" small class="pa-0 mt-6 mb-2">E</v-btn>
                <v-spacer></v-spacer>
                The B is IN the word and in the CORRECT spot, and the E is In the word, but the wrong spot.
                <v-spacer></v-spacer>
                <h2 class="mt-4">Correct word:</h2>
                <v-spacer></v-spacer>
                <v-btn color="success" small class="pa-0 my-4">S</v-btn>
                <v-btn color="success" small class="pa-0 my-4">A</v-btn>
                <v-btn color="success" small class="pa-0 my-4">B</v-btn>
                <v-btn color="success" small class="pa-0 my-4">E</v-btn>
                <v-btn color="success" small class="pa-0 my-4">R</v-btn>
                <v-spacer></v-spacer>
              </v-card>
            </v-container>
          </div>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
@Component
export default class InstructionsPage extends Vue {
  get cols(): string {
    switch (this.$vuetify.breakpoint.name) {
      case 'xs':
      case 'sm':
        return '12'
      default:
        return '7'
    }
  }
}