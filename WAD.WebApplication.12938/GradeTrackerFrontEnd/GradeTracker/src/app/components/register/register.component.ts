import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, of } from 'rxjs';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, MatInputModule, MatFormFieldModule, MatButtonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  createTeacher: any ={
    id: 0,
    teacherBackground: "",
    user: {
    id: 0,
    firstName: "",
    lastName: "",
    profileImage: "",
    emailAddress: "",
    password: "",
    confirmPassword:""
  }
  }
  activeRoute = inject(ActivatedRoute)
  create(){
    this.GradeTrackerService.TeacherRegister(this.createTeacher)
    .subscribe(() => {
      alert("Registration is sucessfully try to login to your account now");
      this.router.navigateByUrl("home")
    });
  }
}
