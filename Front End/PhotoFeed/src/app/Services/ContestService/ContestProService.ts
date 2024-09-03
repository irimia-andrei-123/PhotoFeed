import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { BasicContest } from 'src/app/Models/CreateBasicContestModel';
import { PhotoBasicContest } from 'src/app/Models/PhotoBasicContestModel';
import { ProContest } from 'src/app/Models/CreateProContestModel';

@Injectable({
    providedIn: 'root'
})

export class ContestProService {

    constructor(private httpClient: HttpClient) { }

    public AddProContest(proContest: ProContest): Observable<any> {
        return this.httpClient.post(`http://localhost:54768/api/contestPro/newContestPro`, proContest);
    }

    public GetProContest(proContestId: number): Observable<ProContest> {
        return this.httpClient.get<ProContest>(`http://localhost:54768/api/contestPro/${proContestId}`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                    return [];
                    })
            );
    }

    public GetAllActiveContestPro(): Observable<any> {
        return this.httpClient.get<ProContest[]>(`http://localhost:54768/api/contestPro/active`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                    return [];
                    })
            );
    }

    public GetAllInactiveContestPro(): Observable<any> {
        return this.httpClient.get<ProContest[]>(`http://localhost:54768/api/contestPro/inactive`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                    return [];
                    })
            );
    }

    public EndProContest(proContestId: number): Observable<any> {
        return this.httpClient.post(`http://localhost:54768/api/contestPro/close/${proContestId}`, {});
    }

    public GetContestSubmissions(proContestId: number, criteria: boolean): Observable<any> {
        return this.httpClient.get<PhotoBasicContest[]>(`http://localhost:54768/api/upload/submissionsPro/${proContestId}/${criteria}`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                    return [];
                    })
            );
    }

    public SubmitVote(idSubmission: number, voteScore: number): Observable<any> {
        return this.httpClient.put(`http://localhost:54768/api/upload/votePro/${idSubmission}/${voteScore}`, {});
    }
}
