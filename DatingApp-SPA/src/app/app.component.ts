import { Component, OnInit } from '@angular/core';
import { User } from './_model/user';
import { AccountService } from './_service/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'DatingApp-SPA';

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
    this.setCurrentUser();
  }

  // we going to look inside the browser localstorage & see if we have an object with a key of 'user'
  // login will be persisted since we are getting the token from local storage (user object)
  // & setting it to our valueService
  setCurrentUser() {
    // set current user to var & since we stringyfied the object as a JSON format, we are going to parse it to turn it back to original way
    const user: User = JSON.parse(localStorage.getItem('user'));
    // console.log(user);
    this.accountService.setCurrentUser(user);
  }
}
