import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ModuleDetailsComponent } from './components/module-details/module-details.component';
import { ModuleDeleteComponent } from './components/module-delete/module-delete.component';
import { ModuleEditComponent } from './components/module-edit/module-edit.component';

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
        path:"edit/:id",
        component:ModuleEditComponent
    },
    {
        path:"details/:id",
        component:ModuleDetailsComponent
    },
    {
        path:"delete/:id",
        component:ModuleDeleteComponent
    }

];
