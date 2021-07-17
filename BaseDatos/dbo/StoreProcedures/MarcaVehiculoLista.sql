CREATE PROCEDURE dbo.MarcaVehiculoLista

AS
	BEGIN
		SET NOCOUNT ON



		SELECT 
		MarcaVehiculoId,
		Descripcion

		FROM	
			dbo.marcavehiculo

			WHERE
					Estado=1






	END