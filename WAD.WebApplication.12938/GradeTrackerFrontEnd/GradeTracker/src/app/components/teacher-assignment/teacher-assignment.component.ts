import { Component, Input, inject } from '@angular/core';
import {MatTableModule} from '@angular/material/table'
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Assignment } from '../../GradeTrackerItems';

@Component({
  selector: 'app-teacher-assignment',
  standalone: true,
  imports: [MatTableModule,MatButtonModule, MatDividerModule, MatIconModule],
  templateUrl: './teacher-assignment.component.html',
  styleUrl: './teacher-assignment.component.css'
})
export class TeacherAssignmentComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  activeRoute = inject(ActivatedRoute)
  items:Assignment[]=[]
  ngOnInit(){
    this.GradeTrackerService.GetAssignmentsByModule(this.activeRoute.snapshot.params["id"]).subscribe((result) => {this.items = result})
  }
  displayedColumns: string[] = ['assignmentId','assignmentName','assignmentDescription','Actions']
  EditClicked(assignmentId:number){
    this.router.navigateByUrl("/module/" + this.activeRoute.snapshot.params["id"]+"/assignments/edit/"+ assignmentId)
  }
  DetailsClicked(assignmentId:number){
    this.router.navigateByUrl("/module/assignments/details/"+ assignmentId)
  }
  DeleteClicked(assignmentId:number){
    this.router.navigateByUrl("/module/"+ this.activeRoute.snapshot.params["id"]+"/assignments/delete/"+ assignmentId)
  }
  CreateAssignment(){
    this.router.navigateByUrl(`/module/${this.activeRoute.snapshot.params["id"]}/assignments/create`)
  }
}
