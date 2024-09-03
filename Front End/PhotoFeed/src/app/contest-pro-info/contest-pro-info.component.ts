import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ContestSubmission } from '../Models/ContestSubmissionModel';
import { ProContest } from '../Models/CreateProContestModel';
import { ContestProService } from '../Services/ContestService/ContestProService';
import { UploadService } from '../Services/UploadService/Upload';

@Component({
  selector: 'app-contest-pro-info',
  templateUrl: './contest-pro-info.component.html',
  styleUrls: ['./contest-pro-info.component.css']
})
export class ContestProInfoComponent implements OnInit {
  constestSubmission: ContestSubmission;
  contestEnded: boolean;
  contestInfo: ProContest;
  submissionForm: FormGroup;
  noSubmitImgs: number[];
  public base64Files: string[] = [];
  private fileReader = new FileReader();

  constructor(private contestProService: ContestProService, private router: Router,
    private route: ActivatedRoute, private uploadSvc: UploadService) {
    this.contestProService.GetProContest(+this.route.snapshot.paramMap.get('id')).subscribe(res => {
      this.contestInfo = res;
      this.contestEnded = (this.contestInfo.EndDate.toString() < new Date().toISOString()) || (this.contestInfo.Closed === 1);
    },
    err => {
      alert('Failed to load contest');
    });
  }

  ngOnInit() {
    this.submissionForm = new FormGroup({
      SubmitedPictures: new FormControl('')
    });
  }

  onFileChanged(event: Event, maxPics: number) {
    this.noSubmitImgs = [];
    const files = event.target['files'];
    if (files) {
      this.readFiles(files, 0, maxPics);
    }
  }

  private readFiles(files: any[], index: number, maxPics: number) {
    const file = files[index];
    if (index < maxPics) {
      this.fileReader.onload = () => {
        this.base64Files.push(<string>this.fileReader.result);
        this.noSubmitImgs.push(index);
        if (files[index + 1]) {
          this.readFiles(files, index + 1, maxPics);
        }
      };
    } else {
      return;
    }
    this.fileReader.readAsDataURL(file);
  }

  navigateToVote() {
    const contestId = this.route.snapshot.paramMap.get('id');
    this.router.navigate(['pro-contest-submissions/', contestId]);
  }

  Submit() {
    this.constestSubmission = {
      IdUser: JSON.parse(localStorage.getItem('loged_user')).IdUser,
      Photos: this.base64Files,
      IdContest: +this.route.snapshot.paramMap.get('id'),
    } as ContestSubmission;

    if (this.constestSubmission.IdUser === undefined) {
      alert('Companies can not submit images!');
    } else {
      this.uploadSvc.SubmitProContest(this.constestSubmission).subscribe(res => {
        window.location.reload();
      },
      err => {
        alert('Failed to submit images');
      });
    }
  }
}
