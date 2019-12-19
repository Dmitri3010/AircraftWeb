import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../models/RegisterModel';
import { retry, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment'


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

    errorHandler(error) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            errorMessage = error.error.message;
        } else {
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        console.log(errorMessage);
        return throwError(errorMessage);
    }

    auth(User: User): Observable<User> {

        this._http.post<User>(this.myAppUrl + this.myApiUrl, JSON.stringify(User), this.httpOptions)    
        .pipe(catchError(this.errorHandler))
        .subscribe(value=> console.log("asdasdasdasd",value));
        return;
    }

}
