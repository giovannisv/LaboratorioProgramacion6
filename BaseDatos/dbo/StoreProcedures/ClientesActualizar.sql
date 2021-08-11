﻿CREATE PROCEDURE [dbo].ClientesActualizar
	@ClientesId INT,
	@NombreCompleto VARCHAR(250),
	@Direccion varchar(500),
	@Telefono varchar(500),
	@AgenciaId INT,
    @Estado BIT
	
	
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

		
		update dbo.Clientes set     
	      NombreCompleto=@NombreCompleto,
		  Direccion=@Direccion,
		  Telefono=@Telefono,
		  AgenciaId=@AgenciaId,
		  Estado=@Estado
		where ClientesId=@ClientesId


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