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