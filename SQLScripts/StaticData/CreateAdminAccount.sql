IF NOT EXISTS (SELECT 1 FROM dbo.SystemUser WHERE UserName = 'Admin')
BEGIN
	INSERT INTO 
	dbo.SystemUser (UserName, Password, DateCreated, IsAdmin)
	VALUES ('Admin', 'bbb7b19fe1ed2f32883d32234246d88462df528f1a05d358957aeed805a447e0', GETDATE(), 1)
END
GO
