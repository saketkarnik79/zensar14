import { Component } from '@angular/core';
import { ActivatedRoute, Router  } from '@angular/router';

@Component({
  selector: 'app-comp2',
  imports: [],
  templateUrl: './comp2.html',
  styleUrl: './comp2.css'
})
export class Comp2 {
  color: string="";
  sortField: string="";

  constructor(private route: ActivatedRoute, private router: Router) {
    this.route.queryParams.subscribe(params => {
      this.color=params['color'];
    });
    this.route.queryParams.subscribe(params => {
      this.sortField=params['sort'];
    });
    console.log`color: ${this.color}, sortField: ${this.sortField}`;
    if(this.sortField=="id"){
      this.router.navigate(['/comp1']);
    }
  }
}
