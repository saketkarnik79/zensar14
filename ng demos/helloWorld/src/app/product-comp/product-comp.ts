import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Product2 } from '../models/Product2';
import { ProductProxy } from './services/product-proxy';
import { map, Observable } from 'rxjs';

@Component({
  selector: 'app-product-comp',
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './product-comp.html',
  styleUrl: './product-comp.css',
  providers: [{ provide: ProductProxy, useClass: ProductProxy , multi: false}]
})
export class ProductComp implements OnInit {
  constructor(private proxy: ProductProxy){}

  products$: Observable<Product2[]> = new Observable<Product2[]>();
  productForm: FormGroup=new FormGroup({});
  submitted:boolean=false;
  eventValue:string="Save";

  ngOnInit(): void {
      this.onInitialized();
  }

  onInitialized(){
    this.getAllProducts()
    this.productForm=new FormGroup({
      productId: new FormControl(0),
      name: new FormControl('',[Validators.required, Validators.minLength(3), Validators.maxLength(50)]),
      description: new FormControl('',[Validators.required, Validators.maxLength(200)]),
      price: new FormControl(0,[Validators.required]),
    });
  }

  
getAllProducts() {
  this.products$ = this.proxy.getData().pipe(
    map (result => [...result]) // force new reference
  );
}

  // getAllProducts(){
  //   this.proxy.getData().subscribe((result: Product2[])=>{
  //     this.products=[...result];
  //   });
  // }

  deleteProduct(id:number){
    if(confirm("Are you sure to delete?")){
      this.proxy.deleteData(id).subscribe((result: Product2)=>{
        this.getAllProducts();
      });
    }
  }

  onSubmit(){
    this.submitted=true;
    switch(this.eventValue){
      case "Save":
        this.save();
        break;
      case "Update":
        this.update();
        break;
    }
  }

  save(){
    if(this.productForm.valid){
      this.proxy.postData(this.productForm.value).subscribe((result: Product2)=>{
        this.resetForm();
      });
    };
  }

  resetForm(){
    this.getAllProducts();
    this.productForm.reset();
    this.productForm.patchValue({productId:0, name:'', description:'', price:0});
    this.eventValue="Save";
    this.submitted=false;
  }

  update(){
    this.submitted=true;
    if(this.productForm.valid){
      this.proxy.putData(this.productForm.value.productId, this.productForm.value).subscribe((result: Product2)=>{
        this.resetForm();
      });
    }
  }

  editProduct(product:Product2){
    this.productForm.controls['productId'].setValue(product.productId);
    this.productForm.controls['name'].setValue(product.name);
    this.productForm.controls['description'].setValue(product.description);
    this.productForm.controls['price'].setValue(product.price);
    this.eventValue="Update";
  }
}
