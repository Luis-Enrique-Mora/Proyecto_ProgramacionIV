import { Component, OnInit} from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  LoggedIn: boolean;
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  loggedInMode(){
    return this.authService.loggedIn();
  }

  logout(){
    this.authService.logOut();
  }

}
