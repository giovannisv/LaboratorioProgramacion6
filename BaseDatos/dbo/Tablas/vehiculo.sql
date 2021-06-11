﻿CREATE TABLE [dbo].[vehiculo]
(
	VehiculoId INT NOT NULL IDENTITY (1,1) CONSTRAINT PK_Vehiculo  PRIMARY KEY CLUSTERED(VehiculoID)
	, Matricula VARCHAR (250) NOT NULL
	, Color VARCHAR (250) NOT NULL
	, FechaModelo DATE NOT NULL CONSTRAINT DF_Vehiculo_FechaModelo default ('2020-01-01')
	, Estado BIT NOT NULL
	)
	WITH (DATA_COMPRESSION = PAGE)
	GO

	CREATE UNIQUE NONCLUSTERED INDEX IDX_Vehiculo_Matricula
	ON dbo.Vehiculo(Matricula)
	WITH (DATA_COMPRESSION = PAGE)
	GO
