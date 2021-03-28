import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from 'src/app/_model/user';
import { AccountService } from 'src/app/_service/account.service';

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
  // inject router to get navigation properties
  // inject toastr to get access for notification
  constructor(private accountService: AccountService, private router: Router, private toastr: ToastrService ) { }

  ngOnInit(): void {
    // get current user when this component loads
    this.getCurrentUser();

    // we set the currentuser$ observable to the currentUser value we get from accountService
    this.currentUser$ = this.accountService.currentUser$;
  }

  // use this method to get value from ngSubmit form
  // it will submit a whole form & we will store in an object since there will be more than 1 kind of type
  login(): void {
    // log the values we recieve from the form
    console.log(this.model);

    // call login method from service & subscribe to an observable
    this.accountService.login(this.model).subscribe({
      next: res => {
        // redirect user when they log in to a path we specify
        this.router.navigateByUrl('/members');
        console.log(res);
        this.model = res;
        // this.loggedIn = true; //using async pipe
      },
      error: err => {
        console.log(err);
        this.toastr.error(err.error);
      }
    });
    // clears the form fields when submit is fired
    this.model = '';
  }

  logout() {
    // call logout from service
    this.accountService.logout();
    // this.loggedIn = false; // using async pipe

    // redirect user when they log out to home page
    this.router.navigateByUrl('/');
  }


  getCurrentUser() {
    // we interrogate valueService & see inside the current user observable
    // we subscribe to our created observable in value service & setting loggedin status to current user
    this.accountService.currentUser$.subscribe(user => {
      console.log(user);
      // double ! turns our object into a boolean type
      // if there is a user, then true, if user is null then false
      // this.loggedIn = !!user; //using async pipe
    }, error => console.log(error));
  }



}
