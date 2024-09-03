import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { BasicContest } from 'src/app/Models/CreateBasicContestModel';
import { PhotoBasicContest } from 'src/app/Models/PhotoBasicContestModel';

@Injectable({
    providedIn: 'root'
})

export class ContestBasicService {

    constructor(private httpClient: HttpClient) { }

    public AddBasicContest(basicContest: BasicContest): Observable<any> {
        return this.httpClient.post(`http://localhost:54768/api/contestBasic/newContestBasic`, basicContest);
    }

    public GetBasicContest(basicContestId: number): Observable<BasicContest> {
        return this.httpClient.get<BasicContest>(`http://localhost:54768/api/contestBasic/${basicContestId}`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                    return [];
                    })
            );
    }

    public GetAllActiveContestBasic(): Observable<any> {
        return this.httpClient.get<BasicContest[]>(`http://localhost:54768/api/contestBasic/active`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                    return [];
                    })
            );
    }

    public GetAllInactiveContestBasic(): Observable<any> {
        return this.httpClient.get<BasicContest[]>(`http://localhost:54768/api/contestBasic/inactive`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                    return [];
                    })
            );
    }

    public EndBasicContest(basicContestId: number): Observable<any> {
        return this.httpClient.post(`http://localhost:54768/api/contestBasic/close/${basicContestId}`, {});
    }

    public GetContestSubmissions(basicContestId: number, criteria: boolean): Observable<any> {
        return this.httpClient.get<PhotoBasicContest[]>(`http://localhost:54768/api/upload/submissions/${basicContestId}/${criteria}`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                    return [];
                    })
            );
    }

    public SubmitVote(idSubmission: number, voteScore: number): Observable<any> {
        return this.httpClient.put(`http://localhost:54768/api/upload/voteBasic/${idSubmission}/${voteScore}`, {});
    }
}
