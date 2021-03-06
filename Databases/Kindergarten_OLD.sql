USE [master]
GO
/****** Object:  Database [TelerikKindergarten]    Script Date: 31.8.2014 г. 10:30:40 ******/
CREATE DATABASE [TelerikKindergarten]
GO
ALTER DATABASE [TelerikKindergarten] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TelerikKindergarten].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TelerikKindergarten] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET ARITHABORT OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TelerikKindergarten] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TelerikKindergarten] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TelerikKindergarten] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TelerikKindergarten] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TelerikKindergarten] SET  MULTI_USER 
GO
ALTER DATABASE [TelerikKindergarten] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TelerikKindergarten] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TelerikKindergarten] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TelerikKindergarten] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TelerikKindergarten] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TelerikKindergarten]
GO
/****** Object:  Table [dbo].[Assets]    Script Date: 31.8.2014 г. 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assets](
	[AssetID] [int] IDENTITY(1,1) NOT NULL,
	[AssetTypeID] [int] NOT NULL,
	[DepartmentID] [int] NULL,
	[Value] [money] NOT NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK_Assets] PRIMARY KEY CLUSTERED 
(
	[AssetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AssetTypes]    Script Date: 31.8.2014 г. 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetTypes](
	[AssetTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AssetTypes] PRIMARY KEY CLUSTERED 
(
	[AssetTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Children]    Script Date: 31.8.2014 г. 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Children](
	[ChildID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[AdmissionDate] [date] NOT NULL,
	[ConclusionDate] [date] NULL,
	[GroupID] [int] NOT NULL,
 CONSTRAINT [PK_Children] PRIMARY KEY CLUSTERED 
(
	[ChildID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 31.8.2014 г. 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Departments_1] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 31.8.2014 г. 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[ManagerID] [int] NULL,
	[DepartmentID] [int] NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Groups]    Script Date: 31.8.2014 г. 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[SupervisorID] [int] NOT NULL,
	[Notes] [text] NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Assets] ON 

GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (1, 1, 3, 30.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (2, 1, 3, 30.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (3, 1, 3, 30.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (4, 1, 3, 20.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (5, 1, 3, 30.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (6, 1, 3, 25.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (7, 1, 3, 30.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (8, 1, 3, 30.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (10, 2, 3, 80.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (11, 2, 3, 150.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (12, 2, 3, 155.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (13, 3, 3, 300.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (14, 3, 3, 350.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (15, 17, 3, 180.0000, N'Red')
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (16, 17, 3, 180.0000, N'Red')
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (17, 17, 3, 180.0000, N'Red')
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (18, 17, 3, 180.0000, N'Blue')
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (19, 17, 3, 180.0000, N'Blue')
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (20, 17, 3, 180.0000, N'Blue')
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (21, 17, 3, 180.0000, N'Blue')
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (22, 17, 3, 180.0000, N'Green')
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (23, 17, 3, 180.0000, N'Green')
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (24, 17, 3, 180.0000, N'Green')
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (25, 17, 3, 180.0000, N'Green')
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (26, 17, 3, 180.0000, N'Green')
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (27, 17, 3, 180.0000, N'Yellow')
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (28, 17, 3, 180.0000, N'Yellow')
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (29, 17, 3, 180.0000, N'Yellow')
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (30, 17, 3, 180.0000, N'Yellow')
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (31, 5, 3, 300.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (32, 5, 3, 300.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (33, 4, 3, 100.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (34, 4, 3, 100.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (35, 4, 3, 100.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (36, 6, 3, 40.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (37, 6, 3, 40.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (38, 6, 3, 40.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (39, 6, 3, 40.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (40, 6, 3, 40.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (41, 6, 3, 40.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (42, 6, 3, 40.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (43, 6, 3, 40.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (44, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (45, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (46, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (47, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (48, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (49, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (50, 8, 3, 8.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (51, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (52, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (53, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (54, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (55, 8, 3, 20.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (56, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (57, 8, 3, 7.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (58, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (59, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (60, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (61, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (62, 8, 3, 15.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (63, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (64, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (65, 8, 3, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (66, 9, 3, 80.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (67, 9, 3, 40.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (68, 9, 3, 55.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (69, 9, 3, 60.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (70, 9, 3, 300.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (71, 11, 1, 500.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (72, 11, 1, 500.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (73, 3, 1, 150.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (74, 12, 1, 100.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (75, 13, 1, 80.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (76, 13, 1, 80.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (77, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (78, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (79, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (80, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (81, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (82, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (83, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (84, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (85, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (86, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (87, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (88, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (89, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (90, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (91, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (92, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (93, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (94, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (95, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (96, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (97, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (98, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (99, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (100, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (101, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (102, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (103, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (104, 14, 1, 3.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (105, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (106, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (107, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (108, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (109, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (110, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (111, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (112, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (113, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (114, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (115, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (116, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (117, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (118, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (119, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (120, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (121, 15, 1, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (122, 16, 1, 15.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (123, 16, 1, 15.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (124, 16, 1, 15.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (125, 16, 1, 15.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (126, 16, 1, 15.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (127, 16, 1, 15.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (128, 16, 1, 15.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (129, 16, 1, 15.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (130, 18, 4, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (131, 18, 4, 12.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (132, 19, 4, 5.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (133, 20, 4, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (134, 20, 4, 10.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (135, 21, 1, 40.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (136, 21, 1, 40.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (137, 21, 1, 40.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (138, 21, 2, 70.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (139, 21, 2, 70.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (140, 21, 3, 40.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (141, 21, 3, 40.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (142, 21, 3, 40.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (143, 21, 4, 35.0000, NULL)
GO
INSERT [dbo].[Assets] ([AssetID], [AssetTypeID], [DepartmentID], [Value], [Description]) VALUES (144, 21, 4, 32.0000, NULL)
GO
SET IDENTITY_INSERT [dbo].[Assets] OFF
GO
SET IDENTITY_INSERT [dbo].[AssetTypes] ON 

GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (1, N'Chair')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (2, N'Table(small)')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (3, N'Table(big)')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (4, N'Carpet(small)')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (5, N'Carpet(big)')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (6, N'Lamp')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (7, N'Lightbulb')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (8, N'Toy(small)')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (9, N'Toy(big)')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (10, N'Toy(medium)')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (11, N'Oven')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (12, N'Utensils')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (13, N'Pan')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (14, N'Plate(small)')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (15, N'Plate(big)')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (16, N'Bowl')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (17, N'Bed')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (18, N'Broom')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (19, N'Cleaning solution')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (20, N'Bucket')
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [Name]) VALUES (21, N'Clothes')
GO
SET IDENTITY_INSERT [dbo].[AssetTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Children] ON 

GO
INSERT [dbo].[Children] ([ChildID], [FirstName], [MiddleName], [LastName], [Address], [AdmissionDate], [ConclusionDate], [GroupID]) VALUES (1, N'Emil', NULL, N'Slavov', N'Vasil Levski 10', CAST(N'2004-12-01' AS Date), NULL, 1)
GO
INSERT [dbo].[Children] ([ChildID], [FirstName], [MiddleName], [LastName], [Address], [AdmissionDate], [ConclusionDate], [GroupID]) VALUES (2, N'Martin', NULL, N'Tonkov', N'Stara planina 2', CAST(N'2003-10-01' AS Date), CAST(N'2004-03-02' AS Date), 1)
GO
INSERT [dbo].[Children] ([ChildID], [FirstName], [MiddleName], [LastName], [Address], [AdmissionDate], [ConclusionDate], [GroupID]) VALUES (4, N'Valentin', NULL, N'Radev', N'Ivan Vazov 5', CAST(N'2005-04-13' AS Date), NULL, 1)
GO
INSERT [dbo].[Children] ([ChildID], [FirstName], [MiddleName], [LastName], [Address], [AdmissionDate], [ConclusionDate], [GroupID]) VALUES (5, N'Krasimir', NULL, N'Penev', N'Lyulin 5, bl. 200', CAST(N'2003-07-07' AS Date), CAST(N'2005-03-03' AS Date), 2)
GO
INSERT [dbo].[Children] ([ChildID], [FirstName], [MiddleName], [LastName], [Address], [AdmissionDate], [ConclusionDate], [GroupID]) VALUES (6, N'Svilen', NULL, N'Kucnhev', NULL, CAST(N'2004-09-08' AS Date), NULL, 2)
GO
INSERT [dbo].[Children] ([ChildID], [FirstName], [MiddleName], [LastName], [Address], [AdmissionDate], [ConclusionDate], [GroupID]) VALUES (7, N'Krasimir', NULL, N'Petrov', NULL, CAST(N'2004-12-12' AS Date), NULL, 2)
GO
INSERT [dbo].[Children] ([ChildID], [FirstName], [MiddleName], [LastName], [Address], [AdmissionDate], [ConclusionDate], [GroupID]) VALUES (9, N'Aleksandra', N'Petrova', N'Zhivkova', N'Parensov 10', CAST(N'2005-08-09' AS Date), NULL, 2)
GO
INSERT [dbo].[Children] ([ChildID], [FirstName], [MiddleName], [LastName], [Address], [AdmissionDate], [ConclusionDate], [GroupID]) VALUES (10, N'Nevena', NULL, N'Benatova', NULL, CAST(N'2005-08-09' AS Date), NULL, 2)
GO
INSERT [dbo].[Children] ([ChildID], [FirstName], [MiddleName], [LastName], [Address], [AdmissionDate], [ConclusionDate], [GroupID]) VALUES (11, N'Elka', NULL, N'Minkova', NULL, CAST(N'2004-06-07' AS Date), NULL, 1)
GO
INSERT [dbo].[Children] ([ChildID], [FirstName], [MiddleName], [LastName], [Address], [AdmissionDate], [ConclusionDate], [GroupID]) VALUES (12, N'Trendafil', NULL, N'Akatsiev', N'Nashe selo', CAST(N'2004-05-01' AS Date), CAST(N'2005-01-01' AS Date), 2)
GO
SET IDENTITY_INSERT [dbo].[Children] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

GO
INSERT [dbo].[Departments] ([DepartmentID], [Name]) VALUES (1, N'Cooking')
GO
INSERT [dbo].[Departments] ([DepartmentID], [Name]) VALUES (2, N'Maintenance')
GO
INSERT [dbo].[Departments] ([DepartmentID], [Name]) VALUES (3, N'Children care')
GO
INSERT [dbo].[Departments] ([DepartmentID], [Name]) VALUES (4, N'Cleaning')
GO
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [MiddleName], [LastName], [ManagerID], [DepartmentID]) VALUES (1, N'Evgenia', N'Atanasova', N'Mingova', NULL, NULL)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [MiddleName], [LastName], [ManagerID], [DepartmentID]) VALUES (2, N'Atanas', N'Ivanov', N'Petrov', 1, 2)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [MiddleName], [LastName], [ManagerID], [DepartmentID]) VALUES (3, N'Silvia', N'Aleksandrova', N'Berova', 1, 1)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [MiddleName], [LastName], [ManagerID], [DepartmentID]) VALUES (4, N'Krastina', N'Zhivkova', N'Misheva', 3, 1)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [MiddleName], [LastName], [ManagerID], [DepartmentID]) VALUES (5, N'Atanas', N'Zhorov', N'Efremov', 3, 1)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [MiddleName], [LastName], [ManagerID], [DepartmentID]) VALUES (6, N'Branimir', N'Ilchev', N'Ilchev', 2, 2)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [MiddleName], [LastName], [ManagerID], [DepartmentID]) VALUES (7, N'Milka', N'Petrova', N'Stefanova', 1, 3)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [MiddleName], [LastName], [ManagerID], [DepartmentID]) VALUES (8, N'Evgenia', NULL, N'Radanova', 7, 3)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [MiddleName], [LastName], [ManagerID], [DepartmentID]) VALUES (9, N'Elena', NULL, N'Petrova', 7, 3)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [MiddleName], [LastName], [ManagerID], [DepartmentID]) VALUES (10, N'Pelagia', NULL, N'Boneva', 7, 3)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [MiddleName], [LastName], [ManagerID], [DepartmentID]) VALUES (11, N'Nikoleta', NULL, N'Petkova', 7, 3)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [MiddleName], [LastName], [ManagerID], [DepartmentID]) VALUES (13, N'Rita', NULL, N'Georgieva', NULL, 4)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [MiddleName], [LastName], [ManagerID], [DepartmentID]) VALUES (14, N'Marieta', NULL, N'Dineva', NULL, 4)
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

GO
INSERT [dbo].[Groups] ([GroupID], [SupervisorID], [Notes]) VALUES (1, 8, NULL)
GO
INSERT [dbo].[Groups] ([GroupID], [SupervisorID], [Notes]) VALUES (2, 9, NULL)
GO
INSERT [dbo].[Groups] ([GroupID], [SupervisorID], [Notes]) VALUES (3, 10, NULL)
GO
INSERT [dbo].[Groups] ([GroupID], [SupervisorID], [Notes]) VALUES (4, 11, NULL)
GO
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
ALTER TABLE [dbo].[Assets]  WITH CHECK ADD  CONSTRAINT [FK_Assets_AssetTypes] FOREIGN KEY([AssetTypeID])
REFERENCES [dbo].[AssetTypes] ([AssetTypeID])
GO
ALTER TABLE [dbo].[Assets] CHECK CONSTRAINT [FK_Assets_AssetTypes]
GO
ALTER TABLE [dbo].[Assets]  WITH CHECK ADD  CONSTRAINT [FK_Assets_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[Assets] CHECK CONSTRAINT [FK_Assets_Departments]
GO
ALTER TABLE [dbo].[Children]  WITH CHECK ADD  CONSTRAINT [FK_Children_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[Children] CHECK CONSTRAINT [FK_Children_Groups]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Departments]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Persons] FOREIGN KEY([ManagerID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Persons_Persons]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Employees] FOREIGN KEY([SupervisorID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Employees]
GO
USE [master]
GO
ALTER DATABASE [TelerikKindergarten] SET  READ_WRITE 
GO
