import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  @Output() signedIn = new EventEmitter();

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  login(){
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in succesfully');
    }, error => {
      console.log('failed to login');
    });
  }

  loggedIn(){
    const token = localStorage.getItem('token');
    this.signedIn.emit(!!token);
    return !!token;
  }

  logout(){
    localStorage.removeItem('token');
    console.log('logged out');
  }

}
