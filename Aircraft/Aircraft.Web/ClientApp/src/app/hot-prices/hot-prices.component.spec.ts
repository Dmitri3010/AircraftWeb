import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HotPricesComponent } from './hot-prices.component';

describe('HotPricesComponent', () => {
  let component: HotPricesComponent;
  let fixture: ComponentFixture<HotPricesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HotPricesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HotPricesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
