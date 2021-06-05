/*
No cambie las variables de nombre o ruta de acceso de la base de datos.
Cualquier variable sqlcmd será correctamente sustituida durante 
la compilación y la implementación.
*/
ALTER DATABASE [$(DatabaseName)]
	ADD FILE
	(
		NAME = [MarcaVehiculo],
		FILENAME = '$(DefaultDataPath)$(DefaultFilePrefix)_MarcaVehiculo.ndf'
	)
	
