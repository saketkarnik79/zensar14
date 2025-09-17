import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ParentCompChildComp } from './parent-comp-child-comp/parent-comp-child-comp';

@Component({
  selector: 'app-parent-comp',
  imports: [FormsModule, ParentCompChildComp],
  templateUrl: './parent-comp.html',
  styleUrl: './parent-comp.css'
})
export class ParentComp {
  name: string = 'Angular';
  nameChangeHandler(newName: string) {
    this.name = newName;
  }
}
