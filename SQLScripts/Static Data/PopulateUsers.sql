IF NOT EXISTS (SELECT 1 FROM dbo.SystemUser WHERE UserName = 'admin')
BEGIN
    INSERT INTO dbo.SystemUser
    (
        UserName,
        [Password],
        DateCreated,
        IsAdmin
    )
    VALUES
    (
        'admin',
        'Admin@123',    
        GETDATE(),
        1
    );
END;
GO
