USE [WebSite]
GO
/****** Object:  View [dbo].[vw_Cursos]    Script Date: 11/11/2019 1:06:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Cursos] AS

  SELECT Nome
		,desc_cur [Descrição do curso]
		,cc.desc_cat [Categoria]
		,Aula1 [Aula 01]
		,Aula2 [Aula 02]
		,Aula3 [Aula 03]
		,Aula4 [Aula 04]
		,Aula5 [Aula 05]
		,Aula6 [Aula 06]
		,Aula7 [Aula 07]
		,Aula8 [Aula 08]
		,Aula9 [Aula 09]
		,Aula10 [Aula 10]
  FROM Curso c, Categoria cc
  WHERE c.id_categoria = cc.Id_Categoria
GO
