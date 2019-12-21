import { Component, OnInit, forwardRef, Inject, NgZone } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../models/RegisterModel';
import { retry, catchError } from 'rxjs/operators';
import { Observable, throwError, from } from 'rxjs';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Plane } from 'src/models/plane';
import { Flight } from 'src/models/Flight';
import { Ticket } from 'src/models/Ticket';

@Injectable({
    providedIn: 'root'
})

export class IndexServices {
    myAppUrl: string;
    myApiUrl: string;
    _http: HttpClient;

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json; charset=UTF-8',

        })

    };

    constructor(private http: HttpClient) {
        this.myAppUrl = environment.appUrl;
        this.myApiUrl = 'api/flight/Getflights/';
        this._http = http;

    }

    getFlights(): Observable<Flight[]> {
        return this.http.get<Flight[]>(this.myAppUrl + this.myApiUrl)
    }

    addTicket(ticket: Ticket): Observable<Ticket> {
        return this.http.post<Ticket>(this.myAppUrl + 'api/tickets/AddOrUpdate/', JSON.stringify(ticket), this.httpOptions);
    }
}
