USE [WebSite]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 11/11/2019 1:06:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[Id_curso] [int] IDENTITY(1,1) NOT NULL,
	[Id_Categoria] [int] NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[desc_cur] [nvarchar](500) NOT NULL,
	[Aula1] [nvarchar](500) NOT NULL,
	[Aula2] [nvarchar](500) NULL,
	[Aula3] [nvarchar](500) NULL,
	[Aula4] [nvarchar](500) NULL,
	[Aula5] [nvarchar](500) NULL,
	[Aula6] [nvarchar](500) NULL,
	[Aula7] [nvarchar](500) NULL,
	[Aula8] [nvarchar](500) NULL,
	[Aula9] [nvarchar](500) NULL,
	[Aula10] [nvarchar](500) NULL,
 CONSTRAINT [PK__Curso__FE00CD1C7F0EE470] PRIMARY KEY CLUSTERED 
(
	[Id_curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK__Curso__Id_catego__6477ECF3] FOREIGN KEY([Id_Categoria])
REFERENCES [dbo].[Categoria] ([Id_Categoria])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK__Curso__Id_catego__6477ECF3]
GO
