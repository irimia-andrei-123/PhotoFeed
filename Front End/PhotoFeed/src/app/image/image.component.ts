import { Component, OnInit } from '@angular/core';
import { UploadService } from '../Services/UploadService/Upload';
import { ActivatedRoute } from '@angular/router';
import { ImageInfoModel } from '../Models/ImageInfoModel';

@Component({
  selector: 'app-image',
  templateUrl: './image.component.html',
  styleUrls: ['./image.component.css']
})
export class ImageComponent implements OnInit {

  post: ImageInfoModel;

  constructor(private uploadSvc: UploadService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.loadPost();
  }

  loadPost() {
    this.uploadSvc.GetPost(Number(this.route.snapshot.paramMap.get('id'))).subscribe(rez => {
      if (rez == null) {
        console.log('eroare');
      } else {
        this.post = rez;
      }
    });
    console.log(this.post);
  }

}
