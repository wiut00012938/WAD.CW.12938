import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ModuleDetailsComponent } from './components/module-details/module-details.component';
import { ModuleDeleteComponent } from './components/module-delete/module-delete.component';
import { ModuleEditComponent } from './components/module-edit/module-edit.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { TeacherHomeComponent } from './components/teacher-home/teacher-home.component';
import { TeacherModuleComponent } from './components/teacher-module/teacher-module.component';
import { ModuleCreateComponent } from './components/module-create/module-create.component';
import { ModuleAddstudentComponent } from './components/module-addstudent/module-addstudent.component';
import { ModuleDeletestudentComponent } from './components/module-deletestudent/module-deletestudent.component';
import { TeacherAssignmentComponent } from './components/teacher-assignment/teacher-assignment.component';
import { AssignmentEditComponent } from './components/assignment-edit/assignment-edit.component';
import { AssignmentCreateComponent } from './components/assignment-create/assignment-create.component';
import { AssignnmentGradesComponent } from './components/assignnment-grades/assignnment-grades.component';
import { GradeDetailsComponent } from './components/grade-details/grade-details.component';
import { GradeDeleteComponent } from './components/grade-delete/grade-delete.component';
import { GradeEditComponent } from './components/grade-edit/grade-edit.component';
import { GradeCreateComponent } from './components/grade-create/grade-create.component';
import { AssignmentDeleteComponent } from './components/assignment-delete/assignment-delete.component';
import { StudentHomeComponent } from './components/student-home/student-home.component';
import { LoginStudentComponent } from './components/login-student/login-student.component';
import { RegisterStudentComponent } from './components/register-student/register-student.component';
import { StudentModulesComponent } from './components/student-modules/student-modules.component';
import { StudentGradesComponent } from './components/student-grades/student-grades.component';

export const routes: Routes = [
    {
        path:"",
        component:HomeComponent
    },
    {
        path:"home",
        component:HomeComponent
    },
    {
        path:"teacher-home/:id",
        component:TeacherHomeComponent
    },
    {
        path: "student-home/:id",
        component:StudentHomeComponent
    },
    {
        path: "login",
        component: LoginComponent
    },
    {
        path: "register",
        component: RegisterComponent
    },
    {
        path: "login-student",
        component: LoginStudentComponent
    },
    {
        path: "register-student",
        component: RegisterStudentComponent
    },
    {
        path: "student/:id/modules",
        component: StudentModulesComponent
    },
    {
        path: "student/:id/grades",
        component: StudentGradesComponent
    },
    {
        path: "teacher/:id/modules",
        component: TeacherModuleComponent
    },
    {
        path: "module/create/:id",
        component: ModuleCreateComponent
    },
    {
        path:"module/:teacherid/edit/:id",
        component:ModuleEditComponent
    },
    {
        path:"module/details/:id",
        component:ModuleDetailsComponent
    },
    {
        path:"module/:teacherid/delete/:id",
        component:ModuleDeleteComponent
    },
    {
        path: "module/:id/student/add",
        component:ModuleAddstudentComponent
    },
    {
        path:"module/:moduleid/student/delete/:id",
        component:ModuleDeletestudentComponent
    },
    {
        path:"module/:id/assignments",
        component:TeacherAssignmentComponent
    },
    {
        path:"module/:moduleid/assignment/edit/:id",
        component:AssignmentEditComponent
    },
    {
        path:"module/:moduleid/assignment/delete/:id",
        component:AssignmentDeleteComponent
    },
    {
        path:"module/:id/assignment/create",
        component:AssignmentCreateComponent
    },
    {
        path:"module/:moduleid/assignment/:id/grades",
        component: AssignnmentGradesComponent
    },
    {
        path:"grade/details/:id",
        component:GradeDetailsComponent
    },
    {
        path:"module/:moduleid/assignment/:assignmentid/grade/edit/:id",
        component:GradeEditComponent
    },
    {
        path:"module/:moduleid/assignment/:assignmentid/grade/delete/:id",
        component:GradeDeleteComponent
    },
    {
        path:"module/:moduleid/assignment/:assignmentid/grade/create",
        component:GradeCreateComponent
    }

];
