-- ==================================================
-- Author:		Mario Bletran
-- Create Date: 2024/04/21
-- Description: creacion de la DB para proyectos de horarios
-- ==================================================

PRINT 'creacion de la DB'
IF NOT EXISTS(SELECT NAME FROM SYSDATABASES WHERE NAME = '´Horario')
BEGIN
    CREATE DATABASE Horario
END 
GO

USE Horario
GO

PRINT 'creacion de la tabla Horarios'
IF NOT EXISTS(SELECT NAME FROM sysobjects WHERE NAME = 'Horarios')
BEGIN
    CREATE TABLE dbo.Horarios(
        id										 VARCHAR(36) NOT NULL DEFAULT '',
        Salon       							 VARCHAR(255) NOT NULL DEFAULT '',
        Nombre_Archivo							 VARCHAR(255) NOT NULL DEFAULT '',
        Extension								 VARCHAR(10) NOT NULL DEFAULT '', 
		Formato								     VARCHAR(255) NOT NULL DEFAULT '', 
        Fecha_Entrada							 SMALLDATETIME DEFAULT CURRENT_TIMESTAMP, 
        Archivos								 IMAGE NOT NULL DEFAULT '',
		Tamanio									 FLOAT NOT NULL DEFAULT '',		
        Estado									 BIT NOT NULL DEFAULT 1, 
		Eliminado								 BIT NOT NULL DEFAULT 0, ) ON [PRIMARY]
	ALTER TABLE dbo.Horarios ADD CONSTRAINT 
		PK_Horarios PRIMARY KEY CLUSTERED (id) ON [PRIMARY]	
END
GO