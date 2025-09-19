import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
@Component({
  selector: 'app-reactive-form-demo',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './reactive-form-demo.html',
  styleUrl: './reactive-form-demo.css'
})
export class ReactiveFormDemo {
  title = 'Reactive Forms Demo';
  contactForm = new FormGroup({
    firstName: new FormControl('', [Validators.required, Validators.minLength(2)]),
    lastName: new FormControl(),
    email: new FormControl(),
    gender: new FormControl(),
    isMarried: new FormControl(),
    country: new FormControl()
  });

  onSubmit() {
    console.log(this.contactForm.value);
  }
}
