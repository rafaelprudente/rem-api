USE [rsm-dev]
GO

DBCC CHECKIDENT ('WorldRegions', RESEED, 0)
GO
DBCC CHECKIDENT ('CurrencyCodes', RESEED, 0)
GO
DBCC CHECKIDENT ('Countries', RESEED, 0)
GO

DELETE FROM [dbo].[WorldRegions]
GO
DELETE FROM [dbo].[CurrencyCodes]
GO
DELETE FROM [dbo].[Countries]
GO

-------------- DROP TABLES --------------
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/3/2021 10:27:59 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
/****** Object:  Table [dbo].[BusinessUnits]    Script Date: 10/3/2021 10:29:33 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BusinessUnits]') AND type in (N'U'))
DROP TABLE [dbo].[BusinessUnits]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 10/3/2021 10:30:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Companies]') AND type in (N'U'))
DROP TABLE [dbo].[Companies]
GO
/****** Object:  Table [dbo].[States]    Script Date: 10/3/2021 10:31:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[States]') AND type in (N'U'))
DROP TABLE [dbo].[States]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 10/3/2021 10:28:49 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Addresses]') AND type in (N'U'))
DROP TABLE [dbo].[Addresses]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 10/3/2021 10:29:59 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cities]') AND type in (N'U'))
DROP TABLE [dbo].[Cities]
GO
/****** Object:  Table [dbo].[CountryCurrencyCodes]    Script Date: 10/3/2021 10:31:07 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CountryCurrencyCodes]') AND type in (N'U'))
DROP TABLE [dbo].[CountryCurrencyCodes]
GO
/****** Object:  Table [dbo].[CurrencyCodes]    Script Date: 10/3/2021 10:31:07 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CurrencyCodes]') AND type in (N'U'))
DROP TABLE [dbo].[CurrencyCodes]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 10/3/2021 10:30:41 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Countries]') AND type in (N'U'))
DROP TABLE [dbo].[Countries]
GO
/****** Object:  Table [dbo].[WorldRegions]    Script Date: 10/3/2021 10:31:35 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorldRegions]') AND type in (N'U'))
DROP TABLE [dbo].[WorldRegions]
GO
