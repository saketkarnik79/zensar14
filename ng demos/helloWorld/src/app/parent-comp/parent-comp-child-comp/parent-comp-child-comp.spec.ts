import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParentCompChildComp } from './parent-comp-child-comp';

describe('ParentCompChildComp', () => {
  let component: ParentCompChildComp;
  let fixture: ComponentFixture<ParentCompChildComp>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ParentCompChildComp]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParentCompChildComp);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
