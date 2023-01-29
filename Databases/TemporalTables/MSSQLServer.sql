DECLARE @TableName AS VARCHAR(120) = ''
DECLARE @sql VARCHAR(MAX)

-- Having a primary key is a prerequisite. Most tables include them at creation, but uncomment this if you need to declare one.
-- Tener una clave principal es un requisito previo. La mayoría de las tablas las incluyen en la creación, pero descomente esto si necesita declarar una.
--SET @sql = 'ALTER TABLE ' + QUOTENAME(@TableName) + ' ADD CONSTRAINT PK_ColumnName PRIMARY KEY CLUSTERED(ColumnName ASC)'
--EXEC(@sql)

SET @sql = 'ALTER TABLE ' + QUOTENAME(@TableName) + ' ADD SysStartTime DATETIME2'
EXEC(@sql)

SET @sql = 'ALTER TABLE ' + QUOTENAME(@TableName) + ' ADD SysEndTime DATETIME2'
EXEC(@sql)

SET @sql = 'UPDATE ' + QUOTENAME(@TableName) + ' SET SysStartTime = ''19000101 00:00:00.0000000'', SysEndTime = ''99991231 23:59:59.9999999'''
EXEC(@sql)

SET @sql = 'ALTER TABLE ' + QUOTENAME(@TableName) + ' ALTER COLUMN SysStartTime DATETIME2 NOT NULL'
EXEC(@sql)

SET @sql = 'ALTER TABLE ' + QUOTENAME(@TableName) + ' ALTER COLUMN SysEndTime DATETIME2 NOT NULL'
EXEC(@sql)

SET @sql = 'ALTER TABLE ' + QUOTENAME(@TableName) + ' ADD PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)'
EXEC(@sql)

SET @sql = 'ALTER TABLE ' + QUOTENAME(@TableName) + ' SET(SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.' + QUOTENAME(@TableName) + '_History, DATA_CONSISTENCY_CHECK = ON))'
EXEC(@sql)
