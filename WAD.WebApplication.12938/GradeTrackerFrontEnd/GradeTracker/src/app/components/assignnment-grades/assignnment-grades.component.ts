import { Component, Input, inject } from '@angular/core';
import {MatTableModule} from '@angular/material/table'
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Assignment, Grade } from '../../GradeTrackerItems';

@Component({
  selector: 'app-assignnment-grades',
  standalone: true,
  imports: [MatTableModule,MatButtonModule, MatDividerModule, MatIconModule],
  templateUrl: './assignnment-grades.component.html',
  styleUrl: './assignnment-grades.component.css'
})
export class AssignnmentGradesComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  activeRoute = inject(ActivatedRoute)
  items:Grade[]=[]
  ngOnInit(){
    this.GradeTrackerService.GetGradesByAssignments(this.activeRoute.snapshot.params["id"]).subscribe((result) => {this.items = result})
  }
  displayedColumns: string[] = ['gradeId','gradeScore','gradeFeedback','gradeStudentId','gradeStudentFirstName','gradeStudentLastName','gradeStudentEmail','Actions']
  EditClicked(gradeId:number){
    this.router.navigateByUrl(`/module/${this.activeRoute.snapshot.params["moduleid"]}/assignment/${this.activeRoute.snapshot.params["id"]}/grade/edit/${gradeId}`)
  }
  DeleteClicked(gradeId:number){
    this.router.navigateByUrl(`/module/${this.activeRoute.snapshot.params["moduleid"]}/assignment/${this.activeRoute.snapshot.params["id"]}/grade/delete/${gradeId}`)
  }
  CreateGrade(){
    this.router.navigateByUrl(`/module/${this.activeRoute.snapshot.params["moduleid"]}/assignment/${this.activeRoute.snapshot.params["id"]}/grade/create`)
  }
}
