USE [WebSite]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 11/11/2019 1:06:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id_Categoria] [int] NOT NULL,
	[desc_cat] [nvarchar](50) NULL,
 CONSTRAINT [PK__Categori__CB903349F582D5FD] PRIMARY KEY CLUSTERED 
(
	[Id_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
