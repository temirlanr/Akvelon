use AdventureWorks2019;
go
drop index AK_Employee_LoginID on HumanResources.Employee;
go
create nonclustered index AK_Employee_LoginID on HumanResources.Employee (LoginID);