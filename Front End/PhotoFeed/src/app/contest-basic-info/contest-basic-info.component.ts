import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { BasicContest } from '../Models/CreateBasicContestModel';
import { ContestBasicService } from '../Services/ContestService/ContestBasic';
import { ContestSubmission } from '../Models/ContestSubmissionModel';
import { UploadService } from '../Services/UploadService/Upload';

@Component({
  selector: 'app-contest-basic-info',
  templateUrl: './contest-basic-info.component.html',
  styleUrls: ['./contest-basic-info.component.css']
})
export class ContestBasicInfoComponent implements OnInit {
  constestSubmission: ContestSubmission;
  contestEnded: boolean;
  contestInfo: BasicContest;
  submissionForm: FormGroup;
  noSubmitImgs: number[];
  public base64Files: string[] = [];
  private fileReader = new FileReader();

  constructor(private contestbasicService: ContestBasicService, private router: Router,
    private route: ActivatedRoute, private uploadSvc: UploadService) {
    this.contestbasicService.GetBasicContest(+this.route.snapshot.paramMap.get('id')).subscribe(res => {
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
    this.router.navigate(['basic-contest-submissions/', contestId]);
  }

  Submit() {
    this.constestSubmission = {
      IdUser: JSON.parse(localStorage.getItem('loged_user')).IdUser,
      Photos: this.base64Files,
      IdContest: +this.route.snapshot.paramMap.get('id'),
    } as ContestSubmission;

    this.uploadSvc.SubmitBasicContest(this.constestSubmission).subscribe(res => {
      window.location.reload();
    },
    err => {
      alert('Failed to submit images');
    });
  }
}
