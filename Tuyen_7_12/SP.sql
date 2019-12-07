--Table LoaiPhong
use CaChepFinal3
go

--1.spGetLoaiPhong
create proc spGetLoaiPhong
as
begin 
Select * from LoaiPhongs
end;
go
--2.spGetOneByIdLoaiPhong
create proc spGetOneByIdLoaiPhong
@id int 
as
begin 
Select * from LoaiPhongs
where Id=@id
end;

exec spGetLoaiPhong
go

--3.spAddLoaiPhong
create proc spAddLoaiPhong
@Ten	nvarchar(50)	

as
begin
insert LoaiPhongs
values (@Ten)
end

go
select * from LoaiPhongs
execute dbo.spAddLoaiPhong  @Ten=22222
go

--4.spEditLoaiPhong
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
create proc spGetNameLoaiPhongById
@id int null
as
begin 
if @id is not null
	Select * from LoaiPhongs
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go

--Table LoaiDichVu
--1.spAddLoaiDichVu
create proc spAddLoaiDichVu
@Ten	nvarchar(50)	,
@mota nvarchar(max)='notthing'
as
begin
insert LoaiDichVus
values (@Ten,@mota)
end
go
--2.spEditLoaiDichVu
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
create proc spGetLoaiDichVu
as
begin 
Select * from LoaiDichVus
end;
go
--5.spGetOneByIdLoaiDichVu

create proc spGetOneByIdLoaiDichVu
@id int 
as
begin 
Select * from LoaiDichVus
where Id=@id
end;
go

--Table Chương trình
--1.spEditChuongTrinh
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
create proc spAddChuongTrinh
@Name	nvarchar(max)	,
@Tile int,
@Tang bit
as
begin
insert ChuongTrinhs
values (@Name,@Tile,@Tang)
end	;
go

--3.spGetChuongTrinh
create proc spGetChuongTrinh
as
begin 
Select * from ChuongTrinhs
end;
go

--4.spDeleteChuongTrinh
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
create proc spGetOneByIdChuongTrinh
@id int null
as
begin 
if @id is not null
	Select * from ChuongTrinhs
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go

--6: spGetNameChuongTrinhById
create proc spGetNameChuongTrinhById
@id int null
as
begin 
if @id is not null
	Select * from ChuongTrinhs
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go

--- Table trạng thái
--1.spGetOneByIdTrangThai
create proc spGetOneByIdTrangThai
@id int 
as
begin 
Select * from TrangThais
where Id=@id
end;
go

--2.spAddTrangThai
create proc spAddTrangThai
@Name	nvarchar(max)	
as
begin
insert TrangThais
values (@Name)
end	;
go

--3.spGetTrangThai
create proc spGetTrangThai
as
begin 
Select * from TrangThais
end;
go

--4.spEditTrangThai
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


--Table DichVu
--1.spGetOneByIdDichVu
create proc spGetOneByIdDichVu
@id int 
as
begin 
Select a.Id,a.DichVuName,a.ShortDescription,a.Price,a.ImageUrl,a.InStock
,b.LoaiDichVuName
from DichVus a join LoaiDichVus b
on a.LoaiDvid=b.Id
where a.Id=@id
end;
go

--2 spAddDichVu
create proc spAddDichVu
@Name	nvarchar(max)	,
@Mota nvarchar(max)	,
@Price money,
@hinh nvarchar(max)	,
@InStock int ,
@LoaiDVuId int 
as
begin
insert DichVus
values (@Name,@Mota,@Price,@hinh,@InStock,@LoaiDVuId)
end	;
go
--3 spDeleteDichVu
create proc spDeleteDichVu
@id int
as
begin 
if(@id is not null)
	delete DichVus 
	from DichVus
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go

--4 spEditDichVu
create proc spEditDichVu
@id int ,
@Name	nvarchar(max)	,
@Mota nvarchar(max)	,
@Price money,
@hinh nvarchar(max)	,
@InStock int ,
@LoaiDVuId int 
as
begin 
if(@id is not null)
	update DichVus 
	set 
	DichVuName=@Name,	ShortDescription=@Mota,Price=@Price,ImageUrl=@hinh,InStock=@InStock,LoaiDvid=@LoaiDVuId
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go
--5 spGetOneByIdDichVu
create proc spGetOneByIdDichVu
@id int 
as
begin 
Select a.Id,a.DichVuName,a.ShortDescription,a.Price,a.ImageUrl,a.InStock
,b.LoaiDichVuName,a.LoaiDvid
from DichVus a join LoaiDichVus b
on a.LoaiDvid=b.Id
where a.Id=@id
end;
go
--Table Phong
--1.spEditPhong

create proc spEditPhong
@id int ,
@Ten	nvarchar(50)	,
@Mota nvarchar(max),
@Price money,
@LoaiphongId int,
@ChuongtrinhId int
as
begin 
if(@id is not null)
	update Phongs 
	set 
	PhongName=@Ten,	ShortDescription=@Mota,Price=@Price,LoaiPhongId=@LoaiphongId,ChuongTrinhId=@ChuongtrinhId
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go

--2.spDeletePhong
create proc spDeletePhong
@id int
as
begin 
if(@id is not null)
	delete Phongs 
	from Phongs
	where Id=@id
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
go

--3.spGetOneByIdPhong
create proc spGetOneByIdPhong
@id int 
as
begin 
Select b.Id,b.PhongName,ShortDescription,Price,a.LoaiPhongName,c.ChuongTrinhName,b.ChuongTrinhId,b.LoaiPhongId from LoaiPhongs a join Phongs b
on a.Id=b.LoaiPhongId 
join ChuongTrinhs c
on c.Id=b.ChuongTrinhId 
where b.Id=@id
end;
go
--4spGetPhong
create proc spGetPhong
as
begin 
Select b.Id,b.PhongName,b.ShortDescription,b.Price,a.LoaiPhongName,b.ChuongTrinhId,c.ChuongTrinhName,b.LoaiPhongId from LoaiPhongs a join Phongs b on a.Id=b.LoaiPhongId
join ChuongTrinhs c on
c.Id=b.ChuongTrinhId
end;
exec spGetPhong
go
--5 spAddPhong
create proc spAddPhong
@Name	nvarchar(max)	,
@Mota nvarchar(max)	,
@Price money,
@LoaiPhongId int,
@ChuongTrinhId int 
as
begin
insert Phongs
values (@Name,@Mota,@Price,@LoaiPhongId,@ChuongTrinhId)
end	;
go
drop proc spAddPhong


--transaction DatPhongs,ChiTietDAtPhong
declare @Tenkh nvarchar(max);
declare @DiaChi nvarchar(max);
declare @CMND nvarchar(max);
declare @SDT nvarchar(max);
declare @TienCoc nvarchar(max);
declare @TongTien money;
declare @account int;
declare @AccountId int;
declare @idPhong int ;
declare @ThoiGian datetime2(7) ;
declare @TrangThai int ;
declare @id int ;
declare @NgayNhan datetime2(7) ='2019-12-9';
declare @NgayTra datetime2(7)='2019-12-11';
begin try
	begin tran
		insert DatPhongs
		values ('T','as','13','13231',10000,@NgayNhan,@NgayTra,100000,null,null);
		set @id=@@IDENTITY 
		while @NgayNhan <=@NgayTra		
		begin 	
			insert ChiTietDatPhongs
			values (@id,1,@NgayNhan,1)	;
			set @NgayNhan=(DATEADD(day, 1, @NgayNhan))
		end
	commit tran
	print 'transaction committed';
end try
begin catch 
 print 'error when inserting, rolling back transaction';
 rollback tran; 
end catch