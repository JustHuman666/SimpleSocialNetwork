import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { SOCIAL_NETWORK_API_URL } from 'src/injection/injection-token';

import { GetMessage } from 'src/interfaces/get-message';
import { SendMessage } from 'src/interfaces/send-message';

@Injectable({
  providedIn: 'root'
})

export class MessageService{

  constructor(private http: HttpClient, 
    @Inject(SOCIAL_NETWORK_API_URL) private apiUrl: string) { }

    sendNewMessageInChat(messageModel: SendMessage):Observable<any>{
        return this.http.post(`${this.apiUrl}/api/Message`, messageModel);
    }

    resendMessageInChosenChat(messageId: number, chatId: number):Observable<any>{
        return this.http.post(`${this.apiUrl}/api/Message/Resend/${messageId}/${chatId}`, null);
    }

    editMessageText(messageId: number, messageModel: SendMessage):Observable<any>{
        return this.http.put(`${this.apiUrl}/api/Message/${messageId}`, messageModel);
    }

    updateMessageStatus(messageId: number):Observable<any>{
        return this.http.put(`${this.apiUrl}/api/Message/UpdateStatus/${messageId}`, null);
    }

    deleteMessage(messageId: number):Observable<any>{
        return this.http.delete(`${this.apiUrl}/api/Message/${messageId}`);
    }

    getMessageById(id: number):Observable<GetMessage>{
        return this.http.get<GetMessage>(`${this.apiUrl}/api/Message/${id}`)
    } 

    getAllMessages():Observable<GetMessage[]>{
        return this.http.get<GetMessage[]>(`${this.apiUrl}/api/Message/GetAll`)
    } 
    getChatMessages(id: number):Observable<GetMessage[]>{
        return this.http.get<GetMessage[]>(`${this.apiUrl}/api/Message/GetMessagesOfChat/${id}`)
    } 

   
}
