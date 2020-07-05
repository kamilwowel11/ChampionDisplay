import { Injectable } from '@angular/core';
import { JwtHelperService } from "@auth0/angular-jwt";
import { Credentials } from '../models/Credentials';
import { HttpClient } from '@angular/common/http';
import { map } from "rxjs/operators";
import { tokenGetter } from '../app.module';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private jwtHelper = new JwtHelperService();

  private url = 'http://localhost:5000/api/auth/login';
  public decodedToken: any;

  constructor(private http: HttpClient) { }

  login(credentials: Credentials) {
    //console.log("url: " +this.url);
    //console.log("credentials: " +credentials.login + " " + credentials.password);
    return this.http.post(this.url, credentials).pipe(
      map((response: any) => {
        const userData = response;
       // console.log("userData: " + userData.token);
        if (userData) {
          localStorage.setItem('token', userData.token);
          this.decodedToken = this.jwtHelper.decodeToken(userData.token);
          console.log(this.decodedToken);
        }
      })
    );
  }
  getToken()
  {
    let token = localStorage.getItem('token');
    return this.jwtHelper.decodeToken(token);
  }

  loggedIn(): boolean {
    const token = localStorage.getItem('token');
   // console.log("token: " +token);
    return !this.jwtHelper.isTokenExpired(token);
  }

  logout() {
    localStorage.removeItem('token');
  }

  isAdmin(): boolean {
    if (!this.loggedIn())
      return false;
    let decToken = this.getToken();
    if (decToken && decToken.role == "Admin") {
      return true;
    } else {
      return false;
    }
  }


}
