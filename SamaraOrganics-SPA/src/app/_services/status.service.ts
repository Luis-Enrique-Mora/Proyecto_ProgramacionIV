import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { StatusDto } from '../_models/StatusDto';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class StatusService {

  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  GetStatusList(){
    return this.http.get<StatusDto[]>(this.baseUrl + 'invoicestatus/index', httpOptions);
  }

}
