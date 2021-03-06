﻿use [CaChepFinal3-HQT]
go
--1-Table LoaiPhong

--1.spGetLoaiPhong
IF OBJECT_ID(N'dbo.spGetLoaiPhong', N'P') IS NOT NULL DROP PROC dbo.spGetLoaiPhong;
GO
create proc spGetLoaiPhong
as
begin
    Select *
    from LoaiPhongs
end;
go
--2.spGetOneByIdLoaiPhong
IF OBJECT_ID(N'dbo.spGetOneByIdLoaiPhong', N'P') IS NOT NULL DROP PROC dbo.spGetOneByIdLoaiPhong;
GO
create proc spGetOneByIdLoaiPhong
    @id int
as
begin
    Select *
    from LoaiPhongs
    where Id=@id
end;

exec spGetLoaiPhong
go

--3.spAddLoaiPhong
IF OBJECT_ID(N'dbo.spAddLoaiPhong', N'P') IS NOT NULL DROP PROC dbo.spAddLoaiPhong;
GO
create proc spAddLoaiPhong
    @Ten	nvarchar(50)
as
begin
    insert LoaiPhongs
    values
        (@Ten)
end
go

--4.spEditLoaiPhong
IF OBJECT_ID(N'dbo.spEditLoaiPhong', N'P') IS NOT NULL DROP PROC dbo.spEditLoaiPhong;
GO
create proc spEditLoaiPhong
    @id int null,
    @Ten	nvarchar(50)
as
begin
    if(@id is not null)
	update LoaiPhongs 
	set LoaiPhongName=@Ten
	
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go
--5.spDeleteLoaiPhong
IF OBJECT_ID(N'dbo.spDeleteLoaiPhong', N'P') IS NOT NULL DROP PROC dbo.spDeleteLoaiPhong;
GO
create proc spDeleteLoaiPhong
    @id int null
as
begin
    if(@id is not null)
	delete LoaiPhongs 
	from LoaiPhongs
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go
--6. spGetNameLoaiPhongById
IF OBJECT_ID(N'dbo.spGetNameLoaiPhongById', N'P') IS NOT NULL DROP PROC dbo.spGetNameLoaiPhongById;
GO
create proc spGetNameLoaiPhongById
    @id int null
as
begin
    if @id is not null
	Select *
    from LoaiPhongs
    where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go

--2- Table LoaiDichVu
--1.spAddLoaiDichVu
IF OBJECT_ID(N'dbo.spAddLoaiDichVu', N'P') IS NOT NULL DROP PROC dbo.spAddLoaiDichVu;
GO
create proc spAddLoaiDichVu
    @Ten	nvarchar(50)	,
    @mota nvarchar(max)='notthing'
as
begin
    insert LoaiDichVus
    values
        (@Ten, @mota)
end
go
--2.spEditLoaiDichVu
IF OBJECT_ID(N'dbo.spEditLoaiDichVu', N'P') IS NOT NULL DROP PROC dbo.spEditLoaiDichVu;
GO
create proc spEditLoaiDichVu
    @id int null,
    @Ten	nvarchar(50),
    @mota nvarchar(max)

as
begin
    if(@id is not null)
	update LoaiDichVus 
	set LoaiDichVuName=@Ten,
	Description=@mota	
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go
--3.spDeleteLoaiDichVu
IF OBJECT_ID(N'dbo.spDeleteLoaiDichVu', N'P') IS NOT NULL DROP PROC dbo.spDeleteLoaiDichVu;
GO
create proc spDeleteLoaiDichVu
    @id int null
as
begin
    if(@id is not null)
	delete LoaiDichVus 
	from LoaiDichVus
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go
--4.spGetLoaiDichVu
IF OBJECT_ID(N'dbo.spGetLoaiDichVu', N'P') IS NOT NULL DROP PROC dbo.spGetLoaiDichVu;
GO
create proc spGetLoaiDichVu
as
begin
    Select *
    from LoaiDichVus
end;
go
--5.spGetOneByIdLoaiDichVu
IF OBJECT_ID(N'dbo.spGetOneByIdLoaiDichVu', N'P') IS NOT NULL DROP PROC dbo.spGetOneByIdLoaiDichVu;
GO
create proc spGetOneByIdLoaiDichVu
    @id int
as
begin
    Select *
    from LoaiDichVus
    where Id=@id
end;
go

--3 Table Chương trình
--1.spEditChuongTrinh
IF OBJECT_ID(N'dbo.spEditChuongTrinh', N'P') IS NOT NULL DROP PROC dbo.spEditChuongTrinh;
GO
create proc spEditChuongTrinh
    @id int null,
    @Ten	nvarchar(max),
    @Tile int,
    @Tang bit
as
begin
    if(@id is not null)
	update ChuongTrinhs 
	set 
	ChuongTrinhName=@Ten,
	TiLeThayDoiGia=@Tile,
	IsTang=@Tang
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go

--2.spAddChuongTrinh
IF OBJECT_ID(N'dbo.spAddChuongTrinh', N'P') IS NOT NULL DROP PROC dbo.spAddChuongTrinh;
GO
create proc spAddChuongTrinh
    @Name	nvarchar(max)	,
    @Tile int,
    @Tang bit
as
begin
    insert ChuongTrinhs
    values
        (@Name, @Tile, @Tang)
end	;
go

--3.spGetChuongTrinh
IF OBJECT_ID(N'dbo.spGetChuongTrinh', N'P') IS NOT NULL DROP PROC dbo.spGetChuongTrinh;
GO
create proc spGetChuongTrinh
as
begin
    Select *
    from ChuongTrinhs
end;
go

--4.spDeleteChuongTrinh
IF OBJECT_ID(N'dbo.spDeleteChuongTrinh', N'P') IS NOT NULL DROP PROC dbo.spDeleteChuongTrinh;
GO
create proc spDeleteChuongTrinh
    @id int null
as
begin
    if(@id is not null)
	delete ChuongTrinhs 
	from ChuongTrinhs
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go
--5-spGetOneByIdChuongTrinh
IF OBJECT_ID(N'dbo.spGetOneByIdChuongTrinh', N'P') IS NOT NULL DROP PROC dbo.spGetOneByIdChuongTrinh;
GO
create proc spGetOneByIdChuongTrinh
    @id int null
as
begin
    if @id is not null
	Select *
    from ChuongTrinhs
    where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go

--6: spGetNameChuongTrinhById
IF OBJECT_ID(N'dbo.spGetNameChuongTrinhById', N'P') IS NOT NULL DROP PROC dbo.spGetNameChuongTrinhById;
GO
create proc spGetNameChuongTrinhById
    @id int null
as
begin
    if @id is not null
	Select *
    from ChuongTrinhs
    where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go

---4 Table trạng thái
--1.spGetOneByIdTrangThai
IF OBJECT_ID(N'dbo.spGetOneByIdTrangThai', N'P') IS NOT NULL DROP PROC dbo.spGetOneByIdTrangThai;
GO
create proc spGetOneByIdTrangThai
    @id int
as
begin
    Select *
    from TrangThais
    where Id=@id
end;
go

--2.spAddTrangThai
IF OBJECT_ID(N'dbo.spAddTrangThai', N'P') IS NOT NULL DROP PROC dbo.spAddTrangThai;
GO
create proc spAddTrangThai
    @Name	nvarchar(max)
as
begin
    insert TrangThais
    values
        (@Name)
end	;
go

--3.spGetTrangThai
IF OBJECT_ID(N'dbo.spGetTrangThai', N'P') IS NOT NULL DROP PROC dbo.spGetTrangThai;
GO
create proc spGetTrangThai
as
begin
    Select *
    from TrangThais
end;
go

--4.spEditTrangThai
IF OBJECT_ID(N'dbo.spEditTrangThai', N'P') IS NOT NULL DROP PROC dbo.spEditTrangThai;
GO
create proc spEditTrangThai
    @id int null,
    @Ten	nvarchar(max)
as
begin
    if(@id is not null)
	update TrangThais 
	set 
	TrangThaiName=@Ten	
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go

--5. spDeleteTrangThai
IF OBJECT_ID(N'dbo.spDeleteTrangThai', N'P') IS NOT NULL DROP PROC dbo.spDeleteTrangThai;
GO
create proc spDeleteTrangThai
    @id int
as
begin
    if(@id is not null)
	delete TrangThais 
	from TrangThais
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go


--5 Table DichVu
--1.spGetOneByIdDichVu
IF OBJECT_ID(N'dbo.spGetOneByIdDichVu', N'P') IS NOT NULL DROP PROC dbo.spGetOneByIdDichVu;
GO
create proc spGetOneByIdDichVu
    @id int
as
begin
    Select a.Id, a.DichVuName, a.ShortDescription, a.Price, a.ImageUrl, a.InStock
, b.LoaiDichVuName
    from DichVus a join LoaiDichVus b
        on a.LoaiDvid=b.Id
    where a.Id=@id
end;
go
--2 EditDichVu
IF OBJECT_ID(N'dbo.spEditDichVu', N'P') IS NOT NULL DROP PROC dbo.spEditDichVu;
GO
create proc spEditDichVu
    @id int null,
    @Name	nvarchar(50),
    @Mota   nvarchar(500),
    @Price money,
    @hinh nvarchar(max),
    @InStock int,
    @LoaiDVuId int
as
begin
    if(@id is not null)
	update DichVus 
	set 
DichVuName=@Name,
ShortDescription= @mota,
Price=@Price,
ImageUrl =@hinh,
InStock= @InStock,
LoaiDvid=@LoaiDVuId
where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go
--3.spGetDichVu
IF OBJECT_ID(N'dbo.spGetDichVu', N'P') IS NOT NULL DROP PROC dbo.spGetDichVu;
GO
create proc spGetDichVu
as
begin
    Select a.Id, a.DichVuName, a.ShortDescription, a.Price, a.ImageUrl, a.InStock, a.LoaiDvid
, b.LoaiDichVuName
    from DichVus a join LoaiDichVus b
        on a.LoaiDvid=b.Id
end;
go

--6 Table Phong
--1.spEditPhong
IF OBJECT_ID(N'dbo.spEditPhong', N'P') IS NOT NULL DROP PROC dbo.spEditPhong;
GO
create proc spEditPhong
    @id int ,
    @Ten	nvarchar(50)	,
    @Mota nvarchar(max),
    @Price money,
    @LoaiphongId int,
    @ChuongtrinhId int,
    @HinhUrl nvarchar(max) = null
as
begin
    if(@id !=0 )
	update Phongs 
	set 
	PhongName=@Ten,	
	ShortDescription=@Mota,
	Price=@Price,
	LoaiPhongId=@LoaiphongId,
	ChuongTrinhId=@ChuongtrinhId,
	HinhUrl=@HinhUrl
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go

--2.spDeletePhong
IF OBJECT_ID(N'dbo.spDeletePhong', N'P') IS NOT NULL DROP PROC dbo.spDeletePhong;
GO
create proc spDeletePhong
    @id int =0
as
begin
    if(@id !=0)
	delete Phongs 
	from Phongs
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go

--3.spGetOneByIdPhong
IF OBJECT_ID(N'dbo.spGetOneByIdPhong', N'P') IS NOT NULL DROP PROC dbo.spGetOneByIdPhong;
GO
create proc spGetOneByIdPhong
    @id int
as
begin
    Select b.Id, b.PhongName, ShortDescription, Price, a.LoaiPhongName, c.ChuongTrinhName, b.ChuongTrinhId, b.LoaiPhongId, b.HinhUrl
    from LoaiPhongs a join Phongs b
        on a.Id=b.LoaiPhongId
        join ChuongTrinhs c
        on c.Id=b.ChuongTrinhId
    where b.Id=@id
end;
go
--4spGetPhong
IF OBJECT_ID(N'dbo.spGetPhong', N'P') IS NOT NULL DROP PROC dbo.spGetPhong;
GO
create proc spGetPhong
as
begin
    Select b.Id, b.PhongName, b.ShortDescription, b.Price, a.LoaiPhongName, b.ChuongTrinhId, c.ChuongTrinhName, b.LoaiPhongId, b.HinhUrl
    from LoaiPhongs a join Phongs b on a.Id=b.LoaiPhongId
        join ChuongTrinhs c on
c.Id=b.ChuongTrinhId
end;
exec spGetPhong
go
--5 spAddPhong
IF OBJECT_ID(N'dbo.spAddPhong', N'P') IS NOT NULL DROP PROC dbo.spAddPhong;
GO
create proc spAddPhong
    @Ten nvarchar(50),
    @Mota nvarchar(max),
    @Price money,
    @LoaiphongId int,
    @ChuongtrinhId int,
    @HinhUrl nvarchar(max) = null
as
begin
    insert Phongs
    values
        (@Ten, @Mota, @Price, @LoaiphongId, @ChuongtrinhId, @HinhUrl)
end;
go
--7 Table DatPhong
--1-SearchDatPhongsBySomthing
IF OBJECT_ID(N'dbo.SearchDatPhongsBySomthing', N'P') IS NOT NULL DROP PROC dbo.SearchDatPhongsBySomthing;
GO
CREATE PROC dbo.SearchDatPhongsBySomthing
    @Cmnd as NVARCHAR(255) = NULL,
    @Sdt as  NVARCHAR(255) = NULL,
    @ThoiGianNhanPhongDuKien as  date = NULL
AS
declare @date date = CONVERT(VARCHAR(10),@ThoiGianNhanPhongDuKien, 111);
DECLARE @sql AS NVARCHAR(1000);
SET @sql =N'SELECT *  FROM dbo.DatPhongs'
+ N' WHERE 1 = 1 '

+ CASE WHEN @Cmnd IS NOT NULL THEN
	N' AND Cmnd = @Cd' ELSE N'' END

+ CASE WHEN @Sdt IS NOT NULL THEN
	N' AND Sdt = @St' ELSE N'' END

+ CASE WHEN @ThoiGianNhanPhongDuKien IS NOT NULL THEN
	N' AND ThoiGianNhanPhongDuKien <= @Dt AND @Dt <= ThoiGianTraPhongDuKien ' ELSE N'' END;
EXEC sp_executesql
	@stmt = @sql,
	@params = N'@Cd AS NVARCHAR(255), @St AS NVARCHAR(255), @Dt AS DATE',
	@Cd = @Cmnd,
	@St = @Sdt,
	@Dt = @date;
go

EXEC dbo.SearchDatPhongsBySomthing @ThoiGianNhanPhongDuKien ='2019-12-04 00:00:00.0000000'
--2 Dynamic sort

IF OBJECT_ID(N'dbo.GetSortedDatPhongsBySomthing', N'P') 
IS NOT NULL DROP PROC dbo.GetSortedDatPhongsBySomthing;
GO
CREATE PROC GetSortedDatPhongsBySomthing
    @colname AS sysname,
    @TypeSort AS CHAR(1) = 'I'
AS
IF @colname NOT IN(N'TongTien', N'ThoiGianNhanPhongDuKien',N'ThoiGianTraPhongDuKien',N'TenNguoiDat')
 THROW 50001,'Column name not supported. Possibly a SQL injection attempt.', 1;

DECLARE @sql AS NVARCHAR(1000);
SET @sql = N'SELECT * FROM dbo.DatPhongs ORDER BY '
 + QUOTENAME(@colname) +
 CASE @TypeSort WHEN 'D' THEN N' DESC' ELSE '' END + ';';

EXEC sys.sp_executesql @stmt = @sql;
 GO

EXEC dbo.GetSortedDatPhongsBySomthing N'TenNguoiDat', N'I';

 GO

--3 GetOneDatPhongById
IF EXISTS (
 SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'GetOneDatPhongById'
    AND ROUTINE_TYPE = N'PROCEDURE'
 )
 DROP PROCEDURE dbo.GetOneDatPhongById
 GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.GetOneDatPhongById
    @Id  int  = 0
AS
SELECT *
FROM DatPhongs
WHERE Id=@Id
 GO
EXECUTE dbo.GetOneDatPhongById @Id=1
 GO


--8 Table ChiTietDatPhong
--1 GetChiTietDatPhong_ByIdDatPhong
IF EXISTS (
 SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'GetChiTietDatPhong_ByIdDatPhong'
    AND ROUTINE_TYPE = N'PROCEDURE'
 )
 DROP PROCEDURE dbo.GetChiTietDatPhong_ByIdDatPhong
 GO

CREATE PROCEDURE dbo.GetChiTietDatPhong_ByIdDatPhong
    @Id int  = 0
AS

SELECT *
FROM ChiTietDatPhongs
WHERE DatPhongId =@Id 
 GO

EXECUTE dbo.GetChiTietDatPhong_ByIdDatPhong 1
 GO

--9-Table ChiTietDichVu
--1-GetChiTietDichVuByIdPhong
IF EXISTS (
 SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'GetChiTietDichVuByIdPhong'
    AND ROUTINE_TYPE = N'PROCEDURE'
 )
 DROP PROCEDURE dbo.GetChiTietDichVuByIdPhong
 GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.GetChiTietDichVuByIdPhong
    @Id  int = 0
AS
SELECT a.DichVuId, a.DatPhongId, a.SoLuong, b.Price, b.DichVuName, TongTien= a.SoLuong*b.Price
from ChiTietDichVuDatPhongs a, DichVus b
WHERE a.DatPhongId= @Id
    and a.DichVuId=b.Id
 GO
EXECUTE dbo.GetChiTietDichVuByIdPhong 1 
 GO

--SomeThingElse
IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'GetOnePhongById'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.GetOnePhongById
GO
CREATE PROCEDURE dbo.GetOnePhongById
    @Id int =0
AS
SELECT *
from Phongs
where Id=@Id
GO
EXECUTE dbo.GetOnePhongById 1 
GO

IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'GetOneDichVuById'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.GetOneDichVuById
GO

CREATE PROCEDURE dbo.GetOneDichVuById
    @Id int =0
AS
SELECT *
from DichVus
where Id=@Id
GO
EXECUTE dbo.GetOneDichVuById 1 
GO

IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'GetOneTrangThaiById'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.GetOneTrangThaiById
GO

CREATE PROCEDURE dbo.GetOneTrangThaiById
    @Id  int = 0
AS
-- body of the stored procedure
SELECT *
FROM TrangThais
where Id=@Id
GO

EXECUTE dbo.GetOneTrangThaiById 1 
GO


--GetChiTietDatPhongBy_IdDatPhong_IdPhong_ThoiGian
IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'GetChiTietDatPhongBy_IdDatPhong_IdPhong_ThoiGian'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.GetChiTietDatPhongBy_IdDatPhong_IdPhong_ThoiGian
GO
CREATE PROCEDURE dbo.GetChiTietDatPhongBy_IdDatPhong_IdPhong_ThoiGian
    @DatPhongId  int = 0,
    @PhongId  int  = 0

AS

SELECT *
from ChiTietDatPhongs
where ChiTietDatPhongs.DatPhongId= @DatPhongId
    and PhongId = @PhongId
    and ThoiGian >=  (SELECT CAST(getdate() AS date))
GO

EXECUTE dbo.GetChiTietDatPhongBy_IdDatPhong_IdPhong_ThoiGian @DatPhongId = 1, @PhongId =1
GO

 go

--Query Dac Biet:
--!!! TimPhongDangDcDat
IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'TimPhongDangDcDat'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.TimPhongDangDcDat
GO
CREATE PROCEDURE dbo.TimPhongDangDcDat
    @ThoiGianNhan DATETIME = NULL,
    @ThoiGianTra DATETIME = NULL
AS
-- body of the stored procedure
SELECT distinct PhongId
FROM
    ChiTietDatPhongs
WHERE @ThoiGianNhan <=ThoiGian and ThoiGian <=@ThoiGianTra   
    
    
GO

EXECUTE dbo.TimPhongDangDcDat '2019-12-12' ,  '2020-12-12'
GO
--TimPhongTrongLienTuc
IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'TimPhongLienTuc'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.TimPhongLienTuc
GO
CREATE PROCEDURE dbo.TimPhongLienTuc
    @ThoiGianNhan DATETIME = NULL,
    @ThoiGianTra DATETIME = NULL
AS
-- body of the stored procedure
SELECT *
from Phongs
WHERE Id not IN
  (SELECT distinct PhongId
FROM
    ChiTietDatPhongs
WHERE @ThoiGianNhan <=ThoiGian and ThoiGian <=@ThoiGianTra)   
    
    
GO
EXECUTE dbo.TimPhongLienTuc '2019-12-12' ,  '2020-12-12'
GO

--10- Function tổng tiền dịch vụ của 1 phiếu đặt phòng
IF OBJECT_ID('fnTongTienDichVuByDatPhongId') IS NOT NULL
 DROP FUNCTION fnTongTienDichVuByDatPhongId;
 go
create FUNCTION fnTongTienDichVuByDatPhongId( @IdDatPhong int =0)
 RETURNS money 
 BEGIN
    RETURN (select sum(TongTien)
    from
        (SELECT TongTien = (a.SoLuong*b.Price)
        from ChiTietDichVuDatPhongs a, DichVus b
        WHERE a.DatPhongId=1
            and a.DichVuId=b.Id)c
)
END;
go
print dbo.fnTongTienDichVuByDatPhongId(1)
GO

-- tổng tiền phòng của 1 phiếu đặt phòng
IF OBJECT_ID('fnTongTienPhongByDatPhongId') IS NOT NULL
 DROP FUNCTION fnTongTienPhongByDatPhongId;
 go

create FUNCTION fnTongTienPhongByDatPhongId( @IdDatPhong int =0)
 RETURNS money 
 BEGIN
    RETURN ( select sum(b.Price)
    from ChiTietDatPhongs a, Phongs  b
    where DatPhongId =@IdDatPhong
        and a.PhongId=b.Id )
END;
GO
print dbo.fnTongTienPhongByDatPhongId(1) + dbo.fnTongTienDichVuByDatPhongId(1)
GO
IF OBJECT_ID('spCapNhatTongTienOnePhieuDatPhong') IS NOT NULL
 DROP proc spCapNhatTongTienOnePhieuDatPhong;
 go
create proc spCapNhatTongTienOnePhieuDatPhong
    @Id int =0
as
BEGIN
    IF(@Id is not null)
        UPDATE DatPhongs
        SET TongTien = dbo.fnTongTienPhongByDatPhongId(@Id) + dbo.fnTongTienDichVuByDatPhongId(1)
        WHERE Id=@Id;
    ELSE
   THROW 50001, 'không tồn tại id', 1;
END;
go

execute spCapNhatTongTienOnePhieuDatPhong 3


-- Trigger chưa xong, vì còn thiếu add chi tiết đặt phòng
GO
IF OBJECT_ID('tgChiTietDatPhongInSert') IS NOT NULL
 DROP TRIGGER tgChiTietDatPhongInSert;
 go
CREATE TRIGGER tgChiTietDatPhongInSert
    on ChiTietDatPhongs
    AFTER INSERT
As
go



---Đặt Biệt
--Heap
--AddChiTietDatPhongHeap

IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'AddChiTietDatPhongHeap'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.AddChiTietDatPhongHeap
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.AddChiTietDatPhongHeap
    @Id  int  = 0
AS
insert ChiTietDatPhongHeaps
values
    (@Id)

GO

--AddChiTietDichVuHeap

IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'AddChiTietDichVuHeap'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.AddChiTietDichVuHeap
GO
CREATE PROCEDURE dbo.AddChiTietDichVuHeap
    @Id int  = 0
AS
insert ChiTietDichVuDatPhongHeaps
values
    (@Id)

GO


--Dem So luong Phong -- Fntion

IF OBJECT_ID('fnSoLuongPhongDat') IS NOT NULL
 DROP FUNCTION fnSoLuongPhongDat;
 GO
create FUNCTION fnSoLuongPhongDat()
 RETURNS int 
 BEGIN
    RETURN (select count(PhongId)[SoLuongP]
    from ChiTietDatPhongHeaps)
END;
go

--Dem So luong dich vu

IF OBJECT_ID('fnSoLuongDichVuDat') IS NOT NULL
 DROP FUNCTION fnSoLuongDichVuDat;
 GO
create FUNCTION fnSoLuongDichVuDat()
 RETURNS int 
 BEGIN
    RETURN (select count(DichVuId)[SoLuongP]
    from ChiTietDichVuDatPhongHeaps)
END;
go


--fnGetValueDatPhongHeap
IF OBJECT_ID('fnGetValueDatPhongHeap') IS NOT NULL
 DROP FUNCTION fnGetValueDatPhongHeap;
 GO
create FUNCTION fnGetValueDatPhongHeap(@Vitriinput int =0)
 RETURNS int 
 BEGIN
    RETURN (SELECT PhongId
    FROM ChiTietDatPhongHeaps
    ORDER BY PhongId
			OFFSET @Vitriinput ROWS 
			FETCH NEXT 1 ROWS ONLY)
END;
go

--fnGetValueDichVuHeap
IF OBJECT_ID('fnGetValueDichVuHeap') IS NOT NULL
 DROP FUNCTION fnGetValueDichVuHeap;
 GO
create FUNCTION fnGetValueDichVuHeap(@Vitriinput int =0)
 RETURNS int 
 BEGIN
    RETURN (SELECT DichVuId
    FROM ChiTietDichVuDatPhongHeaps
    ORDER BY DichVuId
			OFFSET @Vitriinput ROWS 
			FETCH NEXT 1 ROWS ONLY)
END;
go

---
-- Lấy Ngày đặt phòng
IF OBJECT_ID('fnGetNgayNhanDatPhong') IS NOT NULL
 DROP FUNCTION fnGetNgayNhanDatPhong;
 GO
create FUNCTION fnGetNgayNhanDatPhong()
 RETURNS datetime2(7) 
 BEGIN
    RETURN (select ThoiGianNhanPhongDuKien
    from DatPhongs
    WHERE Id=@@IDENTITY)
END;
go

-- Lấy Ngày Trả Phòng
IF OBJECT_ID('fnGetNgayTraDatPhong') IS NOT NULL
 DROP FUNCTION fnGetNgayTraDatPhong;
 GO
create FUNCTION fnGetNgayTraDatPhong()
 RETURNS datetime2(7) 
 BEGIN
    RETURN (select ThoiGianTraPhongDuKien
    from DatPhongs
    WHERE Id=@@IDENTITY)
END;
go

---Transaction
IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'AddDatPhong'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.AddDatPhong
GO

CREATE PROCEDURE [dbo].[AddDatPhong]
    @Tenkh nvarchar(max)=null,
    @DiaChi nvarchar(max)=null,
    @CMND nvarchar(max)=NULL,
    @SDT nvarchar(max)=NULL,
    @TienCoc money=0,
    @NgayNhan datetime2(7) ='2000-12-15',
    @NgayTra datetime2(7)='2000-12-18'
AS
BEGIN
    BEGIN TRY
    

    BEGIN TRANSACTION
        BEGIN

        DECLARE @soluongPhong int=0;
        EXECUTE	@soluongPhong =   fnSoLuongPhongDat
        Print @soluongPhong
        IF( @NgayNhan >= GETDATE()
            AND @NgayTra >= @NgayNhan
            AND @Tenkh is not NULL
            AND @DiaChi is not NULL
            AND @CMND is not NULL
            AND @SDT is not NULL
            AND @soluongPhong > 0)
            BEGIN
            SET NOCOUNT ON;
            insert DatPhongs
                (TenNguoiDat,DatPhongs.Address,Cmnd,Sdt,TienDatCoc,ThoiGianNhanPhongDuKien,ThoiGianTraPhongDuKien,TongTien)
            values
                (@Tenkh, @DiaChi, @CMND, @SDT, @TienCoc, @NgayNhan, @NgayTra, 0);
        END
    END
                      
    commit tran
	print 'transaction committed';
END TRY

begin catch 
 print 'error when inserting, rolling back transaction';
 rollback tran; 
end catch
end
GO

--- Trigger-InsertChiTietDatPhong

create TRIGGER InsertChiTietDatPhong
on DatPhongs
after INSERT 
AS

BEGIN
    BEGIN TRY
    BEGIN TRANSACTION
	     		BEGIN
        --khai bao phongid
        DECLARE @Phongid int;

        -- khai bao so luong phong cua 1 phieu
        DECLARE @soluongPhong int=0;
        execute @soluongPhong  =  fnSoLuongPhongDat

        -- khai bao và lấy giá trị ngày nhận phòng cua 1 phieu vừa tạo
        declare @NgayNhan datetime2(7)
        EXEC @NgayNhan = fnGetNgayNhanDatPhong

        -- khai bao và lấy giá trị ngày tra phòng cua 1 phieu vừa tạo

        declare @NgayTra datetime2(7)
        EXEC @NgayTra = fnGetNgayTraDatPhong

        declare @ThoiGian datetime2(7) =@NgayNhan

        DECLARE @iddatphong int;

        set @iddatphong=IDENT_CURRENT ('DatPhongs')

        DECLARE @biendemPhong int =1;
        DECLARE @biendemDichVu int =1;

        DECLARE @soluongDichVu int=0;
        EXEC	@soluongDichVu =  fnSoLuongDichVuDat

        while (@biendemPhong <=@soluongPhong)
						BEGIN
            while (@ThoiGian <=@NgayTra)	
							begin
                BEGIN
                    DECLARE @vitri int = @biendemPhong-1
                    execute @Phongid = fnGetValueDatPhongHeap @vitri
                    insert ChiTietDatPhongs
                        (ThoiGian,DatPhongId,PhongId,TrangThaiId)
                    values
                        (@ThoiGian, @iddatphong, @Phongid, 1)
                    set @ThoiGian=(DATEADD(day, 1, @ThoiGian))
                END
            end
            set  @ThoiGian=@NgayNhan
            set @biendemPhong=@biendemPhong+1;
        end

    END
		
        
        commit tran 
			DELETE FROM ChiTietDatPhongHeaps
        	DELETE FROM ChiTietDichVuDatPhongHeaps
	print 'transaction committed';
    END TRY

    begin catch 
    print 'error when inserting, rolling back transaction';
    rollback tran; 
    end catch
END