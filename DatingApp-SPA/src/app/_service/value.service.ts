import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, ReplaySubject, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { User } from '../_model/user';

@Injectable({
  providedIn: 'root'
})
export class ValueService {

  constructor(private http: HttpClient) { }

  // create an observable to store our Users(data) in
  // ReplaySubject - is an observable type, like a buffer object which is going to store the values inside
  // & anytime a subscriber subs to the observable, it allows us to emmit however many values we want it to emit in it
  // give it a type of User since we are going to store this type in replaysubject
  // insert how many previous values we want it to store (1 for now)
  private currentUserSource = new ReplaySubject<User>(1);
  // $ convention for observable
  currentUser$ = this.currentUserSource.asObservable();

  // get list
  private url = 'http://localhost:5000/api/';

  getValue(): Observable<any> {
    return this.http.get(this.url + 'values').pipe(tap((data) =>
    console.log('All ' + JSON.stringify(data))),
    catchError(this.handleError)
    );
  }

  // login sending request to server
  login(model: any) {
    // map - applies a function to every value emitted by an Observable
    // & emits results as an observable
    return this.http.post(this.url + 'account/login', model).pipe(map((data: User) => {
      // set our data to a local var
      const user = data;
      console.log(user);
      // check if we have a user
      if (user) {
        // we are going to populate browser local storage with our data by setting the item
        // we give setItem a key value pair with our value being the data we get as a response
        // we are then going to take our object & stringify it
        localStorage.setItem('user', JSON.stringify(user));
        // set our current user we get back from API
        this.currentUserSource.next(user);
      }
      // will store our data in local storage to perist login
      // const
      // console.log('All' + JSON.stringify(data)),
      // catchError(this.handleError);
    }));
  }

  // register sending post request to server
  register(model: any) {
    // call post to server
    return this.http.post(this.url + 'account/register', model).pipe(map((data: User) => {
      const user = data;
      if (user) {
        localStorage.setItem('user', JSON.stringify(user));
        this.currentUserSource.next(user);
      }
      return user;
    }));
  }

  // create a helper method
  setCurrentUser(user: User) {
    this.currentUserSource.next(user);
  }

  // logout will set localstorage to null so we can take our credentials out
  logout() {
    // we are using the key from localstorage to remove the item
    localStorage.removeItem('user');
    // set current user value to null
    this.currentUserSource.next(null);
  }

  private handleError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `${err.error.message}`;
    } else {
      errorMessage = `${err.status} : ${err.message}`;
    }
    return throwError;
  }
}
