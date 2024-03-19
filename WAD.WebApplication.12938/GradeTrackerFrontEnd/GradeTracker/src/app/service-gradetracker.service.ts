import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Module, ModuleStudent, Teacher, Student, Assignment, Grade, GradeDto} from './GradeTrackerItems';
import { BehaviorSubject, Observable, map } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ServiceGradetrackerService {
  httpClient = inject(HttpClient);
  constructor() { }

  getAllModulesByTeacher(id:number){
    return this.httpClient.get<Module[]>("http://localhost:5057/api/Teacher/" + id + "/modules")
  };

  private authenticated$ = new BehaviorSubject<boolean>(false);

  get authenticated(): boolean {
    return this.authenticated$.getValue();
  }

  get authenticatedObservable(): Observable<boolean> {
    return this.authenticated$.asObservable();
  }
  
  TeacherLogin(username:string, password:string){
    const encodedUsername = encodeURIComponent(username);
    const encodedPassword = encodeURIComponent(password);
    return this.httpClient.get<Teacher>(`http://localhost:5057/api/Teacher?Email=${encodedUsername}&Password=${encodedPassword}`)
  }

  getTeacherById(id:number){
    return this.httpClient.get<Teacher>("http://localhost:5057/api/Teacher/"+id);
  }

  ModuleCreate(item: Module, id:number){
    return this.httpClient.post<Module>("http://localhost:5057/api/Module?TeacherId="+id, item);
  }

  ModuleEdit(item: Module, id:number){
    return this.httpClient.put("http://localhost:5057/api/Module/"+id, item);  
  }

  ModuleDelete(id:number){
    return this.httpClient.delete("http://localhost:5057/api/Module/"+id);
  }

  ModuleDetails(id:number){
    return this.httpClient.get<ModuleStudent[]>(`http://localhost:5057/api/Module/${id}/students`);
  }
  ModuleAddStudent(moduleId:number,studentId:number){
    return this.httpClient.post<''>(`http://localhost:5057/api/ModuleStudent?ModuleId=${moduleId}&StudentId=${studentId}`,'');
  }

  GetAllStudents(){
    return this.httpClient.get<Student[]>('http://localhost:5057/api/Student/students/allstudents')
  }

  GetStudentById(id:number){
    return this.httpClient.get<Student>(`http://localhost:5057/api/Student/${id}`);
  }

  RemoveStudentFromModule(moduleId:number,studentId:number){
    return this.httpClient.delete(`http://localhost:5057/api/ModuleStudent?ModuleId=${moduleId}&StudentId=${studentId}`)
  }

  GetAssignmentsByModule(moduleId:number){
    return this.httpClient.get<Assignment[]>(`http://localhost:5057/api/Module/${moduleId}/assignments`)
  }

  GetAssignmentById(assignmentId:number){
    return this.httpClient.get<Assignment>(`http://localhost:5057/api/Assignment/${assignmentId}`)
  }
  AssignmentEdit(item:Assignment, assignmentId:number){
    return this.httpClient.put("http://localhost:5057/api/Assignment/"+assignmentId, item);  
  }
  AssignmentDelete(assignmentId:number){
    return this.httpClient.delete("http://localhost:5057/api/Assignment/"+assignmentId);
  }
  AssignmentCreate(item:Assignment, moduleId:number){
    return this.httpClient.post<Assignment>("http://localhost:5057/api/Assignment?ModuleId="+moduleId, item);
  }
  GetGradesByAssignments(assignmentId:number){
    return this.httpClient.get<Grade[]>(`http://localhost:5057/api/Assignment/${assignmentId}/grades`)
  }
  GetGradeById(gradeId:number){
    return this.httpClient.get<Grade>(`http://localhost:5057/api/Grade/${gradeId}`)
  }
  GradeEdit(item:GradeDto, gradeId:number){
    return this.httpClient.put("http://localhost:5057/api/Grade/"+gradeId, item);  
  }
  GradeDelete(gradeId:number){
    return this.httpClient.delete("http://localhost:5057/api/Grade/"+gradeId);
  }
  GradeCreate(item:GradeDto, assignmentId:number, studentId:number){
    return this.httpClient.post<GradeDto>(`http://localhost:5057/api/Grade?AssignmentId=${assignmentId}&StudentId=${studentId}`, item);
  }

}