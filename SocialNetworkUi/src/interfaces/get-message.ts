export interface GetMessage{
    id: number,
    text: string,
    sendingTime: Date,
    senderId: number,
    chatId: number,
    status: boolean,
    originalSenderUserName: string
}