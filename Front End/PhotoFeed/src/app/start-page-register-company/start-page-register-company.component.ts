import { Component, OnInit } from '@angular/core';
import { UserRegisterModel } from '../Models/UserRegisterModel';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../Services/AuthService/Auth';
import { EmployeeModel } from '../Models/EmployeeModel';
import { UserService } from '../Services/UserService/User';
import { Company } from '../Models/CompanyModel';
import { CompanyContact } from '../Models/CompanyContactModule';

@Component({
  selector: 'app-start-page-register-company',
  templateUrl: './start-page-register-company.component.html',
  styleUrls: ['./start-page-register-company.component.css']
})
export class StartPageRegisterCompanyComponent implements OnInit {

  employeeList: EmployeeModel[];

  user: Company;
  registerForm: FormGroup;
  public base64Files: string[] = [];
  private fileReader = new FileReader();
  display_img: Boolean = false;

  constructor(private router: Router, private authSvc: AuthService, private usrService: UserService) { }

  ngOnInit() {
    this.registerForm = new FormGroup({
      CompanyName : new FormControl(''),
      ProfilePicture : new FormControl(''),
      Members : new FormControl(''),
      Description: new FormControl(''),
      Email : new FormControl(''),
      Password : new FormControl(''),
      ContactName : new FormControl(''),
      ContactLink : new FormControl('')
    });
    this.usrService.GetUsers().subscribe(rez => {
      this.employeeList = rez;
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
    } as CompanyContact;

    const contactInfoArray = new Array<CompanyContact>();
    contactInfoArray.push(contactInfo);

    this.user = {
      CompanyName: this.registerForm.controls['CompanyName'].value,
      ProfilePicture: this.base64Files[0],
      Description: this.registerForm.controls['Description'].value,
      Email: this.registerForm.controls['Email'].value,
      Password: this.registerForm.controls['Password'].value,
      Members:  this.registerForm.controls['Members'].value,
      Allowed: 0,
      ContactInfo: contactInfoArray
    } as Company;
    this.authSvc.RegisterCompany(this.user).subscribe(res => {
      this.router.navigate(['login']);
    },
    err => {
      alert('A user with the same email already exists.');
    });
  }

}
