import { Component, OnInit } from '@angular/core';
import {IndexServices} from './index.service';
import { Flight } from 'src/models/Flight';


@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  service: IndexServices;
  public flightsArr: any;


  constructor(service: IndexServices) {
    this.service = service;
    this.flights();

  }

  flights() {
    let flight = this.service.getFlights();
    flight.subscribe(result => {
      this.flightsArr = result as Flight[];
    });
  }

  ngOnInit(){

  }

}
