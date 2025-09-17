import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HelloWorld } from './hello-world/hello-world';
import { ParentComp } from './parent-comp/parent-comp';
import { Product } from './models/Product';
import { ProductService } from './services/product-service';
import { CurrencyPipe, CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [HelloWorld, ParentComp, CurrencyPipe, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css',
  providers: [{ provide: ProductService, useClass: ProductService , multi: false}]
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
