import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { tap, first } from 'rxjs/operators';
import { AuthService } from './Auth';
import { Location } from '@angular/common';

@Injectable({
  providedIn: 'root'
})

export class AuthGuardService implements CanActivate {

  constructor(private authService: AuthService, private router: Router, private location: Location) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> {

      return this.authService.isAuthenticated().pipe(
        first(),
        tap(authFlag => {
          if (!authFlag) {
            console.error('You shall not pass!!!');
            this.location.replaceState('/');
            this.router.navigate(['/startpage/login']);
          }
          return authFlag;
        })
      );
  }
}
