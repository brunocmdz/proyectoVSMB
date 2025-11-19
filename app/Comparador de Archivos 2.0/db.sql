---------------------------------------------------------
-- CREAR BASE DE DATOS (solo si no existe)
---------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ComparadorDB')
BEGIN
    CREATE DATABASE ComparadorDB;
END
GO

---------------------------------------------------------
-- USAR LA BASE DE DATOS
---------------------------------------------------------
USE ComparadorDB;
GO

---------------------------------------------------------
-- TABLA: ArchivosProcesados
---------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ArchivosProcesados')
BEGIN
    CREATE TABLE ArchivosProcesados(
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Fecha DATETIME NOT NULL DEFAULT GETDATE(),
        NombreMadre VARCHAR(200) NULL,
        NombreNuevo VARCHAR(200) NULL,
        Resultado VARCHAR(MAX) NULL
    );
END
GO

---------------------------------------------------------
-- TABLA: TarjetasExtraidas
---------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TarjetasExtraidas')
BEGIN
    CREATE TABLE TarjetasExtraidas(
        Id INT IDENTITY(1,1) PRIMARY KEY,
        IdArchivo INT NULL,
        TipoTarjeta VARCHAR(MAX) NULL,
        Numero VARCHAR(MAX) NULL,
        Fecha1 VARCHAR(50) NULL,
        Fecha2 VARCHAR(10) NULL,
        Titular VARCHAR(MAX) NULL,
        Codigo VARCHAR(50) NULL,
        FOREIGN KEY (IdArchivo) REFERENCES ArchivosProcesados(Id)
    );
END
GO
