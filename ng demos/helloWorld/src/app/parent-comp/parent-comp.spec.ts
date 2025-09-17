import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParentComp } from './parent-comp';

describe('ParentComp', () => {
  let component: ParentComp;
  let fixture: ComponentFixture<ParentComp>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ParentComp]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParentComp);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
