import { TestBed } from '@angular/core/testing';

import { Comp3GuardService } from './comp3-guard-service';

describe('Comp3GuardService', () => {
  let service: Comp3GuardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Comp3GuardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
