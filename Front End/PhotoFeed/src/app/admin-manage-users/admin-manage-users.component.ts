import { Component, OnInit } from '@angular/core';
import { User } from '../Models/UserModel';
import { UserService } from '../Services/UserService/User';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-manage-users',
  templateUrl: './admin-manage-users.component.html',
  styleUrls: ['./admin-manage-users.component.css']
})
export class AdminManageUsersComponent implements OnInit {
  UsersList: User[];

  constructor(private userService: UserService, private router: Router) {
    this.userService.GetAllUsers().subscribe(res => {
      this.UsersList = res;
    },
    err => {
      alert('Failed to load users');
    });
  }

  ngOnInit() {
  }

  ChangeBlockStatus(userId: number) {
    this.userService.ChangeUserBlockStatus(userId).subscribe(() => {
      this.userService.GetAllUsers().subscribe(res => {
        this.UsersList = res;
      },
      err => {
        alert('Failed to load users');
      });
    },
    err => {
      alert('Failed to update user');
    });
  }

  GoToUser(userId: number) {
    this.router.navigateByUrl(`user/${userId}`);
  }

}
