import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { SOCIAL_NETWORK_API_URL } from 'src/injection/injection-token';

import { GetUser } from 'src/interfaces/get-user';

@Injectable({
  providedIn: 'root'
})

export class FriendsService{

  constructor(private http: HttpClient, 
    @Inject(SOCIAL_NETWORK_API_URL) private apiUrl: string) { }

    getUserFriendsById(id: number):Observable<GetUser[]>{
        return this.http.get<GetUser[]>(`${this.apiUrl}/api/Friend/UserFriends/${id}`)
    } 

    getOwnFriends():Observable<GetUser[]>{
        return this.http.get<GetUser[]>(`${this.apiUrl}/api/Friend/OwnFriends`)
    } 

    getReceivedInnvitations():Observable<GetUser[]>{
        return this.http.get<GetUser[]>(`${this.apiUrl}/api/Friend/GetOwnInvitations`)
    } 

    getSentInvitations():Observable<GetUser[]>{
        return this.http.get<GetUser[]>(`${this.apiUrl}/api/Friend/GetSentInvitations`)
    } 

    confirmFriendship(friendId: number):Observable<any>{
        return this.http.put(`${this.apiUrl}/api/Friend/Confirm/${friendId}`, null);
    }

    deleteFriendById(friendId: number):Observable<any>{
        return this.http.delete(`${this.apiUrl}/api/Friend/${friendId}`);
    }

    sendInvitationForFriendship(friendId: number):Observable<any>{
        return this.http.post(`${this.apiUrl}/api/Friend/Invite/${friendId}`, null);
    }
}
