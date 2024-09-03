import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { AuthService } from './Services/AuthService/Auth';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'PhotoFeed';
  isUser = true;

  constructor(private router: Router, private authService: AuthService) { }

  navigateTo(url: string) {
    this.router.navigate([url]);
  }

  navigateToProfile() {
    if (JSON.parse(localStorage.getItem('loged_user')).IdUser !== undefined) {
      this.router.navigate(['user/', JSON.parse(localStorage.getItem('loged_user')).IdUser]);
    } else {
      this.router.navigate(['comapny/', JSON.parse(localStorage.getItem('loged_user')).IdCompany]);
    }
  }

  logout() {
    this.authService.Logout();
  }

  ngOnInit() {
    if (JSON.parse(localStorage.getItem('loged_user')).IdCompany !== undefined) {
      this.isUser = false;
    }

    this.router.routeReuseStrategy.shouldReuseRoute = function() {
      return false;
    };

    this.router.events.subscribe((evt) => {
        if (evt instanceof NavigationEnd) {
            this.router.navigated = false;
            window.scrollTo(0, 0);
        }
    });
  }
}
