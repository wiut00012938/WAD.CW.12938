import { Component, OnInit, inject } from '@angular/core';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import { ActivatedRoute, Router} from '@angular/router';
import { Student, Teacher } from '../../GradeTrackerItems';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-student-home',
  standalone: true,
  imports: [MatIconModule],
  templateUrl: './student-home.component.html',
  styleUrl: './student-home.component.css'
})
export class StudentHomeComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  
  student: Student = {
    id: 0,
    enrolledModulesNum: 0,
    user: {
        id: 0,
        firstName: "",
        lastName: "",
        profileImage: ""
      }
  };

  activeRoute = inject(ActivatedRoute)
  ngOnInit(){
    this.GradeTrackerService.GetStudentById(this.activeRoute.snapshot.params["id"]).subscribe((resultedItem)=>{
      this.student = resultedItem
    });
  }
  
  router = inject(Router)

  onModulesClicked(){
    this.router.navigateByUrl("/student/"+this.student.id + "/modules")
  }
  onGradesClicked(){
    this.router.navigateByUrl("/student/"+this.student.id + "/grades")
  }
}
