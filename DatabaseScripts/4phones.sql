--it creates the phones table, if exists, drop it and re-do it again
Use SamaraOrganicsServer
Go
Drop table if Exists phones
Go
CREATE TABLE phones (
    phone_id int Identity (1,1) NOT NULL,
    phone_number varchar(50) NOT NULL,
    person_fk int  not NULL,
    --Constraints
	--primary key
	Constraint PK_phones Primary Key clustered (phone_id),
	--foreign keys
	Constraint FK_person_phone Foreign Key (person_fk) References persons (id_person) ON UPDATE CASCADE
)
Go