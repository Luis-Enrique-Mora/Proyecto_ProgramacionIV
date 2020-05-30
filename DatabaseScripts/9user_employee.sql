--it creates the table user_employee, if exists, drop it and re-do it again
Use SamaraOrganicsServer
Go
Drop table if Exists employee
Go
CREATE TABLE employee (
    employee_id int Identity (1,1) NOT NULL,
    person_fk int NOT NULL,
    last_name2 varchar(12) NOT NULL,
    cedula varchar(12) NOT NULL,
    salary_per_hour numeric(8,2) NOT NULL,
    --Constraints
	--primary key
	Constraint PK_user_employee Primary Key clustered (employee_id),
	--foreign keys
	Constraint FK_person_employee Foreign Key (person_fk) References persons (id_person) On Delete No Action
)
Go