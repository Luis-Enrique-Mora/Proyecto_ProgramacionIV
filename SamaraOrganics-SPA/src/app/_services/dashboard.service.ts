import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Accounts } from '../_models/Accounts';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token')
  })
};
@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  GetAccounts(){
    return this.http.get<Accounts[]>(this.baseUrl + 'moneyaccounts/index', httpOptions);
  }
}
