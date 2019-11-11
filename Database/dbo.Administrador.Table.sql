USE [WebSite]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 11/11/2019 1:06:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[Id_Adm] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[usuario] [nvarchar](20) NOT NULL,
	[senha] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Adm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
