import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { Company } from 'src/app/Models/CompanyModel';
import { CompanyProfile } from 'src/app/Models/CompanyProfileModel';
import { User } from 'src/app/Models/UserModel';

@Injectable({
    providedIn: 'root'
})

export class CompanyService {

    constructor(private httpClient: HttpClient) { }

    public GetPendingCompanies(): Observable<any> {
        return this.httpClient.get<Company>('http://localhost:54768/api/company/getPendingCompanies')
            .pipe(
                catchError((err: HttpErrorResponse) => {
                  return [];
                  })
            );
    }

    public DenyComapny(companyId: number): Observable<any> {
        return this.httpClient.put(`http://localhost:54768/api/company/denyComapny/${companyId}`, {});
    }

    public AllowComapny(companyId: number): Observable<any> {
        return this.httpClient.put(`http://localhost:54768/api/company/allowComapny/${companyId}`, {});
    }

    public GetCompany(companyId: number): Observable<CompanyProfile> {
        return this.httpClient.get<CompanyProfile>(`http://localhost:54768/api/company/get/${companyId}`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                  return [];
                  })
            );
    }

    public GetCompanyMembers(companyId: number): Observable<Array<User>> {
        return this.httpClient.get<Array<User>>(`http://localhost:54768/api/company/get/members/${companyId}`)
            .pipe(
                catchError((err: HttpErrorResponse) => {
                  return [];
                  })
            );
    }
}
