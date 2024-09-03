import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImageFeedbackComponent } from './image-feedback.component';

describe('ImageFeedbackComponent', () => {
  let component: ImageFeedbackComponent;
  let fixture: ComponentFixture<ImageFeedbackComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImageFeedbackComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImageFeedbackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
