import {Reply} from './reply.model';
export class Tweet{
    public id: string;
    public tweetText: string;
    public userId: string;
    public likes: number;
    public dateAndTimeOfTweet: Date;
    public firstName: string;
    public lastName: string;
    public replies: Reply[]
    public likedBy: string [];

    constructor(id: string = "", tweetText: string = "", userId: string = "", likes: number = 0, 
    dateAndTimeOfTweet: Date = new Date('0000/00/00'), replies: Reply[] = [], 
    firstName : string ="", lastName: string = "", likedBy: string [] = []){
        this.userId=userId;
        this.id=id;
        this.tweetText=tweetText;
        this.dateAndTimeOfTweet = dateAndTimeOfTweet;
        this.likes = likes;
        this.replies = replies;
        this.firstName = firstName;
        this.lastName = lastName;
        this.likedBy = likedBy;
    };
}