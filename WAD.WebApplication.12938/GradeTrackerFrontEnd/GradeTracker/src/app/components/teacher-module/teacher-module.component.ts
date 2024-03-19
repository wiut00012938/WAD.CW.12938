import { Component, Input, inject } from '@angular/core';
import {MatTableModule} from '@angular/material/table'
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import {Module} from '../../GradeTrackerItems'
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-teacher-module',
  standalone: true,
  imports: [MatTableModule,MatButtonModule, MatDividerModule, MatIconModule],
  templateUrl: './teacher-module.component.html',
  styleUrl: './teacher-module.component.css'
})
export class TeacherModuleComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  activeRoute = inject(ActivatedRoute)
  items:Module[]=[]
  ngOnInit(){
    this.GradeTrackerService.getAllModulesByTeacher(this.activeRoute.snapshot.params["id"]).subscribe((result) => {this.items = result})
  }
  displayedColumns: string[] = ['moduleId','moduleName','moduleDescription','Actions']
  EditClicked(moduleId:number){
    this.router.navigateByUrl("/module/" + this.activeRoute.snapshot.params["id"]+"/edit/"+ moduleId)
  }
  DetailsClicked(moduleId:number){
    this.router.navigateByUrl("/module/details/"+ moduleId)
  }
  DeleteClicked(moduleId:number){
    this.router.navigateByUrl("/module/"+ this.activeRoute.snapshot.params["id"]+"/delete/"+ moduleId)
  }
  CreateModule(){
    this.router.navigateByUrl("/module/create/"+ this.activeRoute.snapshot.params["id"])
  }
}
