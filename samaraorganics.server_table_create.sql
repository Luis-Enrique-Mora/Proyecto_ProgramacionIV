





--it creates the transactions table, if exists, drop it and re-do it again
Use SamaraOrganicsServer
Go
Drop table if Exists transactions
Go
Create Table transactions(
	transaction_id integer Identity (1,1) not null,
	transaction_name Varchar(10) not null
	--Constraints
	--Primary key
	Constraint PK_transactions Primary Key(transaction_id)
)
--this method was created to implement faster searches by id 
Create Clustered Index transactions_idx
On transactions(transaction_id)
Go

--it creates the transaction_category table if exists drop it and re-do it again
Use SamaraOrganicsServer
Go
--a transaction_category category may be cash dollars, cash colones, safe dollars, safe colones, transfer, drawer dollars, drawer colones
Drop table if Exists transaction_category
Go
CREATE TABLE transaction_category (
    transaction_category_id integer Identity (1,1) NOT NULL,
    transaction_name varchar(25) NOT NULL,
	transaction_fk integer not null,
    transaction_description varchar(255) NOT NULL,
    --Constraints
	--primary key
	Constraint PK_transaction_category Primary Key (transaction_category_id),
	--foreign key
	Constraint FK_transaction_category Foreign Key(transaction_fk) References transactions(transaction_id)
)
--this method was created to implement faster searches by id 
Create Clustered Index transaction_category_idx
On transaction_category(transaction_category_id)
Go


--it creates the persons table, if exists, drop it and re-do it again
Use SamaraOrganicsServer
Go
Drop table if Exists persons
Go
CREATE TABLE persons (
    id_person integer Identity (1,1) NOT NULL,
    person_name varchar(25) NOT NULL,
    last_name varchar(25) NOT NULL,
    email varchar(100) unique,
    --Constraints
	--primary key
	Constraint PK_persons Primary Key(id_person)
)
--this method was created to implement faster searches by id 
Create Clustered Index persons_idx
On persons(id_person)
Go

--it creates the phones table, if exists, drop it and re-do it again
Use SamaraOrganicsServer
Go
Drop table if Exists phones
Go
CREATE TABLE phones (
    phone_id integer Identity (1,1) NOT NULL,
    phone_number varchar(50) NOT NULL,
    person_fk integer NOT NULL,
    --Constraints
	--primary key
	Constraint PK_phones Primary Key (phone_id),
	--foreign keys
	Constraint FK_person_phone Foreign Key (person_fk) References persons (id_person)
)
--this method was created to implement faster searches by id 
Create Clustered Index phones_idx
On phones(phone_id)
Go

--it creates the table users, if exists, drop it and re-do it again
Use SamaraOrganicsServer
Go
Drop table if Exists users
Go
CREATE TABLE users (
    id_user integer Identity (1,1) NOT NULL,
    person_fk integer NOT NULL,
    photo binary NOT NULL,
    password binary NOT NULL,
    role varchar(25) NOT NULL,
    --Constraints
	--primary key
	Constraint PK_users Primary key(id_user),
	--Foreign key
	Constraint FK_person_user Foreign Key(person_fk) References persons(id_person)
)
--this method was created to implement faster searches by id 
Create Clustered Index users_idx
On users(id_user)
Go

--it creates the table vendors, if exists, drop it and re-do it again
Use SamaraOrganicsServer
Go
Drop table if Exists vendors
Go
CREATE TABLE vendors (
    vendor_id integer Identity (1,1) NOT NULL,
    vendor_name varchar(25) NOT NULL,
    person_fk integer NOT NULL,
    company_name varchar(45) NOT NULL,
	--Constraints
	--primary key
	Constraint PK_vendors Primary Key (vendor_id),
	--Foreign keys
	Constraint FK_person_vendor Foreign Key (person_fk) References persons(id_person)

)
--this method was created to implement faster searches by id 
Create Clustered Index vendors_idx
On vendors(vendor_id)
Go

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
    final_payment Decimal(10,2) Default 0 NOT NULL,
    invoice_category_fk integer NOT NULL,
    transaction_category_fk integer NOT NULL,
    status_fk integer NOT NULL,

	--Constraints
	--primary key
	Constraint PK_invoices Primary Key (invoice_id),
	--Foreign keys
    Constraint FK_vendor Foreign Key (vendor_fk) References vendors(vendor_id),
	Constraint FK_invoice_category Foreign Key (invoice_category_fk) References invoice_category(invoice_category_id),
	Constraint FK_transaction_category Foreign Key (transaction_category_fk) References transaction_category(transaction_category_id),
	Constraint FK_status Foreign Key (status_fk) References invoice_status(status_id)
)
--this method was created to implement faster searches by id 
Create Clustered Index invoice_idx
On invoices(invoice_id)
Go

--it creates the table user_employee, if exists, drop it and re-do it again
Use SamaraOrganicsServer
Go
Drop table if Exists user_employee
Go
CREATE TABLE user_employee (
    employee_id integer Identity (1,1) NOT NULL,
    user_fk integer NOT NULL,
    last_name2 varchar(12) NOT NULL,
    cedula varchar(12) NOT NULL,
    salary_per_hour numeric(8,2) NOT NULL,
    --Constraints
	--primary key
	Constraint PK_user_employee Primary Key (employee_id),
	--foreign keys
	Constraint FK_user_employee Foreign Key (user_fk) References users (id_user)
)
--this method was created to implement faster searches by id 
Create Clustered Index user_employee_idx
On user_employee(employee_id)
Go

--it creates the table salaries, if exists, drop it and re-do it again
Use SamaraOrganicsServer
Go
Drop table if Exists salaries
Go
CREATE TABLE salaries (
	salary_id integer Identity (1,1) Not null,
    employee_id integer NOT NULL,
    last_name2 varchar(12) NOT NULL,
    --Constraints
	--primary key
	Constraint PK_salaries Primary Key (salary_id),
	--foreign key
	Constraint FK_user_salary Foreign Key (user_fk) References users (id_user)
)
--this method was created to implement faster searches by id 
Create Clustered Index salaries_idx
On salaries(salary_id)
Go