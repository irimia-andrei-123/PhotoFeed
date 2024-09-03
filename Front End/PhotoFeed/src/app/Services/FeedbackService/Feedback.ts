import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FeedbackModel } from '../../Models/FeedbackModel';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { FeedbackImageModel } from '../../Models/FeedbackImageModel';
import { UserFeedbackSubmissionModel } from '../../Models/UserFeedbackSubmissionModel';
import { FeedbackPost } from 'src/app/Models/FeedbackPostModel';
import { FeedbackComment } from 'src/app/Models/FeedbackCommentModel';

@Injectable({
    providedIn: 'root'
})

export class FeedbackService {

    constructor(private httpClient: HttpClient) { }

    public UploadFeedbackImage(image: FeedbackImageModel): Observable<Object> {
        return this.httpClient.post(`http://localhost:54768/api/feedback/add`, image);
    }

    public GetUserPosts(userId: number): Observable<UserFeedbackSubmissionModel[]> {
        return this.httpClient.get<UserFeedbackSubmissionModel[]>(`http://localhost:54768/api/feedback/posts/user/${userId}`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                    return [];
                    })
            );
    }

    public GetCategoryPosts(categoryId: number): Observable<UserFeedbackSubmissionModel[]> {
        return this.httpClient.get<UserFeedbackSubmissionModel[]>(`http://localhost:54768/api/feedback/posts/category/${categoryId}`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                    return [];
                    })
            );
    }

    public GetFeedbackPost(feedbackPostId: number): Observable<FeedbackPost> {
        return this.httpClient.get<FeedbackPost>(`http://localhost:54768/api/feedback/posts/${feedbackPostId}`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                    return [];
                    })
            );
    }

    public AddComment(comment: FeedbackComment): Observable<Object> {
        return this.httpClient.post(`http://localhost:54768/api/feedback/comment`, comment);
    }
}
