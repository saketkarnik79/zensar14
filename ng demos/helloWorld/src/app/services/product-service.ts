import { Injectable } from '@angular/core';
import { Product } from '../models/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  public getProducts(): Product[] {
    return [
      new Product(1, 'Laptop', 999.99),
      new Product(2, 'Smartphone', 499.99),
      new Product(3, 'Tablet', 299.99)
    ];
  }
}
