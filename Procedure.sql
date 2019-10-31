
create proc spGetBill
as
begin 
Select * from Bill
end;
go

create proc spGetBrands
as
begin 
Select * from Brands
end;
go

create proc spGetCustomers
as
begin 
Select * from Customers
end;
go 

create proc spGetEmployees
as
begin 
Select * from Employees
end;
go


create proc spGetForms
as
begin 
Select * from Forms
end;
go 

create proc spGetForm_Products
as
begin 
Select * from Forms_Produces
end;
go

create proc spGetGroupPurpose
as
begin 
Select * from GroupPurpose
end;
go 

create proc spGetProducts
as
begin 
Select * from Products
end;
go

create proc spGetPurpose
as
begin 
Select * from Purpose
end;
go

exec spGetBill