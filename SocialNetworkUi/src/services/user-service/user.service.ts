import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { SOCIAL_NETWORK_API_URL } from 'src/injection/injection-token';

import { GetUser } from 'src/interfaces/get-user';
import { UpdateUser } from 'src/interfaces/update-user';
import { ChangePassword } from 'src/interfaces/change-password';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, 
    @Inject(SOCIAL_NETWORK_API_URL) private apiUrl: string) { }

  getAllUsers():Observable<GetUser[]>{
      return this.http.get<GetUser[]>(`${this.apiUrl}/api/User`)
  }  

  getUserById(id : number):Observable<GetUser>{
    return this.http.get<GetUser>(`${this.apiUrl}/api/User/${id}`);
  }

  getUserRoles():Observable<string[]>{
    return this.http.get<string[]>(`${this.apiUrl}/api/User/Roles`);
  }

  getThisUserProfile():Observable<GetUser>{
    return this.http.get<GetUser>(`${this.apiUrl}/api/User/MyProfile`);
  }

  changeUserPassword(changePassword: ChangePassword):Observable<any>{
    return this.http.put(`${this.apiUrl}/api/User/ChangePassword`, changePassword);
  }

  getUserProfileByEmail(email: string):Observable<GetUser>{
    return this.http.post<GetUser>(`${this.apiUrl}/api/User/GetByEmail`, email);
  }

  getUserProfileByUserName(userName: string):Observable<GetUser>{
    return this.http.get<GetUser>(`${this.apiUrl}/api/User/GetByUserName/${userName}`);
  }

  getUserProfilesByFullName(firstName: string, lastName: string):Observable<GetUser[]>{
    return this.http.get<GetUser[]>(`${this.apiUrl}/api/User/GetByFullName/${firstName}/${lastName}`);
  }

  getUserProfileByPhone(phone: string):Observable<GetUser>{
    return this.http.post<GetUser>(`${this.apiUrl}/api/User/GetByPhone`, phone);
  }

  addUserToRole(id: number, role: string):Observable<any>{
    return this.http.post(`${this.apiUrl}/api/User/AddRole/${id}/${role}`, null);
  }

  updateThisUserInfo(newInfo: UpdateUser):Observable<GetUser>{
    return this.http.put<GetUser>(`${this.apiUrl}/api/User/UpdateMyInfo`, newInfo);
  }

  updateUserInfoById(id: number, newInfo: UpdateUser):Observable<GetUser>{
    return this.http.put<GetUser>(`${this.apiUrl}/api/User/UpdateUserInfo/${id}`, newInfo);
  }

  deleteThisUser():Observable<any>{
    return this.http.delete(`${this.apiUrl}/api/User/DeleteOwnAccount`);
  }

  deleteUserById(id: number):Observable<any>{
    return this.http.delete(`${this.apiUrl}/api/User/DeleteUserByAdmin/${id}`);
  }

}
