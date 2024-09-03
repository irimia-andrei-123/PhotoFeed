import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ProContest } from '../Models/CreateProContestModel';
import { ContestProService } from '../Services/ContestService/ContestProService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-company-contest',
  templateUrl: './company-contest.component.html',
  styleUrls: ['./company-contest.component.css']
})
export class CompanyContestComponent implements OnInit {
  contestProData: ProContest;
  contestProForm: FormGroup;

  constructor(private contestProService: ContestProService, private router: Router) { }

  ngOnInit() {
    this.contestProForm = new FormGroup({
      ContestName : new FormControl(''),
      Description : new FormControl(''),
      MaxPhotos: new FormControl(''),
      EndDate : new FormControl('')
    });
  }

  Create() {
    this.contestProData = {
        IdCreator: JSON.parse(localStorage.getItem('loged_user')).IdCompany,
        ContestName: this.contestProForm.controls.ContestName.value,
        Description: this.contestProForm.controls.Description.value,
        MaximumPictureNumber: this.contestProForm.controls.MaxPhotos.value,
        StartDate: new Date(),
        EndDate: this.contestProForm.controls.EndDate.value,
        Closed: 0
      } as ProContest;

      this.contestProService.AddProContest(this.contestProData).subscribe(() => {
        window.location.reload();
      },
      err => {
        alert('Failed to create contest');
      });
  }
}
