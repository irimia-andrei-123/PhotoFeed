import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../Services/CategoryService/Category';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryImageModel } from '../Models/CategoryImageModel';

@Component({
  selector: 'app-categories-images',
  templateUrl: './categories-images.component.html',
  styleUrls: ['./categories-images.component.css']
})
export class CategoriesImagesComponent implements OnInit {

  constructor(private catService: CategoryService, private route: ActivatedRoute, private router: Router) { }

  imgArr: CategoryImageModel[];
  public base64Files: string[] = [];
  display_img;
  category;

  ngOnInit() {
    this.category = Number(this.route.snapshot.paramMap.get('id'));
    this.catService.GetCategoriesImages(this.category).subscribe(rez => {
      if (rez.length === 0) {
        this.display_img = false;
      } else {
        this.display_img = true;
        this.imgArr = rez;
      }
    });
  }

  GoToImage(idImage: number) {
    this.router.navigateByUrl(`/image/${idImage}`);
  }

  GoToUser(idUser: number) {
    this.router.navigateByUrl(`/user/${idUser}`);
  }

}
