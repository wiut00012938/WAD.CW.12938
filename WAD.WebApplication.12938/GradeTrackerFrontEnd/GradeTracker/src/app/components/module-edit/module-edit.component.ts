import { Component, inject} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
@Component({
  selector: 'app-module-edit',
  standalone: true,
  imports: [FormsModule, MatInputModule, MatFormFieldModule, MatButtonModule],
  templateUrl: './module-edit.component.html',
  styleUrl: './module-edit.component.css'
})
export class ModuleEditComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  createModule: any = {
    moduleId: 0,
    moduleName: "",
    moduleDescription: ""
  }
  activeRoute = inject(ActivatedRoute)

  ngOnInit(){
    this.GradeTrackerService.ModuleDetails(this.activeRoute.snapshot.params["id"]).subscribe((resultedItem)=>{
      this.createModule = resultedItem
    });
  }
  edit(){
    this.GradeTrackerService.ModuleEdit(this.createModule,this.activeRoute.snapshot.params["id"])
    .subscribe(() => {
      alert("Module edited successfully");
      this.router.navigateByUrl("/teacher/"+this.activeRoute.snapshot.params["teacherid"] + "/modules")
    }, (error) => {
      console.error(error);
      alert("Module edit failed. Please try again.");
    });
  }
}
