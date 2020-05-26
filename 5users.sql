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
	Constraint PK_user_role Primary Key(user_role_id)
)
Go

Drop table if Exists users
Go
CREATE TABLE users (
    id_user int Identity (1,1) NOT NULL,
    person_fk int NOT NULL,
    photo binary NOT NULL,
    password_hash binary NOT NULL,
	password_salt binary not null,
    user_role_fk int NOT NULL,
    --Constraints
	--primary key
	Constraint PK_users Primary key(id_user),
	--Foreign key
	Constraint FK_person_user Foreign Key(person_fk) References persons(id_person),
	Constraint FK_user_role Foreign key(user_role_fk) References user_role(user_role_id)
)
Go