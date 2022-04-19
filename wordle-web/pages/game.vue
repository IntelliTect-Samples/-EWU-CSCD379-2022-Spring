<template>
    <v-container fill-height justify-center>


            <v-btn to="/" color="primary" fab>
                <v-icon>mdi-home</v-icon>
            </v-btn>

            <v-tooltip bottom>
                <template #activator="{ on, attrs }">
                    <v-btn color="primary" dark v-bind="attrs" v-on="on"> Left </v-btn>
                </template>
                <span>Left tooltip</span>
            </v-tooltip>

            <v-card-text class="text-h1 font-wight-black text-center">
                Wordles with Turtles
            </v-card-text>

            <v-card-text>
                <p> Yertle was a turtle who knew oh so many wordles. As a young turtle, he was a bit of a nerdle (he even wore a girtle!). Now he's a bit of a flirtle, though his looks make milk curdle, and his favorite scent is myrtle and his favorite color is purple. He calls his home a yurtle!</p>
                <p> Yertle was a turtle who knew oh so many wordles. As a young turtle, he was a bit of a nerdle (he even wore a girtle!). Now he's a bit of a flirtle, though his looks make milk curdle, and his favorite scent is myrtle and his favorite color is purple. He calls his home a yurtle!</p>
                <p> Yertle was a turtle who knew oh so many wordles. As a young turtle, he was a bit of a nerdle (he even wore a girtle!). Now he's a bit of a flirtle, though his looks make milk curdle, and his favorite scent is myrtle and his favorite color is purple. He calls his home a yurtle!</p>
            </v-card-text>

            <gameboard :wordleGame="wordleGame" />

            <v-card-actions>
                <v-btn color="primary" nuxt to="/"> Back to Main </v-btn>
            </v-card-actions>

            <keyboard :wordleGame="wordleGame" />
                
            

        </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

import  Keyboard from '@/components/keyboard.vue'
import Gameboard from '@/components/gameboard.vue'
import WordleGame from '@/scripts/wordleGame'
import wordsService from '@/scripts/wordsService'

@Component({ components: { Keyboard, Gameboard } })
export default class Game extends Vue {
  
}
</script>