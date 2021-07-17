CREATE PROCEDURE [dbo].[MarcaVehiculoObtener]
	@MarcaVehiculoID INT=NULL
	
AS
	BEGIN

	SELECT
	MarcaVehiculoID
	,Descripcion
	,Estado

	FROM marcavehiculo
	where (@MarcaVehiculoID IS NULL OR MarcaVehiculoID = @MarcaVehiculoID)
	END

