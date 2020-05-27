Use SamaraOrganicsServer
Go
Drop table if Exists money_accounts
Create table money_accounts
(
	money_account_id int Identity(1,1),
	name_money_account varchar(15),
	description_money_account varchar(100),
	global_amount decimal(15,2),
	--constraints
	--PK
	Constraint PK_money_account Primary Key clustered (money_account_id)
)
Go

--histories
Use SamaraOrganicsServer 
Go
Drop table if Exists money_accounts_history
Go
create table money_accounts_history
(
	history_id int Identity(1,1) not null,
	account_fk int not null,
	history_description varchar(200) not null,
	income_outcome decimal(12,2) not null,
	actual_amount decimal(12,2),
	--constraints
	--PK
	Constraint PK_money_accounts_history Primary Key (history_id),
	--FK
	Constraint FK_accounts_history Foreign Key (account_fk) references money_accounts(money_account_id) On Delete No Action
)
Go

