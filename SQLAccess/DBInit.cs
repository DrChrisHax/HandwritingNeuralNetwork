using System;
using System.Data.SqlClient;
using System.IO;

namespace HandwritingNeuralNetwork.SQLAccess
{
    public class DBInit
    {
        private readonly string _masterConnectionString;
        private readonly string _databaseConnectionString;
        private const string DatabaseName = "HWNN";

        public DBInit()
        {
            _masterConnectionString = "Server=CHRIS-LAPTOP\\HWNN;Database=master;User Id=sa;Password=abc123!@#;";
            _databaseConnectionString = $"Server=CHRIS-LAPTOP\\HWNN;Database={DatabaseName};User Id=sa;Password=abc123!@#;";
        }

        public void Connect()
        {
            if(!DBExists())
            {
                CreateDB();
                CreateSchema();
            }
        }

        private bool DBExists()
        {
            using (var conn = new SqlConnection(_masterConnectionString))
            {
                conn.Open();
                string query = $"SELECT COUNT(*) FROM sys.databases WHERE name = '{DatabaseName}'";

                using (var cmd = new SqlCommand(query, conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();
                    return count > 0;
                }
            }
        }

        private void CreateDB()
        {

        }

        private void CreateSchema()
        {

        }

    }
}
