CREATE TABLE Neuron (
	id_neuron INT,
	layer_index INT NOT NULL,
	neuron_index INT NOT NULL,
	from_neuron INT,
	[weight] FLOAT,
	bias FLOAT,
	created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP);

	GO


