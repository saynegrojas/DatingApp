import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ValueService } from '../../_service/value.service';
import { User } from 'src/app/_model/user';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
// OnInit interface for initalize lifecycle
export class ValueComponent implements OnInit {
  // for observable class property
  values: any;
  errorMessage: string;

  // bring httpClient use to go get our values
  constructor(private valueService: ValueService) {
    // now we have access to HttpClient through http private, we can make http requests to our API server

  }

  //  lifecycle method
  ngOnInit(): void {
    // call the getValues when our component initializes get the values populated with the response back from server
    // this.getValues();
    // init setting current user when calling this component
    // this.setCurrentUser();
  }

  // getValues() {
  //   this.valueService.getValue().subscribe({
  //     next: data => {
  //       this.values = data;
  //     }, error: err => this.errorMessage = err,
  //   });
  // }

  // // we going to look inside the browser localstorage & see if we have an object with a key of 'user'
  // // login will be persisted since we are getting the token from local storage (user object)
  // // & setting it to our valueService
  // setCurrentUser() {
  //   // set current user to var & since we stringyfied the object as a JSON format, we are going to parse it to turn it back to original way
  //   const user: User = JSON.parse(localStorage.getItem('user'));
  //   console.log(user);
  //   this.valueService.setCurrentUser(user);
  // }

  //


  /* // get our values
    // getValues() {
    //   // start http to make use of our http clients, get() method makes a get request
    //   // provide address of our API endpoint inside our get method returns an Observable - stream of data from API
    //   // need to subscribe our observable - takes in a function that returns no value
    //   this.http.get('http://localhost:5000/api/values').subscribe(response => {
    //     // values we're getting back from api
    //     this.values = response;
    //     // check for errors
    //   }, error => {
    //     console.log(error);
    //   });
    // }
  */

}
