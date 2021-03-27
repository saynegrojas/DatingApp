import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/_model/user';
import { ValueService } from 'src/app/_service/value.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  // where our data will be stored from template
  model: any = {};
// give us ability to conditionally display things inside our UI
  // loggedIn = false; //don't need since we are going to create an observable with type of our interface
  currentUser$: Observable<User>;

  // inject service
  constructor(private valueService: ValueService) { }

  ngOnInit(): void {
    // get current user when this component loads
    this.getCurrentUser();

    // we set the currentuser$ observable to the currentUser value we get from valueService
    this.currentUser$ = this.valueService.currentUser$;
  }

  // use this method to get value from ngSubmit form
  // it will submit a whole form & we will store in an object since there will be more than 1 kind of type
  login(): void {
    // log the values we recieve from the form
    console.log(this.model);

    // call login method from service & subscribe to an observable
    this.valueService.login(this.model).subscribe({
      next: res => {
        console.log(res);
        this.model = res;
        // this.loggedIn = true; //using async pipe
      },
      error: err => console.log(err)
    });
    // clears the form fields when submit is fired
    this.model = '';
  }

  logout() {
    // call logout from service
    this.valueService.logout();
    // this.loggedIn = false; // using async pipe
  }


  getCurrentUser() {
    // we interrogate valueService & see inside the current user observable
    // we subscribe to our created observable in value service & setting loggedin status to current user
    this.valueService.currentUser$.subscribe(user => {
      // double ! turns our object into a boolean type
      // if there is a user, then true, if user is null then false
      // this.loggedIn = !!user; //using async pipe
    }, error => console.log(error));
  }



}
