import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Module, Teacher} from './GradeTrackerItems';

@Injectable({
  providedIn: 'root'
})
export class ServiceGradetrackerService {
  httpClient = inject(HttpClient);
  constructor() { }
  getAllModulesByTeacher(id:number){
    return this.httpClient.get<Module[]>("http://localhost:5057/api/Teacher/" + id + "/modules")
  };
  TeacherLogin(username:string, password:string){
    const encodedUsername = encodeURIComponent(username);
    const encodedPassword = encodeURIComponent(password);
    return this.httpClient.get<Teacher[]>(`http://localhost:5057/api/Teacher?Email=${encodedUsername}&Password=${encodedPassword}`)
  }
  public isLoggedIn = false;
}