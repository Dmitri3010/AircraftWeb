import { Component, OnInit, forwardRef, NgZone } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../models/RegisterModel';
import { retry, catchError } from 'rxjs/operators';
import { Observable, throwError, from } from 'rxjs';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Flight } from 'src/models/Flight';

@Injectable({
    providedIn: 'root'
})
export class AddFlightService{
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
        this.myApiUrl = 'api/flight/AddOrUpdate/';
        this._http = http;

    }

    addFlight(flight : Flight):Observable<Flight>{
        return this.http.post<Flight>(this.myAppUrl + this.myApiUrl, JSON.stringify(flight), this.httpOptions);
    }
}
