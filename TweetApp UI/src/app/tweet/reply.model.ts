export class Reply{
    public replyText: string;
    public userId: string;
    public dateAndTimeOfReply: Date;
    public firstName: string;
    public lastName: string;

    constructor(replyText: string, userId: string = "", dateAndTimeOfReply: Date = new Date(), firstName: string = "", lastName: string=""){
        this.replyText=replyText;
        this.userId=userId;
        this.dateAndTimeOfReply = dateAndTimeOfReply;
        this.firstName = firstName;
        this.lastName = lastName;
    }
}