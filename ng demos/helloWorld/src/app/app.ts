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
import { Comp1 } from './comp1/comp1';
import { Comp2 } from './comp2/comp2';
import { Comp3 } from './comp3/comp3';
import { RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Comp1, Comp2, Comp3, HelloWorld, ParentComp, CurrencyPipe, CommonModule, FormDemo, ReactiveFormDemo, DemoFormArray, ProductComp, RouterLink, RouterLinkActive],
  templateUrl: './app.html',
  styleUrl: './app.css',
  providers: [
    { provide: ProductService, useClass: ProductService , multi: false}
  ]
})
export class App {
  protected readonly title = "Hello World";

  products: Product[]|undefined;
  productService: ProductService;
  constructor(productService: ProductService) {
    this.productService = productService;
  }

  getAllProducts(): void {
    this.products = this.productService.getProducts();
  }
}
