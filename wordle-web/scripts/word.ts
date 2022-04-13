import{ Letter, LetterStatus } from "~/scripts/letter";


export class word{
    readonly letters: Letter[] = [];
    readonly maxWordLength = 5;

    get text(){
        return this.letters.map(x => x.char).join('');
    }

    addLetter(char: string){
        if(this.letters.length < this.maxWordLength){
            this.letters.push(new Letter(char));
        }
    }

    removeLetter(){
        if(this.letters.length > 0){
        this.letters.pop()
        }
    }

    evaluateWord(word:string): boolean{
        let result = true;

        if(word.length === this.letters.length){
            const wordLettersLeft = word.split('')
            for(const[index,letter] of this.letters.entries()){
                if(word[index] === letter.char){
                    letter.status = LetterStatus.Correct
                    wordLettersLeft.splice(wordLettersLeft.indexOf(letter.char),1)

                }else if (wordLettersLeft.includes(letter.char)){
                    letter.status = LetterStatus.WrongPlace
                    wordLettersLeft.splice(wordLettersLeft.indexOf(letter.char),1)

                    result = false
                }else{
                    letter.status = LetterStatus.Wrong;
                    result = false
                }

            }

            return result;
        
        }else{
            return false;
        }
    
    }
}