import { Component, OnInit } from '@angular/core';
import { UserLoginModel } from '../Models/UserLoginModel';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../Services/AuthService/Auth';

@Component({
  selector: 'app-start-page-login',
  templateUrl: './start-page-login.component.html',
  styleUrls: ['./start-page-login.component.css']
})
export class StartPageLoginComponent implements OnInit {

  user: UserLoginModel;
  loginForm: FormGroup;

  constructor(private router: Router, private authSvc: AuthService) { }

  ngOnInit() {
    this.loginForm = new FormGroup({
      Email : new FormControl(''),
      Password : new FormControl('')
    });
  }

  Login() {
    this.user = this.loginForm.getRawValue();
    this.authSvc.LoginUser(this.user).subscribe(res => {
      localStorage.setItem('loged_user', JSON.stringify(res));
      if (res.Email === 'admin@admin.com') {
        this.router.navigate(['admin-manage']);
      } else {
        if (JSON.parse(localStorage.getItem('loged_user')).IdCompany !== undefined) {
          this.router.navigate([`comapny/${JSON.parse(localStorage.getItem('loged_user')).IdCompany}`]);
        } else {
          this.router.navigate(['homepage']);
        }
      }
    },
    err => {
      alert('User does not exist.');
    });
  }

}
