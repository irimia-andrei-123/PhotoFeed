import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { UserRegisterModel } from '../../Models/UserRegisterModel';
import { UserLoginModel } from '../../Models/UserLoginModel';
import { User } from 'src/app/Models/UserModel';
import { Company } from 'src/app/Models/CompanyModel';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  constructor(private httpClient: HttpClient, private router: Router) { }

  public isAuthenticated(): Observable<boolean> {
    return of(localStorage.getItem('loged_user') !== null);
  }

  public isAdmin(): Observable<boolean> {
    return of(JSON.parse(localStorage.getItem('loged_user')).Email === 'admin@admin.com');
  }


  public LoginUser(user: UserLoginModel): Observable<User> {
    return this.httpClient.post<User>('http://localhost:54768/api/startpage/login', user);
  }

  public Logout() {
    localStorage.removeItem('loged_user');
    this.router.navigate(['startpage']);
  }

  public RegisterUser(user: UserRegisterModel): Observable<Object> {
    return this.httpClient.post('http://localhost:54768/api/startpage/register-user', user);
  }

  public RegisterCompany(company: Company): Observable<Object> {
    return this.httpClient.post('http://localhost:54768/api/startpage/register-company', company);
  }

}
