import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CompanyService } from '../Services/CompanyService/CompanyService';
import { CompanyProfile } from '../Models/CompanyProfileModel';

@Component({
  selector: 'app-company-info',
  templateUrl: './company-info.component.html',
  styleUrls: ['./company-info.component.css']
})
export class CompanyInfoComponent implements OnInit {
  company: CompanyProfile;
  currentCompany = false;
  isCompany = false;

  constructor(private router: Router, private route: ActivatedRoute, private companyService: CompanyService) {
    this.companyService.GetCompany(Number(this.route.snapshot.paramMap.get('id'))).subscribe(res => {
      this.company = res;
      if (Number(this.route.snapshot.paramMap.get('id')) === Number(JSON.parse(localStorage.getItem('loged_user')).IdCompany)) {
        this.currentCompany = true; 
      }
      if (Number(JSON.parse(localStorage.getItem('loged_user')).IdCompany)) {
        this.isCompany = true;
      }
    },
    err => {
      alert('Failed to load companys');
    });
  }

  ngOnInit() {
  }

  navigateTo(url: string) {
    const companyId = this.route.snapshot.paramMap.get('id');
    this.router.navigate([url + '/' + companyId]);
  }

  navigateToSettings() {
    this.router.navigate(['company-settings']);
  }

  navigateToNewContest() {
    this.router.navigate(['company-new-contest']);
  }

}
