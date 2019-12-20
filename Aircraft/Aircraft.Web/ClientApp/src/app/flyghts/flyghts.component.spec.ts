import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlyghtsComponent } from './flyghts.component';

describe('FlyghtsComponent', () => {
  let component: FlyghtsComponent;
  let fixture: ComponentFixture<FlyghtsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlyghtsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlyghtsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
