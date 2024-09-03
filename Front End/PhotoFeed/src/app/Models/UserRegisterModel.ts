import { UserContact } from './UserContactModel';

export class UserRegisterModel { // used
    UserName: string;
    Email: string;
    Password: string;
    Description: string;
    ProfilePicture: string;
    Verified: number;
    Points: number;
    Moderator: number;
    ContactInfo: Array<UserContact>;
}
