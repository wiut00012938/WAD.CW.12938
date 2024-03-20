import { Component, inject} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';

@Component({
  selector: 'app-assignment-edit',
  standalone: true,
  imports: [FormsModule, MatInputModule, MatFormFieldModule, MatButtonModule],
  templateUrl: './assignment-edit.component.html',
  styleUrl: './assignment-edit.component.css'
})
export class AssignmentEditComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  editAssignment: any = {
    assignmentId: 0,
    assignmentName: "",
    assignmentDescription: "",
    createdDate: new Date()
  }
  activeRoute = inject(ActivatedRoute)

  ngOnInit(){
    this.GradeTrackerService.GetAssignmentById(this.activeRoute.snapshot.params["id"]).subscribe((resultedItem)=>{
      this.editAssignment = resultedItem
    });
  }
  edit(){
    this.GradeTrackerService.AssignmentEdit(this.editAssignment,this.activeRoute.snapshot.params["id"])
    .subscribe(() => {
      alert("Assignment edited successfully");
      this.router.navigateByUrl("/module/"+this.activeRoute.snapshot.params["moduleid"] + "/assignments")
    }, (error) => {
      console.error(error);
      alert("Assignment edit failed. Please try again.");
    });
  }
}
