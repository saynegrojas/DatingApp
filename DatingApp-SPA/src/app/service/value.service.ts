import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ValueService {

  constructor(private http: HttpClient) { }

  private url = 'http://localhost:5000/api/values';
  getValue(): Observable<any> {
    return this.http.get(this.url).pipe(tap((data) =>
    console.log('All ' + JSON.stringify(data))),
    catchError(this.handleError)
    );
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
