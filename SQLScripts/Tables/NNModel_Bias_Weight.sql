IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'NNModel')
BEGIN
    CREATE TABLE NNModel (
        ModelId INT IDENTITY(1,1) PRIMARY KEY,
        ModelName NVARCHAR(255) NOT NULL,
        Layers NVARCHAR(MAX) NOT NULL, --e.g., '[784,128,64,10]'
        InputSize INT NOT NULL,
        OutputSize INT NOT NULL,
        LastUpdated DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'NNBias')
BEGIN
    CREATE TABLE NNBias (
        BiasId INT IDENTITY(1,1) PRIMARY KEY,
        ModelId INT NOT NULL,
        LayerIndex INT NOT NULL,   --For example, 1 for first hidden layer, 2 for second hidden layer, etc.
        NeuronIndex INT NOT NULL,  --Index of the neuron in that layer
        BiasValue FLOAT NOT NULL,
        FOREIGN KEY (ModelId) REFERENCES NNModel(ModelId)
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'NeuralNetworkWeight')
BEGIN
    CREATE TABLE NeuralNetworkWeight (
        WeightId INT IDENTITY(1,1) PRIMARY KEY,
        ModelId INT NOT NULL,
        FromLayerIndex INT NOT NULL,  --0 for the input layer
        ToLayerIndex INT NOT NULL,    --1 for first hidden layer, etc.
        RowIndex INT NOT NULL,        --For the destination layer: the index of the neuron
        ColIndex INT NOT NULL,        --For the source layer: the index of the neuron
        WeightValue FLOAT NOT NULL,
        FOREIGN KEY (ModelId) REFERENCES NNModel(ModelId)
    );
END
GO