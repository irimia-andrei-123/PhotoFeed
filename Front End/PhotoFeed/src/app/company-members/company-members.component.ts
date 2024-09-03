import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../Models/UserModel';
import { CompanyService } from '../Services/CompanyService/CompanyService';

@Component({
  selector: 'app-company-members',
  templateUrl: './company-members.component.html',
  styleUrls: ['./company-members.component.css']
})
export class CompanyMembersComponent implements OnInit {
  members = Array<User>();
  constructor(private router: Router, private companyService: CompanyService) { }

  ngOnInit() {
    const companyId = JSON.parse(localStorage.getItem('loged_user')).IdCompany;
    this.companyService.GetCompanyMembers(companyId).subscribe( rez => { this.members = rez; });
  }

  GoToUser(userId: number) {
    this.router.navigateByUrl(`user/${userId}`);
  }
}
