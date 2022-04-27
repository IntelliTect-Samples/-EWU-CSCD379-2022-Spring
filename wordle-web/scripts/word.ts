import {Letter, LetterStatus} from '~/scripts/letter'

export class Word {
  readonly letters: Letter[] = []
  static readonly maxLetters = 5

  get text() {
    return this.letters.map((f) => f.char).join('')
  }

  addLetter(char: string) {
    if (this.letters.length < Word.maxLetters) {
      this.letters.push(new Letter(char))
    }
  }

  removeLetter() {
    if (this.letters.length > 0) {
      this.letters.pop()
    }
  }

  clearWord() {
    while (this.letters.length > 0) {
      this.removeLetter()
    }
  }

  evaluateWord(word: string): boolean {
    let result = true

    if (word.length === this.letters.length) {
      const wordLettersLeft = word.split('')
      const lettersLeft = []

      for (const [index, letter] of this.letters.entries()) {
        if (word[index] === letter.char) {
          letter.status = LetterStatus.Correct
          wordLettersLeft.splice(wordLettersLeft.indexOf(letter.char), 1)
        } else {
          result = false
          lettersLeft.push(letter)
        }
      }

      if (!result) {
        for (const letter of lettersLeft) {
          if (wordLettersLeft.includes(letter.char)) {
            letter.status = LetterStatus.WrongPlace
            wordLettersLeft.splice(wordLettersLeft.indexOf(letter.char), 1)
          } else {
            letter.status = LetterStatus.Wrong
          }
        }
      }
      return result
    } else {
      return false
    }
  }

  get length() {
    return this.letters.length
  }
}
