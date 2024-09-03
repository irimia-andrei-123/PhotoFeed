import { Component, OnInit } from '@angular/core';
import { Company } from '../Models/CompanyModel';
import { Router } from '@angular/router';
import { CompanyService } from '../Services/CompanyService/CompanyService';

@Component({
  selector: 'app-admin-manage-companies',
  templateUrl: './admin-manage-companies.component.html',
  styleUrls: ['./admin-manage-companies.component.css']
})
export class AdminManageCompaniesComponent implements OnInit {
  CompaniesList: Company;

  constructor(private companyService: CompanyService, private router: Router) {
    this.companyService.GetPendingCompanies().subscribe(res => {
      this.CompaniesList = res;
    },
    err => {
      alert('Failed to load companies');
    });
  }

  ngOnInit() {
  }

  GoToCompany(companyId: number) {
    this.router.navigateByUrl(`user/${companyId}`);
  }

  DenyCompany(companyId: number) {
    this.companyService.DenyComapny(companyId).subscribe(() => {
      this.companyService.GetPendingCompanies().subscribe(res => {
        this.CompaniesList = res;
      },
      err => {
        alert('Failed to load companies');
      });
    },
    err => {
      alert('failed to update company');
    });
  }

  AllowCompany(companyId: number) {
    this.companyService.AllowComapny(companyId).subscribe(() => {
      this.companyService.GetPendingCompanies().subscribe(res => {
        this.CompaniesList = res;
      },
      err => {
        alert('Failed to load companies');
      });
    },
    err => {
      alert('failed to update company');
    });
  }
}

