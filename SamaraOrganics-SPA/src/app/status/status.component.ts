import { Component, OnInit } from '@angular/core';
import { StatusService } from '../_services/status.service';
import { AlertifyService } from '../_services/alertify.service';
import { StatusDto } from '../_models/StatusDto';

@Component({
  selector: 'app-status',
  templateUrl: './status.component.html',
  styleUrls: ['./status.component.css']
})
export class StatusComponent implements OnInit {

  statuslist: StatusDto[];
  constructor(private statusService: StatusService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.GetList();
  }

  GetList(){
    this.statusService.GetStatusList().subscribe((statuslist: StatusDto[]) => {
      this.statuslist = statuslist;
      console.log(this.statuslist);
    });
  }

}
