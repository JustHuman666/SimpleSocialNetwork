export interface LoggedUserProfile {
    id: number;
    userName: string;
    email: string;
    phoneNumber: string;
    firstName: string;
    lastName: string;

    thisUserFriendIds: number[];
    userIsFriendIds: number[];
    chatIds: number[];
    messageIds: number[];
}