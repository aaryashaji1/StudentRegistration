USE [StudentRegistrationDatabase]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 4/9/2021 5:03:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Name] [varchar](20) NOT NULL,
	[Address] [varchar](20) NOT NULL,
	[Gender] [varchar](20) NOT NULL,
	[SSLC] [varchar](20) NOT NULL,
	[PlusTwo] [varchar](20) NOT NULL,
	[Ug] [varchar](20) NOT NULL,
	[Pg] [varchar](20) NOT NULL,
	[Image] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Student] ([Name], [Address], [Gender], [SSLC], [PlusTwo], [Ug], [Pg], [Image]) VALUES (N'Arya', N'Kalady', N'F', N'1', N'1', N'0', N'0', N'C:\Users\ASUS\Downloads\Raf747df4fe1655615d99af2e4dfead5c.jpg')
INSERT [dbo].[Student] ([Name], [Address], [Gender], [SSLC], [PlusTwo], [Ug], [Pg], [Image]) VALUES (N'Anu', N'Angamaly', N'F', N'0', N'1', N'0', N'1', N'C:\Users\ASUS\Downloads\2.jpg')
INSERT [dbo].[Student] ([Name], [Address], [Gender], [SSLC], [PlusTwo], [Ug], [Pg], [Image]) VALUES (N'Amal', N'Malapuram', N'M', N'0', N'1', N'1', N'0', N'C:\Users\ASUS\Downloads\OIP (5).jpg')
INSERT [dbo].[Student] ([Name], [Address], [Gender], [SSLC], [PlusTwo], [Ug], [Pg], [Image]) VALUES (N'Kiran', N'Trisur', N'M', N'0', N'0', N'1', N'1', N'C:\Users\ASUS\Downloads\8.jpg')
GO
/****** Object:  StoredProcedure [dbo].[StudentRead]    Script Date: 4/9/2021 5:03:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StudentRead]
	@Name VARCHAR(20)
AS
BEGIN
SELECT
	[Name]
	,	[Address]
	,	[Gender]
	,	[SSLC]
	,	[PlusTwo]
	,	[Ug]
	,	[Pg]
	,	[Image]
FROM [dbo].[Student]
WHERE [Name]=@Name
END
GO
/****** Object:  StoredProcedure [dbo].[StudentSave]    Script Date: 4/9/2021 5:03:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StudentSave]
	@Name	VARCHAR(20)
	,	@Address	VARCHAR(20)
	,	@Gender		VARCHAR(20)
	,	@Sslc	VARCHAR(20)
	,	@PlusTwo VARCHAR(20)
	,	@Ug	VARCHAR(20)
	,	@Pg	VARCHAR(20)
	,	@Image	VARCHAR(MAX)
AS
BEGIN
INSERT INTO [dbo].[Student]
(
	[Name]
	,	[Address]
	,	[Gender]
	,	[SSLC]
	,	[PlusTwo]
	,	[Ug]
	,	[Pg]
	,	[Image]
)
VALUES
(
	@Name
	,	@Address
	,	@Gender
	,	@Sslc
	,	@PlusTwo
	,	@Ug
	,	@Pg
	,	@Image
)
END
GO
