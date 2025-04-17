--New table for 16×16 binary input only
CREATE TABLE dbo.TrainingData16
(
    ID_TrainingData16 INT IDENTITY(1,1) PRIMARY KEY,
    InputData         VARBINARY(32)   NOT NULL,  --256 bits = 32 bytes
    DataLabel         CHAR(1)         NOT NULL,  --'0'–'9' or 'n'
    LastUpdated       DATETIME        NOT NULL  DEFAULT GETDATE()
);
