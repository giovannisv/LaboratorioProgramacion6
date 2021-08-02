CREATE PROCEDURE [dbo].[MarcaVehiculoLista]

AS
	BEGIN
		SET NOCOUNT ON



		SELECT 
		MarcaVehiculoID,
		Descripcion

		FROM	
			marcavehiculo

			WHERE
					Estado=1

	END