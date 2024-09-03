import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FeedbackCategoriesComponent } from './feedback-categories.component';

describe('FeedbackCategoriesComponent', () => {
  let component: FeedbackCategoriesComponent;
  let fixture: ComponentFixture<FeedbackCategoriesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FeedbackCategoriesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FeedbackCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
