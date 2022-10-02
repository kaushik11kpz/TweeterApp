export class User{
    constructor(public emailId: string, 
        public dateOfBirth: Date, 
        public gender: string, 
        public password: string, 
        public confirmPassword: string, 
        public firstName: string, 
        public lastName: string,
        public securityQuestion: number,
        public securityAnswer: string){
    }
}