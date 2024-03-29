USE [WebSite]
GO
/****** Object:  Table [dbo].[tb_user]    Script Date: 11/11/2019 1:06:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_user](
	[Id_user] [int] IDENTITY(1,1) NOT NULL,
	[Name_user] [nvarchar](150) NOT NULL,
	[Login_user] [nvarchar](100) NOT NULL,
	[Password_user] [nvarchar](100) NOT NULL,
	[User_Type] [char](10) NULL,
 CONSTRAINT [PK_ID_USER] PRIMARY KEY CLUSTERED 
(
	[Id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Login_user_Unique] UNIQUE NONCLUSTERED 
(
	[Login_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_user] ADD  CONSTRAINT [DF_tb_user_User_Type]  DEFAULT ('ALUNO') FOR [User_Type]
GO
