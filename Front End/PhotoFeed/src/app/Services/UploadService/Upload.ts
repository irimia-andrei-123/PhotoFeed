import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UploadImageModel } from '../../Models/UploadImageModel';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ImageInfoModel } from '../../Models/ImageInfoModel';
import { catchError } from 'rxjs/operators';
import { ContestSubmission } from 'src/app/Models/ContestSubmissionModel';

@Injectable({
    providedIn: 'root'
})

export class UploadService {

    constructor(private httpClient: HttpClient) { }

    public UploadImage(image: UploadImageModel): Observable<Object> {
        return this.httpClient.post(`http://localhost:54768/api/upload/newPicture`, image);
    }

    public GetPost(postId: number): Observable<ImageInfoModel> {
        return this.httpClient.get<ImageInfoModel>(`http://localhost:54768/api/upload/post/${postId}`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                    return [];
                    })
            );
    }

    public SubmitBasicContest(images: ContestSubmission): Observable<any> {
        return this.httpClient.post(`http://localhost:54768/api/upload/submitBasicContest`, images);
    }

    public SubmitProContest(images: ContestSubmission): Observable<any> {
        return this.httpClient.post(`http://localhost:54768/api/upload/submitProContest`, images);
    }
}
