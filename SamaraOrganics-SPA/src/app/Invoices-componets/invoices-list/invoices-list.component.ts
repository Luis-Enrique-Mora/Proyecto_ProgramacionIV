import { Component, OnInit } from '@angular/core';
import { InvoicesService } from '../../_services/invoices.service';
import { Invoice } from '../../_models/invoice';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  selector: 'app-invoices-list',
  templateUrl: './invoices-list.component.html',
  styleUrls: ['./invoices-list.component.css']
})
export class InvoicesListComponent implements OnInit {

  constructor(private invoiceService: InvoicesService, private alertify: AlertifyService) { }
  invoiceList: Invoice[];
  ngOnInit() {
    this.loadInvoices();
  }

  loadInvoices(){
    this.invoiceService.GetInvoices().subscribe((invoiceList: Invoice[]) => {
      this.invoiceList = invoiceList;
    }, error => {
      this.alertify.error(error);
    });
  }

}
