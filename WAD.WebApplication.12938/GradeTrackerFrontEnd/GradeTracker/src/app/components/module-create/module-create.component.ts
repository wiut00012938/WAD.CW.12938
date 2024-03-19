import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { ServiceGradetrackerService } from '../../service-gradetracker.service';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, of } from 'rxjs';

@Component({
  selector: 'app-module-create',
  standalone: true,
  imports: [FormsModule, MatInputModule, MatFormFieldModule, MatButtonModule],
  templateUrl: './module-create.component.html',
  styleUrl: './module-create.component.css'
})
export class ModuleCreateComponent {
  GradeTrackerService = inject(ServiceGradetrackerService)
  router = inject(Router)
  createModule: any = {
    moduleId: 0,
    moduleName: "",
    moduleDescription: ""
  }
  activeRoute = inject(ActivatedRoute)
  create(){
    this.GradeTrackerService.ModuleCreate(this.createModule,this.activeRoute.snapshot.params["id"])
    .subscribe(() => {
      alert("Module created successfully");
      this.router.navigateByUrl("/teacher/"+this.activeRoute.snapshot.params["id"] + "/modules")
    });
  }
}
