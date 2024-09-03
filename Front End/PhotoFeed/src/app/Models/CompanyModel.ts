import { CompanyContact } from './CompanyContactModule';

export class Company {
    IdCompany: number;
    CompanyName: string;
    Email: string;
    Password: string;
    Description: string;
    ProfilePicture: string;
    Members: number[];
    Allowed: number;
    ContactInfo: Array<CompanyContact>;
}
