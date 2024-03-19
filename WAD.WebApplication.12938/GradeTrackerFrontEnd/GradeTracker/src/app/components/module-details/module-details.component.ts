import { Component, inject} from '@angular/core';
import {MatTableModule} from '@angular/material/table'
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import {ModuleStudent} from '../../GradeTrackerItems'
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-module-details',
  standalone: true,
  imports: [MatTableModule,MatButtonModule, MatDividerModule, MatIconModule],
  templateUrl: './module-details.component.html',
  styleUrl: './module-details.component.css'
})
export class ModuleDetailsComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  activeRoute = inject(ActivatedRoute)
  items:ModuleStudent[]=[]
  createModule: any = {
    moduleId: 0,
    moduleName: "",
    moduleDescription: ""
  }

  ngOnInit(){
    this.GradeTrackerService.ModuleDetails(this.activeRoute.snapshot.params["id"]).subscribe((result) => {this.items = result})
    this.createModule = this.items[0]['module']
  }
  displayedColumns: string[] = ['id','firstName','lastName','email','Actions']

  AddStudent(){
    this.router.navigateByUrl(`/module/${this.activeRoute.snapshot.params["id"]}/student/add`)
  }
  ViewAssignments(){
    this.router.navigateByUrl(`/module/${this.activeRoute.snapshot.params["id"]}/assignments`)
  }
  Delete(studentId:number){
    this.router.navigateByUrl(`/module/${this.activeRoute.snapshot.params["id"]}/student/delete/${studentId}`)
  }
}
