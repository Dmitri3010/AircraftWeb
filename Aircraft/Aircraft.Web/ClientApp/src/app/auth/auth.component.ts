import { Component, OnInit, Inject, forwardRef } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../models/RegisterModel';
import { Observable, throwError } from 'rxjs';
import { FormControl } from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { authService } from './auth.service';
import { Router } from "@angular/router";
import {ResponceModel} from "../../models/responseModel";


@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  User: User;
  authForm: FormGroup;
  service: authService;
  router: Router;
  responce:ResponceModel;

  constructor(public fb: FormBuilder, @Inject(forwardRef(() => authService)) service: authService, router: Router) {
    this.authForm = this.fb.group({
      login: [""],
      password: [""]
    });
    this.service = service;
    this.router = router;
  }



  ngOnInit() {

  }

  navigateToHome() {
    this.router.navigate(['']);
  }


  auth() {

    var user = new User();
    user.login = this.authForm.get("password").value;
    user.password = this.authForm.get("password").value;
     var login = this.service.auth(user);
     login.subscribe(result =>{
        var resJson = JSON.stringify(result);
        this.responce = JSON.parse(resJson);
        console.log(this.responce.status);
        if(this.responce.status == '200'){
          localStorage.setItem("access-token", this.responce.message);
          this.navigateToHome();
        }
        else{
          document.getElementById('incorrectLoginText').style.display = "flex";
        }
     });
     
    }

}
