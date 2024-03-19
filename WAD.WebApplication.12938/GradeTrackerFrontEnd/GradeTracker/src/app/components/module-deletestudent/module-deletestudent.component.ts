import { Component, inject } from '@angular/core';
import { MatChipsModule } from '@angular/material/chips';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import { Student } from '../../GradeTrackerItems';

@Component({
  selector: 'app-module-deletestudent',
  standalone: true,
  imports: [MatChipsModule, MatCardModule, MatButtonModule],
  templateUrl: './module-deletestudent.component.html',
  styleUrl: './module-deletestudent.component.css'
})
export class ModuleDeletestudentComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  deleteStudent: any = {
    id: 0,
  enrolledModulesNum: 0,
  user: {
    id: 0,
    firstName: "",
    lastName: "",
    profileImage: ""
  }
  }
  activeRoute = inject(ActivatedRoute)

  ngOnInit(){
    this.GradeTrackerService.GetStudentById(this.activeRoute.snapshot.params["id"]).subscribe((resultedItem)=>{
      this.deleteStudent = resultedItem
      console.log(this.deleteStudent)
    });
  }
  onDeleteButtonClick(){
    this.GradeTrackerService.RemoveStudentFromModule(this.activeRoute.snapshot.params["moduleid"],this.activeRoute.snapshot.params["id"])
    .subscribe(() => {
      alert("Student deleted successfully");
      this.router.navigateByUrl("/module/details/"+this.activeRoute.snapshot.params["moduleid"])
    }, (error) => {
      console.error(error);
      alert("Student delete failed. Please try again.");
    });
  }
  onHomeButtonClick(){
    this.router.navigateByUrl("/module/details/"+this.activeRoute.snapshot.params["moduleid"])
  }
}
