CREATE PROCEDURE [dbo].[VehiculoInsertar]
    @MarcaVehiculoID INT,
	@Matricula varchar(250)	,
	@Color varchar(250)	,
	@Modelo varchar(250),	
	@FechaModelo DATE,
	@TieneDefectos BIT ,
	@Defectos VARCHAR(1000)= NULL,
	@Estado BIT
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	-- AQUI VA EL CODIGO
		
		INSERT INTO vehiculo 
		(
	     MarcaVehiculoID
	    , Matricula 
	    , Color
	    , Modelo 	     
		, FechaModelo
		, TieneDefectos
		, Defectos
		, Estado
		)
		VALUES
		(
		 @MarcaVehiculoID
	    , @Matricula 
	    , @Color
	    , @Modelo	    
		, @FechaModelo
		, @TieneDefectos
		, @Defectos
		, @Estado 
		)


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