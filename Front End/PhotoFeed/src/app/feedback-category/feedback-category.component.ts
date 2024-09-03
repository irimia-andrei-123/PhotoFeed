import { Component, OnInit } from '@angular/core';
import { UserFeedbackSubmissionModel } from '../Models/UserFeedbackSubmissionModel';
import { FeedbackService } from '../Services/FeedbackService/Feedback';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-feedback-category',
  templateUrl: './feedback-category.component.html',
  styleUrls: ['./feedback-category.component.css']
})
export class FeedbackCategoryComponent implements OnInit {

  constructor(private feedbackSubmitionSvc: FeedbackService, private router: Router, private route: ActivatedRoute) { }

  imgArr: UserFeedbackSubmissionModel[];
  display_img;
  category;

  ngOnInit() {
    this.category = Number(this.route.snapshot.paramMap.get('id'));
    this.feedbackSubmitionSvc.GetCategoryPosts(this.category).subscribe(rez => {
      if (rez.length === 0) {
        this.display_img = false;
      } else {
        this.display_img = true;
        this.imgArr = rez;
      }
    });
  }

  GoToUser(idUser: number) {
    this.router.navigateByUrl(`/user/${idUser}`);
  }

  GoToImage(idImage: number) {
    this.router.navigateByUrl(`/image-feedback/${idImage}`);
  }
}
