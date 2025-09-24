import { Component, OnInit, signal, VERSION } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Observable, Observer, of, from, Subscription, interval, timer, Subject } from 'rxjs';
import { filter, map, tap, switchMap, mergeMap, concatMap, exhaustMap, debounceTime, debounce, delay, delayWhen } from 'rxjs/operators';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, FormsModule, ReactiveFormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  protected readonly title = signal('demoObservable');

  // obs = new Observable((observer)=>{
  //   console.log("Observable Starts...");
  //   // observer.next("1");
  //   // observer.next("2");
  //   // observer.next("3");
  //   // observer.next("4");
  //   // observer.next("5");
  //   setTimeout(()=> { observer.next("1"); }, 1000);
  //   setTimeout(()=> { observer.next("2"); }, 2000);
  //   setTimeout(()=> { observer.next("3"); }, 3000);
  //   setTimeout(()=> { observer.next("4"); }, 4000);
  //   //setTimeout(()=> { observer.error("Error emmitted") }, 4500);
  //   setTimeout(()=> { observer.complete() }, 4500);
  //   setTimeout(()=> { observer.next("5"); }, 5000);
  // });

  //   obs = new Observable<number>((observer)=>{
  //   console.log("Observable Starts...");

  //   observer.next(1);
  //   observer.next(2);
  //   observer.next(3);
  //   observer.next(4);
  //   observer.next(5);
  //   observer.complete();
  // });

  // sub:any;

  // ngOnInit(): void {
  //    this.sub=this.obs.pipe(filter((data)=>data>2), map(val=> val * 2))
  //   .subscribe({next: val=> console.log(val),
  //     complete:()=>console.log("Completed...")
  //   });

      // this.obs.subscribe(
      //   {
      //     next: (val) => {
      //       console.log(val);
      //     },//next callback
      //     error: (error) => {
      //       console.log(`error: ${error}`);
      //     }, //error callback
      //     complete: () => {
      //       console.log('Completed');
      //     }//complete callback
      //   }
      // );
  //}

  // ngOnDestroy(){
  //   this.sub.unsubscribe()
  // }

  // ngOnInit():void{
  //   //Create an Observable from Create Method
  //   const obs=Observable.create((observer:Observer<string>)=>{
  //     observer.next('1');
  //     observer.next('2');
  //     observer.next('3');
  //     observer.complete();
  //   });
  //   obs.subscribe((val:string)=>console.log(val),(error:any)=>console.log(error),()=>console.log("complete"));
  // }

  // ngOnInit(): void {
  //     // const array1=[1, 2, 3, 4, 5, 6, 7, 8];
  //     // const array2=['a', 'b', 'c', 'd'];

  //     // const obs=of(array1, array2);
  //     const obs= of(10, 20, 30, 40);
  //     obs.subscribe(
  //       (val)=>console.log(val),
  //       (error) => console.log(error),
  //       ()=> console.log("completed...")
  //     );
  // }

  // ngOnInit(): void {
  //     const array= [1, 2, 3, 4, 5, 6, 7, 8];
  //     const obs=from(array);
  //     obs.subscribe(
  //       (val)=>console.log(val),
  //       (error) => console.log(error),
  //       ()=> console.log("completed...")
  //     );
  // }

  // ngOnInit(): void {
  //     let dict=new Map();
  //     dict.set(1, "Hello");
  //     dict.set(2, "Angular");
  //     const obs=from(dict);
  //     obs.subscribe(
  //       (val)=>console.log(val),
  //       (error) => console.log(error),
  //       ()=> console.log("completed...")
  //     );
  // }

  // ngOnInit(): void {
  //     of(10, 20, 30, 40, 50, 60, 70)
  //       .pipe(
  //         tap((val) => {
  //           console.log(`Before: ${val}`)
  //         }),
  //         map(val => {
  //           return val * 2;
  //         }),
  //         tap((val) => {
  //           console.log(`After: ${val}`)
  //         }),
  //       )
  //       .subscribe({next:(val)=>console.log(`At Subscriber: ${val}`)});
  // }

  // ngOnInit(): void {
  //     let srcObs = of(10, 20, 30, 40, 50);
  //     let innerObs = of('A', 'B', 'C', 'D', 'E', 'F');

  //     srcObs.pipe(
  //       switchMap(val => {
  //         console.log(`Source Value: ${val}`);
  //         console.log(`Starting new observale...`);
  //         return innerObs;
  //       })
  //     ).subscribe(val => {
  //       console.log(`Received: ${val}`)
  //     });
  // }

  // ngOnInit(): void {
  //     let srcObs = of(10, 20, 30, 40, 50);
  //     let innerObs = of('A', 'B', 'C', 'D', 'E', 'F');

  //     srcObs.pipe(
  //       mergeMap(val=>{
  //         console.log(`Source Value: ${val}`);
  //         console.log('Starting New Observable...');
  //         return innerObs;
  //       })
  //     ).subscribe(val=>{
  //       console.log(`Received: ${val}`);
  //     });
  // }

  // ngOnInit(): void {
  //     let srcObs = of(10, 20, 30, 40, 50);
  //     let innerObs = of('A', 'B', 'C', 'D', 'E', 'F');

  //     srcObs.pipe(
  //       concatMap(val=>{
  //         console.log(`Source Value: ${val}`);
  //         console.log('Starting New Observable...');
  //         return innerObs;
  //       })
  //     ).subscribe(val=>{
  //       console.log(`Received: ${val}`);
  //     });
  // }

  // ngOnInit(): void {
  //     let srcObs = of(10, 20, 30, 40, 50);
  //     let innerObs = of('A', 'B', 'C', 'D', 'E', 'F');

  //     srcObs.pipe(
  //       exhaustMap(val=>{
  //         console.log(`Source Value: ${val}`);
  //         console.log('Starting New Observable...');
  //         return innerObs;
  //       })
  //     ).subscribe(val=>{
  //       console.log(`Received: ${val}`);
  //     });
  // }
  // demoForm: FormGroup=new FormGroup({name: new FormControl()});
  // obs!:Subscription;

  // ngOnInit(): void {
  //     this.obs=this.demoForm.valueChanges.pipe(debounceTime(500)).subscribe(val=>console.log(val));
  // }
  // ngOnInit(): void {
  //     this.obs=this.demoForm.valueChanges.pipe(debounce(()=>interval(500))).subscribe(val=>console.log(val));
  // }

  // ngOnDestroy(){
  //   this.obs.unsubscribe();
  // }
  // dt=new Date();
  // ngOnInit(): void {
  //   this.dt.setSeconds(this.dt.getSeconds()+5)
  //    of(10, 20, 30, 40, 50, 60, 70)
  //     .pipe(
  //       tap(val => console.log(`Before: ${val}`)),
  //       //delay(1000)
  //       concatMap(val=>of(val).pipe(delay((this.dt))))
  //     )
  //     .subscribe(
  //       val=> console.log(val),
  //       err=> console.log(err),
  //       () => console.log("Completed...")
  //     );
  // }

  // ngOnInit(): void {
  //     of(10, 20, 30, 40, 50, 60, 70)
  //     .pipe(tap(val => console.log(`Before: ${val}`)), delayWhen(()=> timer(1000)))
  //     .subscribe(val=> console.log(val));
  // }

  subject$ = new  Subject();
  
  ngOnInit(): void {
      // this.subject$.subscribe(val =>{
      //   console.log(val);
      // });

      this.subject$.next("1");
      this.subject$.next("2");

      this.subject$.subscribe(val =>{
        console.log(val);
      });
      this.subject$.next("3");
      this.subject$.next("4");
      this.subject$.next("5");

      this.subject$.complete();
  }
}
