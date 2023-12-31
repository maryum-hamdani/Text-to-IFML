USE [master]
GO
/****** Object:  Database [IFML]    Script Date: 10/04/2019 21:48:53 ******/
CREATE DATABASE [IFML] ON  PRIMARY 
( NAME = N'IFML', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\IFML.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'IFML_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\IFML_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER DATABASE [IFML] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IFML].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IFML] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [IFML] SET ANSI_NULLS OFF
GO
ALTER DATABASE [IFML] SET ANSI_PADDING OFF
GO
ALTER DATABASE [IFML] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [IFML] SET ARITHABORT OFF
GO
ALTER DATABASE [IFML] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [IFML] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [IFML] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [IFML] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [IFML] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [IFML] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [IFML] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [IFML] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [IFML] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [IFML] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [IFML] SET  DISABLE_BROKER
GO
ALTER DATABASE [IFML] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [IFML] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [IFML] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [IFML] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [IFML] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [IFML] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [IFML] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [IFML] SET  READ_WRITE
GO
ALTER DATABASE [IFML] SET RECOVERY SIMPLE
GO
ALTER DATABASE [IFML] SET  MULTI_USER
GO
ALTER DATABASE [IFML] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [IFML] SET DB_CHAINING OFF
GO
USE [IFML]
GO
/****** Object:  Table [dbo].[table_ViewContainers]    Script Date: 10/04/2019 21:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[table_ViewContainers](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[strRequirement] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewContainer1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewContainer2] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewContainer3] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewContainer4] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewContainer5_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewContainer5_2] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewContainer1_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewContainer2_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewContainer4_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewContainer3_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewContainer55_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewContainer6_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_table_ViewContainers] PRIMARY KEY CLUSTERED 
(
	[intId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[table_ViewContainers] ON
INSERT [dbo].[table_ViewContainers] ([intId], [strRequirement], [strViewContainer1], [strViewContainer2], [strViewContainer3], [strViewContainer4], [strViewContainer5_1], [strViewContainer5_2], [strViewContainer1_1], [strViewContainer2_1], [strViewContainer4_1], [strViewContainer3_1], [strViewContainer55_1], [strViewContainer6_1]) VALUES (1, N'The main page exhibits a list of movies. ', N'The main page exhibits ', N'', N'', N'', N'', N'', N'main page ', N'', N'', N'', N'', N'')
INSERT [dbo].[table_ViewContainers] ([intId], [strRequirement], [strViewContainer1], [strViewContainer2], [strViewContainer3], [strViewContainer4], [strViewContainer5_1], [strViewContainer5_2], [strViewContainer1_1], [strViewContainer2_1], [strViewContainer4_1], [strViewContainer3_1], [strViewContainer55_1], [strViewContainer6_1]) VALUES (2, N'Particularly the title of each existing movie is displayed on this page. ', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[table_ViewContainers] ([intId], [strRequirement], [strViewContainer1], [strViewContainer2], [strViewContainer3], [strViewContainer4], [strViewContainer5_1], [strViewContainer5_2], [strViewContainer1_1], [strViewContainer2_1], [strViewContainer4_1], [strViewContainer3_1], [strViewContainer55_1], [strViewContainer6_1]) VALUES (3, N'There is a provision to add a new movie through add new button which navigates to add movie page. ', N'', N'navigates to add movie page ', N'', N'', N'', N'', N'', N'add movie page ', N'', N'', N'', N'')
INSERT [dbo].[table_ViewContainers] ([intId], [strRequirement], [strViewContainer1], [strViewContainer2], [strViewContainer3], [strViewContainer4], [strViewContainer5_1], [strViewContainer5_2], [strViewContainer1_1], [strViewContainer2_1], [strViewContainer4_1], [strViewContainer3_1], [strViewContainer55_1], [strViewContainer6_1]) VALUES (4, N'It contains a form to add movie details the title of movie and year of release. ', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[table_ViewContainers] ([intId], [strRequirement], [strViewContainer1], [strViewContainer2], [strViewContainer3], [strViewContainer4], [strViewContainer5_1], [strViewContainer5_2], [strViewContainer1_1], [strViewContainer2_1], [strViewContainer4_1], [strViewContainer3_1], [strViewContainer55_1], [strViewContainer6_1]) VALUES (5, N'Once the form is successfully filled information can be saved using save button. ', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[table_ViewContainers] ([intId], [strRequirement], [strViewContainer1], [strViewContainer2], [strViewContainer3], [strViewContainer4], [strViewContainer5_1], [strViewContainer5_2], [strViewContainer1_1], [strViewContainer2_1], [strViewContainer4_1], [strViewContainer3_1], [strViewContainer55_1], [strViewContainer6_1]) VALUES (6, N'The main page is displayed in case of successful save otherwise error page is redirected. 
', N'The main page is ', N'', N'error page is ', N'', N'', N'', N'main page ', N'', N'', N'error page ', N'', N'')
INSERT [dbo].[table_ViewContainers] ([intId], [strRequirement], [strViewContainer1], [strViewContainer2], [strViewContainer3], [strViewContainer4], [strViewContainer5_1], [strViewContainer5_2], [strViewContainer1_1], [strViewContainer2_1], [strViewContainer4_1], [strViewContainer3_1], [strViewContainer55_1], [strViewContainer6_1]) VALUES (7, N'In addition to add movie feature the user can also select desired movie from the list of movies presented on main page in order to view its details. ', N'', N'', N'', N'presented on main page ', N'', N'', N'', N'', N'main page ', N'', N'', N'')
INSERT [dbo].[table_ViewContainers] ([intId], [strRequirement], [strViewContainer1], [strViewContainer2], [strViewContainer3], [strViewContainer4], [strViewContainer5_1], [strViewContainer5_2], [strViewContainer1_1], [strViewContainer2_1], [strViewContainer4_1], [strViewContainer3_1], [strViewContainer55_1], [strViewContainer6_1]) VALUES (8, N'It directs to the movie description page which provides detail of selected movie along with a button to edit those details. ', N'', N'', N'movie description page which provides ', N'', N'', N'', N'', N'', N'', N'movie description page ', N'', N'')
INSERT [dbo].[table_ViewContainers] ([intId], [strRequirement], [strViewContainer1], [strViewContainer2], [strViewContainer3], [strViewContainer4], [strViewContainer5_1], [strViewContainer5_2], [strViewContainer1_1], [strViewContainer2_1], [strViewContainer4_1], [strViewContainer3_1], [strViewContainer55_1], [strViewContainer6_1]) VALUES (9, N'This button navigates to the edit movie page that presents a form for modification of existing information including title of movie and year of release. ', N'', N'', N'edit movie page that presents ', N'', N'', N'', N'', N'', N'', N'edit movie page ', N'', N'')
INSERT [dbo].[table_ViewContainers] ([intId], [strRequirement], [strViewContainer1], [strViewContainer2], [strViewContainer3], [strViewContainer4], [strViewContainer5_1], [strViewContainer5_2], [strViewContainer1_1], [strViewContainer2_1], [strViewContainer4_1], [strViewContainer3_1], [strViewContainer55_1], [strViewContainer6_1]) VALUES (10, N'The user can edit this information and update it using update button. ', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[table_ViewContainers] ([intId], [strRequirement], [strViewContainer1], [strViewContainer2], [strViewContainer3], [strViewContainer4], [strViewContainer5_1], [strViewContainer5_2], [strViewContainer1_1], [strViewContainer2_1], [strViewContainer4_1], [strViewContainer3_1], [strViewContainer55_1], [strViewContainer6_1]) VALUES (11, N'The movie description page is displayed in case of successful save otherwise view is directed to error page.
', N'', N'', N'movie description page is ', N'', N'', N'directed to error page ', N'', N'', N'', N'movie description page ', N'', N'error page ')
SET IDENTITY_INSERT [dbo].[table_ViewContainers] OFF
/****** Object:  Table [dbo].[table_ViewComponent]    Script Date: 10/04/2019 21:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[table_ViewComponent](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[strRequirement] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewComponent1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewComponent2] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewComponent3] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewComponent4] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewComponent5] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewComponent6] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewComponent1_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewComponent2_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewComponent3_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewComponent4_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewComponent5_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strViewComponent6_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_table_ViewComponent] PRIMARY KEY CLUSTERED 
(
	[intId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[table_ViewComponent] ON
INSERT [dbo].[table_ViewComponent] ([intId], [strRequirement], [strViewComponent1], [strViewComponent2], [strViewComponent3], [strViewComponent4], [strViewComponent5], [strViewComponent6], [strViewComponent1_1], [strViewComponent2_1], [strViewComponent3_1], [strViewComponent4_1], [strViewComponent5_1], [strViewComponent6_1]) VALUES (1, N'The main page exhibits a list of movies. ', N'exhibits a list of movies ', N'', N'', N'', N'', N'', N'list of movies Databinding <Movie manager>', N'', N'', N'', N'', N'')
INSERT [dbo].[table_ViewComponent] ([intId], [strRequirement], [strViewComponent1], [strViewComponent2], [strViewComponent3], [strViewComponent4], [strViewComponent5], [strViewComponent6], [strViewComponent1_1], [strViewComponent2_1], [strViewComponent3_1], [strViewComponent4_1], [strViewComponent5_1], [strViewComponent6_1]) VALUES (2, N'Particularly the title of each existing movie is displayed on this page. ', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[table_ViewComponent] ([intId], [strRequirement], [strViewComponent1], [strViewComponent2], [strViewComponent3], [strViewComponent4], [strViewComponent5], [strViewComponent6], [strViewComponent1_1], [strViewComponent2_1], [strViewComponent3_1], [strViewComponent4_1], [strViewComponent5_1], [strViewComponent6_1]) VALUES (3, N'There is a provision to add a new movie through add new button which navigates to add movie page. ', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[table_ViewComponent] ([intId], [strRequirement], [strViewComponent1], [strViewComponent2], [strViewComponent3], [strViewComponent4], [strViewComponent5], [strViewComponent6], [strViewComponent1_1], [strViewComponent2_1], [strViewComponent3_1], [strViewComponent4_1], [strViewComponent5_1], [strViewComponent6_1]) VALUES (4, N'It contains a form to add movie details the title of movie and year of release. ', N'', N'', N'', N'', N'', N'contains a form to add movie ', N'', N'', N'', N'', N'', N'form to add movie ')
INSERT [dbo].[table_ViewComponent] ([intId], [strRequirement], [strViewComponent1], [strViewComponent2], [strViewComponent3], [strViewComponent4], [strViewComponent5], [strViewComponent6], [strViewComponent1_1], [strViewComponent2_1], [strViewComponent3_1], [strViewComponent4_1], [strViewComponent5_1], [strViewComponent6_1]) VALUES (5, N'Once the form is successfully filled information can be saved using save button. ', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[table_ViewComponent] ([intId], [strRequirement], [strViewComponent1], [strViewComponent2], [strViewComponent3], [strViewComponent4], [strViewComponent5], [strViewComponent6], [strViewComponent1_1], [strViewComponent2_1], [strViewComponent3_1], [strViewComponent4_1], [strViewComponent5_1], [strViewComponent6_1]) VALUES (6, N'The main page is displayed in case of successful save otherwise error page is redirected. 
', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[table_ViewComponent] ([intId], [strRequirement], [strViewComponent1], [strViewComponent2], [strViewComponent3], [strViewComponent4], [strViewComponent5], [strViewComponent6], [strViewComponent1_1], [strViewComponent2_1], [strViewComponent3_1], [strViewComponent4_1], [strViewComponent5_1], [strViewComponent6_1]) VALUES (7, N'In addition to add movie feature the user can also select desired movie from the list of movies presented on main page in order to view its details. ', N'', N'', N'list of movies presented ', N'', N'', N'', N'', N'', N'list of movies Databinding <Movie manager>', N'', N'', N'')
INSERT [dbo].[table_ViewComponent] ([intId], [strRequirement], [strViewComponent1], [strViewComponent2], [strViewComponent3], [strViewComponent4], [strViewComponent5], [strViewComponent6], [strViewComponent1_1], [strViewComponent2_1], [strViewComponent3_1], [strViewComponent4_1], [strViewComponent5_1], [strViewComponent6_1]) VALUES (8, N'It directs to the movie description page which provides detail of selected movie along with a button to edit those details. ', N'', N'', N'', N'provides detail of selected movie ', N'', N'', N'', N'', N'', N'detail of selected movie Databinding <Movie manager>', N'', N'')
INSERT [dbo].[table_ViewComponent] ([intId], [strRequirement], [strViewComponent1], [strViewComponent2], [strViewComponent3], [strViewComponent4], [strViewComponent5], [strViewComponent6], [strViewComponent1_1], [strViewComponent2_1], [strViewComponent3_1], [strViewComponent4_1], [strViewComponent5_1], [strViewComponent6_1]) VALUES (9, N'This button navigates to the edit movie page that presents a form for modification of existing information including title of movie and year of release. ', N'presents a form for modification ', N'', N'', N'', N'', N'', N'form for modification ', N'', N'', N'', N'', N'')
INSERT [dbo].[table_ViewComponent] ([intId], [strRequirement], [strViewComponent1], [strViewComponent2], [strViewComponent3], [strViewComponent4], [strViewComponent5], [strViewComponent6], [strViewComponent1_1], [strViewComponent2_1], [strViewComponent3_1], [strViewComponent4_1], [strViewComponent5_1], [strViewComponent6_1]) VALUES (10, N'The user can edit this information and update it using update button. ', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[table_ViewComponent] ([intId], [strRequirement], [strViewComponent1], [strViewComponent2], [strViewComponent3], [strViewComponent4], [strViewComponent5], [strViewComponent6], [strViewComponent1_1], [strViewComponent2_1], [strViewComponent3_1], [strViewComponent4_1], [strViewComponent5_1], [strViewComponent6_1]) VALUES (11, N'The movie description page is displayed in case of successful save otherwise view is directed to error page.
', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[table_ViewComponent] OFF
/****** Object:  Table [dbo].[table_Results]    Script Date: 10/04/2019 21:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[table_Results](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[line] [int] NULL,
	[container] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[component] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[events] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[actions] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[parameters] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[navigation] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_table_Results] PRIMARY KEY CLUSTERED 
(
	[intId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[table_Results] ON
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (1, 1, N'main page ', N'', N'', N'', N'', N'')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (2, 1, N'', N'list of movies Databinding <Movie manager>', N'', N'', N'', N'')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (3, 1, N'', N'', N'add new ', N'', N'', N'True')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (4, 3, N'add movie page ', N'', N'', N'', N'', N'')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (5, 3, N'', N'form to add movie ', N'', N'', N'', N'')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (6, 3, N'', N'', N'add new ', N'', N'', N'True')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (7, 6, N'main page ', N'', N'', N'', N'', N'')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (8, 6, N'error page ', N'', N'', N'', N'', N'')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (9, 7, N'main page ', N'', N'', N'', N'', N'')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (10, 7, N'', N'list of movies Databinding <Movie manager>', N'', N'', N'', N'')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (11, 7, N'', N'', N'select ', N'', N'', N'True')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (12, 8, N'movie description page ', N'', N'', N'', N'', N'')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (13, 8, N'', N'detail of selected movie Databinding <Movie manager>', N'', N'', N'', N'')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (14, 8, N'', N'', N'edit ', N'', N'', N'True')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (15, 9, N'edit movie page ', N'', N'', N'', N'', N'')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (16, 9, N'', N'form for modification ', N'', N'', N'', N'')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (17, 9, N'', N'', N'update ', N'', N'', N'True')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (18, 9, N'', N'', N'', N'update ', N'', N'')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (19, 11, N'movie description page ', N'', N'', N'', N'', N'')
INSERT [dbo].[table_Results] ([intId], [line], [container], [component], [events], [actions], [parameters], [navigation]) VALUES (20, 11, N'error page ', N'', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[table_Results] OFF
/****** Object:  Table [dbo].[table_Parameters]    Script Date: 10/04/2019 21:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[table_Parameters](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[strParameter1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strParameter2] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strRequirement] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_table_Parameters] PRIMARY KEY CLUSTERED 
(
	[intId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[table_Parameters] ON
INSERT [dbo].[table_Parameters] ([intId], [strParameter1], [strParameter2], [strRequirement]) VALUES (1, N'list of movies ', N'', N'The main page exhibits a list of movies. ')
INSERT [dbo].[table_Parameters] ([intId], [strParameter1], [strParameter2], [strRequirement]) VALUES (2, N'', N'', N'Particularly the title of each existing movie is displayed on this page. ')
INSERT [dbo].[table_Parameters] ([intId], [strParameter1], [strParameter2], [strRequirement]) VALUES (3, N'', N'', N'There is a provision to add a new movie through add new button which navigates to add movie page. ')
INSERT [dbo].[table_Parameters] ([intId], [strParameter1], [strParameter2], [strRequirement]) VALUES (4, N'year of release ', N'', N'It contains a form to add movie details the title of movie and year of release. ')
INSERT [dbo].[table_Parameters] ([intId], [strParameter1], [strParameter2], [strRequirement]) VALUES (5, N'', N'filled information ', N'Once the form is successfully filled information can be saved using save button. ')
INSERT [dbo].[table_Parameters] ([intId], [strParameter1], [strParameter2], [strRequirement]) VALUES (6, N'', N'', N'The main page is displayed in case of successful save otherwise error page is redirected. 
')
INSERT [dbo].[table_Parameters] ([intId], [strParameter1], [strParameter2], [strRequirement]) VALUES (7, N'list of movies ', N'desired movie ', N'In addition to add movie feature the user can also select desired movie from the list of movies presented on main page in order to view its details. ')
INSERT [dbo].[table_Parameters] ([intId], [strParameter1], [strParameter2], [strRequirement]) VALUES (8, N'', N'selected movie ', N'It directs to the movie description page which provides detail of selected movie along with a button to edit those details. ')
INSERT [dbo].[table_Parameters] ([intId], [strParameter1], [strParameter2], [strRequirement]) VALUES (9, N'year of release ', N'', N'This button navigates to the edit movie page that presents a form for modification of existing information including title of movie and year of release. ')
INSERT [dbo].[table_Parameters] ([intId], [strParameter1], [strParameter2], [strRequirement]) VALUES (10, N'', N'', N'The user can edit this information and update it using update button. ')
INSERT [dbo].[table_Parameters] ([intId], [strParameter1], [strParameter2], [strRequirement]) VALUES (11, N'', N'', N'The movie description page is displayed in case of successful save otherwise view is directed to error page.
')
SET IDENTITY_INSERT [dbo].[table_Parameters] OFF
/****** Object:  Table [dbo].[table_Events]    Script Date: 10/04/2019 21:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[table_Events](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[strEvent1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strEvent2] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strEvent3] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strEvent4] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strEvent5] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strRequirement] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strEvent1_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strEvent2_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strEvent3_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strEvent4_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strEvent5_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strEvent6] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strEvent6_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[navigation1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[navigation2] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[navigation3] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[navigation4] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[navigation5] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_table_Events] PRIMARY KEY CLUSTERED 
(
	[intId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[table_Events] ON
INSERT [dbo].[table_Events] ([intId], [strEvent1], [strEvent2], [strEvent3], [strEvent4], [strEvent5], [strRequirement], [strEvent1_1], [strEvent2_1], [strEvent3_1], [strEvent4_1], [strEvent5_1], [strEvent6], [strEvent6_1], [navigation1], [navigation2], [navigation3], [navigation4], [navigation5]) VALUES (1, N'', N'', N'', N'', N'', N'The main page exhibits a list of movies. ', N'', N'', N'', N'', N'', N'', NULL, N'True', N'True', N'True', N'True', N'True')
INSERT [dbo].[table_Events] ([intId], [strEvent1], [strEvent2], [strEvent3], [strEvent4], [strEvent5], [strRequirement], [strEvent1_1], [strEvent2_1], [strEvent3_1], [strEvent4_1], [strEvent5_1], [strEvent6], [strEvent6_1], [navigation1], [navigation2], [navigation3], [navigation4], [navigation5]) VALUES (2, N'', N'', N'', N'', N'', N'Particularly the title of each existing movie is displayed on this page. ', N'', N'', N'', N'', N'', N'', NULL, N'True', N'True', N'True', N'True', N'True')
INSERT [dbo].[table_Events] ([intId], [strEvent1], [strEvent2], [strEvent3], [strEvent4], [strEvent5], [strRequirement], [strEvent1_1], [strEvent2_1], [strEvent3_1], [strEvent4_1], [strEvent5_1], [strEvent6], [strEvent6_1], [navigation1], [navigation2], [navigation3], [navigation4], [navigation5]) VALUES (3, N'through add new button ', N'', N'', N'', N'', N'There is a provision to add a new movie through add new button which navigates to add movie page. ', N'add new ', N'', N'', N'', N'', N'', NULL, N'True', N'True', N'True', N'True', N'True')
INSERT [dbo].[table_Events] ([intId], [strEvent1], [strEvent2], [strEvent3], [strEvent4], [strEvent5], [strRequirement], [strEvent1_1], [strEvent2_1], [strEvent3_1], [strEvent4_1], [strEvent5_1], [strEvent6], [strEvent6_1], [navigation1], [navigation2], [navigation3], [navigation4], [navigation5]) VALUES (4, N'', N'', N'', N'', N'', N'It contains a form to add movie details the title of movie and year of release. ', N'', N'', N'', N'', N'', N'', NULL, N'True', N'True', N'True', N'True', N'True')
INSERT [dbo].[table_Events] ([intId], [strEvent1], [strEvent2], [strEvent3], [strEvent4], [strEvent5], [strRequirement], [strEvent1_1], [strEvent2_1], [strEvent3_1], [strEvent4_1], [strEvent5_1], [strEvent6], [strEvent6_1], [navigation1], [navigation2], [navigation3], [navigation4], [navigation5]) VALUES (5, N'', N'using save button ', N'', N'', N'', N'Once the form is successfully filled information can be saved using save button. ', N'', N'save ', N'', N'', N'', N'', NULL, N'True', N'True', N'True', N'True', N'True')
INSERT [dbo].[table_Events] ([intId], [strEvent1], [strEvent2], [strEvent3], [strEvent4], [strEvent5], [strRequirement], [strEvent1_1], [strEvent2_1], [strEvent3_1], [strEvent4_1], [strEvent5_1], [strEvent6], [strEvent6_1], [navigation1], [navigation2], [navigation3], [navigation4], [navigation5]) VALUES (6, N'', N'', N'', N'', N'', N'The main page is displayed in case of successful save otherwise error page is redirected. 
', N'', N'', N'', N'', N'', N'', NULL, N'True', N'True', N'True', N'True', N'True')
INSERT [dbo].[table_Events] ([intId], [strEvent1], [strEvent2], [strEvent3], [strEvent4], [strEvent5], [strRequirement], [strEvent1_1], [strEvent2_1], [strEvent3_1], [strEvent4_1], [strEvent5_1], [strEvent6], [strEvent6_1], [navigation1], [navigation2], [navigation3], [navigation4], [navigation5]) VALUES (7, N'', N'', N'select desired movie ', N'', N'', N'In addition to add movie feature the user can also select desired movie from the list of movies presented on main page in order to view its details. ', N'', N'', N'select ', N'', N'', N'', NULL, N'True', N'True', N'True', N'True', N'True')
INSERT [dbo].[table_Events] ([intId], [strEvent1], [strEvent2], [strEvent3], [strEvent4], [strEvent5], [strRequirement], [strEvent1_1], [strEvent2_1], [strEvent3_1], [strEvent4_1], [strEvent5_1], [strEvent6], [strEvent6_1], [navigation1], [navigation2], [navigation3], [navigation4], [navigation5]) VALUES (8, N'to edit those details ', N'', N'', N'', N'', N'It directs to the movie description page which provides detail of selected movie along with a button to edit those details. ', N'edit ', N'', N'', N'', N'', N'', NULL, N'True', N'True', N'True', N'True', N'True')
INSERT [dbo].[table_Events] ([intId], [strEvent1], [strEvent2], [strEvent3], [strEvent4], [strEvent5], [strRequirement], [strEvent1_1], [strEvent2_1], [strEvent3_1], [strEvent4_1], [strEvent5_1], [strEvent6], [strEvent6_1], [navigation1], [navigation2], [navigation3], [navigation4], [navigation5]) VALUES (9, N'', N'', N'', N'', N'', N'This button navigates to the edit movie page that presents a form for modification of existing information including title of movie and year of release. ', N'', N'', N'', N'', N'', N'', NULL, N'True', N'True', N'True', N'True', N'True')
INSERT [dbo].[table_Events] ([intId], [strEvent1], [strEvent2], [strEvent3], [strEvent4], [strEvent5], [strRequirement], [strEvent1_1], [strEvent2_1], [strEvent3_1], [strEvent4_1], [strEvent5_1], [strEvent6], [strEvent6_1], [navigation1], [navigation2], [navigation3], [navigation4], [navigation5]) VALUES (10, N'', N'using update button ', N'', N'', N'', N'The user can edit this information and update it using update button. ', N'', N'update ', N'', N'', N'', N'', NULL, N'True', N'True', N'True', N'True', N'True')
INSERT [dbo].[table_Events] ([intId], [strEvent1], [strEvent2], [strEvent3], [strEvent4], [strEvent5], [strRequirement], [strEvent1_1], [strEvent2_1], [strEvent3_1], [strEvent4_1], [strEvent5_1], [strEvent6], [strEvent6_1], [navigation1], [navigation2], [navigation3], [navigation4], [navigation5]) VALUES (11, N'', N'', N'', N'', N'', N'The movie description page is displayed in case of successful save otherwise view is directed to error page.
', N'', N'', N'', N'', N'', N'', NULL, N'True', N'True', N'True', N'True', N'True')
SET IDENTITY_INSERT [dbo].[table_Events] OFF
/****** Object:  Table [dbo].[table_Actions]    Script Date: 10/04/2019 21:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[table_Actions](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[strRequirement] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strAction1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strAction2] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strAction1_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[strAction2_1] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_table_Actions] PRIMARY KEY CLUSTERED 
(
	[intId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[table_Actions] ON
INSERT [dbo].[table_Actions] ([intId], [strRequirement], [strAction1], [strAction2], [strAction1_1], [strAction2_1]) VALUES (1, N'The main page exhibits a list of movies. ', N'', N'', N'', N'')
INSERT [dbo].[table_Actions] ([intId], [strRequirement], [strAction1], [strAction2], [strAction1_1], [strAction2_1]) VALUES (2, N'Particularly the title of each existing movie is displayed on this page. ', N'', N'', N'', N'')
INSERT [dbo].[table_Actions] ([intId], [strRequirement], [strAction1], [strAction2], [strAction1_1], [strAction2_1]) VALUES (3, N'There is a provision to add a new movie through add new button which navigates to add movie page. ', N'', N'', N'', N'')
INSERT [dbo].[table_Actions] ([intId], [strRequirement], [strAction1], [strAction2], [strAction1_1], [strAction2_1]) VALUES (4, N'It contains a form to add movie details the title of movie and year of release. ', N'', N'', N'', N'')
INSERT [dbo].[table_Actions] ([intId], [strRequirement], [strAction1], [strAction2], [strAction1_1], [strAction2_1]) VALUES (5, N'Once the form is successfully filled information can be saved using save button. ', N'saved using save button ', N'', N'saved ', N'')
INSERT [dbo].[table_Actions] ([intId], [strRequirement], [strAction1], [strAction2], [strAction1_1], [strAction2_1]) VALUES (6, N'The main page is displayed in case of successful save otherwise error page is redirected. 
', N'', N'', N'', N'')
INSERT [dbo].[table_Actions] ([intId], [strRequirement], [strAction1], [strAction2], [strAction1_1], [strAction2_1]) VALUES (7, N'In addition to add movie feature the user can also select desired movie from the list of movies presented on main page in order to view its details. ', N'', N'', N'', N'')
INSERT [dbo].[table_Actions] ([intId], [strRequirement], [strAction1], [strAction2], [strAction1_1], [strAction2_1]) VALUES (8, N'It directs to the movie description page which provides detail of selected movie along with a button to edit those details. ', N'', N'', N'', N'')
INSERT [dbo].[table_Actions] ([intId], [strRequirement], [strAction1], [strAction2], [strAction1_1], [strAction2_1]) VALUES (9, N'This button navigates to the edit movie page that presents a form for modification of existing information including title of movie and year of release. ', N'', N'', N'', N'')
INSERT [dbo].[table_Actions] ([intId], [strRequirement], [strAction1], [strAction2], [strAction1_1], [strAction2_1]) VALUES (10, N'The user can edit this information and update it using update button. ', N'', N'update it using update button ', N'', N'update ')
INSERT [dbo].[table_Actions] ([intId], [strRequirement], [strAction1], [strAction2], [strAction1_1], [strAction2_1]) VALUES (11, N'The movie description page is displayed in case of successful save otherwise view is directed to error page.
', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[table_Actions] OFF
