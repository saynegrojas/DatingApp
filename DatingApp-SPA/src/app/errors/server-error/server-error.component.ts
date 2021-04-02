import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.css']
})
export class ServerErrorComponent implements OnInit {

  // will hold the navigation extras status from interceptor
  error: any;

  constructor(private router: Router, private location: Location) {
    // access navigation extras
    const navigation = this.router.getCurrentNavigation();
    // set the navigation extras' state to property
    this.error = navigation?.extras?.state?.error;
  }

  ngOnInit(): void {
  }

  goBack() {
    this.location.back();
  }

}
