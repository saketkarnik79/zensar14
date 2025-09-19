import { Component, signal } from '@angular/core';
import { HelloWorld } from './hello-world/hello-world';
import { ParentComp } from './parent-comp/parent-comp';
import { Product } from './models/Product';
import { ProductService } from './services/product-service';
import { CurrencyPipe, CommonModule } from '@angular/common';
import { FormDemo } from './form-demo/form-demo';
import { ReactiveFormDemo } from "./reactive-form-demo/reactive-form-demo";
import { DemoFormArray } from "./demo-form-array/demo-form-array";
import { ProductComp } from './product-comp/product-comp';

@Component({
  selector: 'app-root',
  imports: [HelloWorld, ParentComp, CurrencyPipe, CommonModule, FormDemo, ReactiveFormDemo, DemoFormArray, ProductComp],
  templateUrl: './app.html',
  styleUrl: './app.css',
  providers: [
    { provide: ProductService, useClass: ProductService , multi: false}
  ]
})
export class App {
  protected readonly title = signal('helloWorld');

  products: Product[]|undefined;
  productService: ProductService;
  constructor(productService: ProductService) {
    this.productService = productService;
  }

  getAllProducts(): void {
    this.products = this.productService.getProducts();
  }
}
