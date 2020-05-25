--it creates the invoice_status table if exists drop it and re-do it again
Use SamaraOrganicsServer
Go
Drop table if Exists invoice_status
Go
--the status could be pending or paid
CREATE TABLE invoice_status (
    status_id integer Identity (1,1) NOT NULL,
    status_name varchar(25) NOT NULL,
    status_description varchar(200),
    --Constraints
	--primary key
	Constraint PK_invoice_status Primary Key (status_id)
)
--this method was created to implement faster searches by id 
Create Clustered Index invoice_status_idx
On invoice_status(status_id)
Go