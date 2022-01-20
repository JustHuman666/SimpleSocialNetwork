export interface GetUser {
    id: number;
    userName: string;
    email: string;
    phoneNumber: string;
    firstName: string;
    lastName: string;
    
    thisUserFriendIds : number[];
}