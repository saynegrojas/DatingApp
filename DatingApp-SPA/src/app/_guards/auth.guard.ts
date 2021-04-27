import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../_service/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private accountService: AccountService, private toastr: ToastrService) {}
  // needs to return an observable boolean type not a regular boolean
  canActivate(): Observable<boolean> {
    // don't need to subscribe, since guard automatically subs to an observable
    return this.accountService.currentUser$.pipe(map(data => {
      // if there is data that is an observable return a observable of boolean type(not regular boolean)
        // tslint:disable-next-line:curly
        if (data) return true;
          // will now be an observable boolean
        this.toastr.error('Unauthorized');
      })
    );
  }

}
