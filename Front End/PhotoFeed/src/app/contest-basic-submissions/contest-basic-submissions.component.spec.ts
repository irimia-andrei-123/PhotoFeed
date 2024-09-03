import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContestBasicSubmissionsComponent } from './contest-basic-submissions.component';

describe('ContestBasicSubmissionsComponent', () => {
  let component: ContestBasicSubmissionsComponent;
  let fixture: ComponentFixture<ContestBasicSubmissionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContestBasicSubmissionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContestBasicSubmissionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
