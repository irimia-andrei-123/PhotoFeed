import { Component, OnInit } from '@angular/core';
import { BasicContest } from '../Models/CreateBasicContestModel';
import { ContestBasicService } from '../Services/ContestService/ContestBasic';
import { Router, ActivatedRoute } from '@angular/router';
import { PhotoBasicContest } from '../Models/PhotoBasicContestModel';

@Component({
  selector: 'app-contest-basic-submissions',
  templateUrl: './contest-basic-submissions.component.html',
  styleUrls: ['./contest-basic-submissions.component.css']
})
export class ContestBasicSubmissionsComponent implements OnInit {
  contestInfo: BasicContest;
  contestEnded: boolean;
  submissions: PhotoBasicContest[];
  voteScore = 0;

  constructor(private contestbasicService: ContestBasicService, private router: Router, private route: ActivatedRoute) {
    this.contestbasicService.GetBasicContest(+this.route.snapshot.paramMap.get('id')).subscribe(res => {
      this.contestInfo = res;
      this.contestEnded = (this.contestInfo.EndDate.toString() < new Date().toISOString()) || (this.contestInfo.Closed === 1);
      this.contestbasicService.GetContestSubmissions(+this.route.snapshot.paramMap.get('id'), this.contestEnded).subscribe(res2 => {
        this.submissions = res2;
      },
      err => {
        alert('Failed to load submissions');
      });
    },
    err => {
      alert('Failed to load contest');
    });
  }

  ngOnInit() {
  }

  formatLabel(value: number | null) {
    if (!value) {
      return 0;
    }
    return value;
  }

  updateVote(event) {
    this.voteScore = event.value;
  }

  Vote(photoId: number) {
    document.getElementById(`voteId${photoId}`).style.display = 'none';

    this.contestbasicService.SubmitVote(photoId, this.voteScore).subscribe(() => {
      this.voteScore = 0;
      this.formatLabel(this.voteScore);
    },
    err => {
      alert('Failed to vote');
    });
  }

}
