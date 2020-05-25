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