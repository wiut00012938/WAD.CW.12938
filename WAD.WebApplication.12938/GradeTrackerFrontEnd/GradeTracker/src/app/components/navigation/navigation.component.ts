import { Component , OnInit, inject} from '@angular/core';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIcon, MatIconModule} from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import {Router} from '@angular/router';
import { CommonModule } from '@angular/common';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';

@Component({
  selector: 'app-navigation',
  standalone: true,
  imports: [MatToolbarModule, MatIconModule, MatButtonModule, CommonModule],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.css'
})
export class NavigationComponent implements OnInit{
  GradeTrackerService = inject(ServiceGradetrackerService)
  isLoggedIn: boolean = false;
  isStudent: boolean = false;
  teacherId: number = 0;
  studentId: number = 0;
  constructor(){}
  ngOnInit(): void{
    this.isLoggedIn = this.GradeTrackerService.isLoggedIn;
  }
  router = inject(Router)

  onHomeIconClicked(){
    this.router.navigateByUrl("home")
  }
  onEnrolledModulesClicked(studentId:number) {
    this.router.navigateByUrl("/enrolledmodules/"+studentId)
  }

  onMyGradesClicked(studentId:number) {
    this.router.navigateByUrl("/mygrades/"+studentId)
  }

  onLeadingModulesClicked(teacherId:number) {
    this.router.navigateByUrl("/leadingmodules/"+teacherId)
  }

  onAssignmentsClicked(teacherId:number) {
    this.router.navigateByUrl("/createdassignments/"+teacherId)
  }

  onLogoutClicked() {
    this.isLoggedIn = false;
  }

  onLoginClicked() {
    this.router.navigateByUrl("/login")
  }

  onRegisterClicked() {
    this.router.navigateByUrl("/register")
  }
}
