use Cosmetic_SM
go

-- create proc GroupPurposes
if OBJECT_ID('spInsertGroupPurpose') is not null
drop proc spInsertGroupPurpose;
go

create proc spInsertGroupPurpose
	--@GroupPurposeID	int	=null,
	@GroupPurposeName	nvarchar(1000)	
as
begin
insert GroupPurpose
values (@GroupPurposeName);
end

exec spInsertGroupPurpose @GroupPurposeName='afhfd';
-- create proc Purpose
if OBJECT_ID('spInsertPurpose') is not null
drop proc spInsertPurpose;
go

create proc spInsertPurpose

@PurposeName	nvarchar(1000)	,
@GroupPurposeID	int	
as 
begin
if exists (select GroupPurposeID from GroupPurpose where GroupPurposeID = @GroupPurposeID)

insert Purpose
values (@PurposeName, @GroupPurposeID);
else 
THROW 50001, 'Ma GroupPurpose khong ton tai.', 1;
end

exec spInsertPurpose 
@PurposeName= 'hsg',
@GroupPurposeID =5

--create proc Employess
if OBJECT_ID('spInsertEmployees') is not null
drop proc spInsertEmployees;
go

create proc spInsertEmployees
	
@EmployeeName	nvarchar(100)	,
@PhoneNumber	varchar(15)	,
@BirthDay	nvarchar(50)	
	
as
begin
insert Employees
values (@EmployeeName,@PhoneNumber,@BirthDay);
end	
--create Customers
if OBJECT_ID('spInsertCustomers') is not null
drop proc spInsertCustomers;
go

create proc spInsertCustomers
	

@CustomerName	nvarchar(100),
@PhoneNumber	varchar(15)	,
@Birthday	nvarchar(50)
		
as
begin
insert Customers
values (@CustomerName,@PhoneNumber,@BirthDay);
end	

--create Brands
if OBJECT_ID('spInsertBrands') is not null
drop proc spInsertBrands;
go

create proc spInsertBrands
@BrandName	nvarchar(1000)	,
@Description	ntext	
as
begin
insert Brands
values (@BrandName,@Description);
end	
	
if OBJECT_ID('spInsertForms') is not null
drop proc spInsertForms;
go

create proc spInsertForms

@Type	char(3)	,
@CreatedDate	datetime,	
@CreatedPersonID	int	,
@FormID int output
as
begin
insert Forms
values (@Type,@CreatedDate,@CreatedPersonID);
end	

--create proc BIll
if OBJECT_ID('spInsertBill') is not null
drop proc spInsertBill;
go

create proc spInsertBill

@FormID	bigint	,
@TotalCost	money,	
@DiscountPercent	int,	
@CustomerID	int	
		
as 
begin
if exists (select FormID from Forms where FormID = @FormID)
--gia tri mac dinh cua discountPercent , CID 
insert Bill
values (@FormID, @TotalCost,@DiscountPercent,@CustomerID);
else 
THROW 50001, 'Ma Form khong ton tai.', 1;
end
--chua kiem tra chay dung chuc nang k!
exec spInsertBill
@FormID=2,
@TotalCost=10,
@DiscountPercent=0,
@CustomerID=0

--create proc products
if OBJECT_ID('spInsertProduct') is not null
drop proc spInsertEmployees;
go

create proc spInsertProduct
@ProductName	nvarchar(1000)	,
@Unit	nvarchar(1000)	,
@SellingPrice	money	,
@BuyingPrice	money	,
@ShelvesID	char(3)	,
@PurposeID	int	,
@BrandID	int	,
@Number	int	,
@Description	ntext	
			
as
begin
if @SellingPrice >0 and @SellingPrice>@BuyingPrice and @BuyingPrice>0 and @Number>0 
and (exists (select PurposeID from Purpose where PurposeID = @PurposeID) )

insert Products
values (@ProductName,@Unit,@SellingPrice,@BuyingPrice,@ShelvesID,@PurposeID,@BrandID,@Number,@Description);
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;


--create proc Form_Products
--if OBJECT_ID('spInsertForms_Product') is not null
--drop proc spInsertForms_Product;
--go

--create proc spInsertForms_Product_Type1
	
--@FormID	bigint	,
--@ProductID	int,
--@Number	int	
--as
--begin
----typeform 0:nhap , 1:xuat
--if
--	@FormID  is  null or @ProductID is null or @Number is  null
--	throw 50001,'Ma Form ,ProductID , Number khong duoc phep null!!!.', 1;
--if
--(exists (select FormID from Forms where FormID = @FormID and Forms.Type=1) )
--and (exists (select ProductID from Products where ProductID=@ProductID))
--and  ((select Number from Products where ProductID=@ProductID )>@Number)
--and (@Number>0)

--insert Products
--values (@FormID,@ProductID,@Number);
----thuc hien ham tru san pham(update so luong san pham) 
--throw 50001,'Nhap ma Form ,ProductID hoac so luong khong dung!!!.', 1;
--end	