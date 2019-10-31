SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tạo form -> tạo bill -> thêm sản phẩm, ghi xuống Form-Bill

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'spInsertBothFormAndBill'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE [dbo].[spInsertBothFormAndBill]
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE [dbo].[spInsertBothFormAndBill]
-- FormNeed
@TypeForm char(3) = 1,
@CreatedDate datetime ,
@CreatedPersion int = 0,

--Bill Need

@TotalCost	money =NULL,	
@DiscountPercent int =0,
@CustomerID	int	=NULL

as 
begin
    --tạo form
    DECLARE @FormID int;
 	EXECUTE @FormID = dbo.spInsertForms @TypeForm,@CreatedDate,@CreatedPersion;

    --tạo bill
    insert Bill
    values (@FormID, @TotalCost,@DiscountPercent,@CustomerID);

    RETURN @FormID
end
GO

--Tạo proc thêm bill detal vào bảng Form-produce
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'addBillDetail'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.addBillDetail
go
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.addBillDetail 
@FormID int,
@ProductId INT,
@Number INT
AS
BEGIN
    -- Insert rows into table 'TableName' in schema '[dbo]'
    INSERT INTO [dbo].[Forms_Produces]
    ( -- Columns to insert data into
     [FormID], [ProductID], [Number]
    )
    VALUES
    ( -- First row: values for the columns in the list above
     @FormID, @ProductId, @Number
    -- Add more rows here
    )
    EXECUTE dbo.fnTotalCostOfBill @FormID
END
go


 IF OBJECT_ID('Form_ProDuces_INSERT_UPDATE') IS NOT NULL
 DROP TRIGGER Form_ProDuces_INSERT_UPDATE;
GO

CREATE TRIGGER Form_ProDuces_INSERT_UPDATE
ON Forms_Produces
AFTER INSERT,UPDATE
AS
    DECLARE @FormID int
    set @FormID = (select FormID  from inserted) 
 EXECUTE dbo.spUpdateTotalCostofBill @FormID
go


DECLARE @formId int

  EXECUTE @formId = spInsertBothFormAndBill 1,'2019-03-10 00:00:00.000',1,null,null,null

  execute dbo.addBillDetail @formId,1,10;
  execute dbo.addBillDetail 15,1,10;

DECLARE @tien money
 execute @tien= dbo.spUpdateTotalCostofBill 14
 print @tien

--Get cái idform vừa tạo
-- DECLARE @formId int,
 -- @formId =  SELECT  TOP 1 Bill.FormID FROM Bill  
  --  ORDER BY Bill.FormID DESC;  
    -- body of the stored procedure