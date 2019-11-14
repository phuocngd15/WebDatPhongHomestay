
--create Account
if OBJECT_ID('spThemAccount') is not null
drop proc spThemAccount;
go

create proc spThemAccount
@Username	nvarchar(50)	,
@Password	nvarchar(50),
@Quyen nvarchar(50)
	
as
begin
insert Account
values (@Username,@Password,@Quyen);
end	
go

--create MaGiamGia
if OBJECT_ID('spThemMaGiamGia') is not null
drop proc spThemMaGiamGia;
go

create proc spThemMaGiamGia
@MaGiamGia nvarchar(50),
@TenChuongTrinh	nvarchar(50)	,
@NgayBatDau	datetime,
@NgayKetThuc datetime,
@DieuKienApDung ntext
	
as
begin
insert MaGiamGia
values (@MaGiamGia,@TenChuongTrinh,@NgayBatDau,@NgayKetThuc,@DieuKienApDung);
end	

--create ThemNhanVien
if OBJECT_ID('spThemNhanVien') is not null
drop proc spThemNhanVien;
go

create proc spThemNhanVien
@TenNV	nvarchar(50)	,
@SDT int,
@NgaySinh date,
@CMND int,
@Luong money,
@NgayLam datetime,
@AccoutID	int
	
as
begin
insert NhanVien
values (@TenNV,@SDT,@NgaySinh,@CMND,@Luong,@NgayLam,@AccoutID);
end	
go

--create cap nhat luong Nhan vien
if OBJECT_ID('spCapNhatLuongNV') is not null
drop proc spCapNhatLuongNV;
go
create proc spCapNhatLuongNV
@NhanVienID int,
@Luong money
as
begin 
if(@NhanVienID is not null)
	update NhanVien 
	set Luong=@Luong
	where NhanVienID=@NhanVienID
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;

end;


if OBJECT_ID('spChiPhi') is not null
drop proc spChiPhi;
go

create proc spChiPhi
@Ten	nvarchar(50)	,
@SoTien money,
@ThoiGian datetime
as
begin
insert ChiTieu
values (@Ten,@SoTien,@ThoiGian);
end	
go

--function TongLuong
if OBJECT_ID('fnTongLuong') is not null
drop function fnTongLuong;
go
create Function fnTongLuong ()
returns int 
begin
return 
(select  Sum(Luong)
from  NhanVien
)
end;

if OBJECT_ID('fnTongBill') is not null
drop function fnTongBill;
go

create Function fnTongBill (@id int)
returns money
begin
return 
(select  Sum(TongTien)
from  HoaDon
where month(NgayLap)=@id
group by month(NgayLap)
)
end;

print dbo.fnTongBill(11)
-- proc Chiphi

if OBJECT_ID('spTongThu') is not null
drop proc spTongThu;
go

create proc spTongThu
@SoTien money,
@ThoiGian datetime
as
begin
insert into Thu 
values (@SoTien,@ThoiGian);
declare @Thang int
set @SoTien=dbo.fnTongBill(@Thang)
end	

declare @tien money
declare @ThoiGian1 datetime=GETDATE();
declare @thang1 int=month(@ThoiGian1)
exec @tien=dbo.fnTongBill @thang1
exec spTongThu @SoTien=@tien,@ThoiGian=@ThoiGian1


if OBJECT_ID('spCapNhatTongThu') is not null
drop proc spCapNhatTongThu;
go
create proc spCapNhatTongThu
@SoTien money,
@ThoiGian datetime
as
begin 
if(@SoTien is not null)
	update Thu 
	set SoTien=@SoTien ,ThoiGian=GETDATE()
	where month(@ThoiGian)= month(ThoiGian)
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;

end;
declare @tien money
declare @ThoiGian1 datetime=GETDATE();
declare @thang1 int=month(@ThoiGian1)
exec @tien=dbo.fnTongBill @thang1

exec spCapNhatTongThu @SoTien=@Tien,@ThoiGian=@ThoiGian1