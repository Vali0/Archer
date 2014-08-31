USE [master]
GO
/****** Object:  Database [TelerikKindergarten]    Script Date: 31.8.2014 г. 10:40:58 ******/
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
/****** Object:  Table [dbo].[Children]    Script Date: 31.8.2014 г. 10:40:58 ******/
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
/****** Object:  Table [dbo].[Departments]    Script Date: 31.8.2014 г. 10:40:58 ******/
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
/****** Object:  Table [dbo].[Employees]    Script Date: 31.8.2014 г. 10:40:58 ******/
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
/****** Object:  Table [dbo].[Groups]    Script Date: 31.8.2014 г. 10:40:58 ******/
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
