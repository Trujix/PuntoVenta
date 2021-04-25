-- VERIFICA SI LA BD EXISTE, SINO LA CREA
If(db_id(N'pventa') IS NULL) 
	CREATE DATABASE pventa;

-- INICIALIZA EL USO DE LA BD
USE pventa;

-- COMIENZA LA CONSTRUCCION
DROP TABLE IF EXISTS dbo.usuarios;

CREATE TABLE [dbo].[usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](200) NOT NULL,
	[pass] [varchar](200) NOT NULL,
	/*[tokenusuario] [varchar](200) NOT NULL,
	[tokencentro] [varchar](200) NOT NULL,
	[nombre] [varchar](200) NOT NULL,
	[apellido] [varchar](200) NOT NULL,
	[correo] [varchar](200) NOT NULL,
	[administrador] [bit] NOT NULL DEFAULT 'False',
	[activo] [int] NOT NULL DEFAULT 1,
	[estatus] [int] NOT NULL DEFAULT 1,
	[idnotificacion] [varchar](200) NOT NULL,
	[fechahora] [datetime] NULL,
	[admusuario] [varchar](50) NULL,*/
		CONSTRAINT [PK_UsuarioID] PRIMARY KEY CLUSTERED ([id] ASC)
);

INSERT INTO dbo.usuarios (usuario, pass) VALUES ('tgomez','123');
INSERT INTO dbo.usuarios (usuario, pass) VALUES ('dmorfin','456');