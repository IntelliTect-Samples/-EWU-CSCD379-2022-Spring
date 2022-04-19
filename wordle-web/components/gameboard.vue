<template>
    <v-card>
        <v-container>
            <v-row v-for="row in wordleGame.maxGuesses" :key="row" dense>
                <v-col v-for="index in wordleGame.currentWord.maxLetters" :key=>
                    <v-card height="50">
                        <v-card-text class="text-center">

                        </v-card-text>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
    </v-card>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'
import { WordleGame } from '@/scripts/wordleGame';
import { Letter } from '@/scripts/letter';
import { Word } from '@/scripts/word';

@Component({ components: {} })
export default class Gameboard extends Vue {
    @Prop({ required: true })
    wordleGame!: WordleGame;

    getLetter(row: number, index: number): Letter | null {
        const word: Word = this.wordleGame.words[row - 1]
    }
}
</script>
