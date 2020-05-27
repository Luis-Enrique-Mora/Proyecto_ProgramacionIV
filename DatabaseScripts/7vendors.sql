--it creates the table vendors, if exists, drop it and re-do it again
Use SamaraOrganicsServer
Go
Drop table if Exists vendors
Go
CREATE TABLE vendors (
    vendor_id int Identity (1,1) NOT NULL,
    vendor_name varchar(25) NOT NULL,
    person_fk int NOT NULL,
    company_name varchar(45) NOT NULL,
	--Constraints
	--primary key
	Constraint PK_vendors Primary Key clustered(vendor_id),
	--Foreign keys
	Constraint FK_person_vendor Foreign Key (person_fk) References persons(id_person) On Delete No Action

)

Go