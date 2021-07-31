CREATE PROCEDURE dbo.MarcaVehiculoLista

AS
	BEGIN
		SET NOCOUNT ON



		SELECT 
		MarcaVehiculoID,
		Descripcion

		FROM	
			dbo.marcavehiculo

			WHERE
					Estado=1

	END