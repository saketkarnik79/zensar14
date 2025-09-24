import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Comp3 } from './comp3';

describe('Comp3', () => {
  let component: Comp3;
  let fixture: ComponentFixture<Comp3>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Comp3]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Comp3);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
