import { Component, inject } from '@angular/core';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Grade, ModuleStudent, Student } from '../../GradeTrackerItems';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import {CommonModule} from '@angular/common';
import Module from 'module';

@Component({
  selector: 'app-grade-create',
  standalone: true,
  imports: [CommonModule,FormsModule, MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule, MatChipsModule],
  templateUrl: './grade-create.component.html',
  styleUrl: './grade-create.component.css'
})
export class GradeCreateComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  createGrade: any = {
    gradeId:0,
    score: 0,
    feedback: ""
  }
  activeRoute = inject(ActivatedRoute)

  selectedStudentId: number = 0;
  existingStudents:Grade[]=[]
  allModuleStudents:ModuleStudent[] = []
  newStudents:ModuleStudent[]= []

  ngOnInit(){
    this.GradeTrackerService.ModuleDetails(this.activeRoute.snapshot.params["moduleid"]).subscribe((result) => {this.allModuleStudents = result; this.populateNewStudents();})
    this.GradeTrackerService.GetGradesByAssignments(this.activeRoute.snapshot.params["assignmentid"]).subscribe((result) => {this.existingStudents = result; this.populateNewStudents();})
  }
  
  populateNewStudents(){
    if (this.allModuleStudents.length > 0 && this.existingStudents.length > 0) {
      this.newStudents = this.allModuleStudents.filter((student) => {
        return !this.existingStudents.some((existingStudent) => existingStudent.student.id === student.student.id);
      });
    }
    else{
      this.newStudents = this.allModuleStudents
    }
  }



  create(){
    this.GradeTrackerService.GradeCreate(this.createGrade, this.activeRoute.snapshot.params["assignmentid"], this.selectedStudentId)
    .subscribe(() => {
      alert("Module created successfully");
      this.router.navigateByUrl(`/module/${this.activeRoute.snapshot.params["moduleid"]}/assignment/${this.activeRoute.snapshot.params["assignmentid"]}/grades`)
    });
  }
}
