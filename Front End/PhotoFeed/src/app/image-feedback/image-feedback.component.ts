import { Component, OnInit } from '@angular/core';
import { UploadService } from '../Services/UploadService/Upload';
import { ActivatedRoute, Router } from '@angular/router';
import { ImageInfoModel } from '../Models/ImageInfoModel';
import { FeedbackService } from '../Services/FeedbackService/Feedback';
import { FeedbackPost } from '../Models/FeedbackPostModel';
import { FormGroup, FormControl } from '@angular/forms';
import { FeedbackComment } from '../Models/FeedbackCommentModel';

@Component({
  selector: 'app-image',
  templateUrl: './image-feedback.component.html',
  styleUrls: ['./image-feedback.component.css']
})
export class ImageFeedbackComponent implements OnInit {
  post: FeedbackPost;
  commentForm: FormGroup;

  constructor(private feedbackService: FeedbackService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.loadPost();
    this.commentForm = new FormGroup({
      Comment : new FormControl(''),
    });
  }

  loadPost() {
    this.feedbackService.GetFeedbackPost(Number(this.route.snapshot.paramMap.get('id'))).subscribe(rez => {
      if (rez == null) {
        console.log('eroare');
      } else {
        this.post = rez;
      }
    });
  }

  GoToUser(userId: number) {
    this.router.navigateByUrl(`user/${userId}`);
  }

  Comment() {
    const comment = {
      CommenterName: JSON.parse(localStorage.getItem('loged_user')).UserName,
      DatePosted: new Date(),
      IdCommenter: JSON.parse(localStorage.getItem('loged_user')).IdUser,
      IdPhotoFeedback: Number(this.route.snapshot.paramMap.get('id')),
      Miscellaneous: this.commentForm.getRawValue().Comment
    } as FeedbackComment;

    this.feedbackService.AddComment(comment).subscribe( () => {
      this.commentForm.reset();
      this.feedbackService.GetFeedbackPost(Number(this.route.snapshot.paramMap.get('id'))).subscribe(rez => {
        if (rez == null) {
          console.log('eroare');
        } else {
          this.post = rez;
        }
      });
    } );
  }
}
