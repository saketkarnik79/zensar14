import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-parent-comp-child-comp',
  imports: [],
  templateUrl: './parent-comp-child-comp.html',
  styleUrl: './parent-comp-child-comp.css'
})
export class ParentCompChildComp {
  @Input() name!: string ;
  @Output() nameChange: EventEmitter<string> = new EventEmitter<string>();

  changeName(newName: string) {
    this.name = newName;
    this.nameChange.emit(this.name);
  }
  
  ngOnInit() {
    console.log(`Child Component Initialized with name: ${this.name}`);
  }

  ngOnChanges() {
    console.log(`Child Component Input Changed: ${this.name}`);
  }

  ngOnDestroy() {
    console.log('Child Component Destroyed');
  }
}
