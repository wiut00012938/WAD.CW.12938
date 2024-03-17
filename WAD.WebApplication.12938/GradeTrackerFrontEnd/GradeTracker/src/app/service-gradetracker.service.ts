import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Module} from './GradeTrackerItems';

@Injectable({
  providedIn: 'root'
})
export class ServiceGradetrackerService {
  httpClient = inject(HttpClient);
  constructor() { }
  getAllModulesByTeacher(id:number){
    return this.httpClient.get<Module[]>("http://localhost:5057/api/Teacher/" + id + "/modules")
  };
}
