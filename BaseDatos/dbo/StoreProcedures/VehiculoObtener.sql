CREATE PROCEDURE [dbo].VehiculoObtener
@VehiculoId INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
			VehiculoId
		,   Matricula
		,   Color
		,   Modelo		
		,   FechaModelo
		,	TieneDefectos
		,   Defectos
		,   Estado
		,   MarcaVehiculoID
		,	Descripcion
	
				

	FROM vehiculo 
	 INNER JOIN MarcaVehiculo 
         ON MarcaVehiculoID = MarcaVehiculoId
	WHERE
	     (@VehiculoId IS NULL OR VehiculoId=@VehiculoId)

END