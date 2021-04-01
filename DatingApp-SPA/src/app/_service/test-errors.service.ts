import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TestErrorsService {
  // base url
  private url = 'http://localhost:5000/api/';
  // test to see the different responses we get back from the server
  constructor(private http: HttpClient) { }

  // not-found endpoint 404
  get404Error() {
    return this.http.get(this.url + 'buggy/not-found').pipe(map((data) => {
      console.log('404', JSON.stringify(data));
    }, error => console.log(error)));
  }

  // bad-request endpoint 400
  get400Error() {
    return this.http.get(this.url + 'buggy/bad-request').pipe(map((data) => {
        console.log('400', JSON.stringify(data));
    }, error => console.log(error)));
  }
  // server-error endpoint 500
  get500Error() {
    return this.http.get(this.url + 'buggy/server-error').pipe(map((data) => {
      console.log('500', JSON.stringify(data));
    }, error => console.log(error)));
  }
  // auth endpoint 401
  get401Error() {
    return this.http.get(this.url + 'buggy/auth').pipe(map((data) => {
      console.log('401', JSON.stringify(data));
    }, error => console.log(error)));
  }
  // register endpoint 400 with validation error checking
  // make a post request & we pass in an default empty object since it requires to pass in an object
  get400ValidationError() {
    return this.http.post(this.url + 'account/register', {}).pipe(map((data) => {
      console.log('400: Valiation', JSON.stringify(data));
    }, error => console.log(error)));
  }
}
