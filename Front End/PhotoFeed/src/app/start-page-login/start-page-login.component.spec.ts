import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StartPageLoginComponent } from './start-page-login.component';

describe('StartPageLoginComponent', () => {
  let component: StartPageLoginComponent;
  let fixture: ComponentFixture<StartPageLoginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StartPageLoginComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StartPageLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
