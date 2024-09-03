import { UserContact } from './UserContactModel';

export class User {
    IdUser: number;
    UserName: string;
    Email: string;
    Description: string;
    ProfilePicture: string;
    Verified: number;
    Points: number;
    Moderator: number;
    Blocked: number;
    Contact: Array<UserContact>;
}
