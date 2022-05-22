import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TaskModel } from '../Model/interfaces/TaskModel';
import { appsetting } from './appSettings';
import { Base64UrlService } from './base64url.service';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private controllerUrl = `${appsetting.API_URL}/api/Task`;
  

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };
  constructor(
    private http: HttpClient,
    private base64url: Base64UrlService,
  ) {}

  add(datos:TaskModel){
    let params = JSON.stringify(datos);
   return this.http.post(`${this.controllerUrl}/AddTask`,params,this.httpOptions);
  }

  update(id:number,msn:string){
    let data ={id:id,message:msn};
    let params = JSON.stringify(data);
   return this.http.put(`${this.controllerUrl}/UpdateTask`,params,this.httpOptions);
  }

  getAll(id:number):Observable<TaskModel[]>{
   return this.http.get<TaskModel[]>(`${this.controllerUrl}/GetTasks/${id}`);
  }

  getTaskById(id:number):Observable<TaskModel>{
    return this.http.get<TaskModel>(`${this.controllerUrl}/GetTaskById/${id}`);
   }

}
