import { Component, OnInit, Inject, forwardRef } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../models/RegisterModel';
import { Observable, throwError } from 'rxjs';
import { FormControl } from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { authService } from './auth.service';



@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  User: User;
  authForm: FormGroup;
  service: authService;

  constructor(public fb: FormBuilder, @Inject(forwardRef(()=> authService)) service: authService) {
    this.authForm = this.fb.group({
      login: [""],
      password: [""]
    });
    this.service = service;


  }



  ngOnInit() {

  }


  auth() {

    var user = new User();
    user.login = this.authForm.get("password").value;
    user.password = this.authForm.get("password").value;
    this.service.auth(user);

  }

}
