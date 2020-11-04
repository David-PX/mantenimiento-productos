USE [MANTEMIENTO_PRODUCTO]
GO
/****** Object:  Table [dbo].[CATEGORIA]    Script Date: 7/5/2020 11:22:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIA](
	[IDCATEGORIA] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO]  AS ('CT'+right('00'+CONVERT([varchar],[IDCATEGORIA]),(2))),
	[NOMBRE] [nvarchar](30) NOT NULL,
	[DESCRIPCION] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCATEGORIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCARCATEGORIA]    Script Date: 7/5/2020 11:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_BUSCARCATEGORIA]
@BUSCAR NVARCHAR(20)
AS 
SELECT * FROM CATEGORIA
WHERE NOMBRE LIKE @BUSCAR + '%'
GO
/****** Object:  StoredProcedure [dbo].[SP_EDITARCATEGORIA]    Script Date: 7/5/2020 11:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---PROCEDIMIENTO EDITAR CATEGORIA
CREATE PROC [dbo].[SP_EDITARCATEGORIA]
@IDCATEGORIA INT,
@NOMBRE NVARCHAR(30),
@DESCRIPCION VARCHAR(256)
AS
UPDATE CATEGORIA SET NOMBRE = @NOMBRE, DESCRIPCION=@DESCRIPCION
WHERE IDCATEGORIA = @IDCATEGORIA
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINARCATEGORIA]    Script Date: 7/5/2020 11:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--- PROCEDIMIENTO PARA ELIMINAR REGISTRO
CREATE  PROC [dbo].[SP_ELIMINARCATEGORIA]
@IDCATEGORIA INT
AS
DELETE CATEGORIA
WHERE IDCATEGORIA = @IDCATEGORIA
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTARCATEGORIA]    Script Date: 7/5/2020 11:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--PROCEDIMIENTO INSERTAR CATEGORIA
CREATE PROC [dbo].[SP_INSERTARCATEGORIA]
@NOMBRE NVARCHAR(30),
@DESCRIPCION NVARCHAR(256)
AS
INSERT INTO CATEGORIA VALUES (@NOMBRE,@DESCRIPCION)
GO