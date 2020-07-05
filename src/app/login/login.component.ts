import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AppRoutingModule } from '../app-routing/app-routing.module';
import { Credentials } from '../models/Credentials';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  credentials: Credentials

  constructor(private auth: AuthService, private snackbar: MatSnackBar,private route: Router) {
    this.credentials = {login:"", password: ""};
   }

  ngOnInit(): void {
    if (this.auth.loggedIn()) {
      this.route.navigate(['/champions']);
    }
  }
  submitForm(){
    console.log(this.credentials);
    this.auth.login(this.credentials).subscribe(next => {
      this.snackbar.open("Zalogowano", "ok", {
        duration:2000
      });
      this.route.navigate(["/champions"]);
    }, error => {
      this.snackbar.open("Nie udało się zalogować! (Złe hasło?)");
      console.log(error);
    });
  }

}
