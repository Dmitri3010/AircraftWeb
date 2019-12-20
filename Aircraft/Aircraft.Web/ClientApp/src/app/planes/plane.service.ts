import { Component, OnInit, forwardRef,Inject, NgZone } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../models/RegisterModel';
import { retry, catchError } from 'rxjs/operators';
import { Observable, throwError, from } from 'rxjs';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { PlanesComponent } from './planes.component';
import { Plane } from 'src/models/plane';

@Injectable({
    providedIn: 'root'
})

export class planesServices{
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
        this.myApiUrl = 'api/plane/GetPlanes/';
        this._http = http;       

    }

    getPlanes():Observable<Plane[]>{
        return this.http.get<Plane[]>(this.myAppUrl+this.myApiUrl)
    }
}
