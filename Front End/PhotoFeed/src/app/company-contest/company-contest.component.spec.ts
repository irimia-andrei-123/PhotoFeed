import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyContestComponent } from './company-contest.component';

describe('CompanyContestComponent', () => {
  let component: CompanyContestComponent;
  let fixture: ComponentFixture<CompanyContestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompanyContestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompanyContestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
