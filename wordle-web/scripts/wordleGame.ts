import * as signalR from '@microsoft/signalr'
import NuxtConfig from '../nuxt.config.js'
import { LetterStatus } from './letter'
import { Word } from './word'

export enum GameState {
  Active = 0,
  Won = 1,
  Lost = 2,
}

export class WordleGame {
  private word: string
  words: Word[] = []
  state: GameState = GameState.Active
  readonly maxGuesses = 6
  readonly connection = new signalR.HubConnectionBuilder()
    .withUrl(`${NuxtConfig.axios.baseURL}/gamehub`)
    .build()

  readonly gameName = 'Wordle001'

  readonly username: string = 'User: ' + Math.floor(Math.random() * 100000)

  constructor(word: string) {
    this.words.push(new Word())
    this.word = word
    this.connection
      .start()
      .catch((err) => {
        console.log(err)
      })
      .then(() => {
        this.connection.on('CharacterReceived', this.receiveChar)
        this.connection.on('UserJoined', this.userJoined)
        this.connection.on('UserLeft', this.userLeft)
        this.connection.send('JoinGame', this.username, this.gameName)
      })
  }

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

  addLetter(char: string) {
    this.currentWord.addLetter(char)
    this.connection
      .send('NewCharacter', this.username, char, this.gameName)
      .then(() => {
        console.log(`sent: ${char}`)
      })
  }

  receiveChar = (username: string, char: string) => {
    console.log(`Received: ${char} from ${username}`)
    if (username !== this.username) {
      this.currentWord.addLetter(char)
    }
  }

  userJoined = (username: string) => {
    console.log(`${username} joined`)
  }

  userLeft = (username: string) => {
    console.log(`${username} left`)
  }

  submitWord() {
    if (this.currentWord.evaluateWord(this.word)) {
      this.state = GameState.Won
    } else if (this.words.length === this.maxGuesses) {
      this.state = GameState.Lost
    } else {
      this.words.push(new Word())
    }
  }
}
