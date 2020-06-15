import { Component, OnInit } from '@angular/core';
import { Accounts } from '../_models/Accounts';
import { DashboardService } from '../_services/dashboard.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  AccountList: Accounts[];
  constructor(private dasboardService: DashboardService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.getAccounts();
  }

  getAccounts(){
    this.dasboardService.GetAccounts().subscribe((AccountList: Accounts[]) => {
      this.AccountList = AccountList;
      console.log(this.AccountList);
    }, error => {
      this.alertify.error(error);
    });
  }

}
