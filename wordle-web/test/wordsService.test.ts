import { WordsService } from '@/scripts/wordsService'

describe('Word Service', () => {
  test('Get a word', () => {
    const word = WordsService.getRandomWord()
    expect(word).not.toBeNull()
    expect(word).toHaveLength(5)
    expect(word).not.toHaveLength(4)
  })

  test('Words are private', () => {
    expect((WordsService as any).words).toBeUndefined()
  })

  test('validWords returns proper words', ()=>{
    const word = "a?orn"
    const validWords = WordsService.validWords(word)
    expect (validWords).toHaveLength(2)
    expect (validWords[0]).toBe("acorn")
  })

  test ('validWords returns empty array on no matches',()=>{
    const word = "jjjj?"
    const validWords = WordsService.validWords(word)
    expect (validWords).toHaveLength(0)
  })

  test ('validWords can return all words', ()=>{
    const word = "?????"
    const validWords = WordsService.validWords(word)
    expect (validWords).toHaveLength(631)

  })

})
