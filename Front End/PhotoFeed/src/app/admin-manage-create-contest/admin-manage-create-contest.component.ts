import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { BasicContest } from '../Models/CreateBasicContestModel';
import { ContestBasicService } from '../Services/ContestService/ContestBasic';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-manage-create-contest',
  templateUrl: './admin-manage-create-contest.component.html',
  styleUrls: ['./admin-manage-create-contest.component.css']
})
export class AdminCreateContestComponent implements OnInit {

  contestBasicData: BasicContest;
  contestBasicForm: FormGroup;

  constructor(private contestbasicService: ContestBasicService, private router: Router) { }

  ngOnInit() {
    this.contestBasicForm = new FormGroup({
      ContestName : new FormControl(''),
      Description : new FormControl(''),
      MaxPhotos: new FormControl(''),
      EndDate : new FormControl('')
    });
  }

  Create() {
    this.contestBasicData = {
      IdCreator: JSON.parse(localStorage.getItem('loged_user')).IdUser,
      ContestName: this.contestBasicForm.controls.ContestName.value,
      Description: this.contestBasicForm.controls.Description.value,
      MaximumPictureNumber: this.contestBasicForm.controls.MaxPhotos.value,
      StartDate: new Date(),
      EndDate: this.contestBasicForm.controls.EndDate.value,
      Closed: 0
    } as BasicContest;

    this.contestbasicService.AddBasicContest(this.contestBasicData).subscribe(() => {
      window.location.reload();
    },
    err => {
      alert('Failed to create contest');
    });
  }
}
