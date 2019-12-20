import { Component, OnInit, Inject, forwardRef } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../models/RegisterModel';
import { Observable, throwError } from 'rxjs';
import { FormControl } from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AddPlaneService } from './add-plane.service';
import { Router } from "@angular/router";
import { ResponceModel } from "../../models/responseModel";
import { Plane } from 'src/models/plane';


@Component({
  selector: 'app-add-plane',
  templateUrl: './add-plane.component.html',
  styleUrls: ['./add-plane.component.css']
})
export class AddPlaneComponent implements OnInit {
  planeForm: FormGroup;
  service: AddPlaneService;
  router: Router;
  responce: ResponceModel;

  constructor(public fb: FormBuilder, @Inject(forwardRef(() => AddPlaneService)) service: AddPlaneService, router: Router) {
    this.planeForm = this.fb.group({
      model: [""],
      manufacturer: [""],
      createdYear: [""]
    });
    this.service = service;
    this.router = router;
  }


  ngOnInit() {
  }

  addPlane() {
    var plane = new Plane();

    plane.Model = this.planeForm.get("model").value;
    plane.Manufacturer = this.planeForm.get("manufacturer").value;
    plane.CreatedYear = this.planeForm.get("createdYear").value;

    var addedPlane = this.service.addPlane(plane);
    addedPlane.subscribe(result => {
      var resJson = JSON.stringify(result);
      this.responce = JSON.parse(resJson);
      console.log(this.responce.status);
      if (this.responce.status == '200') {
        this.router.navigate(['/planes']);
      }

    });

  }

}
