<template>
    <v-dialog
      v-model="dialog"
      scrollable
      max-width="375"
      min-height="50"
      max-height="200"
    >
    <template v-slot:activator="{ on, attrs }">
    <v-btn
  color="info"
  outlined = "true"
  elevation="4"
  fab
  right
  absolute
  x-small
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
        <v-chip color="info" v-for = "word in this.words" :key="word"
          @click="hintClicked(word), dialog=false, dialogm1=false"
        >
          {{word}}
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
@Prop({required: false})
words!: string[]
dialog: boolean = false;

  hintClicked(clicked: string){
    console.log("Event emitted")
    this.$emit("guess-from-hint", clicked);
  }

 displayHints(){

 }
}


</script>
