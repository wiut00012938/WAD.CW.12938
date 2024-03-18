import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ModuleDetailsComponent } from './components/module-details/module-details.component';
import { ModuleDeleteComponent } from './components/module-delete/module-delete.component';
import { ModuleEditComponent } from './components/module-edit/module-edit.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';

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
        path: "login",
        component: LoginComponent
    },
    {
        path: "register",
        component: RegisterComponent
    },
    {
        path:"module/edit/:id",
        component:ModuleEditComponent
    },
    {
        path:"module/details/:id",
        component:ModuleDetailsComponent
    },
    {
        path:"module/delete/:id",
        component:ModuleDeleteComponent
    }

];
