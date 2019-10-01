USE [master]
GO
/****** Object:  Database [Cosmetic_SM]    Script Date: 01-Oct-19 7:26:48 PM ******/
CREATE DATABASE [Cosmetic_SM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cosmetic_SM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Cosmetic_SM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cosmetic_SM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Cosmetic_SM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Cosmetic_SM] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cosmetic_SM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cosmetic_SM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cosmetic_SM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cosmetic_SM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Cosmetic_SM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cosmetic_SM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET RECOVERY FULL 
GO
ALTER DATABASE [Cosmetic_SM] SET  MULTI_USER 
GO
ALTER DATABASE [Cosmetic_SM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cosmetic_SM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cosmetic_SM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cosmetic_SM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cosmetic_SM] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Cosmetic_SM', N'ON'
GO
ALTER DATABASE [Cosmetic_SM] SET QUERY_STORE = OFF
GO
USE [Cosmetic_SM]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 01-Oct-19 7:26:49 PM ******/
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
/****** Object:  Table [dbo].[Brands]    Script Date: 01-Oct-19 7:26:49 PM ******/
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
/****** Object:  Table [dbo].[Customers]    Script Date: 01-Oct-19 7:26:49 PM ******/
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
/****** Object:  Table [dbo].[Employees]    Script Date: 01-Oct-19 7:26:49 PM ******/
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
/****** Object:  Table [dbo].[Forms]    Script Date: 01-Oct-19 7:26:49 PM ******/
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
/****** Object:  Table [dbo].[Forms_Produces]    Script Date: 01-Oct-19 7:26:49 PM ******/
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
/****** Object:  Table [dbo].[GroupPurpose]    Script Date: 01-Oct-19 7:26:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupPurpose](
	[GroupPurposeID] [int] IDENTITY(1,1) NOT NULL,
	[GroupPurposeName] [nvarchar](1000) NOT NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_GroupPurpose] PRIMARY KEY CLUSTERED 
(
	[GroupPurposeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 01-Oct-19 7:26:49 PM ******/
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
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purpose]    Script Date: 01-Oct-19 7:26:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purpose](
	[PurposeID] [int] IDENTITY(1,1) NOT NULL,
	[PurposeName] [nvarchar](1000) NOT NULL,
	[Description] [ntext] NULL,
	[GroupPurposeID] [int] NULL,
 CONSTRAINT [PK_Purpose] PRIMARY KEY CLUSTERED 
(
	[PurposeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
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
USE [master]
GO
ALTER DATABASE [Cosmetic_SM] SET  READ_WRITE 
GO
