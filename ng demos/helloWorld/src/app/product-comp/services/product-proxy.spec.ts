import { TestBed } from '@angular/core/testing';

import { ProductProxy } from './product-proxy';

describe('ProductProxy', () => {
  let service: ProductProxy;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductProxy);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
