import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
// OnInit interface for initalize lifecycle
export class ValueComponent implements OnInit {
  // for observable class property
  values: any;

  // bring httpClient use to go get our values
  constructor(private http: HttpClient) {
    // now we have access to HttpClient through http private, we can make http requests to our API server

  }

  //  lifecycle method
  ngOnInit() {
    // call the getValues when our component initializes get the values populated with the response back from server
    this.getValues();
  }

  // get our values
  getValues() {
    // start http to make use of our http clients, get() method makes a get request
    // provide address of our API endpoint inside our get method returns an Observable - stream of data from API
    // need to subscribe our observable - takes in a function that returns no value
    this.http.get('http://localhost:5000/api/values').subscribe(response => {
      // values we're getting back from api
      this.values = response;
      // check for errors
    }, error => {
      console.log(error);
    });
  }

}
