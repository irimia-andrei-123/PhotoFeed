import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { EmployeeModel } from 'src/app/Models/EmployeeModel';
import { User } from 'src/app/Models/UserModel';

@Injectable({
    providedIn: 'root'
})

export class UserService {

    constructor(private httpClient: HttpClient) { }

    public GetUsers(): Observable<EmployeeModel[]> {
        return this.httpClient.get<EmployeeModel[]>('http://localhost:54768/api/users/getAllForEmployees')
            .pipe(
                catchError((err: HttpErrorResponse) => {
                  return [];
                  })
            );
    }

    public GetAllUsers(): Observable<any> {
        return this.httpClient.get<User>('http://localhost:54768/api/users/getAll')
            .pipe(
                catchError((err: HttpErrorResponse) => {
                  return [];
                  })
            );
    }

    public ChangeUserBlockStatus(userId: number): Observable<any> {
        return this.httpClient.put(`http://localhost:54768/api/users/changeBlockStatus/${userId}`, {});
    }

    public GetUser(userId: number): Observable<User> {
        return this.httpClient.get<User>(`http://localhost:54768/api/users/get/${userId}`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                  return [];
                  })
            );
    }

    public GetUserPortfolio(userId: number): Observable<Array<string>> {
        return this.httpClient.get<Array<string>>(`http://localhost:54768/api/users/getProfileImages/${userId}`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                  return [];
                  })
            );
    }
}
