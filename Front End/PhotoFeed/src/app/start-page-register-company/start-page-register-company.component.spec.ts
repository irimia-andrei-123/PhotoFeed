import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StartPageRegisterCompanyComponent } from './start-page-register-company.component';

describe('StartPageRegisterCompanyComponent', () => {
  let component: StartPageRegisterCompanyComponent;
  let fixture: ComponentFixture<StartPageRegisterCompanyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StartPageRegisterCompanyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StartPageRegisterCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
