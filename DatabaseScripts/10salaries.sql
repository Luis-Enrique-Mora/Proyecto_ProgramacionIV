--it creates the table salaries, if exists, drop it and re-do it again
Use SamaraOrganicsServer
Go
Drop table if Exists salaries
Go
CREATE TABLE salaries (
	salary_id int Identity (1,1) Not null,
    employee_fk int NOT NULL,
	hours_worked decimal(10,2),
	insurance_cost decimal(10,2),
	salary_amount decimal(10,2),
	money_account_fk int not null,

    --Constraints
	--primary key
	Constraint PK_salaries Primary Key clustered(salary_id),
	--foreign key
	Constraint FK_employee_salary Foreign Key (employee_fk) References employee (employee_id) On delete no Action
)
Go