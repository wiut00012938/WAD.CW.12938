import { Component, inject } from '@angular/core';
import {Router} from '@angular/router';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import {catchError} from 'rxjs/operators'
import { of } from 'rxjs';
import { Student, Teacher } from '../../GradeTrackerItems';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login-student',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatButtonModule, FormsModule],
  templateUrl: './login-student.component.html',
  styleUrl: './login-student.component.css'
})
export class LoginStudentComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router);

  LoginCredentials: any ={
    UserName: "",
    Password: ""
  }



  login() {
    this.GradeTrackerService.StudentLogin(this.LoginCredentials.userName, this.LoginCredentials.password)
      .pipe(
        catchError(error => {
          alert("Login failed. Please try again."); 
          return of(null); 
        })
      )
      .subscribe((student: Student | null) => {
        if (student != null) {
          alert("Successfully Logged in");
          this.router.navigateByUrl(`/student-home/${student.id}`); 
        } else {
          alert("Login failed. Please try again."); 
        }
      });
  }  
}
