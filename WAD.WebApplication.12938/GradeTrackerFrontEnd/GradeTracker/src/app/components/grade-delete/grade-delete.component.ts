import { Component, inject } from '@angular/core';
import { MatChipsModule } from '@angular/material/chips';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';

@Component({
  selector: 'app-grade-delete',
  standalone: true,
  imports: [MatChipsModule, MatCardModule, MatButtonModule],
  templateUrl: './grade-delete.component.html',
  styleUrl: './grade-delete.component.css'
})
export class GradeDeleteComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  deleteGrade: any = {
    gradeId:0,
    score: 0,
    feedback: ""
  }
  activeRoute = inject(ActivatedRoute)

  ngOnInit(){
    this.GradeTrackerService.GetGradeById(this.activeRoute.snapshot.params["id"]).subscribe((resultedItem)=>{
      this.deleteGrade = resultedItem
    });
  }
  onDeleteButtonClick(){
    this.GradeTrackerService.GradeDelete(this.activeRoute.snapshot.params["id"])
    .subscribe(() => {
      alert("Grade deleted successfully");
      this.router.navigateByUrl(`/module/${this.activeRoute.snapshot.params["moduleid"]}/assignment/${this.activeRoute.snapshot.params["assignmentid"]}/grades`)
    }, (error) => {
      console.error(error);
      alert("Grade delete failed. Please try again.");
    });
  }
  onHomeButtonClick(){
    this.router.navigateByUrl(`/module/${this.activeRoute.snapshot.params["moduleid"]}/assignment/${this.activeRoute.snapshot.params["assignmentid"]}/grades`)
  }
}
