import { Injectable } from '@angular/core';
import { SearchImageModel } from '../../Models/SearchImageModel';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpErrorResponse, HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})

export class SearchService {

    constructor(private httpClient: HttpClient) { }

    public GetSearchResult(tags: string[]): Observable<SearchImageModel[]> {
        let url = 'http://localhost:54768/api/searchpage/search?';
        tags.forEach(x => {
            url = url + 'tags=' + x + '&';
        });
        url = url.substring(0, url.length - 1);
        return this.httpClient.get<SearchImageModel[]>(url)
        .pipe(
            catchError((err: HttpErrorResponse) => {
              return [];
              })
        );
    }
}
