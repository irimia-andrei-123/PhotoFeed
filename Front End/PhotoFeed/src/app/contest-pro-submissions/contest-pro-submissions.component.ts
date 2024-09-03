import { Component, OnInit } from '@angular/core';
import { ProContest } from '../Models/CreateProContestModel';
import { ContestProService } from '../Services/ContestService/ContestProService';
import { Router, ActivatedRoute } from '@angular/router';
import { PhotoProContest } from '../Models/PhotoProContestModel';
import { CompanyService } from '../Services/CompanyService/CompanyService';

@Component({
  selector: 'app-contest-pro-submissions',
  templateUrl: './contest-pro-submissions.component.html',
  styleUrls: ['./contest-pro-submissions.component.css']
})
export class ContestProSubmissionsComponent implements OnInit {
  contestInfo: ProContest;
  contestEnded: boolean;
  submissions: PhotoProContest[];
  voteScore = 0;
  isCompanyMember = false;

  constructor(private contestProService: ContestProService, private router: Router, private route: ActivatedRoute,
    private companyService: CompanyService) {
    this.contestProService.GetProContest(+this.route.snapshot.paramMap.get('id')).subscribe(res => {
      this.contestInfo = res;
      this.contestEnded = (this.contestInfo.EndDate.toString() < new Date().toISOString()) || (this.contestInfo.Closed === 1);
      this.contestProService.GetContestSubmissions(+this.route.snapshot.paramMap.get('id'), this.contestEnded).subscribe(res2 => {
        this.submissions = res2;
      },
      err => {
        alert('Failed to load submissions');
      });

      const userId = JSON.parse(localStorage.getItem('loged_user')).IdUser;
      this.companyService.GetCompanyMembers(this.contestInfo.IdCreator).subscribe( rez => {
        const members = rez.map( x => x.IdUser);

        if (members.includes(userId)) {
          this.isCompanyMember = true;
        }
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

    this.contestProService.SubmitVote(photoId, this.voteScore).subscribe(() => {
      this.voteScore = 0;
      this.formatLabel(this.voteScore);
    },
    err => {
      alert('Failed to vote');
    });
  }
}
