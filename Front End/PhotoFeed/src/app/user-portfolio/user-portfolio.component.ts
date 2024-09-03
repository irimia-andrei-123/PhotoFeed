import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../Services/UserService/User';

@Component({
  selector: 'app-user-portfolio',
  templateUrl: './user-portfolio.component.html',
  styleUrls: ['./user-portfolio.component.css']
})
export class UserPortfolioComponent implements OnInit {
  userPhotos: Array<string>;

  constructor(private router: Router, private route: ActivatedRoute, private userService: UserService) {
    this.userService.GetUserPortfolio(Number(this.route.snapshot.paramMap.get('id'))).subscribe(res => {
      this.userPhotos = res;
    });
  }

  ngOnInit() {
  }

}
