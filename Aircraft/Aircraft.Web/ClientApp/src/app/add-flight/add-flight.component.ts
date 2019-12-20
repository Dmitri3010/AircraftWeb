import { Component, OnInit, Inject, forwardRef } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AddFlightService } from './add-flight.service';
import { Router } from "@angular/router";
import { ResponceModel } from "../../models/responseModel";
import {Flight} from "../../models/Flight";


@Component({
  selector: 'app-add-flight',
  templateUrl: './add-flight.component.html',
  styleUrls: ['./add-flight.component.css']
})
export class AddFlightComponent implements OnInit {
  flightForm: FormGroup;
  service: AddFlightService;
  router: Router;
  responce: ResponceModel;

  constructor(public fb: FormBuilder, @Inject(forwardRef(() => AddFlightService)) service: AddFlightService, router: Router) {
    this.flightForm = this.fb.group({
      arrivivalCity: [""],
      fromCity: [""],
      cost: [""],
      time: [""]
    });
    this.service = service;
    this.router = router;
  }


  ngOnInit() {
  }

  addFlight() {
    var flight = new Flight();

    flight.ArrivivalCity = this.flightForm.get("arrivivalCity").value;
    flight.FromCity = this.flightForm.get("fromCity").value;
    flight.Cost = this.flightForm.get("cost").value;
    flight.Time = this.flightForm.get("time").value;


    var addedFlight = this.service.addFlight(flight);
    addedFlight.subscribe(result => {
      var resJson = JSON.stringify(result);
      this.responce = JSON.parse(resJson);
      console.log(this.responce.status);
      if (this.responce.status == '200') {
        this.router.navigate(['/flights']);
      }

    });

  }

}
