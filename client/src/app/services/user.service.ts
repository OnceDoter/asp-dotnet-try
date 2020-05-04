import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../environments/environment'
import { Observable } from 'rxjs';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private userPath = environment.apiUrl + 'users';
  constructor(private http: HttpClient) { }

  change(data): Observable<User> {
    return this.http.post<User>(this.userPath, data)
  }
  /*delete(data): Observable<User> {
  }*/
}
