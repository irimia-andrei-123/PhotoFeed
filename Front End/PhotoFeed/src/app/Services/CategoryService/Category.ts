import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CategoryModel } from '../../Models/CategoryModel';
import { CategoryImageModel } from '../../Models/CategoryImageModel';
import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class CategoryService {

    constructor(private httpClient: HttpClient) { }

    public GetCategoriesInfo(): Observable<CategoryModel[]> {
        return this.httpClient.get<CategoryModel[]>('http://localhost:54768/api/categories/getAll')
            .pipe(
                catchError((err: HttpErrorResponse) => {
                  return [];
                  })
            );
    }

    public GetCategoriesImages(categoryId: number): Observable<CategoryImageModel[]> {
        return this.httpClient.get<CategoryImageModel[]>(`http://localhost:54768/api/categories/GetCategory/${categoryId}`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                  return [];
                  })
            );
    }
}
