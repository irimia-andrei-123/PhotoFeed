import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatChipInputEvent } from '@angular/material';
import { CategoryService } from '../Services/CategoryService/Category';
import { CategoryModel } from '../Models/CategoryModel';
import { UploadImageModel } from '../Models/UploadImageModel';
import { UploadService } from '../Services/UploadService/Upload';
import { Router } from '@angular/router';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  uploadForm: FormGroup;
  image: UploadImageModel;

  // for images
  base64Files: string[] = [];
  private fileReader = new FileReader();
  display_img: Boolean = false;

  // for categories
  categoryList: CategoryModel[];

  // for tags
  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  readonly separatorKeysCodes: number[] = [32, 13];
  tags: string[] = [];

  constructor(private catService: CategoryService, private uploadSvc: UploadService, private router: Router) { }

  ngOnInit() {
    this.uploadForm = new FormGroup({
      Picture : new FormControl(''),
      Description : new FormControl(''),
      Categories : new FormControl(''),
      Tags : new FormControl('')
    });
    this.catService.GetCategoriesInfo().subscribe(rez => {
      this.categoryList = rez;
    });
  }

  add(event: MatChipInputEvent) {
    const value = event.value;
    if ((value || '').trim()) {
      this.tags.push(value.trim());
    }

    const input = event.input;
    if (input) {
      input.value = '';
    }
  }

  remove(tag: string) {
    const index = this.tags.indexOf(tag);
    if (index >= 0) {
      this.tags.splice(index, 1);
    }
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

  Upload() {
    console.log(this.tags);
    this.image = {
      Photo: this.base64Files[0],
      IdUser: JSON.parse(localStorage.getItem('loged_user')).IdUser,
      Copyrighted: 1,
      Description: this.uploadForm.controls.Description.value,
      DatePosted: new Date(),
      Rating: 0,
      Categories: this.uploadForm.controls.Categories.value,
      Tags: this.tags
    } as UploadImageModel;
    this.uploadSvc.UploadImage(this.image).subscribe(res => {
      this.router.navigateByUrl(`/image/${res}`);
    },
    err => {
      alert('Failed to upload image');
    });
  }

}
