import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Invoice } from '../_models/invoice';
import { CreateInvoiceVM } from '../_models/CreateInvoiceVM';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token')
  })
};
@Injectable({
  providedIn: 'root'
})
export class InvoicesService {

  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

  GetInvoices(): Observable<Invoice[]>{
    return this.http.get<Invoice[]>(this.baseUrl + 'invoices/index', httpOptions);
  }

  GetInvoice(id): Observable<Invoice>{
    return this.http.get<Invoice>(this.baseUrl + 'invoices/get/' + id, httpOptions);
  }

  GetCreateInfo(): Observable<CreateInvoiceVM>{
    return this.http.get<CreateInvoiceVM>(this.baseUrl + 'invoices/get/create', httpOptions);
  }
}
