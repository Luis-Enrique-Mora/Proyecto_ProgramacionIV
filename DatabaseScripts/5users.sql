--it creates the table users, if exists, drop it and re-do it again
Use SamaraOrganicsServer
Go

Drop table if Exists user_role
Create table user_role
(
	user_role_id int Identity(1,1) not null,
	role_name varchar(50) not null,
	role_description varchar(200),
	--Constraint 
	--PK
	Constraint PK_user_role Primary Key clustered(user_role_id)
)
Go

Drop table if Exists users
Go
Create Table users (
    id_user int Identity (1,1) NOT NULL,
    person_fk int NOT NULL,
    password_hash varbinary(max) NOT NULL,
	password_salt varbinary(max) not null,
    user_role_fk int NOT NULL,
    --Constraints
	--primary key
	Constraint PK_users Primary key clustered(id_user),
	--Foreign key
	Constraint FK_person_user Foreign Key(person_fk) References persons(id_person) On Update cascade,
	Constraint FK_user_role Foreign key(user_role_fk) References user_role(user_role_id) On UPDATE CASCADE
)
Go