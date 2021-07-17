CREATE PROCEDURE dbo.VehiculoActualizar
	@VehiculoId INT,
	@MarcaVehiculoID INT,
    @Matricula VARCHAR(250),
	@Color VARCHAR(250),
	@Modelo VARCHAR(250),
	@Estado BIT,
	@FechaModelo DATE,
	@TieneDefectos BIT ,
	@Defectos VARCHAR(1000)= NULL
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	-- AQUI VA EL CODIGO
		
	UPDATE dbo.vehiculo SET
	 MarcaVehiculoID=@MarcaVehiculoId,
	 Matricula=@Matricula,
	 Color=@Color,
	 Modelo=@Modelo,
	 Estado=@Estado,
	 FechaModelo=@FechaModelo,
	 TieneDefectos=@TieneDefectos,
	 Defectos=@Defectos

	WHERE VehiculoId=@VehiculoId

		COMMIT TRANSACTION TRASA
		
		SELECT 0 AS CodeError, '' AS MsgError



	END TRY

	BEGIN CATCH
		SELECT 
				ERROR_NUMBER() AS CodeError
			,	ERROR_MESSAGE() AS MsgError

			ROLLBACK TRANSACTION TRASA
	END CATCH


END
