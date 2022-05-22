import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../Model/interfaces/usuario';
import { appsetting } from './appSettings';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private controllerUrl = `${appsetting.API_URL}/api/User`;
  constructor(private http:HttpClient) { }

  getUserInfo():Observable<Usuario>{
    return this.http.get<Usuario>(`${this.controllerUrl}/GetUserInfo`);
    
  }
}
