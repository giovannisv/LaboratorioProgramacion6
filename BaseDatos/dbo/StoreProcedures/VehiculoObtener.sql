﻿CREATE PROCEDURE [dbo].[VehiculoObtener]
@VehiculoId INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
			V.VehiculoId		
		,  V.Matricula
		,   V.Color
		,   V.Modelo
		,   FechaModelo
		,	TieneDefectos
		,   Defectos		
		,   Estado
		,   MV.MarcaVehiculoID
		,	MV.Descripcion

	FROM vehiculo V
	 INNER JOIN  MarcaVehiculo MV
         ON  V.MarcaVehiculoID = MV.MarcaVehiculoID
	WHERE
	     (@VehiculoId IS NULL OR VehiculoId=@VehiculoId)

END