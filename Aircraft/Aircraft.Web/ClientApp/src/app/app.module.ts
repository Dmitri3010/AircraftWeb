import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TicketsComponent } from './tickets/tickets.component';
import { IndexComponent } from './index/index.component';
import { AuthComponent } from './auth/auth.component';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { registerService } from './register/register.service';
import { HttpClientModule } from '@angular/common/http'; 
import {authService} from './auth/auth.service';
import { PlanesComponent } from './planes/planes.component';
import { HotPricesComponent } from './hot-prices/hot-prices.component';
import { FlyghtsComponent } from './flyghts/flyghts.component';
import { AddPlaneComponent } from './add-plane/add-plane.component';
import { AddPlaneService } from './add-plane/add-plane.service';
import { planesServices } from './planes/plane.service';

@NgModule({
  imports: [
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  declarations: [
    AppComponent,
    TicketsComponent,
    IndexComponent,
    AuthComponent,
    RegisterComponent,
    PlanesComponent,
    HotPricesComponent,
    FlyghtsComponent,
    AddPlaneComponent,
  ],

  providers: [registerService,authService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
