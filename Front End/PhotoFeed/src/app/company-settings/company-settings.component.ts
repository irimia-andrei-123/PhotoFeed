import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-user-settings',
  templateUrl: './company-settings.component.html',
  styleUrls: ['./company-settings.component.css']
})
export class CompanySettingsComponent implements OnInit {

  // newInfo: UserInfoModel;
  editForm: FormGroup;
  public base64Files: string[] = [];
  private fileReader = new FileReader();

  constructor() { }

  ngOnInit() {
    // load base64Files with current pic
    // load new info with the already existing data
    this.editForm = new FormGroup({
      UserName : new FormControl(''),
      ProfilePicture : new FormControl(''),
      Description: new FormControl(''),
      Websites : new FormControl('')
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
      }
    };
    this.fileReader.readAsDataURL(file);
  }

  Save() {
    // call la api care incarca datele stocate + redirect la profil
  }

}
