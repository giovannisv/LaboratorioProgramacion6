CREATE PROCEDURE [dbo].[MarcaVehiculoActualizar]
	@MarcaVehiculoID INT,	
	@Descripcion VARCHAR (250),	
	@Estado BIT
	AS
	BEGIN 
	SET NOCOUNT ON
	BEGIN Transaction TRASA
	BEGIN 	TRY --Metodos
	UPDATE marcavehiculo
	SET 
	Descripcion=@Descripcion
	
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
