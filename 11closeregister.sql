
Use SamaraOrganicsServer

Drop table if Exists close_register

create table close_register
(
	close_register_id int Identity(1,1),
	user_employee_fk int not null,
	system_amount decimal(12,2),
	amount_counted decimal(12,2),
	credit_card_vend decimal(12,2),
	cash_diffrence decimal(12,2),
	credit_card_machine decimal(12,2),
	cc_diference decimal(12,2),
	paidout_amount decimal(12,2),
	paidin_amount decimal(12,2)
	--Constraints
	--PK
	Constraint PK_close_register Primary Key(close_register_id),
	--FK
	Constraint FK_user_close_register Foreign Key(user_employee_fk) references user_employee(employee_id)

)
--this method was created to implement faster searches by id 
Create Clustered Index close_register_idx
On close_register(close_register_id)
Go

use SamaraOrganicsServer
Go

Drop table if exists close_register_invoices
Go

create table close_register_invoices
(
	close_register_invoices_id int Identity(1,1),
	close_register_fk integer not null,
	invoice_fk int not null,
	--constraints 
	--PK
	Constraint PK_close_register_invoices Primary Key(close_register_invoices_id),
	Constraint FK_close_register_invoices Foreign Key(invoice_fk) references invoices(invoice_id),
	Constraint FK_close_register Foreign Key (close_register_fk) references close_register(close_register_id)
)
Create Clustered Index close_register_invoices_idx
On close_register_invoices(close_register_fk)
Go