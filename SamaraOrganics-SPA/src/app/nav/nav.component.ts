import { Component, OnInit} from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  LoggedIn: boolean;
  constructor(public authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  loggedInMode(){
    return this.authService.loggedIn();
  }

  logout(){
    this.authService.logOut();
    this.router.navigate(['/login']);
  }

}
