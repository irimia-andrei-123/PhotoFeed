import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContestProInfoComponent } from './contest-pro-info.component';

describe('ContestProInfoComponent', () => {
  let component: ContestProInfoComponent;
  let fixture: ComponentFixture<ContestProInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContestProInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContestProInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
