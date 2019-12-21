import { Component, OnInit } from '@angular/core';
import { IndexServices } from './index.service';
import { Flight } from 'src/models/Flight';
import { Ticket } from 'src/models/Ticket';

import { FormGroup, FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  service: IndexServices;
  public flightsArr: any;
  ticketForm: FormGroup;
  ticket: Ticket;
  arr: String;
  froms: String;
  timee: String;



  constructor(service: IndexServices, public fb: FormBuilder) {
    this.ticketForm = this.fb.group({
      arrivivalCity: [""],
      fromCity: [""],
      cost: [""],
      time: [""],
      email: [""]
    });
    this.service = service;
    this.flights();

  }

  flights() {
    let flight = this.service.getFlights();
    flight.subscribe(result => {
      this.flightsArr = result as Flight[];
    });
  }

  buyTicket(from: String, arrivivalCity: String, time: String) {
    console.log(arrivivalCity);
    this.arr = arrivivalCity;
    this.froms = from;
    this.timee = time;
    document.getElementById('buy').style.display = "flex";


  }

  getTicket() {
    var ticket = new Ticket();
    ticket.ArrivivalCity = this.arr;
    ticket.FromCity = this.froms;
    ticket.Time = this.timee;

    ticket.Email = document.getElementById('email').value;
    console.log(ticket.Email);
    var ticketData = this.service.addTicket(ticket);
    ticketData.subscribe();
  }

  ngOnInit() {

  }

}
