
import {Routes} from '@angular/router';
import { InvoicesListComponent } from './Invoices-componets/invoices-list/invoices-list.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './_guards/auth.guard';
import { CreateInvoiceComponent } from './Invoices-componets/create-invoice/create-invoice.component';


export const appRoutes: Routes = [
    {path: 'login', component: LoginComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'dashboard', component: DashboardComponent},
            {path: 'invoices', component: InvoicesListComponent},
            {path: 'invoices/create', component: CreateInvoiceComponent},
            {path: '**', redirectTo: 'dashboard', pathMatch: 'full'}
        ]
    }

];
