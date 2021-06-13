﻿CREATE PROCEDURE [dbo].[MarcaVehiculoActualizar]
	@Descripcion VARCHAR (250),
	@MarcaVehiculoID INT,	
	@Estado BIT
	AS
	BEGIN 
	SET NOCOUNT ON
	BEGIN Transaction TRASA
	BEGIN 	TRY --Metodos
	UPDATE MarcaVehiculo
	SET 
	Descripcion=@Descripcion,
	Estado=@Estado
	WHERE
	MarcaVehiculoID = @MarcaVehiculoID

	COMMIT TRANSACTION TRASA
	SELECT 0 AS CodeError, '' AS MsgError
	END TRY
	BEGIN CATCH

	SELECT
	ERROR_NUMBER() AS CodeError
	, ERROR_MESSAGE() AS MsgError
	ROLLBACK TRANSACTION TRASA
	END CATCH
	END
