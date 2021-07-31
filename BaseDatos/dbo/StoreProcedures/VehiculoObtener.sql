CREATE PROCEDURE [dbo].VehiculoObtener
@VehiculoId INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
			VehiculoId
		,   MarcaVehiculoID
		,   Matricula
		,   Color
		,   Modelo		
		,   FechaModelo
		,	TieneDefectos
		,   Defectos		
		,	Descripcion
		,   Estado
				

	FROM vehiculo 
	 INNER JOIN marcavehiculo 
         ON MarcaVehiculoID = @MarcaVehiculoID
	WHERE
	     (@VehiculoId IS NULL OR VehiculoId=@VehiculoId)

END