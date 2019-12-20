import { Component, OnInit, forwardRef, NgZone } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../models/RegisterModel';
import { retry, catchError } from 'rxjs/operators';
import { Observable, throwError, from } from 'rxjs';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { AuthComponent } from './auth.component';

@Injectable({
    providedIn: 'root'
})

export class authService {
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
        this.myApiUrl = 'api/auth/login/';
        this._http = http;

    }

    errorHandler(responce) {

        if (responce.status !== 200) {
            document.getElementById('incorrectLoginText').style.display = "flex";
        }
        else {

        }
        return throwError(responce);
    }

    auth(User: User): Observable<User> {

        return this._http.post<User>(this.myAppUrl + this.myApiUrl, JSON.stringify(User), this.httpOptions);
    }
}
