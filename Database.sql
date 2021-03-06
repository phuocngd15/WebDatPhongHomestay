USE [master]
GO
/****** Object:  Database [CaChepFinal3-HQT]    Script Date: 13-Dec-19 1:17:18 PM ******/
CREATE DATABASE [CaChepFinal3-HQT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CaChepFinal3-HQT', FILENAME = N'C:\Users\JackieLeIV\CaChepFinal3-HQT.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CaChepFinal3-HQT_log', FILENAME = N'C:\Users\JackieLeIV\CaChepFinal3-HQT_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CaChepFinal3-HQT] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CaChepFinal3-HQT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CaChepFinal3-HQT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET ARITHABORT OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET  MULTI_USER 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CaChepFinal3-HQT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CaChepFinal3-HQT] SET QUERY_STORE = OFF
GO
USE [CaChepFinal3-HQT]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [CaChepFinal3-HQT]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetNgayNhanDatPhong]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fnGetNgayNhanDatPhong]()
 RETURNS datetime2(7) 
 BEGIN
    RETURN (select ThoiGianNhanPhongDuKien
    from DatPhongs
    WHERE Id=@@IDENTITY)
END;
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetNgayTraDatPhong]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fnGetNgayTraDatPhong]()
 RETURNS datetime2(7) 
 BEGIN
    RETURN (select ThoiGianTraPhongDuKien
    from DatPhongs
    WHERE Id=@@IDENTITY)
END;
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetValueDatPhongHeap]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fnGetValueDatPhongHeap](@Vitriinput int =0)
 RETURNS int 
 BEGIN
    RETURN (SELECT PhongId
    FROM ChiTietDatPhongHeaps
    ORDER BY PhongId
			OFFSET @Vitriinput ROWS 
			FETCH NEXT 1 ROWS ONLY)
END;
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetValueDichVuHeap]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fnGetValueDichVuHeap](@Vitriinput int =0)
 RETURNS int 
 BEGIN
    RETURN (SELECT DichVuId
    FROM ChiTietDichVuDatPhongHeaps
    ORDER BY DichVuId
			OFFSET @Vitriinput ROWS 
			FETCH NEXT 1 ROWS ONLY)
END;
GO
/****** Object:  UserDefinedFunction [dbo].[fnSoLuongDichVuDat]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fnSoLuongDichVuDat]()
 RETURNS int 
 BEGIN
    RETURN (select count(DichVuId)[SoLuongP]
    from ChiTietDichVuDatPhongHeaps)
END;
GO
/****** Object:  UserDefinedFunction [dbo].[fnSoLuongPhongDat]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fnSoLuongPhongDat]()
 RETURNS int 
 BEGIN
    RETURN (select count(PhongId)[SoLuongP]
    from ChiTietDatPhongHeaps)
END;
GO
/****** Object:  UserDefinedFunction [dbo].[fnTongTienDichVuByDatPhongId]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fnTongTienDichVuByDatPhongId]( @IdDatPhong int =0)
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
GO
/****** Object:  UserDefinedFunction [dbo].[fnTongTienPhongByDatPhongId]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create FUNCTION [dbo].[fnTongTienPhongByDatPhongId]( @IdDatPhong int =0)
 RETURNS money 
 BEGIN
    RETURN ( select sum(b.Price)
    from ChiTietDatPhongs a, Phongs  b
    where DatPhongId =@IdDatPhong
        and a.PhongId=b.Id )
END;
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDatPhongHeaps]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDatPhongHeaps](
	[PhongId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDatPhongs]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDatPhongs](
	[ThoiGian] [datetime2](7) NOT NULL,
	[DatPhongId] [int] NOT NULL,
	[PhongId] [int] NOT NULL,
	[TrangThaiId] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietDatPhongs] PRIMARY KEY CLUSTERED 
(
	[ThoiGian] ASC,
	[DatPhongId] ASC,
	[PhongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDichVuDatPhongHeaps]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDichVuDatPhongHeaps](
	[DichVuId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDichVuDatPhongs]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDichVuDatPhongs](
	[DatPhongId] [int] NOT NULL,
	[DichVuId] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietDichVuDatPhongs] PRIMARY KEY CLUSTERED 
(
	[DatPhongId] ASC,
	[DichVuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChuongTrinhs]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuongTrinhs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ChuongTrinhName] [nvarchar](max) NOT NULL,
	[TiLeThayDoiGia] [int] NOT NULL,
	[IsTang] [bit] NOT NULL,
 CONSTRAINT [PK_ChuongTrinhs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DatPhongs]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatPhongs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenNguoiDat] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Cmnd] [nvarchar](max) NULL,
	[Sdt] [nvarchar](max) NULL,
	[TienDatCoc] [money] NOT NULL,
	[ThoiGianNhanPhongDuKien] [datetime2](7) NOT NULL,
	[ThoiGianTraPhongDuKien] [datetime2](7) NOT NULL,
	[TongTien] [money] NOT NULL,
 CONSTRAINT [PK_DatPhongs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DichVus]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DichVuName] [nvarchar](max) NOT NULL,
	[ShortDescription] [nvarchar](max) NULL,
	[Price] [money] NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[InStock] [int] NULL,
	[LoaiDvid] [int] NOT NULL,
 CONSTRAINT [PK_DichVus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HinhPhongs]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HinhPhongs](
	[HinhId] [int] IDENTITY(1,1) NOT NULL,
	[PhongId] [int] NOT NULL,
	[HinhUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_HinhPhongs] PRIMARY KEY CLUSTERED 
(
	[HinhId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiDichVus]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiDichVus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoaiDichVuName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_LoaiDichVus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiPhongs]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiPhongs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoaiPhongName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_LoaiPhongs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phongs]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phongs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PhongName] [nvarchar](max) NOT NULL,
	[ShortDescription] [nvarchar](max) NULL,
	[Price] [money] NOT NULL,
	[LoaiPhongId] [int] NULL,
	[ChuongTrinhId] [int] NULL,
	[HinhUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Phongs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrangThais]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThais](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrangThaiName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TrangThais] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'3.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191212155858_ver1', N'3.0.0')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'20dd3466-ed49-4f4e-8f39-ae1f8dcfa956', N'Admins', N'ADMINS', N'338e0917-7349-498b-b8f6-b45043ecac07')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c55b6c5d-11ca-419a-8548-f76fc11f8742', N'Super Admin', N'SUPER ADMIN', N'd96f3fe9-7716-4093-81ce-9f793fe858d5')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ecf78dd7-0c73-4b17-a583-cac53b73d6e4', N'c55b6c5d-11ca-419a-8548-f76fc11f8742')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Discriminator]) VALUES (N'ecf78dd7-0c73-4b17-a583-cac53b73d6e4', N'phuocnglt@gmail.com', N'PHUOCNGLT@GMAIL.COM', N'phuocnglt@gmail.com', N'PHUOCNGLT@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEEgig8ZzxId5BDpCKORHBK0QKxP08+kXBpjExDtj6kEqvcR6L/WtoHiBnNNkYjENQg==', N'XJSAFZXU2ULEXWQDP3P7G6MQ2G5ROIH5', N'38de616c-3f4d-41ca-821d-f273322dc047', NULL, 0, 0, NULL, 1, 0, N'Nguyen Duy Phuoc', N'AccountSys')
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-12-03T00:00:00.0000000' AS DateTime2), 2, 3, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-12-03T00:00:00.0000000' AS DateTime2), 2, 4, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-12-04T00:00:00.0000000' AS DateTime2), 2, 3, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-12-04T00:00:00.0000000' AS DateTime2), 2, 4, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-12-05T00:00:00.0000000' AS DateTime2), 2, 3, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-12-05T00:00:00.0000000' AS DateTime2), 2, 4, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-12-06T00:00:00.0000000' AS DateTime2), 2, 3, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-12-06T00:00:00.0000000' AS DateTime2), 2, 4, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-12-14T00:00:00.0000000' AS DateTime2), 5, 1, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-12-15T00:00:00.0000000' AS DateTime2), 5, 1, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-12-23T00:00:00.0000000' AS DateTime2), 3, 5, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-12-23T00:00:00.0000000' AS DateTime2), 3, 6, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-12-24T00:00:00.0000000' AS DateTime2), 3, 5, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-12-24T00:00:00.0000000' AS DateTime2), 3, 6, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-12-25T00:00:00.0000000' AS DateTime2), 3, 5, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-12-25T00:00:00.0000000' AS DateTime2), 3, 6, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2020-12-23T00:00:00.0000000' AS DateTime2), 4, 2, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2020-12-23T00:00:00.0000000' AS DateTime2), 4, 3, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2020-12-23T00:00:00.0000000' AS DateTime2), 4, 4, 1)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-11-22T00:00:00.0000000' AS DateTime2), 1, 1, 3)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-11-22T00:00:00.0000000' AS DateTime2), 1, 2, 3)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-11-23T00:00:00.0000000' AS DateTime2), 1, 1, 3)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-11-23T00:00:00.0000000' AS DateTime2), 1, 2, 3)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-11-24T00:00:00.0000000' AS DateTime2), 1, 1, 3)
INSERT [dbo].[ChiTietDatPhongs] ([ThoiGian], [DatPhongId], [PhongId], [TrangThaiId]) VALUES (CAST(N'2019-11-24T00:00:00.0000000' AS DateTime2), 1, 2, 3)
INSERT [dbo].[ChiTietDichVuDatPhongs] ([DatPhongId], [DichVuId], [SoLuong]) VALUES (1, 1, 2)
INSERT [dbo].[ChiTietDichVuDatPhongs] ([DatPhongId], [DichVuId], [SoLuong]) VALUES (1, 2, 2)
SET IDENTITY_INSERT [dbo].[ChuongTrinhs] ON 

INSERT [dbo].[ChuongTrinhs] ([Id], [ChuongTrinhName], [TiLeThayDoiGia], [IsTang]) VALUES (1, N'notthing', 0, 0)
INSERT [dbo].[ChuongTrinhs] ([Id], [ChuongTrinhName], [TiLeThayDoiGia], [IsTang]) VALUES (2, N'Lễ Tình Nhân', 10, 1)
SET IDENTITY_INSERT [dbo].[ChuongTrinhs] OFF
SET IDENTITY_INSERT [dbo].[DatPhongs] ON 

INSERT [dbo].[DatPhongs] ([Id], [TenNguoiDat], [Address], [Cmnd], [Sdt], [TienDatCoc], [ThoiGianNhanPhongDuKien], [ThoiGianTraPhongDuKien], [TongTien]) VALUES (1, N'Nguyen Phuoc', N'149', N'281212911', N'0937536545', 50000.0000, CAST(N'2019-11-22T00:00:00.0000000' AS DateTime2), CAST(N'2019-11-24T00:00:00.0000000' AS DateTime2), 7000000.0000)
INSERT [dbo].[DatPhongs] ([Id], [TenNguoiDat], [Address], [Cmnd], [Sdt], [TienDatCoc], [ThoiGianNhanPhongDuKien], [ThoiGianTraPhongDuKien], [TongTien]) VALUES (2, N'Nguyen Truc', N'149', N'281212910', N'01264079973', 50000.0000, CAST(N'2019-12-03T00:00:00.0000000' AS DateTime2), CAST(N'2019-12-06T00:00:00.0000000' AS DateTime2), 4000000.0000)
INSERT [dbo].[DatPhongs] ([Id], [TenNguoiDat], [Address], [Cmnd], [Sdt], [TienDatCoc], [ThoiGianNhanPhongDuKien], [ThoiGianTraPhongDuKien], [TongTien]) VALUES (3, N'Phan Tuyen', N'22', N'281212915', N'01626364802', 50000.0000, CAST(N'2019-12-23T00:00:00.0000000' AS DateTime2), CAST(N'2019-12-25T00:00:00.0000000' AS DateTime2), 960000.0000)
INSERT [dbo].[DatPhongs] ([Id], [TenNguoiDat], [Address], [Cmnd], [Sdt], [TienDatCoc], [ThoiGianNhanPhongDuKien], [ThoiGianTraPhongDuKien], [TongTien]) VALUES (4, N'Tenkh', N'DiaChi', N'CMND', N'SDT', 10000.0000, CAST(N'2020-12-23T00:00:00.0000000' AS DateTime2), CAST(N'2020-12-23T00:00:00.0000000' AS DateTime2), 300000.0000)
INSERT [dbo].[DatPhongs] ([Id], [TenNguoiDat], [Address], [Cmnd], [Sdt], [TienDatCoc], [ThoiGianNhanPhongDuKien], [ThoiGianTraPhongDuKien], [TongTien]) VALUES (5, N'Nguyen Duy Phuoc', N'149 yersin', N'281212914', N'0937536545', 0.0000, CAST(N'2019-12-14T00:00:00.0000000' AS DateTime2), CAST(N'2019-12-15T00:00:00.0000000' AS DateTime2), 300000.0000)
SET IDENTITY_INSERT [dbo].[DatPhongs] OFF
SET IDENTITY_INSERT [dbo].[DichVus] ON 

INSERT [dbo].[DichVus] ([Id], [DichVuName], [ShortDescription], [Price], [ImageUrl], [InStock], [LoaiDvid]) VALUES (1, N'NuocTangLuc', NULL, 15000.0000, NULL, 100, 1)
INSERT [dbo].[DichVus] ([Id], [DichVuName], [ShortDescription], [Price], [ImageUrl], [InStock], [LoaiDvid]) VALUES (2, N'NuocSuoi', NULL, 15000.0000, NULL, 100, 1)
SET IDENTITY_INSERT [dbo].[DichVus] OFF
SET IDENTITY_INSERT [dbo].[LoaiDichVus] ON 

INSERT [dbo].[LoaiDichVus] ([Id], [LoaiDichVuName], [Description]) VALUES (1, N'Thuc An', N'notthing')
INSERT [dbo].[LoaiDichVus] ([Id], [LoaiDichVuName], [Description]) VALUES (2, N'Nuoc Uong', N'notthing')
SET IDENTITY_INSERT [dbo].[LoaiDichVus] OFF
SET IDENTITY_INSERT [dbo].[LoaiPhongs] ON 

INSERT [dbo].[LoaiPhongs] ([Id], [LoaiPhongName]) VALUES (1, N'Phong Don')
INSERT [dbo].[LoaiPhongs] ([Id], [LoaiPhongName]) VALUES (2, N'Phong Doi')
INSERT [dbo].[LoaiPhongs] ([Id], [LoaiPhongName]) VALUES (3, N'twin')
SET IDENTITY_INSERT [dbo].[LoaiPhongs] OFF
SET IDENTITY_INSERT [dbo].[Phongs] ON 

INSERT [dbo].[Phongs] ([Id], [PhongName], [ShortDescription], [Price], [LoaiPhongId], [ChuongTrinhId], [HinhUrl]) VALUES (1, N'A101', N'notthing', 150000.0000, 1, 1, N'\images\RoomImages\1.jpg')
INSERT [dbo].[Phongs] ([Id], [PhongName], [ShortDescription], [Price], [LoaiPhongId], [ChuongTrinhId], [HinhUrl]) VALUES (2, N'A102', N'notthing', 150000.0000, 1, 1, N'\images\RoomImages\2.jpg')
INSERT [dbo].[Phongs] ([Id], [PhongName], [ShortDescription], [Price], [LoaiPhongId], [ChuongTrinhId], [HinhUrl]) VALUES (3, N'A103', N'notthing', 150000.0000, 2, 1, N'\images\RoomImages\3.jpg')
INSERT [dbo].[Phongs] ([Id], [PhongName], [ShortDescription], [Price], [LoaiPhongId], [ChuongTrinhId], [HinhUrl]) VALUES (4, N'A104', N'notthing', 0.0000, 2, 1, N'\images\RoomImages\4.jpg')
INSERT [dbo].[Phongs] ([Id], [PhongName], [ShortDescription], [Price], [LoaiPhongId], [ChuongTrinhId], [HinhUrl]) VALUES (5, N'A105', N'notthing', 150000.0000, 1, 1, N'\images\RoomImages\5.jpg')
INSERT [dbo].[Phongs] ([Id], [PhongName], [ShortDescription], [Price], [LoaiPhongId], [ChuongTrinhId], [HinhUrl]) VALUES (6, N'A106', N'notthing', 150000.0000, 2, 1, N'\images\RoomImages\6.jpg')
INSERT [dbo].[Phongs] ([Id], [PhongName], [ShortDescription], [Price], [LoaiPhongId], [ChuongTrinhId], [HinhUrl]) VALUES (7, N'A107', N'notthing', 150000.0000, 2, 1, N'\images\RoomImages\7.jpg')
INSERT [dbo].[Phongs] ([Id], [PhongName], [ShortDescription], [Price], [LoaiPhongId], [ChuongTrinhId], [HinhUrl]) VALUES (8, N'A108', N'notthing', 150000.0000, 2, 1, N'\images\RoomImages\8.jpg')
INSERT [dbo].[Phongs] ([Id], [PhongName], [ShortDescription], [Price], [LoaiPhongId], [ChuongTrinhId], [HinhUrl]) VALUES (9, N'A109', N'123', 1650000.0000, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[Phongs] OFF
SET IDENTITY_INSERT [dbo].[TrangThais] ON 

INSERT [dbo].[TrangThais] ([Id], [TrangThaiName]) VALUES (1, N'Chưa Nhận')
INSERT [dbo].[TrangThais] ([Id], [TrangThaiName]) VALUES (2, N'Đã Nhận')
INSERT [dbo].[TrangThais] ([Id], [TrangThaiName]) VALUES (3, N'Đã Thanh Toán')
SET IDENTITY_INSERT [dbo].[TrangThais] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 13-Dec-19 1:17:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 13-Dec-19 1:17:18 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 13-Dec-19 1:17:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 13-Dec-19 1:17:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 13-Dec-19 1:17:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 13-Dec-19 1:17:18 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 13-Dec-19 1:17:18 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ChiTietDatPhongs_DatPhongId]    Script Date: 13-Dec-19 1:17:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_ChiTietDatPhongs_DatPhongId] ON [dbo].[ChiTietDatPhongs]
(
	[DatPhongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ChiTietDatPhongs_PhongId]    Script Date: 13-Dec-19 1:17:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_ChiTietDatPhongs_PhongId] ON [dbo].[ChiTietDatPhongs]
(
	[PhongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ChiTietDatPhongs_TrangThaiId]    Script Date: 13-Dec-19 1:17:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_ChiTietDatPhongs_TrangThaiId] ON [dbo].[ChiTietDatPhongs]
(
	[TrangThaiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ChiTietDichVuDatPhongs_DichVuId]    Script Date: 13-Dec-19 1:17:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_ChiTietDichVuDatPhongs_DichVuId] ON [dbo].[ChiTietDichVuDatPhongs]
(
	[DichVuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DichVus_LoaiDvid]    Script Date: 13-Dec-19 1:17:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_DichVus_LoaiDvid] ON [dbo].[DichVus]
(
	[LoaiDvid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HinhPhongs_PhongId]    Script Date: 13-Dec-19 1:17:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_HinhPhongs_PhongId] ON [dbo].[HinhPhongs]
(
	[PhongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Phongs_ChuongTrinhId]    Script Date: 13-Dec-19 1:17:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Phongs_ChuongTrinhId] ON [dbo].[Phongs]
(
	[ChuongTrinhId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Phongs_LoaiPhongId]    Script Date: 13-Dec-19 1:17:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Phongs_LoaiPhongId] ON [dbo].[Phongs]
(
	[LoaiPhongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [Discriminator]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ChiTietDatPhongs]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDatPhongs_DatPhongs_DatPhongId] FOREIGN KEY([DatPhongId])
REFERENCES [dbo].[DatPhongs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietDatPhongs] CHECK CONSTRAINT [FK_ChiTietDatPhongs_DatPhongs_DatPhongId]
GO
ALTER TABLE [dbo].[ChiTietDatPhongs]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDatPhongs_Phongs_PhongId] FOREIGN KEY([PhongId])
REFERENCES [dbo].[Phongs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietDatPhongs] CHECK CONSTRAINT [FK_ChiTietDatPhongs_Phongs_PhongId]
GO
ALTER TABLE [dbo].[ChiTietDatPhongs]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDatPhongs_TrangThais_TrangThaiId] FOREIGN KEY([TrangThaiId])
REFERENCES [dbo].[TrangThais] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietDatPhongs] CHECK CONSTRAINT [FK_ChiTietDatPhongs_TrangThais_TrangThaiId]
GO
ALTER TABLE [dbo].[ChiTietDichVuDatPhongs]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDichVuDatPhongs_DatPhongs_DatPhongId] FOREIGN KEY([DatPhongId])
REFERENCES [dbo].[DatPhongs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietDichVuDatPhongs] CHECK CONSTRAINT [FK_ChiTietDichVuDatPhongs_DatPhongs_DatPhongId]
GO
ALTER TABLE [dbo].[ChiTietDichVuDatPhongs]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDichVuDatPhongs_DichVus_DichVuId] FOREIGN KEY([DichVuId])
REFERENCES [dbo].[DichVus] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietDichVuDatPhongs] CHECK CONSTRAINT [FK_ChiTietDichVuDatPhongs_DichVus_DichVuId]
GO
ALTER TABLE [dbo].[DichVus]  WITH CHECK ADD  CONSTRAINT [FK_DichVus_LoaiDichVus_LoaiDvid] FOREIGN KEY([LoaiDvid])
REFERENCES [dbo].[LoaiDichVus] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DichVus] CHECK CONSTRAINT [FK_DichVus_LoaiDichVus_LoaiDvid]
GO
ALTER TABLE [dbo].[HinhPhongs]  WITH CHECK ADD  CONSTRAINT [FK_HinhPhong_Phongs] FOREIGN KEY([PhongId])
REFERENCES [dbo].[Phongs] ([Id])
GO
ALTER TABLE [dbo].[HinhPhongs] CHECK CONSTRAINT [FK_HinhPhong_Phongs]
GO
ALTER TABLE [dbo].[Phongs]  WITH CHECK ADD  CONSTRAINT [FK_Phongs_ChuongTrinh] FOREIGN KEY([ChuongTrinhId])
REFERENCES [dbo].[ChuongTrinhs] ([Id])
GO
ALTER TABLE [dbo].[Phongs] CHECK CONSTRAINT [FK_Phongs_ChuongTrinh]
GO
ALTER TABLE [dbo].[Phongs]  WITH CHECK ADD  CONSTRAINT [FK_Phongs_LoaiPhongs] FOREIGN KEY([LoaiPhongId])
REFERENCES [dbo].[LoaiPhongs] ([Id])
GO
ALTER TABLE [dbo].[Phongs] CHECK CONSTRAINT [FK_Phongs_LoaiPhongs]
GO
/****** Object:  StoredProcedure [dbo].[AddChiTietDatPhongHeap]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE [dbo].[AddChiTietDatPhongHeap]
    @Id  int  = 0
AS
insert ChiTietDatPhongHeaps
values
    (@Id)

GO
/****** Object:  StoredProcedure [dbo].[AddChiTietDichVuHeap]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddChiTietDichVuHeap]
    @Id int  = 0
AS
insert ChiTietDichVuDatPhongHeaps
values
    (@Id)

GO
/****** Object:  StoredProcedure [dbo].[AddDatPhong]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
    DELETE FROM ChiTietDatPhongHeaps
    DELETE FROM ChiTietDichVuDatPhongHeaps
	print 'transaction committed';
END TRY

begin catch 
 print 'error when inserting, rolling back transaction';

 rollback tran; 
end catch
end
GO
/****** Object:  StoredProcedure [dbo].[GetChiTietDatPhong_ByIdDatPhong]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetChiTietDatPhong_ByIdDatPhong]
    @Id int  = 0
AS

SELECT *
FROM ChiTietDatPhongs
WHERE DatPhongId =@Id 
GO
/****** Object:  StoredProcedure [dbo].[GetChiTietDatPhongBy_IdDatPhong_IdPhong_ThoiGian]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetChiTietDatPhongBy_IdDatPhong_IdPhong_ThoiGian]
    @DatPhongId  int = 0,
    @PhongId  int  = 0

AS

SELECT *
from ChiTietDatPhongs
where ChiTietDatPhongs.DatPhongId= @DatPhongId
    and PhongId = @PhongId
    and ThoiGian >=  (SELECT CAST(getdate() AS date))
GO
/****** Object:  StoredProcedure [dbo].[GetChiTietDichVuByIdPhong]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE [dbo].[GetChiTietDichVuByIdPhong]
    @Id  int = 0
AS
SELECT a.DichVuId, a.DatPhongId, a.SoLuong, b.Price, b.DichVuName, TongTien= a.SoLuong*b.Price
from ChiTietDichVuDatPhongs a, DichVus b
WHERE a.DatPhongId= @Id
    and a.DichVuId=b.Id
GO
/****** Object:  StoredProcedure [dbo].[GetOneDatPhongById]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE [dbo].[GetOneDatPhongById]
    @Id  int  = 0
AS
SELECT *
FROM DatPhongs
WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[GetOneDichVuById]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetOneDichVuById]
    @Id int =0
AS
SELECT *
from DichVus
where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[GetOnePhongById]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOnePhongById]
    @Id int =0
AS
SELECT *
from Phongs
where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[GetOneTrangThaiById]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetOneTrangThaiById]
    @Id  int = 0
AS
-- body of the stored procedure
SELECT *
FROM TrangThais
where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[GetSortedDatPhongsBySomthing]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetSortedDatPhongsBySomthing]
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
/****** Object:  StoredProcedure [dbo].[SearchDatPhongsBySomthing]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SearchDatPhongsBySomthing]
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
GO
/****** Object:  StoredProcedure [dbo].[spAddChuongTrinh]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spAddChuongTrinh]
    @Name	nvarchar(max)	,
    @Tile int,
    @Tang bit
as
begin
    insert ChuongTrinhs
    values
        (@Name, @Tile, @Tang)
end	;
GO
/****** Object:  StoredProcedure [dbo].[spAddLoaiDichVu]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spAddLoaiDichVu]
    @Ten	nvarchar(50)	,
    @mota nvarchar(max)='notthing'
as
begin
    insert LoaiDichVus
    values
        (@Ten, @mota)
end
GO
/****** Object:  StoredProcedure [dbo].[spAddLoaiPhong]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spAddLoaiPhong]
    @Ten	nvarchar(50)
as
begin
    insert LoaiPhongs
    values
        (@Ten)
end
GO
/****** Object:  StoredProcedure [dbo].[spAddPhong]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spAddPhong]
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
GO
/****** Object:  StoredProcedure [dbo].[spAddTrangThai]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spAddTrangThai]
    @Name	nvarchar(max)
as
begin
    insert TrangThais
    values
        (@Name)
end	;
GO
/****** Object:  StoredProcedure [dbo].[spCapNhatTongTienOnePhieuDatPhong]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spCapNhatTongTienOnePhieuDatPhong]
    @Id int =0
as
BEGIN
    IF(@Id is not null)
        UPDATE DatPhongs
        SET TongTien = dbo.fnTongTienPhongByDatPhongId(@Id) --+ dbo.fnTongTienDichVuByDatPhongId(1)
        WHERE Id=@Id;
    ELSE
   THROW 50001, 'không tồn tại id', 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[spDeleteChuongTrinh]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spDeleteChuongTrinh]
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
GO
/****** Object:  StoredProcedure [dbo].[spDeleteLoaiDichVu]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spDeleteLoaiDichVu]
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
GO
/****** Object:  StoredProcedure [dbo].[spDeleteLoaiPhong]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spDeleteLoaiPhong]
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
GO
/****** Object:  StoredProcedure [dbo].[spDeletePhong]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spDeletePhong]
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
GO
/****** Object:  StoredProcedure [dbo].[spDeleteTrangThai]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spDeleteTrangThai]
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
GO
/****** Object:  StoredProcedure [dbo].[spEditChuongTrinh]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spEditChuongTrinh]
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
GO
/****** Object:  StoredProcedure [dbo].[spEditDichVu]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spEditDichVu]
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
GO
/****** Object:  StoredProcedure [dbo].[spEditLoaiDichVu]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spEditLoaiDichVu]
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
GO
/****** Object:  StoredProcedure [dbo].[spEditLoaiPhong]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spEditLoaiPhong]
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
GO
/****** Object:  StoredProcedure [dbo].[spEditPhong]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spEditPhong]
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
GO
/****** Object:  StoredProcedure [dbo].[spEditTrangThai]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spEditTrangThai]
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
GO
/****** Object:  StoredProcedure [dbo].[spGetChuongTrinh]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetChuongTrinh]
as
begin
    Select *
    from ChuongTrinhs
end;
GO
/****** Object:  StoredProcedure [dbo].[spGetDichVu]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetDichVu]
as
begin
    Select a.Id, a.DichVuName, a.ShortDescription, a.Price, a.ImageUrl, a.InStock, a.LoaiDvid
, b.LoaiDichVuName
    from DichVus a join LoaiDichVus b
        on a.LoaiDvid=b.Id
end;
GO
/****** Object:  StoredProcedure [dbo].[spGetLoaiDichVu]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetLoaiDichVu]
as
begin
    Select *
    from LoaiDichVus
end;
GO
/****** Object:  StoredProcedure [dbo].[spGetLoaiPhong]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetLoaiPhong]
as
begin
    Select *
    from LoaiPhongs
end;
GO
/****** Object:  StoredProcedure [dbo].[spGetNameChuongTrinhById]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetNameChuongTrinhById]
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
GO
/****** Object:  StoredProcedure [dbo].[spGetNameLoaiPhongById]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetNameLoaiPhongById]
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
GO
/****** Object:  StoredProcedure [dbo].[spGetOneByIdChuongTrinh]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetOneByIdChuongTrinh]
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
GO
/****** Object:  StoredProcedure [dbo].[spGetOneByIdDichVu]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetOneByIdDichVu]
    @id int
as
begin
    Select a.Id, a.DichVuName, a.ShortDescription, a.Price, a.ImageUrl, a.InStock
, b.LoaiDichVuName
    from DichVus a join LoaiDichVus b
        on a.LoaiDvid=b.Id
    where a.Id=@id
end;
GO
/****** Object:  StoredProcedure [dbo].[spGetOneByIdLoaiDichVu]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetOneByIdLoaiDichVu]
    @id int
as
begin
    Select *
    from LoaiDichVus
    where Id=@id
end;
GO
/****** Object:  StoredProcedure [dbo].[spGetOneByIdLoaiPhong]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetOneByIdLoaiPhong]
    @id int
as
begin
    Select *
    from LoaiPhongs
    where Id=@id
end;

exec spGetLoaiPhong
GO
/****** Object:  StoredProcedure [dbo].[spGetOneByIdPhong]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetOneByIdPhong]
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
GO
/****** Object:  StoredProcedure [dbo].[spGetOneByIdTrangThai]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetOneByIdTrangThai]
    @id int
as
begin
    Select *
    from TrangThais
    where Id=@id
end;
GO
/****** Object:  StoredProcedure [dbo].[spGetPhong]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetPhong]
as
begin
    Select b.Id, b.PhongName, b.ShortDescription, b.Price, a.LoaiPhongName, b.ChuongTrinhId, c.ChuongTrinhName, b.LoaiPhongId, b.HinhUrl
    from LoaiPhongs a join Phongs b on a.Id=b.LoaiPhongId
        join ChuongTrinhs c on
c.Id=b.ChuongTrinhId
end;
exec spGetPhong
GO
/****** Object:  StoredProcedure [dbo].[spGetTrangThai]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetTrangThai]
as
begin
    Select *
    from TrangThais
end;
GO
/****** Object:  StoredProcedure [dbo].[TimPhongDangDcDat]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TimPhongDangDcDat]
    @ThoiGianNhan DATETIME = NULL,
    @ThoiGianTra DATETIME = NULL
AS
-- body of the stored procedure
SELECT distinct PhongId
FROM
    ChiTietDatPhongs
WHERE @ThoiGianNhan <=ThoiGian and ThoiGian <=@ThoiGianTra   
    
    
GO
/****** Object:  StoredProcedure [dbo].[TimPhongLienTuc]    Script Date: 13-Dec-19 1:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TimPhongLienTuc]
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
USE [master]
GO
ALTER DATABASE [CaChepFinal3-HQT] SET  READ_WRITE 
GO
