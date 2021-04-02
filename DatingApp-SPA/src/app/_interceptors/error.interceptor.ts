import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  // intercept the request that is going out or the response that goes back, with the next HTTP Handler

  // router - to navigate user to another page when they encounter an error
  // toastr - notify user when they encounter an error
  constructor(private router: Router, private toastr: ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    // returns an observable so use pipe to implement functionality (catchError)
    // use catchError to catch the error coming in & throw the error
    return next.handle(request).pipe(
      catchError(err => {
        // checking if we get an error first
        if (err) {
          // use switch statement depending on the error status
          switch (err.status) {
            case 400:
              // checking for first 400 error based on the error response
              if (err.error.errors) {
                const modelStateErrors = [];
                // loop through each key in the error's object
                for(const key in err.error.errors) {
                  if(err.error.errors[key]) {
                    // push each key to the modelStateErrors array
                    // this flattens the array of errors that we get back from our validation response
                    modelStateErrors.push(err.error.errors[key]);
                  }
                }
                // throw array with all the validaton response back to the component
                throw modelStateErrors.flat();
                // checking for the other 400 error
                // return statusText & status
              } else {
                this.toastr.error(err.statusText, err.status);
              }
              break;
              // unauthorized
              case 401:
                this.toastr.error(err.statusText, err.status);
                break;
              // not found redirect
              case 404:
                const navigationExtra: NavigationExtras = {state: {error: err.error}};
                this.router.navigateByUrl('/not-found', navigationExtra);
                break;
                // server, redirect & pass state to display the type of error
              case 500:
                const navigationExtras: NavigationExtras = {state: {error: err.error}};
                this.router.navigateByUrl('/server-error', navigationExtras);
                break;
              default:
                this.toastr.error('Oops! Something went wrong.');
          }
        }
        // should not get to this point but if we do throw the error
        return throwError(err);
      })
    );
  }
}
