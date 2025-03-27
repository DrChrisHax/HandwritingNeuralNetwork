IF NOT EXISTS (SELECT 1 FROM dbo.AIModelTable WHERE ModelName = 'HWNN v0.1')
BEGIN
	INSERT INTO 
	dbo.AIModelTable (ModelName, Trainable, Deployed)
	VALUES ('HWNN v0.1', 1, 0)
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.AIModelTable WHERE ModelName = 'MINST v0.1')
BEGIN
	INSERT INTO 
	dbo.AIModelTable (ModelName, Trainable, Deployed)
	VALUES ('MINST v0.1', 1, 1)
END
GO
