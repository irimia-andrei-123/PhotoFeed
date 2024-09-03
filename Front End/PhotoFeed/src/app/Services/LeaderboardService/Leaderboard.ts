import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LeaderModel } from '../../Models/LeaderModel';
import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class LeaderboardService {

    constructor(private httpClient: HttpClient) { }

    public GetLeaderboardInfo(criteria: number): Observable<LeaderModel[]> {
        return this.httpClient.get<LeaderModel[]>(`http://localhost:54768/api/startpage/leaderboard/${criteria}`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                  return [];
                  })
            );
    }
}
