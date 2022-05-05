


export class Stopwatch{
  startTime: number = 0;
  currentTime: number = 0;
  UpdateProcess: any;

  Start(): void {
    this.startTime = Date.now()
    this.currentTime = 0
    this.UpdateProcess = setInterval(this.Update, 10);
  }

  Update(): void{
    this.currentTime = Date.now() -this.startTime
    console.log(this.currentTime)
  }

  Stop(): void{
    clearInterval(this.UpdateProcess)
  }


}