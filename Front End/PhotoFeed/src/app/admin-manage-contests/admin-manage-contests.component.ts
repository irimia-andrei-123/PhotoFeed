import { Component, OnInit } from '@angular/core';
import { BasicContest } from '../Models/CreateBasicContestModel';
import { ContestBasicService } from '../Services/ContestService/ContestBasic';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-manage-contests',
  templateUrl: './admin-manage-contests.component.html',
  styleUrls: ['./admin-manage-contests.component.css']
})
export class AdminManageContestsComponent implements OnInit {
  activeContestBasicList: BasicContest[];

  constructor(private contestbasicService: ContestBasicService, private router: Router) {
    this.contestbasicService.GetAllActiveContestBasic().subscribe(res => {
      this.activeContestBasicList = res;
    },
    err => {
      alert('Failed to load contests');
    });
  }

  ngOnInit() {
  }

  EndContest(contestId: number) {
    this.contestbasicService.EndBasicContest(contestId).subscribe(() => {
      this.contestbasicService.GetAllActiveContestBasic().subscribe(res => {
        this.activeContestBasicList = res;
      },
      err => {
        alert('Failed to load contests');
      });
    },
    err => {
      alert('Failed to create contest');
    });
  }

  GoToContest(contestId: number) {
    this.router.navigateByUrl(`basic-contest/${contestId}`);
  }

}
