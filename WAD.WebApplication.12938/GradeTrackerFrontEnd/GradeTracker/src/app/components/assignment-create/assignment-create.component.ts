import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-assignment-create',
  standalone: true,
  imports: [FormsModule, MatInputModule, MatFormFieldModule, MatButtonModule],
  templateUrl: './assignment-create.component.html',
  styleUrl: './assignment-create.component.css'
})
export class AssignmentCreateComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  createAssignment: any = {
    assignmentId: 0,
    assignmentName: "",
    assignmentDescription: "",
    createdDate: new Date()
  }
  activeRoute = inject(ActivatedRoute)
  create(){
    this.GradeTrackerService.AssignmentCreate(this.createAssignment,this.activeRoute.snapshot.params["id"])
    .subscribe(() => {
      alert("Assignment created successfully");
      this.router.navigateByUrl("/module/"+this.activeRoute.snapshot.params["id"] + "/assignments")
    });
  }
}
