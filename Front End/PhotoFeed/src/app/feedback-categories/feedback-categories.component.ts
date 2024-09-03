import { Component, OnInit } from '@angular/core';
import { CategoryModel } from '../Models/CategoryModel';
import { CategoryService } from '../Services/CategoryService/Category';
import { Router } from '@angular/router';

@Component({
  selector: 'app-feedback-categories',
  templateUrl: './feedback-categories.component.html',
  styleUrls: ['./feedback-categories.component.css']
})
export class FeedbackCategoriesComponent implements OnInit {

  constructor(private catService: CategoryService, private router: Router) { }

  categoryArr: CategoryModel[];
  categoriesDisplayed = false;

  ngOnInit() {
    this.catService.GetCategoriesInfo().subscribe(rez => {
      this.categoryArr = rez;
    });
  }

  navigateToCategory(url: string) {
    this.router.navigateByUrl('feedback-category/' + url);
  }

}
