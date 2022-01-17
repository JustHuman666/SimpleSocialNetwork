import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

import { SOCIAL_NETWORK_API_URL } from 'src/injection/injection-token';
import { Token } from 'src/interfaces/token';
import { RegisterUser } from 'src/interfaces/register-user';

export const UNIQUE_USER_TOKEN_KEY = 'social_network_user_acces_token';
export const USER_ID = "active_user_id";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http: HttpClient,
    @Inject(SOCIAL_NETWORK_API_URL) private apiUrl: string,
    private jwtHelper: JwtHelperService
  ) { }

  logIn(email: string, password: string): Observable<Token> {
    return this.http.post<Token>(`${this.apiUrl}/api/Authentification/Login`, {
      email, password
    }).pipe(
      tap(token => {
        localStorage.setItem(UNIQUE_USER_TOKEN_KEY, token.token);
        localStorage.setItem(USER_ID, token.userId.toString());
      })
    )
  }

  register(registerData : RegisterUser){
    return this.http.post(`${this.apiUrl}/api/Authentification/Register`, registerData);
  }

  logOut(): void{
    localStorage.removeItem(UNIQUE_USER_TOKEN_KEY);
    localStorage.removeItem(USER_ID);
  }

  getUserId(): number {
    var id = localStorage.getItem(USER_ID);
    if(id){
      return parseInt(id);
    }
    return 0;
  }

  getUserToken(): string {
    var token = localStorage.getItem(UNIQUE_USER_TOKEN_KEY);
    if(token){
      return token;
    }
    return '';
  }

  isAuthenticated(): boolean {
    var token = localStorage.getItem(UNIQUE_USER_TOKEN_KEY);
    if(token){
      return !this.jwtHelper.isTokenExpired(token)
    }
    return false;
  }
  
}
