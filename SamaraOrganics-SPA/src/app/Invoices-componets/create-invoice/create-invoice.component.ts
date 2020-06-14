import { Component, OnInit } from '@angular/core';
import { InvoicesService } from 'src/app/_services/invoices.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { CreateInvoiceVM } from 'src/app/_models/CreateInvoiceVM';

@Component({
  selector: 'app-create-invoice',
  templateUrl: './create-invoice.component.html',
  styleUrls: ['./create-invoice.component.css']
})
export class CreateInvoiceComponent implements OnInit {

  constructor(private invoiceService: InvoicesService, private alertify: AlertifyService) { }
  InvoiceDtos: CreateInvoiceVM;
  ngOnInit() {
  }

  loadInvoiceParameters(){
    this.invoiceService.GetCreateInfo().subscribe((InvoiceDtos: CreateInvoiceVM) => {
      this.InvoiceDtos = InvoiceDtos;
    }, error => {
      this.alertify.error(error);
    });
  }

}
