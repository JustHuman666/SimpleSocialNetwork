import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { SOCIAL_NETWORK_API_URL } from 'src/injection/injection-token';

import { GetUser } from 'src/interfaces/get-user';
import { CreateChat } from 'src/interfaces/create-chat';
import { GetChat } from 'src/interfaces/get-chat';

@Injectable({
  providedIn: 'root'
})

export class ChatService{

  constructor(private http: HttpClient, 
    @Inject(SOCIAL_NETWORK_API_URL) private apiUrl: string) { }

    createChat(chatModel: CreateChat):Observable<any>{
        return this.http.post(`${this.apiUrl}/api/Chat/CreateChat`, chatModel);
    }

    getOwnChats():Observable<GetChat[]>{
        return this.http.get<GetChat[]>(`${this.apiUrl}/api/Chat/AllUserChats`)
    } 
    
    getUsersOfChatById(id: number):Observable<GetUser[]>{
        return this.http.get<GetUser[]>(`${this.apiUrl}/api/Chat/AllChatUsers/${id}`)
    } 

    renameChat(id: number, name: string):Observable<any>{
        return this.http.put(`${this.apiUrl}/api/Chat/Rename/${id}/${name}`, null);
    }

    addUserInChat(chatId: number, userId: number):Observable<any>{
        return this.http.post(`${this.apiUrl}/api/Chat/AddUser/${chatId}/${userId}`, null);
    }

    deleteUserFromChat(chatId: number, userId: number):Observable<any>{
        return this.http.delete(`${this.apiUrl}/api/Chat/DeleteUser/${chatId}/${userId}`);
    }

    clearChatHistory(id: number):Observable<any>{
        return this.http.put(`${this.apiUrl}/api/Chat/ClearHistory/${id}`, null);
    }

    deleteChat(id: number):Observable<any>{
        return this.http.delete(`${this.apiUrl}/api/Chat/${id}`);
    }

    getChatById(id: number):Observable<GetChat>{
        return this.http.get<GetChat>(`${this.apiUrl}/api/Chat/${id}`)
    } 
}
