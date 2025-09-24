import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-comp3',
  imports: [],
  templateUrl: './comp3.html',
  styleUrl: './comp3.css'
})
export class Comp3 {
  id:number=0;
  constructor(private activatedRoute: ActivatedRoute) {
    this.activatedRoute.params.subscribe(params => {
      this.id = params['id'];
    });

    //this.id=this.activatedRoute.snapshot.params['id'];
    console.log(this.id);
  }
}
