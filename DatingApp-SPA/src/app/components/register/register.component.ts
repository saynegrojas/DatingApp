import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_service/account.service';
import { ValueService } from 'src/app/_service/value.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // parent to child
  @Input() usersFromHome;

  // child to parent
  @Output() cancelRegister = new EventEmitter();

  model: any = {};

  constructor(private accountService: AccountService, private toastr: ToastrService ) { }

  ngOnInit(): void {
  }

  // register a user
  register() {
    // call the register method from service
    this.accountService.register(this.model).subscribe(data => {
      console.log(data);
      // use conditional to hide & show component
      this.cancel();
    }, error => {
      console.log(error);
      this.toastr.error(error.error);
    });
  }

  // method will go back to previous page
  cancel() {
    this.cancelRegister.emit(false);
  }

}
