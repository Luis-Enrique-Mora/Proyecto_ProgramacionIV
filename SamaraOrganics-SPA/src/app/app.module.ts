import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { RouterModule } from '@angular/router';
import {appRoutes} from '../app/routes';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { LoginComponent } from './login/login.component';
import { AuthService } from './_services/auth.service';
import { SideBarComponent } from './side-bar/side-bar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CreateInvoiceComponent } from '../app/Invoices-componets/create-invoice/create-invoice.component';
import { DetailsInvoiceComponent } from '../app/Invoices-componets/details-invoice/details-invoice.component';
import { InvoicesListComponent } from '../app/Invoices-componets/invoices-list/invoices-list.component';
import { AdminComponent } from './admin/admin.component';
import { StatusComponent } from './status/status.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      LoginComponent,
      SideBarComponent,
      InvoicesListComponent,
      DashboardComponent,
      CreateInvoiceComponent,
      DetailsInvoiceComponent,
      AdminComponent,
      StatusComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BrowserAnimationsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      TooltipModule.forRoot(),
      BsDatepickerModule.forRoot()
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
