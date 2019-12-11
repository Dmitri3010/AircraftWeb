import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {IndexComponent} from './index/index.component';
import {AuthComponent} from './auth/auth.component';


const routes: Routes = [
  {path:'', component: IndexComponent,pathMatch:'full' },
  {path:'auth', component: AuthComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
