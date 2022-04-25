import { LetterStatus } from './letter'
import { Word } from './word'
import {WordsService} from './wordsService'

export enum GameState {
  Active = 0,
  Won = 1,
  Lost = 2,
}

export class WordleGame {
  constructor(word: string) {
    this.words.push(new Word())
    this.word = word
  }

  private word: string
  words: Word[] = []
  hints: string[][]=[]
  displayHints: boolean[]=[false,false,false,false,false,false];
  state: GameState = GameState.Active
  readonly maxGuesses = 6

  get currentWord(): Word {
    return this.words[this.words.length - 1]
  }

  get gameOver(): Boolean {
    return this.state === GameState.Won || this.state === GameState.Lost
  }

  get correctChars() {
    const allLetters = this.words.map((x) => x.letters).flat()
    return allLetters
      .filter((x) => x.status === LetterStatus.Correct)
      .map((x) => x.char)
  }

  get wrongPlaceChars() {
    const allLetters = this.words.map((x) => x.letters).flat()
    const wrongPlaceLetters = allLetters
      .filter((x) => x.status === LetterStatus.WrongPlace)
      .map((x) => x.char)
    return wrongPlaceLetters.filter((x) => !this.correctChars.includes(x))
  }

  get wrongChars() {
    const allLetters = this.words.map((x) => x.letters).flat()
    return allLetters
      .filter((x) => x.status === LetterStatus.Wrong)
      .map((x) => x.char)
  }
  public setCurrentWord(to :string){
    this.currentWord.setWord(to);
  }
  submitWord() {
    if (this.currentWord.evaluateWord(this.word)) {
      this.state = GameState.Won
    } else if (this.words.length === this.maxGuesses) {
      this.state = GameState.Lost
    } else {
      if (this.currentWord.text.includes("?")){
        this.displayHints[this.words.length] = true
      }
      this.hints[this.words.length] = WordsService.validWords(this.currentWord.text)
      this.words.push(new Word())
    }
  }
}
