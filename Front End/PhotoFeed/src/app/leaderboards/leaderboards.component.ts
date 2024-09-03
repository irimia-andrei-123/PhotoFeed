import { Component, OnInit } from '@angular/core';
import { LeaderboardService } from '../Services/LeaderboardService/Leaderboard';
import { Router } from '@angular/router';

@Component({
  selector: 'app-leaderboards',
  templateUrl: './leaderboards.component.html',
  styleUrls: ['./leaderboards.component.css']
})
export class LeaderboardsComponent implements OnInit {

  sortCriteria = [{name: 'Total Points', value: 0},
    { name: 'Number of pro contests won', value: 1},
    { name: 'Number of basic contests won', value: 2}];
  selectedSort = this.sortCriteria[0].value;

  displayedColumns: string[] = ['position', 'name', 'totalPoints', 'proContestsWon', 'basicContestsWon'];

  dataSource = null;

  constructor(private leaderboardService: LeaderboardService, private router: Router) { }

  ngOnInit() {
    this.leaderboardService.GetLeaderboardInfo(this.selectedSort).subscribe(rez => {
      this.dataSource = rez;
    });
  }

  GoToUser(idUser: number) {
    this.router.navigateByUrl(`/user/${idUser}`);
  }

  ReloadLeaders(criteria)  {
    this.leaderboardService.GetLeaderboardInfo(this.selectedSort).subscribe(rez => {
      this.dataSource = rez;
    });
  }

}
