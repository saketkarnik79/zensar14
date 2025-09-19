import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DemoFormArray } from './demo-form-array';

describe('DemoFormArray', () => {
  let component: DemoFormArray;
  let fixture: ComponentFixture<DemoFormArray>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DemoFormArray]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DemoFormArray);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
