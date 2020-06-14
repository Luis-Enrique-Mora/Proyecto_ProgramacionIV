import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  @Output() signedIn = new EventEmitter();

  constructor(private authService: AuthService, private alertify: AlertifyService, private router: Router ) { }

  ngOnInit() {
  }

  login(){
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Logged in succesfully');
    }, error => {
      this.alertify.error('failed to login');
    }, () =>  {
      this.router.navigate(['/dashboard']);
    });
  }

  loggedIn(){
    return this.authService.loggedIn();
  }

  logout(){
    this.authService.logOut();
    this.alertify.message('logged out');
  }

}
