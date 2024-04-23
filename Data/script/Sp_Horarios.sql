-- ==================================================
-- Author:		Mario Beltran
-- Create Date: 2024/04/21
-- Description: creacion de sp para tabla horarios
-- ==================================================
PRINT 'Creacion procedimientos de horarios'
IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME LIKE 'db_sp_Horario_%')
BEGIN
    DROP PROCEDURE dbo.db_sp_Horario_insert
	DROP PROCEDURE dbo.db_sp_Horario_select
    DROP PROCEDURE dbo.db_sp_Horario_buscar
END

PRINT 'Creacion procedimiento insert'
GO
CREATE PROCEDURE dbo.db_sp_Horario_insert
	@id										 VARCHAR(36), 
	@Salon									 VARCHAR(255),
	@Nombre_Archivo							 VARCHAR(255),
    @Extension								 VARCHAR(10) , 
	@Formato								 VARCHAR(255),    
    @Archivos								 IMAGE,
	@Tamanio								 FLOAT
AS 
BEGIN
	INSERT INTO dbo.Horarios(id,Salon, Nombre_Archivo, Extension, Formato, Fecha_Entrada, Archivos, Tamanio, Estado, Eliminado) VALUES
                              (@id, @Salon, @Nombre_Archivo, @Extension, @Formato, GETDATE(), @Archivos, @Tamanio, 1, 0);        
END

PRINT 'Creacion procedimiento select'
GO
CREATE PROCEDURE dbo.db_sp_Horario_select
	    @ID          VARCHAR(36)    
AS 
BEGIN
    SELECT id, Nombre_Archivo, Extension, Formato, Fecha_Entrada, Archivos, Tamanio 
    FROM dbo.Horarios
    WHERE id = @ID
END

PRINT 'Creacion procedimiento buscar salones'
GO
CREATE PROCEDURE dbo.db_sp_Horario_buscar
	    @Salon          VARCHAR(255)    
AS 
BEGIN
    SELECT id, Salon 
    FROM dbo.Horarios
    WHERE Salon = @Salon
END

PRINT 'Creacion procedimiento Horario Del '
GO
CREATE PROCEDURE dbo.db_sp_Horario_Del
	@Id VARCHAR(36)
AS
BEGIN
    -- Actualiza el estado "Eliminado" a 1
    UPDATE dbo.Horarios
    SET Eliminado = 1
    WHERE id = @Id;
	
	-- Obtiene el estado "Eliminado" despues de la actualizacion 
    SELECT Eliminado
    FROM dbo.Horarios
    WHERE id = @Id;    
END 

