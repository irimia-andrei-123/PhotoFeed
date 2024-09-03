import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContestBasicListComponent } from './contest-basic-list.component';

describe('ContestBasicListComponent', () => {
  let component: ContestBasicListComponent;
  let fixture: ComponentFixture<ContestBasicListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContestBasicListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContestBasicListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
