import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
// import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Member } from '../_model/member';

// getting token from localstorage to set headers
// const httpOptions = {
//   headers: new HttpHeaders({
//     Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token
//   })
// };

@Injectable({
  providedIn: 'root'
})
export class MembersService {

  // bring in api url from env
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  // get all members
  getMembers() {

    // need headers for users endpoint protected by authentication (need token)
    return this.http.get<Member[]>(this.baseUrl + 'users');
  }

  // get member by username
  getMember(username: string) {
    return this.http.get<Member>(this.baseUrl + 'users/' + username);
  }
}
