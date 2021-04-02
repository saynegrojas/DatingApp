import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css']
})
export class NotFoundComponent implements OnInit {
  errorStatus: any;
  // access state of nav with Router, must init in constructor & will only load once
  constructor(private location: Location, private router: Router) {
    const navigation = this.router.getCurrentNavigation();
    this.errorStatus = navigation?.extras?.state?.error;
  }

  ngOnInit(): void {
  }
  goBack() {
    this.location.back();
  }
}
