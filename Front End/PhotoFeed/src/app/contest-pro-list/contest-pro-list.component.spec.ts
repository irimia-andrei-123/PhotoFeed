import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContestProListComponent } from './contest-pro-list.component';

describe('ContestProListComponent', () => {
  let component: ContestProListComponent;
  let fixture: ComponentFixture<ContestProListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContestProListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContestProListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
