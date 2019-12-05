USE [CaChepFinal3]
GO
/****** Object:  StoredProcedure [dbo].[spGetOneByIdPhong]    Script Date: 12/5/2019 9:44:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[spGetOneByIdPhong]
@id int 
as
begin 
Select b.Id,b.Name,ShortDescription,Price,a.Name,c.TenChuongTrinh from LoaiPhongs a join Phongs b
on a.Id=b.LoaiPhongId 
join ChuongTrinhs c
on c.Id=b.ChuongTrinhId 

where b.Id=@id
end;

exec spGetOneByIdPhong @id=1