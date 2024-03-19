import { Component, inject } from '@angular/core';
import {Router} from '@angular/router';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import {catchError} from 'rxjs/operators'
import { of } from 'rxjs';
import { Teacher } from '../../GradeTrackerItems';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatButtonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router);

  LoginCredentials: any ={
    UserName: "",
    Password: ""
  }



  login() {
    this.GradeTrackerService.TeacherLogin(this.LoginCredentials.userName, this.LoginCredentials.password)
      .pipe(
        catchError(error => {
          alert("Login failed. Please try again."); 
          return of(null); 
        })
      )
      .subscribe((teacher: Teacher | null) => {
        if (teacher != null) {
          console.log(teacher)
          alert("Successfully Logged in");
          this.router.navigateByUrl(`/teacher-home/${teacher.id}`); 
        } else {
          alert("Login failed. Please try again."); 
        }
      });
  }  
}
