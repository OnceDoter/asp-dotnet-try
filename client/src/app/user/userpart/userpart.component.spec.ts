import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserpartComponent } from './userpart.component';

describe('UserpartComponent', () => {
  let component: UserpartComponent;
  let fixture: ComponentFixture<UserpartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserpartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserpartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
