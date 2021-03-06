USE [master]
GO
/****** Object:  Database [restaurant]    Script Date: 8/11/2017 2:50:34 PM ******/
CREATE DATABASE [restaurant]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'restaurant', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\restaurant.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'restaurant_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\restaurant_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [restaurant] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [restaurant].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [restaurant] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [restaurant] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [restaurant] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [restaurant] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [restaurant] SET ARITHABORT OFF 
GO
ALTER DATABASE [restaurant] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [restaurant] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [restaurant] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [restaurant] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [restaurant] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [restaurant] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [restaurant] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [restaurant] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [restaurant] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [restaurant] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [restaurant] SET  DISABLE_BROKER 
GO
ALTER DATABASE [restaurant] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [restaurant] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [restaurant] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [restaurant] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [restaurant] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [restaurant] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [restaurant] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [restaurant] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [restaurant] SET  MULTI_USER 
GO
ALTER DATABASE [restaurant] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [restaurant] SET DB_CHAINING OFF 
GO
ALTER DATABASE [restaurant] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [restaurant] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [restaurant]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 8/11/2017 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[AreaID] [int] IDENTITY(1,1) NOT NULL,
	[Area] [nvarchar](50) NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[AreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Division]    Script Date: 8/11/2017 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Division](
	[EmployeeID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Division] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC,
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 8/11/2017 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Phone] [numeric](13, 0) NOT NULL,
	[TypeID] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Formula]    Script Date: 8/11/2017 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formula](
	[ProductParentID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Number] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Formula] PRIMARY KEY CLUSTERED 
(
	[ProductParentID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 8/11/2017 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[ExportDate] [date] NOT NULL,
	[TotalPrice] [money] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[TableID] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 8/11/2017 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[Prices] [money] NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 8/11/2017 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Prices] [money] NOT NULL,
	[ExportPrice] [money] NOT NULL,
	[AreaID] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductDetail]    Script Date: 8/11/2017 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetail](
	[OrderDetailID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Prices] [money] NOT NULL,
 CONSTRAINT [PK_ProductDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Table]    Script Date: 8/11/2017 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[TableID] [int] IDENTITY(1,1) NOT NULL,
	[Area] [nvarchar](50) NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[TableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TypeOfEmployee]    Script Date: 8/11/2017 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfEmployee](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[NameOfType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TypeOfEmployee] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Area] ON 

INSERT [dbo].[Area] ([AreaID], [Area], [Number]) VALUES (1, N'Dãy 1', 5)
INSERT [dbo].[Area] ([AreaID], [Area], [Number]) VALUES (2, N'Dãy 2', 8)
INSERT [dbo].[Area] ([AreaID], [Area], [Number]) VALUES (3, N'Dãy 3', 10)
INSERT [dbo].[Area] ([AreaID], [Area], [Number]) VALUES (4, N'Dãy 4', 90)
INSERT [dbo].[Area] ([AreaID], [Area], [Number]) VALUES (5, N'Dãy 5', 0)
INSERT [dbo].[Area] ([AreaID], [Area], [Number]) VALUES (6, N'Dãy 6', 100)
SET IDENTITY_INSERT [dbo].[Area] OFF
INSERT [dbo].[Division] ([EmployeeID], [OrderID], [Type]) VALUES (1, 3, N'Bán hàng')
INSERT [dbo].[Division] ([EmployeeID], [OrderID], [Type]) VALUES (2, 6, N'Thu tiền')
INSERT [dbo].[Division] ([EmployeeID], [OrderID], [Type]) VALUES (3, 7, N'Quản lí')
INSERT [dbo].[Division] ([EmployeeID], [OrderID], [Type]) VALUES (4, 8, N'Phục vụ')
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [Username], [Password], [FirstName], [LastName], [Gender], [Address], [Phone], [TypeID]) VALUES (1, N'Dat', N'123                                               ', N'Đạt', N'Trần', 1, N'29 Phước Long B, Quận 9, HCM', CAST(1656746404 AS Numeric(13, 0)), 2)
INSERT [dbo].[Employee] ([EmployeeID], [Username], [Password], [FirstName], [LastName], [Gender], [Address], [Phone], [TypeID]) VALUES (2, N'An', N'123                                               ', N'Ân', N'Nguyễn', 0, N'77 Võ Thị Sáu, Phan Rang, Ninh Thuận', CAST(1213659875 AS Numeric(13, 0)), 5)
INSERT [dbo].[Employee] ([EmployeeID], [Username], [Password], [FirstName], [LastName], [Gender], [Address], [Phone], [TypeID]) VALUES (3, N'Nhi', N'123                                               ', N'Nhi', N'Trương', 1, N'22 Trần Quốc Tuấn, Bình Thạnh, HCM', CAST(1359637542 AS Numeric(13, 0)), 6)
INSERT [dbo].[Employee] ([EmployeeID], [Username], [Password], [FirstName], [LastName], [Gender], [Address], [Phone], [TypeID]) VALUES (4, N'Quang', N'123                                               ', N'Quang', N'Nguyễn', 1, N'16 Đinh Tiên Hoàng, Thủ Đức, HCM', CAST(1943685482 AS Numeric(13, 0)), 3)
INSERT [dbo].[Employee] ([EmployeeID], [Username], [Password], [FirstName], [LastName], [Gender], [Address], [Phone], [TypeID]) VALUES (5, N'Hà', N'123                                               ', N'Hà', N'Hồ', 0, N'10 Trần Như Đạt, Quận 1, HCM', CAST(1369787546 AS Numeric(13, 0)), 1)
INSERT [dbo].[Employee] ([EmployeeID], [Username], [Password], [FirstName], [LastName], [Gender], [Address], [Phone], [TypeID]) VALUES (7, N'Đào', N'123                                               ', N'Đào', N'Hồ', 1, N'10 Điện Biên Phủ, Quận Như Đạt, HCM', CAST(1365987569 AS Numeric(13, 0)), 4)
SET IDENTITY_INSERT [dbo].[Employee] OFF
INSERT [dbo].[Formula] ([ProductParentID], [ProductID], [Number]) VALUES (4, 3, CAST(0.10 AS Decimal(18, 2)))
INSERT [dbo].[Formula] ([ProductParentID], [ProductID], [Number]) VALUES (4, 6, CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[Formula] ([ProductParentID], [ProductID], [Number]) VALUES (8, 1, CAST(0.01 AS Decimal(18, 2)))
INSERT [dbo].[Formula] ([ProductParentID], [ProductID], [Number]) VALUES (8, 9, CAST(0.30 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [ExportDate], [TotalPrice], [Type], [TableID]) VALUES (3, CAST(0x1D3D0B00 AS Date), 300000.0000, N'Hóa đơn bán', 1)
INSERT [dbo].[Order] ([OrderID], [ExportDate], [TotalPrice], [Type], [TableID]) VALUES (6, CAST(0x1E3D0B00 AS Date), 500000.0000, N'Hóa đơn mua', NULL)
INSERT [dbo].[Order] ([OrderID], [ExportDate], [TotalPrice], [Type], [TableID]) VALUES (7, CAST(0x1F3D0B00 AS Date), 1000000.0000, N'Hóa đơn bán', 2)
INSERT [dbo].[Order] ([OrderID], [ExportDate], [TotalPrice], [Type], [TableID]) VALUES (8, CAST(0x203D0B00 AS Date), 598000.0000, N'Hóa đơn bán', 3)
INSERT [dbo].[Order] ([OrderID], [ExportDate], [TotalPrice], [Type], [TableID]) VALUES (9, CAST(0x213D0B00 AS Date), 864000.0000, N'Hóa đơn mua', NULL)
INSERT [dbo].[Order] ([OrderID], [ExportDate], [TotalPrice], [Type], [TableID]) VALUES (10, CAST(0x203D0B00 AS Date), 861000.0000, N'Hóa đơn bán', 1)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([OrderDetailID], [Number], [Prices], [OrderID], [ProductID]) VALUES (2, 2, 20000.0000, 3, 1)
INSERT [dbo].[OrderDetail] ([OrderDetailID], [Number], [Prices], [OrderID], [ProductID]) VALUES (3, 3, 50000.0000, 6, 2)
INSERT [dbo].[OrderDetail] ([OrderDetailID], [Number], [Prices], [OrderID], [ProductID]) VALUES (4, 4, 100000.0000, 7, 3)
INSERT [dbo].[OrderDetail] ([OrderDetailID], [Number], [Prices], [OrderID], [ProductID]) VALUES (5, 5, 65000.0000, 8, 5)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [Name], [Unit], [Prices], [ExportPrice], [AreaID]) VALUES (1, N'Muối', N'kg', 2000.0000, 1000.0000, 1)
INSERT [dbo].[Product] ([ProductID], [Name], [Unit], [Prices], [ExportPrice], [AreaID]) VALUES (2, N'Đường', N'kg', 15000.0000, 9000.0000, 2)
INSERT [dbo].[Product] ([ProductID], [Name], [Unit], [Prices], [ExportPrice], [AreaID]) VALUES (3, N'Cà chua', N'kg', 5000.0000, 2000.0000, 3)
INSERT [dbo].[Product] ([ProductID], [Name], [Unit], [Prices], [ExportPrice], [AreaID]) VALUES (4, N'Canh chua', N'tô', 30000.0000, 10000.0000, NULL)
INSERT [dbo].[Product] ([ProductID], [Name], [Unit], [Prices], [ExportPrice], [AreaID]) VALUES (5, N'Giá', N'kg', 100000.0000, 50000.0000, 5)
INSERT [dbo].[Product] ([ProductID], [Name], [Unit], [Prices], [ExportPrice], [AreaID]) VALUES (6, N'Me', N'kg', 20000.0000, 10000.0000, 6)
INSERT [dbo].[Product] ([ProductID], [Name], [Unit], [Prices], [ExportPrice], [AreaID]) VALUES (8, N'Sườn om', N'dĩa', 50000.0000, 20000.0000, NULL)
INSERT [dbo].[Product] ([ProductID], [Name], [Unit], [Prices], [ExportPrice], [AreaID]) VALUES (9, N'Thịt', N'kg', 300000.0000, 100000.0000, 4)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Table] ON 

INSERT [dbo].[Table] ([TableID], [Area]) VALUES (1, N'Bàn 1 - dãy 1')
INSERT [dbo].[Table] ([TableID], [Area]) VALUES (2, N'Bàn 1 - dãy 2')
INSERT [dbo].[Table] ([TableID], [Area]) VALUES (3, N'Bàn 1 - dãy 3')
INSERT [dbo].[Table] ([TableID], [Area]) VALUES (4, N'Bàn 1 - dãy 4')
INSERT [dbo].[Table] ([TableID], [Area]) VALUES (5, N'Bàn 2 - dãy 1')
INSERT [dbo].[Table] ([TableID], [Area]) VALUES (6, N'Bàn 3 - dãy 1')
INSERT [dbo].[Table] ([TableID], [Area]) VALUES (7, N'Bàn 4 - dãy 3')
INSERT [dbo].[Table] ([TableID], [Area]) VALUES (8, N'Bàn 2 - dãy 5')
INSERT [dbo].[Table] ([TableID], [Area]) VALUES (9, N'Bàn 6 - dãy 3')
SET IDENTITY_INSERT [dbo].[Table] OFF
SET IDENTITY_INSERT [dbo].[TypeOfEmployee] ON 

INSERT [dbo].[TypeOfEmployee] ([TypeID], [NameOfType]) VALUES (1, N'Nhân viên phục vụ')
INSERT [dbo].[TypeOfEmployee] ([TypeID], [NameOfType]) VALUES (2, N'Quản lí')
INSERT [dbo].[TypeOfEmployee] ([TypeID], [NameOfType]) VALUES (3, N'Nhân viên lễ tân')
INSERT [dbo].[TypeOfEmployee] ([TypeID], [NameOfType]) VALUES (4, N'Nhân viên thu ngân')
INSERT [dbo].[TypeOfEmployee] ([TypeID], [NameOfType]) VALUES (5, N'Nhân viên rửa chén')
INSERT [dbo].[TypeOfEmployee] ([TypeID], [NameOfType]) VALUES (6, N'Giám sát viên')
SET IDENTITY_INSERT [dbo].[TypeOfEmployee] OFF
ALTER TABLE [dbo].[Division]  WITH CHECK ADD  CONSTRAINT [FK_Division_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Division] CHECK CONSTRAINT [FK_Division_Employee]
GO
ALTER TABLE [dbo].[Division]  WITH CHECK ADD  CONSTRAINT [FK_Division_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[Division] CHECK CONSTRAINT [FK_Division_Order]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_TypeOfEmployee] FOREIGN KEY([TypeID])
REFERENCES [dbo].[TypeOfEmployee] ([TypeID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_TypeOfEmployee]
GO
ALTER TABLE [dbo].[Formula]  WITH CHECK ADD  CONSTRAINT [FK_Formula_Product] FOREIGN KEY([ProductParentID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Formula] CHECK CONSTRAINT [FK_Formula_Product]
GO
ALTER TABLE [dbo].[Formula]  WITH CHECK ADD  CONSTRAINT [FK_Formula_Product1] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Formula] CHECK CONSTRAINT [FK_Formula_Product1]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Table] FOREIGN KEY([TableID])
REFERENCES [dbo].[Table] ([TableID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Table]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Area] FOREIGN KEY([AreaID])
REFERENCES [dbo].[Area] ([AreaID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Area]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetail_OrderDetail] FOREIGN KEY([OrderDetailID])
REFERENCES [dbo].[OrderDetail] ([OrderDetailID])
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [FK_ProductDetail_OrderDetail]
GO
USE [master]
GO
ALTER DATABASE [restaurant] SET  READ_WRITE 
GO
