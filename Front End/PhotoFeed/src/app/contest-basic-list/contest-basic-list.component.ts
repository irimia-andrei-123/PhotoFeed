import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BasicContest } from '../Models/CreateBasicContestModel';
import { ContestBasicService } from '../Services/ContestService/ContestBasic';

@Component({
  selector: 'app-contest-basic-list',
  templateUrl: './contest-basic-list.component.html',
  styleUrls: ['./contest-basic-list.component.css']
})
export class ContestBasicListComponent implements OnInit {
  activeContestBasicList: BasicContest[];
  inactiveContestBasicList: BasicContest[];

  constructor(private contestBasicService: ContestBasicService, private router: Router) {
    this.contestBasicService.GetAllActiveContestBasic().subscribe(res => {
      this.activeContestBasicList = res;
    },
    err => {
      alert('Failed to load contests');
    });
    this.contestBasicService.GetAllInactiveContestBasic().subscribe(res => {
      this.inactiveContestBasicList = res;
    },
    err => {
      alert('Failed to load contests');
    });
  }

  ngOnInit() {
  }

  navigateToContest(id: number) {
    this.router.navigate(['basic-contest/', id]);
  }

}
