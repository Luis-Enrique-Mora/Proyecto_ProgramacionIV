--it creates the table invoices, if exists, drop it and re-do it again
Use SamaraOrganicsServer
Go
Drop table if Exists invoices
Go
CREATE TABLE invoices (
    invoice_id integer Identity (1,1) NOT NULL,
    vendor_fk integer NOT NULL,
    invoice_date date NOT NULL,
    invoice_number varchar(20) NOT NULL,
    invoice_description varchar(250),
    amount Decimal(10,2) NOT NULL,
	status_fk integer NOT NULL,
	money_account_fk integer not null,
    final_payment Decimal(10,2) Default 0 NOT NULL,
    movements_category_fk integer NOT NULL,

	--Constraints
	--primary key
	Constraint PK_invoices Primary Key (invoice_id),
	--Foreign keys
    Constraint FK_vendor Foreign Key (vendor_fk) References vendors(vendor_id),
	Constraint FK_status Foreign Key (status_fk) References invoice_status(status_id),
	Constraint FK_money_account Foreign Key (money_account_fk) money_accounts(money_account_id)
)
--this method was created to implement faster searches by id 
Create Clustered Index invoice_idx
On invoices(invoice_id)
Go