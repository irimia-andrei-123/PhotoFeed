import { CompanyContact } from './CompanyContactModule';

export class CompanyProfile {
    IdCompany: number;
    CompanyName: string;
    Email: string;
    Description: string;
    ProfilePicture: string;
    Contact: Array<CompanyContact>;
}
