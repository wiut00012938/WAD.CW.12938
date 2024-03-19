import { Component, inject } from '@angular/core';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ModuleStudent, Student } from '../../GradeTrackerItems';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import {CommonModule} from '@angular/common';
@Component({
  selector: 'app-module-addstudent',
  standalone: true,
  imports: [CommonModule,FormsModule, MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule, MatChipsModule],
  templateUrl: './module-addstudent.component.html',
  styleUrl: './module-addstudent.component.css'
})
export class ModuleAddstudentComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  activeRoute = inject(ActivatedRoute)
  selectedStudentId: number = 0;
  existingStudents:ModuleStudent[]=[]
  allStudents:Student[] = []
  newStudents:Student[]= []

  ngOnInit(){
    this.GradeTrackerService.ModuleDetails(this.activeRoute.snapshot.params["id"]).subscribe((result) => {this.existingStudents = result; this.populateNewStudents();})
    this.GradeTrackerService.GetAllStudents().subscribe((result) => {this.allStudents = result; this.populateNewStudents();})

  }
  
  populateNewStudents(){
    if (this.allStudents.length > 0 && this.existingStudents.length > 0) {
      this.newStudents = this.allStudents.filter((student) => {
        return !this.existingStudents.some((existingStudent) => existingStudent.student.id === student.id);
      });
    }
    else{
      this.newStudents = this.allStudents
    }
  }
  submit() {
    if (this.selectedStudentId !== null) {
      this.GradeTrackerService.ModuleAddStudent(this.activeRoute.snapshot.params["id"], this.selectedStudentId)
    .subscribe(() => {
      alert("Student successfully added");
      this.router.navigateByUrl("/module/details/"+this.activeRoute.snapshot.params["id"])
    });
    } else {
      alert("Choose one of the avaible students")
    }
  }

}
