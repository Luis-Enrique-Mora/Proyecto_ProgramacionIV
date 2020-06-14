import { AccountsDto } from './AccountsDto';
import { VendorsDto } from './VendorsDto';
import { CategoryDto } from './CategoryDto';
import { StatusDto } from './StatusDto';

export interface CreateInvoiceVM {
    VendorsList: VendorsDto[];
    CategoryList: CategoryDto[];
    StatusList: StatusDto[];
    AccountsList: AccountsDto[];
}

