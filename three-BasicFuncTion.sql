
--create function fnTotalCostOfBill
--(@IDBill int )
--returns money
--begin
--return

use Cosmetic_SM
GO


-- 1/ fnPriceOfProduct(int idproduct) tìm giá của sản phẩm theo idProduc
IF OBJECT_ID('fnPriceOfProduct') IS NOT NULL
 DROP FUNCTION fnPriceOfProduct;
 GO

create function fnPriceOfProduct (@IdProduct int)
returns money
begin
return (select SellingPrice from Products where ProductID=@IdProduct)
end
GO

PRINT dbo.fnPriceOfProduct(2) -- đã test xong
go

--2/ fnTotalCostOfBill(int idbill) -- Tính tổng tiền của bill theo IDbill

IF OBJECT_ID('fnTotalCostOfBill') IS NOT NULL
 DROP FUNCTION fnTotalCostOfBill;
 GO

create function fnTotalCostOfBill (@IdBill int)
returns money
begin
return (select sum(fp.Number * dbo.fnPriceOfProduct(fp.ProductID))
		from Forms_Produces fp
		where fp.FormID=@IdBill)
end
GO

-- test với bill có id = 2: tính tổng tiền đc là 19 triệu
print dbo.fnTotalCostOfBill(2)
go

--3 / spUpdateTotalCostofBill(int idbill) update cột TotalCost của bảng bill
IF OBJECT_ID('spUpdateTotalCostofBill') IS NOT NULL
DROP PROC spUpdateTotalCostofBill;
GO

create proc spUpdateTotalCostofBill (@IDbill int)
as
begin 
if(@IDbill is not null)
	update Bill 
	set Bill.TotalCost=dbo.fnTotalCostOfBill(@IDbill)
	where Bill.FormID=@IDbill 
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end
GO
--kiểm tra:
