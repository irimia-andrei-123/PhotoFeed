import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminManageContestsComponent } from './admin-manage-contests.component';

describe('AdminManageContestsComponent', () => {
  let component: AdminManageContestsComponent;
  let fixture: ComponentFixture<AdminManageContestsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminManageContestsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminManageContestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
