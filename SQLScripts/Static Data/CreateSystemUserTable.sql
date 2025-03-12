
IF NOT EXISTS (
    SELECT 1
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_NAME = 'SystemUser'
      AND TABLE_SCHEMA = 'dbo'
)
BEGIN
    CREATE TABLE dbo.SystemUser
    (
        ID_SystemUser INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        UserName      NVARCHAR(50) NOT NULL
    );
END;
GO

IF NOT EXISTS (
    SELECT 1
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'SystemUser'
      AND COLUMN_NAME = 'Password'
      AND TABLE_SCHEMA = 'dbo'
)
BEGIN
    ALTER TABLE dbo.SystemUser
    ADD Password NVARCHAR(255);
END;
GO

IF NOT EXISTS (
    SELECT 1
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'SystemUser'
      AND COLUMN_NAME = 'DateCreated'
      AND TABLE_SCHEMA = 'dbo'
)
BEGIN
    ALTER TABLE dbo.SystemUser
    ADD DateCreated DATETIME;
END;
GO

IF NOT EXISTS (
    SELECT 1
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'SystemUser'
      AND COLUMN_NAME = 'IsAdmin'
      AND TABLE_SCHEMA = 'dbo'
)
BEGIN
    ALTER TABLE dbo.SystemUser
    ADD IsAdmin BIT;
END;
GO

-- Test that the table and columns exist
SELECT * FROM dbo.SystemUser;
GO
