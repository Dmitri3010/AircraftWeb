import { Component, OnInit } from '@angular/core';
import { flightsServices } from "./flights.service"
import { Flight } from 'src/models/Flight';

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.css']
})
export class FlightsComponent implements OnInit {
  service: flightsServices;
  public flightsArr: any;


  constructor(service: flightsServices) {
    this.service = service;
    this.flights();

  }

  flights() {
    let flight = this.service.getFlights();
    flight.subscribe(result => {
      this.flightsArr = result as Flight[];
      console.log(this.flightsArr);
    });
  }

  ngOnInit() {
  }


}
