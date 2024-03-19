import { Component, Input, inject } from '@angular/core';
import {MatTableModule} from '@angular/material/table'
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import {Module} from '../../GradeTrackerItems'
import { Router } from '@angular/router';
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatTableModule,MatButtonModule, MatDividerModule, MatIconModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  
  EditClicked(moduleId:number){
    console.log(moduleId, "From Edit");
    this.router.navigateByUrl("/edit/"+moduleId)
  }
  DetailsClicked(moduleId:number){
    console.log(moduleId, "From Edit");
    this.router.navigateByUrl("/details/"+moduleId)
  }
  DeleteClicked(moduleId:number){
    console.log(moduleId, "From Edit");
    this.router.navigateByUrl("/delete/"+moduleId)
  }
}
