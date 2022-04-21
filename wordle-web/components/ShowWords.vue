<template>
  <div>
    <v-row justify="center">
      <v-dialog v-model="dialog" scrollable max-width="300px">
        <template #activator="{ on, attrs }">
          <v-btn :disabled="wordleGame.gameOver" v-bind="attrs" v-on="on">
            Show Available Words
          </v-btn>
        </template>
        <v-card>
          <v-card-title>Available Words</v-card-title>
          <v-divider></v-divider>
          <v-card-text style="height: 300px">
            <v-radio-group v-model="dialogm1" column>
              <div v-for="item in items" :key="item">
                <v-radio
                  :label="item"
                  :value="item"
                  @click="setInput(item)"
                ></v-radio>
              </div>
            </v-radio-group>
          </v-card-text>
          <v-divider></v-divider>
          <v-card-actions>
            <v-btn text @click="dialog = false"> Close </v-btn>
            <v-btn color="primary" text @click="inputWord(availableWordsInput)">
              Select
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-row>
  </div>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator'
// import { Letter, LetterStatus } from '~/scripts/letter'
import { WordleGame } from '~/scripts/wordleGame'

@Component({})
export default class ShowWords extends Vue {
  @Prop({ required: true })
  wordleGame!: WordleGame

  dialog = false
  availableWordsInput = 'words'

  toggleDialog() {
    this.dialog = !this.dialog
  }

  clearLetters() {
    while (this.wordleGame.currentWord.length > 0) {
      this.wordleGame.currentWord.removeLetter()
    }
  }

  inputWord(word: string) {
    this.clearLetters()
    for (let i = 0; i < word.length; i++) {
      this.wordleGame.currentWord.addLetter(word.charAt(i))
    }
    this.dialog = false
  }

  setInput(text: string) {
    this.availableWordsInput = text
  }

  data() {
    return {
      items: [
        'acorn',
        'acrid',
        'actor',
        'adept',
        'adobe',
        'adorn',
        'adult',
        'agent',
        'agony',
        'aisle',
        'alder',
        'alien',
        'alike',
        'alive',
        'alone',
        'aloud',
        'amber',
        'ample',
        'amuck',
        'angel',
        'angry',
        'ankle',
        'antic',
        'arise',
        'aspen',
        'aspic',
        'audio',
        'awful',
        'azure',
        'balmy',
        'bandy',
        'basic',
        'basin',
        'batch',
        'baton',
        'bawdy',
        'beady',
        'beamy',
        'beast',
        'being',
        'bight',
        'bigot',
        'binge',
        'bingo',
        'biped',
        'birch',
        'birth',
        'bison',
        'biter',
        'blame',
        'bland',
        'blank',
        'bleak',
        'bleat',
        'blind',
        'bloat',
        'blond',
        'blunt',
        'bodge',
        'bogie',
        'bogus',
        'boned',
        'bonus',
        'bound',
        'boxer',
        'braid',
        'brand',
        'brash',
        'brave',
        'brawl',
        'brawn',
        'brick',
        'brief',
        'brisk',
        'broad',
        'broke',
        'brute',
        'bugle',
        'built',
        'bulky',
        'burly',
        'bushy',
        'butch',
        'cadet',
        'cadre',
        'calyx',
        'camel',
        'caste',
        'cedar',
        'chaos',
        'chard',
        'cheap',
        'chest',
        'chief',
      ],
    }
  }
}
</script>
