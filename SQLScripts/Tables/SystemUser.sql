-- Create the SystemUser table if it doesn't exist
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SystemUser')
BEGIN
    CREATE TABLE dbo.SystemUser (
        ID_SystemUser INT IDENTITY (1,1) NOT NULL PRIMARY KEY,  -- Auto-incrementing primary key
        UserName NVARCHAR(50) NOT NULL                            -- Username column
    );
END

-- Add the 'Password' column if it doesn't exist
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'SystemUser' AND COLUMN_NAME = 'Password')
BEGIN
    ALTER TABLE dbo.SystemUser
    ADD Password NVARCHAR(255);  -- Add Password column
END

-- Add the 'DateCreated' column if it doesn't exist
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'SystemUser' AND COLUMN_NAME = 'DateCreated')
BEGIN
    ALTER TABLE dbo.SystemUser
    ADD DateCreated DATETIME DEFAULT GETDATE();  -- Add DateCreated column with default value
END

-- Add the 'IsAdmin' column if it doesn't exist
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'SystemUser' AND COLUMN_NAME = 'IsAdmin')
BEGIN
    ALTER TABLE dbo.SystemUser
    ADD IsAdmin BIT NOT NULL DEFAULT 0;  -- Add IsAdmin column (default value = 0)
END

GO

