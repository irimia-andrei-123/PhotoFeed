import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { FeedbackImageModel } from '../Models/FeedbackImageModel';
import { FeedbackService } from '../Services/FeedbackService/Feedback';
import { CategoryModel } from '../Models/CategoryModel';
import { CategoryService } from '../Services/CategoryService/Category';
import { UserFeedbackSubmissionModel } from '../Models/UserFeedbackSubmissionModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-feedback',
  templateUrl: './feedback-user.component.html',
  styleUrls: ['./feedback-user.component.css']
})
export class UserFeedbackComponent implements OnInit {

  categoryArr: CategoryModel[];

  userSubmissions: UserFeedbackSubmissionModel[];

  submission: FeedbackImageModel;
  feedbackImageForm: FormGroup;
  public base64Files: string[] = [];
  private fileReader = new FileReader();
  display_img: Boolean = false;

  constructor(private feedbackSubmitionSvc: FeedbackService, private catService: CategoryService,
    private router: Router) { }

  ngOnInit() {
    this.catService.GetCategoriesInfo().subscribe(rez => {
      this.categoryArr = rez;
    });
    this.feedbackImageForm = new FormGroup({
      FeedbackPicture: new FormControl(''),
      FeedbackCategory: new FormControl(''),
      Description: new FormControl('')
    });

    this.loadSubmissions();
  }

  loadSubmissions() {
    this.feedbackSubmitionSvc.GetUserPosts(JSON.parse(localStorage.getItem('loged_user')).IdUser).subscribe(rez => {
      if (rez.length === 0) {
      } else {
        this.userSubmissions = rez;
      }
    });
  }

  onFileChanged(event: Event) {
    const files = event.target['files'];
    if (files) {
      this.readFiles(files, 0);
    }
  }

  private readFiles(files: any[], index: number) {
    const file = files[index];
    this.fileReader.onload = () => {
      this.base64Files.push(<string>this.fileReader.result);
      if (files[index + 1]) {
        this.readFiles(files, index + 1);
      } else {
        this.display_img = true;
      }
    };
    this.fileReader.readAsDataURL(file);
  }

  Submit() {
    this.submission = {
      IdUser: JSON.parse(localStorage.getItem('loged_user')).IdUser,
      Copyrighted: 1,
      Photo: this.base64Files[0],
      Description: this.feedbackImageForm.controls['Description'].value,
      DatePosted: new Date(),
      CategoryId: this.feedbackImageForm.controls['FeedbackCategory'].value
    } as FeedbackImageModel;
    this.feedbackSubmitionSvc.UploadFeedbackImage(this.submission).subscribe(res => {
        this.loadSubmissions();
      },
      err => {
        alert('Failed to upload image');
    });
  }

  GoToImage(idImage: number) {
    this.router.navigateByUrl(`/image-feedback/${idImage}`);
  }
}
