-- Create a new database called 'Cosmetic_SM'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'Cosmetic_SM'
)
CREATE DATABASE Cosmetic_SM
GO
USE [Cosmetic_SM]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 10/4/2019 4:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[FormID] [bigint] NOT NULL,
	[TotalCost] [money] NULL,
	[DiscountPercent] [int] NULL,
	[CustomerID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 10/4/2019 4:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[BrandID] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](1000) NOT NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[BrandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10/4/2019 4:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](100) NOT NULL,
	[PhoneNumber] [varchar](15) NOT NULL,
	[Birthday] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/4/2019 4:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](100) NOT NULL,
	[PhoneNumber] [varchar](15) NOT NULL,
	[BirthDay] [nvarchar](50) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forms]    Script Date: 10/4/2019 4:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forms](
	[FormID] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [char](3) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedPersonID] [int] NULL,
 CONSTRAINT [PK_Forms] PRIMARY KEY CLUSTERED 
(
	[FormID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forms_Produces]    Script Date: 10/4/2019 4:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forms_Produces](
	[FormID] [bigint] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Number] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupPurpose]    Script Date: 10/4/2019 4:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupPurpose](
	[GroupPurposeID] [int] IDENTITY(1,1) NOT NULL,
	[GroupPurposeName] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_GroupPurpose] PRIMARY KEY CLUSTERED 
(
	[GroupPurposeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/4/2019 4:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](1000) NOT NULL,
	[Unit] [nvarchar](1000) NOT NULL,
	[SellingPrice] [money] NOT NULL,
	[BuyingPrice] [money] NOT NULL,
	[ShelvesID] [char](3) NULL,
	[PurposeID] [int] NOT NULL,
	[BrandID] [int] NULL,
	[Number] [int] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purpose]    Script Date: 10/4/2019 4:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purpose](
	[PurposeID] [int] IDENTITY(1,1) NOT NULL,
	[PurposeName] [nvarchar](1000) NOT NULL,
	[GroupPurposeID] [int] NULL,
 CONSTRAINT [PK_Purpose] PRIMARY KEY CLUSTERED 
(
	[PurposeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Bill] ([FormID], [TotalCost], [DiscountPercent], [CustomerID]) VALUES (2, 190000000.0000, 0, 1)
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([BrandID], [BrandName], [Description]) VALUES (1, N'Sun Natural', NULL)
INSERT [dbo].[Brands] ([BrandID], [BrandName], [Description]) VALUES (2, N'soHERBS', NULL)
SET IDENTITY_INSERT [dbo].[Brands] OFF
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerID], [CustomerName], [PhoneNumber], [Birthday]) VALUES (1, N'Thanh Truc', N'0974562133', N'08/10/1999')
SET IDENTITY_INSERT [dbo].[Customers] OFF
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeID], [EmployeeName], [PhoneNumber], [BirthDay]) VALUES (1, N'Ngoc Tuyen', N'032636802', N'25/02/1999')
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[Forms] ON 

INSERT [dbo].[Forms] ([FormID], [Type], [CreatedDate], [CreatedPersonID]) VALUES (2, N'1  ', CAST(N'2019-03-10T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Forms] OFF
INSERT [dbo].[Forms_Produces] ([FormID], [ProductID], [Number]) VALUES (2, 1, 100)
SET IDENTITY_INSERT [dbo].[GroupPurpose] ON 

INSERT [dbo].[GroupPurpose] ([GroupPurposeID], [GroupPurposeName]) VALUES (1, N'Chăm Sóc Da Mặt')
INSERT [dbo].[GroupPurpose] ([GroupPurposeID], [GroupPurposeName]) VALUES (2, N'Chăm Sóc Da(body)')
INSERT [dbo].[GroupPurpose] ([GroupPurposeID], [GroupPurposeName]) VALUES (3, N'Nước Hoa')
INSERT [dbo].[GroupPurpose] ([GroupPurposeID], [GroupPurposeName]) VALUES (4, N'Chăm Sóc Tóc,Da Đầu')
SET IDENTITY_INSERT [dbo].[GroupPurpose] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [ProductName], [Unit], [SellingPrice], [BuyingPrice], [ShelvesID], [PurposeID], [BrandID], [Number], [Description]) VALUES (1, N'Sửa Rửa Mặt Khổ Qua', N'chai', 190000.0000, 100000.0000, N'1  ', 1, 1, 100, N'Là sản phẩm sửa rửa mặt làm sạch nhẹ nhàng ,loại bỏ tạp chất,ngăn ngừa sự hình thành mụn')
INSERT [dbo].[Products] ([ProductID], [ProductName], [Unit], [SellingPrice], [BuyingPrice], [ShelvesID], [PurposeID], [BrandID], [Number], [Description]) VALUES (2, N'Serum Tảo Biển', N'chai', 200000.0000, 150000.0000, N'1  ', 1, 1, 50, N'Giúp da mặt được bảo vệ và cấp ẩm đủ, tái tạo độ mịn màng cho da,cải thiện trình trạng lão hóa')
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Purpose] ON 

INSERT [dbo].[Purpose] ([PurposeID], [PurposeName], [GroupPurposeID]) VALUES (1, N'Sạch nhờn', 1)
INSERT [dbo].[Purpose] ([PurposeID], [PurposeName], [GroupPurposeID]) VALUES (2, N'Chống Nắng', 2)
SET IDENTITY_INSERT [dbo].[Purpose] OFF
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Customers]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Forms] FOREIGN KEY([FormID])
REFERENCES [dbo].[Forms] ([FormID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Forms]
GO
ALTER TABLE [dbo].[Forms]  WITH CHECK ADD  CONSTRAINT [FK_Forms_Employees] FOREIGN KEY([CreatedPersonID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Forms] CHECK CONSTRAINT [FK_Forms_Employees]
GO
ALTER TABLE [dbo].[Forms_Produces]  WITH CHECK ADD  CONSTRAINT [FK_Forms_Produces_Forms] FOREIGN KEY([FormID])
REFERENCES [dbo].[Forms] ([FormID])
GO
ALTER TABLE [dbo].[Forms_Produces] CHECK CONSTRAINT [FK_Forms_Produces_Forms]
GO
ALTER TABLE [dbo].[Forms_Produces]  WITH CHECK ADD  CONSTRAINT [FK_Forms_Produces_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Forms_Produces] CHECK CONSTRAINT [FK_Forms_Produces_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brands] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brands] ([BrandID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Brands]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Purpose] FOREIGN KEY([PurposeID])
REFERENCES [dbo].[Purpose] ([PurposeID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Purpose]
GO
ALTER TABLE [dbo].[Purpose]  WITH CHECK ADD  CONSTRAINT [FK_Purpose_GroupPurpose] FOREIGN KEY([GroupPurposeID])
REFERENCES [dbo].[GroupPurpose] ([GroupPurposeID])
GO
ALTER TABLE [dbo].[Purpose] CHECK CONSTRAINT [FK_Purpose_GroupPurpose]
GO
