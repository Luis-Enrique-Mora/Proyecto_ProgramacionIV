
export interface Invoice {
    invoiceId: number;
    invoiceNumber: string;
    invoiceDate: Date;
    vendorName: string;
    invoiceAmount: number;
    categoryName: string;
    statusName: string;
    nameMoneyAccount: string;
}
