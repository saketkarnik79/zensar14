import { Component } from '@angular/core';
import {FontAwesomeModule} from '@fortawesome/angular-fontawesome';
import {faCoffee} from '@fortawesome/free-solid-svg-icons';
import { Location } from '@angular/common';

@Component({
  selector: 'app-test',
  imports: [FontAwesomeModule],
  templateUrl: './test.html',
  styleUrls: ['./test.css']
})
export class Test {
  faCoffee=faCoffee;

  constructor(private location:Location){
    
  }
}
