import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContestProSubmissionsComponent } from './contest-pro-submissions.component';

describe('ContestProSubmissionsComponent', () => {
  let component: ContestProSubmissionsComponent;
  let fixture: ComponentFixture<ContestProSubmissionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContestProSubmissionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContestProSubmissionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
