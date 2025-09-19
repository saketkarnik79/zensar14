import { Component, ViewChild, ElementRef, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, FormsModule, Validators } from '@angular/forms';
import { Contact } from '../models/Contact';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-form-demo',
  imports: [CommonModule, FormsModule],
  templateUrl: './form-demo.html',
  styleUrl: './form-demo.css'
})
export class FormDemo implements OnInit {
  // let firstName:FormControl = new FormControl('');
  // let address:FormGroup = new FormGroup({
  //   city: new FormControl(''),
  //   street: new FormControl(''),
  //   pinCode: new FormControl('')
  // });

  title = 'Template Driven Form Demo';
  @ViewChild('contactForm') contactForm!: NgForm;
  contact!:Contact;

  ngOnInit(): void {
    this.contact = {
      firstName: '',
      lastName: '',
      gender: '',
      isToc:true,
      email: ''
    };
    //this.contactForm?.controls["lastName"]?.setValidators([Validators.minLength(2)]);
  }

  onSubmit() {
    console.log(this.contactForm.value);
  }
}
