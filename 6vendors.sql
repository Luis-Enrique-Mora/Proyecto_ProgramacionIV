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