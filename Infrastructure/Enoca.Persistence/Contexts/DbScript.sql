USE [master]
GO
/****** Object:  Database [EnocaChallenge2]    Script Date: 14.04.2023 12:10:06 ******/
CREATE DATABASE [EnocaChallenge2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EnocaChallenge2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\EnocaChallenge2.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EnocaChallenge2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\EnocaChallenge2_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EnocaChallenge2] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EnocaChallenge2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EnocaChallenge2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET ARITHABORT OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EnocaChallenge2] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [EnocaChallenge2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EnocaChallenge2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EnocaChallenge2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EnocaChallenge2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EnocaChallenge2] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EnocaChallenge2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EnocaChallenge2] SET  MULTI_USER 
GO
ALTER DATABASE [EnocaChallenge2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EnocaChallenge2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EnocaChallenge2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EnocaChallenge2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [EnocaChallenge2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14.04.2023 12:10:07 ******/
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
/****** Object:  Table [dbo].[CarrierConfigurations]    Script Date: 14.04.2023 12:10:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarrierConfigurations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarrierMaxDesi] [int] NOT NULL,
	[CarrierMinDesi] [int] NOT NULL,
	[CarrierCost] [decimal](18, 2) NOT NULL,
	[CarrierId] [int] NOT NULL,
 CONSTRAINT [PK_CarrierConfigurations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CarrierReports]    Script Date: 14.04.2023 12:10:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarrierReports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarrierCost] [decimal](18, 2) NOT NULL,
	[CarrierReportDate] [datetime2](7) NOT NULL,
	[CarrierId] [int] NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CarrierReports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Carriers]    Script Date: 14.04.2023 12:10:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carriers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarrierName] [nvarchar](max) NOT NULL,
	[CarrierIsActive] [bit] NOT NULL,
	[CarrierPlusDesiCost] [int] NOT NULL,
 CONSTRAINT [PK_Carriers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 14.04.2023 12:10:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDesi] [int] NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[OrderCarrierCost] [decimal](18, 2) NOT NULL,
	[CarrierId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CarrierConfigurations] ON 

INSERT [dbo].[CarrierConfigurations] ([Id], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost], [CarrierId]) VALUES (1, 11, 1, CAST(10.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CarrierConfigurations] ([Id], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost], [CarrierId]) VALUES (2, 10, 2, CAST(20.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[CarrierConfigurations] ([Id], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost], [CarrierId]) VALUES (3, 8, 3, CAST(30.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[CarrierConfigurations] ([Id], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost], [CarrierId]) VALUES (4, 40, 4, CAST(8.00 AS Decimal(18, 2)), 4)
INSERT [dbo].[CarrierConfigurations] ([Id], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost], [CarrierId]) VALUES (5, 15, 5, CAST(15.00 AS Decimal(18, 2)), 5)
SET IDENTITY_INSERT [dbo].[CarrierConfigurations] OFF
SET IDENTITY_INSERT [dbo].[Carriers] ON 

INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost]) VALUES (1, N'Carrier1', 1, 1)
INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost]) VALUES (2, N'Carrier2', 1, 2)
INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost]) VALUES (3, N'Carrier3', 1, 3)
INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost]) VALUES (4, N'Carrier4', 0, 4)
INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost]) VALUES (5, N'Carrier5', 1, 5)
SET IDENTITY_INSERT [dbo].[Carriers] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId]) VALUES (1, 10, CAST(N'2023-04-14 11:44:04.3893627' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId]) VALUES (2, 1, CAST(N'2023-04-14 11:54:14.4928769' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId]) VALUES (3, 5, CAST(N'2023-04-14 11:55:07.8188047' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), 4)
INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId]) VALUES (4, 41, CAST(N'2023-04-14 11:57:46.0320156' AS DateTime2), CAST(12.00 AS Decimal(18, 2)), 4)
SET IDENTITY_INSERT [dbo].[Orders] OFF
/****** Object:  Index [IX_CarrierConfigurations_CarrierId]    Script Date: 14.04.2023 12:10:07 ******/
CREATE NONCLUSTERED INDEX [IX_CarrierConfigurations_CarrierId] ON [dbo].[CarrierConfigurations]
(
	[CarrierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CarrierReports_CarrierId]    Script Date: 14.04.2023 12:10:07 ******/
CREATE NONCLUSTERED INDEX [IX_CarrierReports_CarrierId] ON [dbo].[CarrierReports]
(
	[CarrierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_CarrierId]    Script Date: 14.04.2023 12:10:07 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_CarrierId] ON [dbo].[Orders]
(
	[CarrierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CarrierReports] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [OrderDate]
GO
ALTER TABLE [dbo].[CarrierConfigurations]  WITH CHECK ADD  CONSTRAINT [FK_CarrierConfigurations_Carriers_CarrierId] FOREIGN KEY([CarrierId])
REFERENCES [dbo].[Carriers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CarrierConfigurations] CHECK CONSTRAINT [FK_CarrierConfigurations_Carriers_CarrierId]
GO
ALTER TABLE [dbo].[CarrierReports]  WITH CHECK ADD  CONSTRAINT [FK_CarrierReports_Carriers_CarrierId] FOREIGN KEY([CarrierId])
REFERENCES [dbo].[Carriers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CarrierReports] CHECK CONSTRAINT [FK_CarrierReports_Carriers_CarrierId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Carriers_CarrierId] FOREIGN KEY([CarrierId])
REFERENCES [dbo].[Carriers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Carriers_CarrierId]
GO
USE [master]
GO
ALTER DATABASE [EnocaChallenge2] SET  READ_WRITE 
GO
