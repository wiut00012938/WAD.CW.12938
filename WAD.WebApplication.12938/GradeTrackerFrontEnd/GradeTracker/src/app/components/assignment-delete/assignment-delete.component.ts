import { Component, inject } from '@angular/core';
import { MatChipsModule } from '@angular/material/chips';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';

@Component({
  selector: 'app-assignment-delete',
  standalone: true,
  imports: [MatChipsModule, MatCardModule, MatButtonModule],
  templateUrl: './assignment-delete.component.html',
  styleUrl: './assignment-delete.component.css'
})
export class AssignmentDeleteComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  assignmentDelete: any = {
    assignmentId: 0,
    assignmentName: "",
    assignmentDescription: "",
    createdDate: new Date()
  }
  activeRoute = inject(ActivatedRoute)

  gOnInit(){
    this.GradeTrackerService.GetAssignmentById(this.activeRoute.snapshot.params["id"]).subscribe((resultedItem)=>{
      this.assignmentDelete = resultedItem
    });
  }
  onDeleteButtonClick(){
    this.GradeTrackerService.AssignmentDelete(this.activeRoute.snapshot.params["id"])
    .subscribe(() => {
      alert("Module deleted successfully");
      this.router.navigateByUrl("/module/"+this.activeRoute.snapshot.params["moduleid"] + "/assignments")
    }, (error) => {
      console.error(error);
      alert("Assignment delete failed. Ensure that grades are deleted first.");
    });
  }
  onHomeButtonClick(){
    this.router.navigateByUrl("/module/"+this.activeRoute.snapshot.params["moduleid"] + "/assignments")
  }
}
