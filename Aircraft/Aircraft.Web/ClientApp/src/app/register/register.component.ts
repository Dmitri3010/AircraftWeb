import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../models/RegisterModel';
import { Observable, throwError } from 'rxjs';
import { registerService } from '../../app/register/register.service';
import { FormControl } from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {ResponceModel} from '../../models/responseModel';
import { Router } from "@angular/router";




@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  User: User;
  registerForm: FormGroup;
  service:registerService;
  responce:ResponceModel;
  router: Router;



  constructor(public fb: FormBuilder, service : registerService, router: Router) {
    this.registerForm = this.fb.group({
      login: [""],
      password: [""],
      email: [""]
    });
    this.service =service;


  }
 


  ngOnInit() {

  }

  navigateToHome() {
    this.router.navigate(['']);
  }


  registration() {

    var user = new User();
    user.email= this.registerForm.get("email").value;
    user.login = this.registerForm.get("password").value;
    user.password =  this.registerForm.get("password").value;
   var login = this.service.register(user);
    login.subscribe(result =>{
      var resJson = JSON.stringify(result);
      this.responce = JSON.parse(resJson);
      console.log(this.responce.status);
      if(this.responce.status == '200'){
        localStorage.setItem("access-token", this.responce.message);
        this.navigateToHome();
      }
      else{
        document.getElementById('incorrectRegisterText').style.display = "flex";
      }
   });

  }

}
