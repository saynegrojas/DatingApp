import { Component, OnInit } from '@angular/core';
import { TestErrorsService } from 'src/app/_service/test-errors.service';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})

// test global error handling endpoints
export class TestErrorsComponent implements OnInit {

  // inject error service
  constructor(private testErrorService: TestErrorsService) { }

  // for validation array
  validationErrors: string[] = [];
  ngOnInit(): void {
  }

  // methods to call & sub to an observable
  get404Error() {
    this.testErrorService.get404Error().subscribe(data => {
      console.log(data);
    }, error => console.log(error));
  }

  get400Error() {
    this.testErrorService.get400Error().subscribe(data => {
      console.log(data);
    }, error => console.log(error));
  }
  get500Error() {
    this.testErrorService.get500Error().subscribe(data => {
      console.log(data);
    }, error => console.log(error));
  }
  get401Error() {
    this.testErrorService.get401Error().subscribe(data => {
      console.log(data);
    }, error => console.log(error));
  }
  get400ValidationError() {
    this.testErrorService.get400ValidationError().subscribe(data => {
      console.log(data);
    }, error => {
      // set error we get back to string array
      console.log(error);
      this.validationErrors = error;
    });
  }
}
