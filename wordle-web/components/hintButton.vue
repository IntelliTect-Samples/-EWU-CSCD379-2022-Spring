<template>
    <v-dialog
      v-model="dialog"
      scrollable
      max-width="300px"
    >
    <template v-slot:activator="{ on, attrs }">
    <v-btn
  color="rgba(0,255,0,0.8)"
  outlined = true
  elevation="4"
  fab
  right
  absolute
  small
  value = undefined;
  v-bind="attrs"
  v-on="on"
  @click = "displayHints()"
>{{words.length}}</v-btn>
  </template>
    <v-card>
      <v-card-title>Hints</v-card-title>
      <v-divider></v-divider>
      <v-card-text style="height: 300px;">
        <v-chip-group
          v-model="dialogm1"
          column
        >
        <v-chip v-for = "words in this.words" :key="words">
          {{words}}
        </v-chip>
      </v-chip-group>
    </v-card-text>
    </v-card>
    </v-dialog>
  </template>

<script lang = "ts">
import { Component, Vue, Prop } from 'vue-property-decorator'

@Component({ components: {} })
export default class Wordslist extends Vue {
 words :string[] = ['house', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard'
 , 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard'
 , 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard'
 , 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard'
 , 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard'
 , 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard'
 , 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard'
 , 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard'
 , 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard', 'talent', 'posts', 'hoard']

 displayHints(){

 }
}


</script>
