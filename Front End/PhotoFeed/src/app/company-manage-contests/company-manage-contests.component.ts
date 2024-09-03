import { Component, OnInit } from '@angular/core';
import { ProContest } from '../Models/CreateProContestModel';
import { ContestProService } from '../Services/ContestService/ContestProService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-company-manage-contests',
  templateUrl: './company-manage-contests.component.html',
  styleUrls: ['./company-manage-contests.component.css']
})
export class CompanyManageContestsComponent implements OnInit {
  activeContestProList: ProContest[];

  constructor(private contestProService: ContestProService, private router: Router) {
    this.contestProService.GetAllActiveContestPro().subscribe(res => {
      this.activeContestProList = res;
    },
    err => {
      alert('Failed to load contests');
    });
  }

  ngOnInit() {
  }

  EndContest(contestId: number) {
    this.contestProService.EndProContest(contestId).subscribe(() => {
      this.contestProService.GetAllActiveContestPro().subscribe(res => {
        this.activeContestProList = res;
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
    this.router.navigateByUrl(`pro-contest/${contestId}`);
  }

}
