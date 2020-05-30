
Use SamaraOrganicsServer
Go
Drop table if exists schedule
create table schedule
(
	schedule_id int Identity(1,1),
	schedule_name varchar(12),
	--Constraints
	--PK
	Constraint PK_schedule Primary Key clustered(schedule_id)
)
Go
Drop table if Exists close_register
create table close_register
(
	close_register_id int Identity(1,1),
	close_register_date date not null,
	schedule_fk int not null,
	user_fk int not null,
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
	Constraint FK_user_close_register Foreign Key(user_fk) references employee(employee_id) On Delete No Action,
	Constraint FK_schedule Foreign Key(schedule_fk) references schedule(schedule_id) On Delete No Action on Update no action
)
Go

use SamaraOrganicsServer
Go
Drop table if exists close_register_invoices
Go
create table close_register_invoices
(
	close_register_invoices_id int Identity(1,1),
	close_register_fk int not null,
	invoice_fk int not null,
	--constraints 
	--PK
	Constraint PK_close_register_invoices Primary Key(close_register_invoices_id),
	--FK
	Constraint FK_close_register_invoices Foreign Key(invoice_fk) references invoices(invoice_id) On Delete No Action,
	Constraint FK_close_register Foreign Key (close_register_fk) references close_register(close_register_id) On Delete No Action
)
Go

use SamaraOrganicsServer
Go
Drop table if Exists paid_in
create table paid_in
(
	paid_in_id int Identity(1,1),
	paid_in_date date not null,
	paid_in_description varchar(200) not null,
	paid_in_amount decimal(12,2) not null,
	money_account_fk int not null,
	--Constraints
	--PK
	Constraint PK_paid_in Primary Key (paid_in_id),
	--FK
	Constraint FK_paid_in_money_account Foreign Key(money_account_fk) References money_accounts(money_account_id) On Delete No Action
)
Go

use SamaraOrganicsServer
Go
Drop table if Exists paid_in_close_register
Go
create table paid_in_close_register
(
	paid_in_close_register_id int Identity(1,1),
	close_register_fk int not null,
	paid_in_fk int not null,
	--Constraints
	--PK
	Constraint PK_paid_in_close_register Primary Key (paid_in_close_register_id),
	--FK
	Constraint FK_paid_in_money_account_close_register Foreign Key(close_register_fk) References close_register(close_register_id) On Delete No Action,
	Constraint FK_paid_in_close_register Foreign Key(paid_in_fk) References paid_in(paid_in_id) On Delete No Action
)
Go