import { Component, inject} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';

@Component({
  selector: 'app-grade-edit',
  standalone: true,
  imports: [FormsModule, MatInputModule, MatFormFieldModule, MatButtonModule],
  templateUrl: './grade-edit.component.html',
  styleUrl: './grade-edit.component.css'
})
export class GradeEditComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  editGrade: any = {
    gradeId:0,
    score: 0,
    feedback: ""
  }
  activeRoute = inject(ActivatedRoute)

  ngOnInit(){
    this.GradeTrackerService.GetGradeById(this.activeRoute.snapshot.params["id"]).subscribe((resultedItem)=>{
      this.editGrade = resultedItem
    });
  }
  edit(){
    this.GradeTrackerService.GradeEdit(this.editGrade,this.activeRoute.snapshot.params["id"])
    .subscribe(() => {
      alert("Grade edited successfully");
      this.router.navigateByUrl(`/module/${this.activeRoute.snapshot.params["moduleid"]}/assignment/${this.activeRoute.snapshot.params["assignmentid"]}/grades`)
    }, (error) => {
      console.error(error);
      alert("Grade edit failed. Please try again.");
    });
  }
}
