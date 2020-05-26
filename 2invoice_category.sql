use SamaraOrganicsServer
Go
Drop table if Exists invoice_category
Go
create table invoice_category
(
	invoice_category_id int Identity(1,1) not null,
	category_name varchar(50) not null,
	category_description varchar(200),
	--Constraints
	--PK
	Constraint PK_invoice_category Primary Key (invoice_category_id)
)
Go
