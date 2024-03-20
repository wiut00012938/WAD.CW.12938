import { Component, Input, inject } from '@angular/core';
import {MatTableModule} from '@angular/material/table'
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Assignment, Grade, GradeStudent } from '../../GradeTrackerItems';

@Component({
  selector: 'app-student-grades',
  standalone: true,
  imports: [MatTableModule,MatButtonModule, MatDividerModule, MatIconModule],
  templateUrl: './student-grades.component.html',
  styleUrl: './student-grades.component.css'
})
export class StudentGradesComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  activeRoute = inject(ActivatedRoute)
  items:GradeStudent[]=[]
  ngOnInit(){
    this.GradeTrackerService.GetAllGradesByStudent(this.activeRoute.snapshot.params["id"]).subscribe((result) => {this.items = result})
  }
  displayedColumns: string[] = ['gradeId','gradeScore','gradeFeedback','assignmentId','assignmentName','assignmentDescription','moduleId','moduleName']
}
