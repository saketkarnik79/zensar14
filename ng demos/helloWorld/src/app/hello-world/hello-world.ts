import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Person } from './models/Person';

@Component({
  selector: 'app-hello-world',
  imports: [CommonModule],
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
}
