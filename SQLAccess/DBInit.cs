using System;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

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

        public void Init()
        {
            //This class is only used for setting up the DB
            //We will have another class for reading and writing
            CreateDB();
            CreateSchema();

        }

        private void CreateDB()
        {
            string scriptFile = Path.Combine(Directory.GetCurrentDirectory(), "SQLScripts", "Databases", "HWNN.sql");

            ExecuteSqlScript(_masterConnectionString, scriptFile);
        }

        private void CreateSchema()
        {
            string tablesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SQLScripts", "Tables");

            string[] files = Directory.GetFiles(tablesDir, "*.sql");

            if (files.Length == 0)
            {
                Console.WriteLine("No SQL files found in: " + tablesDir);
                return;
            }

            foreach (string file in files)
            {
                Console.WriteLine("Executing SQL file: " + file);
                ExecuteSqlScript(_databaseConnectionString, file);
            }
        }

        private void ExecuteSqlScript(string connectionString, string scriptFile)
        {
            string script = File.ReadAllText(scriptFile);

            string[] commands = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (string command in commands)
                {
                    if (!string.IsNullOrWhiteSpace(command))
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = command;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
