USE [QLCuaHangMyPham]
GO
/****** Object:  User [sa2]    Script Date: 11/30/2019 5:39:44 PM ******/
CREATE USER [sa2] FOR LOGIN [sa2] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[fnTongBill]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Function [dbo].[fnTongBill] (@id int)
returns money
begin
return 
(select  Sum(TongTien)
from  HoaDon
where month(NgayLap)=@id
group by month(NgayLap)
)
end;
GO
/****** Object:  UserDefinedFunction [dbo].[fnTongLuong]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Function [dbo].[fnTongLuong] ()
returns int 
begin
return 
(select  Sum(Luong)
from  NhanVien
)
end;
GO
/****** Object:  Table [dbo].[ThuongHieu]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuongHieu](
	[ThuongHieuID] [int] IDENTITY(1,1) NOT NULL,
	[TenThuongHieu] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ThuongHieu] PRIMARY KEY CLUSTERED 
(
	[ThuongHieuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[SanPhamID] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](50) NOT NULL,
	[SoLuong] [int] NULL,
	[DVT] [nvarchar](50) NULL,
	[GiaNhap] [money] NOT NULL,
	[GiaBan] [money] NOT NULL,
	[MaKe] [int] NOT NULL,
	[ThuongHieuID] [int] NULL,
	[CongDungID] [int] NOT NULL,
	[MoTa] [ntext] NULL,
	[LoaiSanPhamId] [int] NULL,
	[HinhAnh] [nvarchar](max) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[SanPhamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[LoaiSanPhamId] [int] NOT NULL,
	[TenLoaiSanPham] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[LoaiSanPhamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[viewSanPham]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[viewSanPham]
as
select TenSanPham,GiaBan,TenThuongHieu,TenLoaiSanPham,MoTa
from SanPham a join ThuongHieu b on a.ThuongHieuID=b.ThuongHieuID
join LoaiSanPham c on a.LoaiSanPhamId=c.LoaiSanPhamId

GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccoutID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Quyen] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccoutID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CapBacThe]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CapBacThe](
	[CapBacTheID] [int] IDENTITY(1,1) NOT NULL,
	[TenCapBac] [nvarchar](50) NOT NULL,
	[TienToiThieu] [money] NOT NULL,
	[QuyenLoi] [ntext] NULL,
 CONSTRAINT [PK_CapBacThe] PRIMARY KEY CLUSTERED 
(
	[CapBacTheID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[HoaDonID] [int] NOT NULL,
	[SanPhamID] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[GiaBan] [money] NOT NULL,
	[ThanhTien] [money] NOT NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[HoaDonID] ASC,
	[SanPhamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTieu]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTieu](
	[ChiTieuID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[SoTien] [money] NOT NULL,
	[ThoiGian] [datetime] NOT NULL,
 CONSTRAINT [PK_ChiTieu] PRIMARY KEY CLUSTERED 
(
	[ChiTieuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongDung]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongDung](
	[CongDungID] [int] IDENTITY(1,1) NOT NULL,
	[TenCongDung] [nvarchar](50) NOT NULL,
	[NhomCongDungID] [int] NOT NULL,
 CONSTRAINT [PK_CongDung] PRIMARY KEY CLUSTERED 
(
	[CongDungID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[HoaDonID] [int] IDENTITY(1,1) NOT NULL,
	[AccoutID] [int] NOT NULL,
	[NgayLap] [datetime] NOT NULL,
	[MaGiamGia] [nvarchar](50) NULL,
	[TheTVienID] [int] NULL,
	[TongTien] [money] NOT NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[HoaDonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[KhachHangID] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](50) NOT NULL,
	[NgaySinh] [datetime] NOT NULL,
	[SDT] [int] NOT NULL,
	[Email] [nvarchar](50) NULL,
	[TheTVienID] [int] NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[KhachHangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaGiamGia]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaGiamGia](
	[MaGiamGia] [nvarchar](50) NOT NULL,
	[TenChuongTrinh] [nvarchar](50) NULL,
	[NgayBatDau] [datetime] NOT NULL,
	[NgayKetThuc] [datetime] NOT NULL,
	[DieuKienApDung] [ntext] NULL,
 CONSTRAINT [PK_MaGiamGia] PRIMARY KEY CLUSTERED 
(
	[MaGiamGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[NhanVienID] [int] IDENTITY(1,1) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[SDT] [int] NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[CMND] [int] NOT NULL,
	[Luong] [money] NULL,
	[NgayLam] [datetime] NULL,
	[AccoutID] [int] NULL,
 CONSTRAINT [PK_NhanVien2] PRIMARY KEY CLUSTERED 
(
	[NhanVienID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhomCongDung]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomCongDung](
	[NhomCongDungID] [int] IDENTITY(1,1) NOT NULL,
	[TenNhomCongDung] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NhomCongDung] PRIMARY KEY CLUSTERED 
(
	[NhomCongDungID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheThanhVien]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheThanhVien](
	[TheTVienID] [int] IDENTITY(1,1) NOT NULL,
	[TongChiTieu] [money] NOT NULL,
	[Ngaylap] [datetime] NULL,
	[CapbacTheID] [int] NOT NULL,
 CONSTRAINT [PK_TheThanhVien] PRIMARY KEY CLUSTERED 
(
	[TheTVienID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Thu]    Script Date: 11/30/2019 5:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thu](
	[ThuID] [int] IDENTITY(1,1) NOT NULL,
	[SoTien] [money] NOT NULL,
	[ThoiGian] [datetime] NULL,
 CONSTRAINT [PK_Thu] PRIMARY KEY CLUSTERED 
(
	[ThuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccoutID], [Username], [Password], [Quyen]) VALUES (1, N'Admin', N'123456', N'Admin')
INSERT [dbo].[Account] ([AccoutID], [Username], [Password], [Quyen]) VALUES (2, N'NhanVien1', N'123456', N'NhanVien')
INSERT [dbo].[Account] ([AccoutID], [Username], [Password], [Quyen]) VALUES (3, N'NhanVien2', N'123456', N'NhanVien')
INSERT [dbo].[Account] ([AccoutID], [Username], [Password], [Quyen]) VALUES (4, N'QuanLy', N'123456', N'QuanLy')
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[CapBacThe] ON 

INSERT [dbo].[CapBacThe] ([CapBacTheID], [TenCapBac], [TienToiThieu], [QuyenLoi]) VALUES (1, N'Vip1', 1500000.0000, N'giảm 5%')
INSERT [dbo].[CapBacThe] ([CapBacTheID], [TenCapBac], [TienToiThieu], [QuyenLoi]) VALUES (2, N'Vip2', 3500000.0000, N'giảm 8%')
INSERT [dbo].[CapBacThe] ([CapBacTheID], [TenCapBac], [TienToiThieu], [QuyenLoi]) VALUES (3, N'Vip3', 7000000.0000, N'giảm 15%')
INSERT [dbo].[CapBacThe] ([CapBacTheID], [TenCapBac], [TienToiThieu], [QuyenLoi]) VALUES (4, N'thuong', 0.0000, N'0')
SET IDENTITY_INSERT [dbo].[CapBacThe] OFF
INSERT [dbo].[ChiTietHoaDon] ([HoaDonID], [SanPhamID], [SoLuong], [GiaBan], [ThanhTien]) VALUES (7, 1, 2, 100000.0000, 200000.0000)
INSERT [dbo].[ChiTietHoaDon] ([HoaDonID], [SanPhamID], [SoLuong], [GiaBan], [ThanhTien]) VALUES (7, 2, 2, 100000.0000, 200000.0000)
SET IDENTITY_INSERT [dbo].[ChiTieu] ON 

INSERT [dbo].[ChiTieu] ([ChiTieuID], [Ten], [SoTien], [ThoiGian]) VALUES (1, N'Nhập sản phẩm 1', 1000000.0000, CAST(N'2019-11-14T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[ChiTieu] OFF
SET IDENTITY_INSERT [dbo].[CongDung] ON 

INSERT [dbo].[CongDung] ([CongDungID], [TenCongDung], [NhomCongDungID]) VALUES (1, N'Sữa Rửa Mặt', 1)
INSERT [dbo].[CongDung] ([CongDungID], [TenCongDung], [NhomCongDungID]) VALUES (2, N'Mặt Mạ', 1)
INSERT [dbo].[CongDung] ([CongDungID], [TenCongDung], [NhomCongDungID]) VALUES (3, N'Chống Nắng', 1)
INSERT [dbo].[CongDung] ([CongDungID], [TenCongDung], [NhomCongDungID]) VALUES (4, N'Nước Hoa Hồng', 1)
INSERT [dbo].[CongDung] ([CongDungID], [TenCongDung], [NhomCongDungID]) VALUES (5, N'Serum & Kem Dưỡng', 1)
INSERT [dbo].[CongDung] ([CongDungID], [TenCongDung], [NhomCongDungID]) VALUES (6, N'Sữa Tắm', 2)
INSERT [dbo].[CongDung] ([CongDungID], [TenCongDung], [NhomCongDungID]) VALUES (7, N'Dưỡng Thể', 2)
INSERT [dbo].[CongDung] ([CongDungID], [TenCongDung], [NhomCongDungID]) VALUES (8, N'Chống Nắng', 2)
INSERT [dbo].[CongDung] ([CongDungID], [TenCongDung], [NhomCongDungID]) VALUES (9, N'Dầu Gọi-Dầu Xả', 3)
INSERT [dbo].[CongDung] ([CongDungID], [TenCongDung], [NhomCongDungID]) VALUES (10, N'Dưỡng Tóc', 3)
INSERT [dbo].[CongDung] ([CongDungID], [TenCongDung], [NhomCongDungID]) VALUES (11, N'Nước Hoa', 4)
SET IDENTITY_INSERT [dbo].[CongDung] OFF
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([HoaDonID], [AccoutID], [NgayLap], [MaGiamGia], [TheTVienID], [TongTien]) VALUES (5, 2, CAST(N'2019-11-13T00:00:00.000' AS DateTime), NULL, NULL, 100000.0000)
INSERT [dbo].[HoaDon] ([HoaDonID], [AccoutID], [NgayLap], [MaGiamGia], [TheTVienID], [TongTien]) VALUES (6, 2, CAST(N'2019-11-13T00:00:00.000' AS DateTime), NULL, NULL, 200000.0000)
INSERT [dbo].[HoaDon] ([HoaDonID], [AccoutID], [NgayLap], [MaGiamGia], [TheTVienID], [TongTien]) VALUES (7, 2, CAST(N'2019-12-13T00:00:00.000' AS DateTime), NULL, NULL, 500000.0000)
INSERT [dbo].[HoaDon] ([HoaDonID], [AccoutID], [NgayLap], [MaGiamGia], [TheTVienID], [TongTien]) VALUES (8, 2, CAST(N'2019-11-14T00:00:00.000' AS DateTime), NULL, NULL, 100000.0000)
INSERT [dbo].[HoaDon] ([HoaDonID], [AccoutID], [NgayLap], [MaGiamGia], [TheTVienID], [TongTien]) VALUES (9, 3, CAST(N'2019-11-13T00:00:00.000' AS DateTime), NULL, NULL, 150000.0000)
INSERT [dbo].[HoaDon] ([HoaDonID], [AccoutID], [NgayLap], [MaGiamGia], [TheTVienID], [TongTien]) VALUES (10, 3, CAST(N'2019-11-15T00:00:00.000' AS DateTime), NULL, NULL, 100000.0000)
INSERT [dbo].[HoaDon] ([HoaDonID], [AccoutID], [NgayLap], [MaGiamGia], [TheTVienID], [TongTien]) VALUES (11, 2, CAST(N'2019-12-15T00:00:00.000' AS DateTime), NULL, NULL, 100000.0000)
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([KhachHangID], [TenKhachHang], [NgaySinh], [SDT], [Email], [TheTVienID]) VALUES (2, N'Ngoc Tuyen', CAST(N'1999-02-25T00:00:00.000' AS DateTime), 326364802, N'', 3)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
INSERT [dbo].[LoaiSanPham] ([LoaiSanPhamId], [TenLoaiSanPham]) VALUES (1, N'Sữa Rửa Mặt')
INSERT [dbo].[LoaiSanPham] ([LoaiSanPhamId], [TenLoaiSanPham]) VALUES (2, N'Mặt Mạ')
INSERT [dbo].[LoaiSanPham] ([LoaiSanPhamId], [TenLoaiSanPham]) VALUES (3, N'Chống Nắng')
INSERT [dbo].[LoaiSanPham] ([LoaiSanPhamId], [TenLoaiSanPham]) VALUES (4, N'Nước Hoa Hồng')
INSERT [dbo].[LoaiSanPham] ([LoaiSanPhamId], [TenLoaiSanPham]) VALUES (5, N'Serum & Kem Dưỡng')
INSERT [dbo].[LoaiSanPham] ([LoaiSanPhamId], [TenLoaiSanPham]) VALUES (6, N'Sữa Tắm')
INSERT [dbo].[LoaiSanPham] ([LoaiSanPhamId], [TenLoaiSanPham]) VALUES (7, N'Dưỡng Thể')
INSERT [dbo].[LoaiSanPham] ([LoaiSanPhamId], [TenLoaiSanPham]) VALUES (8, N'Chống Nắng')
INSERT [dbo].[LoaiSanPham] ([LoaiSanPhamId], [TenLoaiSanPham]) VALUES (9, N'Dầu Gọi-Dầu Xả')
INSERT [dbo].[LoaiSanPham] ([LoaiSanPhamId], [TenLoaiSanPham]) VALUES (10, N'Dưỡng Tóc')
INSERT [dbo].[LoaiSanPham] ([LoaiSanPhamId], [TenLoaiSanPham]) VALUES (11, N'Nước Hoa')
INSERT [dbo].[MaGiamGia] ([MaGiamGia], [TenChuongTrinh], [NgayBatDau], [NgayKetThuc], [DieuKienApDung]) VALUES (N'NGVN', N'Nhà giáo việt nam', CAST(N'2019-11-18T00:00:00.000' AS DateTime), CAST(N'2019-11-21T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[MaGiamGia] ([MaGiamGia], [TenChuongTrinh], [NgayBatDau], [NgayKetThuc], [DieuKienApDung]) VALUES (N'VIP1', N'khách hàng vip 1', CAST(N'2000-01-01T00:00:00.000' AS DateTime), CAST(N'2100-12-31T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[MaGiamGia] ([MaGiamGia], [TenChuongTrinh], [NgayBatDau], [NgayKetThuc], [DieuKienApDung]) VALUES (N'VIP2', N'Khách hàng vip 2', CAST(N'2000-01-01T00:00:00.000' AS DateTime), CAST(N'2100-12-31T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[MaGiamGia] ([MaGiamGia], [TenChuongTrinh], [NgayBatDau], [NgayKetThuc], [DieuKienApDung]) VALUES (N'VIP3', N'Khách hàng vip 3', CAST(N'2000-01-01T00:00:00.000' AS DateTime), CAST(N'2010-12-31T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([NhanVienID], [TenNV], [SDT], [NgaySinh], [CMND], [Luong], [NgayLam], [AccoutID]) VALUES (1, N'Phan Thị Ngọc Tuyền', 326364802, CAST(N'1999-02-25' AS Date), 321780798, NULL, NULL, 2)
INSERT [dbo].[NhanVien] ([NhanVienID], [TenNV], [SDT], [NgaySinh], [CMND], [Luong], [NgayLam], [AccoutID]) VALUES (2, N'Nguyễn Duy Phước', 326478212, CAST(N'1999-03-27' AS Date), 321752321, NULL, NULL, 3)
INSERT [dbo].[NhanVien] ([NhanVienID], [TenNV], [SDT], [NgaySinh], [CMND], [Luong], [NgayLam], [AccoutID]) VALUES (3, N'Nguyễn Trần Thanh Trúc', 321764742, CAST(N'1999-08-10' AS Date), 321754789, NULL, NULL, 4)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
SET IDENTITY_INSERT [dbo].[NhomCongDung] ON 

INSERT [dbo].[NhomCongDung] ([NhomCongDungID], [TenNhomCongDung]) VALUES (1, N'Chăm Sóc Da Mặt')
INSERT [dbo].[NhomCongDung] ([NhomCongDungID], [TenNhomCongDung]) VALUES (2, N'Chăm Sóc Da(body)')
INSERT [dbo].[NhomCongDung] ([NhomCongDungID], [TenNhomCongDung]) VALUES (3, N'Chăm Sóc Tóc,Da Đầu')
INSERT [dbo].[NhomCongDung] ([NhomCongDungID], [TenNhomCongDung]) VALUES (4, N'Nước Hoa')
INSERT [dbo].[NhomCongDung] ([NhomCongDungID], [TenNhomCongDung]) VALUES (5, N'afhfd')
SET IDENTITY_INSERT [dbo].[NhomCongDung] OFF
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([SanPhamID], [TenSanPham], [SoLuong], [DVT], [GiaNhap], [GiaBan], [MaKe], [ThuongHieuID], [CongDungID], [MoTa], [LoaiSanPhamId], [HinhAnh]) VALUES (1, N'Sữa Rửa Mặt Khổ Quas', 0, N'chai', 150000.0000, 190000.0000, 1, 2, 1, NULL, 1, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSanPham], [SoLuong], [DVT], [GiaNhap], [GiaBan], [MaKe], [ThuongHieuID], [CongDungID], [MoTa], [LoaiSanPhamId], [HinhAnh]) VALUES (2, N'Sữa Rửa Mặt Trà Xanh', 0, N'chai', 200000.0000, 220000.0000, 1, 3, 1, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
SET IDENTITY_INSERT [dbo].[TheThanhVien] ON 

INSERT [dbo].[TheThanhVien] ([TheTVienID], [TongChiTieu], [Ngaylap], [CapbacTheID]) VALUES (3, 500000.0000, CAST(N'2019-11-12T00:00:00.000' AS DateTime), 4)
SET IDENTITY_INSERT [dbo].[TheThanhVien] OFF
SET IDENTITY_INSERT [dbo].[Thu] ON 

INSERT [dbo].[Thu] ([ThuID], [SoTien], [ThoiGian]) VALUES (12, 650000.0000, CAST(N'2019-11-30T14:30:21.150' AS DateTime))
INSERT [dbo].[Thu] ([ThuID], [SoTien], [ThoiGian]) VALUES (13, 600000.0000, CAST(N'2019-12-30T14:34:27.280' AS DateTime))
INSERT [dbo].[Thu] ([ThuID], [SoTien], [ThoiGian]) VALUES (15, 650000.0000, CAST(N'2019-11-30T14:30:21.150' AS DateTime))
INSERT [dbo].[Thu] ([ThuID], [SoTien], [ThoiGian]) VALUES (16, 650000.0000, CAST(N'2019-11-30T14:30:42.540' AS DateTime))
SET IDENTITY_INSERT [dbo].[Thu] OFF
SET IDENTITY_INSERT [dbo].[ThuongHieu] ON 

INSERT [dbo].[ThuongHieu] ([ThuongHieuID], [TenThuongHieu]) VALUES (1, N'Laneige')
INSERT [dbo].[ThuongHieu] ([ThuongHieuID], [TenThuongHieu]) VALUES (2, N'soHERS')
INSERT [dbo].[ThuongHieu] ([ThuongHieuID], [TenThuongHieu]) VALUES (3, N'Innisfree')
INSERT [dbo].[ThuongHieu] ([ThuongHieuID], [TenThuongHieu]) VALUES (4, N'Acnes')
SET IDENTITY_INSERT [dbo].[ThuongHieu] OFF
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([HoaDonID])
REFERENCES [dbo].[HoaDon] ([HoaDonID])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_SanPham] FOREIGN KEY([SanPhamID])
REFERENCES [dbo].[SanPham] ([SanPhamID])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_SanPham]
GO
ALTER TABLE [dbo].[CongDung]  WITH CHECK ADD  CONSTRAINT [FK_CongDung_NhomCongDung] FOREIGN KEY([NhomCongDungID])
REFERENCES [dbo].[NhomCongDung] ([NhomCongDungID])
GO
ALTER TABLE [dbo].[CongDung] CHECK CONSTRAINT [FK_CongDung_NhomCongDung]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_Account] FOREIGN KEY([AccoutID])
REFERENCES [dbo].[Account] ([AccoutID])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_Account]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_MaGiamGia] FOREIGN KEY([MaGiamGia])
REFERENCES [dbo].[MaGiamGia] ([MaGiamGia])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_MaGiamGia]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_TheThanhVien] FOREIGN KEY([TheTVienID])
REFERENCES [dbo].[TheThanhVien] ([TheTVienID])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_TheThanhVien]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_TheThanhVien] FOREIGN KEY([TheTVienID])
REFERENCES [dbo].[TheThanhVien] ([TheTVienID])
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_KhachHang_TheThanhVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien2_Account] FOREIGN KEY([AccoutID])
REFERENCES [dbo].[Account] ([AccoutID])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien2_Account]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([LoaiSanPhamId])
REFERENCES [dbo].[LoaiSanPham] ([LoaiSanPhamId])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_CongDung] FOREIGN KEY([CongDungID])
REFERENCES [dbo].[CongDung] ([CongDungID])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_CongDung]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ThuongHieu] FOREIGN KEY([ThuongHieuID])
REFERENCES [dbo].[ThuongHieu] ([ThuongHieuID])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_ThuongHieu]
GO
ALTER TABLE [dbo].[TheThanhVien]  WITH CHECK ADD  CONSTRAINT [FK_TheThanhVien_CapBacThe] FOREIGN KEY([CapbacTheID])
REFERENCES [dbo].[CapBacThe] ([CapBacTheID])
GO
ALTER TABLE [dbo].[TheThanhVien] CHECK CONSTRAINT [FK_TheThanhVien_CapBacThe]
GO
/****** Object:  StoredProcedure [dbo].[GetSortedSanPham]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetSortedSanPham] @colname AS sysname, @sortdir AS CHAR(1) = 'A' AS
select * from viewSanPham 


ORDER BY CASE WHEN @colname = N'GiaBan' AND @sortdir = 'A' THEN GiaBan END,
CASE WHEN @colname = N'GiaBan' AND @sortdir = 'D' THEN GiaBan END DESC,
CASE WHEN @colname = N'TenSanPham' AND @sortdir = 'A' THEN TenSanPham END,
CASE WHEN @colname = N'TenThuongHieu' AND @sortdir = 'D' THEN TenThuongHieu END DESC,
CASE WHEN @colname = N'TenLoaiSanPham' AND @sortdir = 'D' THEN TenLoaiSanPham END DESC
OPTION (RECOMPILE);
GO
/****** Object:  StoredProcedure [dbo].[spCapNhatAccount]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spCapNhatAccount]
@AccountID int ,
@Password nvarchar(50)
as
begin 
if(@AccountID is not null)
	update Account 
	set Password=@Password
	where AccoutID=@AccountID
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
GO
/****** Object:  StoredProcedure [dbo].[spCapNhatCapBacThe]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spCapNhatCapBacThe]
@CapBacTheID int ,
@TenCapBac nvarchar(50),
@TienToiThieu money,
@QuyenLoi ntext
as
begin 
if(@CapBacTheID is not null)
	update CapBacThe 
	set TenCapBac=@TenCapBac,TienToiThieu=@TienToiThieu,QuyenLoi=@QuyenLoi
	where CapBacTheID=@CapBacTheID
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
GO
/****** Object:  StoredProcedure [dbo].[spCapNhatKhachHang]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spCapNhatKhachHang]
@KhachHangID int ,
@TenKhachHang nvarchar(50),
@NgaySinh datetime,
@SDT int,
@Email nvarchar(50),
@TheTVienID int 

as
begin 
if(@KhachHangID is not null)
	update KhachHang 
	set TenKhachHang=@TenKhachHang,NgaySinh=@NgaySinh,SDT=@SDT,Email=@Email,TheTVienID=@TheTVienID
	where KhachHangID=@KhachHangID
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
GO
/****** Object:  StoredProcedure [dbo].[spCapNhatMaGiamGia]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spCapNhatMaGiamGia]
@MaGiamGia int ,
@TenChuongTrinh nvarchar(50),
@NgayBatDau datetime,
@NgayKetThuc datetime,
@DieuKienApDung ntext
as
begin 
if(@MaGiamGia is not null)
	update MaGiamGia 
	set TenChuongTrinh=@TenChuongTrinh,NgayBatDau=@NgayBatDau,NgayKetThuc=@NgayKetThuc,DieuKienApDung=@DieuKienApDung
	where MaGiamGia=@MaGiamGia
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
GO
/****** Object:  StoredProcedure [dbo].[spCapNhatNV]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spCapNhatNV]
@NhanVienID int,
@TenNV	nvarchar(50),
@SDT int,
@Luong money,
@NgayLam datetime
as
begin 
if(@NhanVienID is not null)
	update NhanVien 
	set TenNV=@TenNV,
	 SDT=@SDT,Luong=@Luong
	where NhanVienID=@NhanVienID
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
GO
/****** Object:  StoredProcedure [dbo].[spCapNhatTheThanhVien]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spCapNhatTheThanhVien]
@TheTVienID int ,
@TongChiTieu money,
@NgayLap	datetime,
@CapBacTheID int 
as
begin 
if(@TheTVienID is not null)
	update TheThanhVien 
	set TongChiTieu=@TongChiTieu,Ngaylap=@NgayLap,CapbacTheID=@CapBacTheID
	where TheTVienID=@TheTVienID
else 
THROW 50001, 'Nhap sai dieu kien!!!!.', 1;
end;
GO
/****** Object:  StoredProcedure [dbo].[spCapNhatTongThu]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spCapNhatTongThu]
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
GO
/****** Object:  StoredProcedure [dbo].[spChiPhi]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spChiPhi]
@Ten	nvarchar(50)	,
@SoTien money,
@ThoiGian datetime
as
begin
insert ChiTieu
values (@Ten,@SoTien,@ThoiGian);
end	
GO
/****** Object:  StoredProcedure [dbo].[spGetAccount]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--ACCOUNT

create proc [dbo].[spGetAccount]
as
begin 
Select * from Account
end;
GO
/****** Object:  StoredProcedure [dbo].[spGetCapBacThe]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--CAP BAC THE

create proc [dbo].[spGetCapBacThe]
as
begin 
Select * from CapBacThe
end;
GO
/****** Object:  StoredProcedure [dbo].[spGetChiTietSanPham]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetChiTietSanPham]

as
begin
select SanPhamID,TenSanPham,GiaBan,TenThuongHieu,TenCongDung,MoTa
from SanPham a 
	join ThuongHieu b 
	on a.ThuongHieuID=b.ThuongHieuID 
	join CongDung c
	on a.CongDungID=c.CongDungID

end;
GO
/****** Object:  StoredProcedure [dbo].[spGetKhachHang]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--KHACH HANG
create proc [dbo].[spGetKhachHang]
as
begin 
Select * from KhachHang
end;
GO
/****** Object:  StoredProcedure [dbo].[spGetMaGiamGia]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--MÃ GIẢM GIÁ
create proc [dbo].[spGetMaGiamGia]
as
begin 
Select * from MaGiamGia
end;
GO
/****** Object:  StoredProcedure [dbo].[spGetNhanVien]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spGetNhanVien]
as
begin 
Select * from NhanVien
end;
GO
/****** Object:  StoredProcedure [dbo].[spGetTheTVien]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--THẺ THÀNH VIÊN

create proc [dbo].[spGetTheTVien]
as
begin 
Select * from TheThanhVien
end;
GO
/****** Object:  StoredProcedure [dbo].[spThemAccount]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[spThemAccount]
@Username	nvarchar(50),
@Password	nvarchar(50),
@Quyen nvarchar(50)
as
begin
insert Account
values (@Username,@Password,@Quyen);
end	
GO
/****** Object:  StoredProcedure [dbo].[spThemCapBacThe]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spThemCapBacThe]
@TenCapBac nvarchar(50),
@TienToiThieu money,
@QuyenLoi ntext	
as
begin
insert CapBacThe
values (@TenCapBac,@TienToiThieu,@QuyenLoi);
end	

GO
/****** Object:  StoredProcedure [dbo].[spThemKhachHang]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spThemKhachHang]
@TenKhachHang nvarchar(50),
@NgaySinh datetime,
@SDT int,
@Email nvarchar(50),
@TheTVienID int 

as
begin
insert KhachHang
values (@TenKhachHang,@NgaySinh,@SDT,@Email,@TheTVienID);
end	

GO
/****** Object:  StoredProcedure [dbo].[spThemMaGiamGia]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spThemMaGiamGia]
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

--create NhanVien
if OBJECT_ID('spThemNhanVien') is not null
drop proc spThemAccount;
GO
/****** Object:  StoredProcedure [dbo].[spThemNhanVien]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spThemNhanVien]
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
GO
/****** Object:  StoredProcedure [dbo].[spThemTheTVien]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spThemTheTVien]
@TongChiTieu money,
@NgayLap	datetime,
@CapBacThe int 
	
as
begin
insert TheThanhVien
values (@TongChiTieu,@NgayLap,@CapBacThe);
end	

GO
/****** Object:  StoredProcedure [dbo].[spTim]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spTim]
@ten nvarchar(50)
as
begin
select SanPhamID,TenSanPham,GiaBan,TenThuongHieu,TenCongDung
from SanPham a 
	join ThuongHieu b 
	on a.ThuongHieuID=b.ThuongHieuID 
	join CongDung c
	on a.CongDungID=c.CongDungID
where b.TenThuongHieu =@ten  or  c.TenCongDung=@ten

end;
GO
/****** Object:  StoredProcedure [dbo].[spTimCDSP]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spTimCDSP]
@Ten nvarchar(50)
as
begin
select * 
from SanPham a join CongDung b
on a.CongDungID=b.CongDungID
where b.TenCongDung like @Ten 
end;
GO
/****** Object:  StoredProcedure [dbo].[spTimTHSP]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spTimTHSP]
@Ten nvarchar(50)
as
begin
select * 
from SanPham a join ThuongHieu b
on a.ThuongHieuID=b.ThuongHieuID
where b.TenThuongHieu like @Ten 
end;
GO
/****** Object:  StoredProcedure [dbo].[spTongThu]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spTongThu]
@SoTien money,
@ThoiGian datetime
as
begin
insert into Thu 
values (@SoTien,@ThoiGian);
declare @tien money
set @SoTien=dbo.fnTongBill(11)
end	
GO
/****** Object:  StoredProcedure [dbo].[spXoaAccount]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spXoaAccount]
       @AccountID    INT        
AS 
BEGIN 
     SET NOCOUNT ON 

     DELETE Account
     FROM   Account
     WHERE   AccoutID=@AccountID
    
END
GO
/****** Object:  StoredProcedure [dbo].[spXoaCapBacThe]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spXoaCapBacThe]
       @CapBacTheID    INT        
AS 
BEGIN 
     SET NOCOUNT ON 

     DELETE CapBacThe
     FROM   CapBacThe
     WHERE   CapBacTheID=@CapBacTheID
    
END
GO
/****** Object:  StoredProcedure [dbo].[spXoaKhachHang]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spXoaKhachHang]
       @KhachHangID    INT        
AS 
BEGIN 
     SET NOCOUNT ON 

     DELETE KhachHang
     FROM   KhachHang
     WHERE   KhachHangID=@KhachHangID
    
END
GO
/****** Object:  StoredProcedure [dbo].[spXoaMaGiamGia]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spXoaMaGiamGia]
       @MaGiamGia    INT        
AS 
BEGIN 
     SET NOCOUNT ON 

     DELETE MaGiamGia
     FROM   MaGiamGia
     WHERE   MaGiamGia=@MaGiamGia
    
END
GO
/****** Object:  StoredProcedure [dbo].[spXoaNV]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spXoaNV]
       @NhanVienID    INT        
AS 
BEGIN 
     SET NOCOUNT ON 

     DELETE NhanVien
     FROM   NhanVien
     WHERE  
     NhanVienID = @NhanVienID
END
GO
/****** Object:  StoredProcedure [dbo].[spXoaTheThanhVien]    Script Date: 11/30/2019 5:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spXoaTheThanhVien]
       @TheTVienID    INT        
AS 
BEGIN 
     SET NOCOUNT ON 

     DELETE TheThanhVien
     FROM   TheThanhVien
     WHERE   TheTVienID=@TheTVienID
    
END
GO
