
--create function fnTotalCostOfBill
--(@IDBill int )
--returns money
--begin
--return

select sum(pd.SellingPrice * Number) 
from Products pd 
where  pd.ProductID 
	in (select ProductID from Forms_Produces where FormID =5) 

select * from Forms_Produces
select * from Products


go
create function fnPriceOfProduct (@IdProduct int)
returns money
begin
return (select SellingPrice from Products where ProductID=@IdProduct)
end;

print dbo.fnPriceOfProduct(2)


go
create function fnTotalCostOfBill (@IdBill int)
returns money

begin
return (select sum(fp.Number * dbo.fnPriceOfProduct(fp.ProductID))
		from Forms_Produces fp
		where fp.FormID=@IdBill)
end;

print dbo.fnTotalCostOfBill(5)
go

create proc spUpdateTotalCostofBill
@IDbill int
as
begin 
if(@IDbill is not null)
	update Bill 
	set Bill.TotalCost=dbo.fnTotalCostOfBill(@IDbill)
	where Bill.FormID=@IDbill 
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;

end;

go
declare @IDbill2 int;
exec spInsertForms @Type ='1',@CreatedDate='2019-10-10',@CreatedPersonID=1,@FormID=@IDbill2 output;

print @IDbill2

exec spUpdateTotalCostofBill @IDbill=@IDbill2
go


create Function fnDecreaseNumBer(@id int )
returns int 
begin
return 
(select Type 
from Forms
where FormID=@id
)
end;


go 
create function spupdateproduct(@id int)
returns int 
begin
return 
(select b.Number
from Forms_Produces b join Products a on b.ProductID=a.ProductID
where b.FormID in
(select FormID from Forms where FormID=11))
end;
go 

create Function fnTotalNumBer (@idf int  )
returns int 
begin
return 
(select  a.Number 
from  Forms_Produces a join Products b on a.ProductID=b.ProductID
where  a.FormID=@idf and (dbo.fnDecreaseNumBer(@idf)=0)

)
end;


create Function fnIDPR(@id int)
returns int
begin
return 
(select   ProductID
from Forms_Produces a join Forms b on a.FormID=b.FormID
where b.FormID=@id
)
end;

create  function fnket (@IdBill int)
returns int 
begin
return (select CustomerID
		from Bill
		where FormID=@IdBill)
end;
