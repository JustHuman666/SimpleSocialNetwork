import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

import { SOCIAL_NETWORK_API_URL } from 'src/injection/injection-token';
import { Token } from 'src/interfaces/token';
import { RegisterUser } from 'src/interfaces/register-user';

export const UNIQUE_USER_TOKEN_KEY = "";
export const USER_ID = "";

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
    return this.http.post<Token>(`${this.apiUrl}api/Authentification/Login`, {
      email, password
    }).pipe(
      tap(token => {
        localStorage.setItem(UNIQUE_USER_TOKEN_KEY, token.token);
        localStorage.setItem(USER_ID, token.userId);
      })
    )
  }

  register(registerData : RegisterUser){
    return this.http.post(`${this.apiUrl}api/Authentification/Registerr`, registerData);
  }

  logOut(): void{
    localStorage.removeItem(UNIQUE_USER_TOKEN_KEY);
    localStorage.removeItem(USER_ID);
  }

  getUserId(): string {
    var id = localStorage.getItem(USER_ID);
    if(id){
      return id;
    }
    return '';
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
