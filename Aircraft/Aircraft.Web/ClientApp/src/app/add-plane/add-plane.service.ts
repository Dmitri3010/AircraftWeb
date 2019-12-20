import { Component, OnInit, forwardRef, NgZone } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../models/RegisterModel';
import { retry, catchError } from 'rxjs/operators';
import { Observable, throwError, from } from 'rxjs';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { AddPlaneComponent } from './add-plane.component';
import { Plane } from 'src/models/plane';

@Injectable({
    providedIn: 'root'
})
export class AddPlaneService{
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
        this.myApiUrl = 'api/plane/AddOrUpdate/';
        this._http = http;

    }

    addPlane(plane : Plane):Observable<Plane>{
        return this.http.post<Plane>(this.myAppUrl + this.myApiUrl, JSON.stringify(plane), this.httpOptions);
    }
}
