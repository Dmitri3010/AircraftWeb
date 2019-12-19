import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../models/RegisterModel';
import { Observable, throwError } from 'rxjs';
import { registerService } from '../../app/register/register.service';
import { FormControl } from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  User: User;
  registerForm: FormGroup;
  service:registerService;

  constructor(public fb: FormBuilder, service : registerService) {
    this.registerForm = this.fb.group({
      login: [""],
      password: [""],
      email: [""]
    });
    this.service =service;


  }
 


  ngOnInit() {

  }


  registration() {

    var user = new User();
    user.email= this.registerForm.get("email").value;
    user.login = this.registerForm.get("password").value;
    user.password =  this.registerForm.get("password").value;
    this.service.register(user);

  }

}
