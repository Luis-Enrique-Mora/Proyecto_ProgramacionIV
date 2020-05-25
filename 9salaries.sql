--it creates the table salaries, if exists, drop it and re-do it again
Use SamaraOrganicsServer
Go
Drop table if Exists salaries
Go
CREATE TABLE salaries (
	salary_id integer Identity (1,1) Not null,
    employee_fk integer NOT NULL,
	hours_worked decimal(10,2),
	insurance_cost decimal(10,2),
	salary_amount decimal(10,2),
	money_account_fk integer not null,

    --Constraints
	--primary key
	Constraint PK_salaries Primary Key (salary_id),
	--foreign key
	Constraint FK_employee_salary Foreign Key (employee_fk) References user_employee (employee_id)
)
--this method was created to implement faster searches by id 
Create Clustered Index salaries_idx
On salaries(salary_id)
Go