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