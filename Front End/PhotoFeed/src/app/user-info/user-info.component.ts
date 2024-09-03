import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../Services/UserService/User';
import { User } from '../Models/UserModel';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent implements OnInit {
  user: User;
  currentUser = false;
  isCompany = false;
  currentCompany = false;

  constructor(private router: Router, private route: ActivatedRoute, private userService: UserService) {
    this.userService.GetUser(Number(this.route.snapshot.paramMap.get('id'))).subscribe(res => {
      this.user = res;
      if (Number(this.route.snapshot.paramMap.get('id')) === Number(JSON.parse(localStorage.getItem('loged_user')).IdUser)) {
        this.currentUser = true;
      }
      if (Number(JSON.parse(localStorage.getItem('loged_user')).IdCompany)) {
        this.isCompany = true;
      }
      if (Number(this.route.snapshot.paramMap.get('id')) === Number(JSON.parse(localStorage.getItem('loged_user')).IdCompany)) {
        this.currentUser = true;
      }
      console.log(this.user);
    },
    err => {
      alert('Failed to load users');
    });
  }

  ngOnInit() {
  }

  navigateTo(url: string) {
    const userId = this.route.snapshot.paramMap.get('id');
    this.router.navigate([url + '/' + userId]);
  }

  navigateToSettings() {
    this.router.navigate(['user-settings']);
  }

  navigateToNewContest() {
    this.router.navigate(['company-new-contest']);
  }

}
