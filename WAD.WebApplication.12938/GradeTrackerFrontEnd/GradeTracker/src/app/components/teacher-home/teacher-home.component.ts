import { Component, OnInit, inject } from '@angular/core';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import { ActivatedRoute, Router} from '@angular/router';
import { Teacher } from '../../GradeTrackerItems';
import { MatIconModule } from '@angular/material/icon';


@Component({
  selector: 'app-teacher-home',
  standalone: true,
  imports: [MatIconModule],
  templateUrl: './teacher-home.component.html',
  styleUrl: './teacher-home.component.css'
})
export class TeacherHomeComponent implements OnInit{
  
  GradeTrackerService = inject(ServiceGradetrackerService)
  
  emptyTeacher: Teacher = {
    id: 0,
    teacherBackground: "",
    user: {
        id: 0,
        firstName: "",
        lastName: "",
        profileImage: ""
      }
  };

  activeRoute = inject(ActivatedRoute)
  ngOnInit(){
    this.GradeTrackerService.getTeacherById(this.activeRoute.snapshot.params["id"]).subscribe((resultedItem)=>{
      this.emptyTeacher = resultedItem
    });
  }
  
  router = inject(Router)
  onLeadingModulesClicked() {
    this.router.navigateByUrl("/teacher/"+this.emptyTeacher.id + "/modules")
  }
}
