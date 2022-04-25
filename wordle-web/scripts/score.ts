export class Score {
  constructor(name: string, average: number, gameCount: number) {
    this.name = name
    this.average = average
    this.gameCount = gameCount
  }

  name: string
  average: number
  gameCount: number
}
