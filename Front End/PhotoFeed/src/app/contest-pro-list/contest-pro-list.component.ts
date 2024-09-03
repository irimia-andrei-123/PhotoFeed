import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProContest } from '../Models/CreateProContestModel';
import { ContestProService } from '../Services/ContestService/ContestProService';

@Component({
  selector: 'app-contest-pro-list',
  templateUrl: './contest-pro-list.component.html',
  styleUrls: ['./contest-pro-list.component.css']
})
export class ContestProListComponent implements OnInit {

  activeContestProList: ProContest[];
  inactiveContestProList: ProContest[];

  constructor(private contestProService: ContestProService, private router: Router) {
    this.contestProService.GetAllActiveContestPro().subscribe(res => {
      this.activeContestProList = res;
    },
    err => {
      alert('Failed to load contests');
    });
    this.contestProService.GetAllInactiveContestPro().subscribe(res => {
      this.inactiveContestProList = res;
    },
    err => {
      alert('Failed to load contests');
    });
  }

  ngOnInit() {
  }

  navigateToContest(id: number) {
    this.router.navigate(['pro-contest/', id]);
  }

}
