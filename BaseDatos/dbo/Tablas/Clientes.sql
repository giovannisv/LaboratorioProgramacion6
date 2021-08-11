CREATE TABLE [dbo].[clientes]
(
	ClientesId INT  NOT NULL IDENTITY(1,1) CONSTRAINT Pk_Clientes PRIMARY KEY CLUSTERED (ClientesId)
	,NombreCompleto VARCHAR (250) NOT NULL
	,Direccion VARCHAR (500) NOT NULL
	,Telefono VARCHAR (500) 
	,AgenciaId INT NOT NULL
	CONSTRAINT Fk_Clientes_Agencias FOREIGN KEY (AgenciaId)
	REFERENCES dbo.Agencias(AgenciaId)
	,Estado  BIT
)
WITH (DATA_COMPRESSION = PAGE)
GO
