import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SucsessComponent } from './sucsess.component';

describe('SucsessComponent', () => {
  let component: SucsessComponent;
  let fixture: ComponentFixture<SucsessComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SucsessComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SucsessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
