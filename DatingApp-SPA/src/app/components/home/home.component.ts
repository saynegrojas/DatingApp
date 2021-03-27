import { Component, OnInit } from '@angular/core';
import { ValueService } from 'src/app/_service/value.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  // give us the ability to use directive on elements
  registerMode = false;

  users: any = {};
  constructor(private valueService: ValueService) { }

  ngOnInit(): void {
    this.getUsers();
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  // get users from api
  getUsers() {
    this.valueService.getValue().subscribe(data => this.users = data);
  }

  // child to parent - gets value from emitted event from the child component
  // pass in the method, set it to the registerMode
  // the event we send out is a boolean 
  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

}
