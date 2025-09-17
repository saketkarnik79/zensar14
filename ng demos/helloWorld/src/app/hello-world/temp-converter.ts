import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: 'tempConverter'
})
export class TempConverterPipe implements PipeTransform {
    transform(value: number, unit: string): string|undefined {
        if(value && !isNaN(value)){
            if(unit === 'C'){
                return ((value - 32) * 5/9).toFixed(2);
            }
            else if(unit === 'F'){
                return ((value * 9/5) + 32).toFixed(2);
            }
            else{
                return 'Invalid unit';
            }
        }
        return undefined;
    }
}