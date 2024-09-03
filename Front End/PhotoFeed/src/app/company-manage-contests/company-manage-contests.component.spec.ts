import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyManageContestsComponent } from './company-manage-contests.component';

describe('CompanyManageContestsComponent', () => {
  let component: CompanyManageContestsComponent;
  let fixture: ComponentFixture<CompanyManageContestsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompanyManageContestsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompanyManageContestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
