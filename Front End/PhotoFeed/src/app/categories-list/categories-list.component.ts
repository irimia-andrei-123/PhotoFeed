import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../Services/CategoryService/Category';
import { Router } from '@angular/router';
import { CategoryModel } from '../Models/CategoryModel';

@Component({
  selector: 'app-categories-list',
  templateUrl: './categories-list.component.html',
  styleUrls: ['./categories-list.component.css']
})
export class CategoriesListComponent implements OnInit {

  constructor(private catService: CategoryService, private router: Router) { }

  categoryArr: CategoryModel[];
  categoriesDisplayed = false;

  ngOnInit() {
    this.catService.GetCategoriesInfo().subscribe(rez => {
      this.categoryArr = rez;
    });
  }

  navigateToCategory(url: string) {
    this.router.navigateByUrl('category/' + url);
  }

}
