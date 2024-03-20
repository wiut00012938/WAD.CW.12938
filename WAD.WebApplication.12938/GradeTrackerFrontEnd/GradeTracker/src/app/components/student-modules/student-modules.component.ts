import { Component, Input, inject } from '@angular/core';
import {MatTableModule} from '@angular/material/table'
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import {Module, ModuleStudent} from '../../GradeTrackerItems'
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-student-modules',
  standalone: true,
  imports: [MatTableModule,MatButtonModule, MatDividerModule, MatIconModule],
  templateUrl: './student-modules.component.html',
  styleUrl: './student-modules.component.css'
})
export class StudentModulesComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  activeRoute = inject(ActivatedRoute)
  items:ModuleStudent[]=[]
  ngOnInit(){
    this.GradeTrackerService.GetAllModulesByStudent(this.activeRoute.snapshot.params["id"]).subscribe((result) => {this.items = result})
  }
  displayedColumns: string[] = ['moduleId','moduleName','moduleDescription']
}
