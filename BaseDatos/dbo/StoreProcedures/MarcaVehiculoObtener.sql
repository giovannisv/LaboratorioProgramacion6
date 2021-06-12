CREATE PROCEDURE [dbo].[MarcaVehiculoObtener]
	@MarcaVehiculoID INT=NULL
	
AS
	BEGIN

	SELECT
	MarcaVehiculoID
	,Descripcion
	,Estado

	FROM MarcaVehiculo
	END

