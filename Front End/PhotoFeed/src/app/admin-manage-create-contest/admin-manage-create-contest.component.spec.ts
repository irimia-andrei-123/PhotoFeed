import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminCreateContestComponent } from './admin-manage-create-contest.component';

describe('AdminCreateContestComponent', () => {
  let component: AdminCreateContestComponent;
  let fixture: ComponentFixture<AdminCreateContestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminCreateContestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminCreateContestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
