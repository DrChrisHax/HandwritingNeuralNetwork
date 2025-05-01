using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using HandwritingNeuralNetwork.AIModel; //For NeuralNetwork2

namespace HandwritingNeuralNetwork.Models
{
    public class NNModel : model_base
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string Layers { get; set; }   //e.g. "[784,128,64,10]"
        public int InputSize { get; set; }
        public int OutputSize { get; set; }
        public DateTime LastUpdated { get; set; }

        public NNModel() : base() { }

        public NNModel(int id) : base(id) { }

        ///<summary>
        ///Helper method to parse the Layers column (a JSON-like array string) into an int array.
        ///</summary>
        public int[] GetLayersArray()
        {
            //Remove any surrounding brackets and whitespace, then split on commas.
            string trimmed = Layers.Trim('[', ']');
            return trimmed.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(s => int.Parse(s.Trim()))
                          .ToArray();
        }

        ///<summary>
        ///Loads the NeuralNetwork2 object associated with this model.
        ///It queries the biases and weights tables and then applies those values to a new NeuralNetwork2 instance.
        ///</summary>
        public NeuralNetwork2 LoadNeuralNetwork()
        {
            int[] parsedLayers = GetLayersArray();
            NeuralNetwork2 nn = new NeuralNetwork2(parsedLayers);

            //--- Load Biases ---
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM NNBias WHERE ModelId = @ModelId";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@ModelId", ModelId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Columns: BiasId, ModelId, LayerIndex, NeuronIndex, BiasValue
                            int layerIndex = (int)reader["LayerIndex"]; //SQL stores 1 for first hidden layer, etc.
                            int neuronIndex = (int)reader["NeuronIndex"];
                            double biasValue = (double)reader["BiasValue"];

                            //Since the NeuralNetwork2.biases list is zero-indexed,
                            //use (layerIndex - 1) as the index.
                            nn.SetBias(layerIndex - 1, neuronIndex, biasValue);
                        }
                    }
                }
            }

            //--- Load Weights ---
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM NNWeight WHERE ModelId = @ModelId";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@ModelId", ModelId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Columns: WeightId, ModelId, FromLayerIndex, ToLayerIndex, RowIndex, ColIndex, WeightValue
                            int toLayerIndex = (int)reader["ToLayerIndex"];
                            int rowIndex = (int)reader["RowIndex"];
                            int colIndex = (int)reader["ColIndex"];
                            double weightValue = (double)reader["WeightValue"];

                            //The weight matrix list in NeuralNetwork2 is zero-indexed,
                            //so use (toLayerIndex - 1) as the matrix index.
                            nn.SetWeight(toLayerIndex - 1, rowIndex, colIndex, weightValue);
                        }
                    }
                }
            }

            return nn;
        }

        ///<summary>
        ///Bulk‐inserts all biases and weights for the given network using SqlBulkCopy.
        ///</summary>
        public bool SaveNeuralNetwork(NeuralNetwork2 nn)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var tx = connection.BeginTransaction())
                    {
                        // 1) Clean out old params
                        using (var del = new SqlCommand(
                            "DELETE FROM NNBias WHERE ModelId = @ModelId; " +
                            "DELETE FROM NNWeight WHERE ModelId = @ModelId;",
                            connection, tx))
                        {
                            del.Parameters.AddWithValue("@ModelId", ModelId);
                            del.ExecuteNonQuery();
                        }

                        // 2) Build bias DataTable
                        var biasTable = new DataTable();
                        biasTable.Columns.Add("ModelId", typeof(int));
                        biasTable.Columns.Add("LayerIndex", typeof(int));
                        biasTable.Columns.Add("NeuronIndex", typeof(int));
                        biasTable.Columns.Add("BiasValue", typeof(double));

                        int biasCount = 0;
                        for (int layer = 0; layer < nn.Biases.Count; layer++)
                        {
                            int layerIdx = layer + 1;
                            for (int neuron = 0; neuron < nn.Biases[layer].Length; neuron++)
                            {
                                biasTable.Rows.Add(
                                    ModelId,
                                    layerIdx,
                                    neuron,
                                    nn.Biases[layer][neuron]
                                );
                                biasCount++;
                            }
                        }
                        Debug.WriteLine($"[SaveNN] Prepared {biasCount} bias rows.");

                        // 3) Build weight DataTable
                        var weightTable = new DataTable();
                        weightTable.Columns.Add("ModelId", typeof(int));
                        weightTable.Columns.Add("FromLayerIndex", typeof(int));
                        weightTable.Columns.Add("ToLayerIndex", typeof(int));
                        weightTable.Columns.Add("RowIndex", typeof(int));
                        weightTable.Columns.Add("ColIndex", typeof(int));
                        weightTable.Columns.Add("WeightValue", typeof(double));

                        int weightCount = 0;
                        for (int layer = 0; layer < nn.Weights.Count; layer++)
                        {
                            int fromLayer = layer;
                            int toLayer = layer + 1;
                            var mat = nn.Weights[layer];
                            for (int i = 0; i < mat.GetLength(0); i++)
                            {
                                for (int j = 0; j < mat.GetLength(1); j++)
                                {
                                    weightTable.Rows.Add(
                                        ModelId,
                                        fromLayer,
                                        toLayer,
                                        i,
                                        j,
                                        mat[i, j]
                                    );
                                    weightCount++;
                                }
                            }
                        }
                        Debug.WriteLine($"[SaveNN] Prepared {weightCount} weight rows.");

                        // 4) Bulk‐copy biases
                        using (var bulk = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, tx))
                        {
                            bulk.DestinationTableName = "NNBias";
                            bulk.ColumnMappings.Add("ModelId", "ModelId");
                            bulk.ColumnMappings.Add("LayerIndex", "LayerIndex");
                            bulk.ColumnMappings.Add("NeuronIndex", "NeuronIndex");
                            bulk.ColumnMappings.Add("BiasValue", "BiasValue");
                            bulk.WriteToServer(biasTable);
                        }

                        // 5) Bulk‐copy weights
                        using (var bulk = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, tx))
                        {
                            bulk.DestinationTableName = "NNWeight";
                            bulk.ColumnMappings.Add("ModelId", "ModelId");
                            bulk.ColumnMappings.Add("FromLayerIndex", "FromLayerIndex");
                            bulk.ColumnMappings.Add("ToLayerIndex", "ToLayerIndex");
                            bulk.ColumnMappings.Add("RowIndex", "RowIndex");
                            bulk.ColumnMappings.Add("ColIndex", "ColIndex");
                            bulk.ColumnMappings.Add("WeightValue", "WeightValue");
                            bulk.WriteToServer(weightTable);
                        }

                        tx.Commit();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                return false;
            }
        }
    }
}
