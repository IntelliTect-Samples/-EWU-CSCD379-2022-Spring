
export class Stopwatch{
    startTime: number = 0;
    currentTime: number = 0;
    UpdateProcess: any;
    isRunning: boolean = false;
  
    Start(): void {
      this.startTime = Date.now()
      this.currentTime = 0
      this.UpdateProcess = setInterval(() => {
        this.currentTime = Date.now() - this.startTime
      });
      this.isRunning = true
    }
  
    Stop(): void{
      clearInterval(this.UpdateProcess)
      this.isRunning = false
    }
  
  
  }