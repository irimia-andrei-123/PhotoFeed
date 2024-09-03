import { Component, OnInit } from '@angular/core';
import { UserRegisterModel } from '../Models/UserRegisterModel';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../Services/AuthService/Auth';
import { UserContact } from '../Models/UserContactModel';

@Component({
  selector: 'app-start-page-register-user',
  templateUrl: './start-page-register-user.component.html',
  styleUrls: ['./start-page-register-user.component.css']
})
export class StartPageRegisterUserComponent implements OnInit {

  user: UserRegisterModel;
  registerForm: FormGroup;
  public base64Files: string[] = [];
  private fileReader = new FileReader();
  display_img: Boolean = false;

  constructor(private router: Router, private authSvc: AuthService) { }

  ngOnInit() {
    this.registerForm = new FormGroup({
      UserName : new FormControl(''),
      ProfilePicture : new FormControl(''),
      Description: new FormControl(''),
      Email : new FormControl(''),
      Password : new FormControl(''),
      ContactName : new FormControl(''),
      ContactLink : new FormControl('')
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

  Register() {
    const contactInfo = {
      WebsiteName : this.registerForm.controls['ContactName'].value,
      WebsiteUrl : this.registerForm.controls['ContactLink'].value
    } as UserContact;

    const contactInfoArray = new Array<UserContact>();
    contactInfoArray.push(contactInfo);

    this.user = {
      UserName: this.registerForm.controls['UserName'].value,
      ProfilePicture: this.base64Files[0],
      Description: this.registerForm.controls['Description'].value,
      Email: this.registerForm.controls['Email'].value,
      Password: this.registerForm.controls['Password'].value,
      Verified: 1,
      Points: 0,
      Moderator: 1,
      ContactInfo: contactInfoArray
    } as UserRegisterModel;
    this.authSvc.RegisterUser(this.user).subscribe(res => {
      this.router.navigate(['login']);
    },
    err => {
      alert('A user with the same email already exists.');
    });
  }

}
