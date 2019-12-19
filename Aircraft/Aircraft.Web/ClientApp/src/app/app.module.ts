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
  ],

  providers: [registerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
