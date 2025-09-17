import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Person } from './models/Person';
import { FormsModule } from '@angular/forms';
import { templateUrltClassDirective } from "./tt-class.directive";
import { TempConverterPipe } from './temp-converter';

@Component({
  
  selector: 'app-hello-world',
  imports: [CommonModule, FormsModule, templateUrltClassDirective, TempConverterPipe],
  templateUrl: './hello-world.html',
  styleUrl: './hello-world.css'
})
export class HelloWorld {
  firstName: string = 'John';
  lastName: string = 'Doe';
  person: Person = new Person('Jane', 'Smith', 30);

  title="Angular property Binding Example";
  isDisabled=true;

  classB:string="blue";
  classG:string="green";

  people: Person[] = [
    new Person('Alice', 'Johnson', 25),
    new Person('Bob', 'Brown', 28),
    new Person('Charlie', 'Davis', 22)
  ];

  num: number = 0;
  showButton: boolean = true;

  toggle(){
    this.showButton = !this.showButton;
  }

  color2: string = 'red';
  today: Date = new Date();
  amount: number = 1234567.89;
  message: string = 'heLLo worlD!'
  temp: number = 98.4;
}
