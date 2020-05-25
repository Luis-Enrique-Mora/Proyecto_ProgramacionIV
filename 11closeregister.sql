
Use SamaraOrganicsServer
Go
Drop table if exists schedule
create table schedule
(
	schedule_id int Identity(1,1),
	schedule_name varchar(12),
	--Constraints
	--PK
	Constraint PK_schedule Primary Key(schedule_id)
)
Go
Drop table if Exists close_register
create table close_register
(
	close_register_id int Identity(1,1),
	close_register_date date not null,
	schedule_fk int not null,
	user_employee_fk int not null,
	system_amount decimal(12,2) not null,
	amount_counted decimal(12,2) not null,
	cash_diffrence decimal(12,2),
	credit_card_system decimal(12,2),
	credit_card_machine decimal(12,2),
	cc_diference decimal(12,2),
	paidout_amount decimal(12,2) default 0,
	paidin_amount decimal(12,2) default 0,
	--Constraints
	--PK
	Constraint PK_close_register Primary Key(close_register_id),
	--FK
	Constraint FK_user_close_register Foreign Key(user_employee_fk) references user_employee(employee_id),
	Constraint FK_schedule Foreign Key(schedule_fk) references schedule(schedule_id)
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