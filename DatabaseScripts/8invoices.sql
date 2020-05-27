--it creates the table invoices, if exists, drop it and re-do it again
Use SamaraOrganicsServer
Go
Drop table if Exists invoices
Go
CREATE TABLE invoices (
    invoice_id int Identity (1,1) NOT NULL,
    vendor_fk int NOT NULL,
    invoice_date date NOT NULL,
    invoice_number varchar(20) NOT NULL,
	invoice_category_fk int not null,
    invoice_description varchar(250),
    invoice_amount Decimal(10,2) NOT NULL,
	status_fk int NOT NULL,
	money_account_fk int not null,
    final_payment Decimal(10,2) Default 0,

	--Constraints
	--primary key
	Constraint PK_invoices Primary Key clustered (invoice_id),
	--Foreign keys
    Constraint FK_vendor Foreign Key (vendor_fk) References vendors(vendor_id) On Delete No Action,
	Constraint FK_status Foreign Key (status_fk) References invoice_status(status_id) On Delete No Action,
	Constraint FK_money_account Foreign Key (money_account_fk) References money_accounts(money_account_id) On Delete No Action,
	Constraint FK_invoice_category Foreign Key(invoice_category_fk) References invoice_category(invoice_category_id)
)
Go