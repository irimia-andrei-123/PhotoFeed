import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StartPageRegisterUserComponent } from './start-page-register-user.component';

describe('StartPageRegisterUserComponent', () => {
  let component: StartPageRegisterUserComponent;
  let fixture: ComponentFixture<StartPageRegisterUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StartPageRegisterUserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StartPageRegisterUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
