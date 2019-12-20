import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { AuthComponent } from './auth/auth.component';
import { RegisterComponent } from './register/register.component';
import { PlanesComponent } from './planes/planes.component';
import { AddPlaneComponent } from './add-plane/add-plane.component';
import { FlightsComponent } from './flights/flights.component';
import { AddFlightComponent } from './add-flight/add-flight.component';


const routes: Routes = [
  { path: '', component: IndexComponent, pathMatch: 'full' },
  { path: 'auth', component: AuthComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'planes', component: PlanesComponent },
  { path: 'addOrUpdatePlane', component: AddPlaneComponent },
  { path: 'flights', component: FlightsComponent },
  { path: 'addOrUpdateFlight', component: AddFlightComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
