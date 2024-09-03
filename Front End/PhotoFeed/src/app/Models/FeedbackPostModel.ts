import { FeedbackComment } from './FeedbackCommentModel';

export class FeedbackPost {
    Photo: string;
    IdUser: number;
    UserName: string;
    Description: string;
    DatePosted: Date;
    Comments: Array<FeedbackComment>;
}
