USE [WebSite]
GO
/****** Object:  Table [dbo].[Aluno_Curso]    Script Date: 11/11/2019 1:06:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aluno_Curso](
	[Id_user] [int] NOT NULL,
	[Id_Curso] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_user] ASC,
	[Id_Curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Aluno_Curso]  WITH CHECK ADD  CONSTRAINT [FK__Aluno_Cur__Id_Cu__68487DD7] FOREIGN KEY([Id_Curso])
REFERENCES [dbo].[Curso] ([Id_curso])
GO
ALTER TABLE [dbo].[Aluno_Curso] CHECK CONSTRAINT [FK__Aluno_Cur__Id_Cu__68487DD7]
GO
ALTER TABLE [dbo].[Aluno_Curso]  WITH CHECK ADD  CONSTRAINT [FK__Aluno_Cur__Id_us__6754599E] FOREIGN KEY([Id_user])
REFERENCES [dbo].[tb_user] ([Id_user])
GO
ALTER TABLE [dbo].[Aluno_Curso] CHECK CONSTRAINT [FK__Aluno_Cur__Id_us__6754599E]
GO
