USE [ASPNetAngularDB_Abhik]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/31/2022 12:16:24 AM ******/
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
/****** Object:  Table [dbo].[categoryModels]    Script Date: 1/31/2022 12:16:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoryModels](
	[category_Id] [int] IDENTITY(1,1) NOT NULL,
	[tittle] [nvarchar](100) NOT NULL,
	[creation_Time] [datetime2](7) NOT NULL,
	[lastmodificationTime] [datetime2](7) NULL,
	[isDeleted] [bit] NOT NULL,
	[deletionTime] [datetime2](7) NULL,
 CONSTRAINT [PK_categoryModels] PRIMARY KEY CLUSTERED 
(
	[category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chapterModels]    Script Date: 1/31/2022 12:16:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chapterModels](
	[chapter_Id] [int] IDENTITY(1,1) NOT NULL,
	[tittle] [nvarchar](100) NOT NULL,
	[active] [bit] NOT NULL,
	[creation_Time] [datetime2](7) NOT NULL,
	[lastmodificationTime] [datetime2](7) NULL,
	[isDeleted] [bit] NOT NULL,
	[deletionTime] [datetime2](7) NULL,
	[publishedDatetime] [datetime2](7) NULL,
	[DepartmentType] [nvarchar](100) NULL,
 CONSTRAINT [PK_chapterModels] PRIMARY KEY CLUSTERED 
(
	[chapter_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mappingModels]    Script Date: 1/31/2022 12:16:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mappingModels](
	[map_Id] [int] IDENTITY(1,1) NOT NULL,
	[categoryId] [int] NOT NULL,
	[chapter_Id] [int] NOT NULL,
	[creationTime] [datetime2](7) NOT NULL,
	[creatorUserId] [int] NULL,
 CONSTRAINT [PK_mappingModels] PRIMARY KEY CLUSTERED 
(
	[map_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220129055912_InitialCreate', N'3.1.18')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220129190308_SecondMigration', N'3.1.18')
GO
SET IDENTITY_INSERT [dbo].[categoryModels] ON 

INSERT [dbo].[categoryModels] ([category_Id], [tittle], [creation_Time], [lastmodificationTime], [isDeleted], [deletionTime]) VALUES (4, N'cat1', CAST(N'2022-01-29T19:59:17.4666667' AS DateTime2), CAST(N'2022-01-29T19:59:17.4666667' AS DateTime2), 0, CAST(N'2022-01-29T19:59:17.4666667' AS DateTime2))
INSERT [dbo].[categoryModels] ([category_Id], [tittle], [creation_Time], [lastmodificationTime], [isDeleted], [deletionTime]) VALUES (5, N'cat2', CAST(N'2022-01-29T19:59:17.4833333' AS DateTime2), CAST(N'2022-01-29T19:59:17.4833333' AS DateTime2), 0, CAST(N'2022-01-29T19:59:17.4833333' AS DateTime2))
INSERT [dbo].[categoryModels] ([category_Id], [tittle], [creation_Time], [lastmodificationTime], [isDeleted], [deletionTime]) VALUES (6, N'cat3', CAST(N'2022-01-29T19:59:17.4833333' AS DateTime2), CAST(N'2022-01-29T19:59:17.4833333' AS DateTime2), 0, CAST(N'2022-01-29T19:59:17.4833333' AS DateTime2))
SET IDENTITY_INSERT [dbo].[categoryModels] OFF
GO
SET IDENTITY_INSERT [dbo].[chapterModels] ON 

INSERT [dbo].[chapterModels] ([chapter_Id], [tittle], [active], [creation_Time], [lastmodificationTime], [isDeleted], [deletionTime], [publishedDatetime], [DepartmentType]) VALUES (1, N'Test1', 1, CAST(N'2022-01-30T23:52:39.2119292' AS DateTime2), NULL, 0, NULL, CAST(N'2022-02-02T18:30:00.0000000' AS DateTime2), N'Finance')
INSERT [dbo].[chapterModels] ([chapter_Id], [tittle], [active], [creation_Time], [lastmodificationTime], [isDeleted], [deletionTime], [publishedDatetime], [DepartmentType]) VALUES (2, N'Test23', 1, CAST(N'2022-01-30T23:54:26.4640637' AS DateTime2), CAST(N'2022-01-31T00:07:32.4180177' AS DateTime2), 0, NULL, CAST(N'2022-02-03T18:30:00.0000000' AS DateTime2), N'Admin')
INSERT [dbo].[chapterModels] ([chapter_Id], [tittle], [active], [creation_Time], [lastmodificationTime], [isDeleted], [deletionTime], [publishedDatetime], [DepartmentType]) VALUES (3, N'Test3', 1, CAST(N'2022-01-30T23:54:49.5813859' AS DateTime2), NULL, 0, NULL, CAST(N'2022-01-07T18:30:00.0000000' AS DateTime2), N'IT')
INSERT [dbo].[chapterModels] ([chapter_Id], [tittle], [active], [creation_Time], [lastmodificationTime], [isDeleted], [deletionTime], [publishedDatetime], [DepartmentType]) VALUES (4, N'Test4', 1, CAST(N'2022-01-30T23:55:13.0487282' AS DateTime2), NULL, 0, NULL, CAST(N'2022-02-02T18:30:00.0000000' AS DateTime2), N'Finance')
INSERT [dbo].[chapterModels] ([chapter_Id], [tittle], [active], [creation_Time], [lastmodificationTime], [isDeleted], [deletionTime], [publishedDatetime], [DepartmentType]) VALUES (5, N'Test5', 1, CAST(N'2022-01-30T23:55:49.1377924' AS DateTime2), NULL, 0, NULL, CAST(N'2022-01-13T18:30:00.0000000' AS DateTime2), N'Admin')
SET IDENTITY_INSERT [dbo].[chapterModels] OFF
GO
SET IDENTITY_INSERT [dbo].[mappingModels] ON 

INSERT [dbo].[mappingModels] ([map_Id], [categoryId], [chapter_Id], [creationTime], [creatorUserId]) VALUES (1, 5, 1, CAST(N'2022-01-30T23:52:39.9199697' AS DateTime2), 101)
INSERT [dbo].[mappingModels] ([map_Id], [categoryId], [chapter_Id], [creationTime], [creatorUserId]) VALUES (2, 6, 1, CAST(N'2022-01-30T23:52:39.9709727' AS DateTime2), 101)
INSERT [dbo].[mappingModels] ([map_Id], [categoryId], [chapter_Id], [creationTime], [creatorUserId]) VALUES (3, 5, 2, CAST(N'2022-01-30T23:54:26.4880651' AS DateTime2), 101)
INSERT [dbo].[mappingModels] ([map_Id], [categoryId], [chapter_Id], [creationTime], [creatorUserId]) VALUES (4, 4, 3, CAST(N'2022-01-30T23:54:49.6473897' AS DateTime2), 101)
INSERT [dbo].[mappingModels] ([map_Id], [categoryId], [chapter_Id], [creationTime], [creatorUserId]) VALUES (5, 5, 3, CAST(N'2022-01-30T23:54:49.6873920' AS DateTime2), 101)
INSERT [dbo].[mappingModels] ([map_Id], [categoryId], [chapter_Id], [creationTime], [creatorUserId]) VALUES (6, 4, 4, CAST(N'2022-01-30T23:55:13.0597288' AS DateTime2), 101)
INSERT [dbo].[mappingModels] ([map_Id], [categoryId], [chapter_Id], [creationTime], [creatorUserId]) VALUES (7, 5, 4, CAST(N'2022-01-30T23:55:13.0967309' AS DateTime2), 101)
INSERT [dbo].[mappingModels] ([map_Id], [categoryId], [chapter_Id], [creationTime], [creatorUserId]) VALUES (8, 6, 4, CAST(N'2022-01-30T23:55:13.0987311' AS DateTime2), 101)
INSERT [dbo].[mappingModels] ([map_Id], [categoryId], [chapter_Id], [creationTime], [creatorUserId]) VALUES (9, 4, 5, CAST(N'2022-01-30T23:55:49.2047962' AS DateTime2), 101)
INSERT [dbo].[mappingModels] ([map_Id], [categoryId], [chapter_Id], [creationTime], [creatorUserId]) VALUES (10, 6, 5, CAST(N'2022-01-30T23:55:49.2637996' AS DateTime2), 101)
SET IDENTITY_INSERT [dbo].[mappingModels] OFF
GO
