import { Component, inject } from '@angular/core';
import { MatChipsModule } from '@angular/material/chips';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
@Component({
  selector: 'app-module-delete',
  standalone: true,
  imports: [MatChipsModule, MatCardModule, MatButtonModule],
  templateUrl: './module-delete.component.html',
  styleUrl: './module-delete.component.css'
})
export class ModuleDeleteComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  deleteModule: any = {
    moduleId: 0,
    moduleName: "",
    moduleDescription: ""
  }
  activeRoute = inject(ActivatedRoute)

  ngOnInit(){
    this.GradeTrackerService.ModuleDetails(this.activeRoute.snapshot.params["id"]).subscribe((resultedItem)=>{
      this.deleteModule = resultedItem
      console.log(this.deleteModule)
    });
  }
  onDeleteButtonClick(){
    this.GradeTrackerService.ModuleDelete(this.activeRoute.snapshot.params["id"])
    .subscribe(() => {
      alert("Module deleted successfully");
      this.router.navigateByUrl("/teacher/"+this.activeRoute.snapshot.params["teacherid"] + "/modules")
    }, (error) => {
      console.error(error);
      alert("Module delete failed. Please try again.");
    });
  }
  onHomeButtonClick(){
    this.router.navigateByUrl("/teacher/"+this.activeRoute.snapshot.params["teacherid"] + "/modules")
  }
}
